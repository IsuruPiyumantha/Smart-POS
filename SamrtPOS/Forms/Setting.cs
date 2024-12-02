using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.SettingsForms;
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

namespace SmartPOS.Forms
{
    public partial class Setting : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;

        public Setting()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
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

        private void linkLabelChages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 6))
            {
                Chages chg = new Chages();
                chg.ShowDialog();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ScaleExport expot = new ScaleExport();
            expot.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();

            if (password.GetFinalState() == true)
            {
                ClearData clearData = new ClearData();
                clearData.ShowDialog();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();

            if (password.GetFinalState() == true)
            {
                CompanyDetails CompDetails = new CompanyDetails();
                CompDetails.ShowDialog();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 3))
            {
                RoleMgt roleMgt = new RoleMgt();
                roleMgt.ShowDialog();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Colors colors = new Colors();
            colors.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrintigSettings printigSetting = new PrintigSettings();
            printigSetting.Show();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PrinterSettings printer = new PrinterSettings();
            printer.Show();
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
