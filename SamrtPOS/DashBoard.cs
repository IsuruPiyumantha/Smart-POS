using SmartPOS.Controler;
using SmartPOS.Forms;
using SmartPOS.Forms.AccountForms;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.ReportFrom;
using SmartPOS.Forms.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS
{
    public partial class DashBoard : Form
    {
        private static CommonFuntion comFuntion;
        private static string BackupTime = string.Empty;
        private static string BackupPath = string.Empty;
        public DashBoard()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            GetBackupInfo();
        }

        private void GetBackupInfo()
        {
            BackupInfo backupdata = new BackupInfo();
            backupdata = comFuntion.GetBacupData();
            BackupTime = backupdata.BackupTime;
            BackupPath = backupdata.BackupPath;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromName(Program.col);
            panel1.BackColor = Color.FromName(Program.col2);
            label1.ForeColor = Color.FromName(Program.hText);
            label2.ForeColor = Color.FromName(Program.hText);
            label3.ForeColor = Color.FromName(Program.hText);
            label4.ForeColor = Color.FromName(Program.hText);
            label5.ForeColor = Color.FromName(Program.hText);
            label6.ForeColor = Color.FromName(Program.hText);
            label7.ForeColor = Color.FromName(Program.hText);
            label8.ForeColor = Color.FromName(Program.hText);
            label9.ForeColor = Color.FromName(Program.hText);
            label10.ForeColor = Color.FromName(Program.hText);
            label12.ForeColor = Color.FromName(Program.hText);
            label13.ForeColor = Color.FromName(Program.hText);
            btnSaleForm.Focus();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime nowDateTime = DateTime.Now;
            lblTime.Text = nowDateTime.ToLongTimeString();
            string NTime = nowDateTime.ToLongTimeString();
            if (NTime == BackupTime)
            {
                if(Program.ServerName == "localhost")
                {
                    PerformBackup();
                }
            }
        }

        static void PerformBackup()
        {
            string server = "localhost";
            string user = "root";
            string password = "Msdh@7#8";
            string database = "smart_pos_database";
            string backupPath = BackupPath;
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupFile = Path.Combine(backupPath, $"{database}_backup_{timestamp}.sql");

            // Ensure the backup directory exists
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            // Construct the mysqldump command
            string dumpCommand = $"mysqldump -h {server} -u {user} -p{password} {database} > \"{backupFile}\"";

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + dumpCommand)
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = Process.Start(processInfo);
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    Console.WriteLine($"Backup successful: {backupFile}");
                }
                else
                {
                    Console.WriteLine($"Backup failed. Error: {process.StandardError.ReadToEnd()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while performing backup: {ex.Message}");
            }
        }

        private void btnSaleForm_Click(object sender, EventArgs e)
        {
            if (Program.companyProfile.CatID == 1)
            {
                SalesForm saleForm = new SalesForm();
                saleForm.Show();
            }

            if (Program.companyProfile.CatID == 2)
            {
                TablesManeg tblMng = new TablesManeg();
                tblMng.Show();
            }
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (Program.companyProfile.CatID == 1)
            {
                ProductDetails prodDetails = new ProductDetails();
                prodDetails.Show();
            }

            if (Program.companyProfile.CatID == 2)
            {
                RestaurantProductDetails restProdDet = new RestaurantProductDetails();
                restProdDet.Show();
            }
        }

        private void btnCustForm_Click(object sender, EventArgs e)
        {
            CustomerDetails cusDetails = new CustomerDetails();
            cusDetails.Show();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 7))
            {
                InvoiceDetails invDetails = new InvoiceDetails();
                invDetails.Show();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierDetails SupDetails = new SupplierDetails();
            SupDetails.Show();
        }

        private void btnGRN_Click(object sender, EventArgs e)
        {
            GRNDetails grnDetails = new GRNDetails();
            grnDetails.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Returns retn = new Returns();
            retn.Show();
        }

        private void btnSearchStock_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 4))
            {
                Accounts account = new Accounts();
                account.Show();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void btn_catg_Click(object sender, EventArgs e)
        {
            CategoryList catList = new CategoryList();
            catList.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserDetailsList userList = new UserDetailsList();
            userList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }

        private void btnCashBook_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 5))
            {
                Reports report = new Reports();
                report.Show();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                ShortCutKey(sender, e);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShortCutKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (Program.companyProfile.CatID == 1)
                {
                    SalesForm saleForm = new SalesForm();
                    saleForm.Show();
                }

                if (Program.companyProfile.CatID == 2)
                {
                    TablesManeg tblMng = new TablesManeg();
                    tblMng.Show();
                }
            }
            if (e.KeyCode == Keys.F2)
            {
                if (comFuntion.CheckPermission(Program.userDetails.JobRole, 7))
                {
                    InvoiceDetails invDetails = new InvoiceDetails();
                    invDetails.Show();
                }
                else
                {
                    MessageBox.Show("You can't access.");
                }
            }
            if (e.KeyCode == Keys.F3)
            {
                CustomerDetails cusDetails = new CustomerDetails();
                cusDetails.Show();
            }
            if (e.KeyCode == Keys.F4)
            {
                SupplierDetails SupDetails = new SupplierDetails();
                SupDetails.Show();
            }
            if (e.KeyCode == Keys.F5)
            {
                CategoryList catList = new CategoryList();
                catList.Show();
            }
            if (e.KeyCode == Keys.F6)
            {
                if (Program.companyProfile.CatID == 1)
                {
                    ProductDetails prodDetails = new ProductDetails();
                    prodDetails.Show();
                }

                if (Program.companyProfile.CatID == 2)
                {
                    RestaurantProductDetails restProdDet = new RestaurantProductDetails();
                    restProdDet.Show();
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                Returns retn = new Returns();
                retn.Show();
            }
            if (e.KeyCode == Keys.F8)
            {
                if (comFuntion.CheckPermission(Program.userDetails.JobRole, 4))
                {
                    Accounts account = new Accounts();
                    account.Show();
                }
                else
                {
                    MessageBox.Show("You can't access.");
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                UserDetailsList userList = new UserDetailsList();
                userList.Show();
            }
            if (e.KeyCode == Keys.F10)
            {
                if (comFuntion.CheckPermission(Program.userDetails.JobRole, 5))
                {
                    Reports report = new Reports();
                    report.Show();
                }
                else
                {
                    MessageBox.Show("You can't access.");
                }
            }
            if (e.KeyCode == Keys.F11)
            {
                GRNDetails grnDetails = new GRNDetails();
                grnDetails.Show();
            }
            if (e.KeyCode == Keys.F12)
            {
                Setting setting = new Setting();
                setting.Show();
            }
        }
    }
}
