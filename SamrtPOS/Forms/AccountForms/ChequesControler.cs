using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.AccountForms
{
    public class ChequesControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion cmnFuntion;

        public bool SaveCashbook(string CashINorOUT, decimal Amount, string Description)
        {
            bool IsTrue = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            cmnFuntion = new CommonFuntion();
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            string sql = string.Empty;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        if (CashINorOUT == "CashIN")
                        {
                            sql = "INSERT INTO tbl_pos_cash_book (Description, Credit, Debit, cUser, cDate) VALUES (@description, @payAmt, 0, @cUser, '" + nowDate + "');";
                        }
                        else if (CashINorOUT == "CashOUT")
                        {
                            sql = "INSERT INTO tbl_pos_cash_book (Description, Credit, Debit, cUser, cDate) VALUES (@description, 0, @payAmt, @cUser, '" + nowDate + "');";
                        }
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@description", Description);
                        cmd.Parameters.Add("@payAmt", Amount);
                        cmd.Parameters.Add("@cUser", Program.userDetails.UserID);
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

        internal DataTable getChequesDetails(string fromDate, string toDate)
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sql = "";
            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT tpc.*, tpu.UserName FROM tbl_pos_cheques tpc INNER JOIN tbl_pos_user tpu ON tpu.ID = tpc.cUser WHERE tpc.cDate BETWEEN '" + fromDate + "' AND '" + toDate + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "dataDT");
                        dt1 = ds.Tables["dataDT"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorForm errorFrm = new ErrorForm(ex.Message, sql);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return dt1;
        }
    }
}
