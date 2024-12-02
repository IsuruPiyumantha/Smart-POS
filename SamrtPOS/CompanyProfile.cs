using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPOS
{
    public class CompanyProfile
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Catogery { get; set; }
        public int CatID { get; set; }
        public string Status { get; set; }
        public string SoftName { get; set; }
        public string SoftMobileNo { get; set; }
        public bool IsEnglish { get; set; }
    }
}
