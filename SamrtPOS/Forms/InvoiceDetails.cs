using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.InvoiceForms;
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
    public partial class InvoiceDetails : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private CommonFuntion comnFuntion;

        public InvoiceDetails()
        {
            InitializeComponent();
            comnFuntion = new CommonFuntion();
            SetColors();
            GetGridTable();
        }

        private void GetGridTable()
        {
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
                        sqlUser = "SELECT tpid.*,tpu.UserName FROM tbl_pos_invoice_details tpid INNER JOIN tbl_pos_user tpu ON tpid.cUser = tpu.ID;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "dataDT");
                        dt1 = ds.Tables["dataDT"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
                        }
                        gridDataDetails.AutoGenerateColumns = false;
                        gridDataDetails.DataSource = dt1;
                    }
                    con.Close();
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
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("InvNumber LIKE '%{0}%'", txtIInvoiceNo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fromDate = comnFuntion.convertDateTime(Convert.ToDateTime(fDate.Text));
            string toDate = comnFuntion.convertDateTime(Convert.ToDateTime(tDate.Text).AddDays(1));

            gridDataDetails.DataSource = null;

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
                        sqlUser = "SELECT tpid.*,tpu.UserName FROM tbl_pos_invoice_details tpid INNER JOIN tbl_pos_user tpu ON tpid.cUser = tpu.ID WHERE tpid.cDate BETWEEN '" + fromDate + "' AND '" + toDate + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "dataDT");
                        dt1 = ds.Tables["dataDT"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
                        }
                        gridDataDetails.AutoGenerateColumns = false;
                        gridDataDetails.DataSource = dt1;
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtIInvoiceNo.Enabled = true;
            fDate.Enabled = false;
            tDate.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fDate.Enabled = true;
            tDate.Enabled = true;
            btnSearch.Enabled = true;
            txtIInvoiceNo.Enabled = false;
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            InvoiceControler invoiceCont = new InvoiceControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comnFuntion.CheckPermission(Program.userDetails.JobRole, 9))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (invoiceCont.CancelInvoice(id))
                            {
                                MessageBox.Show("Successfull Delete");
                                gridDataDetails.DataSource = null;
                                GetGridTable();
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
                    if (comnFuntion.CheckPermission(Program.userDetails.JobRole, 8))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (Program.companyProfile.CatID == 1)
                        {
                            InvoiceOverviewSinhala OverviewSinhala = new InvoiceOverviewSinhala(id);
                            OverviewSinhala.ShowDialog();
                        }
                        else
                        {
                            InvoiceOverview Overview = new InvoiceOverview(id);
                            Overview.ShowDialog();
                        }
                        gridDataDetails.DataSource = null;
                        GetGridTable();
                    }
                    else
                    {
                        MessageBox.Show("You can't access.");
                    }
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
