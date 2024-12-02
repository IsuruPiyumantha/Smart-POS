using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms.PrintigSetting
{
    public class BillPrintingControler : BaseControler
    {
        public static bool isDuplicate;
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private MySqlTransaction trans;

        internal DataTable LoadDataForBillSettings(string p)
        {
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
                        sqlUser = "SELECT * FROM tbl_pos_bill_printersettings tpbp WHERE tpbp.ObjectName = '" + p + "' ORDER BY tpbp.ID ASC;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return dt1;
        }

        internal bool Save_Bill_Printing_Data_Settings(List<BillMargingInfo> listBillInfo)
        {
            string sql;
            bool flag = false;
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            con.Open();
            trans = con.BeginTransaction();
            try
            {
                if (listBillInfo.Count > 0)
                {
                    foreach (BillMargingInfo billInfo in listBillInfo)
                    {
                        string valueName = billInfo.Value_Name;
                        int leftMargin = billInfo.Left_Margin;
                        int topMargin = billInfo.Top_Margin;
                        int needToPrint = billInfo.Need_To_Print;
                        string objectname = billInfo.Object_Name;
                        int width = billInfo.Width;
                        string labelName = billInfo.Lable_Name;
                        int lbl_LeftMargin = billInfo.Lbl_Left_Margin;
                        int lbl_TopMargin = billInfo.Lbl_Top_Margin;
                        int lbl_Width = billInfo.Lbl_Width;
                        int height = billInfo.Hight;
                        float fsize = billInfo.FontSize;
                        string align = billInfo.Align;
                        string lalign = billInfo.Label_Align;
                        string style = billInfo.FontStyle;


                        sql = "INSERT INTO tbl_pos_bill_printersettings(ObjectName,ValueName,NeedToPrint,LeftMargin,TopMargin,Width, LabelName,LblLeftMargain,LblTopMargin,  LblWidth,Hight,FontSize,FontStyle,FontAlignment,LblFontAlign) VALUES('" + objectname + "','" + valueName + "','" + needToPrint + "','" + leftMargin + "','" + topMargin + "','" + width + "','" + labelName + "','" + lbl_LeftMargin + "','" + lbl_TopMargin + "','" + lbl_Width + "','" + height + "','" + fsize + "','" + billInfo.FontStyle + "','" + align + "','" + lalign + "')";
                        sql = sql + "ON DUPLICATE KEY UPDATE ObjectName='" + objectname + "',ValueName='" + valueName + "',NeedToPrint='" + needToPrint + "',LeftMargin='" + leftMargin + "',TopMargin='" + topMargin + "',Width='" + width + "', LabelName='" + labelName + "',LblLeftMargain='" + lbl_LeftMargin + "', LblTopMargin='" + lbl_TopMargin + "', LblWidth='" + lbl_Width + "',Hight ='" + height + "',FontSize='" + fsize + "',FontStyle='" + billInfo.FontStyle + "',FontAlignment='" + align + "',LblFontAlign='" + lalign + "' ";
                        flag = ExecuteUpdateNonQuery(sql, con, trans);
                        if (!flag)

                            break;

                    }
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (flag)
                    trans.Commit();
                else
                    trans.Rollback();
                con.Close();
            }
            return flag;    
        }

        private bool ExecuteUpdateNonQuery(string sql, MySqlConnection con, MySqlTransaction trans)
        {
            bool status = false;
            try
            {

                MySqlCommand command = new MySqlCommand(sql, con, trans);
                int rowAffected = command.ExecuteNonQuery();
                status = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    isDuplicate = true;
                status = false;
                ErrorMessage = ex.Message;
            }

            return status;
        }

        internal List<BillMargingInfo> LoadBillSetingDataForSelectedObject(string p)
        {
            List<BillMargingInfo> listBillInfo = new List<BillMargingInfo>();
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
                        sqlUser = "SELECT * FROM tbl_pos_bill_printersettings tpbp WHERE tpbp.ObjectName = '" + p + "' ORDER BY tpbp.ID ASC;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                BillMargingInfo billInfo = new BillMargingInfo();
                                billInfo.ID = int.Parse(r["ID"].ToString());
                                billInfo.Value_Name = r["ValueName"].ToString();
                                billInfo.Need_To_Print = int.Parse(r["NeedToPrint"].ToString());
                                billInfo.Left_Margin = int.Parse(r["LeftMargin"].ToString());
                                billInfo.Top_Margin = int.Parse(r["TopMargin"].ToString());
                                billInfo.Width = int.Parse(r["Width"].ToString());
                                billInfo.Lable_Name = r["LabelName"].ToString();
                                billInfo.Lbl_Left_Margin = int.Parse(r["LblLeftMargain"].ToString());
                                billInfo.Lbl_Top_Margin = int.Parse(r["LblTopMargin"].ToString());
                                billInfo.Lbl_Width = int.Parse(r["LblWidth"].ToString());
                                billInfo.FontSize = float.Parse(r["FontSize"].ToString());
                                billInfo.Hight = int.Parse(r["Hight"].ToString());
                                billInfo.FontStyle = r["FontStyle"].ToString();
                                billInfo.Align = r["FontAlignment"].ToString();
                                billInfo.Label_Align = r["LblFontAlign"].ToString();

                                listBillInfo.Add(billInfo);
                            }
                        } 
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return listBillInfo;
        }
    }
}
