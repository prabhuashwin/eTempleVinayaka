﻿namespace eTemple.UI.Donations
{
    partial class ServiceReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvServiceReport = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dtValue = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gothram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevoteeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransactionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePErformDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvServiceReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 87);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 295);
            this.panel2.TabIndex = 3;
            // 
            // dgvServiceReport
            // 
            this.dgvServiceReport.AllowUserToAddRows = false;
            this.dgvServiceReport.AllowUserToDeleteRows = false;
            this.dgvServiceReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServiceReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvServiceReport.ColumnHeadersHeight = 35;
            this.dgvServiceReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketID,
            this.ReceiptID,
            this.Gothram,
            this.DevoteeName,
            this.TotalCost,
            this.TransactionType,
            this.ServicePErformDate,
            this.CreatedOn});
            this.dgvServiceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiceReport.Location = new System.Drawing.Point(0, 0);
            this.dgvServiceReport.Name = "dgvServiceReport";
            this.dgvServiceReport.ReadOnly = true;
            this.dgvServiceReport.RowHeadersVisible = false;
            this.dgvServiceReport.Size = new System.Drawing.Size(904, 295);
            this.dgvServiceReport.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.dtValue);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbServiceType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 87);
            this.panel1.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(702, 32);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 26);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(633, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.Location = new System.Drawing.Point(561, 32);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(65, 26);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Show";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dtValue
            // 
            this.dtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValue.Location = new System.Drawing.Point(366, 31);
            this.dtValue.Name = "dtValue";
            this.dtValue.Size = new System.Drawing.Size(162, 25);
            this.dtValue.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbServiceType.DisplayMember = "Name";
            this.cmbServiceType.DropDownHeight = 200;
            this.cmbServiceType.DropDownWidth = 300;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.IntegralHeight = false;
            this.cmbServiceType.ItemHeight = 17;
            this.cmbServiceType.Location = new System.Drawing.Point(159, 31);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(177, 25);
            this.cmbServiceType.TabIndex = 1;
            this.cmbServiceType.ValueMember = "Id";
            // 
            // TicketID
            // 
            this.TicketID.DataPropertyName = "TicketID";
            this.TicketID.FillWeight = 17.22052F;
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            this.TicketID.ReadOnly = true;
            // 
            // ReceiptID
            // 
            this.ReceiptID.DataPropertyName = "ReceiptID";
            this.ReceiptID.FillWeight = 25.8308F;
            this.ReceiptID.HeaderText = "ReceiptID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.ReadOnly = true;
            this.ReceiptID.ToolTipText = "ReceiptID";
            // 
            // Gothram
            // 
            this.Gothram.DataPropertyName = "Gothram";
            this.Gothram.FillWeight = 34.44106F;
            this.Gothram.HeaderText = "Gothram";
            this.Gothram.Name = "Gothram";
            this.Gothram.ReadOnly = true;
            // 
            // DevoteeName
            // 
            this.DevoteeName.DataPropertyName = "DevoteeName";
            this.DevoteeName.FillWeight = 51.66159F;
            this.DevoteeName.HeaderText = "DevoteeName";
            this.DevoteeName.Name = "DevoteeName";
            this.DevoteeName.ReadOnly = true;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "Amount";
            this.TotalCost.FillWeight = 22.38669F;
            this.TotalCost.HeaderText = "Amount";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // TransactionType
            // 
            this.TransactionType.DataPropertyName = "TransactionType";
            this.TransactionType.FillWeight = 38F;
            this.TransactionType.HeaderText = "Transaction Type";
            this.TransactionType.Name = "TransactionType";
            this.TransactionType.ReadOnly = true;
            // 
            // ServicePErformDate
            // 
            this.ServicePErformDate.DataPropertyName = "performDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.ServicePErformDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ServicePErformDate.FillWeight = 37.88517F;
            this.ServicePErformDate.HeaderText = "Perform Date";
            this.ServicePErformDate.Name = "ServicePErformDate";
            this.ServicePErformDate.ReadOnly = true;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.CreatedOn.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreatedOn.FillWeight = 34.44106F;
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            this.CreatedOn.ToolTipText = "CreatedOn";
            // 
            // ServiceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 382);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServiceReportForm";
            this.Text = "ServiceReportForm";
            this.Load += new System.EventHandler(this.ServiceReportForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvServiceReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DateTimePicker dtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gothram;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevoteeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransactionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePErformDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
    }
}