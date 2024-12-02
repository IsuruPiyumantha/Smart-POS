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

namespace SmartPOS.Forms
{
    public partial class CustomerDetails : Form
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CustomerControler customerControler;
        private static CommonFuntion comFuntion;


        public CustomerDetails()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            SetColors();
            GetGridTable();
            AddNew.Focus();
        }

        private void GetGridTable()
        {
            customerControler = new CustomerControler();
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT tpc.* FROM tbl_pos_customers tpc;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];

                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
                        }
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                int CusID = int.Parse(r["ID"].ToString());
                                decimal BalanceAmt = customerControler.GetCusBalance(CusID);
                                r["BalanceAmount"] = BalanceAmt;
                            }
                        }
                        gridDataDetails.AutoGenerateColumns = false;
                        gridDataDetails.DataSource = dt1;
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
            styl.FormNormalButtonMain(AddNew);
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 10))
            {
                AddNewCustomer newCust = new AddNewCustomer();
                newCust.ShowDialog();
                gridDataDetails.DataSource = null;
                this.GetGridTable();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            customerControler = new CustomerControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 13))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (customerControler.DeleteCustomer(id))
                            {
                                MessageBox.Show("Successfull Delete");
                                gridDataDetails.DataSource = null;
                                this.GetGridTable();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can't access.");
                    }
                }
                else if (e.ColumnIndex == this.Edit.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 12))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        EditCustomer editCustomer = new EditCustomer(id);
                        editCustomer.ShowDialog();
                        gridDataDetails.DataSource = null;
                        this.GetGridTable();
                    }
                    else
                    {
                        MessageBox.Show("You can't access.");
                    }
                }
                else if (e.ColumnIndex == this.Info.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 11))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                        string CusName = gridDataDetails.Rows[e.RowIndex].Cells["CustomerName"].Value.ToString();

                        CustomerInfo customerInfo = new CustomerInfo(id, CusName);
                        customerInfo.ShowDialog();
                        gridDataDetails.DataSource = null;
                        this.GetGridTable();
                    }
                    else
                    {
                        MessageBox.Show("You can't access.");
                    }
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtCusCode.Enabled = true;
            txtCusCode.Focus();
            txtCusMobile.Enabled = false;
            txtCusName.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtCusCode.Enabled = false;
            txtCusMobile.Enabled = false;
            txtCusName.Enabled = true;
            txtCusName.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtCusCode.Enabled = false;
            txtCusMobile.Enabled = true;
            txtCusMobile.Focus();
            txtCusName.Enabled = false;
        }

        private void txtCusCode_TextChanged(object sender, EventArgs e)
        {
            CommonFuntion comnFuntion = new CommonFuntion();
            if (string.IsNullOrEmpty(txtCusCode.Text) == false || string.IsNullOrWhiteSpace(txtCusCode.Text) == false)
            {
                if (comnFuntion.IsValidInt(txtCusCode.Text))
                {
                    MessageBox.Show("Number Only.");
                }
                else
                {
                    (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", txtCusCode.Text);
                }
            }
        }

        private void txtCusName_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("CustomerName LIKE '%{0}%'", txtCusName.Text);
        }

        private void txtCusMobile_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("CustomerMobileNo LIKE '%{0}%'", txtCusMobile.Text);
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
