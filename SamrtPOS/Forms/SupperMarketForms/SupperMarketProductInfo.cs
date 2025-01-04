using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.SupperMarketForms
{
    public class SupperMarketProductInfo
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemNameSinhala { get; set; }
        public int Unit { get; set; }
        public string UnitName { get; set; }
        public decimal LabledPrice { get; set; }
        public decimal SpeciaPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal BuyingCost { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public int SubCategory { get; set; }
        public string SubCategoryName { get; set; }
        public int Supplier { get; set; }
        public string SupplierName { get; set; }
        public string BarCode { get; set; }
        public string BarCode2 { get; set; }
        public string BarCode3 { get; set; }
        public int Buy { get; set; }
        public int Get { get; set; }
        public int DateExp { get; set; }
        public bool Isprint { get; set; }
    }
}
