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

namespace SmartPOS.Forms
{
    public partial class CrystalReportViewPage : Form
    {
        private KOTbill kotBill;
        private TableBill tableBill;
        private BarCodeForms.BarCode3 Rpt;

        public CrystalReportViewPage()
        {
            InitializeComponent();
        }

        public CrystalReportViewPage(KOTbill kotBill)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.kotBill = kotBill;
        }

        public CrystalReportViewPage(TableBill tableBill)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.tableBill = tableBill;
        }

        public CrystalReportViewPage(BarCodeForms.BarCode3 Rpt)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.Rpt = Rpt;
        }

        private void CrystalReportViewPage_Load(object sender, EventArgs e)
        {
            if (kotBill != null)
                crystalReportViewer1.ReportSource = this.kotBill;
            else if (tableBill != null)
                crystalReportViewer1.ReportSource = this.tableBill;
            else if (Rpt != null)
                crystalReportViewer1.ReportSource = this.Rpt;
        }
    }
}
