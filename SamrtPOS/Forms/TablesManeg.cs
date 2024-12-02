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
    public partial class TablesManeg : Form
    {
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private static TbaleManagerControler TblControler;
        public List<AllTableInfo> AllTBLinfo;
        public AllTableInfo tableInfo;
        private static CommonFuntion comFuntion;

        DataTable fieldTbl;

        public TablesManeg()
        {
            InitializeComponent();
            comFuntion = new CommonFuntion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TablesManeg_Load(object sender, EventArgs e)
        {
            this.fillData();
            SetColors();
            btnRefresh.Focus();
        }

        private void SetColors()
        {
            tableLayoutPanel20.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);
            lblDate.ForeColor = Color.FromName(Program.hText);
            lblTime.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnRefresh);
            styl.FormNormalButtonMain(AddNew);
            styl.FormNormalButtonMain(btnEdit);
        }


        public void fillData()
        {
            TblControler = new TbaleManagerControler();

            this.AllTBLinfo = TblControler.SelectAllTable(0);


            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 555);
            this.tableLayoutPanel1.TabIndex = 0;


            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            if (this.AllTBLinfo.Count > 4)
            {
                int rowCount = (this.AllTBLinfo.Count / 4);
                for (int a = 0; a < rowCount; a++)
                {
                    this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
                }
            }
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 110F));
            this.tableLayoutPanel1.RowCount = this.AllTBLinfo.Count + 2;
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.Refresh();

            this.fillPanal();
            
        }

        public void fillPanal()
        {
            this.AllTBLinfo = TblControler.SelectAllTable(0);

            if (this.AllTBLinfo.Count > 0)
            {

                int x = 0;

                foreach (AllTableInfo inInfo in this.AllTBLinfo)
                {

                    Button b = new Button();
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

                    if (inInfo.IsUse)
                    {
                        b.BackColor = System.Drawing.Color.Maroon;
                    }
                    else
                    {
                        b.BackColor = System.Drawing.Color.MidnightBlue;
                    }
                    b.ForeColor = System.Drawing.Color.White;
                    //b.Size = new System.Drawing.Size(250, 220);
                    b.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    b.Tag = inInfo.ID.ToString();
                    b.Text = inInfo.TableName;
                    b.Location = new Point(x, 8);
                    b.Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(b);
                    x = x + 5;
                    b.Click += new EventHandler(b_Click);
                    //this.fieldTbl = inInfo.fieldDataTable;
                }
            }
        }

        void b_Click(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            tableInfo = TblControler.getTableDate(b);

            if (!tableInfo.IsUse && tableInfo.InvID == 0)
            {
                b.BackColor = System.Drawing.Color.Maroon;
                TableUse(b, Tag);
                RestaurantSale restSale = new RestaurantSale(b, Tag);
                restSale.Show();
            }
            else if (tableInfo.IsUse && tableInfo.InvID > 0)
            {
                RestaurantSale restSale = new RestaurantSale(b, Tag, tableInfo);
                restSale.Show();
                //MessageBox.Show("Already Open This Table.");
            }
            else
            {
                MessageBox.Show("Already Open This Table.");
            }
        }


        private void TableUse(Button b, object Tag)
        {
            TblControler = new TbaleManagerControler();
            this.AllTBLinfo = TblControler.UpdateSelectAllTable(b.Text, 1);
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            if (comFuntion.CheckPermission(Program.userDetails.JobRole, 24))
            {
                AddNewTable newTbl = new AddNewTable();
                newTbl.ShowDialog();
                tableLayoutPanel1.Controls.Clear();
                this.fillPanal();
            }
            else
            {
                MessageBox.Show("You can't access.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TablesList tblList = new TablesList();
            tblList.ShowDialog();
            tableLayoutPanel1.Controls.Clear();
            this.fillPanal();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:MM:ss tt");
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            this.fillPanal();
        }

        private void btnRefresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F5)
            {
                tableLayoutPanel1.Controls.Clear();
                this.fillPanal();
            }
        }
    }
}
