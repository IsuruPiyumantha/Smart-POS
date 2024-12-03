using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.SettingsForms;
using SmartPOS.Forms.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS
{
    public partial class Login : Form
    {
        private bool IsEng;
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static GridColourClass color;
 
        public Login(bool IsEng)
        {
            color = new GridColourClass();
            this.IsEng = IsEng;
            InitializeComponent();
            setColour();
            SelectLang();
            SeteLogo();
        }

        private void SeteLogo()
        {
            try
            {
                string path =  Directory.GetCurrentDirectory() + "\\Logo.jpeg";
                if (File.Exists(path))
                {
                    Bitmap b = new Bitmap(@path);
                    imgLogo.BackgroundImage = b;
                }
                else
                {
                    path = Directory.GetCurrentDirectory() + "\\Logo.png";
                    if (File.Exists(path))
                    {
                        Bitmap b = new Bitmap(@path);
                        imgLogo.BackgroundImage = b;
                    }
                }
            }
            catch
            {

            }
        }

        private void SelectLang()
        {
            if (IsEng)
            {
                RbtnEnglish.Checked = true;
            }
            else
            {
                RbtnSinhala.Checked = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            UserInfo userInfo = new UserInfo();
            UserControler userControl = new UserControler();

            try
            {
                if (string.IsNullOrEmpty(txtUserName.Text) == false || string.IsNullOrWhiteSpace(txtUserName.Text) == false)
                {
                    if (string.IsNullOrEmpty(txtPassword.Text) == false || string.IsNullOrWhiteSpace(txtPassword.Text) == false)
                    {
                        userInfo = userControl.Login(txtUserName.Text.ToString(), txtPassword.Text.ToString());

                        if (userInfo != null)
                        {
                            Program.userDetails = userInfo;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Required Password.");
                    }
                }
                else
                {
                    MessageBox.Show("Required User Name.");
                }
            }
            catch (Exception ee)
            {
                ErrorForm errorFrm = new ErrorForm(ee.Message, "");
                errorFrm.ShowDialog();
            }
        }

        private void setColour()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            color.FormNormalButtonMain(btnSave);
            color.FormNormalButtonMain(btnClear);
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();
            if (password.GetFinalState() == true)
            {
                Networking network = new Networking();
                network.ShowDialog();
                this.Close();
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
