namespace eTemple.UI.Donations
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvServiceReport = new System.Windows.Forms.DataGridView();
            this.TicketID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gothram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevoteeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicePErformDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedOn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtValue = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvServiceReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 365);
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
            this.ServicePErformDate,
            this.CreatedOn});
            this.dgvServiceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiceReport.Location = new System.Drawing.Point(0, 0);
            this.dgvServiceReport.Name = "dgvServiceReport";
            this.dgvServiceReport.ReadOnly = true;
            this.dgvServiceReport.RowHeadersVisible = false;
            this.dgvServiceReport.Size = new System.Drawing.Size(904, 365);
            this.dgvServiceReport.TabIndex = 0;
            // 
            // TicketID
            // 
            this.TicketID.DataPropertyName = "TicketID";
            this.TicketID.FillWeight = 15.38554F;
            this.TicketID.HeaderText = "TicketID";
            this.TicketID.Name = "TicketID";
            this.TicketID.ReadOnly = true;
            // 
            // ReceiptID
            // 
            this.ReceiptID.DataPropertyName = "ReceiptID";
            this.ReceiptID.FillWeight = 23.07832F;
            this.ReceiptID.HeaderText = "ReceiptID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.ReadOnly = true;
            this.ReceiptID.ToolTipText = "ReceiptID";
            // 
            // Gothram
            // 
            this.Gothram.DataPropertyName = "Gothram";
            this.Gothram.FillWeight = 30.77109F;
            this.Gothram.HeaderText = "Gothram";
            this.Gothram.Name = "Gothram";
            this.Gothram.ReadOnly = true;
            // 
            // DevoteeName
            // 
            this.DevoteeName.DataPropertyName = "DevoteeName";
            this.DevoteeName.FillWeight = 46.15664F;
            this.DevoteeName.HeaderText = "DevoteeName";
            this.DevoteeName.Name = "DevoteeName";
            this.DevoteeName.ReadOnly = true;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "Amount";
            this.TotalCost.FillWeight = 20.00121F;
            this.TotalCost.HeaderText = "Amount";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // ServicePErformDate
            // 
            this.ServicePErformDate.DataPropertyName = "performDate";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.ServicePErformDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.ServicePErformDate.FillWeight = 33.8482F;
            this.ServicePErformDate.HeaderText = "Perform Date";
            this.ServicePErformDate.Name = "ServicePErformDate";
            this.ServicePErformDate.ReadOnly = true;
            // 
            // CreatedOn
            // 
            this.CreatedOn.DataPropertyName = "CreatedOn";
            dataGridViewCellStyle8.Format = "G";
            dataGridViewCellStyle8.NullValue = null;
            this.CreatedOn.DefaultCellStyle = dataGridViewCellStyle8;
            this.CreatedOn.FillWeight = 30.77109F;
            this.CreatedOn.HeaderText = "CreatedOn";
            this.CreatedOn.Name = "CreatedOn";
            this.CreatedOn.ReadOnly = true;
            this.CreatedOn.ToolTipText = "CreatedOn";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 77);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.21352F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.7573F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.07692F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtValue, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSubmit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrint, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbServiceType, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(778, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Service";
            // 
            // dtValue
            // 
            this.dtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValue.Location = new System.Drawing.Point(353, 3);
            this.dtValue.Name = "dtValue";
            this.dtValue.Size = new System.Drawing.Size(152, 21);
            this.dtValue.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSubmit.Location = new System.Drawing.Point(511, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(71, 32);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Show";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(588, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 33);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(681, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 32);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbServiceType.DisplayMember = "Name";
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.ItemHeight = 15;
            this.cmbServiceType.Location = new System.Drawing.Point(60, 3);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(287, 23);
            this.cmbServiceType.TabIndex = 1;
            this.cmbServiceType.ValueMember = "Id";
            // 
            // ServiceReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 442);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServiceReportForm";
            this.Text = "ServiceReportForm";
            this.Load += new System.EventHandler(this.ServiceReportForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceReport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvServiceReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.DateTimePicker dtValue;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gothram;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevoteeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicePErformDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedOn;
    }
}