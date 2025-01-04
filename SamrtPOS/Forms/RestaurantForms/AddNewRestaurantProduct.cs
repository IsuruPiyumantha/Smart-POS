using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.SuppliersForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.RestaurantForms
{
    public partial class AddNewRestaurantProduct : Form
    {
        public static ProductControler prodCont;
        public static CommonFuntion CmnFun;

        public AddNewRestaurantProduct()
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

        private void AddNewProduct_Load(object sender, EventArgs e)
        {
            prodCont = new ProductControler();
            SelectItemCode();
            selectAllUnit();
            SelectAllCategory();
            ComboSupplier();
            
        }

        private void ComboSupplier()
        {
            DataTable dt = prodCont.GetAllSupplier();
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            txtSupplier.DataSource = dt;
            txtSupplier.DisplayMember = "SuppliersName";
            txtSupplier.ValueMember = "ID";
            txtSupplier.SelectedIndex = 0;
        }

        private void SelectItemCode()
        {
            int itemCode = prodCont.GetItemCode();
            txtItemCode.Text = (itemCode + 1).ToString();
        }

        private void SelectAllCategory()
        {
            DataTable dt = prodCont.GetAllCategory();
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            combCategory.DataSource = dt;
            combCategory.DisplayMember = "CategoryName";
            combCategory.ValueMember = "ID";
            combCategory.SelectedIndex = 0;
        }

        private void selectAllUnit()
        {
            DataTable dt = prodCont.GetAllUnit();
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            combUnit.DataSource = dt;
            combUnit.DisplayMember = "UnitName";
            combUnit.ValueMember = "ID";
            combUnit.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtItemName.Text = "";
            txtBarCode.Text = "";
            txtBuyingCost.Text = "";
            txtLabledPrice.Text = "";
            txtSupplier.SelectedIndex = 0;
            combCategory.SelectedIndex = 0;
            combUnit.SelectedIndex = 0;
            chkBoxKOT.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();            
        }

        private void Save()
        {
            RestaurantProductInfo prodInfo = new RestaurantProductInfo();
            prodCont = new ProductControler();
            CmnFun = new CommonFuntion();


            if (string.IsNullOrEmpty(txtItemName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtItemName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtLabledPrice.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtLabledPrice.Text.ToString()) == false)
                {
                    if (combUnit.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select the Unit");
                    }
                    if (combCategory.SelectedIndex == 0)
                    {
                        MessageBox.Show("Please select the Category");
                    }
                    else
                    {
                        prodInfo.ItemCode = txtItemCode.Text.Trim().ToString();
                        prodInfo.ItemName = txtItemName.Text.Trim().ToString();
                        prodInfo.Unit = int.Parse(combUnit.SelectedValue.ToString());
                        prodInfo.LabledPrice = decimal.Parse(txtLabledPrice.Text.ToString());

                        if (txtBuyingCost.Text != "")
                        {
                            prodInfo.BuyingCost = decimal.Parse(txtBuyingCost.Text.ToString());
                        }
                        prodInfo.Category = int.Parse(combCategory.SelectedValue.ToString());
                        if (txtSupplier.SelectedIndex > 0)
                        {
                            prodInfo.Supplier = int.Parse(txtSupplier.SelectedValue.ToString());
                        }
                        prodInfo.SupplierName = txtSupplier.Text.ToString();
                        prodInfo.BarCode = txtBarCode.Text.ToString();
                        if (chkBoxKOT.Checked)
                        {
                            prodInfo.KOT = true;
                        }
                        else
                        {
                            prodInfo.KOT = false;
                        }

                        if (prodCont.AddNewRestaurantProduct(prodInfo))
                        {
                            MessageBox.Show("Successfull");
                            Clear();
                            SelectItemCode();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Required Labled Price");
                }
            }
            else
            {
                MessageBox.Show("Required Item Name");
            }
        }

        private void txtLabledPrice_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (CmnFun.IsValidDecimalNo(txtLabledPrice.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Labled Price");
            }
        }

        private void txtBuyingCost_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (CmnFun.IsValidDecimalNo(txtBuyingCost.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Buying Price");
            }
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            AddNewCategory catList = new AddNewCategory();
            catList.ShowDialog();
            SelectAllCategory();
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                combUnit.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void combUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLabledPrice.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (combUnit.SelectedIndex < 1)
                {
                    txtItemName.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtLabledPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuyingCost.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                combUnit.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtBuyingCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                combCategory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtLabledPrice.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void combCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSupplier.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (combCategory.SelectedIndex < 1)
                {
                    txtBuyingCost.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                btnAddNewCategory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtSupplier_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chkBoxKOT.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (txtSupplier.SelectedIndex < 1)
                {
                    combCategory.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                button1.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void chkBoxKOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSupplier.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
                txtItemName.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                chkBoxKOT.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewSupplier newSupp = new AddNewSupplier();
            newSupp.ShowDialog();
            ComboSupplier();
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
