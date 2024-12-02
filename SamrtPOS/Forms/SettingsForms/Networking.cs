using MySql.Data.MySqlClient;
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

namespace SmartPOS.Forms.SettingsForms
{
    public partial class Networking : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public Networking()
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
            con = new MySqlConnection("Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=smart_pos_database;CharSet=utf8;");

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_database tpd;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                TxtHostName.Text = r["Host"].ToString();
                                txtUserName.Text = r["UserName"].ToString();
                                txtPassword.Text = r["Password"].ToString();
                                txtDatabase.Text = r["DatabaseName"].ToString();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtHostName.Text) == true || string.IsNullOrWhiteSpace(TxtHostName.Text) == true)
            {
                MessageBox.Show("Req Host Name.");
            }
            if (string.IsNullOrEmpty(txtUserName.Text) == true || string.IsNullOrWhiteSpace(txtUserName.Text) == true)
            {
                MessageBox.Show("Req UserName.");
            }
            if (string.IsNullOrEmpty(txtPassword.Text) == true || string.IsNullOrWhiteSpace(txtPassword.Text) == true)
            {
                MessageBox.Show("Req Password.");
            }
            if (string.IsNullOrEmpty(txtDatabase.Text) == true || string.IsNullOrWhiteSpace(txtDatabase.Text) == true)
            {
                MessageBox.Show("Req Database.");
            }
            else
            {
                con = new MySqlConnection("Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=smart_pos_database;CharSet=utf8;");

                try
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();

                        if (con != null)
                        {
                            string sql = "UPDATE tbl_pos_database tpd SET tpd.Host = @host, tpd.UserName = @userName, tpd.Password = @password, tpd.DatabaseName = @database;";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@host", TxtHostName.Text);
                            cmd.Parameters.Add("@userName", txtUserName.Text);
                            cmd.Parameters.Add("@password", txtPassword.Text);
                            cmd.Parameters.Add("@database", txtDatabase.Text);
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
                    }
                }
                Application.Restart();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
            txtPassword.Text = "";
            TxtHostName.Text = "";
            txtUserName.Text = "";
            txtDatabase.Text = "";

        }
    }
}
