using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
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
    public partial class EditSubCategory : Form
    {
        private string id;

        public EditSubCategory()
        {
            InitializeComponent();
        }

        private void setColour()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        public EditSubCategory(string id)
        {
            // TODO: Complete member initialization
            this.id = id;

            InitializeComponent();
            setColour();
            CategoryInfo CatInfo = new CategoryInfo();
            ItemsCategoryControls CatCont = new ItemsCategoryControls();

            CatInfo = CatCont.SelectSubCategoryInfo(id);

            if (CatInfo != null)
            {
                txtName.Text = CatInfo.CategoryName.ToString();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateCategory();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateCategory();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void UpdateCategory()
        {
            ItemsCategoryControls CatCont = new ItemsCategoryControls();

            if (string.IsNullOrEmpty(txtName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtName.Text.ToString()) == false)
            {
                string name = txtName.Text.Trim().ToString();

                if (CatCont.UpdateCategory(this.id, name))
                {
                    MessageBox.Show("Successfull Update");
                    txtName.Text = "";
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Category Name is Empty or Null");
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
