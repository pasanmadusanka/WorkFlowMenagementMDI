using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Views.Customers;
using WorkFlowMenagementMDI.Tracking.Views.Farmers;
using WorkFlowMenagementMDI.Tracking.Views.Upload;

namespace WorkFlowMenagementMDI.Tracking.Views
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnFarmersLoc_Click(object sender, EventArgs e)
        {
            FarmersLocationsDetails farmer = new FarmersLocationsDetails();
            farmer.MdiParent = this.ParentForm;
            farmer.Show();
            //_mainMDI.CheckAllFarmers();
            this.Hide();
        }

        private void BtnFieldVisits_Click(object sender, EventArgs e)
        {
            FindLocationFromMap fieldOff = new FindLocationFromMap();
            fieldOff.MdiParent = this.ParentForm;
            fieldOff.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UploadExcelParkingDetails upload = new UploadExcelParkingDetails();
            upload.MdiParent = this.ParentForm;
            upload.Show();
            this.Hide();
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
        private void BtnCusAreaRouts_Click(object sender, EventArgs e)
        {
            FindLocationsOfCustomers CusVisits = new FindLocationsOfCustomers();
            CusVisits.MdiParent = this.ParentForm;
            CusVisits.Show();
            this.Hide();
        }
    }
}
