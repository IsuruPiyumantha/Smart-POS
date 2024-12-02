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
    public partial class EditSupplier : Form
    {
        private static SuppliersControler SuppCont;
        public static SuppliersDetailsInfo SuppInfo;
        public static CommonFuntion CmnFun;
        private string id;

        public EditSupplier()
        {
            InitializeComponent();
        }

        public EditSupplier(string id)
        {
            SuppCont = new SuppliersControler();
            // TODO: Complete member initialization
            this.id = id;
            InitializeComponent();
            SetColors();
            GetSupplierInfo(id);
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
            txtSupplierName.Focus();
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
        }

        private void GetSupplierInfo(string id)
        {
            SuppInfo = new SuppliersDetailsInfo();
            SuppCont = new SuppliersControler();

            SuppInfo = SuppCont.SelectSupplierInfo(id);

            if (SuppInfo != null)
            {
                txtSupplierCode.Enabled = false;
                txtSupplierCode.Text = SuppInfo.SuppCode.ToString();
                txtSupplierName.Text = SuppInfo.SuppName.Trim().ToString();
                txtSupplierMobile.Text = SuppInfo.SuppMobile.Trim().ToString();
                txtSupplierEmail.Text = SuppInfo.SuppEmail.Trim().ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateSupplier();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
                UpdateSupplier();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSupplierMobile.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void UpdateSupplier()
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

                        if (SuppCont.UpdateSupplier(SuppInfo))
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
