using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPOS.Forms
{
    public class AllTableInfo
    {
        public int ID { set; get; }
        public string TableName { set; get; }
        public string TableCode { set; get; }
        public bool IsUse { get; set; }
        public int InvID { set; get; }
        //public string Status { set; get; }
    }
}
