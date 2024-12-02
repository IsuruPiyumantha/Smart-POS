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

namespace SmartPOS.Forms.SuppliersForms
{
    public partial class AddNewSupplier : Form
    {
        private static SuppliersControler SuppCont;
        public static SuppliersDetailsInfo SuppInfo;
        public static CommonFuntion CmnFun;

        public AddNewSupplier()
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
            SuppCont = new SuppliersControler();
            SelectSupplierCode();
            txtSupplierName.Focus();
        }

        private void SelectSupplierCode()
        {
            int itemCode = SuppCont.GetSupplierCode();
            txtSupplierCode.Text = (itemCode + 1).ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            txtSupplierName.Text = "";
            txtSupplierMobile.Text = "";
            txtSupplierEmail.Text = "";
            txtAmt.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSupp();
        }

        private void SaveSupp()
        {
            SuppInfo = new SuppliersDetailsInfo();
            SuppCont = new SuppliersControler();
            CmnFun = new CommonFuntion();


            if (string.IsNullOrEmpty(txtSupplierName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtSupplierName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtSupplierCode.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtSupplierCode.Text.ToString()) == false)
                {
                    {
                        SuppInfo.SuppCode = int.Parse(txtSupplierCode.Text.Trim().ToString());
                        SuppInfo.SuppName = txtSupplierName.Text.Trim().ToString();
                        SuppInfo.SuppMobile = txtSupplierMobile.Text.Trim().ToString();
                        SuppInfo.SuppEmail = txtSupplierEmail.Text.Trim().ToString();
                        if (txtAmt.Text != "")
                        {
                            SuppInfo.BalanceAmount = decimal.Parse(txtAmt.Text);
                        }

                        if (SuppCont.AddNewSupplier(SuppInfo))
                        {
                            MessageBox.Show("Successfull");
                            Clear();
                            SelectSupplierCode();
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

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierMobile.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtSupplierMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplierEmail.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSupplierName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtSupplierEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSupplierMobile.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSupp();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSupplierEmail.Focus();
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
