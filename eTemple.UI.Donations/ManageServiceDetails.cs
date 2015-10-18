using eTemple.Data.Models;
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
    public partial class ManageServiceDetails : Form
    {
        private ServiceTypeRepository servRepo;
        // private BindingSource bindingSource = null;
        private DataTable dtDetails;
        public string servId;
        public int rowId;
        public int maxId;
        public ManageServiceDetails()
        {
            InitializeComponent();
            servRepo = new ServiceTypeRepository();
            HideControls(false);
        }

        public void HideControls(bool showhide)
        {
            lblId.Visible = showhide;
            lblCost.Visible = showhide;
            lblServiceName.Visible = showhide;
            chkIsDaterelated.Visible = showhide;
            txtId.Visible = showhide;
            txtCost.Visible = showhide;
            txtServiceName.Visible = showhide;
            btnDelete.Visible = showhide;
            btnSave.Visible = showhide;
            btnUpdate.Visible = showhide;
            btnCancel.Visible = showhide;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageServiceDetails_Load(object sender, EventArgs e)
        {
            loadGridviewData();
        }

        public void loadGridviewData()
        {
            dtDetails = servRepo.GetAllasDataTable();
            foreach (DataRow dr in dtDetails.Rows)
            {
                dr["isdaterelated"] = (dr["isdaterelated"].ToString() == "0") ? "No" : "Yes";
            }
            dgvService.DataSource = dtDetails;
            dgvService.ReadOnly = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            servId = dgvService.Rows[e.RowIndex].Cells[0].Value.ToString();
            rowId = dgvService.Rows[e.RowIndex].Index;
            HideControls(true);
            loadControls();

        }
        /// <summary>
        /// 
        /// </summary>
        public void loadControls()
        {
            if (dtDetails.Rows.Count == 0)
            {
                int set = 100;
                txtId.Text = set.ToString();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnDelete.Enabled = false;
            }
            else
            {
                try
                {
                    bindDataOnGridViewClick();

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void bindDataOnGridViewClick()
        {
            txtId.Text = dtDetails.Rows[rowId]["Id"].ToString();
            txtServiceName.Text = dtDetails.Rows[rowId]["Name"].ToString();
            txtCost.Text = dtDetails.Rows[rowId]["Cost"].ToString();
            chkIsDaterelated.Visible = true;
            chkIsDaterelated.Checked = (dtDetails.Rows[rowId]["isdaterelated"].ToString() == "No") ? false : true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnDelete.Visible = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                var confirmResult = MessageBox.Show("Are you sure to delete this servicetype ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string status = servRepo.DeleteService(servId);
                    HideControls(false);
                    loadGridviewData();
                }
                else
                {
                    //HideControls(false);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceTypes servDetails = new ServiceTypes
                {
                    Id = Convert.ToInt32(dtDetails.Rows[rowId]["Id"]),
                    Cost = Convert.ToInt32((txtCost.Text.Trim() == "") ? "0" : txtCost.Text.Trim()),
                    Name = txtServiceName.Text.Trim(),
                    IsDateRelated = (chkIsDaterelated.Checked == true) ? 1 : 0,
                    ModifiedOn = DateTime.Today.Date,
                    ModifiedBy = ApplicationElements.loggedInEmployee.Id
                };


                string updateStatus = servRepo.updateSvcInformation(servDetails);

                if (updateStatus == "Success")
                {
                    MessageBox.Show("Details updated successfully.");
                    loadGridviewData();
                    CleareAllcontrolsRecursive();
                }
                else
                {
                    MessageBox.Show("Update Failed...");
                    loadGridviewData();
                    CleareAllcontrolsRecursive();
                }
                // txtRole.Visible = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            CleareAllcontrolsRecursive();
            HideControls(true);
            maxId = Convert.ToInt16(dtDetails.Compute("MAX(id)", string.Empty));
            maxId = maxId + 1;
            txtId.Text = maxId.ToString();
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnDelete.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ServiceTypes servDetails = new ServiceTypes
            {
                Id = maxId,
                Cost = Convert.ToInt32((txtCost.Text.Trim() == "") ? "0" : txtCost.Text.Trim()),
                Name = txtServiceName.Text.Trim(),
                IsDateRelated = (chkIsDaterelated.Checked == true) ? 1 : 0,
                CreatedOn = DateTime.Today.Date,
                CreatedBy = ApplicationElements.loggedInEmployee.Id
            };

            string insertStatus = servRepo.InsertEmployee(servDetails);

            if (insertStatus == "Success")
            {
                MessageBox.Show("Data inserted successfully.");
                loadGridviewData();
                CleareAllcontrolsRecursive();
            }
            else
            {
                MessageBox.Show("Add Failed...");
                loadGridviewData();
                CleareAllcontrolsRecursive();
            }
        }

        private void CleareAllcontrolsRecursive()
        {
            chkIsDaterelated.Visible = false;
            lblId.Visible = false;
            lblCost.Visible = false;
            lblServiceName.Visible = false;
            txtId.Visible = false;
            txtId.Text = "";
            txtCost.Visible = false;
            txtCost.Text = "";
            txtServiceName.Visible = false;
            txtServiceName.Text = "";
            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            HideControls(false);
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
