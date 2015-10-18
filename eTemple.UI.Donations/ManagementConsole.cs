using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eTemple.UI.Donations
{
    public partial class ManagementConsole : Form
    {

        public ManagementConsole()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxAdmin_Click(object sender, EventArgs e)
        {
            AdminConsole admConsole = new AdminConsole();
            admConsole.ShowDialog();
        }

        private void picBoxDonation_Click(object sender, EventArgs e)
        {
            DonationRecording odonationRecording = new DonationRecording();
            odonationRecording.ShowDialog();
        }
    }
}
