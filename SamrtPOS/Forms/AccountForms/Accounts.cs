using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.BarCodeForms;
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

namespace SmartPOS.Forms.AccountForms
{
    public partial class Accounts : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public Accounts()
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

        private void btnCustForm_Click(object sender, EventArgs e)
        {
            Cheques chq = new Cheques();
            chq.ShowDialog();
        }

        private void btnSaleForm_Click(object sender, EventArgs e)
        {
            CashInOut cashInOut = new CashInOut();
            cashInOut.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            CashBook cashBook = new CashBook();
            cashBook.ShowDialog();
        }

        private void btnSaleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCustForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
