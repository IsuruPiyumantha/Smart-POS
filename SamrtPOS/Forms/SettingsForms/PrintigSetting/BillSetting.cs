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
    public partial class BillSetting : Form
    {
        List<BillMargingInfo> listBillInfo = new List<BillMargingInfo>();
        private BillPrintingControler ctrl;
        private string BillName;

        public BillSetting()
        {
            InitializeComponent();
        }

        public BillSetting(string p)
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


                if (value_name == "Company Name")
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
                else if (value_name == "Company Address")
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
                else if (value_name == "Company MobileNo")
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
                else if (value_name == "Invoice No")
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
                else if (value_name == "Table Name")
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
                else if (value_name == "Casher")
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
                else if (value_name == "Date")
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
                else if (value_name == "Time")
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

                else if (value_name == "Sub Total")
                {
                    txtLeft9.Text = left;
                    txtTop9.Text = top;
                    txtWidth9.Text = width;
                    txtName9.Text = lname;
                    txtNameLeft9.Text = lleft;
                    txtNameTop9.Text = ltop;
                    txtNameWidth9.Text = lwidth;
                    txtHeight9.Text = height;
                    cmbFSize9.Text = fsize;
                    cmbStyle9.SelectedIndex = cmbStyle9.FindString(fontStyle);
                    cmbAlign9.Text = align;
                    cmbNameAlign9.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk9.Checked = true;
                    }
                    else
                    {
                        chk9.Checked = false;
                        txtLeft9.Text = "0";
                        txtLeft9.ReadOnly = true;
                        txtTop9.Text = "0";
                        txtTop9.ReadOnly = true;
                        txtWidth9.Text = "0";
                        txtWidth9.ReadOnly = true;
                        txtHeight9.Text = "0";
                        txtHeight9.ReadOnly = true;
                        txtNameLeft9.Text = "0";
                        txtNameLeft9.ReadOnly = true;
                        txtNameTop9.Text = "0";
                        txtNameTop9.ReadOnly = true;
                        txtNameWidth9.Text = "0";
                        txtNameWidth9.ReadOnly = true;
                        txtName9.Text = "";
                        txtName9.ReadOnly = true;
                        cmbFSize9.SelectedIndex = 1;
                        cmbFSize9.Enabled = false;
                        cmbAlign9.SelectedIndex = 1;
                        cmbAlign9.Enabled = false;
                        cmbNameAlign9.SelectedIndex = 1;
                        cmbNameAlign9.Enabled = false;
                        cmbStyle9.SelectedIndex = 1;
                        cmbStyle9.Enabled = false;

                    }
                }
                else if (value_name == "Service Charge")
                {
                    txtLeft10.Text = left;
                    txtTop10.Text = top;
                    txtWidth10.Text = width;
                    txtName10.Text = lname;
                    txtNameLeft10.Text = lleft;
                    txtNameTop10.Text = ltop;
                    txtNameWidth10.Text = lwidth;
                    txtHeight10.Text = height;
                    cmbFSize10.Text = fsize;
                    cmbStyle10.SelectedIndex = cmbStyle10.FindString(fontStyle);
                    cmbAlign10.Text = align;
                    cmbNameAlign10.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk10.Checked = true;
                    }
                    else
                    {
                        chk10.Checked = false;
                        txtLeft10.Text = "0";
                        txtLeft10.ReadOnly = true;
                        txtTop10.Text = "0";
                        txtTop10.ReadOnly = true;
                        txtWidth10.Text = "0";
                        txtWidth10.ReadOnly = true;
                        txtHeight10.Text = "0";
                        txtHeight10.ReadOnly = true;
                        txtNameLeft10.Text = "0";
                        txtNameLeft10.ReadOnly = true;
                        txtNameTop10.Text = "0";
                        txtNameTop10.ReadOnly = true;
                        txtNameWidth10.Text = "0";
                        txtNameWidth10.ReadOnly = true;
                        txtName10.Text = "";
                        txtName10.ReadOnly = true;
                        cmbFSize10.SelectedIndex = 1;
                        cmbFSize10.Enabled = false;
                        cmbAlign10.SelectedIndex = 1;
                        cmbAlign10.Enabled = false;
                        cmbNameAlign10.SelectedIndex = 1;
                        cmbNameAlign10.Enabled = false;
                        cmbStyle10.SelectedIndex = 1;
                        cmbStyle10.Enabled = false;

                    }
                }
                else if (value_name == "Card Pay Fee")
                {
                    txtLeft11.Text = left;
                    txtTop11.Text = top;
                    txtWidth11.Text = width;
                    txtName11.Text = lname;
                    txtNameLeft11.Text = lleft;
                    txtNameTop11.Text = ltop;
                    txtNameWidth11.Text = lwidth;
                    txtHeight11.Text = height;
                    cmbFSize11.Text = fsize;
                    cmbStyle11.SelectedIndex = cmbStyle11.FindString(fontStyle);
                    cmbAlign11.Text = align;
                    cmbNameAlign11.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk11.Checked = true;
                    }
                    else
                    {
                        chk11.Checked = false;
                        txtLeft11.Text = "0";
                        txtLeft11.ReadOnly = true;
                        txtTop11.Text = "0";
                        txtTop11.ReadOnly = true;
                        txtWidth11.Text = "0";
                        txtWidth11.ReadOnly = true;
                        txtHeight11.Text = "0";
                        txtHeight11.ReadOnly = true;
                        txtNameLeft11.Text = "0";
                        txtNameLeft11.ReadOnly = true;
                        txtNameTop11.Text = "0";
                        txtNameTop11.ReadOnly = true;
                        txtNameWidth11.Text = "0";
                        txtNameWidth11.ReadOnly = true;
                        txtName11.Text = "";
                        txtName11.ReadOnly = true;
                        cmbFSize11.SelectedIndex = 1;
                        cmbFSize11.Enabled = false;
                        cmbAlign11.SelectedIndex = 1;
                        cmbAlign11.Enabled = false;
                        cmbNameAlign11.SelectedIndex = 1;
                        cmbNameAlign11.Enabled = false;
                        cmbStyle11.SelectedIndex = 1;
                        cmbStyle11.Enabled = false;

                    }
                }
                else if (value_name == "Tax")
                {
                    txtLeft12.Text = left;
                    txtTop12.Text = top;
                    txtWidth12.Text = width;
                    txtName12.Text = lname;
                    txtNameLeft12.Text = lleft;
                    txtNameTop12.Text = ltop;
                    txtNameWidth12.Text = lwidth;
                    txtHeight12.Text = height;
                    cmbFSize12.Text = fsize;
                    cmbStyle12.SelectedIndex = cmbStyle12.FindString(fontStyle);
                    cmbAlign12.Text = align;
                    cmbNameAlign12.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk12.Checked = true;
                    }
                    else
                    {
                        chk12.Checked = false;
                        txtLeft12.Text = "0";
                        txtLeft12.ReadOnly = true;
                        txtTop12.Text = "0";
                        txtTop12.ReadOnly = true;
                        txtWidth12.Text = "0";
                        txtWidth12.ReadOnly = true;
                        txtHeight12.Text = "0";
                        txtHeight12.ReadOnly = true;
                        txtNameLeft12.Text = "0";
                        txtNameLeft12.ReadOnly = true;
                        txtNameTop12.Text = "0";
                        txtNameTop12.ReadOnly = true;
                        txtNameWidth12.Text = "0";
                        txtNameWidth12.ReadOnly = true;
                        txtName12.Text = "";
                        txtName12.ReadOnly = true;
                        cmbFSize12.SelectedIndex = 1;
                        cmbFSize12.Enabled = false;
                        cmbAlign12.SelectedIndex = 1;
                        cmbAlign12.Enabled = false;
                        cmbNameAlign12.SelectedIndex = 1;
                        cmbNameAlign12.Enabled = false;
                        cmbStyle12.SelectedIndex = 1;
                        cmbStyle12.Enabled = false;

                    }
                }
                else if (value_name == "Net Total")
                {
                    txtLeft13.Text = left;
                    txtTop13.Text = top;
                    txtWidth13.Text = width;
                    txtName13.Text = lname;
                    txtNameLeft13.Text = lleft;
                    txtNameTop13.Text = ltop;
                    txtNameWidth13.Text = lwidth;
                    txtHeight13.Text = height;
                    cmbFSize13.Text = fsize;
                    cmbStyle13.SelectedIndex = cmbStyle13.FindString(fontStyle);
                    cmbAlign13.Text = align;
                    cmbNameAlign13.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk13.Checked = true;
                    }
                    else
                    {
                        chk13.Checked = false;
                        txtLeft13.Text = "0";
                        txtLeft13.ReadOnly = true;
                        txtTop13.Text = "0";
                        txtTop13.ReadOnly = true;
                        txtWidth13.Text = "0";
                        txtWidth13.ReadOnly = true;
                        txtHeight13.Text = "0";
                        txtHeight13.ReadOnly = true;
                        txtNameLeft13.Text = "0";
                        txtNameLeft13.ReadOnly = true;
                        txtNameTop13.Text = "0";
                        txtNameTop13.ReadOnly = true;
                        txtNameWidth13.Text = "0";
                        txtNameWidth13.ReadOnly = true;
                        txtName13.Text = "";
                        txtName13.ReadOnly = true;
                        cmbFSize13.SelectedIndex = 1;
                        cmbFSize13.Enabled = false;
                        cmbAlign13.SelectedIndex = 1;
                        cmbAlign13.Enabled = false;
                        cmbNameAlign13.SelectedIndex = 1;
                        cmbNameAlign13.Enabled = false;
                        cmbStyle13.SelectedIndex = 1;
                        cmbStyle13.Enabled = false;

                    }
                }
                else if (value_name == "Discoun")
                {
                    txtLeft14.Text = left;
                    txtTop14.Text = top;
                    txtWidth14.Text = width;
                    txtName14.Text = lname;
                    txtNameLeft14.Text = lleft;
                    txtNameTop14.Text = ltop;
                    txtNameWidth14.Text = lwidth;
                    txtHeight14.Text = height;
                    cmbFSize14.Text = fsize;
                    cmbStyle14.SelectedIndex = cmbStyle14.FindString(fontStyle);
                    cmbAlign14.Text = align;
                    cmbNameAlign14.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk14.Checked = true;
                    }
                    else
                    {
                        chk14.Checked = false;
                        txtLeft14.Text = "0";
                        txtLeft14.ReadOnly = true;
                        txtTop14.Text = "0";
                        txtTop14.ReadOnly = true;
                        txtWidth14.Text = "0";
                        txtWidth14.ReadOnly = true;
                        txtHeight14.Text = "0";
                        txtHeight14.ReadOnly = true;
                        txtNameLeft14.Text = "0";
                        txtNameLeft14.ReadOnly = true;
                        txtNameTop14.Text = "0";
                        txtNameTop14.ReadOnly = true;
                        txtNameWidth14.Text = "0";
                        txtNameWidth14.ReadOnly = true;
                        txtName14.Text = "";
                        txtName14.ReadOnly = true;
                        cmbFSize14.SelectedIndex = 1;
                        cmbFSize14.Enabled = false;
                        cmbAlign14.SelectedIndex = 1;
                        cmbAlign14.Enabled = false;
                        cmbNameAlign14.SelectedIndex = 1;
                        cmbNameAlign14.Enabled = false;
                        cmbStyle14.SelectedIndex = 1;
                        cmbStyle14.Enabled = false;

                    }
                }
                else if (value_name == "Total")
                {
                    txtLeft15.Text = left;
                    txtTop15.Text = top;
                    txtWidth15.Text = width;
                    txtName15.Text = lname;
                    txtNameLeft15.Text = lleft;
                    txtNameTop15.Text = ltop;
                    txtNameWidth15.Text = lwidth;
                    txtHeight15.Text = height;
                    cmbFSize15.Text = fsize;
                    cmbStyle15.SelectedIndex = cmbStyle15.FindString(fontStyle);
                    cmbAlign15.Text = align;
                    cmbNameAlign15.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk15.Checked = true;
                    }
                    else
                    {
                        chk15.Checked = false;
                        txtLeft15.Text = "0";
                        txtLeft15.ReadOnly = true;
                        txtTop15.Text = "0";
                        txtTop15.ReadOnly = true;
                        txtWidth15.Text = "0";
                        txtWidth15.ReadOnly = true;
                        txtHeight15.Text = "0";
                        txtHeight15.ReadOnly = true;
                        txtNameLeft15.Text = "0";
                        txtNameLeft15.ReadOnly = true;
                        txtNameTop15.Text = "0";
                        txtNameTop15.ReadOnly = true;
                        txtNameWidth15.Text = "0";
                        txtNameWidth15.ReadOnly = true;
                        txtName15.Text = "";
                        txtName15.ReadOnly = true;
                        cmbFSize15.SelectedIndex = 1;
                        cmbFSize15.Enabled = false;
                        cmbAlign15.SelectedIndex = 1;
                        cmbAlign15.Enabled = false;
                        cmbNameAlign15.SelectedIndex = 1;
                        cmbNameAlign15.Enabled = false;
                        cmbStyle15.SelectedIndex = 1;
                        cmbStyle15.Enabled = false;

                    }
                }
                else if (value_name == "Pay Amount")
                {
                    txtLeft16.Text = left;
                    txtTop16.Text = top;
                    txtWidth16.Text = width;
                    txtName16.Text = lname;
                    txtNameLeft16.Text = lleft;
                    txtNameTop16.Text = ltop;
                    txtNameWidth16.Text = lwidth;
                    txtHeight16.Text = height;
                    cmbFSize16.Text = fsize;
                    cmbStyle16.SelectedIndex = cmbStyle16.FindString(fontStyle);
                    cmbAlign16.Text = align;
                    cmbNameAlign16.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk16.Checked = true;
                    }
                    else
                    {
                        chk16.Checked = false;
                        txtLeft16.Text = "0";
                        txtLeft16.ReadOnly = true;
                        txtTop16.Text = "0";
                        txtTop16.ReadOnly = true;
                        txtWidth16.Text = "0";
                        txtWidth16.ReadOnly = true;
                        txtHeight16.Text = "0";
                        txtHeight16.ReadOnly = true;
                        txtNameLeft16.Text = "0";
                        txtNameLeft16.ReadOnly = true;
                        txtNameTop16.Text = "0";
                        txtNameTop16.ReadOnly = true;
                        txtNameWidth16.Text = "0";
                        txtNameWidth16.ReadOnly = true;
                        txtName16.Text = "";
                        txtName16.ReadOnly = true;
                        cmbFSize16.SelectedIndex = 1;
                        cmbFSize16.Enabled = false;
                        cmbAlign16.SelectedIndex = 1;
                        cmbAlign16.Enabled = false;
                        cmbNameAlign16.SelectedIndex = 1;
                        cmbNameAlign16.Enabled = false;
                        cmbStyle16.SelectedIndex = 1;
                        cmbStyle16.Enabled = false;

                    }
                }

                else if (value_name == "Balance Amount")
                {
                    txtLeft17.Text = left;
                    txtTop17.Text = top;
                    txtWidth17.Text = width;
                    txtName17.Text = lname;
                    txtNameLeft17.Text = lleft;
                    txtNameTop17.Text = ltop;
                    txtNameWidth17.Text = lwidth;
                    txtHeight17.Text = height;
                    cmbFSize17.Text = fsize;
                    cmbStyle17.SelectedIndex = cmbStyle17.FindString(fontStyle);
                    cmbAlign17.Text = align;
                    cmbNameAlign17.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk17.Checked = true;
                    }
                    else
                    {
                        chk17.Checked = false;
                        txtLeft17.Text = "0";
                        txtLeft17.ReadOnly = true;
                        txtTop17.Text = "0";
                        txtTop17.ReadOnly = true;
                        txtWidth17.Text = "0";
                        txtWidth17.ReadOnly = true;
                        txtHeight17.Text = "0";
                        txtHeight17.ReadOnly = true;
                        txtNameLeft17.Text = "0";
                        txtNameLeft17.ReadOnly = true;
                        txtNameTop17.Text = "0";
                        txtNameTop17.ReadOnly = true;
                        txtNameWidth17.Text = "0";
                        txtNameWidth17.ReadOnly = true;
                        txtName17.Text = "";
                        txtName17.ReadOnly = true;
                        cmbFSize17.SelectedIndex = 1;
                        cmbFSize17.Enabled = false;
                        cmbAlign17.SelectedIndex = 1;
                        cmbAlign17.Enabled = false;
                        cmbNameAlign17.SelectedIndex = 1;
                        cmbNameAlign17.Enabled = false;
                        cmbStyle17.SelectedIndex = 1;
                        cmbStyle17.Enabled = false;

                    }
                }
                else if (value_name == "BarCode")
                {
                    txtLeft18.Text = left;
                    txtTop18.Text = top;
                    txtWidth18.Text = width;
                    txtName18.Text = lname;
                    txtNameLeft18.Text = lleft;
                    txtNameTop18.Text = ltop;
                    txtNameWidth18.Text = lwidth;
                    txtHeight18.Text = height;
                    cmbFSize18.Text = fsize;
                    cmbStyle18.SelectedIndex = cmbStyle18.FindString(fontStyle);
                    cmbAlign18.Text = align;
                    cmbNameAlign18.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk18.Checked = true;
                    }
                    else
                    {
                        chk18.Checked = false;
                        txtLeft18.Text = "0";
                        txtLeft18.ReadOnly = true;
                        txtTop18.Text = "0";
                        txtTop18.ReadOnly = true;
                        txtWidth18.Text = "0";
                        txtWidth18.ReadOnly = true;
                        txtHeight18.Text = "0";
                        txtHeight18.ReadOnly = true;
                        txtNameLeft18.Text = "0";
                        txtNameLeft18.ReadOnly = true;
                        txtNameTop18.Text = "0";
                        txtNameTop18.ReadOnly = true;
                        txtNameWidth18.Text = "0";
                        txtNameWidth18.ReadOnly = true;
                        txtName18.Text = "";
                        txtName18.ReadOnly = true;
                        cmbFSize18.SelectedIndex = 1;
                        cmbFSize18.Enabled = false;
                        cmbAlign18.SelectedIndex = 1;
                        cmbAlign18.Enabled = false;
                        cmbNameAlign18.SelectedIndex = 1;
                        cmbNameAlign18.Enabled = false;
                        cmbStyle18.SelectedIndex = 1;
                        cmbStyle18.Enabled = false;

                    }
                }
                else if (value_name == "Message")
                {
                    txtLeft19.Text = left;
                    txtTop19.Text = top;
                    txtWidth19.Text = width;
                    txtName19.Text = lname;
                    txtNameLeft19.Text = lleft;
                    txtNameTop19.Text = ltop;
                    txtNameWidth19.Text = lwidth;
                    txtHeight19.Text = height;
                    cmbFSize19.Text = fsize;
                    cmbStyle19.SelectedIndex = cmbStyle19.FindString(fontStyle);
                    cmbAlign19.Text = align;
                    cmbNameAlign19.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk19.Checked = true;
                    }
                    else
                    {
                        chk19.Checked = false;
                        txtLeft19.Text = "0";
                        txtLeft19.ReadOnly = true;
                        txtTop19.Text = "0";
                        txtTop19.ReadOnly = true;
                        txtWidth19.Text = "0";
                        txtWidth19.ReadOnly = true;
                        txtHeight19.Text = "0";
                        txtHeight19.ReadOnly = true;
                        txtNameLeft19.Text = "0";
                        txtNameLeft19.ReadOnly = true;
                        txtNameTop19.Text = "0";
                        txtNameTop19.ReadOnly = true;
                        txtNameWidth19.Text = "0";
                        txtNameWidth19.ReadOnly = true;
                        txtName19.Text = "";
                        txtName19.ReadOnly = true;
                        cmbFSize19.SelectedIndex = 1;
                        cmbFSize19.Enabled = false;
                        cmbAlign19.SelectedIndex = 1;
                        cmbAlign19.Enabled = false;
                        cmbNameAlign19.SelectedIndex = 1;
                        cmbNameAlign19.Enabled = false;
                        cmbStyle19.SelectedIndex = 1;
                        cmbStyle19.Enabled = false;

                    }
                }
                else if (value_name == "Software Company Name")
                {
                    txtLeft20.Text = left;
                    txtTop20.Text = top;
                    txtWidth20.Text = width;
                    txtName20.Text = lname;
                    txtNameLeft20.Text = lleft;
                    txtNameTop20.Text = ltop;
                    txtNameWidth20.Text = lwidth;
                    txtHeight20.Text = height;
                    cmbFSize20.Text = fsize;
                    cmbStyle20.SelectedIndex = cmbStyle19.FindString(fontStyle);
                    cmbAlign20.Text = align;
                    cmbNameAlign20.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk20.Checked = true;
                    }
                    else
                    {
                        chk20.Checked = false;
                        txtLeft20.Text = "0";
                        txtLeft20.ReadOnly = true;
                        txtTop20.Text = "0";
                        txtTop20.ReadOnly = true;
                        txtWidth20.Text = "0";
                        txtWidth20.ReadOnly = true;
                        txtHeight20.Text = "0";
                        txtHeight20.ReadOnly = true;
                        txtNameLeft20.Text = "0";
                        txtNameLeft20.ReadOnly = true;
                        txtNameTop20.Text = "0";
                        txtNameTop20.ReadOnly = true;
                        txtNameWidth20.Text = "0";
                        txtNameWidth20.ReadOnly = true;
                        txtName20.Text = "";
                        txtName20.ReadOnly = true;
                        cmbFSize20.SelectedIndex = 1;
                        cmbFSize20.Enabled = false;
                        cmbAlign20.SelectedIndex = 1;
                        cmbAlign20.Enabled = false;
                        cmbNameAlign20.SelectedIndex = 1;
                        cmbNameAlign20.Enabled = false;
                        cmbStyle20.SelectedIndex = 1;
                        cmbStyle20.Enabled = false;

                    }
                }

                else if (value_name == "Software Company Mobile")
                {
                    txtLeft21.Text = left;
                    txtTop21.Text = top;
                    txtWidth21.Text = width;
                    txtName21.Text = lname;
                    txtNameLeft21.Text = lleft;
                    txtNameTop21.Text = ltop;
                    txtNameWidth21.Text = lwidth;
                    txtHeight21.Text = height;
                    cmbFSize21.Text = fsize;
                    cmbStyle21.SelectedIndex = cmbStyle21.FindString(fontStyle);
                    cmbAlign21.Text = align;
                    cmbNameAlign21.Text = lalign;

                    int needToPrint = int.Parse(r["NeedToPrint"].ToString());
                    if (needToPrint == 1)
                    {
                        chk21.Checked = true;
                    }
                    else
                    {
                        chk21.Checked = false;
                        txtLeft21.Text = "0";
                        txtLeft21.ReadOnly = true;
                        txtTop21.Text = "0";
                        txtTop21.ReadOnly = true;
                        txtWidth21.Text = "0";
                        txtWidth21.ReadOnly = true;
                        txtHeight21.Text = "0";
                        txtHeight21.ReadOnly = true;
                        txtNameLeft21.Text = "0";
                        txtNameLeft21.ReadOnly = true;
                        txtNameTop21.Text = "0";
                        txtNameTop21.ReadOnly = true;
                        txtNameWidth21.Text = "0";
                        txtNameWidth21.ReadOnly = true;
                        txtName21.Text = "";
                        txtName21.ReadOnly = true;
                        cmbFSize21.SelectedIndex = 1;
                        cmbFSize21.Enabled = false;
                        cmbAlign21.SelectedIndex = 1;
                        cmbAlign21.Enabled = false;
                        cmbNameAlign21.SelectedIndex = 1;
                        cmbNameAlign21.Enabled = false;
                        cmbStyle21.SelectedIndex = 1;
                        cmbStyle21.Enabled = false;
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
            this.SetCheckBoxcontolValues(chk9, txtLeft9, txtTop9, txtWidth9, txtName9, txtNameLeft9, txtNameTop9, txtNameWidth9, txtHeight9, cmbFSize9.Text, cmbAlign9.Text, cmbNameAlign9.Text, cmbStyle9.Text);
            this.SetCheckBoxcontolValues(chk10, txtLeft10, txtTop10, txtWidth10, txtName10, txtNameLeft10, txtNameTop10, txtNameWidth10, txtHeight10, cmbFSize10.Text, cmbAlign10.Text, cmbNameAlign10.Text, cmbStyle10.Text);
            this.SetCheckBoxcontolValues(chk11, txtLeft11, txtTop11, txtWidth11, txtName11, txtNameLeft11, txtNameTop11, txtNameWidth11, txtHeight11, cmbFSize11.Text, cmbAlign11.Text, cmbNameAlign11.Text, cmbStyle11.Text);
            this.SetCheckBoxcontolValues(chk12, txtLeft12, txtTop12, txtWidth12, txtName12, txtNameLeft12, txtNameTop12, txtNameWidth12, txtHeight12, cmbFSize12.Text, cmbAlign12.Text, cmbNameAlign12.Text, cmbStyle12.Text);
            this.SetCheckBoxcontolValues(chk13, txtLeft13, txtTop13, txtWidth13, txtName13, txtNameLeft13, txtNameTop13, txtNameWidth13, txtHeight13, cmbFSize13.Text, cmbAlign13.Text, cmbNameAlign13.Text, cmbStyle13.Text);
            this.SetCheckBoxcontolValues(chk14, txtLeft14, txtTop14, txtWidth14, txtName14, txtNameLeft14, txtNameTop14, txtNameWidth14, txtHeight14, cmbFSize14.Text, cmbAlign14.Text, cmbNameAlign14.Text, cmbStyle14.Text);
            this.SetCheckBoxcontolValues(chk15, txtLeft15, txtTop15, txtWidth15, txtName15, txtNameLeft15, txtNameTop15, txtNameWidth15, txtHeight15, cmbFSize15.Text, cmbAlign15.Text, cmbNameAlign15.Text, cmbStyle15.Text);
            this.SetCheckBoxcontolValues(chk16, txtLeft16, txtTop16, txtWidth16, txtName16, txtNameLeft16, txtNameTop16, txtNameWidth16, txtHeight16, cmbFSize16.Text, cmbAlign16.Text, cmbNameAlign16.Text, cmbStyle16.Text);
            this.SetCheckBoxcontolValues(chk17, txtLeft17, txtTop17, txtWidth17, txtName17, txtNameLeft17, txtNameTop17, txtNameWidth17, txtHeight17, cmbFSize17.Text, cmbAlign17.Text, cmbNameAlign17.Text, cmbStyle17.Text);
            this.SetCheckBoxcontolValues(chk18, txtLeft18, txtTop18, txtWidth18, txtName18, txtNameLeft18, txtNameTop18, txtNameWidth18, txtHeight18, cmbFSize18.Text, cmbAlign18.Text, cmbNameAlign18.Text, cmbStyle18.Text);
            this.SetCheckBoxcontolValues(chk19, txtLeft19, txtTop19, txtWidth19, txtName19, txtNameLeft19, txtNameTop19, txtNameWidth19, txtHeight19, cmbFSize19.Text, cmbAlign19.Text, cmbNameAlign19.Text, cmbStyle19.Text);
            this.SetCheckBoxcontolValues(chk20, txtLeft20, txtTop20, txtWidth20, txtName20, txtNameLeft20, txtNameTop20, txtNameWidth20, txtHeight20, cmbFSize20.Text, cmbAlign20.Text, cmbNameAlign20.Text, cmbStyle20.Text);
            this.SetCheckBoxcontolValues(chk21, txtLeft21, txtTop21, txtWidth21, txtName21, txtNameLeft21, txtNameTop21, txtNameWidth21, txtHeight21, cmbFSize21.Text, cmbAlign21.Text, cmbNameAlign21.Text, cmbStyle21.Text);

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
