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
    public partial class DCRForm : Form
    {
        public DataTable DCRVals = null;
        public DonorRepository oDonorRepository = null;
        public DailyAnnaDanamRepository oDailyAnnaDanamRepository = null;

        public DCRForm()
        {
            InitializeComponent();
            oDonorRepository = new DonorRepository();
            oDailyAnnaDanamRepository = new DailyAnnaDanamRepository();
            DCRVals = new DataTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ServiceReportForm_Load(object sender, EventArgs e)
        {
            //cmbServiceType.DataSource = lstServiceType;
            //cmbServiceType.DisplayMember = "Name";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DCRVals = new DataTable();
            DataSet DonorRecs = oDonorRepository.getTotalAmountpbySVC(dtValue.Value.ToString("yyyy-MM-dd"));
            //Getting cost for daily annadanam
            DataSet svcCost = oDonorRepository.getCostbyId("10");
            // double dailyanndanamCost = Convert.ToDouble(svcCost.Tables[0].Rows[0][0]);
            int count = 0;
            double totalAmount = 0;
            string perfrmDate = DateTime.Now.ToString("dd-MM-yyyy");
            DCRVals.Columns.Add("PerformDate");
            DCRVals.Columns.Add("Sno");
            DCRVals.Columns.Add("ServiceType");
            DCRVals.Columns.Add("CostPerUnit");
            DCRVals.Columns.Add("Start");
            DCRVals.Columns.Add("End");
            DCRVals.Columns.Add("Quantity");
            DCRVals.Columns.Add("TotalCost");


            foreach (DataRow dr in DonorRecs.Tables[0].Rows)
            {
                DataRow drNew = DCRVals.NewRow();
                drNew["PerformDate"] = perfrmDate;
                drNew["Sno"] = count + 1;
                drNew["ServiceType"] = dr["ServiceType"];
                drNew["CostPerUnit"] = string.Format("{0:0.00}", dr["cost"]);
                drNew["Start"] = "0";
                drNew["End"] = "0";
                drNew["Quantity"] = dr["cnt"];
                drNew["TotalCost"] = dr["Amount"];
                count++;
                totalAmount = totalAmount + Convert.ToDouble(dr["Amount"]);
                DCRVals.Rows.Add(drNew);
            }
            int qty = Convert.ToInt32(oDailyAnnaDanamRepository.getTotalAmtperDate(DateTime.Now.ToString("yyyy-MM-dd")).Tables[0].Rows[0][0]);
            if (qty > 0)
            {
                DataRow drDailyAnndnmRow = DCRVals.NewRow();
                drDailyAnndnmRow["PerformDate"] = perfrmDate;
                drDailyAnndnmRow["Sno"] = count + 1;
                drDailyAnndnmRow["ServiceType"] = "Daily Annadanam";
                drDailyAnndnmRow["CostPerUnit"] = string.Format("{0:0.00}", "123");
                drDailyAnndnmRow["Start"] = "0";
                drDailyAnndnmRow["End"] = "0";
                drDailyAnndnmRow["Quantity"] = qty;
                double totalCost = qty * Convert.ToDouble(drDailyAnndnmRow["CostPerUnit"]);
                drDailyAnndnmRow["TotalCost"] = string.Format("{0:0.00}", totalCost);
                totalAmount = totalAmount + Convert.ToDouble(totalCost);

                DCRVals.Rows.Add(drDailyAnndnmRow);
            }
            DataRow drTotalRow = DCRVals.NewRow();
            drTotalRow["PerformDate"] = perfrmDate;
            drTotalRow["Sno"] = 0;
            drTotalRow["ServiceType"] = "Totals";
            drTotalRow["CostPerUnit"] = "0.00";
            drTotalRow["Start"] = "0";
            drTotalRow["End"] = "0";
            drTotalRow["Quantity"] = "0";
            drTotalRow["TotalCost"] = string.Format("{0:0.00}", totalAmount);
            DCRVals.Rows.Add(drTotalRow);
            dgvServiceReport.AutoGenerateColumns = false;
            dgvServiceReport.DataSource = DCRVals;
        }

        private void btnPrint_Click(object sender, EventArgs e)
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
    }
}
