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
    public partial class ServiceReportOperatorWise : Form
    {
        public EmployeeRepository oEmployee = null;
        public List<Employees> lstEmployee = null;
        public DonorRepository oDonorRepo = null;

        public ServiceReportOperatorWise()
        {
            InitializeComponent();
            oEmployee = new EmployeeRepository();
            oDonorRepo = new DonorRepository();
            lstEmployee = oEmployee.GetAllAsQuerable().ToList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServiceReportForm_Load(object sender, EventArgs e)
        {
            cmbEmployee.DataSource = lstEmployee;
            cmbEmployee.DisplayMember = "LoginId";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var emp = cmbEmployee.SelectedItem as Employees;

            String dtval = string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(dtValue.Text));

            dgvServiceReport.AutoGenerateColumns = false;
            DataSet data = oDonorRepo.getServiceReportByEmployee(emp.Id.ToString(), dtval);
            DataRow dr = data.Tables[0].NewRow();
            dr["servicename"] = "Totals";
            dr["totalcollection"] = data.Tables[0].Compute("sum(totalcollection)", "");
            data.Tables[0].Rows.Add(dr);
            dgvServiceReport.DataSource = data.Tables[0];
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            var reportViewer = new ReportViewer();
            reportViewer.HeaderWidthPercent = 100;
            reportViewer.ContentWidthPercent = 100;
            reportViewer.RowsPerPage = 30;
            reportViewer.HeaderContent = string.Format("<center><h2>Daily Collection Report for the Date of {0:dd/MM/yyyy} of {1}</h2></center>", this.dtValue.Text, ApplicationElements.loggedInEmployee.LoginId);
            reportViewer.GenerateFromGridView(this.dgvServiceReport, false);
            reportViewer.Show(this);

        }
    }
}
