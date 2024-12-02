using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Controler
{
    public partial class ErrorForm : Form
    {
        private string message, sql;

        public ErrorForm(string message, string sql)
        {
            InitializeComponent();
            this.message = message;
            this.sql = sql;
        }

        private void ErrorForm_Load(object sender, EventArgs e)
        {

        }

        private void OpenMessage(string mes)
        {
            this.Height = 207;
            panel1.Height = 172;
            textBox1.Text = mes;
        }

        private void HideMessage()
        {
            this.Height = 114;
            panel1.Height = 78;
            textBox1.Clear();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "View Error Message")
            {
                this.OpenMessage(this.message);
                linkLabel1.Text = "Hide Error Message";
            }
            else
            {
                this.HideMessage();
                linkLabel1.Text = "View Error Message";
            }
            linkLabel2.Text = "View SQL";
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel2.Text == "View SQL")
            {
                this.OpenMessage(this.sql);
                linkLabel2.Text = "Hide SQL";
            }
            else
            {
                this.HideMessage();
                linkLabel2.Text = "View SQL";
            }
            linkLabel1.Text = "View Error Message";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
