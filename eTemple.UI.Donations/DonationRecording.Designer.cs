﻿namespace eTemple.UI.Donations
{
    partial class DonationRecording
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enquiryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportWithAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportWithAddressesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.operatorWiseReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.lblPrinter = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.enquiryToolStripMenuItem,
            this.eitToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.sessionToolStripMenuItem.Text = "Donation Entry";
            this.sessionToolStripMenuItem.Click += new System.EventHandler(this.sessionToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.masterToolStripMenuItem.Text = "Donation Reporting";
            this.masterToolStripMenuItem.Click += new System.EventHandler(this.masterToolStripMenuItem_Click);
            // 
            // enquiryToolStripMenuItem
            // 
            this.enquiryToolStripMenuItem.Name = "enquiryToolStripMenuItem";
            this.enquiryToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.enquiryToolStripMenuItem.Text = "Search";
            this.enquiryToolStripMenuItem.Click += new System.EventHandler(this.enquiryToolStripMenuItem_Click);
            // 
            // eitToolStripMenuItem
            // 
            this.eitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceReportToolStripMenuItem,
            this.serviceReportWithAddressesToolStripMenuItem,
            this.serviceReportWithAddressesToolStripMenuItem1,
            this.operatorWiseReportToolStripMenuItem});
            this.eitToolStripMenuItem.Name = "eitToolStripMenuItem";
            this.eitToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.eitToolStripMenuItem.Text = "Reports";
            this.eitToolStripMenuItem.Click += new System.EventHandler(this.eitToolStripMenuItem_Click);
            // 
            // serviceReportToolStripMenuItem
            // 
            this.serviceReportToolStripMenuItem.Name = "serviceReportToolStripMenuItem";
            this.serviceReportToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.serviceReportToolStripMenuItem.Text = "DCR";
            this.serviceReportToolStripMenuItem.Click += new System.EventHandler(this.serviceReportToolStripMenuItem_Click);
            // 
            // serviceReportWithAddressesToolStripMenuItem
            // 
            this.serviceReportWithAddressesToolStripMenuItem.Name = "serviceReportWithAddressesToolStripMenuItem";
            this.serviceReportWithAddressesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.serviceReportWithAddressesToolStripMenuItem.Text = "Service Report";
            this.serviceReportWithAddressesToolStripMenuItem.Click += new System.EventHandler(this.serviceReportWithAddressesToolStripMenuItem_Click);
            // 
            // serviceReportWithAddressesToolStripMenuItem1
            // 
            this.serviceReportWithAddressesToolStripMenuItem1.Name = "serviceReportWithAddressesToolStripMenuItem1";
            this.serviceReportWithAddressesToolStripMenuItem1.Size = new System.Drawing.Size(231, 22);
            this.serviceReportWithAddressesToolStripMenuItem1.Text = "Service Report with Addresses";
            this.serviceReportWithAddressesToolStripMenuItem1.Click += new System.EventHandler(this.serviceReportWithAddressesToolStripMenuItem1_Click);
            // 
            // operatorWiseReportToolStripMenuItem
            // 
            this.operatorWiseReportToolStripMenuItem.Name = "operatorWiseReportToolStripMenuItem";
            this.operatorWiseReportToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.operatorWiseReportToolStripMenuItem.Text = "OperatorWise Report";
            this.operatorWiseReportToolStripMenuItem.Click += new System.EventHandler(this.operatorWiseReportToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBody.Location = new System.Drawing.Point(0, 77);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(933, 602);
            this.pnlBody.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.cmbPrinter);
            this.panel1.Controls.Add(this.lblPrinter);
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 51);
            this.panel1.TabIndex = 1;
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(731, 24);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(196, 28);
            this.cmbPrinter.TabIndex = 6;
            this.cmbPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbPrinter_SelectedIndexChanged);
            // 
            // lblPrinter
            // 
            this.lblPrinter.AutoSize = true;
            this.lblPrinter.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrinter.Image = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.lblPrinter.Location = new System.Drawing.Point(674, 27);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(51, 20);
            this.lblPrinter.TabIndex = 5;
            this.lblPrinter.Text = "Printer:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Image = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.lblUser.Location = new System.Drawing.Point(728, 4);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 20);
            this.lblUser.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.testlogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(212, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 46);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // DonationRecording
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 681);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DonationRecording";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DonationRecording";
            this.Load += new System.EventHandler(this.DonationRecording_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enquiryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.ToolStripMenuItem serviceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceReportWithAddressesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceReportWithAddressesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem operatorWiseReportToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPrinter;
        private System.Windows.Forms.ComboBox cmbPrinter;
    }
}