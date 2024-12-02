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
using CrystalDecisions.Windows.Forms;
using SmartPOS.Forms.RestaurantForms;
using SmartPOS.Forms.SettingsForms.PrintigSetting;
using CrystalDecisions.CrystalReports.Engine;

namespace SmartPOS.Forms
{
    public partial class RestaurantSale : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        private static CommonFuntion ComFuntion;
        private static SalesControler saleCont;
        private static InvoiceInfo invoiceInfo;
        private static AllTableInfo tableInfo;
        private static InvoiceBillDetails invoiceDetails;

        private static DataTable CategoryTable = new DataTable();
        private static DataTable AllItemsTable = new DataTable();

        private static DataTable ItemsGridTable = new DataTable();
        private static DataTable dt = new DataTable();
        private Button b;
        public bool payCancel = false;
        


        public RestaurantSale()
        {
            InitializeComponent();
        }

        public RestaurantSale(Button b, object Tag)
        {
            this.Tag = Tag;
            this.b = b;
            saleCont = new SalesControler();
            invoiceDetails = new InvoiceBillDetails();

            InitializeComponent();
            SetColors();

            CategoryTable = saleCont.GetAllCategory();
            if (CategoryTable.Rows.Count > 0)
            {
                gridDataDetails.AutoGenerateColumns = false;
                gridDataDetails.DataSource = CategoryTable;
            }
            AllItemsTable = saleCont.GetAllItems();

            invoiceDetails.InvoiceNumber = CurrentInvoiceNumber();
            lblInvoiceNo.Text = invoiceDetails.InvoiceNumber.ToString();

            invoiceDetails.TableName = b.Text;
            lbl_TableName.Text = invoiceDetails.TableName.ToString();

            lblUser.Text = Program.userDetails.UseryName.ToString();


            invoiceDetails.InvoiceID = saleCont.insertNewInvoiceDetails(invoiceDetails.InvoiceNumber, invoiceDetails.TableName);

            saleCont.getServiceCharge(ref invoiceDetails);

            checkServiceChg.Text = "Service Charge " + invoiceDetails.ServiePer + " %";
            checkCardPayFee.Text = "Card Payment Fee " + invoiceDetails.CardPer + " %";
            checkTax.Text = "TAX " + invoiceDetails.TAXPer + " %";

            dt = CreateDataTable();
            SetPrintReport();
        }

        public RestaurantSale(Button b, object Tag, AllTableInfo tableInfo)
        {
            saleCont = new SalesControler();
            invoiceDetails = new InvoiceBillDetails();

            this.Tag = Tag;

            InitializeComponent();
            SetColors();

            CategoryTable = saleCont.GetAllCategory();
            if (CategoryTable.Rows.Count > 0)
            {
                gridDataDetails.AutoGenerateColumns = false;
                gridDataDetails.DataSource = CategoryTable;
            }
            AllItemsTable = saleCont.GetAllItems();
            invoiceDetails.InvoiceID = tableInfo.InvID;

            invoiceDetails = saleCont.getOldInvoiceNo(invoiceDetails.InvoiceID);
            invoiceDetails.TableName = b.Text;
            lbl_TableName.Text = invoiceDetails.TableName.ToString();
            lblInvoiceNo.Text = invoiceDetails.InvoiceNumber.ToString();

            SetChagers();

            lblUser.Text = Program.userDetails.UseryName.ToString();

            saleCont.getServiceCharge(ref invoiceDetails);

            checkServiceChg.Text = "Service Charge " + invoiceDetails.ServiePer + " %";
            checkCardPayFee.Text = "Card Payment Fee " + invoiceDetails.CardPer + " %";
            checkTax.Text = "TAX " + invoiceDetails.TAXPer + " %";


            dt = saleCont.getSalesDetails(invoiceDetails.InvoiceID);
            SetPrintReport();

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
            GetFullTotalPrice();
        }

        private void SetPrintReport()
        {
            CrystalReportViewer viever = new CrystalReportViewer();
            BillPrintingControler billPrintingControler = new BillPrintingControler();
            List<BillMargingInfo> listBillInfo = new List<BillMargingInfo>();
            listBillInfo = billPrintingControler.LoadBillSetingDataForSelectedObject("Restaurant_Table_Bill");

            TableBill tableBill = new TableBill();
            tableBill.SetDataSource(dt);

            this.SetParameterAlign(tableBill, "InvoiceNumber1", listBillInfo.Find(x => x.Value_Name == "Invoice No "));
            this.SetParameterAlign(tableBill, "TableName1", listBillInfo.Find(x => x.Value_Name == "Table Name"));
            this.SetParameterAlign(tableBill, "Date1", listBillInfo.Find(x => x.Value_Name == "Date"));
            this.SetParameterAlign(tableBill, "Time1", listBillInfo.Find(x => x.Value_Name == "Time"));
            this.SetParameterAlign(tableBill, "SubTotal1", listBillInfo.Find(x => x.Value_Name == "Sub Total"));
            this.SetParameterAlign(tableBill, "ServiceChg1", listBillInfo.Find(x => x.Value_Name == "Service Charge"));
            this.SetParameterAlign(tableBill, "Total1", listBillInfo.Find(x => x.Value_Name == "Full Total"));
            this.SetParameterAlign(tableBill, "Casher1", listBillInfo.Find(x => x.Value_Name == "Casher"));


            tableBill.SetParameterValue("InvoiceNumber", invoiceDetails.InvoiceNumber);
            tableBill.SetParameterValue("TableName", invoiceDetails.TableName);
            tableBill.SetParameterValue("Date", DateTime.Now.ToShortDateString());
            tableBill.SetParameterValue("Time", DateTime.Now.ToShortTimeString());
            tableBill.SetParameterValue("SubTotal", invoiceDetails.SubTotalAmount);
            tableBill.SetParameterValue("ServiceChg", invoiceDetails.ServiceCharge);
            tableBill.SetParameterValue("Total", invoiceDetails.NetTotalAmount);
            tableBill.SetParameterValue("Casher", Program.userDetails.UseryName);

            viever.ReportSource = tableBill;
        }

        private void SetChagers()
        {
            if (invoiceDetails.AddServiceChg == true)
            {
                checkServiceChg.Checked = true;
                AddServiceChg();
            }
            else
            {
                checkServiceChg.Checked = false;
                RemoveServiceChg();
            }
            if (invoiceDetails.AddCardPaymentFee == true)
            {
                checkCardPayFee.Checked = true;
                AddCardFee();
            }
            else
            {
                checkCardPayFee.Checked = false;
                RemoveCardFee();
            }
            if (invoiceDetails.AddTAX == true)
            {
                checkTax.Checked = true;
                AddTax();
            }
            else
            {
                checkTax.Checked = false;
                RemoveTax();
            }
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
            styl.setGridDetails(dataGridView1);
            styl.setGridDetails(dataGridView2);
        }

        public string CurrentInvoiceNumber()
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

        private DataTable CreateDataTable()
        {
            dt = new DataTable();

            
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("item_name", typeof(string));
            dt.Columns.Add("labled_price", typeof(decimal));
            dt.Columns.Add("quantity", typeof(string));
            dt.Columns.Add("total_price", typeof(decimal));
            dt.Columns.Add("KOT", typeof(int));
            dt.Columns.Add("count", typeof(int));
            

            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            txtCode.Focus();
        }

        private void gridDataDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ItemsGridTable = new DataTable();
            saleCont = new SalesControler();

            if (e.RowIndex >= 0)
            {
                string id = gridDataDetails.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                if(id != "0")
                {
                    ItemsGridTable = saleCont.SelectItemsForCategoryID(id);
                    dataSourceItemGrid();
                }
            }
        }

        private void dataSourceItemGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ItemsGridTable;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.NotifyCurrentCellDirty(true);
            dataGridView1.EndEdit();
            try
            {
                if (dataGridView1.IsCurrentCellDirty)
                {
                    dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("please enter numeric");
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "quantity")
            {
                dataGridView1.Invalidate();
            }
            if (e.RowIndex >= 0)
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value.ToString();

                if (id != "0")
                {
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        if (r.Cells["quantity"].Value != null)
                        {
                            try
                            {
                                int itemCode = int.Parse(r.Cells["dataGridViewTextBoxColumn1"].Value.ToString());
                                string itemName = r.Cells["item_name"].Value.ToString();
                                decimal price = Convert.ToDecimal(r.Cells["labled_price"].Value.ToString());
                                decimal qunt = Convert.ToDecimal(r.Cells["quantity"].Value.ToString());
                                decimal totPrice = price * qunt;
                                int KOT = int.Parse(r.Cells["kot_item"].Value.ToString());
                                bool kot = Convert.ToBoolean(KOT);

                                if (dataGridView2.Rows.Count > 0)
                                {
                                    DataRow[] rowsToUpdate = dt.Select("ID = '" + itemCode + "'");

                                    if (rowsToUpdate.Length > 0)
                                    {
                                        foreach (DataRow row in rowsToUpdate)
                                        {
                                            // Update the Quantity and Total
                                            // For demonstration, we'll add 1 to Quantity and update the Total accordingly
                                            decimal currentQuantity = Convert.ToDecimal(row["quantity"].ToString());
                                            decimal currentPrice = Convert.ToDecimal(row["labled_price"].ToString());
                                            decimal currentTotal = Convert.ToDecimal(row["total_price"].ToString());

                                            row["quantity"] = currentQuantity + qunt;
                                            row["total_price"] = ((currentQuantity + qunt) * currentPrice).ToString("#.00");

                                            r.Cells["quantity"].Value = null;
                                            for (int a = 0; a < dt.Rows.Count; a++)
                                            {
                                                dt.Rows[a]["count"] = a + 1;
                                            }
                                            InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);
                                            dataGridView2.AutoGenerateColumns = false;
                                            dataGridView2.DataSource = dt;
                                            GetFullTotalPrice();
                                        }
                                    }
                                    else
                                    {
                                        r.Cells["quantity"].Value = null;
                                        dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }
                                        InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);
                                        dataGridView2.AutoGenerateColumns = false;
                                        dataGridView2.DataSource = dt;
                                        GetFullTotalPrice();
                                    }
                                }

                                else
                                {
                                    r.Cells["quantity"].Value = null;
                                    dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        dt.Rows[a]["count"] = a + 1;
                                    }
                                    InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);
                                    dataGridView2.AutoGenerateColumns = false;
                                    dataGridView2.DataSource = dt;
                                    GetFullTotalPrice();
                                }
                            }
                            catch (FormatException)
                            {
                                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            }
                            catch (Exception ex)
                            {
                                ErrorForm errorFrm = new ErrorForm(ex.Message, "");
                                errorFrm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private void txtItemQnt_KeyDown(object sender, KeyEventArgs e)
        {
            ComFuntion = new CommonFuntion();

            if (e.KeyCode == Keys.Enter)
            {
                if (txtItemQnt.Text != "")
                {
                    if (ComFuntion.IsValidDecimalNo(txtItemQnt.Text.Trim().ToString()))
                    {
                        int itemID = int.Parse(txtCode.Text.ToString());
                        if (itemID > 0)
                        {
                            DataRow[] dr = AllItemsTable.Select("ID = '" + itemID + "'");

                            if (dr.Length > 0)
                            {
                                foreach (DataRow row in dr)
                                {
                                    int itemCode = int.Parse(row["ID"].ToString());
                                    string itemName = row["item_name"].ToString();
                                    decimal price = Convert.ToDecimal(row["labled_price"].ToString());
                                    decimal qunt = Convert.ToDecimal(txtItemQnt.Text.ToString());
                                    decimal totPrice = price * qunt;
                                    int KOT = int.Parse(row["kot_item"].ToString());
                                    bool kot = Convert.ToBoolean(KOT);

                                    if (dataGridView2.Rows.Count > 0)
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
                                                decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());

                                                row2["quantity"] = currentQuantity + qunt;
                                                row2["total_price"] = ((currentQuantity + qunt) * currentPrice).ToString("#.00");

                                                for (int a = 0; a < dt.Rows.Count; a++)
                                                {
                                                    dt.Rows[a]["count"] = a + 1;
                                                }
                                                InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);
                                                dataGridView2.AutoGenerateColumns = false;
                                                dataGridView2.DataSource = dt;
                                                GetFullTotalPrice();

                                                txtCode.Text = "";
                                                txtItemQnt.Text = "";
                                                txtItemQnt.Visible = false;
                                                txtCode.Enabled = true;
                                                txtCode.Focus();
                                            }
                                        }
                                        else
                                        {
                                            dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                                            for (int a = 0; a < dt.Rows.Count; a++)
                                            {
                                                dt.Rows[a]["count"] = a + 1;
                                            }
                                            InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);



                                            dataGridView2.AutoGenerateColumns = false;
                                            dataGridView2.DataSource = dt;
                                            GetFullTotalPrice();

                                            txtCode.Text = "";
                                            txtItemQnt.Text = "";
                                            txtItemQnt.Visible = false;
                                            txtCode.Enabled = true;
                                            txtCode.Focus();
                                        }
                                    }
                                    else
                                    {
                                        dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                                        for (int a = 0; a < dt.Rows.Count; a++)
                                        {
                                            dt.Rows[a]["count"] = a + 1;
                                        }

                                        InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending",kot);




                                        dataGridView2.AutoGenerateColumns = false;
                                        dataGridView2.DataSource = dt;
                                        GetFullTotalPrice();

                                        txtCode.Text = "";
                                        txtItemQnt.Text = "";
                                        txtItemQnt.Visible = false;
                                        txtCode.Enabled = true;
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
                    else
                    {
                        MessageBox.Show("please enter numeric.");
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void InsertSalesTable(int itemCode, string itemName, decimal price, decimal qunt, decimal totPrice,string status,bool kot)
        {
            ComFuntion = new CommonFuntion();
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            string sql = string.Empty;
            int cUser = Program.userDetails.UserID;
            string nowDate = ComFuntion.convertDateTime(DateTime.Now);

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {

                        sql = "INSERT INTO tbl_pos_restaurant_sales (InvoiceID,TableName, ItemsCode, ItemsName, Price, Quantity, TotalPrice, KOT, Status, cDate, cUser) VALUES ('" + invoiceDetails.InvoiceID + "','" + invoiceDetails.TableName + "', '" + itemCode + "', '" + itemName + "', '" + price + "', '" + qunt + "', '" + totPrice + "', '" + Convert.ToInt16(kot) + "', '" + status + "', '" + nowDate + "','" + cUser + "');";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
        }

        private void updateSalesTable(int ItemID, string status)
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);
            string sql = string.Empty;
            int cUser = Program.userDetails.UserID;

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {

                        sql = "UPDATE tbl_pos_restaurant_sales tprs SET tprs.Status = '" + status + "' WHERE tprs.ItemsCode = '" + ItemID + "';";
                        MySqlCommand cmd = new MySqlCommand(sql, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sql);
                errorFrm.ShowDialog();
            }
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
                                DataRow[] dr = AllItemsTable.Select("ID = '" + itemID + "'");

                                if (dr.Length > 0)
                                {
                                    txtItemQnt.Visible = true;
                                    txtItemQnt.Text = "1";
                                    txtCode.Enabled = false;
                                    txtItemQnt.Focus();
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
                        txtCategoryName.Focus();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception a)
            {
                ErrorForm errorFrm = new ErrorForm(a.Message, "");
                errorFrm.ShowDialog();
            }

            if (e.KeyCode == Keys.Down)
            {
                txtCategoryName.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

            ShortCutKey(sender, e);
        }

        private void GridShortCutKey(object sender, KeyEventArgs e)
        {
            
        }

        private void ShortCutKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCode.Focus();
            }
            if (e.KeyCode == Keys.F2)
            {
                txtCategoryName.Focus();
            }
            if (e.KeyCode == Keys.F3)
            {
                txtItemName.Focus();
            }

            if (e.KeyCode == Keys.F5)
            {
                int columnIndex = 3;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                if (rowIndex < dataGridView1.Rows.Count && columnIndex < dataGridView1.Columns.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[columnIndex];
                    dataGridView1.BeginEdit(true);
                }
            }

            if (e.KeyCode == Keys.F6)
            {
                if (checkServiceChg.Checked)
                {
                    checkServiceChg.Checked = false;
                }
                else
                {
                    checkServiceChg.Checked = true;
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (checkCardPayFee.Checked)
                {
                    checkCardPayFee.Checked = false;
                }
                else
                {
                    checkCardPayFee.Checked = true;
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (checkTax.Checked)
                {
                    checkTax.Checked = false;
                }
                else
                {
                    checkTax.Checked = true;
                }
            }

            if (e.KeyCode == Keys.F9)
            {
                CashPay();
            }
            if (e.KeyCode == Keys.F10)
            {
                CardPay();
            }
            if (e.KeyCode == Keys.F11)
            {
                PrintTableBill();
            }
            if (e.KeyCode == Keys.F12)
            {
                PrintKOT(true);
            }

            if (e.KeyCode == Keys.Escape)
            {
                ThisClose();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            
            if (txtCode.Text != "")
            {
                string Barcode = txtCode.Text.ToString();
                DataRow[] dr = AllItemsTable.Select("barcode = '" + Barcode + "'");

                if (dr.Length > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        int itemCode = int.Parse(row["ID"].ToString());
                        string itemName = row["item_name"].ToString();
                        decimal price = Convert.ToDecimal(row["labled_price"].ToString());
                        decimal qunt = 1;
                        decimal totPrice = price * qunt;
                        int KOT = int.Parse(row["kot_item"].ToString());
                        bool kot = Convert.ToBoolean(KOT);

                        if (dataGridView2.Rows.Count > 0)
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
                                    decimal currentTotal = Convert.ToDecimal(row2["total_price"].ToString());

                                    row2["quantity"] = currentQuantity + qunt;
                                    row2["total_price"] = ((currentQuantity + qunt) * currentPrice).ToString("#.00");

                                    for (int a = 0; a < dt.Rows.Count; a++)
                                    {
                                        dt.Rows[a]["count"] = a + 1;
                                    }
                                    InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);
                                    dataGridView2.AutoGenerateColumns = false;
                                    dataGridView2.DataSource = dt;
                                    GetFullTotalPrice();

                                    txtCode.Text = "";
                                    txtItemQnt.Text = "";
                                    txtItemQnt.Visible = false;
                                    txtCode.Enabled = true;
                                    txtCode.Focus();
                                }
                            }
                            else
                            {
                                dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                                for (int a = 0; a < dt.Rows.Count; a++)
                                {
                                    dt.Rows[a]["count"] = a + 1;
                                }
                                InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);



                                dataGridView2.AutoGenerateColumns = false;
                                dataGridView2.DataSource = dt;
                                GetFullTotalPrice();

                                txtCode.Text = "";
                                txtItemQnt.Text = "";
                                txtItemQnt.Visible = false;
                                txtCode.Enabled = true;
                                txtCode.Focus();
                            }
                        }
                        else
                        {
                            dt.Rows.Add(itemCode, itemName, price, qunt, totPrice.ToString("#.00"), Convert.ToInt16(kot));
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                dt.Rows[a]["count"] = a + 1;
                            }

                            InsertSalesTable(itemCode, itemName, price, qunt, totPrice, "pending", kot);




                            dataGridView2.AutoGenerateColumns = false;
                            dataGridView2.DataSource = dt;
                            GetFullTotalPrice();

                            txtCode.Text = "";
                            txtItemQnt.Text = "";
                            txtItemQnt.Visible = false;
                            txtCode.Enabled = true;
                            txtCode.Focus();
                        }
                    }
                }
            }
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            (gridDataDetails.DataSource as DataTable).DefaultView.RowFilter = string.Format("CategoryName LIKE '{0}%'", txtCategoryName.Text);
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridDataDetails.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                gridDataDetails.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                txtCode.Focus();
            }

            ShortCutKey(sender, e);
        }

        private void gridDataDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dataGridView1.Focus();
            }

            ShortCutKey(sender, e);

        }

        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("item_name LIKE '{0}%'", txtItemName.Text);
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                dataGridView1.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                gridDataDetails.Focus();
            }

            ShortCutKey(sender, e);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                gridDataDetails.Focus();
            }

            if (e.KeyCode == Keys.F5)
            {
                int columnIndex = 3;
                int rowIndex = dataGridView1.CurrentCell.RowIndex;

                if (rowIndex < dataGridView1.Rows.Count && columnIndex < dataGridView1.Columns.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[columnIndex];
                    dataGridView1.BeginEdit(true);
                }
            }

            ShortCutKey(sender, e);
        }

        private void RestaurantSale_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.Delete.Index)
                {
                    string id = dataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn2"].Value.ToString();

                    if (MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteItemFromDt(int.Parse(id.ToString()));
                    }
                }
            }

        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                string id = "";
                foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                {
                    id = dataGridView2.Rows[row.Index].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                }

                if (string.IsNullOrEmpty(id) == false && MessageBox.Show("Do You Want to Delete Data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DeleteItemFromDt(int.Parse(id.ToString()));
                }
            }
            ShortCutKey(sender, e);
        }

        private void DeleteItemFromDt(int ItemID)
        {
            DataRow[] rows = dt.Select("ID = '" + ItemID + "'"); ;//'UserName' is ColumnName
            foreach (DataRow row in rows)
                dt.Rows.Remove(row);
            updateSalesTable(ItemID, "remove");
            for (int a = 0; a < dt.Rows.Count; a++)
            {
                dt.Rows[a]["count"] = a + 1;
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = dt;
            GetFullTotalPrice();
        }

        private void GetFullTotalPrice()
        {
            if (dt.Rows.Count > 0)
            {
                int numberOfRecords = dt.Rows.Count;
                decimal FullTotal = Convert.ToDecimal(dt.Compute("Sum(total_price)", string.Empty.ToString()));

                lblItemCount.Text = numberOfRecords.ToString();
                invoiceDetails.SubTotalAmount = Convert.ToDecimal(FullTotal.ToString("#.00"));
                invoiceDetails.NetTotalAmount = Convert.ToDecimal(FullTotal.ToString("#.00"));
                lblSubTot.Text = invoiceDetails.SubTotalAmount.ToString("#.00");
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");

                SetChagers();
            }
            else
            {
                lblSubTot.Text = "0.00";
                lblTotAmount.Text = "0.00";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCashPay_Click(object sender, EventArgs e)
        {
            CashPay();
        }

        private void CashPay()
        {


            if (checkCardPayFee.Checked == false)
            {
                CashPayment cashPay = new CashPayment(invoiceDetails, dt);
                cashPay.ShowDialog();

                if (cashPay.IsClose == true)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Remove card Payment Fee.");
            }
        }

        private void CardPay()
        {
            CardPayment cardPay = new CardPayment(invoiceDetails, dt);
            cardPay.ShowDialog();

            if (cardPay.IsClose == true)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:MM:ss tt");
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ThisClose();
        }

        private void ThisClose()
        {
            if (MessageBox.Show("Do You Want to Exit?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnKotPrint_Click(object sender, EventArgs e)
        {
            PrintKOT(true);
        }

        private void PrintKOT(bool isPrint)
        {
            PrintDialog p = new PrintDialog();
            DataTable dt1 = new DataTable();
            dt1 = (DataTable)dataGridView2.DataSource;

            DataTable dt2 = dt1.Copy();
            if (dt2.Rows.Count > 0)
            {
                DataRow[] rows = dt2.Select("KOT = '0'");
                foreach (DataRow row in rows)
                    dt2.Rows.Remove(row);

                CrystalReportViewer viever = new CrystalReportViewer();
                KOTbill kotBill = new KOTbill();
                kotBill.SetDataSource(dt1);
                kotBill.SetParameterValue("InvoiceNumber", invoiceDetails.InvoiceNumber);
                kotBill.SetParameterValue("TableName", invoiceDetails.TableName);

                viever.ReportSource = kotBill;


                string Papersize = Program.printerInfo.KOTpaperSize;
                int rawKind = 0;
                for (int i = 0; i <= p.PrinterSettings.PaperSizes.Count - 1; i++)
                {
                    if (p.PrinterSettings.PaperSizes[i].ToString() == Papersize) // "LXP : Your Page Size"
                    {
                        rawKind = Convert.ToInt32(p.PrinterSettings.PaperSizes[i].GetType().GetField
                            ("kind",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic).GetValue(p.PrinterSettings.PaperSizes[i]));
                        break;
                    }
                }
                kotBill.PrintOptions.PrinterName = Program.printerInfo.KOTprinterName;
                kotBill.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                kotBill.PrintToPrinter(1, true, 1, 100);

                ProductControler prodCont = new ProductControler();
                prodCont.InsertKOTtable(dt2, invoiceDetails.InvoiceNumber, invoiceDetails.TableName);
            }
            else
            {
                MessageBox.Show("No items.");
            }
        }



        private void btnTableBill_Click(object sender, EventArgs e)
        {
            PrintTableBill();
        }

        private void PrintTableBill()
        {
            PrintDialog p = new PrintDialog();
            CrystalReportViewer viever = new CrystalReportViewer();
            BillPrintingControler billPrintingControler = new BillPrintingControler();
            List<BillMargingInfo> listBillInfo = new List<BillMargingInfo>();
            listBillInfo = billPrintingControler.LoadBillSetingDataForSelectedObject("Restaurant_Table_Bill");

            TableBill tableBill = new TableBill();
            tableBill.SetDataSource(dt);

            this.SetParameterAlign(tableBill, "InvoiceNumber1", listBillInfo.Find(x => x.Value_Name == "Invoice No "));
            this.SetParameterAlign(tableBill, "TableName1", listBillInfo.Find(x => x.Value_Name == "Table Name"));
            this.SetParameterAlign(tableBill, "Date1", listBillInfo.Find(x => x.Value_Name == "Date"));
            this.SetParameterAlign(tableBill, "Time1", listBillInfo.Find(x => x.Value_Name == "Time"));
            this.SetParameterAlign(tableBill, "SubTotal1", listBillInfo.Find(x => x.Value_Name == "Sub Total"));
            this.SetParameterAlign(tableBill, "ServiceChg1", listBillInfo.Find(x => x.Value_Name == "Service Charge"));
            this.SetParameterAlign(tableBill, "Total1", listBillInfo.Find(x => x.Value_Name == "Full Total"));
            this.SetParameterAlign(tableBill, "Casher1", listBillInfo.Find(x => x.Value_Name == "Casher"));


            tableBill.SetParameterValue("InvoiceNumber", invoiceDetails.InvoiceNumber);
            tableBill.SetParameterValue("TableName", invoiceDetails.TableName);
            tableBill.SetParameterValue("Date", DateTime.Now.ToShortDateString());
            tableBill.SetParameterValue("Time", DateTime.Now.ToShortTimeString());
            tableBill.SetParameterValue("SubTotal", invoiceDetails.SubTotalAmount);
            tableBill.SetParameterValue("ServiceChg", invoiceDetails.ServiceCharge);
            tableBill.SetParameterValue("Total", invoiceDetails.NetTotalAmount);
            tableBill.SetParameterValue("Casher", Program.userDetails.UseryName);

            viever.ReportSource = tableBill;

            string Papersize = Program.printerInfo.POSpaperSize;
            int rawKind = 0;
            for (int i = 0; i <= p.PrinterSettings.PaperSizes.Count - 1; i++)
            {
                if (p.PrinterSettings.PaperSizes[i].ToString() == Papersize) // "LXP : Your Page Size"
                {
                    rawKind = Convert.ToInt32(p.PrinterSettings.PaperSizes[i].GetType().GetField
                        ("kind",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.NonPublic).GetValue(p.PrinterSettings.PaperSizes[i]));
                    break;
                }
            }
            tableBill.PrintOptions.PrinterName = Program.printerInfo.POSprinterName;
            tableBill.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            tableBill.PrintToPrinter(1, true, 1, 100);
        }

        private void SetParameterAlign(TableBill c, string paraName, BillMargingInfo billMarginInfo)
        {
            ReportObject reportObject1 = c.ReportDefinition.ReportObjects[paraName];
            CrystalDecisions.CrystalReports.Engine.FieldObject f = (FieldObject)reportObject1;
            f.Left = billMarginInfo.Left_Margin;
            f.Top = billMarginInfo.Top_Margin;
            f.Height = billMarginInfo.Hight;

            if (billMarginInfo.FontStyle == "Regular")
                f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Regular));
            else if (billMarginInfo.FontStyle == "Bold")
                f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Bold));
            else if (billMarginInfo.FontStyle == "Italic")
                f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Italic));
            
            if (billMarginInfo.Align == "Left")
                f.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign;
            else if (billMarginInfo.Align == "Right")
                f.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
            else if (billMarginInfo.Align == "Center")
                f.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign;
            else if (billMarginInfo.Align == "Justified")
                f.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.Justified;
            if (billMarginInfo.Need_To_Print == 0)
                f.Width = 0;
            else
                f.Width = billMarginInfo.Width;

            ReportObject reportObject = c.ReportDefinition.ReportObjects["lbl" + paraName];
            TextObject textObject = (TextObject)reportObject;
            textObject.Left = billMarginInfo.Lbl_Left_Margin;
            textObject.Top = billMarginInfo.Lbl_Top_Margin;

            textObject.Height = billMarginInfo.Hight;
            if (billMarginInfo.Need_To_Print == 0)
            {
                textObject.Width = 0;
            }
            else
            {
                textObject.Width = billMarginInfo.Lbl_Width;
            }
            textObject.Text = billMarginInfo.Lable_Name;

            if (billMarginInfo.FontStyle == "Regular")
                textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Regular));
            else if (billMarginInfo.FontStyle == "Bold")
                textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Bold));
            else if (billMarginInfo.FontStyle == "Italic")
                textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Italic));
            
            if (billMarginInfo.Label_Align == "Left")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign;
            else if (billMarginInfo.Label_Align == "Right")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
            else if (billMarginInfo.Label_Align == "Center")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign;
            else if (billMarginInfo.Label_Align == "Justified")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.Justified;
        }


        private void checkServiceChg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkServiceChg.Checked)
            {
                AddServiceChg();
            }
            else
            {
                RemoveServiceChg();
            }
        }

        private void AddServiceChg()
        {
            invoiceDetails.AddServiceChg = true;
            saleCont.UpdateInviceDetils("SC", invoiceDetails);
            invoiceDetails.ServiceCharge = (invoiceDetails.SubTotalAmount * invoiceDetails.ServiePer) / 100;
            invoiceDetails.NetTotalAmount = invoiceDetails.SubTotalAmount + invoiceDetails.ServiceCharge;
            lblServiceChg.Text = invoiceDetails.ServiceCharge.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }
        private void RemoveServiceChg()
        {
            invoiceDetails.AddServiceChg = false;
            saleCont.UpdateInviceDetils("SC", invoiceDetails);
            invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount - invoiceDetails.ServiceCharge;
            invoiceDetails.ServiceCharge = 0;
            lblServiceChg.Text = invoiceDetails.ServiceCharge.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void checkCardPayFee_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCardPayFee.Checked)
            {
                AddCardFee();
            }
            else
            {
                RemoveCardFee();
            }
        }

        private void AddCardFee()
        {
            invoiceDetails.AddCardPaymentFee = true;
            saleCont.UpdateInviceDetils("CP", invoiceDetails);
            invoiceDetails.CardPaymentFee = (invoiceDetails.NetTotalAmount * invoiceDetails.CardPer) / 100;
            invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount + invoiceDetails.CardPaymentFee;
            lblCardFee.Text = invoiceDetails.CardPaymentFee.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void RemoveCardFee()
        {
            invoiceDetails.AddCardPaymentFee = false;
            saleCont.UpdateInviceDetils("CP", invoiceDetails);
            invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount - invoiceDetails.CardPaymentFee;
            invoiceDetails.CardPaymentFee = 0;
            lblCardFee.Text = invoiceDetails.CardPaymentFee.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void checkTax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTax.Checked)
            {
                AddTax();
            }
            else
            {
                RemoveTax();
            }
        }

        private void AddTax()
        {
            invoiceDetails.AddTAX = true;
            saleCont.UpdateInviceDetils("TAX", invoiceDetails);
            invoiceDetails.TAX = (invoiceDetails.NetTotalAmount * invoiceDetails.TAXPer) / 100;
            invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount + invoiceDetails.TAX;
            lblTAX.Text = invoiceDetails.TAX.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void RemoveTax()
        {
            invoiceDetails.AddTAX = false;
            saleCont.UpdateInviceDetils("TAX", invoiceDetails);
            invoiceDetails.NetTotalAmount = invoiceDetails.NetTotalAmount - invoiceDetails.TAX;
            invoiceDetails.TAX = 0;
            lblTAX.Text = invoiceDetails.TAX.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void checkServiceChg_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void checkCardPayFee_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void checkTax_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardPay();
        }

        private void btnKotPrint_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void btnTableBill_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void btnCashPay_KeyDown(object sender, KeyEventArgs e)
        {
            ShortCutKey(sender, e);
        }

        private void button3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ThisClose();
            }
        }
    }
}
