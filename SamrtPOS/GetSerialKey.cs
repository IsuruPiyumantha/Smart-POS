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

namespace SmartPOS
{
    public partial class GetSerialKey : Form
    {
        private CommonFuntion comnFuntion;
        public GetSerialKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comnFuntion = new CommonFuntion();
            string a = textBox1.Text.ToString();
            string b = comnFuntion.Encrypt(a);
            textBox2.Text = b.ToString();
        }
    }
}
