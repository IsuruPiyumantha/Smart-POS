using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class Colors : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;

        public Colors()
        {
            InitializeComponent();
            SetColors();
        }

        private void SetColors()
        {
            MainPanel.BackColor = Color.FromName(Program.col);
            HeaderPanel.BackColor = Color.FromName(Program.col2);
            FooterPanel.BackColor = Color.FromName(Program.col2);
            lblHeadText.ForeColor = Color.FromName(Program.hText);

            GridColourClass styl = new GridColourClass();
            styl.FormNormalButtonMain(btnSave);
            styl.FormNormalButtonMain(btnClear);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllItemsDT()
        {
            conString = Program.ConnectionString.ToString();
            con = new MySqlConnection(conString);

            string sqlUser = "";

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        sqlUser = "SELECT * FROM tbl_pos_colors tpc;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                string pName = r["PanelName"].ToString();

                                if (pName == "col")
                                {
                                    string input = r["PanelColor"].ToString();
                                    Color red = Color.FromName(input);

                                    comboBox1.SelectedItem = red;
                                }
                                if (pName == "col2")
                                {
                                    string input = r["PanelColor"].ToString();
                                    Color red = Color.FromName(input);

                                    comboBox2.SelectedItem = red;
                                }
                                if (pName == "col3")
                                {
                                    string input = r["PanelColor"].ToString();
                                    Color red = Color.FromName(input);

                                    comboBox3.SelectedItem = red;
                                }
                                if (pName == "hText")
                                {
                                    string input = r["PanelColor"].ToString();
                                    Color red = Color.FromName(input);

                                    comboBox4.SelectedItem = red;
                                }
                                if (pName == "Text")
                                {
                                    string input = r["PanelColor"].ToString();
                                    Color red = Color.FromName(input);

                                    comboBox5.SelectedItem = red;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ErrorForm errorFrm = new ErrorForm(e.Message, sqlUser);
                errorFrm.ShowDialog();
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Savedata() == true)
            {
                MessageBox.Show("Successfull Update.");
                Application.Restart();
            }
            
        }
        public bool Savedata() 
        {
            bool IsSuccess = false;
            string sql = string.Empty;

            if (comboBox1.SelectedIndex < 1)
            {
                MessageBox.Show("Select Main Panel Color");
            }
            if (comboBox2.SelectedIndex < 1)
            {
                MessageBox.Show("Select Header/Footer Panel Color");
            }
            if (comboBox3.SelectedIndex < 1)
            {
                MessageBox.Show("Select Side Panel Color");
            }
            if (comboBox4.SelectedIndex < 1)
            {
                MessageBox.Show("Select Header Text Color");
            }
            if (comboBox5.SelectedIndex < 1)
            {
                MessageBox.Show("Select Text Color");
            }
            else
            {
                conString = Program.ConnectionString.ToString();
                con = new MySqlConnection(conString);

                try
                {
                    if (con.State.ToString() != "Open")
                    {
                        con.Open();

                        if (con != null)
                        {
                            sql = "UPDATE tbl_pos_colors tpc SET tpc.PanelColor = @colName WHERE tpc.PanelName = 'col';";
                            sql = sql + "UPDATE tbl_pos_colors tpc SET tpc.PanelColor = @col2Name WHERE tpc.PanelName = 'col2';";
                            sql = sql + "UPDATE tbl_pos_colors tpc SET tpc.PanelColor = @col3Name WHERE tpc.PanelName = 'col3';";
                            sql = sql + "UPDATE tbl_pos_colors tpc SET tpc.PanelColor = @hText WHERE tpc.PanelName = 'hText';";
                            sql = sql + "UPDATE tbl_pos_colors tpc SET tpc.PanelColor = @Text WHERE tpc.PanelName = 'Text';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);

                            string input = comboBox1.SelectedItem.ToString();
                            Regex regex = new Regex(@"\[(.+?)\]");
                            Match match = regex.Match(input);

                            if (match.Success)
                            {
                                string nameValue = match.Groups[1].Value;
                                cmd.Parameters.Add("@colName", nameValue);
                            }

                            input = comboBox2.SelectedItem.ToString();
                            regex = new Regex(@"\[(.+?)\]");
                            match = regex.Match(input);

                            if (match.Success)
                            {
                                string nameValue = match.Groups[1].Value;
                                cmd.Parameters.Add("@col2Name", nameValue);
                            }

                            input = comboBox3.SelectedItem.ToString();
                            regex = new Regex(@"\[(.+?)\]");
                            match = regex.Match(input);

                            if (match.Success)
                            {
                                string nameValue = match.Groups[1].Value;
                                cmd.Parameters.Add("@col3Name", nameValue);
                            }

                            input = comboBox4.SelectedItem.ToString();
                            regex = new Regex(@"\[(.+?)\]");
                            match = regex.Match(input);

                            if (match.Success)
                            {
                                string nameValue = match.Groups[1].Value;
                                cmd.Parameters.Add("@hText", nameValue);
                            }

                            input = comboBox5.SelectedItem.ToString();
                            regex = new Regex(@"\[(.+?)\]");
                            match = regex.Match(input);

                            if (match.Success)
                            {
                                string nameValue = match.Groups[1].Value;
                                cmd.Parameters.Add("@Text", nameValue);
                            }


                            cmd.ExecuteNonQuery();
                            IsSuccess = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorForm errorFrm = new ErrorForm(ex.Message, sql);
                    errorFrm.ShowDialog();
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
            return IsSuccess;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
        }

        private void Colors_Load(object sender, EventArgs e)
        {
            GetCokors();
            AllItemsDT();
        }

        private void GetCokors()
        {
            comboBox1.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();

            comboBox1.MaxDropDownItems = 10;
            comboBox1.IntegralHeight = false;
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DrawItem += comboBox1_DrawItem;

            comboBox2.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();

            comboBox2.MaxDropDownItems = 10;
            comboBox2.IntegralHeight = false;
            comboBox2.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DrawItem += comboBox1_DrawItem;

            comboBox3.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();

            comboBox3.MaxDropDownItems = 10;
            comboBox3.IntegralHeight = false;
            comboBox3.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DrawItem += comboBox1_DrawItem;

            comboBox4.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();

            comboBox4.MaxDropDownItems = 10;
            comboBox4.IntegralHeight = false;
            comboBox4.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DrawItem += comboBox1_DrawItem;

            comboBox5.DataSource = typeof(Color).GetProperties()
            .Where(x => x.PropertyType == typeof(Color))
            .Select(x => x.GetValue(null)).ToList();

            comboBox5.MaxDropDownItems = 10;
            comboBox5.IntegralHeight = false;
            comboBox5.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DrawItem += comboBox1_DrawItem;
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox1.GetItemText(comboBox1.Items[e.Index]);
                var color = (Color)comboBox1.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox1.Font, r2,
                    comboBox1.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox2.GetItemText(comboBox2.Items[e.Index]);
                var color = (Color)comboBox2.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox2.Font, r2,
                    comboBox2.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox3.GetItemText(comboBox3.Items[e.Index]);
                var color = (Color)comboBox3.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox3.Font, r2,
                    comboBox3.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void comboBox4_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox4.GetItemText(comboBox4.Items[e.Index]);
                var color = (Color)comboBox4.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox4.Font, r2,
                    comboBox4.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }

        private void comboBox5_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                var txt = comboBox5.GetItemText(comboBox5.Items[e.Index]);
                var color = (Color)comboBox5.Items[e.Index];
                var r1 = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1,
                    2 * (e.Bounds.Height - 2), e.Bounds.Height - 2);
                var r2 = Rectangle.FromLTRB(r1.Right + 2, e.Bounds.Top,
                    e.Bounds.Right, e.Bounds.Bottom);
                using (var b = new SolidBrush(color))
                    e.Graphics.FillRectangle(b, r1);
                e.Graphics.DrawRectangle(Pens.Black, r1);
                TextRenderer.DrawText(e.Graphics, txt, comboBox5.Font, r2,
                    comboBox5.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
