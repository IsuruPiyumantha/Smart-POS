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
    public partial class EditUser : Form
    {
        private static UserControler UserCont;
        public static UserInfo UserInfo;
        public static CommonFuntion CmnFun;
        private string id;

        public EditUser()
        {
            InitializeComponent();
            SetColors();
        }

        public EditUser(string id)
        {
            UserCont = new UserControler();
            InitializeComponent();
            SetColors();
            SelectUserCode();
            GetJobRoleList();
            this.id = id;
            GetUserInfo(id);
        }

        private void GetUserInfo(string id)
        {
            UserInfo = new UserInfo();
            UserCont = new UserControler();
            CmnFun = new CommonFuntion();

            UserInfo = UserCont.SelectUserInfo(id);

            if (UserInfo != null)
            {
                txtCode.Enabled = false;
                txtCode.Text = UserInfo.UserID.ToString();
                txtFullName.Text = UserInfo.FullName.ToString();
                txtUserName.Text = UserInfo.UseryName.ToString();
                txtPassword.Text = CmnFun.Decrypt(UserInfo.Password.ToString());
                txtMoblieNo.Text = UserInfo.MobileNo.ToString();
                txtEmail.Text = UserInfo.Email.ToString();
                combRole.SelectedValue = UserInfo.JobRole.ToString();

                if (UserInfo.Active)
                {
                    checkActive.Checked = true;
                }
                else
                {
                    checkActive.Checked = false;
                }
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
            UpdateUser();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
                checkActive.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void checkActive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUser();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void UpdateUser()
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
                            if (combRole.SelectedIndex <= 0)
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
                                if (checkActive.Checked)
                                {
                                    UserInfo.Active = true;
                                }
                                else
                                {
                                    UserInfo.Active = false;
                                }

                                if (UserCont.UpdateUserInfo(UserInfo))
                                {
                                    MessageBox.Show("Successfull Update");
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
