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
    public partial class SummaryReport : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion commFunt;

        public SummaryReport()
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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCashBook();
        }

        private void SearchCashBook()
        {

        }

        private void CashBook_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, now.Day);
            var endDate = startDate.AddDays(1);

            FromDate.Value = startDate;
            ToDate.Value = endDate;

            SearchCashBook();
        }
    }
}
