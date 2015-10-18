using eTemple.Data.Repositories;
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
    public partial class AdminConsole : Form
    {
        private ManageEmployeeDetails oMgmtEmpDetails;
        private ManageServiceDetails oMgmtServiceDetails;

        public AdminConsole()
        {
            InitializeComponent();
            
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            pnlBody.Controls.Clear();
            oMgmtEmpDetails = new ManageEmployeeDetails();
            oMgmtEmpDetails.TopLevel = false;
            pnlBody.Controls.Add(oMgmtEmpDetails);
            oMgmtEmpDetails.Location = new Point(0, 0);
            oMgmtEmpDetails.Show();
        }

        private void manageServicetypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDispose();
            oMgmtServiceDetails = new ManageServiceDetails();
            oMgmtServiceDetails.TopLevel = false;
            pnlBody.Controls.Add(oMgmtServiceDetails);
            oMgmtServiceDetails.Location = new Point(0, 0);
            oMgmtServiceDetails.Show();
        }

        public void formDispose()
        {
            if (oMgmtEmpDetails != null)
                oMgmtEmpDetails.Dispose();
            if (oMgmtServiceDetails != null)
                oMgmtServiceDetails.Dispose();            
        }
    }
}
