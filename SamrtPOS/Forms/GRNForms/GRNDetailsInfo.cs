using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.GRNForms
{
    public class GRNDetailsInfo
    {
        public string GRNNumber { get; set; }
        public string Description { get; set; }
        public int SupplirtID { get; set; }
        public string SupplierName { get; set; }
        public decimal Total { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public string ChequesNumber { get; set; }
        public string ChequesDate { get; set; }
    }
}
