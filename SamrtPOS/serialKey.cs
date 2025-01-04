using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.SettingsForms;
using SmartPOS.Forms.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS
{
    public partial class serialKey : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        private string serialKey2;
        private CompanyProfile companyProfile;
        private CommonFuntion comnFuntion;

        public serialKey(CompanyProfile companyProfile, string serialKey2)
        {
            InitializeComponent();
            setColour();
            this.companyProfile = companyProfile;
            this.serialKey2 = serialKey2;
            label3.Text = "Please Contact " + companyProfile.SoftName + " " + companyProfile.SoftMobileNo;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setColour()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSerialKey())
            {
                Application.Restart();
            }
        }

        private bool SaveSerialKey()
        {
            bool IsSucess = false;
            comnFuntion = new CommonFuntion();

            if (string.IsNullOrEmpty(txtSerialKey.Text) == true || string.IsNullOrWhiteSpace(txtSerialKey.Text) == true)
            {
                MessageBox.Show("Serial Key required.");
            }
            else
            {
                string serialKey = txtSerialKey.Text.Trim().ToString();

                if (comnFuntion.PasswordMatch(serialKey2, serialKey))
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
                                string status = comnFuntion.Encrypt("2");
                                sql = "UPDATE tbl_pos_serial_key SET Status = '" + status + "' ";
                                MySqlCommand cmd = new MySqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                                IsSucess = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorForm errorFrm = new ErrorForm(ex.Message, sql);
                        errorFrm.ShowDialog();
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Serial Key.");
                }
            }
            return IsSucess;
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtSerialKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SaveSerialKey())
                {
                    Application.Restart();
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void lblHeadText_DoubleClick(object sender, EventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();
            if (password.GetFinalState() == true)
            {
                GetSerialKey skey = new GetSerialKey();
                skey.ShowDialog();
            }
        }
    }
}
