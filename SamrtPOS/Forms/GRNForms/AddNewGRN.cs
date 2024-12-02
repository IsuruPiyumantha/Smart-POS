using MySql.Data.MySqlClient;
using SmartPOS.Controler;
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

namespace SmartPOS.Forms.GRNForms
{
    public partial class AddNewGRN : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        private static DataTable itemsTable = null;

        private static GRNControler GRNCont;
        public static GRNDetailsInfo GRNInfo;
        public static GRNinfo info;
        public static CommonFuntion CmnFun;

        public AddNewGRN()
        {
            CmnFun = new CommonFuntion();
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClearAll);
            styl.setGridDetails(gridDataDetails);
        }

        private void AddNewSupplier_Load(object sender, EventArgs e)
        {
            GRNCont = new GRNControler();
            SelectGRNNumber();
            GetAllitems();
            ComboItemName();
            ComboSupplier();
        }

        private void ComboSupplier()
        {
            DataTable dt = this.GetAllSupplier();
            DataRow r = dt.NewRow();
            r[1] = "- Select -";
            dt.Rows.InsertAt(r, 0);
            cmbSupplier.DataSource = dt;
            cmbSupplier.DisplayMember = "SuppliersName";
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.SelectedIndex = 0;
        }

        private DataTable GetAllSupplier()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            DataTable Supp = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT ID,SuppliersName FROM tbl_pos_suppliers;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "itemDT");
                        Supp = ds.Tables["itemDT"];
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return Supp;
        }

        private void ComboItemName()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("item_name", typeof(string));
            dt.Rows.Add(0, "-select-");

            if (itemsTable.Rows.Count >= 0)
            {
                foreach (DataRow r in itemsTable.Rows)
                {
                    dt.Rows.Add(int.Parse(r["ID"].ToString()), r["item_name"].ToString());
                }
            }

            txtItemName.DataSource = dt;
            txtItemName.DisplayMember = "item_name";
            txtItemName.ValueMember = "ID";
            txtItemName.SelectedIndex = 0;
            
        }

        private void txtItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtItemName.SelectedIndex > 0)
            {
                int itemID = int.Parse(txtItemName.SelectedValue.ToString());
                if (itemID > 0)
                {
                    DataRow[] dr = itemsTable.Select("ID = '" + itemID + "'");

                    if (dr.Length > 0)
                    {
                        foreach (DataRow row in dr)
                        {
                            txtItemCode.Text = row["ID"].ToString();
                            txtItemCode.Enabled = false;
                            txtLabledPrice.Text = row["labled_price"].ToString();
                            txtLabledPrice.Enabled = false;
                            txtInStock.Text = row["InStock"].ToString();
                            txtInStock.Enabled = false;

                            if (row["barcode"].ToString() != "")
                            {
                                txtBarCode.Text = row["barcode"].ToString();
                                txtBarCode.Enabled = false;
                            }
                            else if (row["barcode2"].ToString() != "")
                            {
                                txtBarCode.Text = row["barcode2"].ToString();
                                txtBarCode.Enabled = false;
                            }
                            else if (row["barcode3"].ToString() != "")
                            {
                                txtBarCode.Text = row["barcode3"].ToString();
                                txtBarCode.Enabled = false;
                            }
                            else
                            {
                                txtBarCode.Text = "";
                                txtBarCode.Enabled = false;
                            }

                            txtBuyingCost.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalide Item Code.");
                    }
                }
            }
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

                        if (Program.companyProfile.IsEnglish == false)
                        {
                            itemsTable.Columns.Remove("item_name");
                            itemsTable.Columns["item_name_sinhala"].ColumnName = "item_name";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SelectGRNNumber()
        {
            string GRNNumber = string.Empty;
            GRNCont = new GRNControler();
            info = new GRNinfo();

            info = GRNCont.GetGrnNumber();

            DateTime now = DateTime.Now;

            if (now.Date > Convert.ToDateTime(info.GRNDate.ToString()))
            {
                bool UpdateInvDate = GRNCont.UpdateGRNDate(ref info, now.ToString("yyyy/MM/dd"));
            }

            char[] yearArr = now.Year.ToString().ToCharArray();
            string month = now.Month.ToString();
            if (now.Month.ToString().Length == 1)
                month = "0" + month;
            string day = now.Day.ToString();
            if (now.Day.ToString().Length == 1)
                day = "0" + day;
            string GRNNo = info.GRNNumber.ToString();
            string GRNCode = info.GRNCode.ToString();
            if (GRNNo.Length == 1)
                GRNNo = "00" + GRNNo;
            else if (GRNNo.Length == 2)
                GRNNo = "0" + GRNNo;

            GRNNumber = GRNCode + yearArr[2].ToString() + yearArr[3].ToString() + month + day + GRNNo;
            lblGRNNumber.Text = GRNNumber;
            txtItemCode.Focus();
            
        }

        private void Clear()
        {
            txtItemCode.Text = "";
            txtItemCode.Enabled = true;
            txtBarCode.Text = "";
            txtBarCode.Enabled = true;
            txtItemName.Text = "";
            txtItemName.Enabled = true;
            txtLabledPrice.Text = "0.00";
            txtLabledPrice.Enabled = true;
            txtBuyingCost.Text = "0.00";
            txtQuantity.Text = "";
            txtTotal.Text = "";
            txtInStock.Text = "";
            txtItemCode.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void Save()
        {
            GRNCont = new GRNControler();
            GRNInfo = new GRNDetailsInfo();
            CmnFun = new CommonFuntion();


            if (cmbSupplier.SelectedIndex > 0)
            {
                if (cmbPayMeth.SelectedIndex >= 0)
                {
                    if (string.IsNullOrEmpty(txtPayAmt.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtPayAmt.Text.ToString()) == false)
                    {
                        if (string.IsNullOrEmpty(txtDescri.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtDescri.Text.ToString()) == false)
                        {
                            if (cmbPayMeth.SelectedIndex == 1)
                            {
                                if (string.IsNullOrEmpty(txtChqNum.Text.ToString()) == false || string.IsNullOrWhiteSpace(txtChqNum.Text.ToString()) == false)
                                {
                                    if (Convert.ToDateTime(chqDate.Text.ToString()) > DateTime.Now)
                                    {
                                        GRNInfo.ChequesNumber = txtChqNum.Text;
                                        GRNInfo.ChequesDate = chqDate.Text.ToString();
                                        saveDatabase();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Required Cheques Date");
                                        chqDate.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Required Cheques Number");
                                    txtChqNum.Focus();
                                }
                            }
                            else
                            {
                                saveDatabase();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Required Description");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Required Amount");
                    }
                }
                else
                {
                    MessageBox.Show("Select Payment Method");
                }
            }
            else
            {
                MessageBox.Show("Select Supplier Name");
            }
        }

        private void saveDatabase()
        {
            GRNInfo.GRNNumber = lblGRNNumber.Text;
            GRNInfo.Description = txtDescri.Text.Trim().ToString();
            GRNInfo.SupplirtID = int.Parse(cmbSupplier.SelectedValue.ToString());
            GRNInfo.SupplierName = cmbSupplier.Text.ToString();
            GRNInfo.Total = decimal.Parse(lblTotAmt.Text.ToString());
            GRNInfo.Method = cmbPayMeth.SelectedItem.ToString();
            GRNInfo.Amount = decimal.Parse(txtPayAmt.Text.ToString());

            DataTable GRNDetails = new DataTable();
            foreach (DataGridViewColumn col in gridDataDetails.Columns)
            {
                GRNDetails.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in gridDataDetails.Rows)
            {
                DataRow dRow = GRNDetails.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                GRNDetails.Rows.Add(dRow);
            }


            if (cmbPayMeth.SelectedIndex == 0)
            {
                if (GRNInfo.Amount >= GRNInfo.Total)
                {
                    if (GRNCont.AddNewGRN(GRNInfo,GRNDetails,"Cash"))
                    {
                        MessageBox.Show("Successfull");
                        bool UpdateGRN = GRNCont.UpdateNextGRNNumber(info.GRNNumber, info.GRNCode, false);
                        ClearAll();
                        SelectGRNNumber();
                    }
                }
                else
                {
                    MessageBox.Show("Enter an amount greater than the total");
                    txtPayAmt.Focus();
                }
            }
            if (cmbPayMeth.SelectedIndex == 1)
            {
                if (GRNCont.AddNewGRN(GRNInfo, GRNDetails, "Cheques"))
                {
                    MessageBox.Show("Successfull");
                    bool UpdateGRN = GRNCont.UpdateNextGRNNumber(info.GRNNumber, info.GRNCode, false);
                    ClearAll();
                    SelectGRNNumber();
                }
            }
            if (cmbPayMeth.SelectedIndex == 2)
            {
                if (GRNInfo.Amount < GRNInfo.Total)
                {
                    if (GRNCont.AddNewGRN(GRNInfo, GRNDetails, "Credit"))
                    {
                        MessageBox.Show("Successfull");
                        bool UpdateGRN = GRNCont.UpdateNextGRNNumber(info.GRNNumber, info.GRNCode, false);
                        ClearAll();
                        SelectGRNNumber();
                    }
                }
            }
        }

        private void ClearAll()
        {
            GetAllitems();
            cmbPayMeth.SelectedIndex = 0;
            cmbSupplier.SelectedIndex = 0;
            gridDataDetails.Rows.Clear();
            gridDataDetails.Refresh();
            lblTotAmt.Text = "0.00";
            txtPayAmt.Text = "0.00";
            txtDescri.Text = "";
            Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemCode.Text != "")
                {
                    if (CmnFun.IsValidDecimalNo(txtItemCode.Text.Trim().ToString()))
                    {
                        int itemID = int.Parse(txtItemCode.Text.ToString());
                        if (itemID > 0)
                        {
                            DataRow[] dr = itemsTable.Select("ID = '" + itemID + "'");

                            if (dr.Length > 0)
                            {
                                foreach (DataRow row in dr)
                                {
                                    txtItemName.Text = row["item_name"].ToString();
                                    txtItemName.Enabled = false;
                                    txtLabledPrice.Text = row["labled_price"].ToString();
                                    txtLabledPrice.Enabled = false;
                                    txtInStock.Text = row["InStock"].ToString();
                                    txtInStock.Enabled = false;

                                    if (row["barcode"].ToString() != "")
                                    {
                                        txtBarCode.Text = row["barcode"].ToString();
                                        txtBarCode.Enabled = false;
                                    }
                                    else if (row["barcode2"].ToString() != "")
                                    {
                                        txtBarCode.Text = row["barcode2"].ToString();
                                        txtBarCode.Enabled = false;
                                    }
                                    else if (row["barcode3"].ToString() != "")
                                    {
                                        txtBarCode.Text = row["barcode3"].ToString();
                                        txtBarCode.Enabled = false;
                                    }
                                    else
                                    {
                                        txtBarCode.Text = "";
                                        txtBarCode.Enabled = false;
                                    }

                                    txtBuyingCost.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalide Item Code.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalide Item Code.");
                        }
                    }
                }
                else
                {
                    txtBarCode.Focus();
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarCode.Text != "")
            {
                string Barcode = txtBarCode.Text.ToString();
                DataRow[] dr = itemsTable.Select("barcode = '" + Barcode + "'");

                if (dr.Length == 0)
                {
                    dr = itemsTable.Select("barcode2 = '" + Barcode + "'");
                }

                if (dr.Length == 0)
                {
                    dr = itemsTable.Select("barcode3 = '" + Barcode + "'");
                }

                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        txtItemCode.Text = row["ID"].ToString();
                        txtItemCode.Enabled = false;
                        txtItemName.Text = row["item_name"].ToString();
                        txtItemName.Enabled = false;
                        txtLabledPrice.Text = row["labled_price"].ToString();
                        txtLabledPrice.Enabled = false;
                        txtInStock.Text = row["InStock"].ToString();
                        txtInStock.Enabled = false;
                        txtBuyingCost.Focus();
                    }
                }
            }
        }

        private void txtBuyingCost_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (CmnFun.IsValidDecimalNo(txtBuyingCost.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Buying Cost");
                txtBuyingCost.Text = "";
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (CmnFun.IsValidDecimalNo(txtQuantity.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Quantity");
                txtQuantity.Text = "";
            }
            else
            {
                if (txtBuyingCost.Text != "" && txtQuantity.Text != "")
                {
                    decimal buyCost = decimal.Parse(txtBuyingCost.Text.ToString());
                    decimal qnt = decimal.Parse(txtQuantity.Text.ToString());
                    decimal tot = buyCost * qnt;

                    txtTotal.Text = tot.ToString("#.00");
                }
                else
                {
                    txtTotal.Text = "0.00";
                }
            }
        }
        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtItemName.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtBuyingCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtItemCode.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExDate.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtBuyingCost.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void ExDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddToGrid();
            }
            BtnClose_KeyDown(sender, e);
        }


        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            AddToGrid();
        }

        private void AddToGrid()
        {
            if (validationTextBox())
            {
                string ICode = txtItemCode.Text;
                string IName = txtItemName.Text;
                string LPrice = txtLabledPrice.Text;
                decimal B = decimal.Parse(txtBuyingCost.Text.ToString());
                string BuyCost = B.ToString("#.00");
                string Qnt = txtQuantity.Text;
                string Tot = txtTotal.Text;
                string EDate = ExDate.Text;
                string[] row = { ICode, IName, BuyCost, Qnt, Tot, EDate };
                gridDataDetails.Rows.Add(row);
                CalTotal();
                Clear();
                txtItemCode.Focus();
            }
        }

        private void CalTotal()
        {
            decimal Total = 0;

            for (int i = 0; i < gridDataDetails.Rows.Count; i++)
            {
                Total += Convert.ToDecimal(gridDataDetails.Rows[i].Cells["Total"].Value);
            }

            lblTotAmt.Text = Total.ToString();
        }

        private bool validationTextBox()
        {
            bool IsSuccess = true;

            if (string.IsNullOrEmpty(txtItemCode.Text) == true || string.IsNullOrWhiteSpace(txtItemCode.Text) == true)
            {
                MessageBox.Show("Item Code is required.");
                IsSuccess = false;
            }
            if (string.IsNullOrEmpty(txtItemName.Text) == true || string.IsNullOrWhiteSpace(txtItemName.Text) == true)
            {
                MessageBox.Show("Item Name is required.");
                IsSuccess = false;
            }
            if (string.IsNullOrEmpty(txtLabledPrice.Text) == true || string.IsNullOrWhiteSpace(txtLabledPrice.Text) == true)
            {
                MessageBox.Show("Labled Price is required.");
                IsSuccess = false;
            }
            if (string.IsNullOrEmpty(txtBuyingCost.Text) == true || string.IsNullOrWhiteSpace(txtBuyingCost.Text) == true)
            {
                MessageBox.Show("Buying Cost is required.");
                IsSuccess = false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text) == true || string.IsNullOrWhiteSpace(txtQuantity.Text) == true)
            {
                MessageBox.Show("Quantity is required.");
                IsSuccess = false;
            }

            return IsSuccess;
        }

        private void AddSupplier_Click(object sender, EventArgs e)
        {
            AddNewSupplier newSupp = new AddNewSupplier();
            newSupp.ShowDialog();
            ComboSupplier();
        }

        private void gridDataDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Int32 selectedRowCount = gridDataDetails.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        gridDataDetails.Rows.RemoveAt(gridDataDetails.SelectedRows[0].Index);
                        CalTotal();
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayMeth.SelectedIndex == 0)
            {
                lblAmount.Text = "Cash Amount :";
                txtPayAmt.Enabled = true;
                groupBox1.Visible = false;
            }
            if (cmbPayMeth.SelectedIndex == 1)
            {
                lblAmount.Text = "Cheques Amount :";
                txtPayAmt.Enabled = true;
                groupBox1.Visible = true;
            }
            if (cmbPayMeth.SelectedIndex == 2)
            {
                lblAmount.Text = "Credit Amount :";
                txtPayAmt.Enabled = true;
                groupBox1.Visible = false;
            }
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemName.Text == "")
                {
                    cmbSupplier.Focus();
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void cmbSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbSupplier.SelectedIndex > 0)
                {
                    cmbPayMeth.Focus();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                AddSupplier.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void cmbPayMeth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPayMeth.SelectedIndex >= 0)
                {
                    txtPayAmt.Focus();
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtPayAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescri.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtDescri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();

            if (CmnFun.IsValidDecimalNo(txtItemCode.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Item Code");
                txtItemCode.Text = "";
            }
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtChqNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                chqDate.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void chqDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
            BtnClose_KeyDown(sender, e);
        }
    }
}
