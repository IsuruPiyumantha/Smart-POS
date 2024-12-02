using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SuppliersForms
{
    public partial class AddSupplierDebit : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private string id;
        private string SupplierName;

        public AddSupplierDebit()
        {
            InitializeComponent();
            SetColors();
        }

        public AddSupplierDebit(string p,string Supplier)
        {
            // TODO: Complete member initialization
            this.id = p;
            this.SupplierName = Supplier;
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void AddCustomerDebit_Load(object sender, EventArgs e)
        {
            txtDes.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private bool Save()
        {
            bool IsSuccess = false;
            bool Error = false;
            string sql = string.Empty;

            int cUser = Program.userDetails.UserID;

            if (string.IsNullOrEmpty(txtDes.Text) == true || string.IsNullOrWhiteSpace(txtDes.Text) == true)
            {
                MessageBox.Show("Please Enter Description.");
                Error = true;
            }
            if (string.IsNullOrEmpty(txtAmt.Text) == true || string.IsNullOrWhiteSpace(txtAmt.Text) == true)
            {
                MessageBox.Show("Please Enter Amount.");
                Error = true;
            }

            if(!Error)
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);

                CommonFuntion cmnFuntion = new CommonFuntion();
                string nowDate = cmnFuntion.convertDateTime(DateTime.Now);

                try
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();

                        if (con != null)
                        {
                            sql = "INSERT INTO tbl_pos_suppliers_info (SupID, Description, Debit, Credit, cDate, cUser) VALUES ('" + this.id + "', @Des, @Amt, 0, '" + nowDate + "', '" + cUser + "'); INSERT INTO tbl_pos_cash_book (Description, Credit, Debit, cUser, cDate) VALUES (@description, 0, @Amt, '" + cUser + "', '" + nowDate + "');";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            string description = this.SupplierName + " paid the creditor";
                            cmd.Parameters.Add("@description", description);
                            cmd.Parameters.Add("@Des", txtDes.Text.Trim().ToString());
                            cmd.Parameters.Add("@Amt", txtAmt.Text);
                            cmd.ExecuteNonQuery();
                            IsSuccess = true;
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
            }
            return IsSuccess;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
            txtDes.Text = "";
            txtAmt.Text = "0";

        }

        private void txtDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmt.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Save())
                {
                    this.Close();
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtAmt_TextChanged(object sender, EventArgs e)
        {
            CommonFuntion cmnFuntion = new CommonFuntion();

            if (txtAmt.Text != "")
            {
                if (cmnFuntion.IsValidDecimalNo(txtAmt.Text.ToString()) == false)
                {
                    MessageBox.Show("Invalid Amount.");
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
    }
}
