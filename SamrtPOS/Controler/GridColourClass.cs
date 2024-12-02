using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPOS.Controler
{
    public class GridColourClass
    {
        public void setGridDetails(DataGridView grid)
        {
            grid.GridColor = System.Drawing.Color.DodgerBlue;

            DataGridViewCellStyle styleDefault = new DataGridViewCellStyle();
            styleDefault.BackColor = System.Drawing.SystemColors.Window;
            styleDefault.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleDefault.ForeColor = System.Drawing.Color.Black;
            styleDefault.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            styleDefault.SelectionForeColor = System.Drawing.Color.Red;
            styleDefault.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.DefaultCellStyle = styleDefault;

            DataGridViewCellStyle styleAlternative = new DataGridViewCellStyle();
            styleAlternative.BackColor = System.Drawing.SystemColors.MenuBar;
            styleAlternative.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleAlternative.ForeColor = System.Drawing.Color.Black;
            styleAlternative.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            styleAlternative.SelectionForeColor = System.Drawing.Color.Red;
            styleAlternative.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.AlternatingRowsDefaultCellStyle = styleAlternative;

            grid.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styleHeaders = new DataGridViewCellStyle();
            styleHeaders.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            styleHeaders.BackColor = System.Drawing.Color.NavajoWhite;
            styleHeaders.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleHeaders.ForeColor = System.Drawing.Color.Black;
            styleHeaders.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            styleHeaders.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            styleHeaders.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            grid.ColumnHeadersDefaultCellStyle = styleHeaders;


        }

        public void setGridRowMouseHoverEvent(DataGridViewRow row)
        {
            DataGridViewCellStyle styleDefault = new DataGridViewCellStyle();
            styleDefault.BackColor = System.Drawing.Color.Lavender;
            styleDefault.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleDefault.ForeColor = System.Drawing.Color.Blue;
            styleDefault.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            styleDefault.SelectionForeColor = System.Drawing.Color.Red;
            styleDefault.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            row.DefaultCellStyle = styleDefault;
        }


        public void setGridRowMouseLeaveEvent(DataGridViewRow row, int rowId)
        {
            DataGridViewCellStyle styleDefault = new DataGridViewCellStyle();
            if (rowId % 2 == 0)
                styleDefault.BackColor = System.Drawing.SystemColors.Window;
            else
                styleDefault.BackColor = System.Drawing.SystemColors.MenuBar;
            styleDefault.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleDefault.ForeColor = System.Drawing.Color.Black;
            styleDefault.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            styleDefault.SelectionForeColor = System.Drawing.Color.Red;
            styleDefault.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            row.DefaultCellStyle = styleDefault;
        }

        public void formNormalButton(Button btn)
        {
            btn.ForeColor = System.Drawing.Color.Navy;
            btn.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.BackColor = System.Drawing.SystemColors.Control;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        public void FormNormalButtonOrange(Button btn)
        {
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.BackColor = System.Drawing.Color.Orange;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkOrange;
        }

        public void FormNormalButtonRed(Button btn)
        {
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.BackColor = System.Drawing.Color.Red;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkRed;
        }

        public void FormNormalButtonGreen(Button btn)
        {
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.BackColor = System.Drawing.Color.Green;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
        }

        public void FormNormalButtonMain(Button btn)
        {
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn.BackColor = Color.FromName(Program.col2);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 4;
            btn.FlatAppearance.BorderColor = Color.FromName(Program.col);
        }
    }
}
