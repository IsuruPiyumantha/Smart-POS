using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.SettingsForms.PrintigSetting;
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
using System.Management;
using System.Drawing.Printing;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class PrinterSettings : Form
    {
        private PrintDocument prtdoc;
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private DataTable dt1;

        public PrinterSettings()
        {
            InitializeComponent();
            SetColors();
            prtdoc = new PrintDocument();
            Getprinters();
            SetPrinterName();
            SetPaperSize();
        }

        private void Getprinters()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection("Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=smart_pos_database;CharSet=utf8;");
            string sql = string.Empty;
            dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT * FROM tbl_pos_ref_printer_settings tprps;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
        }

        private void SetPrinterName()
        {
            if (dt1.Rows.Count > 0)
            {
                foreach (DataRow r in dt1.Rows)
                {
                    string setPrinter = r["PrinterName"].ToString();
                    if (r["ObjectName"].ToString() == "POS")
                    {
                        string strDefaultPrinter = this.prtdoc.PrinterSettings.PrinterName;
                        foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                        {
                            combPrinterNamePOS.Items.Add(strPrinter);
                            if (strPrinter == setPrinter)
                            {
                                combPrinterNamePOS.SelectedIndex = combPrinterNamePOS.Items.IndexOf(setPrinter);
                            }
                        }
                    }
                    else if (r["ObjectName"].ToString() == "KOT")
                    {
                        string strDefaultPrinter = this.prtdoc.PrinterSettings.PrinterName;
                        foreach (String strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                        {
                            combPrinterNameKOT.Items.Add(strPrinter);
                            if (strPrinter == setPrinter)
                            {
                                combPrinterNameKOT.SelectedIndex = combPrinterNameKOT.Items.IndexOf(setPrinter);
                            }
                        }
                    }
                }
            }


            
        }

        private void SetPaperSize()
        {
            if (dt1.Rows.Count > 0)
            {
                combPaperSizePOS.Items.Clear();
                combPaperSizeKOT.Items.Clear();
                foreach (DataRow r in dt1.Rows)
                {
                    string setPaperSize = r["PaperSize"].ToString();
                    if (r["ObjectName"].ToString() == "POS")
                    {
                        combPaperSizePOS.DisplayMember = "PaperName";
                        this.prtdoc.PrinterSettings.PrinterName = combPrinterNamePOS.Text;
                        int a = 0;
                        foreach (PaperSize item in this.prtdoc.PrinterSettings.PaperSizes)
                        {
                            combPaperSizePOS.Items.Add(item);
                            if (item.ToString() == setPaperSize)
                            {
                                combPaperSizePOS.SelectedIndex = a;
                            }
                            a++;
                        }
                    }
                    else if (r["ObjectName"].ToString() == "KOT")
                    {
                        combPaperSizeKOT.DisplayMember = "PaperName";
                        this.prtdoc.PrinterSettings.PrinterName = combPrinterNameKOT.Text;
                        int b = 0;
                        foreach (PaperSize item in this.prtdoc.PrinterSettings.PaperSizes)
                        {
                            combPaperSizeKOT.Items.Add(item);
                            if (item.ToString() == setPaperSize)
                            {
                                combPaperSizeKOT.SelectedIndex = b;
                            }
                            b++;
                        }
                    }
                }
            }
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave1);
            styl.FormNormalButtonMain(btnClear1);
            styl.FormNormalButtonMain(btnSave2);
            styl.FormNormalButtonMain(btnClear2);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (UpdatePrinter("POS"))
            {
                MessageBox.Show("Successfull!");
            }
        }

        private bool UpdatePrinter(string ObjectName)
        {
            bool IsTrue = false;
            string printname = string.Empty;
            string papersize = string.Empty;

            if (ObjectName == "POS")
            {
                printname = combPrinterNamePOS.SelectedItem.ToString();
                papersize = combPaperSizePOS.SelectedItem.ToString();
            }
            else if (ObjectName == "KOT")
            {
                printname = combPrinterNameKOT.SelectedItem.ToString();
                papersize = combPaperSizeKOT.SelectedItem.ToString();
            }

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection("Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=smart_pos_database;CharSet=utf8;");
            string sql = string.Empty;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "UPDATE tbl_pos_ref_printer_settings tprps SET tprps.PrinterName = '" + printname + "', tprps.PaperSize = '" + papersize + "' WHERE tprps.ObjectName = '" + ObjectName + "';";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsTrue;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (UpdatePrinter("KOT"))
            {
                MessageBox.Show("Successfull!");
            }
        }

        private void combPrinterNameKOT_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPaperSize();
        }

        private void combPrinterNamePOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetPaperSize();
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSave1_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void btnClear1_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void combPrinterNamePOS_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void combPaperSizePOS_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void btnSave2_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void btnClear2_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void combPrinterNameKOT_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }
    }
}
