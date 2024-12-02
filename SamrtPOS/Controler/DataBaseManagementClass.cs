using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Controler
{
    public class DataBaseManagementClass
    {
        public bool changeRootPasswords(string pwd)
        {
            String my_con = "Host=localhost; UserName=root; Port=3306;  Password=" + pwd + " ;Database=mysql;";
            MySqlConnection con = new MySqlConnection(my_con);
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("SET PASSWORD FOR root@localhost=PASSWORD('Msdh@7#8');", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool selectDataBase()
        {
            String my_con = "Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=mysql;";
            MySqlConnection con = new MySqlConnection(my_con);
            try
            {
                DataSet ds = new DataSet();
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("show databases;", con);
                MySqlDataAdapter data_adapter = new MySqlDataAdapter(cmd);
                data_adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string dbname = "smart_pos_database";
                    int a = 0;
                    foreach (DataRow r in dt.Rows)
                    {
                        if (r["Database"].ToString() == dbname)
                        {
                            a = 1;
                            break;
                        }
                    }
                    if (a == 1)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool createDatabase()
        {
            String my_con = "Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=mysql;";
            MySqlConnection con = new MySqlConnection(my_con);
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();
                }
                MySqlCommand cmd = new MySqlCommand("create database smart_pos_database;", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }
        }

        public bool insertBackUps(string path)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Program.ConnectionString);
                MySqlCommand cmd = new MySqlCommand("source '" + path + "';", con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
