using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.ReportFrom
{
    public class ReportControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private CommonFuntion cmnFuntion;

        internal DataTable GetAllStock()
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
                        sqlUser = "SELECT tpi.*,tpu.*,tps.SuppliersName FROM tbl_pos_items tpi INNER JOIN tbl_pos_units tpu ON tpi.unit = tpu.ID INNER JOIN tbl_pos_suppliers tps ON tpi.supplier = tps.ID; ";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];

                        if (Program.companyProfile.IsEnglish == false)
                        {
                            dt1.Columns.Remove("item_name");
                            dt1.Columns["item_name_sinhala"].ColumnName = "item_name";
                        }
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
                MessageBox.Show(e.Message);
            }
            return dt1;
        }
    }
}
