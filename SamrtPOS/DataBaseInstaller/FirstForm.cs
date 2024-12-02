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
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    lblMsg.Text = "";
                    Process process = Process.Start(Directory.GetCurrentDirectory() + "\\mysql.msi");
                    process.WaitForExit();
                    process.Close();
                    if (File.Exists(@"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysql.exe"))
                    
                    {
                        Program.dataBaseprocessId = 1;
                        this.Close();

                    }
                    if (File.Exists(@"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe"))
                    
                    {
                        Program.dataBaseprocessId = 1;
                        this.Close();
                    }


                    else
                    {
                        lblMsg.Text = "Data Base Coping error.";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ee)
                {
                    lblMsg.Text = "Data Base Coping error.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }



                /////////  old    /////////////

                //try
                //{
                //    lblMsg.Text = "";
                //    Process process = Process.Start(Directory.GetCurrentDirectory() + "\\mysql.msi");
                //    process.WaitForExit();
                //    process.Close();
                //    if (System.IO.Directory.Exists(@"c:\\Program Files\\MySQL\\MySQL Server 5.0\\bin"))
                //    {
                //        PradeshiyaSaba.Program.dataBaseprocessId = 1;
                //        this.Close();
                //    }
                //    else
                //    {
                //        lblMsg.Text = "Data Base Coping error.";
                //        lblMsg.ForeColor = System.Drawing.Color.Red;
                //    }
                //}
                //catch (Exception ee)
                //{
                //    lblMsg.Text = "Data Base Coping error.";
                //    lblMsg.ForeColor = System.Drawing.Color.Red;
                //}

            }
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {

        }
        
    }
}




