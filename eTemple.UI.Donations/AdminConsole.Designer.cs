namespace eTemple.UI.Donations
{
    partial class AdminConsole
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
            this.manageServicetypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // manageServicetypesToolStripMenuItem
            // 
            this.manageServicetypesToolStripMenuItem.Name = "manageServicetypesToolStripMenuItem";
            this.manageServicetypesToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.manageServicetypesToolStripMenuItem.Text = "Manage Servicetypes";
            this.manageServicetypesToolStripMenuItem.Click += new System.EventHandler(this.manageServicetypesToolStripMenuItem_Click);
            // 
            // manageEmployeesToolStripMenuItem
            // 
            this.manageEmployeesToolStripMenuItem.Name = "manageEmployeesToolStripMenuItem";
            this.manageEmployeesToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.manageEmployeesToolStripMenuItem.Text = "Manage Employees";
            this.manageEmployeesToolStripMenuItem.Click += new System.EventHandler(this.manageEmployeesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageEmployeesToolStripMenuItem,
            this.manageServicetypesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 51);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.testlogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(256, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(450, 46);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnlBody
            // 
            this.pnlBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlBody.Location = new System.Drawing.Point(0, 78);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(971, 650);
            this.pnlBody.TabIndex = 5;
            // 
            // AdminConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 730);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AdminConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminConsole";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem manageServicetypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageEmployeesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBody;
    }
}