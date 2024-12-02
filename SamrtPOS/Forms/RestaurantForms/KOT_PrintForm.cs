using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.RestaurantForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.RestaurantForms
{
    public partial class KOT_PrintForm : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private DataTable dt;
        private DataTable kotItem;
        private string InvoiceNo = string.Empty;
        private string TableName = string.Empty;
        private static ProductControler prodCont;

        public KOT_PrintForm()
        {
            InitializeComponent();
            this.SetColors();
        }

        public KOT_PrintForm(DataTable dt,string InvoiceNo,string TableName)
        {
            InitializeComponent();
            this.SetColors();
            this.dt = dt;
            this.InvoiceNo = InvoiceNo;
            this.TableName = TableName;
            createKOT_Table();
        }

        private void createKOT_Table()
        {
            kotItem = new DataTable();
            kotItem.Columns.Add("ID", typeof(string));
            kotItem.Columns.Add("item_name", typeof(string));
            kotItem.Columns.Add("quantity", typeof(string));
            kotItem.Columns.Add("KOT", typeof(int));

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int kot = int.Parse(r["KOT"].ToString());
                    kotItem.Rows.Add(r["ID"].ToString(), r["item_name"].ToString(), r["quantity"].ToString(), Convert.ToBoolean(kot));
                }
            }

            if (kotItem.Rows.Count > 0)
            {
                gridDataDetails.AutoGenerateColumns = false;
                gridDataDetails.DataSource = kotItem;
            }


        }

        private void SetColors()
        {
            GridColourClass styl = new GridColourClass();
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor= Color.FromName(Program.col2);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            print(true, false);
        }
        private void btnViwe_Click(object sender, EventArgs e)
        {
            print(false, true);
        }

        private void print(bool isPrint, bool isView)
        {
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)gridDataDetails.DataSource;
            DataRow[] rows = dt1.Select("KOT = '0'");
            foreach (DataRow row in rows)
                dt1.Rows.Remove(row);

            CrystalReportViewer viever = new CrystalReportViewer();
            KOTbill kotBill = new KOTbill();
            kotBill.SetDataSource(dt1);
            kotBill.SetParameterValue("InvoiceNumber", this.InvoiceNo);
            kotBill.SetParameterValue("TableName", this.TableName);

            viever.ReportSource = kotBill;
            if (isView)
            {
                CrystalReportViewPage view = new CrystalReportViewPage(kotBill);
                view.ShowDialog();
            }
            else
            {
                if (isPrint)
                    viever.PrintReport();
                else
                    viever.ExportReport();
            }

            prodCont = new ProductControler();
            prodCont.InsertKOTtable(dt1, this.InvoiceNo, this.TableName);

        }

        
    }
}
