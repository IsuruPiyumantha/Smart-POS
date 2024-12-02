using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS;

namespace Nekfa.DataBaseInstaller
{
    public partial class PasswordChange : Form
    {
        private DataBaseManagementClass dbMgr;

        public PasswordChange()
        {
            InitializeComponent();
            dbMgr = new DataBaseManagementClass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNew.Text != null && txtNew.Text != "" && txtOld.Text != null && txtOld.Text != "")
            {
                if (dbMgr.changeRootPasswords(txtOld.Text))
                {
                    Program.dataBaseprocessId = 3;
                    this.Close();
                }
                else
                {
                    lblMsg.Text = "Incorrect existing password.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "Passwords cannot be a null.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        

        


    }
}
