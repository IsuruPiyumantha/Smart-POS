using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.SettingsForms
{
    public partial class Chages : Form
    {
        private static MySqlConnection con;
        private static string conString = string.Empty;
        decimal ServiceCharge = 0;
        decimal CardFee = 0;
        decimal TAX = 0;

        public Chages()
        {
            InitializeComponent();
            AllItemsDT();
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

            DataTable dt1 = new DataTable();

            try
            {
                if (con.State.ToString() != "Open")
                {
                    con.Open();

                    if (con != null)
                    {
                        string sqlUser = "";
                        sqlUser = "SELECT * FROM tbl_pos_system_setting tpss;";
                        MySqlDataAdapter da = new MySqlDataAdapter(sqlUser, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "userDT");
                        dt1 = ds.Tables["userDT"];
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow r in dt1.Rows)
                            {
                                string ObjName = r["ObjName"].ToString();

                                if (ObjName == "Service Charge")
                                {
                                    txtServiceChg.Text = r["ObjValue"].ToString();
                                }
                                if (ObjName == "Card Payment Fee")
                                {
                                    txtCardFee.Text = r["ObjValue"].ToString();
                                }
                                if (ObjName == "TAX")
                                {
                                    txttax.Text = r["ObjValue"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        private void UpdateFee()
        {
            if (string.IsNullOrEmpty(txtServiceChg.Text) == true || string.IsNullOrWhiteSpace(txtServiceChg.Text) == true)
            {
                MessageBox.Show("Req Service Charge.");
            }
            if (string.IsNullOrEmpty(txtCardFee.Text) == true || string.IsNullOrWhiteSpace(txtCardFee.Text) == true)
            {
                MessageBox.Show("Req Card Payment Fee.");
            }
            if (string.IsNullOrEmpty(txttax.Text) == true || string.IsNullOrWhiteSpace(txttax.Text) == true)
            {
                MessageBox.Show("Req TAX.");
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
                            string sql = "UPDATE tbl_pos_system_setting tpss SET tpss.ObjValue = @srevicechg WHERE tpss.ObjName = 'Service Charge'; UPDATE tbl_pos_system_setting tpss SET tpss.ObjValue = @cardFee WHERE tpss.ObjName = 'Card Payment Fee'; UPDATE tbl_pos_system_setting tpss SET tpss.ObjValue = @tax WHERE tpss.ObjName = 'TAX';";
                            MySqlCommand cmd = new MySqlCommand(sql, con);
                            cmd.Parameters.Add("@srevicechg", txtServiceChg.Text);
                            cmd.Parameters.Add("@cardFee", txtCardFee.Text);
                            cmd.Parameters.Add("@tax", txttax.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                        this.Close();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateFee();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void Clear()
        {
            txttax.Text = "0";
            txtServiceChg.Text = "0";
            txtCardFee.Text = "0";

        }

        private void BtnClose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtServiceChg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCardFee.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txtCardFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txttax.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            BtnClose_KeyDown(sender, e);
        }

        private void txttax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateFee();
            }
            BtnClose_KeyDown(sender, e);
        }
    }
}
