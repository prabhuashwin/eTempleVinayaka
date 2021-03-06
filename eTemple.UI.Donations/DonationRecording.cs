﻿using eTemple.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace eTemple.UI.Donations
{
    public partial class DonationRecording : Form
    {
        private DonationInformation oDonationInfo;
        private EnquiryDetailsUI oEnquiryDet;
        private DonorMasterReportUI oDonorReprt;
        private DCRForm oDCRForm;
        private DonationRecording oDonationRecording;
        private ServiceReportForm oServiceReportForm;
        private ServerReportAddresses oServerReportAddresses;
        private ServiceReportOperatorWise oServiceReportOperatorWise;
        public string PrinterName;
        public DonationRecording()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void DonationRecording_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Welcome " + ApplicationElements.loggedInEmployee.LoginId;
           foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(printerName);
            }

           if (cmbPrinter.Items.Count > 0)
           {
               cmbPrinter.SelectedIndex = 0;
           }
           else
           {
               MessageBox.Show("No printers found on this machine. Please install printers for token  printing.", "No Printers found !", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void masterReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oDonationInfo = new DonationInformation();
            oDonationInfo.TopLevel = false;
            pnlBody.Controls.Add(oDonationInfo);
            oDonationInfo.Location = new Point(0, 0);
            oDonationInfo.Show();
        }

        private void eitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void masterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oDonorReprt = new DonorMasterReportUI();
            oDonorReprt.TopLevel = false;
            pnlBody.Controls.Add(oDonorReprt);
            oDonorReprt.Location = new Point(150, 100);
            oDonationRecording = new DonationRecording();
            oDonationRecording.Size = new Size(557, 422);
            oDonorReprt.Show();
        }

        private void enquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oEnquiryDet = new EnquiryDetailsUI();
            oEnquiryDet.TopLevel = false;
            pnlBody.Controls.Add(oEnquiryDet);
            oEnquiryDet.Location = new Point(0, 0);
            oEnquiryDet.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void formDispose()
        {
            if (oDonationInfo != null)
                oDonationInfo.Dispose();
            if (oEnquiryDet != null)
                oEnquiryDet.Dispose();
            if (oDonorReprt != null)
                oDonorReprt.Dispose();
            if (oDCRForm != null)
                oDCRForm.Dispose();
            if (oServiceReportForm != null)
                oServiceReportForm.Dispose();
            if (oServerReportAddresses != null)
                oServerReportAddresses.Dispose();
            if (oServiceReportOperatorWise != null)
                oServiceReportOperatorWise.Dispose();

        }


        public void getDataFromChildWindow(int value)
        {
            oDonationInfo.getDataFromChildWindow(value);
        }

        public void getDataFromChildWindow(Donors donor)
        {
            oDonationInfo.getDataFromChildWindow(donor);
        }

        private void serviceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oDCRForm = new DCRForm();
            oDCRForm.TopLevel = false;
            pnlBody.Controls.Add(oDCRForm);
            oDCRForm.Location = new Point(0, 0);
            //oDCRReportForm.MdiParent = this;
            oDCRForm.WindowState = FormWindowState.Maximized;
            oDCRForm.Show();

        }

        private void serviceReportWithAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            formDispose();
            oServiceReportForm = new ServiceReportForm();
            oServiceReportForm.TopLevel = false;
            pnlBody.Controls.Add(oServiceReportForm);
            oServiceReportForm.Location = new Point(0, 0);
            //oDCRReportForm.MdiParent = this;
            oServiceReportForm.WindowState = FormWindowState.Maximized;
            oServiceReportForm.Show();
        }

        private void serviceReportWithAddressesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            formDispose();
            oServerReportAddresses = new ServerReportAddresses();
            oServerReportAddresses.TopLevel = false;
            pnlBody.Controls.Add(oServerReportAddresses);
            oServerReportAddresses.Location = new Point(0, 0);
            //oDCRReportForm.MdiParent = this;
            oServerReportAddresses.WindowState = FormWindowState.Maximized;
            oServerReportAddresses.Show();
        }

        private void operatorWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oServiceReportOperatorWise = new ServiceReportOperatorWise();
            oServiceReportOperatorWise.TopLevel = false;
            pnlBody.Controls.Add(oServiceReportOperatorWise);
            oServiceReportOperatorWise.Location = new Point(0, 0);
            //oDCRReportForm.MdiParent = this;
            oServiceReportOperatorWise.WindowState = FormWindowState.Maximized;
            oServiceReportOperatorWise.Show();
        }

        private void cmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbPrinter.SelectedIndex!=-1)
            { 
              DonationInformation.printerName = cmbPrinter.SelectedItem.ToString();
            }
        }

    }
}
