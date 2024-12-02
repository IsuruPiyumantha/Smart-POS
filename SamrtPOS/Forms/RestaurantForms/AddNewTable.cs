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

namespace SmartPOS.Forms.RestaurantForms
{
    public partial class AddNewTable : Form
    {
        public AddNewTable()
        {
            InitializeComponent();
            setColour();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCode.Text = "";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveTable();
        }
            

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCode.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveTable();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                txtName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void SaveTable()
        {
            TablesManeg TblMng = new TablesManeg();
            TbaleManagerControler tblMng = new TbaleManagerControler();

            if (string.IsNullOrEmpty(txtName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtCode.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtCode.Text.ToString()) == false)
                {
                    string name = txtName.Text.Trim().ToString();
                    string code = txtCode.Text.Trim().ToString();

                    if (tblMng.AddNewTable(name, code))
                    {
                        MessageBox.Show("Successfull");
                        txtCode.Text = "";
                        txtName.Text = "";
                        TblMng.fillData();
                    }
                }
                else
                {
                    MessageBox.Show("Table Code is Empty or Null");
                }
            }
            else
            {
                MessageBox.Show("Table Name is Empty or Null");
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
