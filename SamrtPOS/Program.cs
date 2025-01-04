using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.UserForms;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.ServiceProcess;
using SmartPOS.Forms.SettingsForms;

namespace SmartPOS
{
    static class Program
    {
        public static string ConnectionString = "";
        public static CompanyProfile companyProfile;
        public static UserInfo userDetails;
        public static PrinterInfo printerInfo;
        public static string ServerName = string.Empty;

        public static int dataBaseprocessId = 0;
        private static string serialKey = string.Empty;
        private static string ExpDate = string.Empty;
        private static string Status = string.Empty;
        public static bool IsEng = true;

        public static string col = string.Empty;
        public static string col2 = string.Empty;
        public static string col3 = string.Empty;
        public static string hText = string.Empty;
        public static string Text = string.Empty;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataBaseManagementClass dbMgr = new DataBaseManagementClass();

            if (checkServiceOk())
            {
                if (checkMySQLServerExit())
                {
                    if (setTestingConnection())
                    {
                        if (dbMgr.selectDataBase())
                        {
                            GetColors();
                            finalStep();
                        }
                        else
                            upToImportDataBase();
                    }
                    else
                    {
                        upToPassword();
                    }
                }
                else
                {
                    upToConfiguration();
                }
            }
            else
            {
                Application.Run(new Nekfa.DataBaseInstaller.FirstForm());
                if (dataBaseprocessId > 0)
                {
                    if (dataBaseprocessId == 1)
                    {
                        upToConfiguration();
                    }
                }
                else
                {

                }
            }
        }

        private static void GetColors()
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            string sql = "";
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sql = "SELECT * FROM tbl_pos_colors tpc;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "colors");
                        DataTable dt1 = ds.Tables["colors"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                string pName = r["PanelName"].ToString();
                                if (pName == "col")
                                    col = r["PanelColor"].ToString();
                                else if (pName == "col2")
                                    col2 = r["PanelColor"].ToString();
                                else if (pName == "col3")
                                    col3 = r["PanelColor"].ToString();
                                else if (pName == "hText")
                                    hText = r["PanelColor"].ToString();
                                else if (pName == "Text")
                                    Text = r["PanelColor"].ToString();
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
        }

        private static void upToConfiguration()
        {
            Application.Run(new Nekfa.DataBaseInstaller.DataBaseConfigForm());
            if (dataBaseprocessId == 2 && checkMySQLServerExit() == true)
            {
                upToPassword();
            }
        }

        private static void upToPassword()
        {
            Application.Run(new Nekfa.DataBaseInstaller.PasswordChange());
            if (dataBaseprocessId == 3)
            {
                upToImportDataBase();
            }
        }

        private static void upToImportDataBase()
        {
            DataBaseManagementClass dbMgr = new DataBaseManagementClass();

            if (dbMgr.selectDataBase())
            {
                if (dataBaseprocessId == 4)
                {
                    finalStep();
                }
            }
            else
            {
                Application.Run(new Nekfa.DataBaseInstaller.ImportDataBase());
                if (dataBaseprocessId == 5)
                {
                    finalStep();
                }
            }
        }

        private static void finalStep()
        {
            if (setTestingConnection())
            {
                if (GetCompanyProfile() && GetPrinterInfo())
                {
                    if (CheckExDate())
                    {
                        Application.Run(new Login(IsEng));
                        GetCompanyProfile();
                        if (userDetails != null)
                        {
                            Application.Run(new DashBoard());
                        }
                    }
                    else
                    {
                        Application.Run(new serialKey(companyProfile, serialKey));
                    }
                }
                else
                {
                    Application.Run(new CompanyRegistration());
                }

            }
            else
            {
                MessageBox.Show("Invlid Connectin String");
            }
        }

        private static bool GetPrinterInfo()
        {
            bool Istrue = false;
            printerInfo = new PrinterInfo();
            companyProfile = new CompanyProfile();
            MySqlConnection con = new MySqlConnection(ConnectionString);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_ref_printer_settings tprps;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "printer");
                        DataTable dt1 = ds.Tables["printer"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                if (r["ObjectName"].ToString() == "POS")
                                {
                                    printerInfo.POSprinterName = r["PrinterName"].ToString();
                                    printerInfo.POSpaperSize = r["PaperSize"].ToString();
                                }
                                if (r["ObjectName"].ToString() == "KOT")
                                {
                                    printerInfo.KOTprinterName = r["PrinterName"].ToString();
                                    printerInfo.KOTpaperSize = r["PaperSize"].ToString();
                                }
                            }
                        }
                        Istrue = true;
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
            return Istrue;
        }

        private static bool CheckExDate()
        {
            CommonFuntion comnFuntion = new CommonFuntion();
            bool IsValid = false;

            if (getData())
            {
                if (Status == comnFuntion.Encrypt("2"))
                {
                    IsValid = true;
                }
                else
                {
                    DateTime Nowdate = DateTime.Now;
                    DateTime Expdate = Convert.ToDateTime(comnFuntion.Decrypt(ExpDate));
                    if (Expdate >= Nowdate)
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }

        private static bool getData()
        {
            companyProfile = new CompanyProfile();
            MySqlConnection con = new MySqlConnection(ConnectionString);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_company_profile tpcp; SELECT * FROM tbl_pos_serial_key;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Table");
                        DataTable dt1 = ds.Tables["Table"];
                        DataTable dt2 = ds.Tables["Table1"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                companyProfile.SoftName = r["SoftCompany"].ToString();
                                companyProfile.SoftMobileNo = r["SoftMoboleNo"].ToString();
                            }
                        }

                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt2.Rows)
                            {
                                serialKey = r["SerialKey"].ToString();
                                ExpDate = r["ExDate"].ToString();
                                Status = r["Status"].ToString();
                            }
                        }

                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private static bool checkMySQLServerExit()
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.ServiceName == "MySQL")
                    return true;
            }
            return false;
        }

        public static bool checkServiceOk()
        {
            string path = @"C:\Program Files (x86)\MySQL\MySQL Server 5.0\bin\mysql.exe";
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                string path1 = @"C:\Program Files\MySQL\MySQL Server 5.0\bin\mysql.exe";
                if (File.Exists(path1))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public static bool setTestingConnection()
        {
            ConnectionString = string.Empty;
            String my_con = "Host=localhost; UserName=root; Port=3306;  Password=Msdh@7#8 ;Database=smart_pos_database;CharSet=utf8;";
            ServerConfigureInfo serverConfigInfo = new ServerConfigureInfo();
            MySqlConnection con = new MySqlConnection(my_con);
            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_database tpd;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        DataTable dt1 = ds.Tables["userDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                serverConfigInfo.hostName = r["Host"].ToString();
                                serverConfigInfo.userName = r["UserName"].ToString();
                                serverConfigInfo.password = r["Password"].ToString();
                                serverConfigInfo.database = r["DatabaseName"].ToString();
                                serverConfigInfo.type = int.Parse(r["Type"].ToString());
                            }
                            ServerName = serverConfigInfo.hostName;
                            ConnectionString = "Host='" + serverConfigInfo.hostName + "'; UserName='" + serverConfigInfo.userName + "'; Port=3306;  Password='" + serverConfigInfo.password + "';Database='" + serverConfigInfo.database + "';CharSet=utf8;";
                        }
                    }
                    return true;
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public static bool GetCompanyProfile()
        {
            companyProfile = new CompanyProfile();
            MySqlConnection con = new MySqlConnection(ConnectionString);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_company_profile tpcp;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "companyProfile");
                        DataTable dt1 = ds.Tables["companyProfile"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                companyProfile.ID = int.Parse(r["ID"].ToString());
                                companyProfile.CompanyName = r["CompanyName"].ToString();
                                companyProfile.Address = r["Address"].ToString();
                                companyProfile.MobileNo = r["MobileNo"].ToString();
                                companyProfile.Email = r["Email"].ToString();
                                companyProfile.Catogery = r["CatgoryName"].ToString();
                                companyProfile.CatID = int.Parse(r["CatgoryID"].ToString());
                                companyProfile.SoftName = r["SoftCompany"].ToString();
                                companyProfile.SoftMobileNo = r["SoftMoboleNo"].ToString();
                                int a = int.Parse(r["IsEnglish"].ToString());
                                if (a == 0)
                                {
                                    companyProfile.IsEnglish = true;
                                    IsEng = true;
                                }
                                else
                                {
                                    companyProfile.IsEnglish = false;
                                    IsEng = false;
                                }

                                return true;
                            }
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
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
