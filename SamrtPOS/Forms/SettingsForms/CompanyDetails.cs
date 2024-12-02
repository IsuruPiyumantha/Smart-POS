using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class CompanyDetails : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public CompanyDetails()
        {
            InitializeComponent();
            SetColors();
            GetCompanyDetails();
            SelectLang();
        }

        private void SelectLang()
        {
            if (Program.IsEng)
            {
                RbtnEnglish.Checked = true;
            }
            else
            {
                RbtnSinhala.Checked = true;
            }
        }

        private void GetCompanyDetails()
        {
            txtCompanyName.Text = Program.companyProfile.CompanyName;
            txtCompanyAddress.Text = Program.companyProfile.Address;
            txtCompanyMobile.Text = Program.companyProfile.MobileNo;
            txtCompanyEmail.Text = Program.companyProfile.Email;
            txtSoftCompany.Text = Program.companyProfile.SoftName;
            txtSoftMobile.Text = Program.companyProfile.SoftMobileNo;
            combCompanyCategory.SelectedItem = Program.companyProfile.Catogery;
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void Clear()
        {
            txtCompanyAddress.Text = "";
            txtCompanyEmail.Text = "";
            txtCompanyMobile.Text = "";
            txtCompanyName.Text = "";
            txtSoftCompany.Text = "";
            txtSoftMobile.Text = "";
            combCompanyCategory.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CommonFuntion comnFuntion = new CommonFuntion();

            if (CompanyDetailsValidation())
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
                            string status = comnFuntion.Encrypt("1");
                            sql = "UPDATE tbl_pos_company_profile tpcp SET tpcp.CompanyName=@compName, tpcp.Address=@compAddress, tpcp.MobileNo=@compMobile, tpcp.Email=@compEmail, tpcp.CatgoryName=@compCatName, tpcp.CatgoryID=@compCatID, tpcp.SoftCompany=@softCompName, tpcp.SoftMoboleNo=@softMobile WHERE tpcp.ID = 1;";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@compName", txtCompanyName.Text.Trim().ToString());
                            cmd.Parameters.Add("@compAddress", txtCompanyAddress.Text.Trim().ToString());
                            cmd.Parameters.Add("@compMobile", txtCompanyMobile.Text.Trim().ToString());
                            cmd.Parameters.Add("@compEmail", txtCompanyEmail.Text.Trim().ToString());
                            cmd.Parameters.Add("@compCatName", combCompanyCategory.SelectedItem.ToString());
                            cmd.Parameters.Add("@compCatID", combCompanyCategory.SelectedIndex + 1);
                            cmd.Parameters.Add("@softCompName", txtSoftCompany.Text.Trim().ToString());
                            cmd.Parameters.Add("@softMobile", txtSoftMobile.Text.Trim().ToString());
                            cmd.ExecuteNonQuery();
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
                //this.Close();
                Application.Restart();
            }
        }

        private bool CompanyDetailsValidation()
        {

            bool IsSuccess = false;
            if (string.IsNullOrEmpty(txtCompanyAddress.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtCompanyAddress.Text.ToString()) == true)
            {
                MessageBox.Show("Shop Address required.");
                return IsSuccess;
            }
            if (string.IsNullOrEmpty(txtCompanyEmail.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtCompanyEmail.Text.ToString()) == true)
            {
                MessageBox.Show("Shop Email required.");
                return IsSuccess;
            }
            if (string.IsNullOrEmpty(txtCompanyMobile.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtCompanyMobile.Text.ToString()) == true)
            {
                MessageBox.Show("Shop Mobile Number required.");
                return IsSuccess;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtCompanyName.Text.ToString()) == true)
            {
                MessageBox.Show("Shop Name required.");
                return IsSuccess;
            }
            if (string.IsNullOrEmpty(txtSoftCompany.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtSoftCompany.Text.ToString()) == true)
            {
                MessageBox.Show("Software Company required.");
                return IsSuccess;
            }
            if (string.IsNullOrEmpty(txtSoftMobile.Text.ToString()) == true || string.IsNullOrWhiteSpace(txtSoftMobile.Text.ToString()) == true)
            {
                MessageBox.Show("Software Mobile Number required.");
                return IsSuccess;
            }
            if (combCompanyCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Select Shop Category.");
                return IsSuccess;
            }

            return true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void RbtnEnglish_CheckedChanged(object sender, EventArgs e)
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
                        sql = "UPDATE tbl_pos_company_profile tpcp SET tpcp.IsEnglish = 0;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
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

        private void RbtnSinhala_CheckedChanged(object sender, EventArgs e)
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
                        sql = "UPDATE tbl_pos_company_profile tpcp SET tpcp.IsEnglish = 1;";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, sql);
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

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void txtCompanyAddress_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void txtCompanyMobile_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void txtCompanyEmail_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void combCompanyCategory_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void txtSoftCompany_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void txtSoftMobile_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void RbtnEnglish_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }

        private void RbtnSinhala_KeyDown(object sender, KeyEventArgs e)
        {
            BtnClose_KeyDown(sender, e);
        }
    }
}
