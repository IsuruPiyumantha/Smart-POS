using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.ItemsForms;
using SmartPOS.Forms.RestaurantForms;
using SmartPOS.Forms.SettingsForms.PrintigSetting;
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
    public partial class CardPayment : Form
    {
        private static CommonFuntion CmnFun;
        private static ProductControler prodCont;
        private static SalesControler saleCont;
        private static TbaleManagerControler TblControler;

        private CrystalReportViewer viever;
        private CardBill mainBill;
        private BillPrintingControler billPrintingControler;
        private List<BillMargingInfo> listBillInfo;

        private InvoiceBillDetails invoiceDetails;
        private DataTable dt = new DataTable();

        public bool IsClose = false;

        public CardPayment()
        {
            InitializeComponent();
        }

        public CardPayment(InvoiceBillDetails invoiceDetails, DataTable dt)
        {
            InitializeComponent();
            SetReferences();
            SetColors();
            this.invoiceDetails = invoiceDetails;
            this.dt = dt;
        }

        private void SetReferences()
        {
            prodCont = new ProductControler();
            saleCont = new SalesControler();
            TblControler = new TbaleManagerControler();

            viever = new CrystalReportViewer();
            mainBill = new CardBill();
            billPrintingControler = new BillPrintingControler();
            listBillInfo = new List<BillMargingInfo>();
            listBillInfo = billPrintingControler.LoadBillSetingDataForSelectedObject("Restaurant_Card_Bill");
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
        }

        private void ProductDetails_Load(object sender, EventArgs e)
        {
            txtPayAmount.Focus();
            lblSubTot.Text = invoiceDetails.SubTotalAmount.ToString("#.00");
            lblServiceChg.Text = invoiceDetails.ServiceCharge.ToString("#.00");
            lblCardPaymentFee.Text = invoiceDetails.CardPaymentFee.ToString("#.00");
            lblTax.Text = invoiceDetails.TAX.ToString("#.00");
            lblNetTot.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
            lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();
            if (txtPayAmount.Text != "")
            {
                if (CmnFun.IsValidDecimalNo(txtPayAmount.Text.ToString()))
                {
                    decimal A = Convert.ToDecimal(lblTotAmount.Text.ToString());
                    decimal B = Convert.ToDecimal(txtPayAmount.Text.ToString());
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
            else
            {
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();
            if (txtDiscount.Text != "")
            {
                if (CmnFun.IsValidDecimalNo(txtDiscount.Text.ToString()))
                {
                    decimal A = Convert.ToDecimal(invoiceDetails.NetTotalAmount.ToString());
                    decimal B = Convert.ToDecimal(txtDiscount.Text.ToString());
                    lblTotAmount.Text = (A - B).ToString("#.00");
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
            else
            {
                lblTotAmount.Text = invoiceDetails.NetTotalAmount.ToString("#.00");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CmnFun = new CommonFuntion();
            if (txtDiscountPer.Text != "")
            {
                if (CmnFun.IsValidDecimalNo(txtDiscountPer.Text.ToString()))
                {
                    decimal A = Convert.ToDecimal(invoiceDetails.NetTotalAmount.ToString());
                    decimal B = Convert.ToDecimal(txtDiscountPer.Text.ToString());
                    txtDiscount.Text = ((A * B) / 100).ToString("#.00");
                    txtDiscount.Enabled = false;
                }
                else
                {
                    MessageBox.Show("please enter numeric.");
                }
            }
            else
            {
                txtDiscount.Text = "0.00";
            }
        }

        private void txtPayAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (txtDiscount.Enabled == false)
                {
                    txtDiscountPer.Focus();
                    txtDiscountPer.BackColor = Color.Yellow;
                    txtPayAmount.BackColor = Color.White;
                }
                else
                {
                    txtDiscount.Focus();
                    txtDiscount.BackColor = Color.Yellow;
                    txtPayAmount.BackColor = Color.White;
                }
            }


            if (e.KeyCode == Keys.Enter)
            {
                if (txtPayAmount.Text != "")
                {
                    if (invoiceDetails.TotalAmount != Convert.ToDecimal(txtPayAmount.Text.ToString()))
                    {
                        if (txtDiscount.Text.ToString() != "")
                        {
                            invoiceDetails.DiscountAmount = Convert.ToDecimal(txtDiscount.Text.ToString());
                        }
                        invoiceDetails.PayAmount = Convert.ToDecimal(txtPayAmount.Text.ToString());
                        invoiceDetails.TotalAmount = Convert.ToDecimal(lblTotAmount.Text.ToString());


                        PrintBill();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Pay Amount.");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Pay Amount.");
                }
            }
            BtnClose_KeyDown(sender, e);
        }

        private void PrintBill()
        {
            PrintDialog p = new PrintDialog();
            mainBill.SetDataSource(dt);

            this.SetParameterAlign(mainBill, "CompanyName1", listBillInfo.Find(x => x.Value_Name == "Company Name"));
            this.SetParameterAlign(mainBill, "CompanyAddress1", listBillInfo.Find(x => x.Value_Name == "Company Address"));
            this.SetParameterAlign(mainBill, "CompanyMobile1", listBillInfo.Find(x => x.Value_Name == "Company MobileNo"));
            this.SetParameterAlign(mainBill, "InvoiceNumber1", listBillInfo.Find(x => x.Value_Name == "Invoice No"));
            this.SetParameterAlign(mainBill, "TableName1", listBillInfo.Find(x => x.Value_Name == "Table Name"));
            this.SetParameterAlign(mainBill, "Casher1", listBillInfo.Find(x => x.Value_Name == "Casher"));
            this.SetParameterAlign(mainBill, "ParameterDate1", listBillInfo.Find(x => x.Value_Name == "Date"));
            this.SetParameterAlign(mainBill, "ParameterTime1", listBillInfo.Find(x => x.Value_Name == "Time"));
            this.SetParameterAlign(mainBill, "SubTotal1", listBillInfo.Find(x => x.Value_Name == "Sub Total"));
            this.SetParameterAlign(mainBill, "ServiceChg1", listBillInfo.Find(x => x.Value_Name == "Service Charge"));
            this.SetParameterAlign(mainBill, "CardPayFee1", listBillInfo.Find(x => x.Value_Name == "Card Pay Fee"));
            this.SetParameterAlign(mainBill, "Tax1", listBillInfo.Find(x => x.Value_Name == "Tax"));
            this.SetParameterAlign(mainBill, "NetTotal1", listBillInfo.Find(x => x.Value_Name == "Net Total"));
            this.SetParameterAlign(mainBill, "Discount1", listBillInfo.Find(x => x.Value_Name == "Discoun"));
            this.SetParameterAlign(mainBill, "Total1", listBillInfo.Find(x => x.Value_Name == "Total"));
            this.SetParameterAlign(mainBill, "CashPay1", listBillInfo.Find(x => x.Value_Name == "Pay Amount"));
            this.SetParameterAlign(mainBill, "Balance1", listBillInfo.Find(x => x.Value_Name == "Balance Amount"));
            this.SetParameterAlign(mainBill, "Barcode1", listBillInfo.Find(x => x.Value_Name == "BarCode"));
            this.SetParameterAlign(mainBill, "Message1", listBillInfo.Find(x => x.Value_Name == "Message"));
            this.SetParameterAlign(mainBill, "SoftwareCompanyName1", listBillInfo.Find(x => x.Value_Name == "Software Company Name"));
            this.SetParameterAlign(mainBill, "SoftwareCompanyNo1", listBillInfo.Find(x => x.Value_Name == "Software Company Mobile"));

            mainBill.SetParameterValue("CompanyName", Program.companyProfile.CompanyName);
            mainBill.SetParameterValue("CompanyAddress", Program.companyProfile.Address);
            mainBill.SetParameterValue("CompanyMobile", Program.companyProfile.MobileNo);
            mainBill.SetParameterValue("InvoiceNumber", invoiceDetails.InvoiceNumber);
            mainBill.SetParameterValue("TableName", invoiceDetails.TableName);
            mainBill.SetParameterValue("Casher", Program.userDetails.UseryName);
            mainBill.SetParameterValue("ParameterDate", DateTime.Now.ToShortDateString());
            mainBill.SetParameterValue("ParameterTime", DateTime.Now.ToShortTimeString());
            mainBill.SetParameterValue("SubTotal", invoiceDetails.SubTotalAmount);
            mainBill.SetParameterValue("ServiceChg", invoiceDetails.ServiceCharge);
            mainBill.SetParameterValue("CardPayFee", decimal.Parse(invoiceDetails.CardPaymentFee.ToString("#.00")));
            mainBill.SetParameterValue("Tax", decimal.Parse(invoiceDetails.TAX.ToString("#.00")));
            mainBill.SetParameterValue("NetTotal", invoiceDetails.NetTotalAmount);
            mainBill.SetParameterValue("Discount", invoiceDetails.DiscountAmount * (-1));
            mainBill.SetParameterValue("Total", invoiceDetails.TotalAmount);
            mainBill.SetParameterValue("CashPay", invoiceDetails.PayAmount);
            mainBill.SetParameterValue("Balance", invoiceDetails.BalenceAmoun);
            mainBill.SetParameterValue("Barcode", invoiceDetails.InvoiceNumber);
            mainBill.SetParameterValue("Message", "Thank you Come Agin!");
            mainBill.SetParameterValue("SoftwareCompanyName", Program.companyProfile.SoftName);
            mainBill.SetParameterValue("SoftwareCompanyNo", Program.companyProfile.SoftMobileNo);


            viever.ReportSource = mainBill;
            DialogResult result = MessageBox.Show("Do You Want to Print?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
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
                mainBill.PrintOptions.PrinterName = Program.printerInfo.POSprinterName;
                mainBill.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                mainBill.PrintToPrinter(1, true, 1, 100);
                SaveInvoice();
            }
            else if (result == DialogResult.No)
            {
                SaveInvoice();
            }
        }

        private void SetParameterAlign(CardBill c, string paraName, BillMargingInfo billMarginInfo)
        {
            ReportObject reportObject1 = c.ReportDefinition.ReportObjects[paraName];
            CrystalDecisions.CrystalReports.Engine.FieldObject f = (FieldObject)reportObject1;
            f.Left = billMarginInfo.Left_Margin;
            f.Top = billMarginInfo.Top_Margin;
            f.Height = billMarginInfo.Hight;

            if (paraName == "Barcode1")
            {
                if (billMarginInfo.FontStyle == "Regular")
                    f.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Regular));
                else if (billMarginInfo.FontStyle == "Bold")
                    f.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Bold));
                else if (billMarginInfo.FontStyle == "Italic")
                    f.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Italic));
            }
            else
            {
                if (billMarginInfo.FontStyle == "Regular")
                    f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Regular));
                else if (billMarginInfo.FontStyle == "Bold")
                    f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Bold));
                else if (billMarginInfo.FontStyle == "Italic")
                    f.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Italic));
            }
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
            if (paraName == "Barcode1")
            {
                if (billMarginInfo.FontStyle == "Regular")
                    textObject.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Regular));
                else if (billMarginInfo.FontStyle == "Bold")
                    textObject.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Bold));
                else if (billMarginInfo.FontStyle == "Italic")
                    textObject.ApplyFont(new Font("Libre Barcode 128", billMarginInfo.FontSize, FontStyle.Italic));
            }
            else
            {
                if (billMarginInfo.FontStyle == "Regular")
                    textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Regular));
                else if (billMarginInfo.FontStyle == "Bold")
                    textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Bold));
                else if (billMarginInfo.FontStyle == "Italic")
                    textObject.ApplyFont(new Font("Arial", billMarginInfo.FontSize, FontStyle.Italic));
            }
            if (billMarginInfo.Label_Align == "Left")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.LeftAlign;
            else if (billMarginInfo.Label_Align == "Right")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.RightAlign;
            else if (billMarginInfo.Label_Align == "Center")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.HorizontalCenterAlign;
            else if (billMarginInfo.Label_Align == "Justified")
                textObject.ObjectFormat.HorizontalAlignment = CrystalDecisions.Shared.Alignment.Justified;
        }

        private void SaveInvoice()
        {
            if (prodCont.SaveSoldOutItems(invoiceDetails.InvoiceID, "SoldOut", dt) == true)
            {
                if (saleCont.UpdateInvoicePayment(invoiceDetails, "Complete", "Card") == true)
                {
                    if (TblControler.UpdateTableDetails(invoiceDetails.TableName))
                    {
                        MessageBox.Show("Payment Successfull");
                        IsClose = true;
                        this.Close();
                        
                    }
                }
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtDiscountPer.Focus();
                txtDiscountPer.BackColor = Color.Yellow;
                txtDiscount.BackColor = Color.White;
            }

            if (e.KeyCode == Keys.Down)
            {
                txtPayAmount.Focus();
                txtPayAmount.BackColor = Color.Yellow;
                txtDiscount.BackColor = Color.White;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtPayAmount.Focus();
                txtPayAmount.BackColor = Color.Yellow;
                txtDiscount.BackColor = Color.White;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (txtDiscount.Enabled == false)
                {
                    txtPayAmount.Focus();
                    txtPayAmount.BackColor = Color.Yellow;
                    txtDiscountPer.BackColor = Color.White;
                }
                else
                {
                    txtDiscount.Focus();
                    txtDiscount.BackColor = Color.Yellow;
                    txtDiscountPer.BackColor = Color.White;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDiscount.Enabled == false)
                {
                    txtPayAmount.Focus();
                    txtPayAmount.BackColor = Color.Yellow;
                    txtDiscountPer.BackColor = Color.White;
                }
                else
                {
                    txtDiscount.Focus();
                    txtDiscount.BackColor = Color.Yellow;
                    txtDiscountPer.BackColor = Color.White;
                }
            }
            BtnClose_KeyDown(sender, e);
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
