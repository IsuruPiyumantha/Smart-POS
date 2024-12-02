using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS
{
    public class SerialKeyControler
    {
        public string GenerateGuid()
        {
            return Guid.NewGuid().ToString(); // Generates a unique GUID in string format
        }
    }
}
