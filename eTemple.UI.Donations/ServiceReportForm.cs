using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eTemple.Data.Repositories;
using eTemple.Data.Models;

namespace eTemple.UI.Donations
{
    public partial class ServiceReportForm : Form
    {
        public ServiceTypeRepository oServiceTypeRep = null;
        public List<ServiceTypes> lstServiceType = null;
        public DonorRepository oDonorRepo = null;

        public ServiceReportForm()
        {
            InitializeComponent();
            oServiceTypeRep = new ServiceTypeRepository();
            oDonorRepo = new DonorRepository();
            lstServiceType = oServiceTypeRep.GetAllAsQuerable().ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServiceReportForm_Load(object sender, EventArgs e)
        {
            cmbServiceType.DataSource = lstServiceType;
            cmbServiceType.DisplayMember = "Name";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbServiceType.SelectedIndex != 0)
            {
                var servceType = cmbServiceType.SelectedItem as ServiceTypes;

                String dtval = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtValue.Text));
                
                dgvServiceReport.AutoGenerateColumns = false;
                DataSet data = oDonorRepo.getServiceReport(servceType.Id.ToString(), dtval);
                DataRow dr = data.Tables[0].NewRow();
                dr["DevoteeName"] = "Totals";
                dr["Amount"] = data.Tables[0].Compute("sum(amount)","");
                data.Tables[0].Rows.Add(dr);
                dgvServiceReport.DataSource = data.Tables[0];
            }
            else
                MessageBox.Show("Please select a service type..");
        }
    }
}
