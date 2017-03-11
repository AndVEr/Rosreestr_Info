using System;
using System.Data;
using System.IO;
using System.Text;

public class md_general
{
    public class PKK_Property_Info
    {
        public pkk_feature feature;
        public string note;
        public int status;
    }
    public class pkk_feature
    {
        public pkk_attrs attrs;
        public pkk_center center;
        public pkk_extent extent;
        public bool stat;
        public int type;
    }
    public class pkk_attrs { 
        public DateTime adate;
        public string address;
        public string anno_text;
        public string area_type;
        public string area_unit;
        public decimal area_value;
        public decimal cad_cost;
        public pkk_cad_eng_data cad_eng_data;
        public DateTime cad_record_date;
        public string cad_unit;
        public string category_type;
        public string cn;
        public DateTime date_cost;
        public DateTime date_create;
        public string fp;
        public string id;
        public string kvartal;
        public string kvartal_cn;
        public string okrug;
        public string okrug_cn;
        public DateTime pubdate;
        public string rayon;
        public string rayon_cn;
        public int reg;
        public string rifr;
        public int rights_reg;
        public int sale;
        public string statecd;
        public string util_by_doc;
        public string util_code;
        }
    public class pkk_cad_eng_data
    {
        public string actual_date;
        public string ci_first;
        public string ci_n_certificate;
        public string ci_patronymic;
        public string ci_surname;
        public string lastmodified;
        public int rc_type;
    }
    public class pkk_center
    {
        public decimal x;
        public decimal y;
    }
    public class pkk_extent
    {
        public decimal xmax;
        public decimal xmin;
        public decimal ymax;
        public decimal ymin;
    }

    public static DataTable GetCadastralInfoFromPKK_REST(string cadastral)
    {
        //System.Net.WebClient obj = new System.Net.WebClient();
        string rosreestr_id = "";
        string str_text = "";
        //UTF8Encoding utf8 = new UTF8Encoding();
        //byte[] qqq;
        DataSet dsCadastral;
        DataTable dtCadastral;
        DataRow d_row;

        PKK_Property_Info pty = new PKK_Property_Info();
        Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
        settings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        settings.StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.Default;


        rosreestr_id = Transform_Cadastral(cadastral);
        Uri strUrl = new Uri(System.String.Format("http://pkk5.rosreestr.ru/api/features/1/{0}?date_format=%Y-%m-%d", rosreestr_id));

        //--------------------------------------------------------
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(strUrl);
        request.Method = System.Net.WebRequestMethods.Http.Get;
        request.Accept = "application/json";
        request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
        request.Credentials = System.Net.CredentialCache.DefaultCredentials;
        request.ReadWriteTimeout = 60000;
        try
        {
            System.Net.WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                str_text = reader.ReadToEnd();
            }
        }
        catch (System.Net.WebException ex)
        {
            dsCadastral = new DataSet();
            dtCadastral = dsCadastral.Tables.Add();
            dtCadastral.Columns.Add("error", typeof(String));
            d_row = dtCadastral.NewRow();
            d_row["error"] = ex.Message;
            dtCadastral.Rows.Add(d_row);
            return dtCadastral;
            throw;
        }
        //--------------------------------------------------------

        //        str_text = utf8.GetString(qqq)

        pty = Newtonsoft.Json.JsonConvert.DeserializeObject<PKK_Property_Info>(str_text, settings);


        dsCadastral = new DataSet();
        string xml_file_path = AppDomain.CurrentDomain.BaseDirectory + "XML\\online_data.xsd";
        //''dsCadastral.ReadXmlSchema(xml_file_path)
        //'        dtCadastral = dsCadastral.Tables("Property")
        //''dtCadastral = dsCadastral.Tables("rosreestr_info")
        dtCadastral = new Rosreestr_Info.XML.online_data.rosreestr_infoDataTable();
        d_row = dtCadastral.NewRow();
        d_row["cadastral"] = cadastral;

        if (pty.feature == null)
        {
            dsCadastral = new DataSet();
            dtCadastral = dsCadastral.Tables.Add();
            dtCadastral.Columns.Add("error", typeof(String));
            d_row = dtCadastral.NewRow();
            d_row["error"] = "Не найдено";
            dtCadastral.Rows.Add(d_row);
            return dtCadastral;
        }

        d_row["p_cadastral"] = pty.feature.attrs.cn;

        d_row["p_stoim"] = pty.feature.attrs.cad_cost;
        d_row["p_date_stoim"] = pty.feature.attrs.date_cost;
        d_row["p_area"] = pty.feature.attrs.area_value;
        if (pty.feature.attrs.util_by_doc != null)
        {
            d_row["p_utilByDoc"] = pty.feature.attrs.util_by_doc.Replace("&quot;", "\"\"");
        }
        else
        {
            d_row["p_utilByDoc"] = "";
        }
        if (pty.feature.attrs.util_code != null)
        {
            d_row["p_utilCode"] = pty.feature.attrs.util_code;
        }
        else
        {
            d_row["p_utilCode"] = "";
        }

        //'If Not (pty.parcelData.utilCodedesc Is Nothing) Then
        //'    d_row("p_utilDesc") = pty.parcelData.utilCodedesc.Replace("&quot;", """")
        //'Else
        //'    d_row("p_utilDesc") = ""
        //'End If

        d_row["p_status"] = "";
        d_row["p_status_str"] = "-";
        string status_text ="";
        if (pty.feature.attrs.statecd != null) {
            d_row["p_status"] = pty.feature.attrs.statecd;
            switch (pty.feature.attrs.statecd)
            {
                case "01":
                    status_text = "Ранее учтенный";
                    break;
                case "06":
                    status_text = "Учтенный";
                    break;
                case "07":
                    status_text = "Снят с учета";
                    break;
                default:
                    break;
            }
            d_row["p_status_str"] = status_text;
        }
        dtCadastral.Rows.Add(d_row);
        return dtCadastral;

    }
    public static string Transform_Cadastral(string cadastral)
    {
        string res = "";
        string[] ar_cad;
        string part = "";
        string sep = "";
        ar_cad = cadastral.Split(':');
        int n;
        for (int i = 0; i < ar_cad.Length ; i++)
        {
            if (int.TryParse(ar_cad[i], out n))
            {
//                part = ar_cad[i].TrimStart('0');
                part = n.ToString() ;
            }
            else
            {
                part = ar_cad[i];

            }
            if (i==0)
            {
                sep = "";
            }
            else
            {
                sep = ":";
            }
            res = res + sep + part.Trim(' ');

        }
        return res;
    }

}