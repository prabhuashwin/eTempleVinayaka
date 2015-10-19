namespace eTemple.UI.Donations
{
    partial class ManagementConsole
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
            this.picBoxDonation = new System.Windows.Forms.PictureBox();
            this.picBoxAdmin = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDonation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAdmin)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxDonation
            // 
            this.picBoxDonation.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.donate_now_button1;
            this.picBoxDonation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxDonation.Location = new System.Drawing.Point(553, 157);
            this.picBoxDonation.Name = "picBoxDonation";
            this.picBoxDonation.Size = new System.Drawing.Size(182, 128);
            this.picBoxDonation.TabIndex = 5;
            this.picBoxDonation.TabStop = false;
            this.picBoxDonation.Click += new System.EventHandler(this.picBoxDonation_Click);
            // 
            // picBoxAdmin
            // 
            this.picBoxAdmin.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.AdminModule;
            this.picBoxAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBoxAdmin.Location = new System.Drawing.Point(229, 157);
            this.picBoxAdmin.Name = "picBoxAdmin";
            this.picBoxAdmin.Size = new System.Drawing.Size(182, 128);
            this.picBoxAdmin.TabIndex = 4;
            this.picBoxAdmin.TabStop = false;
            this.picBoxAdmin.Click += new System.EventHandler(this.picBoxAdmin_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.lblUser);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 51);
            this.panel1.TabIndex = 8;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Image = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.lblUser.Location = new System.Drawing.Point(759, 16);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 20);
            this.lblUser.TabIndex = 5;
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
            // ManagementConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eTemple.UI.Donations.Properties.Resources.wood4;
            this.ClientSize = new System.Drawing.Size(1012, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picBoxDonation);
            this.Controls.Add(this.picBoxAdmin);
            this.Name = "ManagementConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManagementConsole";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDonation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxAdmin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxDonation;
        private System.Windows.Forms.PictureBox picBoxAdmin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUser;
    }
}