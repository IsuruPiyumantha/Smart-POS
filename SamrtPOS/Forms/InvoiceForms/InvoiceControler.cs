using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.InvoiceForms
{
    public class InvoiceControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;



        internal bool CancelInvoice(string id)
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
                        sql = "UPDATE tbl_pos_invoice_details tpid SET tpid.Status = 'Cancel' WHERE tpid.ID = @id;";
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
    }
}
