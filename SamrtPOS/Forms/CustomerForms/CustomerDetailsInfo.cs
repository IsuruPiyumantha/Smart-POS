using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.CustomerForms
{
    public class CustomerDetailsInfo
    {
        public int CusCode { get; set; }
        public string CusName { get; set; }
        public string CusAddress { get; set; }
        public string CusMobile { get; set; }
        public string CusEmail { get; set; }
        public decimal Amount { get; set; }
    }
}
