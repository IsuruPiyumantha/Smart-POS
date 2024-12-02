using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using SmartPOS;

namespace Nekfa.DataBaseInstaller
{
    public partial class DataBaseConfigForm : Form
    {
        public DataBaseConfigForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    lblMsg.Text = "";
            //    Process process1 = Process.Start("C:\\Program Files\\MySQL\\MySQL Server 5.0\\bin\\MySQLInstanceConfig.exe");
            //    process1.WaitForExit();
            //    process1.Close();
            //    PradeshiyaSaba.Program.dataBaseprocessId = 2;
            //    this.Close();
            //}
            //catch (Exception ee)
            //{
            //    lblMsg.Text = "Data Base Configuration error.";
            //    lblMsg.ForeColor = System.Drawing.Color.Red;
            //}



            string path = @"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysql.exe";
            string conConfig = @"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\MySQLInstanceConfig.exe";
            if (!File.Exists(path))
            {
                string path1 = @"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe";
                if (File.Exists(path1))
                {
                    path = path1;
                    conConfig = @"C:\Program Files\MySQL\MySQL Server 5.0\bin\MySQLInstanceConfig.exe";
                }
                else
                {
                    lblMsg.Text = "MySQL Configuration error.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }


            try
            {
                lblMsg.Text = "";
                Process process1 = Process.Start(conConfig);
                process1.WaitForExit();
                process1.Close();
                Program.dataBaseprocessId = 2;
                this.Close();
            }
            catch (Exception ee)
            {
                lblMsg.Text = "MySQL Configuration error.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
           
        

        private void DataBaseConfigForm_Load(object sender, EventArgs e)
        {

        }
    }
}
