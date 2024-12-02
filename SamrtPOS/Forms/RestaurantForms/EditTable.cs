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
    public partial class EditTable : Form
    {
        private static AllTableInfo tblInfo;

        public EditTable(string id)
        {
            InitializeComponent();
            GetTableInfo(id);
            setColour();
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

        private void GetTableInfo(string id)
        {
            TbaleManagerControler tblMng = new TbaleManagerControler();
            tblInfo = new AllTableInfo();

            tblInfo = tblMng.GetTableInfo(id);

            if (tblInfo != null)
            {
                txtName.Text = tblInfo.TableName;
                txtCode.Text = tblInfo.TableCode;

                if (tblInfo.IsUse == true)
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCode.Text = "";
            checkBox.Checked = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateTable();
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
                checkBox.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void checkBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTable();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void UpdateTable()
        {
            TbaleManagerControler tblMng = new TbaleManagerControler();

            if (string.IsNullOrEmpty(txtName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtCode.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtCode.Text.ToString()) == false)
                {
                    tblInfo.TableName = txtName.Text.Trim().ToString();
                    tblInfo.TableCode = txtCode.Text.Trim().ToString();
                    if (checkBox.Checked == true)
                    {
                        tblInfo.IsUse = true;
                    }
                    else
                    {
                        tblInfo.IsUse = false;
                    }
                    if (tblMng.UpdateTableInfo(tblInfo))
                    {
                        MessageBox.Show("Successfull Update");
                        this.Close();
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
