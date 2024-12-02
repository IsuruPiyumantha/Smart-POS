using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.CustomerForms
{
    public partial class EditCustomer : Form
    {
        private static CustomerControler CusCont;
        public static CustomerDetailsInfo CusInfo;
        public static CommonFuntion CmnFun;
        private string id;

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(string id)
        {
            CusCont = new CustomerControler();
            this.id = id;
            InitializeComponent();
            SetColors();
            GetCustomerInfo(id);
        }

        private void GetCustomerInfo(string id)
        {
            CusInfo = new CustomerDetailsInfo();
            CusCont = new CustomerControler();

            CusInfo = CusCont.SelectCustomerInfo(id);

            if (CusInfo != null)
            {
                txtCustomerCode.Enabled = false;
                txtCustomerCode.Text = CusInfo.CusCode.ToString();
                txtCustomerName.Text = CusInfo.CusName.Trim().ToString();
                txtCustomerAddress.Text = CusInfo.CusAddress.Trim().ToString();
                txtCustomerMobile.Text = CusInfo.CusMobile.Trim().ToString();
                txtCustomerEmail.Text = CusInfo.CusEmail.Trim().ToString();
            }
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void AddNewSupplier_Load(object sender, EventArgs e)
        {

        }

        private void Clear()
        {
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerMobile.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerEmail.Text = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerAddress.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtCustomerAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerMobile.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtCustomerMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerEmail.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtCustomerEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCustomer();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void UpdateCustomer()
        {
            CusInfo = new CustomerDetailsInfo();
            CusCont = new CustomerControler();
            CmnFun = new CommonFuntion();


            if (string.IsNullOrEmpty(txtCustomerName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtCustomerName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtCustomerCode.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtCustomerCode.Text.ToString()) == false)
                {
                    {
                        CusInfo.CusCode = int.Parse(txtCustomerCode.Text.Trim().ToString());
                        CusInfo.CusName = txtCustomerName.Text.Trim().ToString();
                        CusInfo.CusAddress = txtCustomerAddress.Text.Trim().ToString();
                        CusInfo.CusMobile = txtCustomerMobile.Text.Trim().ToString();
                        CusInfo.CusEmail = txtCustomerEmail.Text.Trim().ToString();

                        if (CusCont.UpdateCustomer(CusInfo))
                        {
                            MessageBox.Show("Successfull Update");
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Required Supplier Code");
                }
            }
            else
            {
                MessageBox.Show("Required Supplier Name");
            }
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
