using WorkFlowMenagementMDI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Views;
using WorkFlowMenagementMDI.FuelApp.Views.Reports;
using WorkFlowMenagementMDI.FuelApp.Views.StockMovement;
using WorkFlowMenagementMDI.FuelApp.Views.Settings;
using WorkFlowMenagementMDI.Tracking.Views;
using WorkFlowMenagementMDI.Tracking.Views.Customers;
using WorkFlowMenagementMDI.Tracking.Views.Farmers;
using WorkFlowMenagementMDI.Tracking.Views.ReportView;
using WorkFlowMenagementMDI.Tracking.Views.FieldOfficers;
using WorkFlowMenagementMDI.Login;
using WorkFlowMenagementMDI.Tracking.Views.Upload;
using WorkFlowMenagementMDI.FeedIssue.Views;
using WorkFlowMenagementMDI.FeedIssue.ReportView;

namespace WorkFlowMenagementMDI
{
    public partial class WorkFlowMenagement : Form
    {
        public WorkFlowMenagement()
        {
            InitializeComponent();
        }

        string lastUser = Properties.Settings.Default.LastUser;
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Form form in Application.OpenForms)
            //{
            //    if (form.GetType() == typeof(MainMenu))
            //    {
            //        form.Activate();
            //        return;
            //    }
            //}
            //TrackingMainMenu main = new TrackingMainMenu();
            //main.MdiParent = this;
            //main.Show();
            //main.WindowState = FormWindowState.Normal;
        }

        private void fieldVisitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FindLocationFromMap))
                {
                    form.Activate();
                    return;
                }
            }
            FindLocationFromMap Officers = new FindLocationFromMap();
            Officers.MdiParent = this;
            Officers.Show();
        }

        private void customerVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FindLocationsOfCustomers))
                {
                    form.Activate();
                    return;
                }
            }
            FindLocationsOfCustomers cust = new FindLocationsOfCustomers();
            cust.MdiParent = this;
            cust.Show();
        }

        private void farmersOnMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FarmersLocationsDetails))
                {
                    form.Activate();
                    return;
                }
            }
            FarmersLocationsDetails farmers = new FarmersLocationsDetails();
            farmers.MdiParent = this;
            farmers.Show();
        }

        #region Edit of Tracking module
        private void customerLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CustomerCreations))
                {
                    form.Activate();
                    return;
                }
            }
            CustomerCreations customersEdit = new CustomerCreations();
            customersEdit.MdiParent = this;
            customersEdit.Show();
        }

        private void farmerLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FarmerCreationForm))
                {
                    form.Activate();
                    return;
                }
            }
            FarmerCreationForm farmerCreateEdit = new FarmerCreationForm();
            farmerCreateEdit.MdiParent = this;
            farmerCreateEdit.Show();
        }

        private void fieldOfficerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FieldOfficerCreation))
                {
                    form.Activate();
                    return;
                }
            }
            FieldOfficerCreation fieldOfficerEdit = new FieldOfficerCreation();
            fieldOfficerEdit.MdiParent = this;
            fieldOfficerEdit.Show();
        }
        #endregion

        private void farmerVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FarmerReport FoReport = new FarmerReport();
            FoReport.Show();
        }

        private void customerVisitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomerReports cusRep = new CustomerReports();
            cusRep.ShowDialog();
        }

        private void newSchaduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FeedIssueSchedule))
                {
                    form.Activate();
                    return;
                }
            }
            FeedIssueSchedule createSchedule = new FeedIssueSchedule();
            createSchedule.MdiParent = this;
            createSchedule.Show();
        }

        private void viewSchedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FeedIssueScheduleList))
                {
                    form.Activate();
                    return;
                }
            }
            FeedIssueScheduleList listSchedule = new FeedIssueScheduleList();
            listSchedule.MdiParent = this;
            listSchedule.Show();
        }

        private void areaWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSelector reportArea = new ReportSelector();
            reportArea.Show();
        }

        private void areaWiseDateScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportSelectorDateRange reportArea = new ReportSelectorDateRange();
            reportArea.Show();
        }

        private void fuelControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Admin_Controller))
                {
                    form.Activate();
                    return;
                }
            }
            Admin_Controller main = new Admin_Controller();
            main.MdiParent = this;
            main.Show();
        }

        private void fuelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "LoadMain";
            DateSelection report = new DateSelection(id);
            report.Show();
        }

        private void addFuelPhysicalStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWeeklyPhysicalStk weeklyStoc = new SaveWeeklyPhysicalStk();
            weeklyStoc.ShowDialog();
        }

        private void fuelStockMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastUser == "admin")
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(StockMovementForm))
                    {
                        form.Activate();
                        return;
                    }
                }
                StockMovementForm report = new StockMovementForm();
                report.MdiParent = this;
                report.Show();
            }
            else { fuelStockMovementToolStripMenuItem.Enabled = false; }
        }

        private void sMSControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (lastUser == "admin")
            //{
            //    foreach (Form form in Application.OpenForms)
            //    {
            //        if (form.GetType() == typeof(SMS_Sender))
            //        {
            //            form.Activate();
            //            return;
            //        }
            //    }
            //    SMS_Sender sms = new SMS_Sender();
            //    sms.MdiParent = this;
            //    sms.Show();

            //    sms.WindowState = FormWindowState.Normal;
            //}
            //else
            //{ sMSControllerToolStripMenuItem.Enabled = false; }
        }

        private void fuelGeneralReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "LoadMain";
            DateSelection report = new DateSelection(id);
            report.Show();
        }

        private void fuelWeeklyPhysicalStockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "PhycisalLoad";
            DateSelection report = new DateSelection(id);
            report.Show();
        }

        private void fuelStockMovementReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "stockMovement";
            StockMovementReportView report = new StockMovementReportView(id);
            report.Show();
        }

        private void changeWeeklyStockUpdateDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhysicalStockAddOnOff weeklyStoc = new PhysicalStockAddOnOff();
            weeklyStoc.Show();
        }

        private void WorkFlowMenagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
        }

        private void uploadParkingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(UploadExcelParkingDetails))
                {
                    form.Activate();
                    return;
                }
            }
            UploadExcelParkingDetails upload = new UploadExcelParkingDetails();
            upload.MdiParent = this;
            upload.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CustomerTMPView))
                {
                    form.Activate();
                    return;
                }
            }
            CustomerTMPView tmp = new CustomerTMPView();
            tmp.MdiParent = this;
            tmp.Show();
        }
    }
}
