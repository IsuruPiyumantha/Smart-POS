using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SmartPOS.Controler
{
    public class CommonFuntion
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        // Valid Decimal Number 
        public bool IsValidDecimalNo(string strValue)
        {
            bool IsValid = false;
            try
            {
                if (strValue.Contains(".") == true)
                {

                    int intEndIndex = strValue.Trim().IndexOf('.');
                    string strFirst = strValue.Substring(0, intEndIndex).Trim();
                    string strSecond = strValue.Substring(intEndIndex + 1).Trim();

                    if (ValidatePhoneNoDigits(strFirst) == false || ValidatePhoneNoDigits(strSecond) == false)
                    {
                        IsValid = false;
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
                else
                {
                    if (ValidatePhoneNoDigits(strValue) == false)
                    {
                        IsValid = false;
                    }
                    else
                    {
                        IsValid = true;
                    }
                }

            }
            catch (Exception)
            {
                IsValid = false;
            }

            return IsValid;
        }

        public bool ValidatePhoneNoDigits(string strInput)
        {
            foreach (char character in strInput)
            {
                if (character < '0' || character > '9')
                {
                    return false;
                }
            }
            return true;
        }

        public string convertDateTime(DateTime d)
        {
            string format_date = null;
            try
            {
                format_date = d.ToString("yyyy:MM:dd HH:mm:ss");
            }
            catch (Exception)
            {
                format_date = "";
            }
            return format_date;
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        // Decrypt
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



        // Check whether spaces contains
        public bool isThereSpace(String s)
        {
            return s.Contains(" ");
        }


        //Password Checking
        public bool PasswordMatch(string pswd, string dbpassword)
        {
            bool IsSuccess = false;
            string password = Encrypt(pswd);
            if (dbpassword == password)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        // Check Is only Int
        public bool IsValidInt(string Input)
        {
            bool IsSuccess = false;

            var input = Input;
            var hasNumber = new Regex(@"[0-9]+");

            if (!hasNumber.IsMatch(input))
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }


        // Remove Spaces
        public string RemoveSpaces(string input)
        {
            // Trim leading and trailing whitespaces, then replace multiple spaces with a single space
            return Regex.Replace(input.Trim(), @"\s{2,}", " ");
        }

        public bool CheckPermission(int RoleId, int Action)
        {
            bool IsSuccess = false;

            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sqlUser = "";

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sqlUser = "SELECT * FROM tbl_pos_privilage tpp WHERE tpp.RoleID ='" + RoleId + "' AND tpp.Action = '" + Action + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        DataTable dt1 = ds.Tables["userDT"];

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                int istrue = int.Parse(r["IsTrue"].ToString());
                                IsSuccess = Convert.ToBoolean(istrue);
                            }
                        }
                        else
                        {
                            ErrorForm errorFrm = new ErrorForm("No Rows", sqlUser);
                            errorFrm.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorForm errorFrm = new ErrorForm(ex.Message, sqlUser);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return IsSuccess;
        }
    }
}
