using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.UserForms
{
    public class UserControler: BaseControler
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion cmnFuntion;
    
        internal int GetUserCode()
        {
            int id = 0;
            string sql = "SELECT MAX(tpu.ID) FROM tbl_pos_user tpu";
            id = ReturnAndExecuteNonQuery(sql);
            return id;
        }

        internal DataTable GetAllJobRole()
        {
            string sql = "SELECT * FROM tbl_pos_role;";
            DataTable dt = FillDataSet(sql).Tables[0];
            return dt;
        }

        internal bool AddNewUser(UserInfo UserInfo)
        {
            cmnFuntion = new CommonFuntion();
            bool IsTrue = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            string sql = string.Empty;
            string nowDate = cmnFuntion.convertDateTime(DateTime.Now);
            int UserId = int.Parse(Program.userDetails.UserID.ToString());

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "INSERT INTO tbl_pos_user (ID, FullName, UserName, Password, MobileNo, Email, Active, RoleID, cUser, cDate) VALUES (@Code, @fullName, @userName, @password, @mobileNo, @email, 1, @role, '" + UserId + "', '" + nowDate + "');";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@Code", UserInfo.UserID);
                        cmd.Parameters.Add("@fullName", UserInfo.FullName);
                        cmd.Parameters.Add("@userName", UserInfo.UseryName);
                        cmd.Parameters.Add("@password", UserInfo.Password);
                        cmd.Parameters.Add("@mobileNo", UserInfo.MobileNo);
                        cmd.Parameters.Add("@email", UserInfo.Email);
                        cmd.Parameters.Add("@role", UserInfo.JobRole);
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

        internal bool DeleteUser(string id)
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
                        sql = "DELETE FROM tbl_pos_user WHERE ID = @id;";
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

        internal UserInfo SelectUserInfo(string id)
        {
            UserInfo UserInfo = new UserInfo();

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
                        sql = "SELECT * FROM tbl_pos_user tpu WHERE tpu.ID = '" + id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                UserInfo.UserID = int.Parse(r["ID"].ToString());
                                UserInfo.FullName = r["FullName"].ToString();
                                UserInfo.UseryName = r["UserName"].ToString();
                                UserInfo.Password = r["Password"].ToString();
                                UserInfo.MobileNo = r["MobileNo"].ToString();
                                UserInfo.Email = r["Email"].ToString();
                                int active = Convert.ToInt16(r["Active"].ToString());
                                UserInfo.Active = Convert.ToBoolean(active);
                                UserInfo.JobRole = int.Parse(r["RoleID"].ToString());
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
            return UserInfo;
        }

        internal bool UpdateUserInfo(UserInfo UserInfo)
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
                        sql = "UPDATE tbl_pos_user tpu SET tpu.FullName = @fullName, tpu.UserName = @userName, tpu.Password = @password, tpu.MobileNo = @mobileNo, tpu.Email = @email, tpu.Active = @active, tpu.RoleID = @role WHERE tpu.ID = @Code;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.Parameters.Add("@Code", UserInfo.UserID);
                        cmd.Parameters.Add("@fullName", UserInfo.FullName);
                        cmd.Parameters.Add("@userName", UserInfo.UseryName);
                        cmd.Parameters.Add("@password", UserInfo.Password);
                        cmd.Parameters.Add("@mobileNo", UserInfo.MobileNo);
                        cmd.Parameters.Add("@email", UserInfo.Email);
                        cmd.Parameters.Add("@active", Convert.ToInt16(UserInfo.Active));
                        cmd.Parameters.Add("@role", UserInfo.JobRole);
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

        internal UserInfo Login(string UserName, string Password)
        {
            UserInfo UserInfo = new UserInfo();
            cmnFuntion = new CommonFuntion();

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
                        sql = "SELECT * FROM tbl_pos_user tpu WHERE tpu.UserName = '" + UserName + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];


                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                int active = Convert.ToInt16(r["Active"].ToString());
                                if (active != 0)
                                {
                                    string DBpassword = r["Password"].ToString();
                                    if (cmnFuntion.PasswordMatch(Password, DBpassword))
                                    {
                                        UserInfo.UserID = int.Parse(r["ID"].ToString());
                                        UserInfo.FullName = r["FullName"].ToString();
                                        UserInfo.UseryName = r["UserName"].ToString();
                                        UserInfo.Password = r["Password"].ToString();
                                        UserInfo.MobileNo = r["MobileNo"].ToString();
                                        UserInfo.Email = r["Email"].ToString();
                                        active = Convert.ToInt16(r["Active"].ToString());
                                        UserInfo.Active = Convert.ToBoolean(active);
                                        UserInfo.JobRole = int.Parse(r["RoleID"].ToString());
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid Password..");
                                        UserInfo = null;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Your Account Is DeActive..");
                                    UserInfo = null;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(" User Name Not Fund..");
                            UserInfo = null;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
                UserInfo = null;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return UserInfo;
        }
    }
}
