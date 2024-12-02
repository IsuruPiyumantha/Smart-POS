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
    public partial class ClearData : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public ClearData()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_items;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_item_category;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_customers_info; TRUNCATE TABLE tbl_pos_customers;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_grn_details; TRUNCATE TABLE tbl_pos_grn;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_restaurant_sales;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_supper_market_sales;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_invoice_details;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_kot_print;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_stock;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_suppliers_info;TRUNCATE TABLE tbl_pos_suppliers;INSERT INTO tbl_pos_suppliers (ID, SuppliersName, SuppliersMobileNo, SuppliersEmail, BalanceAmount, cDate) VALUES (0, '', '', '', 0, NOW());";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_tables;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
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
                        sqlUser = "SELECT * FROM tbl_pos_role tpr; SELECT * FROM tbl_pos_system_action tpsa;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "DT");
                        DataTable AllRole = ds.Tables["DT"];
                        DataTable AllAction = ds.Tables["DT1"];

                        string sql = "TRUNCATE TABLE tbl_pos_privilage;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        if (AllRole.Rows.Count > 0)
                        {
                            foreach (DataRow r in AllRole.Rows)
                            {
                                int RoleID = int.Parse(r["ID"].ToString());

                                if (AllAction.Rows.Count > 0)
                                {
                                    foreach (DataRow rr in AllAction.Rows)
                                    {
                                        int ActionID = int.Parse(rr["ID"].ToString());

                                        int isTure = 0;
                                        if (RoleID == 1 || RoleID == 2)
                                            isTure = 1;

                                        string sql2 = "INSERT INTO tbl_pos_privilage (RoleID, Action, IsTrue)  VALUES ('" + RoleID + "', '" + ActionID + "', '" + isTure + "');";
                                        MySqlCommand cmd2 = new MySqlCommand(sql2, con);
                                        cmd2.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Successfull Deleting.");
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
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_grn;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_grn_details;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "UPDATE tbl_pos_items tpi SET tpi.InStock = 0;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_cash_book;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_cheques;";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "TRUNCATE TABLE tbl_pos_user;INSERT INTO tbl_pos_user(FullName, UserName, Password, MobileNo, Email, Active,RoleID, cUser, cDate) VALUES ('Isuru Piyumantha','isuru','MdIsV2xRCopx0hV6WDnnKUzGyiwBNw9KLXwpnYZjjz8=','0','0',1,1,1,NOW());";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfull Deleting.");

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
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
