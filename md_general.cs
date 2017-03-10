using System;
using System.Data;

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
        DataTable dt_res = new DataTable();
        return dt_res;
    }
}