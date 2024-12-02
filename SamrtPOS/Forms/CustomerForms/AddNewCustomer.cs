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
    public partial class AddNewCustomer : Form
    {
        private static CustomerControler CusCont;
        public static CustomerDetailsInfo CusInfo;
        public static CommonFuntion CmnFun;
        private int p;

        public AddNewCustomer()
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
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void AddNewSupplier_Load(object sender, EventArgs e)
        {
            CusCont = new CustomerControler();
            SelectCustomerCode();
        }

        private void SelectCustomerCode()
        {
            int itemCode = CusCont.GetCustomerCode();
            txtCustomerCode.Text = (itemCode + 1).ToString();
        }

        private void Clear()
        {
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerMobile.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerEmail.Text = "";
            txtAmt.Text = "";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
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
                        if (txtAmt.Text.ToString() != "")
                        {
                            CusInfo.Amount = decimal.Parse(txtAmt.Text.ToString());
                        }

                        if (CusCont.AddNewCustomer(CusInfo))
                        {
                            MessageBox.Show("Successfull");
                            Clear();
                            SelectCustomerCode();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (txtAmt.Text != "")
            {
                if (CmnFun.IsValidDecimalNo(txtAmt.Text.ToString()) == false)
                {
                    MessageBox.Show("Invalid Amount.");
                }
            }
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
                txtAmt.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Save();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
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
