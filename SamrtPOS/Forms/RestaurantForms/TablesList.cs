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

namespace SmartPOS.Forms.RestaurantForms
{
    public partial class TablesList : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;

        public TablesList()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            setColour();
        }

        private void setColour()
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

        private void TablesList_Load(object sender, EventArgs e)
        {
            AllTableDT();
        }

        private void AllTableDT()
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
                        sqlUser = "SELECT * FROM tbl_pos_tables tpt ORDER BY tpt.TableName;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Tables");
                        dt1 = ds.Tables["Tables"];
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

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TbaleManagerControler tblMng = new TbaleManagerControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 26))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (tblMng.DeleteTable(x))
                            {
                                MessageBox.Show("Successfull Delete");
                                gridDataDetails.DataSource = null;
                                this.AllTableDT();
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
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 25))
                    {
                        string x = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        EditTable editTbl = new EditTable(x);
                        editTbl.ShowDialog();
                        gridDataDetails.DataSource = null;
                        this.AllTableDT();
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
