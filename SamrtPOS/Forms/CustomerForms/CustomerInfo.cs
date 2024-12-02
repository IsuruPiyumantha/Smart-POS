using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.CustomerForms;
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
    public partial class CustomerInfo : Form
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private string id;
        private string CustomerName;
        private static DataTable dt = null;

        public CustomerInfo()
        {
            InitializeComponent();
            SetColors();
            GetGridTable();
        }

        public CustomerInfo(string id, string CusName)
        {
            InitializeComponent();
            this.id = id;
            lblCusName.Text = CusName.ToString();
            this.CustomerName = CusName;
            SetColors();
            GetGridTable();
        }

        private DataTable CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Debit", typeof(decimal));
            dt.Columns.Add("Credit", typeof(decimal));
            dt.Columns.Add("BalanceAmount", typeof(decimal));
            dt.Columns.Add("count", typeof(int));
            return dt;
        }

        private void GetGridTable()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            dt = CreateDataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_customers tpc WHERE tpc.ID = '" + this.id + "'; SELECT * FROM tbl_pos_customers_info tpci WHERE tpci.CusID = '" + this.id + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        dt2 = ds.Tables["userDT1"];

                        decimal OpenAmt = 0;
                        decimal BalanceAmt = 0;

                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r1 in dt1.Rows)
                            {
                                OpenAmt = decimal.Parse(r1["BalanceAmount"].ToString());
                                BalanceAmt = OpenAmt;
                                dt.Rows.Add("Openning Balance", r1["cDate"].ToString(), 0, 0, BalanceAmt);
                            }
                        }

                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow r2 in dt2.Rows)
                            {
                                decimal debit = decimal.Parse(r2["Debit"].ToString());
                                decimal credit = decimal.Parse(r2["Credit"].ToString());

                                if (debit > 0)
                                {
                                    BalanceAmt = BalanceAmt - debit;
                                    dt.Rows.Add(r2["Description"].ToString(), r2["cDate"].ToString(), debit, 0, BalanceAmt);
                                }
                                if (credit > 0)
                                {
                                    BalanceAmt = BalanceAmt + credit;
                                    dt.Rows.Add(r2["Description"].ToString(), r2["cDate"].ToString(), 0, credit, BalanceAmt);
                                }
                            }
                        }

                        lblBalance.Text = BalanceAmt.ToString();

                        for (int a = 0; a < dt.Rows.Count; a++)
                        {
                            dt.Rows[a]["count"] = a + 1;
                        }
                        gridDataDetails.AutoGenerateColumns = false;
                        gridDataDetails.DataSource = dt;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(AddDebit);
            styl.FormNormalButtonMain(AddCredit);
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            AddCustomerDebit addCustomerDebit = new AddCustomerDebit(this.id, this.CustomerName);
            addCustomerDebit.ShowDialog();
            gridDataDetails.DataSource = null;
            this.GetGridTable();
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCustomerCredit addCustomerCredit = new AddCustomerCredit(this.id, this.CustomerName);
            addCustomerCredit.ShowDialog();
            gridDataDetails.DataSource = null;
            this.GetGridTable();
            
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
