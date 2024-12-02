﻿namespace SmartPOS.Forms
{
    partial class SupplierDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDataDetails = new System.Windows.Forms.DataGridView();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppliersName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppliersMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppliersEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewImageColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.txtSupMobile = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.txtSupCode = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.AddNew = new System.Windows.Forms.Button();
            this.lblHeadText = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataDetails)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.tableLayoutPanel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1375, 716);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1373, 714);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.SuppliersName,
            this.SuppliersMobileNo,
            this.SuppliersEmail,
            this.BalanceAmount,
            this.Info,
            this.Edit,
            this.Delete});
            this.gridDataDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDataDetails.GridColor = System.Drawing.Color.White;
            this.gridDataDetails.Location = new System.Drawing.Point(0, 0);
            this.gridDataDetails.Name = "gridDataDetails";
            this.gridDataDetails.ReadOnly = true;
            this.gridDataDetails.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDataDetails.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridDataDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDataDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDataDetails.Size = new System.Drawing.Size(1367, 529);
            this.gridDataDetails.TabIndex = 2;
            this.gridDataDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDataDetails_CellContentClick);
            this.gridDataDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // count
            // 
            this.count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "#";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            this.count.Width = 50;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "Supplier Code";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SuppliersName
            // 
            this.SuppliersName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SuppliersName.DataPropertyName = "SuppliersName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersName.DefaultCellStyle = dataGridViewCellStyle2;
            this.SuppliersName.HeaderText = "Supplier Name";
            this.SuppliersName.Name = "SuppliersName";
            this.SuppliersName.ReadOnly = true;
            this.SuppliersName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SuppliersMobileNo
            // 
            this.SuppliersMobileNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SuppliersMobileNo.DataPropertyName = "SuppliersMobileNo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SuppliersMobileNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.SuppliersMobileNo.HeaderText = "Supplier Mobile No";
            this.SuppliersMobileNo.Name = "SuppliersMobileNo";
            this.SuppliersMobileNo.ReadOnly = true;
            this.SuppliersMobileNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SuppliersMobileNo.Width = 150;
            // 
            // SuppliersEmail
            // 
            this.SuppliersEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SuppliersEmail.DataPropertyName = "SuppliersEmail";
            this.SuppliersEmail.HeaderText = "Supplier Email";
            this.SuppliersEmail.Name = "SuppliersEmail";
            this.SuppliersEmail.ReadOnly = true;
            this.SuppliersEmail.Width = 170;
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BalanceAmount.DataPropertyName = "BalanceAmount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BalanceAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.BalanceAmount.HeaderText = "Balance Amount";
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.ReadOnly = true;
            this.BalanceAmount.Width = 120;
            // 
            // Info
            // 
            this.Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Info.DataPropertyName = "Info";
            this.Info.HeaderText = "";
            this.Info.Image = global::SmartPOS.Properties.Resources.binary;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Width = 30;
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
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.White;
            this.HeaderPanel.Controls.Add(this.txtSupMobile);
            this.HeaderPanel.Controls.Add(this.radioButton3);
            this.HeaderPanel.Controls.Add(this.txtSupName);
            this.HeaderPanel.Controls.Add(this.radioButton2);
            this.HeaderPanel.Controls.Add(this.txtSupCode);
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
            // txtSupMobile
            // 
            this.txtSupMobile.Enabled = false;
            this.txtSupMobile.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupMobile.Location = new System.Drawing.Point(661, 65);
            this.txtSupMobile.Name = "txtSupMobile";
            this.txtSupMobile.Size = new System.Drawing.Size(194, 22);
            this.txtSupMobile.TabIndex = 48;
            this.txtSupMobile.TextChanged += new System.EventHandler(this.txtSupMobile_TextChanged);
            this.txtSupMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton3.Location = new System.Drawing.Point(661, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(176, 20);
            this.radioButton3.TabIndex = 47;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Search Supplier Mobile";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            this.radioButton3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // txtSupName
            // 
            this.txtSupName.Enabled = false;
            this.txtSupName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupName.Location = new System.Drawing.Point(250, 65);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(350, 22);
            this.txtSupName.TabIndex = 45;
            this.txtSupName.TextChanged += new System.EventHandler(this.txtSupName_TextChanged);
            this.txtSupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(250, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(170, 20);
            this.radioButton2.TabIndex = 44;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Search Supplier Name";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.radioButton2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // txtSupCode
            // 
            this.txtSupCode.Enabled = false;
            this.txtSupCode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupCode.Location = new System.Drawing.Point(8, 65);
            this.txtSupCode.Name = "txtSupCode";
            this.txtSupCode.Size = new System.Drawing.Size(184, 22);
            this.txtSupCode.TabIndex = 43;
            this.txtSupCode.TextChanged += new System.EventHandler(this.txtSupCode_TextChanged);
            this.txtSupCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(8, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(166, 20);
            this.radioButton1.TabIndex = 42;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Search Supplier Code";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.radioButton1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnClose_KeyDown);
            // 
            // AddNew
            // 
            this.AddNew.FlatAppearance.BorderSize = 2;
            this.AddNew.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNew.Image = global::SmartPOS.Properties.Resources.addicon;
            this.AddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddNew.Location = new System.Drawing.Point(1138, 53);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(219, 42);
            this.AddNew.TabIndex = 39;
            this.AddNew.Text = "Add New Supplier";
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
            this.lblHeadText.Size = new System.Drawing.Size(194, 30);
            this.lblHeadText.TabIndex = 38;
            this.lblHeadText.Text = "Supplier Details";
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
            // FooterPanel
            // 
            this.FooterPanel.BackColor = System.Drawing.Color.White;
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FooterPanel.Location = new System.Drawing.Point(3, 645);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(1367, 66);
            this.FooterPanel.TabIndex = 2;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::SmartPOS.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::SmartPOS.Properties.Resources.collapse;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // SupplierDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1375, 716);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SupplierDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDataDetails)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gridDataDetails;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.TextBox txtSupMobile;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox txtSupName;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtSupCode;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Label lblHeadText;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppliersName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppliersMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppliersEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceAmount;
        private System.Windows.Forms.DataGridViewImageColumn Info;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}