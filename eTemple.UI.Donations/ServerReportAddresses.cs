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
using System.Drawing.Printing;

namespace eTemple.UI.Donations
{
    public partial class ServerReportAddresses : Form
    {
        public ServiceTypeRepository oServiceTypeRep = null;
        public List<ServiceTypes> lstServiceType = null;
        public DonorRepository oDonorRepo = null;
        public ServerReportAddresses()
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbServiceType.SelectedIndex != 0)
            {
                var servceType = cmbServiceType.SelectedItem as ServiceTypes;

                String dtval = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtValue.Text));

                dgvServiceReport.AutoGenerateColumns = false;
                DataSet data = oDonorRepo.getServiceReport(servceType.Id.ToString(), dtval);
                DataRow dr = data.Tables[0].NewRow();
                //dr["DevoteeName"] = "Totals";
                //dr["Amount"] = data.Tables[0].Compute("sum(amount)", "");
                //data.Tables[0].Rows.Add(dr);
                dgvServiceReport.DataSource = data.Tables[0];
            }
            else
                MessageBox.Show("Please select a service type..");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cmbServiceType.SelectedIndex != 0)
            {
                var reportViewer = new ReportViewer();
                reportViewer.HeaderWidthPercent = 100;
                reportViewer.ContentWidthPercent = 100;
                reportViewer.RowsPerPage = 30;
                //reportViewer.HeaderContent = string.Format("<h2 style='margin-left:100px'>Daily Collection Report for the Date of {0:dd/MM/yyyy}</h2>", this.dtpFromDate.Value);
                reportViewer.HeaderContent = string.Format("<div style='float: left; width: 350px;'>Date : {0: dd-MM-YYYY} </div>", dtValue.Text);
                reportViewer.GenerateFromGridView(this.dgvServiceReport, false);
                reportViewer.Show(this);
            }
            else
                MessageBox.Show("Please select a service type..");
        }

        private void ServerReportAddresses_Load(object sender, EventArgs e)
        {
            cmbServiceType.DataSource = lstServiceType;
            cmbServiceType.DisplayMember = "Name";
        }
    }
}
