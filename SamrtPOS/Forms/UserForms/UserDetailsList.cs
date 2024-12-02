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

namespace SmartPOS.Forms.UserForms
{
    public partial class UserDetailsList : Form
    {

        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static CommonFuntion comFuntion;

        public UserDetailsList()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
            SetColors();
            GetGridTable();
        }

        private void UserDetailsList_Load(object sender, EventArgs e)
        {
            AddNew.Focus();
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
                        sqlUser = "SELECT tpu.*,tpr.RoleName FROM tbl_pos_user tpu INNER JOIN tbl_pos_role tpr ON tpu.RoleID = tpr.ID;";
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
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 1))
            {
                AddNewUser newUser = new AddNewUser();
                newUser.ShowDialog();
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
            UserControler UserCont = new UserControler();

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                    if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (UserCont.DeleteUser(id))
                        {
                            MessageBox.Show("Successfull Delete");
                            gridDataDetails.DataSource = null;
                            this.GetGridTable();
                        }
                    }
                }
                else if (e.ColumnIndex == this.Edit.Index)
                {
                    if (comFuntion.CheckPermission(Program.userDetails.JobRole, 2))
                    {
                        string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                        if (id != "1")
                        {
                            EditUser EditUser = new EditUser(id);
                            EditUser.ShowDialog();
                            gridDataDetails.DataSource = null;
                            this.GetGridTable();
                        }
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
            txtUserCode.Enabled = true;
            txtUserCode.Focus();
            txtUserName.Enabled = false;
            txtUserMobile.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtUserCode.Enabled = false;
            txtUserName.Enabled = true;
            txtUserName.Focus();
            txtUserMobile.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtUserCode.Enabled = false;
            txtUserName.Enabled = false;
            txtUserMobile.Enabled = true;
            txtUserMobile.Focus();
        }

        private void txtUserCode_TextChanged(object sender, EventArgs e)
        {
            CommonFuntion comnFuntion = new CommonFuntion();
            if (string.IsNullOrEmpty(txtUserCode.Text) == false || string.IsNullOrWhiteSpace(txtUserCode.Text) == false)
            {
                if (comnFuntion.IsValidInt(txtUserCode.Text))
                {
                    MessageBox.Show("Number Only.");
                }
                else
                {
                    (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", txtUserCode.Text);
                }
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("UserName LIKE '%{0}%'", txtUserName.Text);
        }

        private void txtUserMobile_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("MobileNo LIKE '%{0}%'", txtUserMobile.Text);
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
