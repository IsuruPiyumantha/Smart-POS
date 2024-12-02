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

namespace SmartPOS.Forms.BarCodeForms
{
    public partial class BarCode : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private DataTable Barcode;

        private string ProdName;
        private string ProdCode;
        private decimal ProdPrice;
        private string ProdBarCode;

        public BarCode()
        {
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BarCode_Load(object sender, EventArgs e)
        {
            Barcode = new DataTable();
            Barcode.Columns.Add("ProductName", typeof(string));
            Barcode.Columns.Add("ProductCode", typeof(string));
            Barcode.Columns.Add("ProductPrice", typeof(decimal));
            Barcode.Columns.Add("ProductBarCode", typeof(decimal));

            GetItemDetails();
        }

        private void GetItemDetails()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_items tpi WHERE tpi.ID = 1;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        DataTable itemsTable = ds.Tables["itemDT"];

                        if (Program.companyProfile.IsEnglish == false)
                        {
                            itemsTable.Columns.Remove("item_name");
                            itemsTable.Columns["item_name_sinhala"].ColumnName = "item_name";
                        }
                        if (itemsTable.Rows.Count > 0)
                        {

                            foreach (DataRow r in itemsTable.Rows)
                            {
                                this.ProdName = r["item_name"].ToString();
                                this.ProdCode = r["ID"].ToString();
                                this.ProdPrice = decimal.Parse(r["labled_price"].ToString());
                                this.ProdBarCode = "100000" + r["ID"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Length = int.Parse(textBox1.Text.Trim());
            for (int i = 0; i < Length; i++)
            {
                Barcode.Rows.Add(this.ProdName, this.ProdCode, this.ProdPrice, this.ProdBarCode);
            }
            dataGridView1.DataSource = Barcode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BarCode3 Rpt = this.SetCrystalReport();
            CrystalReportViewPage cry = new CrystalReportViewPage(Rpt);
            cry.Show();
        }

        private BarCode3 SetCrystalReport()
        {
            BarCode3 Rpt = new BarCode3();
            Rpt.SetDataSource(Barcode);
            return Rpt;
        }
    }
}
