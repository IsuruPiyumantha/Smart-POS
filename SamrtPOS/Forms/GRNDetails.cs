using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.CustomerForms;
using SmartPOS.Forms.GRNForms;
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
    public partial class GRNDetails : Form
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CustomerControler customerControler;

        public GRNDetails()
        {
            InitializeComponent();
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
                        sqlUser = "SELECT tpg.*, tps.SuppliersName, tpu.UserName FROM tbl_pos_grn tpg INNER JOIN tbl_pos_suppliers tps ON tpg.SupplierID= tps.ID INNER JOIN tbl_pos_user tpu ON tpg.cUser= tpu.ID;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a + 1;
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
            AddNewGRN newGRN = new AddNewGRN();
            newGRN.ShowDialog();
            gridDataDetails.DataSource = null;
            this.GetGridTable();
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //customerControler = new CustomerControler();

            //if (e.RowIndex >= 0)
            //{
            //    if (e.ColumnIndex == this.Delete.Index)
            //    {
            //        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            //        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //        {
            //            if (customerControler.DeleteCustomer(id))
            //            {
            //                MessageBox.Show("Successfull Delete");
            //                gridDataDetails.DataSource = null;
            //                this.GetGridTable();
            //            }
            //        }
            //    }
            //    else if (e.ColumnIndex == this.Viwe.Index)
            //    {
            //        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            //        EditCustomer editCustomer = new EditCustomer(id);
            //        editCustomer.ShowDialog();
            //        gridDataDetails.DataSource = null;
            //        this.GetGridTable();
            //    }
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtCusCode.Enabled = true;
            txtCusCode.Focus();
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

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
