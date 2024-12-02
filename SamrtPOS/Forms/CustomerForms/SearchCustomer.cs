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

namespace SmartPOS.Forms.CustomerForms
{
    public partial class SearchCustomer : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private decimal Amount;
        private string InvoiceNumber;
        private DataTable dt = null;
        public bool IsSuccess = false;

        public SearchCustomer(decimal Amount, string InvoiceNo)
        {
            // TODO: Complete member initialization
            this.InvoiceNumber = InvoiceNo;
            this.Amount = Amount;
            InitializeComponent();
            SetColors();
            GetAllCustomer();
        }

        private void GetAllCustomer()
        {
            CustomerControler cusCont = new CustomerControler();
            dt = new DataTable();
            dt = cusCont.SelectAllCustomers();

            txtCustname.DataSource = dt;
            txtCustname.DisplayMember = "CustomerName";
            txtCustname.ValueMember = "ID";
            txtCustname.SelectedIndex = -1;
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
        }

        private void AddCustomerDebit_Load(object sender, EventArgs e)
        {
            txtCustname.Focus();
            lblAmount.Text = Amount.ToString("#.00");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            if (txtCustname.SelectedIndex >= 0)
            {
                int id = int.Parse(txtCustname.SelectedValue.ToString());
                int cUser = Program.userDetails.UserID;

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
                            string sql = "INSERT INTO tbl_pos_customers_info (CusID, Description, Debit, Credit, cDate, cUser) VALUES ('" + id + "', '" + this.InvoiceNumber + "', 0, @Amt, '" + nowDate + "', '" + cUser + "');";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@Amt", this.Amount);
                            cmd.ExecuteNonQuery();
                            IsSuccess = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select Customer.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {

        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            AddNewCustomer addCus = new AddNewCustomer();
            addCus.ShowDialog();
            GetAllCustomer();
            txtCustname.Focus();
        }

        private void txtCustname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult result = MessageBox.Show("Are You Sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Save();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                AddCustomer.Focus();
            }
            BtnClose_KeyDown(sender, e);
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
