using MySql.Data.MySqlClient;
using SmartPOS.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Controler
{
    public class TbaleManagerControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;


        internal List<AllTableInfo> SelectAllTable(int p)
        {
            List<AllTableInfo> AllTBLinfo = new List<AllTableInfo>();

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt1 = new DataTable();
            string sqlUser = "";

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sqlUser = "SELECT * FROM tbl_pos_tables tpt ORDER BY tpt.TableName;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                AllTableInfo tableInfo = new AllTableInfo();

                                tableInfo.ID = int.Parse(r["ID"].ToString());
                                tableInfo.TableName = r["TableName"].ToString();
                                tableInfo.TableCode = r["TableCode"].ToString();
                                int True = int.Parse(r["TableIsUse"].ToString());
                                tableInfo.IsUse = Convert.ToBoolean(True);

                                AllTBLinfo.Add(tableInfo);
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sqlUser);
                errorFrm.ShowDialog();
            }



            return AllTBLinfo;
        }


        public bool AddNewTable(string name,string code)
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
                        string sql = "INSERT INTO tbl_pos_tables (TableName, TableCode)VALUES (@name, @code);";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@name", name);
                        cmd.Parameters.Add("@code", code);
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


        public bool DeleteTable(string id)
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
                        string sql = "DELETE FROM tbl_pos_tables WHERE ID = @id;";
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

        internal AllTableInfo GetTableInfo(string id)
        {
            AllTableInfo tableInfo = new AllTableInfo();

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
                        sqlUser = "SELECT * FROM tbl_pos_tables tpt WHERE tpt.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                tableInfo.ID = int.Parse(r["ID"].ToString());
                                tableInfo.TableName = r["TableName"].ToString();
                                tableInfo.TableCode = r["TableCode"].ToString();
                                int True = int.Parse(r["TableIsUse"].ToString());
                                tableInfo.IsUse = Convert.ToBoolean(True);
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }



            return tableInfo;
        }

        internal bool UpdateTableInfo(AllTableInfo tblInfo)
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
                        string sql = "UPDATE tbl_pos_tables tpt SET tpt.TableName = @name,tpt.TableCode = @code,tpt.TableIsUse = @isUse WHERE tpt.ID = @id;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@id", tblInfo.ID);
                        cmd.Parameters.Add("@name", tblInfo.TableName);
                        cmd.Parameters.Add("@code", tblInfo.TableCode);
                        cmd.Parameters.Add("@isUse", Convert.ToInt16(tblInfo.IsUse));
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

        internal List<AllTableInfo> UpdateSelectAllTable(string ButtonName,int IsUse)
        {
            List<AllTableInfo> AllTBLinfo = new List<AllTableInfo>();

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt1 = new DataTable();
            string sqlUser = "";
            string UpdateSql = string.Empty;
            bool IsTrue = false;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {

                        UpdateSql = "UPDATE tbl_pos_tables SET TableIsUse = '" + IsUse + "' WHERE TableName = '" + ButtonName + "';"; //,InvID = 0
                        MySqlCommand cmd = new MySqlCommand(UpdateSql, con);
                        cmd.ExecuteNonQuery();
                        IsTrue = true;

                        if (IsTrue)
                        {
                            sqlUser = "SELECT * FROM tbl_pos_tables tpt ORDER BY tpt.TableName;";
                            MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "userDT");
                            dt1 = ds.Tables["userDT"];


                            if (dt1.Rows.Count > 0)
                            {
                                foreach (DataRow r in dt1.Rows)
                                {
                                    AllTableInfo tableInfo = new AllTableInfo();

                                    tableInfo.ID = int.Parse(r["ID"].ToString());
                                    tableInfo.TableName = r["TableName"].ToString();
                                    tableInfo.TableCode = r["TableCode"].ToString();
                                    int True = int.Parse(r["TableIsUse"].ToString());
                                    tableInfo.IsUse = Convert.ToBoolean(True);

                                    AllTBLinfo.Add(tableInfo);
                                }
                            }
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
                ErrorForm errorFrm = new ErrorForm(e.Message, sqlUser);
                errorFrm.ShowDialog();
            }



            return AllTBLinfo;
        }

        internal AllTableInfo getTableDate(Button b)
        {
            AllTableInfo getData = new AllTableInfo();

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt1 = new DataTable();
            string sql = string.Empty;
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT * FROM tbl_pos_tables tpt WHERE tpt.TableName = '" + b.Text + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                getData.ID = int.Parse(r["ID"].ToString());
                                getData.TableName = r["TableName"].ToString();
                                getData.TableCode = r["TableCode"].ToString();
                                int True = int.Parse(r["TableIsUse"].ToString());
                                getData.IsUse = Convert.ToBoolean(True);
                                getData.InvID = int.Parse(r["InvID"].ToString());
                            }
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
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }

            return getData;
        }

        internal bool UpdateTableDetails(string tableName)
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
                        string sql = "UPDATE tbl_pos_tables tpt SET tpt.TableIsUse = 0, tpt.InvID = 0 WHERE tpt.TableName = @tableName;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@tableName", tableName);
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
    }
}
