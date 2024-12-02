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

namespace SmartPOS.Forms.UserForms
{
    public partial class AddNewUser : Form
    {
        private static UserControler UserCont;
        public static UserInfo UserInfo;
        public static CommonFuntion CmnFun;

        public AddNewUser()
        {

            UserCont = new UserControler();
            InitializeComponent();
            SetColors();
            SelectUserCode();
            GetJobRoleList();
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

        private void GetJobRoleList()
        {
            DataTable dt = UserCont.GetAllJobRole();
            dt.Rows.RemoveAt(0);
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            combRole.DataSource = dt;
            combRole.DisplayMember = "RoleName";
            combRole.ValueMember = "ID";
            combRole.SelectedIndex = 0;
        }

        private void SelectUserCode()
        {
            int userCode = UserCont.GetUserCode();
            txtCode.Text = (userCode + 1).ToString();
        }

        private void Clear()
        {
            txtFullName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtMoblieNo.Text = "";
            txtEmail.Text = "";
            combRole.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUserName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMoblieNo.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMoblieNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                combRole.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void combRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveUser();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SaveUser()
        {
            UserInfo = new UserInfo();
            UserCont = new UserControler();
            CmnFun = new CommonFuntion();


            if (string.IsNullOrEmpty(txtFullName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtFullName.Text.ToString()) == false)
            {
                if (string.IsNullOrEmpty(txtCode.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtCode.Text.ToString()) == false)
                {
                    if (string.IsNullOrEmpty(txtUserName.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtUserName.Text.ToString()) == false)
                    {
                        if (string.IsNullOrEmpty(txtPassword.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtPassword.Text.ToString()) == false)
                        {
                            if (combRole.SelectedIndex == 0)
                            {
                                MessageBox.Show("Please select the Job Role");
                            }
                            else
                            {
                                UserInfo.UserID = int.Parse(txtCode.Text.ToString());
                                UserInfo.FullName = txtFullName.Text.Trim().ToString();
                                UserInfo.UseryName = txtUserName.Text.ToString();
                                UserInfo.Password = CmnFun.Encrypt(txtPassword.Text.ToString());
                                UserInfo.MobileNo = txtMoblieNo.Text.ToString();
                                UserInfo.Email = txtEmail.Text.ToString();
                                UserInfo.JobRole = int.Parse(combRole.SelectedValue.ToString());

                                if (UserCont.AddNewUser(UserInfo))
                                {
                                    MessageBox.Show("Successfull");
                                    Clear();
                                    SelectUserCode();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Required User Password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Required User Name");
                    }
                }
                else
                {
                    MessageBox.Show("Required User Code");
                }
            }
            else
            {
                MessageBox.Show("Required User Full Name");
            }
        }
    }
}
