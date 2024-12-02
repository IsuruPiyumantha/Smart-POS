using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms
{
    public class SalesControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private CommonFuntion cmnFuntion;

        internal DataTable SelectItemsForCategoryID(string id)
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable itemsTable = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_items tpi WHERE tpi.Category = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        itemsTable = ds.Tables["itemDT"];
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
            return itemsTable;
        }

        internal InvoiceInfo GetInvoiceInfo()
        {
            InvoiceInfo GetInfo = new InvoiceInfo();

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
                        sql = "SELECT * FROM tbl_pos_index tbi;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "GetInfo");
                        dt1 = ds.Tables["GetInfo"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                GetInfo.InvCode = r["InvoiceCode"].ToString();
                                GetInfo.InvNumber = int.Parse(r["InvoiceNumber"].ToString());
                                GetInfo.InvDate = r["InvoiceDate"].ToString();
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
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return GetInfo;
        }

        internal bool UpdateNextInvoiceNumber(int invoiceNo, string InvoiceCode,bool IsClose)
        {
            bool state = false;
            int NewInvoiceNo = 0;
            if (!IsClose)
            {
                NewInvoiceNo = invoiceNo + 1;
            }
            else
            {
                NewInvoiceNo = invoiceNo;
            }
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_pos_index tpi SET tpi.InvoiceNumber = '" + NewInvoiceNo + "' WHERE tpi.InvoiceCode = '" + InvoiceCode + "';", con);
                cmd.ExecuteNonQuery();
                cmd.Cancel();
                state = true;
            }
            catch (Exception e)
            {
                state = false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return state;
        }

        internal bool UpdateInvoiceDate(ref InvoiceInfo invoiceInfo,string newInvoiceDate)
        {
            bool state = false;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE tbl_pos_index tpi SET tpi.InvoiceDate = '" + newInvoiceDate + "',tpi.InvoiceNumber = '1' WHERE tpi.InvoiceCode = '" + invoiceInfo.InvCode + "'; ", con);
                cmd.ExecuteNonQuery();
                state = true;
                invoiceInfo.InvNumber = 1;
                cmd.Cancel();
                
            }
            catch (Exception e)
            {
                state = false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return state;
        }

        internal int insertNewInvoiceDetails(string InvoiceNo,string BottonText)
        {
            cmnFuntion = new CommonFuntion();
            int id = 0;
            string sql = string.Empty;
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            int cUser = Program.userDetails.UserID;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "INSERT INTO tbl_pos_invoice_details (InvNumber, cDate, cUser, Status) VALUES ('" + InvoiceNo + "', '" + nowDate + "', '" + cUser + "', 'pendig');";
                MySqlCommand command = new MySqlCommand(sql, con);
                command.ExecuteNonQuery();
                id = int.Parse(command.LastInsertedId.ToString());

                if (id > 0)
                {
                    MySqlCommand cmd = new MySqlCommand("UPDATE tbl_pos_tables tpt SET tpt.InvID = '" + id + "' WHERE tpt.TableName = '" + BottonText + "';", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                ErrorForm errorFrm = new ErrorForm(ex.Message, sql);
                errorFrm.ShowDialog();
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
            return id;
        }

        internal InvoiceBillDetails getOldInvoiceNo(int InvoiceID)
        {
            InvoiceBillDetails invoiceDetils = new InvoiceBillDetails();

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
                        sql = "SELECT tpid.* FROM tbl_pos_invoice_details tpid WHERE tpid.ID = '" + InvoiceID + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "GetInfo");
                        dt1 = ds.Tables["GetInfo"];

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                invoiceDetils.InvoiceID = InvoiceID;
                                invoiceDetils.InvoiceNumber = r["InvNumber"].ToString();
                                int SC = int.Parse(r["IsServiceChg"].ToString());
                                invoiceDetils.AddServiceChg = Convert.ToBoolean(SC);
                                int CP = int.Parse(r["IsCardFee"].ToString());
                                invoiceDetils.AddCardPaymentFee = Convert.ToBoolean(CP);
                                int TAX = int.Parse(r["IsTAX"].ToString());
                                invoiceDetils.AddTAX = Convert.ToBoolean(TAX);
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
            return invoiceDetils;
        }

        internal DataTable getSalesDetails(int InvoiceID)
        {
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
                        sql = "SELECT tprs.ItemsCode AS ID, tprs.ItemsName AS item_name, tprs.Price AS labled_price, SUM(tprs.Quantity) AS quantity, SUM(tprs.TotalPrice) AS total_price, tprs.KOT FROM tbl_pos_restaurant_sales tprs WHERE tprs.InvoiceID = '" + InvoiceID + "' AND tprs.Status = 'pending' GROUP BY tprs.ItemsCode;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "GetInfo");
                        dt1 = ds.Tables["GetInfo"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
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
            return dt1;
        
        }

        internal DataTable GetAllCategory()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_item_category tpic;";
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

        internal DataTable GetAllItems()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_items tpi;";
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

        internal void getServiceCharge(ref InvoiceBillDetails invoiceDetails)
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_system_setting tpss;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "DT");
                        dt = ds.Tables["DT"];

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt.Rows)
                            {
                                if (r["ObjName"].ToString() == "Service Charge")
                                {
                                    invoiceDetails.ServiePer = Convert.ToDecimal(r["ObjValue"].ToString());
                                }
                                if (r["ObjName"].ToString() == "Card Payment Fee")
                                {
                                    invoiceDetails.CardPer = Convert.ToDecimal(r["ObjValue"].ToString());
                                }
                                if (r["ObjName"].ToString() == "TAX")
                                {
                                    invoiceDetails.TAXPer = Convert.ToDecimal(r["ObjValue"].ToString());
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
        }

        internal bool UpdateInvoicePayment(InvoiceBillDetails invoiceDetails,string Status, string PayMethod)
        {
            cmnFuntion = new CommonFuntion();
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            int uUser = Program.userDetails.UserID;
            bool status = false;
            string sql = string.Empty;
            
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                con.Open();
                sql = "UPDATE tbl_pos_invoice_details tpid SET tpid.SubTotal ='" + invoiceDetails.SubTotalAmount + "', tpid.ServiceChg = '" + invoiceDetails.ServiceCharge + "', tpid.CardFee = '" + invoiceDetails.CardPaymentFee + "', tpid.TAX = '" + invoiceDetails.TAX + "', tpid.NetTotal = '" + invoiceDetails.NetTotalAmount + "', tpid.Discount = '" + invoiceDetails.DiscountAmount + "',";
                sql = sql + " tpid.InvoiceAmount ='" + invoiceDetails.TotalAmount + "', tpid.InvoicePayAmount='" + invoiceDetails.PayAmount + "', tpid.InvoiceBalAmount='" + invoiceDetails.BalenceAmoun + "', tpid.Status = '" + Status + "', tpid.PayMethod = '" + PayMethod + "', uDate = '" + nowDate + "', uUser = '" + uUser + "' WHERE tpid.ID = '" + invoiceDetails.InvoiceID + "';";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                status = true;

            }
            catch (MySqlException ex)
            {
                con.Close();
                if (ex.Number == 1062)
                    status = false;
                ErrorForm errorFrm = new ErrorForm(ex.Message, sql);
                errorFrm.ShowDialog();
            }
            catch (Exception e)
            {
                con.Close();
                status = false;
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
            return status;
        }

        internal bool InvoiceInvoiceDetails(ref InvoiceBillDetails invoiceDetails, string PayMethod)
        {
            bool isSuccess = false;

            cmnFuntion = new CommonFuntion();
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            int cUser = Program.userDetails.UserID;

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
                        sql = "INSERT INTO tbl_pos_invoice_details (InvNumber, SubTotal, ServiceChg, CardFee, TAX, NetTotal, Discount, InvoiceAmount, InvoicePayAmount, InvoiceBalAmount, PayMethod, cDate, cUser, Status) VALUES ";
                        sql = sql + "('" + invoiceDetails.InvoiceNumber + "', '" + invoiceDetails.SubTotalAmount + "', 0, '" + invoiceDetails.CardPaymentFee + "', '" + invoiceDetails.TAX + "', '" + invoiceDetails.NetTotalAmount + "', '" + invoiceDetails.DiscountAmount + "', '" + invoiceDetails.TotalAmount + "', '" + invoiceDetails.PayAmount + "', '" + invoiceDetails.BalenceAmoun + "', '" + PayMethod + "', '" + nowDate + "', '" + cUser + "', 'Complete');";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        invoiceDetails.InvoiceID = cmd.ExecuteNonQuery();
                        invoiceDetails.InvoiceID = int.Parse(cmd.LastInsertedId.ToString());
                        isSuccess = true;
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
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

            return isSuccess;
        }

        internal bool SaveSupperMarketItems(int invoiceID, DataTable dt)
        {
            bool isSuccess = false;

            CommonFuntion cmnFuntion = new CommonFuntion();
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            int cUser = Program.userDetails.UserID;

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
                        foreach (DataRow r in dt.Rows)
                        {
                            int itemCode = int.Parse(r["ID"].ToString());
                            string itemName = r["item_name"].ToString();
                            string lablePrice = r["labled_price"].ToString();
                            string specialPrice = r["special_price"].ToString();
                            string quantity = r["quantity"].ToString();
                            string totalPrice = r["total_price"].ToString();

                            sql = "INSERT INTO tbl_pos_supper_market_sales(InvoiceID, ItemCode, ItemName, LabledPrice, SpecialPrice, Quantity, TotalPrice, cDate, cUser) VALUES('" + invoiceID + "','" + itemCode + "','" + itemName + "','" + lablePrice + "','" + specialPrice + "','" + quantity + "','" + totalPrice + "','" + nowDate + "','" + cUser + "');";
                            sql = sql + "UPDATE tbl_pos_items tpi SET tpi.InStock = tpi.InStock - " + quantity + " WHERE tpi.ID = '" + itemCode + "';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                            isSuccess = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
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

            return isSuccess;
        }

        internal void UpdateInviceDetils(string ChageName, InvoiceBillDetails invoiceDetils)
        {
            CommonFuntion cmnFuntion = new CommonFuntion();
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
                        if (ChageName == "SC")
                        {
                            sql = "UPDATE tbl_pos_invoice_details tpid SET tpid.IsServiceChg = @isTrue WHERE tpid.ID = '" + invoiceDetils.InvoiceID + "';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@isTrue", Convert.ToInt16(invoiceDetils.AddServiceChg));
                            cmd.ExecuteNonQuery();
                        }
                        if (ChageName == "CP")
                        {
                            sql = "UPDATE tbl_pos_invoice_details tpid SET tpid.IsCardFee = @isTrue WHERE tpid.ID = '" + invoiceDetils.InvoiceID + "';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@isTrue", Convert.ToInt16(invoiceDetils.AddCardPaymentFee));
                            cmd.ExecuteNonQuery();
                        }
                        if (ChageName == "CP")
                        {
                            sql = "UPDATE tbl_pos_invoice_details tpid SET tpid.IsTAX = @isTrue WHERE tpid.ID = '" + invoiceDetils.InvoiceID + "';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@isTrue", Convert.ToInt16(invoiceDetils.AddTAX));
                            cmd.ExecuteNonQuery();
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
        }
    }
}
