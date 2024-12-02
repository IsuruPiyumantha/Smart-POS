using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Controler
{
    public class BaseControler
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        public static string ErrorMessage { set; get; }

        public static DataSet FillDataSet(string select)
        {
            ErrorMessage = null;
            DataSet dataset = new DataSet();
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                MySqlCommand cmd = new MySqlCommand(select, con);
                cmd.CommandTimeout = 1800;
                MySqlDataAdapter data_adapter = new MySqlDataAdapter(cmd);
                data_adapter.Fill(dataset);
                con.Close();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                ErrorForm errorFrm = new ErrorForm(e.Message, select);
                errorFrm.ShowDialog();
            }
            return dataset;

        }


        public static int InsertUpdateNonQueryAndReturnIndex(string sql)
        {
            bool status = false;
            int id = 0;
            try
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);
                MySqlCommand command = new MySqlCommand(sql, con);
                id =  command.ExecuteNonQuery();
                id = int.Parse(command.LastInsertedId.ToString());
                // if (rowAffected > 0)
                status = true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                status = false;
            }
            catch (Exception e)
            {
                status = false;
                ErrorMessage = e.Message;
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }

            return id;
        }

        public static int ReturnAndExecuteNonQuery(string sql)
        {
            int id = 0;
            try
            {
                conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            con.Open();
            MySqlCommand command = new MySqlCommand(sql, con);

            id = int.Parse(command.ExecuteScalar().ToString());

            con.Close();

            return id;

            }

            catch (Exception e)
            {
                //ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                //errorFrm.ShowDialog();
                id = 0;
            }
            return id;
        }

    }
}
