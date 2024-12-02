using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Controler
{
    public class ServerConfigureInfo
    {
        public string hostName { set; get; }
        public string userName { set; get; }
        public string password { set; get; }
        public string database { set; get; }
        public int type { set; get; }
    }
}
