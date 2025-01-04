using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.RestaurantForms;
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
using System.Globalization;

namespace SmartPOS.Forms.SupperMarketForms
{
    public partial class AddNewSupperMarketProduct : Form
    {
        public static SupperMarketProductControler prodCont;
        public static SupperMarketProductInfo prodInfo;
        public static CommonFuntion CmnFun;

        public AddNewSupperMarketProduct()
        {
            CmnFun = new CommonFuntion();
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
            prodCont = new SupperMarketProductControler();
            SelectItemCode();
            selectAllUnit();
            SelectAllCategory();
            ComboSupplier();

            if (Program.companyProfile.IsEnglish)
            {
                txtItemNameSinhala.Enabled = false;
                txtItemName.Focus();
            }
            else
            {
                txtItemName.Focus();
            }
            
        }

        private void SelectItemCode()
        {
            int itemCode = prodCont.GetItemCode();
            txtItemCode.Text = (itemCode + 1).ToString();
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
            txtItemNameSinhala.Text = "";
            txtBarCode.Text = "";
            txtBarCode2.Text = "";
            txtBarCode3.Text = "";
            txtBuyingCost.Text = "";
            txtLabledPrice.Text = "";
            txtSpecialPrice.Text = "";
            txtWholePrice.Text = "";
            txtitemBuy.Text = "";
            txtItemGet.Text = "";
            txtDateExp.Text = "";
            chkExpPrint.Checked = false;
            txtSupplier.SelectedIndex = 0;
            combCategory.SelectedIndex = 0;
            combUnit.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();            
        }

        private void Save()
        {
            prodInfo = new SupperMarketProductInfo();
            prodCont = new SupperMarketProductControler();
            CmnFun = new CommonFuntion();

            if (Validation())
            {
                prodInfo.ItemCode = txtItemCode.Text.Trim().ToString();
                prodInfo.ItemName = txtItemName.Text.Trim().ToString();
                prodInfo.ItemNameSinhala = txtItemNameSinhala.Text.Trim().ToString();
                prodInfo.Unit = int.Parse(combUnit.SelectedValue.ToString());
                prodInfo.LabledPrice = decimal.Parse(txtLabledPrice.Text.ToString());
                if (txtSpecialPrice.Text != "")
                {
                    prodInfo.SpeciaPrice = decimal.Parse(txtSpecialPrice.Text.ToString());
                }
                else
                {
                    prodInfo.SpeciaPrice = prodInfo.LabledPrice;
                }
                if (txtWholePrice.Text != "")
                {
                    prodInfo.WholesalePrice = decimal.Parse(txtWholePrice.Text.ToString());
                }
                if (txtBuyingCost.Text != "")
                {
                    prodInfo.BuyingCost = decimal.Parse(txtBuyingCost.Text.ToString());
                }
                if (combCategory.SelectedIndex > 0)
                {
                    prodInfo.Category = int.Parse(combCategory.SelectedValue.ToString());
                    if (combSubCategory.SelectedIndex > 0)
                    {
                        prodInfo.SubCategory = int.Parse(combSubCategory.SelectedValue.ToString());
                    }
                }
                if (txtSupplier.SelectedIndex > 0)
                {
                    prodInfo.Supplier = int.Parse(txtSupplier.SelectedValue.ToString());
                }
                if(txtitemBuy.Text != "")
                {
                    prodInfo.Buy = int.Parse(txtitemBuy.Text.ToString());
                }
                if(txtItemGet.Text != "")
                {
                    prodInfo.Get = int.Parse(txtItemGet.Text.ToString());
                }
                if (txtDateExp.Text != "")
                {
                    prodInfo.DateExp = int.Parse(txtDateExp.Text.ToString());
                }
                if (chkExpPrint.Checked == true)
                    prodInfo.Isprint = true;
                else
                    prodInfo.Isprint = false;
                prodInfo.SupplierName = txtSupplier.Text.ToString();
                prodInfo.BarCode = txtBarCode.Text.ToString();
                prodInfo.BarCode2 = txtBarCode2.Text.ToString();
                prodInfo.BarCode3 = txtBarCode3.Text.ToString();

                if (prodCont.AddNewSupperMarketProduct(prodInfo))
                {
                    MessageBox.Show("Successfull");
                    Clear();
                    txtItemName.Focus();
                    SelectItemCode();
                }
            }
        }


        private bool Validation()
        {
            bool IsSuccess = false;

            if (Program.companyProfile.IsEnglish)
            {
                if (string.IsNullOrEmpty(txtItemName.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtItemName.Text.ToString()) == true)
                {
                    MessageBox.Show("Required Item Name");
                    return IsSuccess;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtItemNameSinhala.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtItemNameSinhala.Text.ToString()) == true)
                {
                    MessageBox.Show("Required Item Name Sinhala");
                    return IsSuccess;
                }
            }
            if (string.IsNullOrEmpty(txtLabledPrice.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtLabledPrice.Text.ToString()) == true)
            {
                MessageBox.Show("Required Labled Price");
                return IsSuccess;
            }
            if (combUnit.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the Unit");
                return IsSuccess;
            }

            IsSuccess = true;

            return IsSuccess;
        }

        private void txtLabledPrice_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtLabledPrice.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Labled Price.");
            }
        }

        private void txtSpecialPrice_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtSpecialPrice.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Special Price.");
            }
        }

        private void txtWholePrice_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtWholePrice.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Wholesale Price.");
            }
        }

        private void txtBuyingCost_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtBuyingCost.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Buying Price.");
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Program.companyProfile.IsEnglish)
                {
                    combUnit.Focus();
                }
                else
                {
                    txtItemNameSinhala.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtItemNameSinhala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                combUnit.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtItemName.Focus();
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
                    if (txtItemNameSinhala.Enabled == true)
                    {
                        txtItemNameSinhala.Focus();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        txtItemName.Focus();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtLabledPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSpecialPrice.Focus();
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

        private void txtSpecialPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtWholePrice.Focus();
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

        private void txtWholePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuyingCost.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtSpecialPrice.Focus();
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
                txtWholePrice.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void combCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combSubCategory.Enabled == true)
                {
                    combSubCategory.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    txtSupplier.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                
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

        private void combSubCategory_KeyDown(object sender, KeyEventArgs e)
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
                btnAddNewSubCategory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtSupplier_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (txtSupplier.SelectedIndex < 1)
                {
                    if (combSubCategory.Enabled == true)
                    {
                        combSubCategory.Focus();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        combCategory.Focus();
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
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

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode2.Focus();
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

        private void txtBarCode2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarCode3.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtBarCode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtBarCode3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
                txtItemName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtBarCode2.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void btnAddNewCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                combCategory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnAddNewSubCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                combSubCategory.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                txtSupplier.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            AddNewCategory catList = new AddNewCategory();
            catList.ShowDialog();
            SelectAllCategory();
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

        private void btnAddNewSubCategory_Click(object sender, EventArgs e)
        {
            AddNewSubCategory newSubCat = new AddNewSubCategory(combCategory.SelectedValue.ToString());
            newSubCat.ShowDialog();
            GetSubCategory();
        }

        private void combCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combCategory.SelectedIndex > 0)
            {
                combSubCategory.Enabled = true;
                btnAddNewSubCategory.Enabled = true;
                GetSubCategory();
            }
            else
            {
                combSubCategory.Enabled = false;
                btnAddNewSubCategory.Enabled = false;
            }
        }

        private void GetSubCategory()
        {
            DataTable dt = prodCont.GetAllSubCategory(int.Parse(combCategory.SelectedValue.ToString()));
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            combSubCategory.DataSource = dt;
            combSubCategory.DisplayMember = "SubCategoryName";
            combSubCategory.ValueMember = "ID";
            combSubCategory.SelectedIndex = 0;
        }

        private void txtItemNameSinhala_Enter(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("si-LK"));
        }

        private void txtItemNameSinhala_Leave(object sender, EventArgs e)
        {
            Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        }

        private void txtitemBuy_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtitemBuy.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Buy.");
                txtitemBuy.Text = "";
            }
        }

        private void txtItemGet_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtItemGet.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Get.");
                txtItemGet.Text = "";
            }
        }

        private void txtDateExp_TextChanged(object sender, EventArgs e)
        {
            if (CmnFun.IsValidDecimalNo(txtDateExp.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Dates to Expiration.");
                txtDateExp.Text = "";
            }
        }
    }
}
