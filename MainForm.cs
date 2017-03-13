using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static md_general;

namespace Rosreestr_Info
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public System.Data.DataTable dtCadList;
        public string cur_cadastral;
        public int cur_index;

        private void mnuImportList_Click(object sender, EventArgs e)
        {
            dtCadList = GetData();
            if ( dtCadList != null)
            {
                FillListView();
            }
        }
        private System.Data.DataTable GetData()
        {
            string sConnection;
            string conn_templ = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties=\"text;HDR=yes;FMT=delimited\";";
            string cur_path;
            DialogResult rc;
            OpenFileDialog qq = new OpenFileDialog();

            rc = qq.ShowDialog();

            if ( rc == DialogResult.Cancel) {
                MessageBox.Show("Импорт отменен");
                stLbl.Text = "Импорт отменен";
                return null;
            }

            UpdateStatus("Загрузка списка из файла...", Cursors.WaitCursor);
            cur_path = qq.FileName;
            cur_path = System.IO.Path.GetDirectoryName(cur_path);

            sConnection = String.Format(conn_templ, cur_path);
            string sSQL = "select cadastral, '-' as checked, '-' as r_checked from " + System.IO.Path.GetFileName(qq.FileName);
            XML.online_data.rosreestr_infoDataTable dt = new XML.online_data.rosreestr_infoDataTable();
            //Dim dt As New online_data.rosreestr_infoDataTable

            OleDbDataAdapter da = new OleDbDataAdapter(sSQL, sConnection);

            try
            {
                da.Fill(dt);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());

                throw;
            }
            UpdateStatus("Список загружен...", Cursors.Arrow);

            return dt;
        }
        private void UpdateStatus(string Message, Cursor set_cursor)
        {
            Cursor = set_cursor;
            stLbl.Text = Message;
            System.Windows.Forms.Application.DoEvents();
        }
        private void FillListView()
        {
            this.lvCadastral.Items.Clear();
            foreach (DataRow row in dtCadList.Rows)
            {
                ListViewItem lvi = new ListViewItem(row["cadastral"].ToString());
                lvi.SubItems.Add(row["checked"].ToString());
                lvi.SubItems.Add(row["r_checked"].ToString());
                this.lvCadastral.Items.Add(lvi);
            }
            this.lvCadastral.Items[0].Focused = true;
            this.lvCadastral.Items[0].Selected = true;

        }

        private void mnuExitApp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuSaveData_Click(object sender, EventArgs e)
        {
            SaveDataFile();
        }
        private void SaveDataFile()
        {
            UpdateStatus("Сохранение файла...", Cursors.WaitCursor);
            //        'dtCadList.WriteXmlSchema(AppDomain.CurrentDomain.BaseDirectory & "result.xml")
            if (dtCadList != null)
            {
                dtCadList.WriteXml(AppDomain.CurrentDomain.BaseDirectory + "result.xml");
                UpdateStatus("Завершено...", Cursors.Arrow);
            }
            else { UpdateStatus("Ошибка записи в файл", Cursors.Arrow); }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDataFile();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenDataFile();
        }
        private void OpenDataFile()
        {
            UpdateStatus("Загрузка файла...", Cursors.WaitCursor);
            dtCadList = new XML.online_data.rosreestr_infoDataTable();
            try
            {
                dtCadList.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "result.xml");
                UpdateStatus("Готово", Cursors.Arrow);

            }
            catch (Exception ex)
            {
                UpdateStatus(ex.Message, Cursors.Arrow);
                return;
            }
            if (dtCadList != null)
            {
                FillListView();
            }
                
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            Microsoft.Office.Interop.Excel.Application xl_app;
            Workbook xl_wbk;
            Worksheet xl;
            int i;

            UpdateStatus("Экспорт в Excel...", Cursors.WaitCursor);
            if (dtCadList != null)
            {
                xl_app = new Microsoft.Office.Interop.Excel.Application();
                xl_wbk = xl_app.Workbooks.Add();
                xl = xl_wbk.ActiveSheet;
                i = 1;
                xl.Cells[i, 1].value = "КН";
                xl.Cells[i, 2].value = "КН (РР)";
                xl.Cells[i, 3].value = "Стоимость (РР)";
                xl.Cells[i, 4].value = "Дата стоимости (РР)";
                xl.Cells[i, 5].value = "Площадь (РР)";
                xl.Cells[i, 6].value = "Статус (РР)";
                xl.Cells[i, 7].value = "Назначение (РР)";
                xl.Cells[i, 8].value = "Стоимость (R/3)";
                xl.Cells[i, 9].value = "Дата стоимости (R/3)";
                xl.Cells[i, 10].value = "Площадь (R/3)";
                Range rr = xl.Rows[i];
                rr.Font.Bold = true;
                i = 2;
                foreach (DataRow row in dtCadList.Rows)
                {
                    xl.Cells[i, 1].value = row["cadastral"];
                    xl.Cells[i, 2].value = row["p_cadastral"];
                    xl.Cells[i, 3].value = row["p_stoim"];
                    xl.Cells[i, 4].value = row["p_date_stoim"];
                    xl.Cells[i, 5].value = row["p_area"];
                    xl.Cells[i, 6].value = row["p_status_str"];
                    xl.Cells[i, 7].value = row["p_utilByDoc"];
                    if (dtCadList.Columns["r_stoim"] != null)
                    {
                        xl.Cells[i, 8].value = row["r_stoim"];
                    }
                    if (dtCadList.Columns["r_date_stoim"] != null)
                    {
                        xl.Cells[i, 9].value = row["r_date_stoim"];
                    }
                    if (dtCadList.Columns["r_area"] != null)
                    {
                        xl.Cells[i, 10].value = row["r_area"];
                    }
                    UpdateStatus("Экспорт в Excel... " + row["cadastral"], Cursors.WaitCursor);
                i++;

                }
            //    'xl_wbk.SaveAs(AppDomain.CurrentDomain.BaseDirectory & "result.xlsx")
                xl_app.Visible = true;
            //    'xl_app.Quit()

            }
            UpdateStatus("Экспорт в файл Excel завершен", Cursors.Arrow);
        }

        private void lvCadastral_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            cur_cadastral = lv.FocusedItem.Text;
            cur_index = lv.FocusedItem.Index;
            XML.online_data.rosreestr_infoDataTable dt = new XML.online_data.rosreestr_infoDataTable();
            DataRow dr = dt.NewRow();
            dr = dtCadList.Rows[cur_index];
            dt.ImportRow(dr);
            FillDetailsListView(dt);
        }

        private void mnuGetInfoByCadastral_Click(object sender, EventArgs e)
        {
            UpdateStatus(String.Format("Запрос информации по {0}", cur_cadastral), Cursors.AppStarting);
            GetInfoByCadastral(cur_cadastral);
            XML.online_data.rosreestr_infoDataTable dt = new XML.online_data.rosreestr_infoDataTable();
            DataRow dr = dt.NewRow();
            dr = dtCadList.Rows[cur_index];
            dt.ImportRow(dr);
            FillDetailsListView(dt);
            UpdateStatus("Готово", Cursors.Arrow);
        }

        private void GetInfoByCadastral(string cadastral)
        {
            System.Data.DataTable dtInfo = GetCadastralInfoFromPKK_REST(cadastral);
            //Проверяем на ошибку
            if (dtInfo.Columns[0].ColumnName != "error")
            {

                //tbx_p_cad_stoim.Text = Format(dtInfo(0)("p_stoim"), "C2")
                //tbx_p_date_stoim.Text = dtInfo(0)("p_date_stoim")
                //tbx_p_area.Text = Format(dtInfo(0)("p_area"), "N2")
                //tbx_p_utilByDoc.Text = dtInfo(0)("p_utilByDoc")
                //'TODO - закинуть в таблицу
                //Нужен индекс в таблице, соответствующий индексу в листвью
                dtCadList.Rows[cur_index]["p_cadastral"] = dtInfo.Rows[0]["p_cadastral"];
                dtCadList.Rows[cur_index]["p_stoim"] = dtInfo.Rows[0]["p_stoim"];
                dtCadList.Rows[cur_index]["p_date_stoim"] = dtInfo.Rows[0]["p_date_stoim"];
                dtCadList.Rows[cur_index]["p_area"] = dtInfo.Rows[0]["p_area"];
                dtCadList.Rows[cur_index]["p_utilByDoc"] = dtInfo.Rows[0]["p_utilByDoc"];
                dtCadList.Rows[cur_index]["p_status"] = dtInfo.Rows[0]["p_status"];
                dtCadList.Rows[cur_index]["p_status_str"] = dtInfo.Rows[0]["p_status_str"];
                dtCadList.Rows[cur_index]["checked"] = "+";

            }
            else
            {
                //tbx_p_cad_stoim.Clear()
                //tbx_p_date_stoim.Clear()
                //tbx_p_area.Clear()
                //tbx_p_utilByDoc.Text = "!Ошибка загрузки!"

            }

        }
        private void FillDetailsListView(System.Data.DataTable dt)
        {
            System.Globalization.NumberFormatInfo nfi = new System.Globalization.CultureInfo("ru-RU",true).NumberFormat;
            nfi.NumberGroupSeparator = " ";
            lvDetails.Items.Clear();
            foreach (DataColumn col in dt.Columns)
            {
                ListViewItem lvi = new ListViewItem(col.Caption);
                if (col.DataType == typeof(System.DateTime)) {
                    DataRow row = dt.Rows[0];
                    DateTime d_val = new DateTime();
                    if (row[col.ColumnName].ToString() != "")
                    {
                        d_val = (DateTime)row[col.ColumnName];
                        lvi.SubItems.Add(d_val.ToString("dd.MM.yyyy"));
                    }
                } else if (col.DataType == typeof(System.Decimal)) {
                    Decimal d_val = new Decimal();
                    if (dt.Rows[0][col.ColumnName].ToString() != "")
                    {
                       d_val = (Decimal)dt.Rows[0][col.ColumnName];
                        lvi.SubItems.Add(d_val.ToString("N2", nfi));
                    }
                }
                else { lvi.SubItems.Add(dt.Rows[0][col.ColumnName].ToString()); }
                
                this.lvDetails.Items.Add(lvi);
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            pb1.Minimum = 0;
            pb1.Maximum = dtCadList.Rows.Count - 1;
            for (cur_index = 0; cur_index < dtCadList.Rows.Count; cur_index++)
            {
                cur_cadastral = dtCadList.Rows[cur_index]["cadastral"].ToString();
                GetInfoByCadastral(cur_cadastral);
                pb1.Value = cur_index;
                UpdateStatus(String.Format("Запрос информации по {0} ({1} из {2})", cur_cadastral, cur_index+1, pb1.Maximum + 1), Cursors.AppStarting);
                TimeSpan interval = new TimeSpan(0,0,1);
                System.Threading.Thread.Sleep(interval);
            }
            UpdateStatus("Готово", Cursors.Arrow);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            OpenDataFile();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult rc = MessageBox.Show("Сохранить данные?", "Внимание", MessageBoxButtons.YesNo);
            if (rc == DialogResult.Yes)
            {
                SaveDataFile();
            }
        }
    }
}
