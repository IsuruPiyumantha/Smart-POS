using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.GRNForms
{
    public class GRNControler : BaseControler
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private CommonFuntion cmnFuntion;
        private MySqlTransaction trans;

        internal GRNinfo GetGrnNumber()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            GRNinfo info = new GRNinfo();
            string sql = string.Empty;

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT * FROM tbl_pos_index tbi;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "GetInfo");
                        dt1 = ds.Tables["GetInfo"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                info.GRNDate = r["GRNdate"].ToString();
                                info.GRNCode = r["GRNcode"].ToString();
                                info.GRNNumber = int.Parse(r["GRNnumber"].ToString());
                            }
                        }

                    }

                    con.Close();
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
            con.Close();
            return info;
        }

        internal bool UpdateGRNDate(ref GRNinfo info, string date)
        {
            bool state = false;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_pos_index tpi SET tpi.GRNdate = '" + date + "',tpi.GRNnumber = '1' WHERE tpi.GRNcode = '" + info.GRNCode + "'; ", con);
                cmd.ExecuteNonQuery();
                state = true;
                info.GRNNumber = 1;
                cmd.Cancel();
                con.Close();

            }
            catch (Exception e)
            {
                state = false;
            }
            return state;
        }

        internal bool UpdateNextGRNNumber(int GRNNO, string GRNCode, bool IsClose)
        {
            bool state = false;
            int NewGRNNo = 0;
            if (!IsClose)
            {
                NewGRNNo = GRNNO + 1;
            }
            else
            {
                NewGRNNo = GRNNO;
            }
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_pos_index tpi SET tpi.GRNnumber = '" + NewGRNNo + "' WHERE tpi.GRNcode = '" + GRNCode + "';", con);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
                con.Close();
                state = true;
            }
            catch (Exception e)
            {
                state = false;
            }
            return state;
        }

        internal bool AddNewGRN(GRNDetailsInfo GRNInfo, DataTable GRNDetails,string Method)
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
                    trans = con.BeginTransaction();

                    if (con != null)
                    {
                        int id = 0;
                        sql = "INSERT INTO tbl_pos_grn (GRNNumber, Description, SupplierID, TotalAmount, PayAmount, Method, cDate, cUser) VALUES (@grnNum, @descri, @suoID, @tot, @payAmt, @method, NOW(), @cUser);";
                        MySqlCommand cmd = new MySqlCommand(sql, con, trans);
                        cmd.Parameters.Add("@grnNum", GRNInfo.GRNNumber);
                        cmd.Parameters.Add("@descri", GRNInfo.Description);
                        cmd.Parameters.Add("@suoID", GRNInfo.SupplirtID);
                        cmd.Parameters.Add("@tot", GRNInfo.Total);
                        cmd.Parameters.Add("@payAmt", GRNInfo.Amount);
                        cmd.Parameters.Add("@method", GRNInfo.Method);
                        cmd.Parameters.Add("@cUser", Program.userDetails.UserID);
                        id = cmd.ExecuteNonQuery();
                        id = int.Parse(cmd.LastInsertedId.ToString());
                        IsTrue = true;
                        if (GRNDetails.Rows.Count > 0)
                        {
                            foreach (DataRow r in GRNDetails.Rows)
                            {
                                string ICode = r["ItemCode"].ToString();
                                string IName = r["ItemName"].ToString();
                                string BCost = r["BuyingCost"].ToString();
                                string Qnt = r["Quantity"].ToString();
                                string Tot = r["Total"].ToString();
                                string ExD = cmnFuntion.convertDateTime(Convert.ToDateTime(r["ExpDate"].ToString()));
                                int cUser = Program.userDetails.UserID;

                                IsTrue = false;
                                sql = "INSERT INTO tbl_pos_grn_details (GRN_ID, ItemCode, ItemName, BuyingCost, Quantity, Total, ExpDate, cDate, cUser) VALUES ('" + id + "', '" + ICode + "', '" + IName + "', '" + BCost + "', '" + Qnt + "', '" + Tot + "', '" + ExD + "', NOW(), '" + cUser + "');";
                                // stock add
                                sql = sql + "INSERT INTO tbl_pos_stock (ItemID, Description, Date, InStock, OutStock, BuyingCost, ExpDate, cUser) VALUES ('" + ICode + "', '" + GRNInfo.GRNNumber + "', '" + nowDate + "', '" + Qnt + "', 0, '" + BCost + "', '" + ExD + "', '" + cUser + "'); UPDATE tbl_pos_items tpi SET tpi.InStock = tpi.InStock + " + Qnt + " WHERE tpi.ID = '" + ICode + "';";
                                MySqlCommand cmmd = new MySqlCommand(sql, con, trans);
                                cmmd.ExecuteNonQuery();
                                cmmd.Cancel();
                                IsTrue = true;
                            }
                        }
                        if (Method == "Cash" || Method == "Credit")
                        {
                            if (GRNInfo.Amount > 0)
                            {
                                IsTrue = false;
                                sql = "INSERT INTO tbl_pos_cash_book (Description, Credit, Debit, cUser, cDate) VALUES (@description, 0, @payAmt, @cUser, '" + nowDate + "');";
                                MySqlCommand cmd1 = new MySqlCommand(sql, con, trans);
                                string description = "Purchased stock  (" + GRNInfo.GRNNumber + ")";
                                cmd1.Parameters.Add("@description", description);
                                cmd1.Parameters.Add("@payAmt", GRNInfo.Amount);
                                cmd1.Parameters.Add("@cUser", Program.userDetails.UserID);
                                cmd1.ExecuteNonQuery();
                                IsTrue = true;
                            }
                        }
                        else if (Method == "Cheques")
                        {
                            IsTrue = false;
                            sql = "INSERT INTO tbl_pos_cheques (Description, ChequesNo, ChequesDate, Income, Expense, cUser, cDate) VALUES (@description, @chequesNumber, @chequesDate, 0, @payAmt, @cUser, '" + nowDate + "');";
                            MySqlCommand cmd2 = new MySqlCommand(sql, con, trans);
                            string description = "Purchased stock  (" + GRNInfo.GRNNumber + ")";
                            cmd2.Parameters.Add("@description", description);
                            cmd2.Parameters.Add("@chequesNumber", GRNInfo.ChequesNumber);
                            cmd2.Parameters.Add("@chequesDate", cmnFuntion.convertDateTime(Convert.ToDateTime(GRNInfo.ChequesDate.ToString())));
                            cmd2.Parameters.Add("@payAmt", GRNInfo.Amount);
                            cmd2.Parameters.Add("@cUser", Program.userDetails.UserID);
                            cmd2.ExecuteNonQuery();
                            IsTrue = true;
                        }
                        if (Method == "Credit")
                        {
                            IsTrue = false;
                            sql = "INSERT INTO tbl_pos_suppliers_info (SupID, Description, Debit, Credit, cUser, cDate) VALUES (@suoID, @description, 0, @payAmt, @cUser, '" + nowDate + "');";
                            MySqlCommand cmd3 = new MySqlCommand(sql, con, trans);
                            string description = "Purchased stock  (" + GRNInfo.GRNNumber + ")";
                            cmd3.Parameters.Add("@description", description);
                            cmd3.Parameters.Add("@suoID", GRNInfo.SupplirtID);
                            cmd3.Parameters.Add("@payAmt", GRNInfo.Total - GRNInfo.Amount);
                            cmd3.Parameters.Add("@cUser", Program.userDetails.UserID);
                            cmd3.ExecuteNonQuery();
                            IsTrue = true;
                        }
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
                if (IsTrue)
                {
                    trans.Commit();
                }
                else
                {
                    trans.Rollback();
                }
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsTrue;
        }
    }
}
