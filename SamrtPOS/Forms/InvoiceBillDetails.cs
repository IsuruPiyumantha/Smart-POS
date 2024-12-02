using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms
{
    public class InvoiceBillDetails
    {
        public int InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public int TableID { get; set; }
        public string TableName { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal NetTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PayAmount { get; set; }
        public decimal BalenceAmoun { get; set; }
        public string payMethod { get; set; }
        public decimal ServiePer { get; set; }
        public bool AddServiceChg { get; set; }
        public decimal ServiceCharge { get; set; }
        public decimal CardPer { get; set; }
        public bool AddCardPaymentFee { get; set; }
        public decimal CardPaymentFee { get; set; }
        public decimal TAXPer { get; set; }
        public bool AddTAX { get; set; }
        public decimal TAX { get; set; }
        public int ItemCount {get; set;}

    }
}
