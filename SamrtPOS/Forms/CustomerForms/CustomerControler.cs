using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.CustomerForms
{
    public class CustomerControler : BaseControler
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static DataTable dt;

        internal int GetCustomerCode()
        {
            int id = 0;
            string sql = "SELECT MAX(tpc.ID) FROM tbl_pos_customers tpc";
            id = ReturnAndExecuteNonQuery(sql);
            return id;
        }

        internal bool AddNewCustomer(CustomerDetailsInfo CusInfo)
        {
            bool IsTrue = false;

            CommonFuntion cmnFuntion = new CommonFuntion();
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sql = string.Empty;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "INSERT INTO tbl_pos_customers (ID, CustomerName,CustomerAddress, CustomerMobileNo, CustomerEmail, BalanceAmount, cDate) VALUES (@suppCode, @suppName, @suppAddress, @suppMobil, @suppEmail, @balanceAmt, '" + nowDate + "');";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@suppCode", CusInfo.CusCode);
                        cmd.Parameters.Add("@suppName", CusInfo.CusName);
                        cmd.Parameters.Add("@suppAddress", CusInfo.CusAddress);
                        cmd.Parameters.Add("@suppMobil", CusInfo.CusMobile);
                        cmd.Parameters.Add("@suppEmail", CusInfo.CusEmail);
                        cmd.Parameters.Add("@balanceAmt", CusInfo.Amount);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsTrue;
        }

        internal bool DeleteCustomer(string id)
        {
            bool IsTrue = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sql = string.Empty;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "DELETE FROM tbl_pos_customers WHERE ID = @id;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@id", id);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsTrue;
        }

        internal CustomerDetailsInfo SelectCustomerInfo(string id)
        {
            CustomerDetailsInfo CusInfo = new CustomerDetailsInfo();

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            string sql = string.Empty;

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT * FROM tbl_pos_customers tpc WHERE tpc.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                CusInfo.CusCode = int.Parse(r["ID"].ToString());
                                CusInfo.CusName = r["CustomerName"].ToString();
                                CusInfo.CusAddress = r["CustomerAddress"].ToString();
                                CusInfo.CusMobile = r["CustomerMobileNo"].ToString();
                                CusInfo.CusEmail = r["CustomerEmail"].ToString();
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return CusInfo;
        }

        internal bool UpdateCustomer(CustomerDetailsInfo CusInfo)
        {
            bool IsTrue = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            string sql = string.Empty;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "UPDATE tbl_pos_customers tpc SET tpc.CustomerName = @suppName , tpc.CustomerAddress = @suppAddress, tpc.CustomerMobileNo = @suppMobil, tpc.CustomerEmail = @suppEmail WHERE tpc.ID = @suppCode;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@suppCode", CusInfo.CusCode);
                        cmd.Parameters.Add("@suppName", CusInfo.CusName);
                        cmd.Parameters.Add("@suppAddress", CusInfo.CusAddress);
                        cmd.Parameters.Add("@suppMobil", CusInfo.CusMobile);
                        cmd.Parameters.Add("@suppEmail", CusInfo.CusEmail);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsTrue;
        }

        private DataTable CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Debit", typeof(decimal));
            dt.Columns.Add("Credit", typeof(decimal));
            dt.Columns.Add("BalanceAmount", typeof(decimal));
            dt.Columns.Add("count", typeof(int));
            return dt;
        }

        internal decimal GetCusBalance(int CusID)
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            dt = CreateDataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            decimal OpenAmt = 0;
            decimal BalanceAmt = 0;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_customers tpc WHERE tpc.ID = '" + CusID + "'; SELECT * FROM tbl_pos_customers_info tpci WHERE tpci.CusID = '" + CusID + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        dt2 = ds.Tables["userDT1"];

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r1 in dt1.Rows)
                            {
                                OpenAmt = decimal.Parse(r1["BalanceAmount"].ToString());
                                BalanceAmt = OpenAmt;
                                dt.Rows.Add("Openning Balance", r1["cDate"].ToString(), 0, 0, BalanceAmt);
                            }
                        }

                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow r2 in dt2.Rows)
                            {
                                decimal debit = decimal.Parse(r2["Debit"].ToString());
                                decimal credit = decimal.Parse(r2["Credit"].ToString());

                                if (debit > 0)
                                {
                                    BalanceAmt = BalanceAmt - debit;
                                    dt.Rows.Add(r2["Description"].ToString(), r2["cDate"].ToString(), debit, 0, BalanceAmt);
                                }
                                if (credit > 0)
                                {
                                    BalanceAmt = BalanceAmt + credit;
                                    dt.Rows.Add(r2["Description"].ToString(), r2["cDate"].ToString(), 0, credit, BalanceAmt);
                                }
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
            return BalanceAmt;
        }

        internal DataTable SelectAllCustomers()
        {
            DataTable dt = new DataTable();
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
                        sqlUser = "SELECT tpc.ID,tpc.CustomerName FROM tbl_pos_customers tpc;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        dt = ds.Tables["itemDT"];
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
            return dt;
        }
    }
}
