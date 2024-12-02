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

namespace SmartPOS.Forms
{
    public partial class Temp : Form
    {
        private static MySqlConnection con;
        private static CommonFuntion ComFuntion;
        private static string conString = string.Empty;
        private static DataTable itemsTable = new DataTable();
        private static DataTable dt = null;
        private static DataTable GridTable = null;


        public Temp()
        {
            ComFuntion = new CommonFuntion();

            InitializeComponent();
            Clear();

        }

        private void Clear()
        {
            txtQnt.Text = "";
            txtLabPrice.Text = "0.00";
            txtSpecPrice.Text = "0.00";
            txtTotPrice.Text = "0.00";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromName(Program.col);
            panel20.BackColor = Color.FromName(Program.col2);
            panel6.BackColor = Color.FromName(Program.col3);
            tableLayoutPanel13.BackColor = Color.FromName(Program.col3);
            panel4.BackColor = Color.FromName(Program.col3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void SearchItem()
        {
        }

        private void GetAllitems()
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
                        sqlUser = "SELECT * FROM tbl_pos_items tpi;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        itemsTable = ds.Tables["itemDT"];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
        }

        private void txtQnt_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSpecPrice_TextChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddGrid();
        }

        private void AddGrid()
        {
            throw new NotImplementedException();
        }
    }
}
