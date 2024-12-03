using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class ScaleExport : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private DataTable dt1;

        public ScaleExport()
        {
            InitializeComponent();
            SetColors();
            GetData();
        }

        private void GetData()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT tpi.ID, tpi.item_name,tpi.item_name_sinhala, tpi.labled_price FROM tbl_pos_items tpi WHERE tpi.unit = 2;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];

                        if (dt1.Rows.Count > 0)
                        {
                            dt1.Columns.Add("ItemCode", typeof(string));
                            if (Program.companyProfile.IsEnglish == false)
                            {
                                dt1.Columns.Remove("item_name");
                                dt1.Columns["item_name_sinhala"].ColumnName = "item_name";
                            }
                            dt1.Columns.Add("count", typeof(int));
                            for (int a = 0; a < dt1.Rows.Count; a++)
                            {
                                dt1.Rows[a]["count"] = a + 1;
                            }
                            foreach (DataRow r in dt1.Rows)
                            {
                                string id = r["ID"].ToString();
                                if (id.Length == 1)
                                {
                                    r["ItemCode"] = "0000" + id;
                                }
                                if (id.Length == 2)
                                {
                                    r["ItemCode"] = "000" + id;
                                }
                                if (id.Length == 3)
                                {
                                    r["ItemCode"] = "00" + id;
                                }
                                if (id.Length == 4)
                                {
                                    r["ItemCode"] = "0" + id;
                                }
                                if (id.Length == 5)
                                {
                                    r["ItemCode"] = id;
                                }
                            }
                            gridDataDetails.AutoGenerateColumns = false;
                            gridDataDetails.DataSource = dt1;
                        }
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
                }
            }
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnExport);
            styl.setGridDetails(gridDataDetails);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (DataRow r in dt1.Rows)
                        {
                            if (chkCount.Checked == true)
                            {
                                tw.WriteLineAsync(r["count"].ToString() + "#" + r["ItemCode"].ToString() + "#" + r["item_name"].ToString().ToUpper() + "#" + r["labled_price"].ToString() + "#");
                            }
                            else
                            {
                                tw.WriteLineAsync(r["ItemCode"].ToString() + "#" + r["item_name"].ToString().ToUpper() + "#" + r["labled_price"].ToString() + "#");
                            }
                        }
                    }
                    this.Close();
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
