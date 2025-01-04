using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
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

namespace SmartPOS.Forms.ItemsForms
{
    public partial class SubCategoryList : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;
        private string x;

        public SubCategoryList()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            AllItemsDT();
            this.SetColors();
            radioButton2.Checked = true;
        }

        public SubCategoryList(string x, string y)
        {
            // TODO: Complete member initialization
            this.x = x;
            InitializeComponent();
            lblHeadText.Text = y.ToString();
            comFuntion = new CommonFuntion();
            AllItemsDT();
            this.SetColors();
            radioButton2.Checked = true;
        }

        private void SetColors()
        {
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
                        sqlUser = "SELECT * FROM tbl_pos_item_sub_category tpisc WHERE tpisc.CategoryID = '" + x + "';";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemCat");
                        dt1 = ds.Tables["itemCat"];
                        dt1.Columns.Add("count", typeof(int));
                        for (int a = 0; a < dt1.Rows.Count; a++)
                        {
                            dt1.Rows[a]["count"] = a+1;
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
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor= Color.FromName(Program.col2);
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 18))
            {
                AddNewSubCategory newCat = new AddNewSubCategory(this.x);
                newCat.ShowDialog();
                gridDataDetails.DataSource = null;
                AllItemsDT();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemsCategoryControls itemsCatMng = new ItemsCategoryControls();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 20))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (itemsCatMng.DeleteItemsSubCategory(x))
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
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 19))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        EditSubCategory editCat = new EditSubCategory(x);
                        editCat.ShowDialog();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("CategoryName LIKE '%{0}%'", textBox1.Text);
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
