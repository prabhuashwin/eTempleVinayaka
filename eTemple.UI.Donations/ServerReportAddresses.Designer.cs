namespace eTemple.UI.Donations
{
    partial class ServerReportAddresses
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvServiceReport = new System.Windows.Forms.DataGridView();
            this.DailyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gothram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevoteeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistrictName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OtherDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.dtValue = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceReport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvServiceReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1205, 455);
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
            this.DailyNumber,
            this.ServiceID,
            this.Gothram,
            this.DevoteeName,
            this.TotalCost,
            this.DoorNumber,
            this.DistrictName,
            this.StateName,
            this.OtherDetails,
            this.PhoneNumber});
            this.dgvServiceReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServiceReport.Location = new System.Drawing.Point(0, 0);
            this.dgvServiceReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvServiceReport.Name = "dgvServiceReport";
            this.dgvServiceReport.ReadOnly = true;
            this.dgvServiceReport.RowHeadersVisible = false;
            this.dgvServiceReport.Size = new System.Drawing.Size(1205, 455);
            this.dgvServiceReport.TabIndex = 0;
            // 
            // DailyNumber
            // 
            this.DailyNumber.DataPropertyName = "TicketID";
            this.DailyNumber.HeaderText = "TicketID";
            this.DailyNumber.Name = "DailyNumber";
            this.DailyNumber.ReadOnly = true;
            // 
            // ServiceID
            // 
            this.ServiceID.DataPropertyName = "ServiceID";
            this.ServiceID.HeaderText = "ServiceID";
            this.ServiceID.Name = "ServiceID";
            this.ServiceID.ReadOnly = true;
            // 
            // Gothram
            // 
            this.Gothram.DataPropertyName = "Gothram";
            this.Gothram.HeaderText = "Gothram";
            this.Gothram.Name = "Gothram";
            this.Gothram.ReadOnly = true;
            // 
            // DevoteeName
            // 
            this.DevoteeName.DataPropertyName = "DevoteeName";
            this.DevoteeName.HeaderText = "DevoteeName";
            this.DevoteeName.Name = "DevoteeName";
            this.DevoteeName.ReadOnly = true;
            // 
            // TotalCost
            // 
            this.TotalCost.DataPropertyName = "Amount";
            this.TotalCost.HeaderText = "Amount";
            this.TotalCost.Name = "TotalCost";
            this.TotalCost.ReadOnly = true;
            // 
            // DoorNumber
            // 
            this.DoorNumber.DataPropertyName = "address";
            this.DoorNumber.HeaderText = "Address";
            this.DoorNumber.Name = "DoorNumber";
            this.DoorNumber.ReadOnly = true;
            // 
            // DistrictName
            // 
            this.DistrictName.DataPropertyName = "DistrictName";
            this.DistrictName.HeaderText = "DistrictName";
            this.DistrictName.Name = "DistrictName";
            this.DistrictName.ReadOnly = true;
            // 
            // StateName
            // 
            this.StateName.DataPropertyName = "statename";
            this.StateName.HeaderText = "StateName";
            this.StateName.Name = "StateName";
            this.StateName.ReadOnly = true;
            // 
            // OtherDetails
            // 
            this.OtherDetails.DataPropertyName = "OtherDetails";
            this.OtherDetails.HeaderText = "OtherDetails";
            this.OtherDetails.Name = "OtherDetails";
            this.OtherDetails.ReadOnly = true;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.DataPropertyName = "PhoneNumber";
            this.PhoneNumber.HeaderText = "PhoneNumber";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.dtValue);
            this.panel1.Controls.Add(this.cmbServiceType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 123);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(81, 44);
            this.cmbServiceType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(299, 25);
            this.cmbServiceType.TabIndex = 1;
            this.cmbServiceType.ValueMember = "Id";
            // 
            // dtValue
            // 
            this.dtValue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtValue.Location = new System.Drawing.Point(401, 44);
            this.dtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtValue.Name = "dtValue";
            this.dtValue.Size = new System.Drawing.Size(196, 25);
            this.dtValue.TabIndex = 3;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(607, 35);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(115, 44);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Show Report";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(749, 35);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 44);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(892, 35);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(115, 44);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ServerReportAddresses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 578);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ServerReportAddresses";
            this.Text = "ServerReportAddresses";
            this.Load += new System.EventHandler(this.ServerReportAddresses_Load);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.DateTimePicker dtValue;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn DailyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gothram;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevoteeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoorNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistrictName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OtherDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
    }
}