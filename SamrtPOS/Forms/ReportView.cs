using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SmartPOS.Forms
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


        public void LoadReport()
        {
            ReportDataSource rptReportDataSource;
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\NewReceipt.rdlc";
        }

        internal void LoadReport(DataTable dt)
        {
            ReportDataSource rptReportDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\NewReceipt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                rptReportDataSource = new ReportDataSource("Items", dt);
                this.reportViewer1.LocalReport.DataSources.Add(rptReportDataSource);
                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.ZoomMode = ZoomMode.Percent;
                this.reportViewer1.ZoomPercent = 30;
            }
            catch (Exception ex)
            {

            }
            
        }
    }
}
