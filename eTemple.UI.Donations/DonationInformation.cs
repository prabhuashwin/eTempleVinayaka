﻿using eTemple.Data;
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
using System.Data.SqlClient;
using eTemple.UI.Donations;
using eTemple.Data.Models;
using System.Net.Http;
using System.Configuration;
using eTemple.Data.Utilities;

namespace eTemple.UI
{
    public partial class DonationInformation : Form
    {
        private DonorRepository donorRepo;
        private DateTypeRepository datetypeRepo;
        private DesignationRepository desigRepo;
        private EmployeeRepository employeeRepo;
        private PrefixesRepository prefixRepo;
        private RoleRepository roleRepo;
        private ServiceNameRepository serviceNameRepo;
        private ServiceTypeRepository serviceTypeRepo;
        private SpecialDayRepository specialDayRepo;
        private StarsRepository starRepo;
        private MonthsRepository monthsRepo;
        private PakshaRepository pakshaRepo;
        private ThidhiRepository thithiRepo;
        private MonthlyAnnaRepository monthlyAnnaRepo;
        public GothramsRepository gothramRepo;
        public StateRepository stateRepo;
        public PrefixesRepository prefixesRepo;
        public TransactionTypeRepository transTypeRepo;
        public List<State> lstStates = null;
        public List<Gothrams> lstGothrams = null;
        public List<TokenPrint> lstTokenPrint = null;
        public List<Donors> lstCityVillage = null;
        public List<Donors> lstMandal = null;
        public List<Donors> lstPurpose = null;
        public List<Donors> lstDistrict = null;
        public static string printerName = string.Empty;
        public DonationInformation()
        {
            //dtpDate.MinDate = DateTime.Now;
            this.MaximizeBox = false;
            InitializeComponent();

            dtpEnglishDateType.Format = DateTimePickerFormat.Custom;
            dtpEnglishDateType.CustomFormat = "dd/MM";

            donorRepo = new DonorRepository();
            datetypeRepo = new DateTypeRepository();
            desigRepo = new DesignationRepository();
            employeeRepo = new EmployeeRepository();
            prefixRepo = new PrefixesRepository();
            roleRepo = new RoleRepository();
            serviceNameRepo = new ServiceNameRepository();
            serviceTypeRepo = new ServiceTypeRepository();
            specialDayRepo = new SpecialDayRepository();
            starRepo = new StarsRepository();
            monthsRepo = new MonthsRepository();
            pakshaRepo = new PakshaRepository();
            thithiRepo = new ThidhiRepository();
            monthlyAnnaRepo = new MonthlyAnnaRepository();
            gothramRepo = new GothramsRepository();
            transTypeRepo = new TransactionTypeRepository();
            lstTokenPrint = new List<TokenPrint>();
            stateRepo = new StateRepository();
            lstStates = new List<State>();
            prefixesRepo = new PrefixesRepository();

            bindData();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;

            lblSpecialDay.Visible = false;
            cmbSpecialDay.Visible = false;
            lblMonth.Visible = false;
            cmbMonth.Visible = false;
            lblThithi.Visible = false;
            cmbThithi.Visible = false;
            lblMonthlyAnna.Visible = false;
            cmbMonthlyAnna.Visible = false;
            lblEnglishDatetype.Visible = false;
            dtpEnglishDateType.Visible = false;
            rbdEnglish.Checked = false;
            rbdTelugu.Checked = false;
            lblMonthyAnnaThithi.Visible = false;
            cmbMonthyAnnaThithi.Visible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool checkvalidate = validation();
            if (checkvalidate == false)
                return;

            string performDate = string.Empty;
            DateTime donorDate;
            string transactionDate = string.Empty;

            try
            {
                donorDate = Convert.ToDateTime(dtpDate.Text);


                if (dtpEnglishDateType.Enabled == true)
                    performDate = dtpEnglishDateType.Value.ToString("dd-MM");
                else
                    performDate = "";

                if (cmbTransactionDate.Enabled == true)
                    transactionDate = cmbTransactionDate.Value.ToString("dd-MM-yyyy");
                else
                    transactionDate = "";


                if ((txtTransaction.Text == "") || (txtTransaction.Text == string.Empty))
                    txtTransaction.Text = null;

                if ((txtPin.Text == "") || (txtPin.Text == string.Empty))
                    txtPin.Text = null;

                if ((txtLandline.Text == "") || (txtLandline.Text == string.Empty))
                    txtLandline.Text = null;

                if ((txtMobile.Text == "") || (txtMobile.Text == string.Empty))
                    txtMobile.Text = null;

                if ((txtTransaction.Text == "") || (txtTransaction.Text == string.Empty))
                    txtTransaction.Text = null;

                if ((txtMandal.Text == "") || (txtMandal.Text == string.Empty))
                    txtMandal.Text = null;


                int selectedServiceTypeId;
                int selectedServiceNameId;
                int selectedMonthId;
                int selectedStarId;
                int selectedSpecialDayId;
                int selectedThithiId;
                int selectedDayId;
                int selectedDonorThithi;
                int selectedTransactionTypeId;
                var selectedDateTypeId = SelectedDateTypeId(out selectedServiceTypeId, out selectedServiceNameId, out selectedMonthId, out selectedStarId, out selectedSpecialDayId, out selectedThithiId, out selectedDayId, out selectedDonorThithi, out selectedTransactionTypeId);

                string maxIDFormat = DateForId(donorDate);

                #region AutoGenerate Id
                var maxDonorId = donorRepo.getMaxIdFromDonor(maxIDFormat);
                int maxId = 0;
                //date = date.ToString("yyyy/mm/dd");
                if (maxDonorId.Tables[0].Rows.Count > 0)
                {
                    string Id = maxDonorId.Tables[0].Rows[0]["donroId"].ToString();
                    maxId = Convert.ToInt32(Id) + 1;
                }
                else
                    maxId = 1;

                string uniqueDonorId = DateForId(donorDate) + " " + maxId;

                #endregion
                #region AutoGenerate MRNo

                var fetchMRNO = donorRepo.getMaxMRNoFromDonor();
                int maxMRNO = 0;
                //date = date.ToString("yyyy/mm/dd");
                if (fetchMRNO.Tables[0].Rows.Count > 0)
                {
                    int Id = Convert.ToInt32(fetchMRNO.Tables[0].Rows[0]["donroMRNo"]);
                    if (Id == 0)
                        maxMRNO = 15001;
                    else
                        maxMRNO = Id + 1;
                }
                //}
                //else
                //    maxId = 15000;

                string uniqueMRNo = Convert.ToString(maxMRNO);

                #endregion
                if (cmbServiceName.Enabled == false)
                    selectedServiceNameId = 0;

                if (cmbMonth.Enabled == false)
                    selectedMonthId = 0;

                if (cmbSpecialDay.Enabled == false)
                    selectedSpecialDayId = 0;

                if (cmbThithi.Enabled == false)
                    selectedThithiId = 0;

                if (cmbMonthlyAnna.Enabled == false)
                    selectedDayId = 0;

                if (cmbMonthyAnnaThithi.Enabled == false)
                    selectedDonorThithi = 0;

                var nameonPrefix = cmbNameOnPrefix.SelectedItem as Prefixes;
                var namePrefix = cmbNamePrefix.SelectedItem as Prefixes;
                Donors donorInfo = new Donors
                {
                    Id = uniqueDonorId,
                    Donordate = donorDate,
                    Prefix_Name = namePrefix.Id,
                    DonorName = txtName.Text,
                    DistrictName = txtDistrict.Text,
                    City = txtCity.Text,
                    Pin = txtPin.Text,
                    State = txtState.Text,
                    Prefix_NameOn = nameonPrefix.Id,
                    NameOn = txtNameOn.Text,
                    Star = selectedStarId,
                    TransactionTypeId = selectedTransactionTypeId,
                    TransactionId = txtTransaction.Text,
                    TransactionDate = transactionDate,
                    Occasion = txtPurpose.Text,
                    Gothram = txtGothram.Text,
                    MR_No = uniqueMRNo,
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    Landline = txtLandline.Text,
                    SpecialDayId = selectedSpecialDayId,
                    ServiceTypeId = selectedServiceTypeId,
                    ServiceNameId = selectedServiceNameId,
                    DateTypeId = selectedDateTypeId,
                    DoorNo = txtDoorNo.Text,
                    Mandal = txtMandal.Text,
                    PerformDate = performDate,
                    EmailId = txtEmailId.Text,
                    DonorMonth = selectedMonthId,
                    Thidhi = selectedThithiId,
                    DonorDay = selectedDayId,
                    Mobile = txtMobile.Text,
                    DonorThithi = selectedDonorThithi,
                    CreatedBy = ApplicationElements.loggedInEmployee.Id
                };
                string performDate_ForPrint = string.Empty;
                var selecteddtType = cmbDateType.SelectedItem as DateType;
                var selectedMonth = cmbMonth.SelectedItem as Months;
                var selectdThidhi = cmbThithi.SelectedItem as Thidhi;
                var selectdspDay = cmbSpecialDay.SelectedItem as SpecialDay;
                var selectedStar = cmbStar.SelectedItem as Stars;
                if (cmbDateType.Enabled == true)
                {
                    switch (selecteddtType.Id)
                    {
                        case 1:
                            performDate_ForPrint = selectedMonth.Name + "  " + selectdThidhi.Name;
                            break;
                        case 2:
                            performDate_ForPrint = dtpEnglishDateType.Value.ToString("dd-MMM");
                            break;
                        case 3:
                            performDate_ForPrint = selectdspDay.Name;
                            break;
                    }
                }
                var selectedServiceType = cmbServiceType.SelectedItem as ServiceTypes;
                TokenPrint oTokenPrint = new TokenPrint
                {
                    Id = uniqueMRNo,
                    Name = txtName.Text,
                    NameOn = txtNameOn.Text,
                    PerformDate = performDate_ForPrint,
                    Star = (selectedStar.Id == 0) ? "" : selectedStar.Name,
                    PhoneNumber = txtMobile.Text,
                    Gothram = txtGothram.Text,
                    VillageName = txtCity.Text,
                    ServiceType = selectedServiceType.Name,
                    Cost = Convert.ToDouble(txtAmount.Text),
                    LoginName = ApplicationElements.loggedInEmployee.LoginId
                };

                //check if gothra exists
                var checkIfExists = gothramRepo.checkIfGothramExists(txtGothram.Text);

                //If Gothra doesn't exist and if user has entered a Gothram
                if (checkIfExists == null && txtGothram.Text != string.Empty)
                {
                    string insrtGothra = gothramRepo.insertNewGothraName(txtGothram.Text);
                }

                //Insert the Donor Information
                string strInsertStatus = donorRepo.insertDonorInformation(donorInfo);

                string performDatePrintMsg = string.Empty;
                if (performDate_ForPrint != "" && performDate_ForPrint != string.Empty)
                    performDatePrintMsg = " to be performed on " + performDate_ForPrint;
                //var selectedServiceType = cmbServiceType.SelectedItem as ServiceTypes;

                string smsMessage = "We have received an amount of Rs." + donorInfo.Amount + "/- towards " + selectedServiceType.Name + performDatePrintMsg + " Visit: www.svstemple.com , Call:08856225812 ";

                if (strInsertStatus == "Success")
                {
                    MessageBox.Show("Data inserted successfully.");
                    CleareAllcontrolsRecursive();
                    loadGothramAutoComplete();
                    loadGothramAutoComplete();
                    loadStateAutoComplete();
                    loadCityVillageAutoComplete();
                    loadMandalAutoComplete();
                    loadDistrictAutoComplete();

                    try
                    {
                        SMSHelper smshelper = new SMSHelper();
                        smshelper.sendSMS("91" + donorInfo.Mobile, smsMessage);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was a problem sending SMS to the recipients.");
                    }
                    PrintHelper oPrintHelper = new PrintHelper();
                    lstTokenPrint.Clear();
                    lstTokenPrint.Add(oTokenPrint);
                    if (printerName == string.Empty || printerName == "")
                    {
                        MessageBox.Show("Token cannot be printed.... Please install a printer and select..");
                    }
                    else
                        oPrintHelper.PrintTokens(lstTokenPrint, this, printerName, Convert.ToBoolean(ConfigurationManager.AppSettings["ShowPrintPreview"]));
                }
                else
                    MessageBox.Show("There was a problem inserting data, kindly try again to save the record");
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was a problem inserting data, kindly try again to save the record " + ex.Message);
            }
        }

        public static int customConvertToInt32(object value, int defaultValue)
        {
            if (value == null)
                return defaultValue;
            return Convert.ToInt32(value);
        }

        private int SelectedDateTypeId(out int selectedServiceTypeId, out int selectedServiceNameId,
            out int selectedMonthId, out int selectedStarId, out int selectedSpecialDayId, out int selectedThithiId,
            out int selectedDayId, out int selectedDonorThithiId, out int selectedTransactionTypeId)
        {
            int selectedDateTypeId = 0;
            selectedServiceTypeId = 0;
            selectedServiceNameId = 0;
            selectedMonthId = 0;
            selectedStarId = 0;
            selectedSpecialDayId = 0;
            selectedThithiId = 0;
            string selectedPakshaName = "";
            selectedDayId = 0;
            selectedDonorThithiId = 0;
            selectedTransactionTypeId = 0;

            var selectedDateType = cmbDateType.SelectedItem as DateType;
            if (selectedDateType == null)
                selectedDateTypeId = 0;
            else
                selectedDateTypeId = selectedDateType.Id;

            var selectedServiceType = cmbServiceType.SelectedItem as ServiceTypes;
            if (selectedServiceType == null)
                selectedServiceTypeId = 0;
            else
                selectedServiceTypeId = selectedServiceType.Id;


            var selectedServiceName = cmbServiceName.SelectedItem as ServiceName;
            if (selectedServiceName == null)
                selectedServiceNameId = 0;
            else
                selectedServiceNameId = selectedServiceName.Id;

            var selectedMonth = cmbMonth.SelectedItem as Months;
            if (selectedMonth == null)
                selectedMonthId = 0;
            else
                selectedMonthId = selectedMonth.Id;

            var selectedStar = cmbStar.SelectedItem as Stars;
            if (selectedStar == null)
                selectedStarId = 0;
            else
                selectedStarId = selectedStar.Id;

            var selectedSpecialDay = cmbSpecialDay.SelectedItem as SpecialDay;
            if (selectedSpecialDay == null)
                selectedSpecialDayId = 0;
            else
                selectedSpecialDayId = selectedSpecialDay.Id;

            var selectedThithi = cmbThithi.SelectedItem as Thidhi;
            if (selectedThithi == null)
                selectedThithiId = 0;
            else
                selectedThithiId = selectedThithi.Id;

            var selectedDay = cmbMonthlyAnna.SelectedItem as MonthlyAnnaDanam;
            if (selectedDay == null)
                selectedDayId = 0;
            else
                selectedDayId = selectedDay.Id;

            var selectedDonorThithi = cmbMonthyAnnaThithi.SelectedItem as Thidhi;
            if (selectedDonorThithi == null)
                selectedDonorThithiId = 0;
            else
                selectedDonorThithiId = selectedDonorThithi.Id;

            var selectedTransactionType = cmbTransaction.SelectedItem as TransactionType;
            if (selectedTransactionType == null)
                selectedTransactionTypeId = 0;
            else
                selectedTransactionTypeId = selectedTransactionType.Id;

            return selectedDateTypeId;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string DateForId(DateTime date)
        {
            String dy = date.Day.ToString();
            String mn = date.Month.ToString();
            String yy = date.Year.ToString();

            string s3 = yy + mn + dy;

            return s3;

        }

        public void bindData()
        {
            lblServiceName.Enabled = true;
            cmbServiceName.Enabled = true;

            #region Default Date Type Values
            //cmbDateType.Items.Insert(0, "--Select--");
            //cmbDateType.Items.Insert(1, "Telugu");
            //cmbDateType.Items.Insert(2, "English");

            //cmbDateType.SelectedIndex = 0;
            var bindDateType = datetypeRepo.GetAllAsQuerable();
            var cmbListDateType = bindDateType.ToList();
            cmbDateType.DataSource = cmbListDateType;
            cmbDateType.DisplayMember = "Name";
            #endregion


            #region Bind Stars values
            var bindStars = starRepo.GetAllAsQuerable();
            cmbStar.DataSource = bindStars;
            cmbStar.DisplayMember = "Name";
            #endregion

            #region Bind Prefixes values
            var prefixes = prefixesRepo.GetAllAsQuerable();
            cmbNamePrefix.DataSource = prefixes;
            cmbNamePrefix.DisplayMember = "Name";
            var prefixes1 = prefixesRepo.GetAllAsQuerable();
            cmbNameOnPrefix.DataSource = prefixes1;
            cmbNameOnPrefix.DisplayMember = "Name";
            #endregion

            #region Bind ServiceType values
            var bindServiceType = serviceTypeRepo.GetAllAsQuerable();
            cmbServiceType.DataSource = bindServiceType;
            cmbServiceType.DisplayMember = "Name";
            #endregion

            #region Bind TransactionType

            var bindTransactionType = transTypeRepo.GetAllAsQuerable();
            cmbTransaction.DataSource = bindTransactionType;
            cmbTransaction.DisplayMember = "Name";

            #endregion

            //#region Bind ServiceName values
            //var bindServiceName = serviceNameRepo.GetAllAsQuerable();
            //cmbServiceName.DataSource = bindServiceName;
            //cmbServiceName.DisplayMember = "Name";
            //#endregion

            var serviceType = cmbServiceType.SelectedItem as ServiceTypes;
            if (serviceType != null)
            {
                cmbServiceName.DataSource = serviceNameRepo.GetAllAsQuerable().Where(sType => sType.ServiceTypeId == serviceType.Id).ToList();
                cmbServiceName.DisplayMember = "Name";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbDateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDateType = cmbDateType.SelectedItem as DateType;

            if (selectedDateType.Name == "Telugu")
            {
                lblSpecialDay.Visible = false;
                cmbSpecialDay.Visible = false;
                cmbSpecialDay.Enabled = false;
                lblEnglishDatetype.Visible = false;
                dtpEnglishDateType.Visible = false;
                dtpEnglishDateType.Enabled = false;
                dtpEnglishDateType.CustomFormat = "";
                lblMonth.Visible = true;
                cmbMonth.Enabled = true;
                cmbMonth.Visible = true;
                lblThithi.Visible = true;
                cmbThithi.Visible = true;
                cmbThithi.Enabled = true;
                lblMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Enabled = false;
                cmbMonthlyAnna.Enabled = false;
                cmbMonthlyAnna.Visible = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                lblMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Enabled = false;

                #region Bind Month values
                var bindMonth = monthsRepo.GetAllAsQuerable();
                cmbMonth.DataSource = bindMonth;
                cmbMonth.DisplayMember = "Name";
                #endregion

                #region Thithi
                var bindThithi = thithiRepo.GetAllAsQuerable();
                cmbThithi.DataSource = bindThithi;
                cmbThithi.DisplayMember = "Name";
                #endregion
            }

            else if (selectedDateType.Name == "English")
            {
                lblSpecialDay.Visible = false;
                cmbSpecialDay.Visible = false;
                cmbSpecialDay.Enabled = false;
                lblEnglishDatetype.Visible = true;
                dtpEnglishDateType.Visible = true;
                dtpEnglishDateType.Enabled = true;
                lblMonth.Visible = false;
                cmbMonth.Visible = false;
                cmbMonth.Enabled = false;
                lblThithi.Visible = false;
                cmbThithi.Visible = false;
                cmbThithi.Enabled = false;
                lblMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Enabled = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                lblMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Enabled = false;
            }

            else if (selectedDateType.Name == "Special")
            {
                lblSpecialDay.Visible = true;
                cmbSpecialDay.Visible = true;
                cmbSpecialDay.Enabled = true;
                lblEnglishDatetype.Visible = false;
                dtpEnglishDateType.Visible = false;
                dtpEnglishDateType.Enabled = false;
                dtpEnglishDateType.CustomFormat = "";
                lblMonth.Visible = false;
                cmbMonth.Visible = false;
                cmbMonth.Enabled = false;
                lblThithi.Visible = false;
                cmbThithi.Visible = false;
                cmbThithi.Enabled = false;
                lblMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Enabled = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                lblMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Enabled = false;

                #region Bind SpecialDay values
                var bindSpecialDay = specialDayRepo.GetAllAsQuerable();
                cmbSpecialDay.DataSource = bindSpecialDay;
                cmbSpecialDay.DisplayMember = "Name";
                #endregion
            }
            else if (selectedDateType.Name == "Select")
            {
                lblSpecialDay.Visible = false;
                cmbSpecialDay.Visible = false;
                cmbSpecialDay.Enabled = false;
                lblEnglishDatetype.Visible = false;
                dtpEnglishDateType.Visible = false;
                dtpEnglishDateType.Enabled = false;
                dtpEnglishDateType.CustomFormat = "";
                lblMonth.Visible = false;
                cmbMonth.Visible = false;
                cmbMonth.Enabled = false;
                lblThithi.Visible = false;
                cmbThithi.Visible = false;
                cmbThithi.Enabled = false;
                lblMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Visible = false;
                cmbMonthlyAnna.Enabled = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                rbdEnglish.Checked = false;
                rbdTelugu.Checked = false;
                lblMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Visible = false;
                cmbMonthyAnnaThithi.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnModify.Visible = false;
            using (ModifyPopup formOptions = new ModifyPopup())
            {
                // passing this in ShowDialog will set the .Owner 
                // property of the child form
                formOptions.ShowDialog(this);
                formOptions.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool checkvalidate = validation();
            if (checkvalidate == false)
                return;
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnModify.Visible = false;

            DateTime donorDate;
            string performDate = string.Empty;
            string transactionDate = string.Empty;

            donorDate = Convert.ToDateTime(dtpDate.Text);

            if (dtpEnglishDateType.Enabled == true)
                performDate = dtpEnglishDateType.Value.ToString("dd-MM");
            else
                performDate = "";


            int selectedServiceTypeId;
            int selectedServiceNameId;
            int selectedMonthId;
            int selectedStarId;
            int selectedSpecialDayId;
            int selectedThithiId;
            int selectedDayId;
            int selectedDonorThithi;
            int selectedTransactionTypeId;
            var selectedDateTypeId = SelectedDateTypeId(out selectedServiceTypeId, out selectedServiceNameId, out selectedMonthId, out selectedStarId, out selectedSpecialDayId, out selectedThithiId, out selectedDayId, out selectedDonorThithi, out selectedTransactionTypeId);

            if (cmbServiceName.Enabled == false)
                selectedServiceNameId = 0;

            if (cmbMonth.Enabled == false)
                selectedMonthId = 0;

            if (cmbSpecialDay.Enabled == false)
                selectedSpecialDayId = 0;

            if (cmbThithi.Enabled == false)
                selectedThithiId = 0;

            if (cmbMonthlyAnna.Enabled == false)
                selectedDayId = 0;

            if (cmbMonthyAnnaThithi.Enabled == false)
                selectedDonorThithi = 0;

            if (cmbTransaction.Enabled == false)
                selectedTransactionTypeId = 0;

            var nameonprefix = cmbNameOnPrefix.SelectedItem as Prefixes;
            var nameprefix = cmbNamePrefix.SelectedItem as Prefixes;

            Donors donorUpdateInfo = new Donors
            {
                Id = txtDonorId.Text,
                Donordate = donorDate,
                Prefix_Name = nameprefix.Id,
                Prefix_NameOn=nameonprefix.Id,
                DonorName = txtName.Text,
                DistrictName = txtDistrict.Text,
                City = txtCity.Text,
                Pin = txtPin.Text,
                State = txtState.Text,
                NameOn = txtNameOn.Text,
                Star = selectedStarId,
                MR_No = txtMRNo.Text,
                TransactionTypeId = selectedTransactionTypeId,
                TransactionId = txtTransaction.Text,
                TransactionDate = transactionDate,
                Occasion = txtPurpose.Text,
                Gothram = txtGothram.Text,
                Amount = Convert.ToDecimal(txtAmount.Text),
                Landline = txtLandline.Text,
                SpecialDayId = selectedSpecialDayId,
                ServiceTypeId = selectedServiceTypeId,
                ServiceNameId = selectedServiceNameId,
                DateTypeId = selectedDateTypeId,
                DoorNo = txtDoorNo.Text,
                Mandal = txtMandal.Text,
                PerformDate = performDate,
                EmailId = txtEmailId.Text,
                DonorMonth = selectedMonthId,
                Thidhi = selectedThithiId,
                DonorDay = selectedDayId,
                Mobile = txtMobile.Text,
                DonorThithi = selectedDonorThithi,
                ModifiedBy = ApplicationElements.loggedInEmployee.Id,
                ModifiedDate = donorDate
            };

            string updateStatus = donorRepo.updateDonorInformation(donorUpdateInfo);

            if (updateStatus == "Success")
            {
                MessageBox.Show("Data updated successfully.");
                CleareAllcontrolsRecursive();
                btnAdd.Visible = true;
                btnModify.Visible = true;
            }
            else
                MessageBox.Show("There was a problem in updating your data, kindly try again.");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
            btnModify.Visible = true;

            CleareAllcontrolsRecursive();
            CleareAllcontrolsRecursive();
            CleareAllcontrolsRecursive();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void getDataFromChildWindow(Donors donor)
        {
            if (donor != null)
            {
                DateTime dt;

                if (!DateTime.TryParse(donor.Donordate.ToString(), out dt))
                {
                    dtpDate.Value = dt;
                }

                txtDonorId.Text = donor.Id;
                txtMRNo.Text = donor.MR_No;

                txtName.Text = donor.DonorName;
                txtDistrict.Text = donor.DistrictName;
                txtCity.Text = donor.City;
                txtPin.Text = donor.Pin;
                txtState.Text = donor.State;
                txtPurpose.Text = donor.Occasion;

                txtNameOn.Text = donor.NameOn;
               // txtNameOn.Enabled = false;
                txtName.Text = donor.DonorName;
               // txtName.Enabled = false;

               // cmbNameOnPrefix.Enabled = false;
              //  cmbNamePrefix.Enabled = false;

                //Get Star Info
                var bindStarName = starRepo.GetAllAsQuerable(donor.Star);
                string[] starNameValue = bindStarName.Select(p => p.Name).ToArray();
                cmbStar.SelectedIndex = cmbStar.FindString(starNameValue[0]);

                var bindprefixName = prefixesRepo.GetAllAsQuerable(donor.Prefix_Name);
                string[] PrefixName = bindprefixName.Select(p => p.Name).ToArray();
                cmbNamePrefix.SelectedIndex = cmbNamePrefix.FindString(PrefixName[0]);

                var bindprefixNameOn = prefixesRepo.GetAllAsQuerable(donor.Prefix_NameOn);
                string[] PrefixNameOn = bindprefixNameOn.Select(p => p.Name).ToArray();
                cmbNameOnPrefix.SelectedIndex = cmbNameOnPrefix.FindString(PrefixNameOn[0]);

                txtAmount.Text = donor.Amount.ToString();
                txtAmount.Enabled = false;

                txtPurpose.Text = donor.Occasion;
                txtGothram.Text = donor.Gothram;

                txtLandline.Text = donor.Landline;
                txtMobile.Text = donor.Mobile;
                txtEmailId.Text = donor.EmailId;

                //Get ServiceType
                var bindServiceType = serviceTypeRepo.GetAllAsQuerable(donor.ServiceTypeId);
                string[] starTypeValue = bindServiceType.Select(p => p.Name).ToArray();
                cmbServiceType.SelectedIndex = cmbServiceType.FindString(starTypeValue[0]);

                //Get Transaction
                if (cmbTransaction.Enabled == true)
                {
                    var bindTransactionName = transTypeRepo.GetAllAsQuerable(donor.TransactionTypeId);
                    string[] transNameValue = bindTransactionName.Select(p => p.Name).ToArray();
                    cmbTransaction.SelectedIndex = cmbTransaction.FindString(transNameValue[0]);

                    if (cmbTransaction.Text == "Credit/Debit Card")
                    {
                        txtTransaction.Text = donor.TransactionId;
                    }
                    if (cmbTransaction.Text == "DD")
                    {
                        txtTransaction.Text = donor.TransactionId;

                        if (donor.TransactionDate != null)
                        {
                            var transDate = donor.TransactionDate.ToString();
                            var perforDateArr = transDate.Split('-');
                            DateTime dt1 = new DateTime();
                            int date;
                            int month;
                            int year;
                            if (perforDateArr.Length > 0)
                            {
                                var performDateWithoutMonthAndYear = int.TryParse(perforDateArr[0], out date);
                                var performDayWithoutYearAbdDate = int.TryParse(perforDateArr[1], out month);
                                year = DateTime.Now.Year;
                                dt1 = new DateTime(year, month, date);
                            }

                            cmbTransactionDate.Value = dt1;
                        }
                        else
                        {
                            cmbTransactionDate.Visible = false;
                            cmbTransactionDate.Enabled = false;
                        }
                    }
                    if (cmbTransaction.Text == "Cheque")
                    {
                        txtTransaction.Text = donor.TransactionId;
                        if (donor.TransactionDate != null)
                        {
                            var transDate = donor.TransactionDate.ToString();
                            var perforDateArr = transDate.Split('-');
                            DateTime dt1 = new DateTime();
                            int date;
                            int month;
                            int year;
                            if (perforDateArr.Length > 0)
                            {
                                var performDateWithoutMonthAndYear = int.TryParse(perforDateArr[0], out date);
                                var performDayWithoutYearAbdDate = int.TryParse(perforDateArr[1], out month);
                                year = DateTime.Now.Year;
                                dt1 = new DateTime(year, month, date);
                            }

                            cmbTransactionDate.Value = dt1;
                        }
                        else
                        {
                            cmbTransactionDate.Visible = false;
                            cmbTransactionDate.Enabled = false;
                        }
                    }
                }

                //Get ServiceName
                if (cmbServiceName.Enabled == true)
                {
                    var bindServiceName = serviceNameRepo.GetAllAsQuerable(donor.ServiceNameId);
                    string[] serviceNameValue = bindServiceName.Select(p => p.Name).ToArray();
                    cmbServiceName.SelectedIndex = cmbServiceName.FindString(serviceNameValue[0]);
                }

                //Get DateType
                if (cmbDateType.Enabled == true)
                {
                    var bindDatetype = datetypeRepo.GetAllAsQuerable(donor.DateTypeId);
                    string[] dateTypeValue = bindDatetype.Select(p => p.Name).ToArray();
                    cmbDateType.SelectedIndex = cmbDateType.FindString(dateTypeValue[0]);
                }

                //Get SpecialDay
                if (cmbSpecialDay.Enabled == true)
                {
                    var bindSpecialDay = specialDayRepo.GetAllAsQuerable(donor.SpecialDayId);
                    string[] specialDayValue = bindSpecialDay.Select(p => p.Name).ToArray();
                    cmbSpecialDay.SelectedIndex = cmbSpecialDay.FindString(specialDayValue[0]);
                }

                //Get Month
                if (cmbMonth.Enabled == true)
                {
                    var bindMonth = monthsRepo.GetAllAsQuerable(donor.DonorMonth);
                    string[] monthValue = bindMonth.Select(p => p.Name).ToArray();
                    cmbMonth.SelectedIndex = cmbMonth.FindString(monthValue[0]);
                }

                //Get Thithi
                if (cmbThithi.Enabled == true)
                {
                    var bindThithi = thithiRepo.GetAllAsQuerable(donor.Thidhi);
                    string[] thithiValue = bindThithi.Select(p => p.Name).ToArray();
                    cmbThithi.SelectedIndex = cmbThithi.FindString(thithiValue[0]);
                }

                //Perform Date

                if (donor.PerformDate != null)
                {
                    var performDate = donor.PerformDate.ToString();
                    var perforDateArr = performDate.Split('-');
                    DateTime dt1 = new DateTime();
                    int date;
                    int month;
                    int year;
                    if (perforDateArr.Length > 0)
                    {
                        var performDateWithoutMonthAndYear = int.TryParse(perforDateArr[0], out date);
                        var performDayWithoutYearAbdDate = int.TryParse(perforDateArr[1], out month);
                        year = DateTime.Now.Year;
                        dt1 = new DateTime(year, month, date);
                    }

                    dtpEnglishDateType.Value = dt1;
                }
                else
                {
                    dtpEnglishDateType.Visible = false;
                    dtpEnglishDateType.Enabled = false;
                }

                //Monthly AnnaDanam

                if (donor.DonorDay != 0)
                {
                    rbdEnglish.Visible = true;
                    rbdTelugu.Visible = true;
                    rbdEnglish.Checked = true;
                    var bindDonorDay = monthlyAnnaRepo.GetAllAsQuerable(donor.DonorDay);
                    string[] donorDayValue = bindDonorDay.Select(p => p.Day).ToArray();
                    cmbMonthlyAnna.SelectedIndex = cmbMonthlyAnna.FindString(donorDayValue[0]);
                }

                else if (donor.DonorThithi != 0)
                {
                    rbdEnglish.Visible = true;
                    rbdTelugu.Visible = true;
                    rbdTelugu.Checked = true;
                    var bindDonorThithi = thithiRepo.GetAllAsQuerable(donor.DonorThithi);
                    string[] donorthithiValue = bindDonorThithi.Select(p => p.Name).ToArray();
                    cmbMonthyAnnaThithi.SelectedIndex = cmbMonthyAnnaThithi.FindString(donorthithiValue[0]);
                }
            }
        }

        public void getDataFromChildWindow(int value)
        {
            if (value == 0)
            {
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnAdd.Visible = true;
                btnModify.Visible = true;
            }
        }

        public bool validation()
        {
            bool needValidate = true;
            var servicetypeId = cmbServiceType.SelectedItem as ServiceTypes;

            if (dtpDate.Text == "" || dtpDate.Text == string.Empty)
            {
                errorProvider1.SetError(dtpDate, "Need to select Date to continue");
                needValidate = false;
                return needValidate;
            }
            else
                errorProvider1.Clear();

            //if (txtAddress.Text == "" || txtAddress.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtAddress, "Need to enter Address");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtSurname.Text == "" || txtSurname.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtSurname, "Need to enter Surname");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtName.Text == "" || txtName.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtName, "Need to enter Name");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtDistrict.Text == "" || txtDistrict.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtDistrict, "Need to enter District");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtCity.Text == "" || txtCity.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtCity, "Need to enter City");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtPin.Text == "" || txtPin.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtPin, "Need to enter PIN Code");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtState.Text == "" || txtState.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtState, "Need to enter State");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtCountry.Text == "" || txtCountry.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtCountry, "Need to enter Country");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            if (txtNameOn.Text == "" || txtNameOn.Text == string.Empty)
            {
                errorProvider1.SetError(txtNameOn, "Need to have Name On");
                needValidate = false;
                return needValidate;
            }
            else
                errorProvider1.Clear();
            if (cmbStar.Text == "" || cmbStar.Text == string.Empty)
            {
                errorProvider1.SetError(cmbStar, "Need to Select Star");
                needValidate = false;
                return needValidate;
            }
            else
                errorProvider1.Clear();

            var transactionType = cmbTransaction.SelectedItem as TransactionType;

            if (transactionType.Id == 2 || transactionType.Id == 3)
            {
                if (txtTransaction.Text == "" || txtTransaction.Text == string.Empty)
                {
                    errorProvider1.SetError(txtTransaction, "Need to enter the details");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            //if (txtOccassion.Text == "" || txtOccassion.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtOccassion, "Need to enter Occassion");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtGothram.Text == "" || txtGothram.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtGothram, "Need to enter Gothram");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();

            //else if ((servicetypeId.Id == 1) && (Convert.ToInt32(txtAmount.Text) < 1116))
            //{
            //    errorProvider1.SetError(txtAmount, "Amount cannot be less than Rs.1,116 for selected service type");
            //    needValidate = false;
            //    return needValidate;
            //}

            //else
            //    errorProvider1.Clear();
            //if (txtMRNo.Text == "" || txtMRNo.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtMRNo, "Need to enter the MR Number");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtRemarks.Text == "" || txtRemarks.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtRemarks, "Need to enter the Remarks");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtLandline.Text == "" || txtLandline.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtLandline, "Need to enter Landline Number");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtMobile.Text == "" || txtMobile.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtMobile, "Need to enter Mobile Number");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            //if (txtEmailId.Text == "" || txtEmailId.Text == string.Empty)
            //{
            //    errorProvider1.SetError(txtEmailId, "Need to enter Email ID");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();
            if (txtAmount.Text == "" || txtAmount.Text == string.Empty)
            {
                errorProvider1.SetError(txtAmount, "Need to enter the Amount");
                needValidate = false;
                return needValidate;
            }
            else if ((servicetypeId.Id == 1) && (Convert.ToDouble(txtAmount.Text) < 1116))
            {
                errorProvider1.SetError(txtAmount, "Amount cannot be less than Rs.1,116 for selected service type");
                needValidate = false;
                return needValidate;
            }

            else
                errorProvider1.Clear();
            if (cmbServiceType.Text == "Select" || cmbServiceType.Text == string.Empty)
            {
                errorProvider1.SetError(cmbServiceType, "Need to select Service Type");
                needValidate = false;
                return needValidate;
            }
            else
                errorProvider1.Clear();
            //if (cmbServiceName.Text == "" || cmbServiceName.Text == string.Empty)
            //{
            //    errorProvider1.SetError(cmbServiceName, "Need to select Service Name");
            //    needValidate = false;
            //    return needValidate;
            //}
            //else
            //    errorProvider1.Clear();

            if (cmbDateType.Enabled == true)
            {
                if (cmbDateType.Text == "Select" || cmbDateType.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbDateType, "Need to select Date Type");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            if (cmbSpecialDay.Enabled == true)
            {
                if (cmbSpecialDay.Text == "Select" || cmbSpecialDay.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbSpecialDay, "Need to select Special Day");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            if (cmbMonth.Enabled == true)
            {
                if (cmbMonth.Text == "Select" || cmbMonth.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbMonth, "Need to select Month");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            if (cmbThithi.Enabled == true)
            {
                if (cmbThithi.Text == "Select" || cmbThithi.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbThithi, "Need to select Thithi");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            if (cmbMonthlyAnna.Enabled == true)
            {
                if (cmbMonthlyAnna.Text == "Select" || cmbMonthlyAnna.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbMonthlyAnna, "Need to select Thithi");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            if (cmbMonthyAnnaThithi.Enabled == true)
            {
                if (cmbMonthyAnnaThithi.Text == "Select" || cmbMonthyAnnaThithi.Text == string.Empty)
                {
                    errorProvider1.SetError(cmbMonthyAnnaThithi, "Need to select Thithi");
                    needValidate = false;
                    return needValidate;
                }
                else
                    errorProvider1.Clear();
            }

            return needValidate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblServiceName.Enabled = false;
            cmbServiceName.Enabled = false;

            var serviceType = cmbServiceType.SelectedItem as ServiceTypes;
            if (serviceType != null)
            {
                if (serviceType.Cost != 0)
                {
                    txtAmount.Text = serviceType.Cost.ToString();
                    //txtAmount.Enabled = false;
                }
                //else
                //{
                //    txtAmount.Text = string.Empty;
                //    //txtAmount.Enabled = true;
                //}
                cmbServiceName.DataSource = null;

                var ServiceTypeData = serviceNameRepo.GetAllAsQuerable().Where(sType => sType.ServiceTypeId == serviceType.Id).ToList();
                cmbServiceName.DataSource = ServiceTypeData;
                cmbServiceName.DisplayMember = "Name";
                if (ServiceTypeData.Count > 0)
                {
                    lblServiceName.Enabled = true;
                    cmbServiceName.Enabled = true;

                    var serviceName = cmbServiceName.SelectedItem as ServiceName;

                    if (serviceName.IsDateRelated == 1)
                    {
                        lblDateType.Visible = true;
                        cmbDateType.Visible = true;
                        cmbDateType.Enabled = true;
                        lblSpecialDay.Visible = false;
                        cmbSpecialDay.Visible = false;
                        cmbSpecialDay.Enabled = false;
                        lblEnglishDatetype.Visible = false;
                        dtpEnglishDateType.Visible = false;
                        dtpEnglishDateType.Enabled = false;
                        dtpEnglishDateType.CustomFormat = "";
                        lblMonth.Visible = false;
                        cmbMonth.Visible = false;
                        cmbMonth.Enabled = false;
                        lblThithi.Visible = false;
                        cmbThithi.Visible = false;
                        cmbThithi.Enabled = false;
                        lblMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Enabled = false;

                        lblMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Enabled = false;
                        lblMonthyAnnaThithi.Visible = false;
                        cmbMonthyAnnaThithi.Visible = false;
                        cmbMonthyAnnaThithi.Enabled = false;
                        rbdEnglish.Visible = false;
                        rbdTelugu.Visible = false;
                    }
                    else
                    {
                        lblDateType.Visible = false;
                        cmbDateType.Visible = false;
                        cmbDateType.Enabled = false;
                        lblSpecialDay.Visible = false;
                        cmbSpecialDay.Visible = false;
                        cmbSpecialDay.Enabled = false;
                        lblEnglishDatetype.Visible = false;
                        dtpEnglishDateType.Visible = false;
                        dtpEnglishDateType.Enabled = false;
                        dtpEnglishDateType.CustomFormat = "";
                        lblMonth.Visible = false;
                        cmbMonth.Visible = false;
                        cmbMonth.Enabled = false;
                        lblThithi.Visible = false;
                        cmbThithi.Visible = false;
                        cmbThithi.Enabled = false;
                        lblMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Enabled = false;
                        lblMonthlyAnna.Visible = false;
                        cmbMonthlyAnna.Visible = false;
                        lblMonthyAnnaThithi.Visible = false;
                        cmbMonthyAnnaThithi.Visible = false;
                        cmbMonthyAnnaThithi.Enabled = false;
                        rbdEnglish.Visible = false;
                        rbdTelugu.Visible = false;
                    }

                }
                else if (serviceType.IsDateRelated == 1)
                {
                    lblDateType.Visible = true;
                    cmbDateType.Visible = true;
                    cmbDateType.Enabled = true;
                    lblSpecialDay.Visible = false;
                    cmbSpecialDay.Visible = false;
                    cmbSpecialDay.Enabled = false;
                    lblEnglishDatetype.Visible = false;
                    dtpEnglishDateType.Visible = false;
                    dtpEnglishDateType.Enabled = false;
                    dtpEnglishDateType.CustomFormat = "";
                    lblMonth.Visible = false;
                    cmbMonth.Visible = false;
                    cmbMonth.Enabled = false;
                    lblThithi.Visible = false;
                    cmbThithi.Visible = false;
                    cmbThithi.Enabled = false;
                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Enabled = false;

                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Enabled = false;
                    lblMonthyAnnaThithi.Visible = false;
                    cmbMonthyAnnaThithi.Visible = false;
                    cmbMonthyAnnaThithi.Enabled = false;
                    rbdEnglish.Visible = false;
                    rbdTelugu.Visible = false;
                }
                else
                {
                    lblDateType.Visible = false;
                    cmbDateType.Visible = false;
                    cmbDateType.Enabled = false;
                    lblSpecialDay.Visible = false;
                    cmbSpecialDay.Visible = false;
                    cmbSpecialDay.Enabled = false;
                    lblEnglishDatetype.Visible = false;
                    dtpEnglishDateType.Visible = false;
                    dtpEnglishDateType.Enabled = false;
                    dtpEnglishDateType.CustomFormat = "";
                    lblMonth.Visible = false;
                    cmbMonth.Visible = false;
                    cmbMonth.Enabled = false;
                    lblThithi.Visible = false;
                    cmbThithi.Visible = false;
                    cmbThithi.Enabled = false;

                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Enabled = false;
                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    lblMonthyAnnaThithi.Visible = false;
                    cmbMonthyAnnaThithi.Visible = false;
                    cmbMonthyAnnaThithi.Enabled = false;
                    rbdEnglish.Visible = false;
                    rbdTelugu.Visible = false;
                }
            }
            if (serviceType.Name == "Monthly Annadanam")
            {
                #region Show Hide Controls
                lblDateType.Visible = false;
                cmbDateType.Visible = false;
                cmbDateType.Enabled = false;
                lblSpecialDay.Visible = false;
                cmbSpecialDay.Visible = false;
                cmbSpecialDay.Enabled = false;
                lblEnglishDatetype.Visible = false;
                dtpEnglishDateType.Visible = false;
                dtpEnglishDateType.Enabled = false;
                dtpEnglishDateType.CustomFormat = "";
                lblMonth.Visible = false;
                cmbMonth.Visible = false;
                cmbMonth.Enabled = false;
                lblThithi.Visible = false;
                cmbThithi.Visible = false;
                cmbThithi.Enabled = false;
                lblServiceName.Enabled = false;
                cmbServiceName.Enabled = false;
                cmbServiceName.Enabled = false;
                lblMonthlyAnna.Visible = true;
                cmbMonthlyAnna.Visible = true;
                cmbMonthlyAnna.Enabled = true;
                #endregion

                rbdEnglish.Visible = true;
                rbdTelugu.Visible = true;
                rbdEnglish.Checked = true;

            }
            //else
            //
            //    lblDateType.Visible = true;
            //    cmbDateType.Visible = true;
            //    lblMonthlyAnna.Visible = false;
            //    cmbMonthlyAnna.Visible = false;
            //    lblServiceName.Enabled = true;
            //    cmbServiceName.Enabled = true;
            //}
        }


        public void CleareAllcontrolsRecursive()
        {
            cmbNamePrefix.Visible = true;
            cmbNameOnPrefix.Visible = true;
            txtName.Enabled = true;
            txtNameOn.Enabled = true;
            txtAmount.Enabled = true;
            txtName.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPin.Text = string.Empty;
            txtState.Text = string.Empty;

            txtNameOn.Text = string.Empty;

            txtPurpose.Text = string.Empty;
            txtGothram.Text = string.Empty;

            txtLandline.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            txtTransaction.Text = string.Empty;
            bindData();
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            dtpEnglishDateType.CustomFormat = "";
            lblSpecialDay.Visible = false;
            cmbSpecialDay.Visible = false;
            lblMonth.Visible = false;
            cmbMonth.Visible = false;
            lblThithi.Visible = false;
            cmbThithi.Visible = false;
            lblMonthlyAnna.Visible = false;
            cmbMonthlyAnna.Visible = false;
            txtAmount.Text = string.Empty;
            lblMonthyAnnaThithi.Visible = false;
            cmbMonthyAnnaThithi.Visible = false;

            rbdEnglish.Visible = false;
            rbdTelugu.Visible = false;
            txtDoorNo.Text = string.Empty;
            txtMandal.Text = string.Empty;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuickDailyAnna_Click(object sender, EventArgs e)
        {
            using (DailyAnnadanam formOptions = new DailyAnnadanam())
            {
                // passing this in ShowDialog will set the .Owner 
                // property of the child form
                formOptions.ShowDialog(this);
                formOptions.Dispose();
                //Added the below to load any gothrams added in Daily Annadanam.
                loadGothramAutoComplete();
            }
        }

        private void DonationInformation_Load(object sender, EventArgs e)
        {
            loadGothramAutoComplete();
            loadStateAutoComplete();
            loadCityVillageAutoComplete();
            loadMandalAutoComplete();
            loadDistrictAutoComplete();
            loadPurposeAutoComplete();

            rbdEnglish.Visible = false;
            rbdTelugu.Visible = false;
        }

        private void loadGothramAutoComplete()
        {
            lstGothrams = gothramRepo.GetAllAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (Gothrams gothram in lstGothrams)
            {
                strcoll.Add(gothram.Name);
            }
            txtGothram.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtGothram.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtGothram.AutoCompleteCustomSource = strcoll;
        }

        private void loadCityVillageAutoComplete()
        {
            lstCityVillage = donorRepo.GetCityVillageAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (Donors ocityVillage in lstCityVillage)
            {
                if (ocityVillage.City != null)
                    strcoll.Add(ocityVillage.City);
            }
            txtCity.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtCity.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtCity.AutoCompleteCustomSource = strcoll;
        }

        private void loadPurposeAutoComplete()
        {
            lstPurpose = donorRepo.GetPurposeAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (Donors oPurpose in lstPurpose)
            {
                if (oPurpose.Occasion != null)
                    strcoll.Add(oPurpose.Occasion);
            }
            txtPurpose.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPurpose.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPurpose.AutoCompleteCustomSource = strcoll;
        }

        private void loadMandalAutoComplete()
        {
            lstMandal = donorRepo.GetMandalAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (Donors oMandal in lstMandal)
            {
                if (oMandal.Mandal != null)
                    strcoll.Add(oMandal.Mandal);
            }
            txtMandal.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMandal.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtMandal.AutoCompleteCustomSource = strcoll;
        }

        private void loadDistrictAutoComplete()
        {
            lstDistrict = donorRepo.GetDistrictAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (Donors oDistrict in lstDistrict)
            {
                if (oDistrict.DistrictName != null)
                    strcoll.Add(oDistrict.DistrictName);
            }
            txtDistrict.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtDistrict.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtDistrict.AutoCompleteCustomSource = strcoll;
        }

        private void loadStateAutoComplete()
        {
            lstStates = stateRepo.GetAllAsQuerable().ToList();
            AutoCompleteStringCollection strcoll = new AutoCompleteStringCollection();
            foreach (State ostate in lstStates)
            {
                strcoll.Add(ostate.Name);
            }
            txtState.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtState.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtState.AutoCompleteCustomSource = strcoll;
        }



        private void cmbServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serviceName = cmbServiceName.SelectedItem as ServiceName;

            if (serviceName != null)
            {
                if (serviceName.IsDateRelated == 1)
                {
                    lblDateType.Visible = true;
                    cmbDateType.Visible = true;
                    cmbDateType.Enabled = true;
                    lblSpecialDay.Visible = false;
                    cmbSpecialDay.Visible = false;
                    cmbSpecialDay.Enabled = false;
                    lblEnglishDatetype.Visible = false;
                    dtpEnglishDateType.Visible = false;
                    dtpEnglishDateType.Enabled = false;
                    lblMonth.Visible = false;
                    cmbMonth.Visible = false;
                    cmbMonth.Enabled = false;
                    lblThithi.Visible = false;
                    cmbThithi.Visible = false;
                    cmbThithi.Enabled = false;
                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Enabled = false;
                }
                else
                {
                    lblDateType.Visible = false;
                    cmbDateType.Visible = false;
                    cmbDateType.Enabled = false;
                    lblSpecialDay.Visible = false;
                    cmbSpecialDay.Visible = false;
                    cmbSpecialDay.Enabled = false;
                    lblEnglishDatetype.Visible = false;
                    dtpEnglishDateType.Visible = false;
                    dtpEnglishDateType.Enabled = false;
                    lblMonth.Visible = false;
                    cmbMonth.Visible = false;
                    cmbMonth.Enabled = false;
                    lblThithi.Visible = false;
                    cmbThithi.Visible = false;
                    cmbThithi.Enabled = false;
                    lblMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Visible = false;
                    cmbMonthlyAnna.Enabled = false;
                }
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void rbdEnglish_CheckedChanged(object sender, EventArgs e)
        {
            lblMonthlyAnna.Visible = true;
            cmbMonthlyAnna.Visible = true;
            cmbMonthlyAnna.Enabled = true;
            lblMonthyAnnaThithi.Visible = false;
            cmbMonthyAnnaThithi.Visible = false;
            cmbMonthyAnnaThithi.Enabled = false;

            #region Bind MonthlyAnna values
            var bindMonthlyAnna = monthlyAnnaRepo.GetAllAsQuerable();
            cmbMonthlyAnna.DataSource = bindMonthlyAnna;
            cmbMonthlyAnna.DisplayMember = "Day";
            #endregion
        }

        private void rbdTelugu_CheckedChanged(object sender, EventArgs e)
        {
            lblMonthlyAnna.Visible = false;
            cmbMonthlyAnna.Visible = false;
            cmbMonthlyAnna.Enabled = false;
            lblMonthyAnnaThithi.Visible = true;
            cmbMonthyAnnaThithi.Visible = true;
            cmbMonthyAnnaThithi.Enabled = true;

            #region Thithi
            var bindThithi = thithiRepo.GetAllAsQuerable();
            cmbMonthyAnnaThithi.DataSource = bindThithi;
            cmbMonthyAnnaThithi.DisplayMember = "Name";
            #endregion
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBindDataFromPhone_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                var donorExists = donorRepo.fetchDataFromMobileNumber(txtMobile.Text);
                if (donorExists != null)
                {
                    txtName.Text = donorExists.DonorName;
                    txtDistrict.Text = donorExists.DistrictName;
                    txtCity.Text = donorExists.City;
                    txtPin.Text = donorExists.Pin;
                    txtState.Text = donorExists.State;
                    txtDoorNo.Text = donorExists.DoorNo;
                    txtMandal.Text = donorExists.Mandal;
                    txtNameOn.Text = donorExists.NameOn;

                    var bindprefixName = prefixesRepo.GetAllAsQuerable(donorExists.Prefix_Name);
                    string[] PrefixName = bindprefixName.Select(p => p.Name).ToArray();
                    cmbNamePrefix.SelectedIndex = cmbNamePrefix.FindString(PrefixName[0]);

                    var bindprefixNameOn = prefixesRepo.GetAllAsQuerable(donorExists.Prefix_NameOn);
                    string[] PrefixNameOn = bindprefixNameOn.Select(p => p.Name).ToArray();
                    cmbNameOnPrefix.SelectedIndex = cmbNameOnPrefix.FindString(PrefixNameOn[0]);

                    //Get Star Info
                    var bindStarName = starRepo.GetAllAsQuerable(donorExists.Star);
                    string[] starNameValue = bindStarName.Select(p => p.Name).ToArray();
                    cmbStar.SelectedIndex = cmbStar.FindString(starNameValue[0]);

                    txtPurpose.Text = donorExists.Occasion;
                    txtGothram.Text = donorExists.Gothram;

                    txtLandline.Text = donorExists.Landline;
                    txtMobile.Text = donorExists.Mobile;
                    txtEmailId.Text = donorExists.EmailId;
                }
            }
            else
                MessageBox.Show("No data found for the provided mobile number");
        }

        private void cmbTransaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            var transactionType = cmbTransaction.SelectedItem as TransactionType;

            if (transactionType.Name == "Cash")
            {
                lblNumberBank.Visible = false;
                lblTransactionID.Visible = false;
                txtTransaction.Visible = false;
                txtTransaction.Enabled = false;
                lblTransactionDate.Visible = false;
                cmbTransactionDate.Visible = false;
                cmbTransaction.Enabled = true;
                txtTransaction.Text = "";
            }
            else if (transactionType.Name == "Credit/Debit Card")
            {
                lblNumberBank.Visible = false;
                lblTransactionID.Visible = true;
                txtTransaction.Enabled = true;
                txtTransaction.Visible = true;
                lblTransactionDate.Visible = false;
                cmbTransactionDate.Visible = false;
                cmbTransaction.Enabled = true;
                txtTransaction.Text = "";
            }
            else if (transactionType.Name == "DD")
            {
                lblNumberBank.Visible = true;
                lblTransactionID.Visible = false;
                txtTransaction.Enabled = true;
                txtTransaction.Visible = true;
                lblTransactionDate.Visible = true;
                cmbTransactionDate.Visible = true;
                cmbTransaction.Enabled = true;
                txtTransaction.Text = "";
            }
            else if (transactionType.Name == "Cheque")
            {
                lblNumberBank.Visible = true;
                lblTransactionID.Visible = false;
                txtTransaction.Enabled = true;
                txtTransaction.Visible = true;
                lblTransactionDate.Visible = true;
                cmbTransactionDate.Visible = true;
                cmbTransaction.Enabled = true;
                txtTransaction.Text = "";
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {

            Donors oDonorLastRec = donorRepo.GetLastRecordbyOperator(ApplicationElements.loggedInEmployee.Id);
            if (oDonorLastRec != null)
            {
                string performDate_ForPrint = string.Empty;
                //Get Star Info
                var bindStarName = starRepo.GetAllAsQuerable(oDonorLastRec.Star);
                string[] starNameValue = bindStarName.Select(p => p.Name).ToArray();

                //Get serviceName Info
                var bindServiceType = serviceTypeRepo.GetAllAsQuerable(oDonorLastRec.ServiceTypeId);
                string[] ServceType = bindServiceType.Select(p => p.Name).ToArray();

                switch (oDonorLastRec.DateTypeId)
                {
                    case 1:
                        var bindMonth = monthsRepo.GetAllAsQuerable(oDonorLastRec.DonorMonth);
                        string[] months = bindMonth.Select(p => p.Name).ToArray();

                        var bindThidhi = thithiRepo.GetAllAsQuerable(oDonorLastRec.Thidhi);
                        string[] thidhi = bindThidhi.Select(p => p.Name).ToArray();
                        performDate_ForPrint = months[0] + " " + thidhi[0];
                        break;
                    case 2:
                        performDate_ForPrint = oDonorLastRec.PerformDate;
                        break;
                    case 3:
                        var bindSpecialDay = specialDayRepo.GetAllAsQuerable(oDonorLastRec.SpecialDayId);
                        string[] specialDay = bindSpecialDay.Select(p => p.Name).ToArray();
                        performDate_ForPrint = specialDay[0];
                        break;
                }

                TokenPrint oTokenPrint = new TokenPrint
                {
                    Id = oDonorLastRec.MR_No,
                    Name = oDonorLastRec.DonorName,
                    NameOn = oDonorLastRec.NameOn,
                    PerformDate = performDate_ForPrint,
                    Star = (starNameValue[0] == "Select") ? "" : starNameValue[0],
                    PhoneNumber = oDonorLastRec.Mobile,
                    Gothram = oDonorLastRec.Gothram,
                    VillageName = oDonorLastRec.City,
                    ServiceType = ServceType[0],
                    Cost = Convert.ToDouble(oDonorLastRec.Amount),
                    LoginName = ApplicationElements.loggedInEmployee.LoginId
                };

                PrintHelper oPrintHelper = new PrintHelper();
                lstTokenPrint.Clear();
                lstTokenPrint.Add(oTokenPrint);
                if (printerName == string.Empty || printerName == "")
                {
                    MessageBox.Show("Token cannot be printed.... Please install a printer and select..");
                }
                else
                    oPrintHelper.PrintTokens(lstTokenPrint, this, printerName, Convert.ToBoolean(ConfigurationManager.AppSettings["ShowPrintPreview"]));
            }
            else
                MessageBox.Show("No Data found for this user");
        }
    }
}