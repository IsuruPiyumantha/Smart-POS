using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SupperMarketForms
{
    public class SupperMarketProductControler : BaseControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public static string ErrorMessage { set; get; }

        internal bool AddNewSupperMarketProduct(SupperMarketProductInfo prodInfo)
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
                        sql = "INSERT INTO tbl_pos_items (ID, item_name, item_name_sinhala, barcode, barcode2, barcode3, unit, labled_price, special_price, wholesale_price, buying_cost, Category, supplier) VALUES (@itemCode, @itemName, @itemNameSinhala, @barcode, @barcode2, @barcode3, @unit, @labledPrice,@spePrice, @wholPrice, @buyingCost, @category, @supplier);";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@itemCode", prodInfo.ItemCode);
                        cmd.Parameters.Add("@itemName", prodInfo.ItemName);
                        cmd.Parameters.Add("@itemNameSinhala", prodInfo.ItemNameSinhala);
                        cmd.Parameters.Add("@barcode", prodInfo.BarCode);
                        cmd.Parameters.Add("@barcode2", prodInfo.BarCode2);
                        cmd.Parameters.Add("@barcode3", prodInfo.BarCode3);
                        cmd.Parameters.Add("@unit", prodInfo.Unit);
                        cmd.Parameters.Add("@labledPrice", prodInfo.LabledPrice);
                        cmd.Parameters.Add("@spePrice", prodInfo.SpeciaPrice);
                        cmd.Parameters.Add("@wholPrice", prodInfo.WholesalePrice);
                        cmd.Parameters.Add("@buyingCost", prodInfo.BuyingCost);
                        cmd.Parameters.Add("@category", prodInfo.Category);
                        cmd.Parameters.Add("@supplier", prodInfo.Supplier);
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

        internal DataTable GetAllUnit()
        {
            string sql = "SELECT * FROM tbl_pos_units tpu;";
            DataTable dt = FillDataSet(sql).Tables[0];
            return dt;
        }

        internal DataTable GetAllCategory()
        {
            string sql = "SELECT * FROM tbl_pos_item_category tpic;";
            DataTable dt = FillDataSet(sql).Tables[0];
            return dt;
        }

        internal int GetItemCode()
        {
            int id = 0;
            string sql = "SELECT MAX(tpi.ID) FROM tbl_pos_items tpi;";
            id = ReturnAndExecuteNonQuery(sql);
            return id;
        }

        internal bool DeleteProduct(string x)
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
                        string sql = "DELETE FROM tbl_pos_items WHERE ID = @id;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@id", x);
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

        internal SupperMarketProductInfo GetRestaurantProductInfo(string id)
        {
            SupperMarketProductInfo getInfo = new SupperMarketProductInfo();

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
                        sqlUser = "SELECT * FROM tbl_pos_items tpt WHERE tpt.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                getInfo.ItemCode = r["ID"].ToString();
                                getInfo.ItemName = r["item_name"].ToString();
                                getInfo.Unit = int.Parse(r["unit"].ToString());
                                getInfo.LabledPrice = decimal.Parse(r["labled_price"].ToString());
                                getInfo.BuyingCost = decimal.Parse(r["labled_price"].ToString());
                                getInfo.Category = int.Parse(r["Category"].ToString());
                                getInfo.SupplierName = r["supplier"].ToString();
                                int kot = int.Parse(r["kot_item"].ToString());
                                getInfo.BarCode = r["barcode"].ToString();
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



            return getInfo;
        }

        internal bool UpdateRestaurantProduct(SupperMarketProductInfo prodInfo)
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
                        string sql = "UPDATE tbl_pos_items tpi SET tpi.item_name=@itemName, tpi.unit=@unit, tpi.barcode.@barcode , tpi.labled_price=@labledPrice, tpi.buying_cost=@buyingCost, tpi.Category=@category, tpi.supplier=@supplier, tpi.kot_item=@kot WHERE tpi.ID=@itemCode; ";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@itemCode", prodInfo.ItemCode);
                        cmd.Parameters.Add("@itemName", prodInfo.ItemName);
                        cmd.Parameters.Add("@barcode", prodInfo.BarCode);
                        cmd.Parameters.Add("@unit", prodInfo.Unit);
                        cmd.Parameters.Add("@labledPrice", prodInfo.LabledPrice);
                        cmd.Parameters.Add("@buyingCost", prodInfo.BuyingCost);
                        cmd.Parameters.Add("@category", prodInfo.Category);
                        cmd.Parameters.Add("@supplier", prodInfo.SupplierName);
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

        internal void InsertKOTtable(DataTable dt1, string InvoiceNo, string TableName)
        {
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

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                string itemcode = r["ID"].ToString();
                                string itemName = r["item_name"].ToString();
                                string Qnt = r["quantity"].ToString();

                                sql = "INSERT INTO tbl_pos_kot_print (InvNumber, TableName, ItemCode, ItemName, Qnt, cUser, cDate) VALUES ('" + InvoiceNo + "', '" + TableName + "', '" + itemcode + "', '" + itemName + "', '" + Qnt + "', '" + Program.userDetails.UserID + "', NOW());";
                                MySqlCommand cmd = new MySqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                            }
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
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        internal bool SaveSoldOutItems(int invoiceID,string status, DataTable dt)
        {
            bool isSuccess = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sql = string.Empty;
            int cUser = Program.userDetails.UserID;

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

                            sql = "UPDATE tbl_pos_restaurant_sales tprs SET tprs.Status = '" + status + "' WHERE tprs.InvoiceID = '" + invoiceID + "' AND tprs.ItemsCode = '" + itemCode + "' AND tprs.Status = 'pending';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.ExecuteNonQuery();
                            isSuccess = true;
                        }
                    }
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                isSuccess = false;
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }

            return isSuccess;
        }

        internal bool SupperMarketProduct(string id)
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
                        sql = "DELETE FROM tbl_pos_items WHERE ID = @id;";
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

        internal SupperMarketProductInfo SelectProductInfo(string id)
        {
            SupperMarketProductInfo ProductInfo = new SupperMarketProductInfo();

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
                        sql = "SELECT * FROM tbl_pos_items tpi WHERE tpi.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                ProductInfo.ItemCode = r["ID"].ToString();
                                ProductInfo.ItemName = r["item_name"].ToString();
                                ProductInfo.ItemNameSinhala = r["item_name_sinhala"].ToString();
                                ProductInfo.Unit = int.Parse(r["unit"].ToString());
                                ProductInfo.LabledPrice = decimal.Parse(r["labled_price"].ToString());
                                ProductInfo.SpeciaPrice = decimal.Parse(r["special_price"].ToString());
                                ProductInfo.WholesalePrice = decimal.Parse(r["wholesale_price"].ToString());
                                ProductInfo.BuyingCost = decimal.Parse(r["buying_cost"].ToString());
                                ProductInfo.Category = int.Parse(r["Category"].ToString());
                                ProductInfo.Supplier = int.Parse(r["supplier"].ToString());
                                ProductInfo.BarCode = r["barcode"].ToString();
                                ProductInfo.BarCode2 = r["barcode2"].ToString();
                                ProductInfo.BarCode3 = r["barcode3"].ToString();
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
            return ProductInfo;
        }

        internal bool EditSupperMarketProduct(SupperMarketProductInfo prodInfo)
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
                        sql = "UPDATE tbl_pos_items tpi SET tpi.item_name =@itemName, tpi.item_name_sinhala =@itemNameSinhala, tpi.unit =@unit, tpi.labled_price =@labledPrice, tpi.special_price =@spePrice, tpi.wholesale_price =@wholPrice, tpi.buying_cost =@buyingCost, tpi.Category =@category, tpi.supplier =@supplier, tpi.barcode =@barcode, tpi.barcode2 =@barcode2, tpi.barcode3 =@barcode3 WHERE tpi.ID =@itemCode;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@itemCode", prodInfo.ItemCode);
                        cmd.Parameters.Add("@itemName", prodInfo.ItemName);
                        cmd.Parameters.Add("@itemNameSinhala", prodInfo.ItemNameSinhala);
                        cmd.Parameters.Add("@barcode", prodInfo.BarCode);
                        cmd.Parameters.Add("@barcode2", prodInfo.BarCode2);
                        cmd.Parameters.Add("@barcode3", prodInfo.BarCode3);
                        cmd.Parameters.Add("@unit", prodInfo.Unit);
                        cmd.Parameters.Add("@labledPrice", prodInfo.LabledPrice);
                        cmd.Parameters.Add("@spePrice", prodInfo.SpeciaPrice);
                        cmd.Parameters.Add("@wholPrice", prodInfo.WholesalePrice);
                        cmd.Parameters.Add("@buyingCost", prodInfo.BuyingCost);
                        cmd.Parameters.Add("@category", prodInfo.Category);
                        cmd.Parameters.Add("@supplier", prodInfo.Supplier);
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

        internal DataTable GetAllSupplier()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            DataTable Supp = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT ID,SuppliersName FROM tbl_pos_suppliers;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        Supp = ds.Tables["itemDT"];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return Supp;
        }
    }
}
