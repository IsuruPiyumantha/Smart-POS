using MySql.Data.MySqlClient;
using SmartPOS.Controler;
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
    public partial class SystemAction : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private DataTable dt1;
        private static int roleID;

        public SystemAction(int id)
        {
            InitializeComponent();
            roleID = id;
            GetData();
            SetColors();
        }

        private void GetData()
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
                        string sqlUser = "";
                        sqlUser = "SELECT tpp.*,tpsa.ActionName FROM tbl_pos_privilage tpp INNER JOIN tbl_pos_system_action tpsa ON tpp.Action = tpsa.ID WHERE tpp.RoleID = '" + roleID + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];

                        if (dt1.Rows.Count > 0)
                        {
                            gridDataDetails.AutoGenerateColumns = false;
                            gridDataDetails.DataSource = dt1;
                        }
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
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save() == true)
            {
                MessageBox.Show("Successfull Update.");
                this.Close();
            }
        }

        private bool Save()
        {
            bool IsSuccess = false;
            DataTable dt = (DataTable)gridDataDetails.DataSource;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sqlUser = "";

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                int ID = int.Parse(row["ID"].ToString());
                                int isTrue = 0;
                                if (row["IsTrue"].ToString() == "")
                                {
                                    isTrue = 0;
                                }
                                else
                                {
                                    isTrue = int.Parse(row["IsTrue"].ToString());
                                }
                                //int isTrue = int.Parse(row["IsTrue"].ToString());

                                string sql = "UPDATE tbl_pos_privilage tpp SET tpp.IsTrue = '" + isTrue + "' WHERE tpp.ID = '" + ID + "';";
                                MySqlCommand cmd = new MySqlCommand(sql, con);
                                cmd.ExecuteNonQuery();

                                IsSuccess = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorForm errorFrm = new ErrorForm(ex.Message, sqlUser);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsSuccess;
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
