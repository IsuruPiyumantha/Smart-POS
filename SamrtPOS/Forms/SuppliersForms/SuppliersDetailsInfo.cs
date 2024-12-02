using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.SuppliersForms
{
    public class SuppliersDetailsInfo
    {
        public int SuppCode { get; set; }
        public string SuppName { get; set; }
        public string SuppAddress { get; set; }
        public string SuppMobile { get; set; }
        public string SuppEmail { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
