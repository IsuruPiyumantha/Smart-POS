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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS
{
    public partial class DashBoard : Form
    {
        private static CommonFuntion comFuntion;
        public DashBoard()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
