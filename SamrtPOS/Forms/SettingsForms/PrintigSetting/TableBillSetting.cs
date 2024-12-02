using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.RestaurantForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms.PrintigSetting
{
    public partial class TableBillSetting : Form
    {
        List<BillMargingInfo> listBillInfo = new List<BillMargingInfo>();
        private BillPrintingControler ctrl;
        private string BillName;

        public TableBillSetting()
        {
            InitializeComponent();
        }

        public TableBillSetting(string p)
        {
            InitializeComponent();
            this.BillName = p;
        }

        private void TablesManeg_Load(object sender, EventArgs e)
        {
            SetColors();
            ctrl = new BillPrintingControler();
            DataTable dt = ctrl.LoadDataForBillSettings(this.BillName);
            SetDataInLoad(dt);
        }

        private void SetColors()
        {
            tableLayoutPanel20.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
        }

        private void SetDataInLoad(DataTable dt)
        {
            foreach (DataRow r in dt.Rows)
            {
                int id = int.Parse(r["ID"].ToString());
                string left = r["LeftMargin"].ToString();
                string top = r["TopMargin"].ToString();
                string width = r["Width"].ToString();
                string lname = r["LabelName"].ToString();
                string lleft = r["LblLeftMargain"].ToString();
                string ltop = r["LblTopMargin"].ToString();
                string lwidth = r["LblWidth"].ToString();
                string height = r["Hight"].ToString();
                string fsize = r["FontSize"].ToString();
                string value_name = r["ValueName"].ToString();
                string fontStyle = r["FontStyle"].ToString();
                string align = r["FontAlignment"].ToString();
                string lalign = r["LblFontAlign"].ToString();


                if (value_name == "Invoice No ")
                {
                    txtLeft1.Text = left;
                    txtTop1.Text = top;
                    txtWidth1.Text = width;
                    txtName1.Text = lname;
                    txtNameLeft1.Text = lleft;
                    txtNameTop1.Text = ltop;
                    txtNameWidth1.Text = lwidth;
                    txtHeight1.Text = height;
                    cmbFSize1.Text = fsize;
                    cmbStyle1.SelectedIndex = cmbStyle1.FindString(fontStyle);
                    cmbAlign1.Text = align;
                    cmbNameAlign1.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk1.Checked = true;
                    }
                    else
                    {
                        chk1.Checked = false;
                        txtLeft1.Text = "0";
                        txtLeft1.ReadOnly = true;
                        txtTop1.Text = "0";
                        txtTop1.ReadOnly = true;
                        txtWidth1.Text = "0";
                        txtWidth1.ReadOnly = true;
                        txtHeight1.Text = "0";
                        txtHeight1.ReadOnly = true;
                        txtNameLeft1.Text = "0";
                        txtNameLeft1.ReadOnly = true;
                        txtNameTop1.Text = "0";
                        txtNameTop1.ReadOnly = true;
                        txtNameWidth1.Text = "0";
                        txtNameWidth1.ReadOnly = true;
                        txtName1.Text = "";
                        txtName1.ReadOnly = true;
                        cmbFSize1.SelectedIndex = 1;
                        cmbFSize1.Enabled = false;
                        cmbAlign1.SelectedIndex = 1;
                        cmbAlign1.Enabled = false;
                        cmbNameAlign1.SelectedIndex = 1;
                        cmbNameAlign1.Enabled = false;
                        cmbStyle1.SelectedIndex = 1;
                        cmbStyle1.Enabled = false;

                    }
                }
                else if (value_name == "Table Name")
                {
                    txtLeft2.Text = left;
                    txtTop2.Text = top;
                    txtWidth2.Text = width;
                    txtName2.Text = lname;
                    txtNameLeft2.Text = lleft;
                    txtNameTop2.Text = ltop;
                    txtNameWidth2.Text = lwidth;
                    txtHeight2.Text = height;
                    cmbFSize2.Text = fsize;
                    cmbStyle2.SelectedIndex = cmbStyle2.FindString(fontStyle);
                    cmbAlign2.Text = align;
                    cmbNameAlign2.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk2.Checked = true;
                    }
                    else
                    {
                        chk2.Checked = false;
                        txtLeft2.Text = "0";
                        txtLeft2.ReadOnly = true;
                        txtTop2.Text = "0";
                        txtTop2.ReadOnly = true;
                        txtWidth2.Text = "0";
                        txtWidth2.ReadOnly = true;
                        txtHeight2.Text = "0";
                        txtHeight2.ReadOnly = true;
                        txtNameLeft2.Text = "0";
                        txtNameLeft2.ReadOnly = true;
                        txtNameTop2.Text = "0";
                        txtNameTop2.ReadOnly = true;
                        txtNameWidth2.Text = "0";
                        txtNameWidth2.ReadOnly = true;
                        txtName2.Text = "";
                        txtName2.ReadOnly = true;
                        cmbFSize2.SelectedIndex = 1;
                        cmbFSize2.Enabled = false;
                        cmbAlign2.SelectedIndex = 1;
                        cmbAlign2.Enabled = false;
                        cmbNameAlign2.SelectedIndex = 1;
                        cmbNameAlign2.Enabled = false;
                        cmbStyle2.SelectedIndex = 1;
                        cmbStyle2.Enabled = false;

                    }
                }
                else if (value_name == "Date")
                {
                    txtLeft3.Text = left;
                    txtTop3.Text = top;
                    txtWidth3.Text = width;
                    txtName3.Text = lname;
                    txtNameLeft3.Text = lleft;
                    txtNameTop3.Text = ltop;
                    txtNameWidth3.Text = lwidth;
                    txtHeight3.Text = height;
                    cmbFSize3.Text = fsize;
                    cmbStyle3.SelectedIndex = cmbStyle3.FindString(fontStyle);
                    cmbAlign3.Text = align;
                    cmbNameAlign3.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk3.Checked = true;
                    }
                    else
                    {
                        chk3.Checked = false;
                        txtLeft3.Text = "0";
                        txtLeft3.ReadOnly = true;
                        txtTop3.Text = "0";
                        txtTop3.ReadOnly = true;
                        txtWidth3.Text = "0";
                        txtWidth3.ReadOnly = true;
                        txtHeight3.Text = "0";
                        txtHeight3.ReadOnly = true;
                        txtNameLeft3.Text = "0";
                        txtNameLeft3.ReadOnly = true;
                        txtNameTop3.Text = "0";
                        txtNameTop3.ReadOnly = true;
                        txtNameWidth3.Text = "0";
                        txtNameWidth3.ReadOnly = true;
                        txtName3.Text = "";
                        txtName3.ReadOnly = true;
                        cmbFSize3.SelectedIndex = 1;
                        cmbFSize3.Enabled = false;
                        cmbAlign3.SelectedIndex = 1;
                        cmbAlign3.Enabled = false;
                        cmbNameAlign3.SelectedIndex = 1;
                        cmbNameAlign3.Enabled = false;
                        cmbStyle3.SelectedIndex = 1;
                        cmbStyle3.Enabled = false;

                    }
                }
                else if (value_name == "Time")
                {
                    txtLeft4.Text = left;
                    txtTop4.Text = top;
                    txtWidth4.Text = width;
                    txtName4.Text = lname;
                    txtNameLeft4.Text = lleft;
                    txtNameTop4.Text = ltop;
                    txtNameWidth4.Text = lwidth;
                    txtHeight4.Text = height;
                    cmbFSize4.Text = fsize;
                    cmbStyle4.SelectedIndex = cmbStyle4.FindString(fontStyle);
                    cmbAlign4.Text = align;
                    cmbNameAlign4.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk4.Checked = true;
                    }
                    else
                    {
                        chk4.Checked = false;
                        txtLeft4.Text = "0";
                        txtLeft4.ReadOnly = true;
                        txtTop4.Text = "0";
                        txtTop4.ReadOnly = true;
                        txtWidth4.Text = "0";
                        txtWidth4.ReadOnly = true;
                        txtHeight4.Text = "0";
                        txtHeight4.ReadOnly = true;
                        txtNameLeft4.Text = "0";
                        txtNameLeft4.ReadOnly = true;
                        txtNameTop4.Text = "0";
                        txtNameTop4.ReadOnly = true;
                        txtNameWidth4.Text = "0";
                        txtNameWidth4.ReadOnly = true;
                        txtName4.Text = "";
                        txtName4.ReadOnly = true;
                        cmbFSize4.SelectedIndex = 1;
                        cmbFSize4.Enabled = false;
                        cmbAlign4.SelectedIndex = 1;
                        cmbAlign4.Enabled = false;
                        cmbNameAlign4.SelectedIndex = 1;
                        cmbNameAlign4.Enabled = false;
                        cmbStyle4.SelectedIndex = 1;
                        cmbStyle4.Enabled = false;

                    }

                }
                else if (value_name == "Sub Total")
                {
                    txtLeft5.Text = left;
                    txtTop5.Text = top;
                    txtWidth5.Text = width;
                    txtName5.Text = lname;
                    txtNameLeft5.Text = lleft;
                    txtNameTop5.Text = ltop;
                    txtNameWidth5.Text = lwidth;
                    txtHeight5.Text = height;
                    cmbFSize5.Text = fsize;
                    cmbStyle5.SelectedIndex = cmbStyle5.FindString(fontStyle);
                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    cmbAlign5.Text = align;
                    cmbNameAlign5.Text = lalign;

                    if (needToPrint == 1)
                    {
                        chk5.Checked = true;
                    }
                    else
                    {
                        chk5.Checked = false;
                        txtLeft5.Text = "0";
                        txtLeft5.ReadOnly = true;
                        txtTop5.Text = "0";
                        txtTop5.ReadOnly = true;
                        txtWidth5.Text = "0";
                        txtWidth5.ReadOnly = true;
                        txtHeight5.Text = "0";
                        txtHeight5.ReadOnly = true;
                        txtNameLeft5.Text = "0";
                        txtNameLeft5.ReadOnly = true;
                        txtNameTop5.Text = "0";
                        txtNameTop5.ReadOnly = true;
                        txtNameWidth5.Text = "0";
                        txtNameWidth5.ReadOnly = true;
                        txtName5.Text = "";
                        txtName5.ReadOnly = true;
                        cmbFSize5.SelectedIndex = 1;
                        cmbFSize5.Enabled = false;
                        cmbAlign5.SelectedIndex = 1;
                        cmbAlign5.Enabled = false;
                        cmbNameAlign5.SelectedIndex = 1;
                        cmbNameAlign5.Enabled = false;
                        cmbStyle5.SelectedIndex = 1;
                        cmbStyle5.Enabled = false;

                    }
                }
                else if (value_name == "Service Charge")
                {
                    txtLeft6.Text = left;
                    txtTop6.Text = top;
                    txtWidth6.Text = width;
                    txtName6.Text = lname;
                    txtNameLeft6.Text = lleft;
                    txtNameTop6.Text = ltop;
                    txtNameWidth6.Text = lwidth;
                    txtHeight6.Text = height;
                    cmbFSize6.Text = fsize;
                    cmbStyle6.SelectedIndex = cmbStyle6.FindString(fontStyle);
                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    cmbAlign6.Text = align;
                    cmbNameAlign6.Text = lalign;

                    if (needToPrint == 1)
                    {
                        chk6.Checked = true;
                    }
                    else
                    {
                        chk6.Checked = false;
                        txtLeft6.Text = "0";
                        txtLeft6.ReadOnly = true;
                        txtTop6.Text = "0";
                        txtTop6.ReadOnly = true;
                        txtWidth6.Text = "0";
                        txtWidth6.ReadOnly = true;
                        txtHeight6.Text = "0";
                        txtHeight6.ReadOnly = true;
                        txtNameLeft6.Text = "0";
                        txtNameLeft6.ReadOnly = true;
                        txtNameTop6.Text = "0";
                        txtNameTop6.ReadOnly = true;
                        txtNameWidth6.Text = "0";
                        txtNameWidth6.ReadOnly = true;
                        txtName6.Text = "";
                        txtName6.ReadOnly = true;
                        cmbFSize6.SelectedIndex = 1;
                        cmbFSize6.Enabled = false;
                        cmbAlign6.SelectedIndex = 1;
                        cmbAlign6.Enabled = false;
                        cmbNameAlign6.SelectedIndex = 1;
                        cmbNameAlign6.Enabled = false;
                        cmbStyle6.SelectedIndex = 1;
                        cmbStyle6.Enabled = false;

                    }
                }
                else if (value_name == "Full Total")
                {
                    txtLeft7.Text = left;
                    txtTop7.Text = top;
                    txtWidth7.Text = width;
                    txtName7.Text = lname;
                    txtNameLeft7.Text = lleft;
                    txtNameTop7.Text = ltop;
                    txtNameWidth7.Text = lwidth;
                    txtHeight7.Text = height;
                    cmbFSize7.Text = fsize;
                    cmbStyle7.SelectedIndex = cmbStyle7.FindString(fontStyle);
                    cmbAlign7.Text = align;
                    cmbNameAlign7.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk7.Checked = true;
                    }
                    else
                    {
                        chk7.Checked = false;
                        txtLeft7.Text = "0";
                        txtLeft7.ReadOnly = true;
                        txtTop7.Text = "0";
                        txtTop7.ReadOnly = true;
                        txtWidth7.Text = "0";
                        txtWidth7.ReadOnly = true;
                        txtHeight7.Text = "0";
                        txtHeight7.ReadOnly = true;
                        txtNameLeft7.Text = "0";
                        txtNameLeft7.ReadOnly = true;
                        txtNameTop7.Text = "0";
                        txtNameTop7.ReadOnly = true;
                        txtNameWidth7.Text = "0";
                        txtNameWidth7.ReadOnly = true;
                        txtName7.Text = "";
                        txtName7.ReadOnly = true;
                        cmbFSize7.SelectedIndex = 1;
                        cmbFSize7.Enabled = false;
                        cmbAlign7.SelectedIndex = 1;
                        cmbAlign7.Enabled = false;
                        cmbNameAlign7.SelectedIndex = 1;
                        cmbNameAlign7.Enabled = false;
                        cmbStyle7.SelectedIndex = 1;
                        cmbStyle7.Enabled = false;

                    }
                }
                else if (value_name == "Casher")
                {
                    txtLeft8.Text = left;
                    txtTop8.Text = top;
                    txtWidth8.Text = width;
                    txtName8.Text = lname;
                    txtNameLeft8.Text = lleft;
                    txtNameTop8.Text = ltop;
                    txtNameWidth8.Text = lwidth;
                    txtHeight8.Text = height;
                    cmbFSize8.Text = fsize;
                    cmbStyle8.SelectedIndex = cmbStyle8.FindString(fontStyle);
                    cmbAlign8.Text = align;
                    cmbNameAlign8.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk8.Checked = true;
                    }
                    else
                    {
                        chk8.Checked = false;
                        txtLeft8.Text = "0";
                        txtLeft8.ReadOnly = true;
                        txtTop8.Text = "0";
                        txtTop8.ReadOnly = true;
                        txtWidth8.Text = "0";
                        txtWidth8.ReadOnly = true;
                        txtHeight8.Text = "0";
                        txtHeight8.ReadOnly = true;
                        txtNameLeft8.Text = "0";
                        txtNameLeft8.ReadOnly = true;
                        txtNameTop8.Text = "0";
                        txtNameTop8.ReadOnly = true;
                        txtNameWidth8.Text = "0";
                        txtNameWidth8.ReadOnly = true;
                        txtName8.Text = "";
                        txtName8.ReadOnly = true;
                        cmbFSize8.SelectedIndex = 1;
                        cmbFSize8.Enabled = false;
                        cmbAlign8.SelectedIndex = 1;
                        cmbAlign8.Enabled = false;
                        cmbNameAlign8.SelectedIndex = 1;
                        cmbNameAlign8.Enabled = false;
                        cmbStyle8.SelectedIndex = 1;
                        cmbStyle8.Enabled = false;

                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ctrl = new BillPrintingControler();

            this.SetCheckBoxcontolValues(chk1, txtLeft1, txtTop1, txtWidth1, txtName1, txtNameLeft1, txtNameTop1, txtNameWidth1, txtHeight1, cmbFSize1.Text, cmbAlign1.Text, cmbNameAlign1.Text, cmbStyle1.Text);
            this.SetCheckBoxcontolValues(chk2, txtLeft2, txtTop2, txtWidth2, txtName2, txtNameLeft2, txtNameTop2, txtNameWidth2, txtHeight2, cmbFSize2.Text, cmbAlign2.Text, cmbNameAlign2.Text, cmbStyle2.Text);
            this.SetCheckBoxcontolValues(chk3, txtLeft3, txtTop3, txtWidth3, txtName3, txtNameLeft3, txtNameTop3, txtNameWidth3, txtHeight3, cmbFSize3.Text, cmbAlign3.Text, cmbNameAlign3.Text, cmbStyle3.Text);
            this.SetCheckBoxcontolValues(chk4, txtLeft4, txtTop4, txtWidth4, txtName4, txtNameLeft4, txtNameTop4, txtNameWidth4, txtHeight4, cmbFSize4.Text, cmbAlign4.Text, cmbNameAlign4.Text, cmbStyle4.Text);
            this.SetCheckBoxcontolValues(chk5, txtLeft5, txtTop5, txtWidth5, txtName5, txtNameLeft5, txtNameTop5, txtNameWidth5, txtHeight5, cmbFSize5.Text, cmbAlign5.Text, cmbNameAlign5.Text, cmbStyle5.Text);
            this.SetCheckBoxcontolValues(chk6, txtLeft6, txtTop6, txtWidth6, txtName6, txtNameLeft6, txtNameTop6, txtNameWidth6, txtHeight6, cmbFSize6.Text, cmbAlign6.Text, cmbNameAlign6.Text, cmbStyle6.Text);
            this.SetCheckBoxcontolValues(chk7, txtLeft7, txtTop7, txtWidth7, txtName7, txtNameLeft7, txtNameTop7, txtNameWidth7, txtHeight7, cmbFSize7.Text, cmbAlign7.Text, cmbNameAlign7.Text, cmbStyle7.Text);
            this.SetCheckBoxcontolValues(chk8, txtLeft8, txtTop8, txtWidth8, txtName8, txtNameLeft8, txtNameTop8, txtNameWidth8, txtHeight8, cmbFSize8.Text, cmbAlign8.Text, cmbNameAlign8.Text, cmbStyle8.Text);
            

            bool flag = ctrl.Save_Bill_Printing_Data_Settings(listBillInfo);

            if (flag)
            {
                MessageBox.Show("Successfully Saved");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not Saved Successfully");
            }
        }

        private void SetCheckBoxcontolValues(CheckBox checkBoxName, TextBox left, TextBox top, TextBox width, TextBox descrip, TextBox Nleft, TextBox Ntop, TextBox Nwidth, TextBox height, string Fsize, string align, string lalign, string style)
        {
            int tleft1 = int.Parse(left.Text);
            int ttop1 = int.Parse(top.Text);
            int twidth = int.Parse(width.Text);
            int theight = int.Parse(height.Text);
            int nleft = int.Parse(Nleft.Text);
            int ntop = int.Parse(Ntop.Text);
            int nwidth = int.Parse(Nwidth.Text);
            string desc = descrip.Text.ToString();
            string fsize = Fsize;
            string fstyle = style;
            string falign = align;
            string flalign = lalign;



            BillMargingInfo billInfo = new BillMargingInfo();
            billInfo.Value_Name = checkBoxName.Text;
            if (checkBoxName.Checked)
                billInfo.Need_To_Print = 1;
            else
                billInfo.Need_To_Print = 0;
            billInfo.Left_Margin = tleft1;
            billInfo.Top_Margin = ttop1;
            billInfo.Width = twidth;
            billInfo.Object_Name = BillName;
            billInfo.Lable_Name = desc;
            billInfo.Lbl_Left_Margin = nleft;
            billInfo.Lbl_Top_Margin = ntop;
            billInfo.Lbl_Width = nwidth;
            if (fsize == "")
            {
                billInfo.FontSize = float.Parse("10");
            }
            else
            {
                billInfo.FontSize = float.Parse(fsize);
            }
            billInfo.Hight = theight;
            billInfo.FontStyle = fstyle;
            billInfo.Align = falign;
            billInfo.Label_Align = flalign;

            this.listBillInfo.Add(billInfo); 
        }

        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox ch = (CheckBox)sender;
            string IDNo = ch.Tag.ToString();
            Control[] c = this.Controls.Find("txtLeft" + IDNo, true);
            Control[] cTop = this.Controls.Find("txtTop" + IDNo, true);
            Control[] cWidth = this.Controls.Find("txtWidth" + IDNo, true);
            Control[] cDescription = this.Controls.Find("txtName" + IDNo, true);
            Control[] c2 = this.Controls.Find("txtNameLeft" + IDNo, true);
            Control[] cTop2 = this.Controls.Find("txtNameTop" + IDNo, true);
            Control[] cWidth2 = this.Controls.Find("txtNameWidth" + IDNo, true);
            Control[] cHeight = this.Controls.Find("txtHeight" + IDNo, true);
            Control[] cFSize = this.Controls.Find("cmbFSize" + IDNo, true);
            Control[] cAlign = this.Controls.Find("cmbAlign" + IDNo, true);
            Control[] cLAlign = this.Controls.Find("cmbNameAlign" + IDNo, true);
            Control[] cFStyle = this.Controls.Find("cmbStyle" + IDNo, true);



            TextBox tLeft = (TextBox)c[0];
            TextBox tTop = (TextBox)cTop[0];
            TextBox tWidth = (TextBox)cWidth[0];
            TextBox tDescrip = (TextBox)cDescription[0];
            TextBox tLeft2 = (TextBox)c2[0];
            TextBox tTop2 = (TextBox)cTop2[0];
            TextBox tWidth2 = (TextBox)cWidth2[0];
            TextBox tHeight = (TextBox)cHeight[0];
            ComboBox tFsize = (ComboBox)cFSize[0];
            ComboBox tAlign = (ComboBox)cAlign[0];
            ComboBox tLAlign = (ComboBox)cLAlign[0];
            ComboBox tFstyle = (ComboBox)cFStyle[0];



            this.CheckChangeEvent(ch, tLeft, tTop, tWidth, tDescrip, tLeft2, tTop2, tWidth2, tHeight, tFsize, tAlign, tLAlign, tFstyle);
        }

        public void CheckChangeEvent(CheckBox ch, TextBox tLeft, TextBox tTop, TextBox tWidth, TextBox descrip, TextBox tLeft2, TextBox tTop2, TextBox tWidth2, TextBox height, ComboBox cmbFSize, ComboBox align, ComboBox lalign, ComboBox style)
        {
            if (ch.Checked)
            {
                tLeft.ReadOnly = false;
                tTop.ReadOnly = false;
                tWidth.ReadOnly = false;
                tLeft2.ReadOnly = false;
                tTop2.ReadOnly = false;
                tWidth2.ReadOnly = false;
                height.ReadOnly = false;
                cmbFSize.Enabled = true;
                descrip.ReadOnly = false;
                align.Enabled = true;
                lalign.Enabled = true;
                style.Enabled = true;

            }
            else
            {
                tLeft.ReadOnly = true;
                tTop.ReadOnly = true;
                tWidth.ReadOnly = true;
                tLeft.Text = "0";
                tTop.Text = "0";
                tWidth.Text = "0";
                tLeft2.ReadOnly = true;
                tTop2.ReadOnly = true;
                tWidth2.ReadOnly = true;
                tLeft2.Text = "0";
                tTop2.Text = "0";
                tWidth2.Text = "0";
                height.ReadOnly = true;
                height.Text = "0";
                descrip.Text = "";
                descrip.ReadOnly = true;
                cmbFSize.SelectedIndex = 0;
                cmbFSize.Enabled = false;
                align.SelectedIndex = 0;
                align.Enabled = false;
                lalign.SelectedIndex = 0;
                lalign.Enabled = false;
                style.SelectedIndex = 0;
                style.Enabled = false;
            }
        }
    }
}
