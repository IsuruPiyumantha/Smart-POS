using MySql.Data.MySqlClient;
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

namespace SmartPOS.Forms.SettingsForms
{
    public partial class Password : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private bool finalState;

        public Password()
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
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.finalState = false;
                try
                {
                    if (txtPassword.Text.Trim() != "")
                    {

                        if (txtPassword.Text.Equals("Support@2024"))
                        {
                            this.finalState = true;
                            this.Close();
                        }
                        else
                        {
                            this.finalState = false;
                            lblMsg.Text = "Incorrect Password..!";
                            txtPassword.SelectAll();
                        }
                    }
                    else
                    {
                        lblMsg.Text = "Enter Admin Password..!";
                        this.ActiveControl = txtPassword;
                    }
                }
                catch (Exception ee)
                {
                    this.finalState = false;
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        public bool GetFinalState()
        {
            return this.finalState;
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
