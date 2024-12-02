using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.BarCodeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.ReportFrom
{
    public partial class StockReport : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static ReportControler RptContr;
        private static CommonFuntion commFunt;

        public StockReport()
        {
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            //styl.FormNormalButtonMain(btnExport);
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCheques();
        }

        private void SearchCheques()
        {
            RptContr = new ReportControler();
            commFunt = new CommonFuntion();
            gridDataDetails.DataSource = null;

            string fromDate = commFunt.convertDateTime(Convert.ToDateTime(FromDate.Value));
            string toDate = commFunt.convertDateTime(Convert.ToDateTime(ToDate.Value).AddDays(1));

            DataTable dt = RptContr.GetAllStock();

            if (dt.Rows.Count > 0)
            {
                gridDataDetails.AutoGenerateColumns = false;
                gridDataDetails.DataSource = dt;
            }

        }

        private void CashBook_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            FromDate.Value = startDate;
            ToDate.Value = endDate;

            SearchCheques();
        }

        private void FromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridDataDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
