using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.RestaurantForms
{
    public class RestaurantProductInfo
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Unit { get; set; }
        public string UnitName { get; set; }
        public decimal LabledPrice { get; set; }
        public decimal BuyingCost { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int Supplier { get; set; }
        public string SupplierName { get; set; }
        public string BarCode { get; set; }
        public bool KOT { get; set; }
    }
}
