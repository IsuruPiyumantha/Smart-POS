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
using SmartPOS.Controler;
using SmartPOS;

namespace Nekfa.DataBaseInstaller
{
    public partial class ImportDataBase : Form
    {
        private DataBaseManagementClass dbMgr;
        private bool state;

        public ImportDataBase()
        {
            InitializeComponent();
            proBar.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            proBar.Style = ProgressBarStyle.Continuous;
            proBar.PerformStep();
            proBar.Visible = true;
            timerPro.Start();
            button2.Enabled = false;
            button3.Enabled = false;
            backgroundWorker1.RunWorkerAsync();            
        }


        private bool createResoreMySQLFile()
        {


            string path = @"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysql.exe";

            if (!File.Exists(path))
            {
                string path1 = @"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe";
                if (File.Exists(path1))
                {
                    path = path1;

                }
                else
                {
                    lblMsg.Text = "Data Base Restore error.\nPlease contact administrator.";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }

            try
            {
                StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + "\\smartposDB.sql");
                ProcessStartInfo proc = new ProcessStartInfo();

                string cmdArgs = string.Format(@"-u{0} -p{1} -h{2} {3}", "root", "Msdh@7#8", "localhost", "smart_pos_database");
                proc.FileName = path;
                proc.RedirectStandardInput = true;
                proc.RedirectStandardOutput = false;
                proc.Arguments = cmdArgs;
                proc.UseShellExecute = false;
                proc.CreateNoWindow = true;
                Process p = Process.Start(proc);
                string res = file.ReadToEnd();
                file.Close();
                p.StandardInput.WriteLine(res);
                p.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

            //try
            //{
            //    StreamReader file = new StreamReader(Directory.GetCurrentDirectory() + "\\rate.sql");
            //    ProcessStartInfo proc = new ProcessStartInfo();

            //    string cmdArgs = string.Format(@"-u{0} -p{1} -h{2} {3}", "root", "Msdh@7#8", "localhost", "ratedatabase");
            //    proc.FileName = "C:\\Program Files\\MySQL\\MySQL Server 5.0\\bin\\mysql.exe";
            //    proc.RedirectStandardInput = true;
            //    proc.RedirectStandardOutput = false;
            //    proc.Arguments = cmdArgs;
            //    proc.UseShellExecute = false;
            //    proc.CreateNoWindow = true;
            //    Process p = Process.Start(proc);
            //    string res = file.ReadToEnd();
            //    file.Close();
            //    p.StandardInput.WriteLine(res);
            //    p.Close();
            //    return true; 
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           DataBaseManagementClass dbMgr=new DataBaseManagementClass();
           if (dbMgr.createDatabase())
           {
               state = this.createResoreMySQLFile();
           }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {         

            timerPro.Stop();
            proBar.Style = ProgressBarStyle.Blocks;
            if (state)
            {
                Program.dataBaseprocessId = 5;
                this.Close();
            }
            else
            {
                lblMsg.Text = "Data Base Restore error.\nPlease contact administrator.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                button2.Enabled = true;
                button3.Enabled = true;
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (proBar.Value == proBar.Maximum)
                proBar.Value = 0;
            proBar.PerformStep();
        }

        
    }
}
