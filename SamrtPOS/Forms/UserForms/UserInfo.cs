using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartPOS.Forms.UserForms
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UseryName { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int JobRole { get; set; }
        public string JobRoleName { get; set; }
    }
}
