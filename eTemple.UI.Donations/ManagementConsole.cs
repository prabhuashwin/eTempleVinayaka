using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTemple.Data.Models;
using eTemple.Data.Repositories;

namespace eTemple.UI.Donations
{
    public partial class ManagementConsole : Form
    {

        public RoleModuleMapRepository oModuleMaprepo;
        public ManagementConsole()
        {
            InitializeComponent();
            lblUser.Text = "Welcome " + ApplicationElements.loggedInEmployee.LoginId;
            oModuleMaprepo = new RoleModuleMapRepository();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxAdmin_Click(object sender, EventArgs e)
        {
            if (oModuleMaprepo.isAuthorized(ApplicationElements.loggedInEmployee.Role, 1, "Admin") == 1)
            {
                AdminConsole admConsole = new AdminConsole();
                admConsole.ShowDialog();
            }
            else
                MessageBox.Show("You are not authorised to view this module.. Please contact administrator");
        }

        private void picBoxDonation_Click(object sender, EventArgs e)
        {
            if (oModuleMaprepo.isAuthorized(ApplicationElements.loggedInEmployee.Role, 1, "Donation") == 1)
            {
                DonationRecording odonationRecording = new DonationRecording();
                odonationRecording.ShowDialog();
            }
            else
                MessageBox.Show("You are not authorised to view this module.. Please contact administrator");
        }

       
    }
}
