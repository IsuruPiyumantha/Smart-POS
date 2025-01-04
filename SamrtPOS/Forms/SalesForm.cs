using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.RestaurantForms;
using SmartPOS.Forms.SupperMarketForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace SmartPOS.Forms
{
    public partial class SalesForm : Form
    {
        private static MySqlConnection con;
        private static CommonFuntion ComFuntion;
        private static string conString = string.Empty;

        private static DataTable itemsTable = null;
        private DataTable dt = null;

        private static InvoiceBillDetails invoiceDetails;
        private static SalesControler saleCont;
        private static ProductControler prodCont;
        private static InvoiceInfo invoiceInfo;

        private PrintDialog p;
        


        public SalesForm()
        {
            invoiceDetails = new InvoiceBillDetails();
            saleCont = new SalesControler();
            prodCont = new ProductControler();

            InitializeComponent();
            SetColors();
            GetAllitems();
        }

        private void SetColors()
        {
            tableLayoutPanel20.BackColor = Color.FromName(Program.col);
            tableLayoutPanel1.BackColor = Color.FromName(Program.col);
            MainPanel.BackColor = Color.FromName(Program.col2);
            tableLayoutPanel3.BackColor = Color.FromName(Program.col2);
            sidePanel.BackColor = Color.FromName(Program.col3);

            GridColourClass styl = new GridColourClass();
            styl.setGridDetails(gridDataDetails);
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
            ComboItemName();
            newForm();
            lbl_shopName.Text = Program.companyProfile.CompanyName.ToString();
        }

        private void ComboItemName()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ID", typeof(int));
            dt2.Columns.Add("item_name", typeof(string));
            dt2.Rows.Add(0, " ");

            if (itemsTable.Rows.Count >= 0)
            {
                foreach (DataRow r in itemsTable.Rows)
                {
                    dt2.Rows.Add(int.Parse(r["ID"].ToString()),r["item_name"].ToString() + " - " + r["labled_price"].ToString());
                }
            }

            txtItemName.DataSource = dt2;
            txtItemName.DisplayMember = "item_name";
            txtItemName.ValueMember = "ID";
            //txtItemName.SelectedIndex = 0;

        }

        private void newForm()
        {
            invoiceDetails = new InvoiceBillDetails();
            saleCont.getServiceCharge(ref invoiceDetails);
            checkCardPayFee.Text = "Card Payment Fee " + invoiceDetails.CardPer + " %";
            checkTax.Text = "TAX " + invoiceDetails.TAXPer + " %";
            CreateDataTable(); 
            invoiceDetails.InvoiceNumber = CurrentInvoiceNumber();
            lblInvoiceNo.Text = invoiceDetails.InvoiceNumber.ToString();
            lblUser.Text = Program.userDetails.UseryName.ToString();
            gridDataDetails.DataSource = null;
            ClearHeadPanel();
            ClearSidepanel();
            
        }

        private void ClearSidepanel()
        {
            lblSubTot.Text = "0.00";
            txtDiscountPer.Text = "";
            txtDiscount.Text = "";
            lblNetTot.Text = "0.00";
            lblCardPayFee.Text = "0.00";
            lblTotAmount.Text = "0.00";
            lblItemCount.Text = "0";
        }

        private DataTable CreateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("item_name", typeof(string));
            dt.Columns.Add("labled_price", typeof(decimal));
            dt.Columns.Add("special_price", typeof(decimal));
            dt.Columns.Add("quantity", typeof(decimal));
            dt.Columns.Add("total_price", typeof(decimal));
            dt.Columns.Add("full_tot_price", typeof(decimal));
            dt.Columns.Add("count", typeof(int));
            return dt;
        }

        private string CurrentInvoiceNumber()
        {
            invoiceDetails.InvoiceNumber = string.Empty;
            invoiceInfo = new InvoiceInfo();
            saleCont = new SalesControler();

            invoiceInfo = saleCont.GetInvoiceInfo();
            DateTime now = DateTime.Now;

            if (now.Date > Convert.ToDateTime(invoiceInfo.InvDate.ToString()))
            {
                bool UpdateInvDate = saleCont.UpdateInvoiceDate(ref invoiceInfo, now.ToString("yyyy/MM/dd"));
            }


            char[] yearArr = now.Year.ToString().ToCharArray();
            string month = now.Month.ToString();
            if (now.Month.ToString().Length == 1)
                month = "0" + month;
            string day = now.Day.ToString();
            if (now.Day.ToString().Length == 1)
                day = "0" + day;
            string invoiceNo = invoiceInfo.InvNumber.ToString();
            string InvoiceCode = invoiceInfo.InvCode.ToString();
            if (invoiceNo.Length == 1)
                invoiceNo = "00" + invoiceNo;
            else if (invoiceNo.Length == 2)
                invoiceNo = "0" + invoiceNo;

            invoiceDetails.InvoiceNumber = InvoiceCode + yearArr[2].ToString() + yearArr[3].ToString() + month + day + invoiceNo;
            bool UpdateInv = saleCont.UpdateNextInvoiceNumber(invoiceInfo.InvNumber, invoiceInfo.InvCode, false);
            return invoiceDetails.InvoiceNumber;
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            bool UpdateInv = saleCont.UpdateNextInvoiceNumber(invoiceInfo.InvNumber, invoiceInfo.InvCode, true);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime nowDateTime = DateTime.Now;
            lblTime.Text = nowDateTime.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            ComFuntion = new CommonFuntion();
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCode.Text != "")
                    {
                        if (ComFuntion.IsValidDecimalNo(txtCode.Text.Trim().ToString()))
                        {
                            int itemID = int.Parse(txtCode.Text.ToString());
                            if (itemID > 0)
                            {
                                DataRow[] dr = itemsTable.Select("ID = '" + itemID + "'");

                                if (dr.Length > 0)
                                {
                                    foreach (DataRow row in dr)
                                    {
                                        txtItemName.Text = row["item_name"].ToString();
                                        txtLabPrice.Text = row["labled_price"].ToString();
                                        txtSpecPrice.Text = row["special_price"].ToString();
                                        txtTotPrice.Text = row["special_price"].ToString();
                                    }
                                    txtQnt.Enabled = true;
                                    txtQnt.Text = "1";
                                    txtQnt.Focus();
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
                        else
                        {
                            MessageBox.Show("please enter numeric.");
                        }
                    }
                    else
                    {
                        txtItemName.Focus();
                        ClearHeadPanel();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

                ShortCutKey(sender, e);
                GridShortCutKey(sender, e);

            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, "");
                errorFrm.ShowDialog();
            }
        }

        private void ClearHeadPanel()
        {
            txtCode.Text = "";
            txtItemName.Text = "";
            txtQnt.Text = "";
            txtSpecPrice.Text = "0.00";
            txtLabPrice.Text = "0.00";
            txtTotPrice.Text = "0.00";
            ComboItemName();
        }

        private void txtQnt_TextChanged(object sender, EventArgs e)
        {
            ComFuntion = new CommonFuntion();

            if (txtQnt.Text != "")
            {
                if (ComFuntion.IsValidDecimalNo(txtQnt.Text) && txtQnt.Text != ".")
                {
                    decimal qnt = decimal.Parse(txtQnt.Text.ToString());
                    if (qnt == 0)
                    {
                        qnt = 1;
                    }
                    decimal price = 0;

                    if (txtSpecPrice.Text != "") //decimal.Parse(txtSpecPrice.Text.ToString()) != 0 || 
                    {
                        price = decimal.Parse(txtSpecPrice.Text.ToString());
                    }
                    else
                    {
                        price = decimal.Parse(txtLabPrice.Text.ToString());
                    }

                    decimal total = qnt * price;
                    txtTotPrice.Text = total.ToString("#.00");
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
            else
            {
                if (txtSpecPrice.Text.ToString() != "") //decimal.Parse(txtSpecPrice.Text.ToString())
                {
                    txtTotPrice.Text = txtSpecPrice.Text;
                }
                else
                {
                    txtTotPrice.Text = txtLabPrice.Text;
                }
            }
        }

        private void ShortCutKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCode.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                txtItemName.Focus();
            }
            if (e.KeyCode == Keys.F3)
            {
                txtQnt.Focus();
            }

            if (e.KeyCode == Keys.F4)
            {
                gridDataDetails.Focus();
            }

            if (e.KeyCode == Keys.F8)
            {
                if (checkCardPayFee.Checked == false)
                {
                    checkCardPayFee.Checked = true;
                }
                else
                {
                    checkCardPayFee.Checked = false;
                }
            }



            if (e.KeyCode == Keys.F9)
            {
                CashBillPrint();
            }
            if (e.KeyCode == Keys.F10)
            {
                CardBillPrint();
            }

            if (e.KeyCode == Keys.F11)
            {
                txtDiscountPer.Focus();
            }
            if (e.KeyCode == Keys.F12)
            {
                txtDiscount.Focus();
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);
        }

        private void txtQnt_KeyDown(object sender, KeyEventArgs e)
        {
            ComFuntion = new CommonFuntion();

            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);

            if (e.KeyCode == Keys.Enter)
            {
                if (txtQnt.Text != "" || txtQnt.Text != null)
                {
                    if (ComFuntion.IsValidDecimalNo(txtQnt.Text.Trim().ToString()))
                    {
                        int itemID = int.Parse(txtCode.Text.ToString());
                        if (itemID > 0)
                        {
                            DataRow[] dr = itemsTable.Select("ID = '" + itemID + "'");

                            if (dr.Length > 0)
                            {
                                foreach (DataRow row in dr)
                                {
                                    int itemCode = int.Parse(row["ID"].ToString());
                                    string itemName = row["item_name"].ToString();
                                    decimal labPrice = Convert.ToDecimal(row["labled_price"].ToString());
                                    decimal spePrice = Convert.ToDecimal(row["special_price"].ToString());
                                    if (spePrice == 0)
                                    {
                                        spePrice = labPrice;
                                    }
                                    decimal qunt = Convert.ToDecimal(txtQnt.Text.ToString());
                                    decimal totPrice = spePrice * qunt;
                                    decimal fullTotPrice = labPrice * qunt;

                                    if (gridDataDetails.Rows.Count > 0)
                                    {
                                        DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                                        if (rowsToUpdate.Length > 0)
                                        {
                                            foreach (DataRow row2 in rowsToUpdate)
                                            {
                                                // Update the Quantity and Total
                                                // For demonstration, we'll add 1 to Quantity and update the Total accordingly
                                                decimal currentQuantity = Convert.ToDecimal(row2["quantity"].ToString());
                                                decimal currentPrice = Convert.ToDecimal(row2["labled_price"].ToString());
                                                decimal currentSpePrice = Convert.ToDecimal(row2["special_price"].ToString());
                                                decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());
                                                decimal currentFullTotal = Convert.ToDecimal(row2["full_tot_price"].ToString());

                                                row2["quantity"] = currentQuantity + qunt;
                                                row2["total_price"] = ((currentQuantity + qunt) * currentSpePrice).ToString("#.00");
                                                row2["full_tot_price"] = ((currentQuantity + qunt) * currentPrice).ToString("#.00");

                                                for (int a = 0; a < dt.Rows.Count; a++)
                                                {
                                                    dt.Rows[a]["count"] = a + 1;
                                                }
                                                gridDataDetails.AutoGenerateColumns = false;
                                                gridDataDetails.DataSource = dt;
                                                GetFullTotalPrice();

                                                ClearHeadPanel();
                                                ComboItemName();
                                                txtCode.Focus();
                                            }
                                        }
                                        else
                                        {
                                            dt.Rows.Add(itemCode, itemName, labPrice, spePrice, qunt, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                            for (int a = 0; a < dt.Rows.Count; a++)
                                            {
                                                dt.Rows[a]["count"] = a + 1;
                                            }



                                            gridDataDetails.AutoGenerateColumns = false;
                                            gridDataDetails.DataSource = dt;
                                            GetFullTotalPrice();

                                            ClearHeadPanel();
                                            txtCode.Focus();
                                        }
                                    }
                                    else
                                    {
                                        dt.Rows.Add(itemCode, itemName, labPrice, spePrice, qunt, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }
                                        gridDataDetails.AutoGenerateColumns = false;
                                        gridDataDetails.DataSource = dt;
                                        GetFullTotalPrice();

                                        ClearHeadPanel();
                                        txtCode.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalide Item Code.");
                        }
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtSpecPrice_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCode.Text != "")
            {
                string Barcode = txtCode.Text.ToString();
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
                    if (dr.Length == 1)
                    {
                        foreach (DataRow row in dr)
                        {
                            int itemCode = int.Parse(row["ID"].ToString());
                            string itemName = row["item_name"].ToString();
                            decimal labPrice = Convert.ToDecimal(row["labled_price"].ToString());
                            decimal spePrice = Convert.ToDecimal(row["special_price"].ToString());
                            if (spePrice == 0)
                            {
                                spePrice = labPrice;
                            }
                            decimal totPrice = spePrice * 1;
                            decimal fullTotPrice = labPrice * 1;

                            if (gridDataDetails.Rows.Count > 0)
                            {
                                DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                                if (rowsToUpdate.Length > 0)
                                {
                                    foreach (DataRow row2 in rowsToUpdate)
                                    {
                                        // Update the Quantity and Total
                                        // For demonstration, we'll add 1 to Quantity and update the Total accordingly
                                        decimal currentQuantity = Convert.ToDecimal(row2["quantity"].ToString());
                                        decimal currentPrice = Convert.ToDecimal(row2["labled_price"].ToString());
                                        decimal currentSpePrice = Convert.ToDecimal(row2["special_price"].ToString());
                                        decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());
                                        decimal currentFullTotal = Convert.ToDecimal(row2["full_tot_price"].ToString());

                                        row2["quantity"] = currentQuantity + 1;
                                        row2["total_price"] = ((currentQuantity + 1) * currentSpePrice).ToString("#.00");
                                        row2["full_tot_price"] = ((currentQuantity + 1) * currentPrice).ToString("#.00");

                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }
                                        gridDataDetails.AutoGenerateColumns = false;
                                        gridDataDetails.DataSource = dt;
                                        GetFullTotalPrice();
                                        txtCode.Focus();
                                        txtCode.Text = null;
                                    }
                                }
                                else
                                {
                                    dt.Rows.Add(itemCode, itemName, labPrice, spePrice, 1, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        dt.Rows[a]["count"] = a + 1;
                                    }



                                    gridDataDetails.AutoGenerateColumns = false;
                                    gridDataDetails.DataSource = dt;
                                    GetFullTotalPrice();
                                    txtCode.Focus();
                                    txtCode.Text = null;
                                }
                            }
                            else
                            {
                                dt.Rows.Add(itemCode, itemName, labPrice, spePrice, 1, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                for (int a = 0; a < dt.Rows.Count; a++)
                                {
                                    dt.Rows[a]["count"] = a + 1;
                                }
                                gridDataDetails.AutoGenerateColumns = false;
                                gridDataDetails.DataSource = dt;
                                GetFullTotalPrice();
                                txtCode.Focus();
                                txtCode.Text = null;
                            }
                        }
                    }
                    else if (dr.Length > 1)
                    {
                        DataTable dt2 = new DataTable();
                        dt2.Columns.Add("ID", typeof(int));
                        dt2.Columns.Add("item_name", typeof(string));
                        dt2.Rows.Add(0, " ");
                        foreach (DataRow row in dr)
                        {
                            dt2.Rows.Add(int.Parse(row["ID"].ToString()), row["item_name"].ToString() + " - " + row["labled_price"].ToString());
                        }
                        txtItemName.DataSource = dt2;
                        txtItemName.DisplayMember = "item_name";
                        txtItemName.ValueMember = "ID";
                        txtItemName.SelectedIndex = 1;
                        txtItemName.Focus();
                    }
                }
                if (txtCode.Text.Length == 10)
                {
                    string barcode = txtCode.Text;

                    string itemCode = int.Parse(barcode.Substring(0, 5)).ToString();
                    decimal weight = decimal.Parse(barcode.Substring(5, 5)) / 1000;

                    DataRow[] drr = itemsTable.Select("ID = '" + itemCode + "'");

                    if (drr.Length > 0)
                    {
                        foreach (DataRow row in drr)
                        {
                            string itemName = row["item_name"].ToString();
                            decimal labPrice = Convert.ToDecimal(row["labled_price"].ToString());
                            decimal spePrice = Convert.ToDecimal(row["special_price"].ToString());
                            if (spePrice == 0)
                            {
                                spePrice = labPrice;
                            }
                            decimal totPrice = spePrice * weight;
                            decimal fullTotPrice = labPrice * weight;

                            if (gridDataDetails.Rows.Count > 0)
                            {
                                DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                                if (rowsToUpdate.Length > 0)
                                {
                                    foreach (DataRow row2 in rowsToUpdate)
                                    {
                                        // Update the Quantity and Total
                                        // For demonstration, we'll add 1 to Quantity and update the Total accordingly
                                        decimal currentQuantity = Convert.ToDecimal(row2["quantity"].ToString());
                                        decimal currentPrice = Convert.ToDecimal(row2["labled_price"].ToString());
                                        decimal currentSpePrice = Convert.ToDecimal(row2["special_price"].ToString());
                                        decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());
                                        decimal currentFullTotal = Convert.ToDecimal(row2["full_tot_price"].ToString());

                                        row2["quantity"] = currentQuantity + weight;
                                        row2["total_price"] = ((currentQuantity + weight) * currentSpePrice).ToString("#.00");
                                        row2["full_tot_price"] = ((currentQuantity + weight) * currentPrice).ToString("#.00");

                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }
                                        gridDataDetails.AutoGenerateColumns = false;
                                        gridDataDetails.DataSource = dt;
                                        GetFullTotalPrice();
                                        txtCode.Focus();
                                        txtCode.Text = null;
                                    }
                                }
                                else
                                {
                                    dt.Rows.Add(itemCode, itemName, labPrice, spePrice, weight, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        dt.Rows[a]["count"] = a + 1;
                                    }



                                    gridDataDetails.AutoGenerateColumns = false;
                                    gridDataDetails.DataSource = dt;
                                    GetFullTotalPrice();
                                    txtCode.Focus();
                                    txtCode.Text = null;
                                }
                            }
                            else
                            {
                                dt.Rows.Add(itemCode, itemName, labPrice, spePrice, weight, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                for (int a = 0; a < dt.Rows.Count; a++)
                                {
                                    dt.Rows[a]["count"] = a + 1;
                                }
                                gridDataDetails.AutoGenerateColumns = false;
                                gridDataDetails.DataSource = dt;
                                GetFullTotalPrice();
                                txtCode.Focus();
                                txtCode.Text = null;
                            }
                        }
                    }
                }
                else if (txtCode.Text.Length > 6)
                {
                    string barcode = txtCode.Text;

                    string itemCode = int.Parse(barcode.Substring(6)).ToString();

                    DataRow[] drr = itemsTable.Select("ID = '" + itemCode + "'");

                    if (drr.Length > 0)
                    {
                        foreach (DataRow row in drr)
                        {
                            string itemName = row["item_name"].ToString();
                            decimal labPrice = Convert.ToDecimal(row["labled_price"].ToString());
                            decimal spePrice = Convert.ToDecimal(row["special_price"].ToString());
                            if (spePrice == 0)
                            {
                                spePrice = labPrice;
                            }
                            decimal totPrice = spePrice * 1;
                            decimal fullTotPrice = labPrice * 1;

                            if (gridDataDetails.Rows.Count > 0)
                            {
                                DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                                if (rowsToUpdate.Length > 0)
                                {
                                    foreach (DataRow row2 in rowsToUpdate)
                                    {
                                        // Update the Quantity and Total
                                        // For demonstration, we'll add 1 to Quantity and update the Total accordingly
                                        decimal currentQuantity = Convert.ToDecimal(row2["quantity"].ToString());
                                        decimal currentPrice = Convert.ToDecimal(row2["labled_price"].ToString());
                                        decimal currentSpePrice = Convert.ToDecimal(row2["special_price"].ToString());
                                        decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());
                                        decimal currentFullTotal = Convert.ToDecimal(row2["full_tot_price"].ToString());

                                        row2["quantity"] = currentQuantity + 1;
                                        row2["total_price"] = ((currentQuantity + 1) * currentSpePrice).ToString("#.00");
                                        row2["full_tot_price"] = ((currentQuantity + 1) * currentPrice).ToString("#.00");

                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }
                                        gridDataDetails.AutoGenerateColumns = false;
                                        gridDataDetails.DataSource = dt;
                                        GetFullTotalPrice();
                                        txtCode.Focus();
                                        txtCode.Text = null;
                                    }
                                }
                                else
                                {
                                    dt.Rows.Add(itemCode, itemName, labPrice, spePrice, 1, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        dt.Rows[a]["count"] = a + 1;
                                    }



                                    gridDataDetails.AutoGenerateColumns = false;
                                    gridDataDetails.DataSource = dt;
                                    GetFullTotalPrice();
                                    txtCode.Focus();
                                    txtCode.Text = null;
                                }
                            }
                            else
                            {
                                dt.Rows.Add(itemCode, itemName, labPrice, spePrice, 1, totPrice.ToString("#.00"), fullTotPrice.ToString("#.00"));
                                for (int a = 0; a < dt.Rows.Count; a++)
                                {
                                    dt.Rows[a]["count"] = a + 1;
                                }
                                gridDataDetails.AutoGenerateColumns = false;
                                gridDataDetails.DataSource = dt;
                                GetFullTotalPrice();
                                txtCode.Focus();
                                txtCode.Text = null;
                            }
                        }
                    }
                }
            }
            else
            {
                ClearHeadPanel();
            }
        }

        private void GetFullTotalPrice()
        {

            if (dt.Rows.Count > 0)
            {
                int numberOfRecords = dt.Rows.Count;
                lblItemCount.Text = numberOfRecords.ToString();
                decimal totLabPrice = 0;
                decimal totSpePrice = 0;

                foreach (DataRow r in dt.Rows)
                {
                    decimal labPrice = decimal.Parse(r["labled_price"].ToString());
                    decimal spePrice = decimal.Parse(r["special_price"].ToString());
                    decimal qnt = decimal.Parse(r["quantity"].ToString());

                    totLabPrice = totLabPrice + (labPrice * qnt);
                    totSpePrice = totSpePrice + (spePrice * qnt);
                }

                lblSubTot.Text = totLabPrice.ToString("#.00");
                invoiceDetails.SubTotalAmount = decimal.Parse(lblSubTot.Text.ToString());
                
                decimal disc = totLabPrice - totSpePrice;
                txtDiscount.Text = disc.ToString("#.00");
                invoiceDetails.DiscountAmount = decimal.Parse(txtDiscount.Text.ToString());

                decimal cardfee = decimal.Parse(lblCardPayFee.Text.ToString());
                decimal tax = decimal.Parse(lblTAX.Text.ToString());


                invoiceDetails.NetTotalAmount = invoiceDetails.SubTotalAmount + cardfee + tax;
                lblNetTot.Text = invoiceDetails.NetTotalAmount.ToString("#.00");

                invoiceDetails.TotalAmount = invoiceDetails.NetTotalAmount - disc;
                lblTotAmount.Text = invoiceDetails.TotalAmount.ToString("#.00");
                

            }
            else
            {
                lblTotAmount.Text = "0.00";
            }
        }

        private void GridShortCutKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                // Specify the column index (3rd column is index 2) and row index
                int columnIndex = 3; // 3rd column (0-based index)
                int rowIndex = gridDataDetails.CurrentCell.RowIndex; // Current row

                // Ensure the indices are valid and within bounds
                if (rowIndex < gridDataDetails.Rows.Count && columnIndex < gridDataDetails.Columns.Count)
                {
                    // Set the selected cell in the DataGridView to the desired one
                    gridDataDetails.CurrentCell = gridDataDetails.Rows[rowIndex].Cells[columnIndex];
                    gridDataDetails.BeginEdit(true); // Focus and start editing the selected cell
                    //gridDataDetails.Rows[rowIndex].Cells[columnIndex].Selected = true; 
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                // Specify the column index (3rd column is index 2) and row index
                int columnIndex = 4; // 3rd column (0-based index)
                int rowIndex = gridDataDetails.CurrentCell.RowIndex; // Current row

                // Ensure the indices are valid and within bounds
                if (rowIndex < gridDataDetails.Rows.Count && columnIndex < gridDataDetails.Columns.Count)
                {
                    // Set the selected cell in the DataGridView to the desired one
                    gridDataDetails.CurrentCell = gridDataDetails.Rows[rowIndex].Cells[columnIndex];
                    gridDataDetails.BeginEdit(true); // Focus and start editing the selected cell
                    //gridDataDetails.Rows[rowIndex].Cells[columnIndex].Selected = true; 
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                // Specify the column index (3rd column is index 2) and row index
                int columnIndex = 5; // 3rd column (0-based index)
                int rowIndex = gridDataDetails.CurrentCell.RowIndex; // Current row

                // Ensure the indices are valid and within bounds
                if (rowIndex < gridDataDetails.Rows.Count && columnIndex < gridDataDetails.Columns.Count)
                {
                    // Set the selected cell in the DataGridView to the desired one
                    gridDataDetails.CurrentCell = gridDataDetails.Rows[rowIndex].Cells[columnIndex];
                    gridDataDetails.BeginEdit(true); // Focus and start editing the selected cell
                    //gridDataDetails.Rows[rowIndex].Cells[columnIndex].Selected = true; 
                }
            }
        }

        private void gridDataDetails_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);
            

            if (e.KeyCode == Keys.Delete)
            {
                string id = "";
                foreach (DataGridViewRow row in gridDataDetails.SelectedRows)
                {
                    id = gridDataDetails.Rows[row.Index].Cells["ID"].Value.ToString();
                }

                if (string.IsNullOrEmpty(id) == false && MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteItemFromDt(int.Parse(id.ToString()));
                }

            }
        }

        private void gridDataDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (gridDataDetails.DataSource != null)
            {
                int columnIndex = gridDataDetails.CurrentCell.ColumnIndex;
                int rowIndex = gridDataDetails.CurrentCell.RowIndex;

                decimal itemCode = int.Parse(gridDataDetails.Rows[rowIndex].Cells[1].Value.ToString());
                decimal qnt = decimal.Parse(gridDataDetails.Rows[rowIndex].Cells[3].Value.ToString());
                decimal spePrice = decimal.Parse(gridDataDetails.Rows[rowIndex].Cells[5].Value.ToString());

                decimal total = spePrice * qnt;
                gridDataDetails.CurrentCell = gridDataDetails.Rows[rowIndex].Cells[6];

                DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                if (rowsToUpdate.Length > 0)
                {
                    foreach (DataRow row in rowsToUpdate)
                    {
                        decimal currentPrice = Convert.ToDecimal(row["special_price"].ToString());
                        decimal currentTotal = Convert.ToDecimal(row["total_price"].ToString());
                        row["total_price"] = (qnt * currentPrice).ToString("#.00");

                    }
                }
                this.dt = new DataTable();
                this.dt = (DataTable)(gridDataDetails.DataSource);
                GetFullTotalPrice();
            }
        }

        private void btnCashPay_Click(object sender, EventArgs e)
        {
            CashBillPrint();
        }

        private void CashBillPrint()
        {
            if (checkCardPayFee.Checked == true)
            {
                MessageBox.Show("Card Payment Fee Remove");
            }
            else
            {
                invoiceDetails.PayAmount = 0;
                invoiceDetails.BalenceAmoun = 0;
                CashPay cashPay = new CashPay(invoiceDetails, dt);
                cashPay.ShowDialog();
                if (cashPay.Msg)
                    newForm();
            }
        }

        private void btnCardPay_Click(object sender, EventArgs e)
        {
            CardBillPrint();
        }

        private void CardBillPrint()
        {
            invoiceDetails.PayAmount = 0;
            invoiceDetails.BalenceAmoun = 0;
            CardPay cardPay = new CardPay(invoiceDetails, dt);
            cardPay.ShowDialog();
            if (cardPay.Msg)
                newForm();
        }

        private void gridDataDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                    if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteItemFromDt(int.Parse(id.ToString()));
                    }
                }
            }
        }

        private void DeleteItemFromDt(int ItemID)
        {
            DataRow[] rows = dt.Select("ID = '" + ItemID + "'"); 
            foreach (DataRow row in rows)
                dt.Rows.Remove(row);
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                dt.Rows[a]["count"] = a + 1;
            }
            gridDataDetails.AutoGenerateColumns = false;
            gridDataDetails.DataSource = dt;
            GetFullTotalPrice();
        }

        private void txtItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            ComFuntion = new CommonFuntion();
            if(txtDiscount.Text != "")
            {
                if (ComFuntion.IsValidDecimalNo(txtDiscount.Text))
                {
                    decimal disc = decimal.Parse(txtDiscount.Text.ToString());
                    invoiceDetails.DiscountAmount = decimal.Parse(txtDiscount.Text.ToString());

                    decimal cardfee = decimal.Parse(lblCardPayFee.Text.ToString());
                    decimal tax = decimal.Parse(lblTAX.Text.ToString());


                    invoiceDetails.NetTotalAmount = invoiceDetails.SubTotalAmount + cardfee + tax;
                    lblNetTot.Text = invoiceDetails.NetTotalAmount.ToString("#.00");

                    invoiceDetails.TotalAmount = invoiceDetails.NetTotalAmount - disc;
                    lblTotAmount.Text = invoiceDetails.TotalAmount.ToString("#.00");
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
        }

        private void txtDiscountPer_TextChanged(object sender, EventArgs e)
        {
            ComFuntion = new CommonFuntion();
            if (txtDiscountPer.Text != "")
            {
                if (ComFuntion.IsValidDecimalNo(txtDiscountPer.Text))
                {
                    decimal discPer = decimal.Parse(txtDiscountPer.Text.ToString());
                    decimal DiscountAmt = invoiceDetails.NetTotalAmount * discPer / 100;
                    txtDiscount.Text = DiscountAmt.ToString("#.00");
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
            else
            {
                GetFullTotalPrice();
            }
        }

        private void checkCardPayFee_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkCardPayFee.Checked)
            
            {
                invoiceDetails.AddCardPaymentFee = true;
                invoiceDetails.CardPaymentFee = (invoiceDetails.NetTotalAmount * invoiceDetails.CardPer) / 100;
                invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount + invoiceDetails.CardPaymentFee;
                lblCardPayFee.Text = invoiceDetails.CardPaymentFee.ToString("#.00");
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
                txtDiscountPer.Text = "";
                GetFullTotalPrice();
            }
            else
            {
                invoiceDetails.AddCardPaymentFee = false;
                invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount - invoiceDetails.CardPaymentFee;
                invoiceDetails.CardPaymentFee = 0;
                lblCardPayFee.Text = invoiceDetails.CardPaymentFee.ToString("#.00");
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
                txtDiscountPer.Text = "";
                GetFullTotalPrice();
            }
        }

        private void checkTax_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkTax.Checked)
            {
                invoiceDetails.AddTAX = true;
                invoiceDetails.TAX = (invoiceDetails.SubTotalAmount * invoiceDetails.TAXPer) / 100;
                invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount + invoiceDetails.TAX;
                lblTAX.Text = invoiceDetails.TAX.ToString("#.00");
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
                GetFullTotalPrice();
            }
            else
            {
                invoiceDetails.AddTAX = false;
                invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount - invoiceDetails.TAX;
                invoiceDetails.TAX = 0;
                lblTAX.Text = invoiceDetails.TAX.ToString("#.00");
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
                GetFullTotalPrice();
            }
        }

        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
            GridShortCutKey(sender, e);
        }

        private void checkCardPayFee_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void checkTax_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show("Do You Want to Exit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void txtItemName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                                txtCode.Text = row["ID"].ToString();
                                txtLabPrice.Text = row["labled_price"].ToString();
                                txtSpecPrice.Text = row["special_price"].ToString();
                                txtTotPrice.Text = row["special_price"].ToString();
                            }
                            txtQnt.Enabled = true;
                            txtQnt.Text = "1";
                            txtQnt.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Invalide Item Code.");
                        }
                    }
                }
            }
            else
            {
                ShortCutKey(sender, e);
            }
        }

        private void txtItemName_Enter(object sender, EventArgs e)
        {
            if(Program.IsEng == false)
            {
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("si-LK"));
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (Program.IsEng == false)
            {
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
            }
        }
    }
}
