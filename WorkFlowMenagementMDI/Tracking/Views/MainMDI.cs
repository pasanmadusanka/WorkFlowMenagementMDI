using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Views.Customers;
using WorkFlowMenagementMDI.Tracking.Views.Farmers;
using WorkFlowMenagementMDI.Tracking.Views.FieldOfficers;
using WorkFlowMenagementMDI.Tracking.Views.ReportView;

namespace WorkFlowMenagementMDI.Tracking.Views
{
    public partial class MainMDI : Form
    {
        public MainMDI()
        {
            InitializeComponent();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainMenu))
                {
                    form.Activate();
                    return;
                }
            }
            MainMenu main = new MainMenu();
            main.MdiParent = this;
            main.Show();
            main.WindowState = FormWindowState.Normal;
        }

        private void allFarmersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckAllFarmers();
        }

        public void CheckAllFarmers()
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
        public void GetFeildVisits()
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

        private void feildOfficerVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetFeildVisits();
        }

        private void farmerLocationsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void feildOfficersToolStripMenuItem_Click(object sender, EventArgs e)
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
        public void OpenUpload()
        {
            Process.Start("UploadAExcelToDB.exe");
            Properties.Settings.Default.UploadExeStat = "0";
            Properties.Settings.Default.Save();
        }
        public void CloseUpload()
        {
            var procs = Process.GetProcessesByName("UploadAExcelToDB");
            if (procs.Length != 0)
                procs[0].Kill();
            Properties.Settings.Default.UploadExeStat = "1";
            Properties.Settings.Default.Save();
        }
        private void uploadDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.UploadExeStat == "1")
            { OpenUpload(); }
            else
            { CloseUpload(); }
        }

        private void MainMDI_FormClosing(object sender, FormClosingEventArgs e)
        { 
            var procs = Process.GetProcessesByName("UploadAExcelToDB");
            if (procs.Length != 0)
                procs[0].Kill();
            Properties.Settings.Default.UploadExeStat = "1";
            Properties.Settings.Default.Save();
        } 
        private void MainMDI_Load(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainMenu))
                {
                    form.Activate();
                    return;
                }
            }
            MainMenu main = new MainMenu();
            main.MdiParent = this;
            main.Show();
            AdminPrivilages();
        }

        public void AdminPrivilages()
        {
            if (Settings.Default.LastUser.ToLower() == "admin")
            {
                tMPToolStripMenuItem.Visible = true;
            }
        }

        private void customersAndLocationsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void MainMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ConnectionCatalog))
                {
                    form.Activate();
                    return;
                }
            }
            ConnectionCatalog coCat = new ConnectionCatalog();
            coCat.MdiParent = this;
            coCat.Show();
        }

        private void tMPToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void agentsVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(CustomerReports))
                {
                    form.Activate();
                    return;
                }
            }
            CustomerReports cusRep = new CustomerReports();
            cusRep.MdiParent = this;
            cusRep.Show();
            cusRep.WindowState = FormWindowState.Normal;
        }

        private void feildOfficerVisitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FarmerReport))
                {
                    form.Activate();
                    return;
                }
            }
            FarmerReport FoReport = new FarmerReport();
            FoReport.MdiParent = this;
            FoReport.Show();

            FoReport.WindowState = FormWindowState.Normal;
        }
    }
}
