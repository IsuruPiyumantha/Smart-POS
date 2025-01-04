using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class Backup : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private string BackUpTime = string.Empty;
        private string BackUpPath = string.Empty;

        public Backup()
        {
            InitializeComponent();
            AllItemsDT();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllItemsDT()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_backup tpb;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                BackUpTime = r["BackupTime"].ToString();
                                BackUpPath = r["Path"].ToString();

                                backUpTimePick.Value = Convert.ToDateTime(BackUpTime.ToString());
                                txtBackupPath.Text = BackUpPath.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void UpdateFee()
        {
            if (string.IsNullOrEmpty(backUpTimePick.Text) == true || string.IsNullOrWhiteSpace(backUpTimePick.Text) == true)
            {
                MessageBox.Show("Req BackUp Time.");
            }
            if (string.IsNullOrEmpty(txtBackupPath.Text) == true || string.IsNullOrWhiteSpace(txtBackupPath.Text) == true)
            {
                MessageBox.Show("Req BackUp Path.");
            }
            else
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);

                try
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();

                        if (con != null)
                        {
                            string sql = "UPDATE tbl_pos_backup tpb SET tpb.BackupTime = @backuptime , tpb.Path = @backUpPath WHERE tpb.ID = 1;";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@backuptime", backUpTimePick.Text);
                            cmd.Parameters.Add("@backUpPath", txtBackupPath.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                        this.Close();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateFee();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
            txtBackupPath.Text = "";
            backUpTimePick.Text = "";

        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txttax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateFee();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            PerformBackup(BackUpPath);
        }

        static void PerformBackup(string backpath)
        {
            string server = "localhost";
            string user = "root";
            string password = "Msdh@7#8";
            string database = "smart_pos_database";
            string path = backpath;
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string backupFile = Path.Combine(path, $"{database}_backup_{timestamp}.sql");

            // Ensure the backup directory exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // Construct the mysqldump command
            string dumpCommand = $"mysqldump -h {server} -u {user} -p{password} {database} > \"{backupFile}\"";

            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + dumpCommand)
                {
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                Process process = Process.Start(processInfo);
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    MessageBox.Show($"Backup successful: {backupFile}");
                }
                else
                {
                    MessageBox.Show($"Backup failed. Error: {process.StandardError.ReadToEnd()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while performing backup: {ex.Message}");
            }
        }
    }
}
