using MySql.Data.MySqlClient;
using SmartPOS.Controler;
using SmartPOS.Forms.BarCodeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Forms.AccountForms
{
    public partial class CashInOut : Form
    {
        private static CommonFuntion cmnFuntion;
        private static CashBookControler cashBookCont;

        public CashInOut()
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
            styl.FormNormalButtonMain(btnClearAll);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CashInOut_Load(object sender, EventArgs e)
        {
            txtPayAmt.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCashBook();
        }

        private void SaveCashBook()
        {
            cashBookCont = new CashBookControler();

            if (string.IsNullOrEmpty(txtPayAmt.Text) == false || string.IsNullOrWhiteSpace(txtPayAmt.Text) == false)
            {
                if (decimal.Parse(txtPayAmt.Text.ToString()) > 0)
                {

                    if (string.IsNullOrEmpty(txtDescri.Text) == false || string.IsNullOrWhiteSpace(txtDescri.Text) == false)
                    {
                        if (cmbInOut.SelectedIndex == 0)
                        {
                            if (cashBookCont.SaveCashbook("CashIN", decimal.Parse(txtPayAmt.Text.ToString()), txtDescri.Text.Trim().ToString()))
                            {
                                MessageBox.Show("Successfull Cash In");
                                this.Close();
                            }
                        }
                        else if (cmbInOut.SelectedIndex == 1)
                        {
                            if (cashBookCont.SaveCashbook("CashOUT", decimal.Parse(txtPayAmt.Text.ToString()), txtDescri.Text.Trim().ToString()))
                            {
                                MessageBox.Show("Successfull Cash Out");
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Select Cash IN or OUT");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Required Description");
                    }


                }
                else
                {
                    MessageBox.Show("Required Amount");
                }
            }
            else
            {
                MessageBox.Show("Required Amount");
            }
        }

        private void txtPayAmt_TextChanged(object sender, EventArgs e)
        {
            cmnFuntion = new CommonFuntion();

            if (cmnFuntion.IsValidDecimalNo(txtPayAmt.Text.ToString()) == false)
            {
                MessageBox.Show("Invalid Amount");
                txtPayAmt.Text = "";
            }
        }

        private void txtPayAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbInOut.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmbInOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescri.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtDescri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveCashBook();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnSave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClearAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
