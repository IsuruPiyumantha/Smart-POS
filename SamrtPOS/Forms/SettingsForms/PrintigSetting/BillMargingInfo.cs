using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS.Forms.SettingsForms.PrintigSetting
{
    public class BillMargingInfo
    {
        public int ID { set; get; }
        public string Object_Name { set; get; }
        public string Value_Name { set; get; }
        public int Need_To_Print { set; get; }
        public int Left_Margin { set; get; }
        public int Top_Margin { set; get; }
        public int Width { set; get; }
        public string Lable_Name { set; get; }
        public int Lbl_Left_Margin { set; get; }
        public int Lbl_Top_Margin { set; get; }
        public int Lbl_Width { set; get; }
        public float FontSize { set; get; }
        public int Hight { set; get; }
        public string FontStyle { get; set; }
        public string Align { get; set; }
        public string Label_Align { get; set; }
    }
}
