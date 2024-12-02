using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.RestaurantForms;
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
    public partial class RestaurantProductDetails : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;

        public RestaurantProductDetails()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            AllItemsDT();
            SetColors();
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

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT tpi.ID,tpi.item_name,tpic.CategoryName,tpi.barcode,tpi.labled_price,tpi.kot_item,tpu.UnitName,tps.SuppliersName FROM tbl_pos_items tpi INNER JOIN tbl_pos_item_category tpic ON tpic.ID = tpi.Category INNER JOIN tbl_pos_units tpu ON tpu.ID = tpi.unit INNER JOIN tbl_pos_suppliers tps ON tpi.supplier = tps.ID;";
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

        private void ProductDetails_Load(object sender, EventArgs e)
        {
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 21))
            {
                AddNewRestaurantProduct AddnewRestprod = new AddNewRestaurantProduct();
                AddnewRestprod.ShowDialog();
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
            ProductControler ProductCont = new ProductControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 23))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (ProductCont.DeleteProduct(x))
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
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 22))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        EditRestaurantProduct editCRedtProd = new EditRestaurantProduct(x);
                        editCRedtProd.ShowDialog();
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
            txtItemCode.Enabled = true;
            txtItemCode.Focus();
            txtItemName.Enabled = false;
            txtBarCode.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtItemCode.Enabled = false;
            txtItemName.Enabled = true;
            txtItemName.Focus();
            txtBarCode.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtItemCode.Enabled = false;
            txtItemName.Enabled = false;
            txtBarCode.Enabled = true;
            txtBarCode.Focus();
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            CommonFuntion comnFuntion = new CommonFuntion();
            if (string.IsNullOrEmpty(txtItemCode.Text) == false || string.IsNullOrWhiteSpace(txtItemCode.Text) == false)
            {
                if (comnFuntion.IsValidInt(txtItemCode.Text))
                {
                    MessageBox.Show("Number Only.");
                }
                else
                {
                    (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", txtItemCode.Text);
                }
            }
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("item_name LIKE '%{0}%'", txtItemName.Text);
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("barcode LIKE '%{0}%'", txtBarCode.Text);
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
