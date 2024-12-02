using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SuppliersForms
{
    public class SuppliersControler : BaseControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static DataTable dt;

        internal int GetSupplierCode()
        {
            int id = 0;
            string sql = "SELECT MAX(tps.ID) FROM tbl_pos_suppliers tps;";
            id = ReturnAndExecuteNonQuery(sql);
            return id;
        }

        internal bool AddNewSupplier(SuppliersDetailsInfo SuppInfo)
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
                        sql = "INSERT INTO tbl_pos_suppliers (ID, SuppliersName, SuppliersMobileNo, SuppliersEmail, BalanceAmount) VALUES (@suppCode, @suppName, @suppMobil, @suppEmail, @balanceAmount);";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@suppCode", SuppInfo.SuppCode);
                        cmd.Parameters.Add("@suppName", SuppInfo.SuppName);
                        cmd.Parameters.Add("@suppMobil", SuppInfo.SuppMobile);
                        cmd.Parameters.Add("@suppEmail", SuppInfo.SuppEmail);
                        cmd.Parameters.Add("@balanceAmount", SuppInfo.BalanceAmount);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
                    }
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
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

        internal bool DeleteSupplier(string id)
        {
            bool IsTrue = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sql = "DELETE FROM tbl_pos_suppliers WHERE ID = @id;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@id", id);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;
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
            return IsTrue;
        }

        internal SuppliersDetailsInfo SelectSupplierInfo(string id)
        {
            SuppliersDetailsInfo suppInfo = new SuppliersDetailsInfo();

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
                        sql = "SELECT * FROM tbl_pos_suppliers tpt WHERE tpt.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                suppInfo.SuppCode = int.Parse(r["ID"].ToString());
                                suppInfo.SuppName = r["SuppliersName"].ToString();
                                suppInfo.SuppMobile = r["SuppliersMobileNo"].ToString();
                                suppInfo.SuppEmail = r["SuppliersEmail"].ToString();
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return suppInfo;
        }

        

        internal bool UpdateSupplier(SuppliersDetailsInfo SuppInfo)
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
                        sql = "UPDATE tbl_pos_suppliers tps SET tps.SuppliersName = @suppName, tps.SuppliersMobileNo = @suppMobil, tps.SuppliersEmail = @suppEmail WHERE tps.ID = @suppCode;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@suppCode", SuppInfo.SuppCode);
                        cmd.Parameters.Add("@suppName", SuppInfo.SuppName);
                        cmd.Parameters.Add("@suppMobil", SuppInfo.SuppMobile);
                        cmd.Parameters.Add("@suppEmail", SuppInfo.SuppEmail);
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

        internal decimal GetSupBalance(int SusID)
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
                        sqlUser = "SELECT * FROM tbl_pos_suppliers tps WHERE tps.ID = '" + SusID + "'; SELECT * FROM tbl_pos_suppliers_info tpsi WHERE tpsi.SupID =  '" + SusID + "';";
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
    }
}
