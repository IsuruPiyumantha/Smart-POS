namespace SmartPOS.Forms
{
    partial class ProductDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.AddNew = new System.Windows.Forms.Button();
            this.lblHeadText = new System.Windows.Forms.Label();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.BtnClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDataDetails = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name_sinhala = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labled_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.special_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wholesale_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppliersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.HeaderPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataDetails)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.White;
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FooterPanel.Location = new System.Drawing.Point(3, 645);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(1367, 66);
            this.FooterPanel.TabIndex = 2;
            // 
            // AddNew
            // 
            this.AddNew.FlatAppearance.BorderSize = 2;
            this.AddNew.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNew.Image = global::SmartPOS.Properties.Resources.addicon;
            this.AddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddNew.Location = new System.Drawing.Point(1138, 54);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(220, 42);
            this.AddNew.TabIndex = 39;
            this.AddNew.Text = "Add New Product";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            this.AddNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // lblHeadText
            // 
            this.lblHeadText.AutoSize = true;
            this.lblHeadText.Font = new System.Drawing.Font("Arial Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadText.Location = new System.Drawing.Point(3, 6);
            this.lblHeadText.Name = "lblHeadText";
            this.lblHeadText.Size = new System.Drawing.Size(189, 30);
            this.lblHeadText.TabIndex = 38;
            this.lblHeadText.Text = "Product Details";
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.HeaderPanel.Controls.Add(this.txtBarCode);
            this.HeaderPanel.Controls.Add(this.radioButton3);
            this.HeaderPanel.Controls.Add(this.txtItemName);
            this.HeaderPanel.Controls.Add(this.radioButton2);
            this.HeaderPanel.Controls.Add(this.txtItemCode);
            this.HeaderPanel.Controls.Add(this.radioButton1);
            this.HeaderPanel.Controls.Add(this.AddNew);
            this.HeaderPanel.Controls.Add(this.lblHeadText);
            this.HeaderPanel.Controls.Add(this.BtnClose);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderPanel.Location = new System.Drawing.Point(3, 3);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1367, 101);
            this.HeaderPanel.TabIndex = 1;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Enabled = false;
            this.txtBarCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.Location = new System.Drawing.Point(661, 65);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(194, 22);
            this.txtBarCode.TabIndex = 48;
            this.txtBarCode.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(661, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(128, 20);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Search Barcode";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.radioButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // txtItemName
            // 
            this.txtItemName.Enabled = false;
            this.txtItemName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(250, 65);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(350, 22);
            this.txtItemName.TabIndex = 45;
            this.txtItemName.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtItemName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(250, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(144, 20);
            this.radioButton2.TabIndex = 44;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Search Item Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Enabled = false;
            this.txtItemCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(8, 65);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(184, 22);
            this.txtItemCode.TabIndex = 43;
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtItemCode_TextChanged);
            this.txtItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(8, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(140, 20);
            this.radioButton1.TabIndex = 42;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Search Item Code";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // BtnClose
            // 
            this.BtnClose.AutoSize = true;
            this.BtnClose.Image = global::SmartPOS.Properties.Resources.imgClose32;
            this.BtnClose.Location = new System.Drawing.Point(1319, 8);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(38, 38);
            this.BtnClose.TabIndex = 37;
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.BtnClose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDataDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1367, 529);
            this.panel2.TabIndex = 0;
            // 
            // gridDataDetails
            // 
            this.gridDataDetails.AllowUserToAddRows = false;
            this.gridDataDetails.AllowUserToDeleteRows = false;
            this.gridDataDetails.AllowUserToResizeColumns = false;
            this.gridDataDetails.AllowUserToResizeRows = false;
            this.gridDataDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.gridDataDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridDataDetails.BackgroundColor = System.Drawing.Color.White;
            this.gridDataDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDataDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.count,
            this.ID,
            this.item_name,
            this.item_name_sinhala,
            this.barcode,
            this.barcode2,
            this.barcode3,
            this.labled_price,
            this.special_price,
            this.wholesale_price,
            this.UnitName,
            this.InStock,
            this.SuppliersName,
            this.Edit,
            this.Delete});
            this.gridDataDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDataDetails.GridColor = System.Drawing.Color.White;
            this.gridDataDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDataDetails.Name = "gridDataDetails";
            this.gridDataDetails.ReadOnly = true;
            this.gridDataDetails.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDataDetails.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDataDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDataDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDataDetails.Size = new System.Drawing.Size(1367, 529);
            this.gridDataDetails.TabIndex = 2;
            this.gridDataDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDataDetails_CellContentClick);
            this.gridDataDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.HeaderPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.FooterPanel, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1373, 714);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.tableLayoutPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1376, 715);
            this.MainPanel.TabIndex = 1;
            // 
            // count
            // 
            this.count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.count.DataPropertyName = "count";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.count.DefaultCellStyle = dataGridViewCellStyle1;
            this.count.HeaderText = "#";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 50;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "Item Code";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // item_name
            // 
            this.item_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_name.DataPropertyName = "item_name";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.item_name.HeaderText = "Item Name";
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            this.item_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // item_name_sinhala
            // 
            this.item_name_sinhala.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.item_name_sinhala.DataPropertyName = "item_name_sinhala";
            this.item_name_sinhala.HeaderText = "Item Name Sinhala";
            this.item_name_sinhala.Name = "item_name_sinhala";
            this.item_name_sinhala.ReadOnly = true;
            // 
            // barcode
            // 
            this.barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Width = 150;
            // 
            // barcode2
            // 
            this.barcode2.DataPropertyName = "barcode2";
            this.barcode2.HeaderText = "barcode2";
            this.barcode2.Name = "barcode2";
            this.barcode2.ReadOnly = true;
            this.barcode2.Visible = false;
            this.barcode2.Width = 77;
            // 
            // barcode3
            // 
            this.barcode3.DataPropertyName = "barcode3";
            this.barcode3.HeaderText = "barcode3";
            this.barcode3.Name = "barcode3";
            this.barcode3.ReadOnly = true;
            this.barcode3.Visible = false;
            this.barcode3.Width = 77;
            // 
            // labled_price
            // 
            this.labled_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.labled_price.DataPropertyName = "labled_price";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labled_price.DefaultCellStyle = dataGridViewCellStyle4;
            this.labled_price.HeaderText = "Labled Price";
            this.labled_price.Name = "labled_price";
            this.labled_price.ReadOnly = true;
            this.labled_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // special_price
            // 
            this.special_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.special_price.DataPropertyName = "special_price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.special_price.DefaultCellStyle = dataGridViewCellStyle5;
            this.special_price.HeaderText = "Special Price";
            this.special_price.Name = "special_price";
            this.special_price.ReadOnly = true;
            this.special_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // wholesale_price
            // 
            this.wholesale_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.wholesale_price.DataPropertyName = "wholesale_price";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wholesale_price.DefaultCellStyle = dataGridViewCellStyle6;
            this.wholesale_price.HeaderText = "WholesalePrice";
            this.wholesale_price.Name = "wholesale_price";
            this.wholesale_price.ReadOnly = true;
            this.wholesale_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // UnitName
            // 
            this.UnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UnitName.DataPropertyName = "UnitName";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.UnitName.DefaultCellStyle = dataGridViewCellStyle7;
            this.UnitName.HeaderText = "Unit";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.UnitName.Width = 60;
            // 
            // InStock
            // 
            this.InStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InStock.DataPropertyName = "InStock";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.InStock.DefaultCellStyle = dataGridViewCellStyle8;
            this.InStock.HeaderText = "InStock";
            this.InStock.Name = "InStock";
            this.InStock.ReadOnly = true;
            this.InStock.Visible = false;
            // 
            // SuppliersName
            // 
            this.SuppliersName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SuppliersName.DataPropertyName = "SuppliersName";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersName.DefaultCellStyle = dataGridViewCellStyle9;
            this.SuppliersName.HeaderText = "Supplier";
            this.SuppliersName.Name = "SuppliersName";
            this.SuppliersName.ReadOnly = true;
            this.SuppliersName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SuppliersName.Width = 150;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.HeaderText = "";
            this.Edit.Image = global::SmartPOS.Properties.Resources.edit;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 30;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.HeaderText = "";
            this.Delete.Image = global::SmartPOS.Properties.Resources.collapse;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 30;
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 715);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ProductDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDataDetails)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Label lblHeadText;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridDataDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name_sinhala;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode2;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode3;
        private System.Windows.Forms.DataGridViewTextBoxColumn labled_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn special_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn wholesale_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppliersName;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}