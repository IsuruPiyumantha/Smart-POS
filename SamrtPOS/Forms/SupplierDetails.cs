using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.CustomerForms;
using SmartPOS.Forms.SuppliersForms;
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
    public partial class SupplierDetails : Form
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;
        private static SuppliersControler SupCont;

        public SupplierDetails()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            SetColors();
            AllItemsDT();
            AddNew.Focus();
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


        private void AllItemsDT()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            SupCont = new SuppliersControler();

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_suppliers tps WHERE tps.ID > 0;";
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
                                int SusID = int.Parse(r["ID"].ToString());
                                decimal BalanceAmt = SupCont.GetSupBalance(SusID);
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

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 14))
            {
                AddNewSupplier newSupp = new AddNewSupplier();
                newSupp.ShowDialog();
                gridDataDetails.DataSource = null;
                this.AllItemsDT();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SuppliersControler suppCont = new SuppliersControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 17))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (suppCont.DeleteSupplier(id))
                            {
                                MessageBox.Show("Successfull Delete");
                                gridDataDetails.DataSource = null;
                                this.AllItemsDT();
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
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 16))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        EditSupplier editCRedtProd = new EditSupplier(id);
                        editCRedtProd.ShowDialog();
                        gridDataDetails.DataSource = null;
                        this.AllItemsDT();
                    }
                    else
                    {
                        MessageBox.Show("You can't access.");
                    }
                }
                else if (e.ColumnIndex == this.Info.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 16))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                        string SupName = gridDataDetails.Rows[e.RowIndex].Cells["SuppliersName"].Value.ToString();

                        SuppliersInfo supInfo = new SuppliersInfo(id, SupName);
                        supInfo.ShowDialog();
                        gridDataDetails.DataSource = null;
                        this.AllItemsDT();
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
            txtSupCode.Enabled = true;
            txtSupCode.Focus();
            txtSupMobile.Enabled = false;
            txtSupName.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtSupCode.Enabled = false;
            txtSupMobile.Enabled = false;
            txtSupName.Enabled = true;
            txtSupName.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtSupCode.Enabled = false;
            txtSupMobile.Enabled = true;
            txtSupMobile.Focus();
            txtSupName.Enabled = false;
        }

        private void txtSupCode_TextChanged(object sender, EventArgs e)
        {
            CommonFuntion comnFuntion = new CommonFuntion();
            if (string.IsNullOrEmpty(txtSupCode.Text) == false || string.IsNullOrWhiteSpace(txtSupCode.Text) == false)
            {
                if (comnFuntion.IsValidInt(txtSupCode.Text))
                {
                    MessageBox.Show("Number Only.");
                }
                else
                {
                    (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", txtSupCode.Text);
                }
            }
        }

        private void txtSupName_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("SuppliersName LIKE '%{0}%'", txtSupName.Text);
        }

        private void txtSupMobile_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("SuppliersMobileNo LIKE '%{0}%'", txtSupMobile.Text);
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
