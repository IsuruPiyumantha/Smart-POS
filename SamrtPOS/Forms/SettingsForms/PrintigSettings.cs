using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.SettingsForms.PrintigSetting;
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

namespace SmartPOS.Forms.SettingsForms
{
    public partial class PrintigSettings : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public PrintigSettings()
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Restaurant_Cash_Bill");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Restaurant_Card_Bill");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Supper_Market_Cash_Bill_English");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Supper_Market_Card_Bill_English");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TableBillSetting restaurantCashBill = new TableBillSetting("Restaurant_Table_Bill");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Supper_Market_Cash_Bill_Sinhala");
            restaurantCashBill.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BillSetting restaurantCashBill = new BillSetting("Supper_Market_Card_Bill_Sinhala");
            restaurantCashBill.ShowDialog();
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
