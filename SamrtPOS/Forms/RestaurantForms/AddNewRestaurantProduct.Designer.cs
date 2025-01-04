namespace SmartPOS.Forms.RestaurantForms
{
    partial class AddNewRestaurantProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSupplier = new System.Windows.Forms.ComboBox();
            this.btnAddNewCategory = new System.Windows.Forms.Button();
            this.chkBoxKOT = new System.Windows.Forms.CheckBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combCategory = new System.Windows.Forms.ComboBox();
            this.txtBuyingCost = new System.Windows.Forms.TextBox();
            this.txtLabledPrice = new System.Windows.Forms.TextBox();
            this.combUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.lblHeadText = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.tableLayoutPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1484, 807);
            this.MainPanel.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeaderPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FooterPanel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1476, 804);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtSupplier);
            this.panel2.Controls.Add(this.btnAddNewCategory);
            this.panel2.Controls.Add(this.chkBoxKOT);
            this.panel2.Controls.Add(this.txtBarCode);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtItemCode);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.combCategory);
            this.panel2.Controls.Add(this.txtBuyingCost);
            this.panel2.Controls.Add(this.txtLabledPrice);
            this.panel2.Controls.Add(this.combUnit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtItemName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1468, 635);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Image = global::SmartPOS.Properties.Resources.addicon;
            this.button1.Location = new System.Drawing.Point(635, 441);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 38);
            this.button1.TabIndex = 59;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // txtSupplier
            // 
            this.txtSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSupplier.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtSupplier.FormattingEnabled = true;
            this.txtSupplier.Location = new System.Drawing.Point(204, 441);
            this.txtSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(421, 37);
            this.txtSupplier.TabIndex = 58;
            this.txtSupplier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSupplier_KeyDown_1);
            // 
            // btnAddNewCategory
            // 
            this.btnAddNewCategory.AutoSize = true;
            this.btnAddNewCategory.Image = global::SmartPOS.Properties.Resources.addicon;
            this.btnAddNewCategory.Location = new System.Drawing.Point(635, 383);
            this.btnAddNewCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddNewCategory.Name = "btnAddNewCategory";
            this.btnAddNewCategory.Size = new System.Drawing.Size(41, 38);
            this.btnAddNewCategory.TabIndex = 23;
            this.btnAddNewCategory.UseVisualStyleBackColor = true;
            this.btnAddNewCategory.Click += new System.EventHandler(this.btnAddNewCategory_Click);
            this.btnAddNewCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // chkBoxKOT
            // 
            this.chkBoxKOT.AutoSize = true;
            this.chkBoxKOT.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.chkBoxKOT.Location = new System.Drawing.Point(204, 507);
            this.chkBoxKOT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkBoxKOT.Name = "chkBoxKOT";
            this.chkBoxKOT.Size = new System.Drawing.Size(76, 33);
            this.chkBoxKOT.TabIndex = 22;
            this.chkBoxKOT.Text = "KOT";
            this.chkBoxKOT.UseVisualStyleBackColor = true;
            this.chkBoxKOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBoxKOT_KeyDown);
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.Location = new System.Drawing.Point(895, 149);
            this.txtBarCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(275, 35);
            this.txtBarCode.TabIndex = 20;
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(777, 150);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 29);
            this.label9.TabIndex = 19;
            this.label9.Text = "BarCode :";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(204, 78);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(175, 35);
            this.txtItemCode.TabIndex = 18;
            this.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(69, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 29);
            this.label8.TabIndex = 17;
            this.label8.Text = "Item Code :";
            // 
            // combCategory
            // 
            this.combCategory.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.combCategory.FormattingEnabled = true;
            this.combCategory.Location = new System.Drawing.Point(204, 383);
            this.combCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combCategory.Name = "combCategory";
            this.combCategory.Size = new System.Drawing.Size(421, 37);
            this.combCategory.TabIndex = 15;
            this.combCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combCategory_KeyDown);
            // 
            // txtBuyingCost
            // 
            this.txtBuyingCost.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyingCost.Location = new System.Drawing.Point(204, 325);
            this.txtBuyingCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuyingCost.Name = "txtBuyingCost";
            this.txtBuyingCost.Size = new System.Drawing.Size(267, 35);
            this.txtBuyingCost.TabIndex = 14;
            this.txtBuyingCost.TextChanged += new System.EventHandler(this.txtBuyingCost_TextChanged);
            this.txtBuyingCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuyingCost_KeyDown);
            // 
            // txtLabledPrice
            // 
            this.txtLabledPrice.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLabledPrice.Location = new System.Drawing.Point(204, 267);
            this.txtLabledPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLabledPrice.Name = "txtLabledPrice";
            this.txtLabledPrice.Size = new System.Drawing.Size(267, 35);
            this.txtLabledPrice.TabIndex = 13;
            this.txtLabledPrice.TextChanged += new System.EventHandler(this.txtLabledPrice_TextChanged);
            this.txtLabledPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLabledPrice_KeyDown);
            // 
            // combUnit
            // 
            this.combUnit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.combUnit.FormattingEnabled = true;
            this.combUnit.Location = new System.Drawing.Point(204, 207);
            this.combUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.combUnit.Name = "combUnit";
            this.combUnit.Size = new System.Drawing.Size(267, 37);
            this.combUnit.TabIndex = 11;
            this.combUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.combUnit_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(87, 444);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "Supplier :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(79, 386);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 29);
            this.label7.TabIndex = 8;
            this.label7.Text = "Category :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 329);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Buying Cost :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 271);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 29);
            this.label5.TabIndex = 4;
            this.label5.Text = "Labled Price :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unit :";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(204, 149);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(421, 35);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 155);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item Name :";
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.HeaderPanel.Controls.Add(this.lblHeadText);
            this.HeaderPanel.Controls.Add(this.BtnClose);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(4, 4);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1468, 72);
            this.HeaderPanel.TabIndex = 1;
            // 
            // lblHeadText
            // 
            this.lblHeadText.AutoSize = true;
            this.lblHeadText.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadText.Location = new System.Drawing.Point(4, 16);
            this.lblHeadText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeadText.Name = "lblHeadText";
            this.lblHeadText.Size = new System.Drawing.Size(445, 38);
            this.lblHeadText.TabIndex = 38;
            this.lblHeadText.Text = "Add New Restaurant Product";
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Image = global::SmartPOS.Properties.Resources.imgClose32;
            this.BtnClose.Location = new System.Drawing.Point(1409, 6);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(51, 47);
            this.BtnClose.TabIndex = 37;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.White;
            this.FooterPanel.Controls.Add(this.btnClear);
            this.FooterPanel.Controls.Add(this.btnSave);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FooterPanel.Location = new System.Drawing.Point(4, 727);
            this.FooterPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(1468, 73);
            this.FooterPanel.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 2;
            this.btnClear.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::SmartPOS.Properties.Resources.index;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(1313, 11);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(147, 52);
            this.btnClear.TabIndex = 43;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SmartPOS.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(1161, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 52);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // AddNewRestaurantProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 807);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AddNewRestaurantProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddNewProduct_Load);
            this.MainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label lblHeadText;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combCategory;
        private System.Windows.Forms.TextBox txtBuyingCost;
        private System.Windows.Forms.TextBox txtLabledPrice;
        private System.Windows.Forms.ComboBox combUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBoxKOT;
        private System.Windows.Forms.Button btnAddNewCategory;
        private System.Windows.Forms.ComboBox txtSupplier;
        private System.Windows.Forms.Button button1;
    }
}