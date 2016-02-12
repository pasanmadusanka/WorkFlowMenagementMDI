using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Methods;
using WorkFlowMenagementMDI.Tracking.Reports;

namespace WorkFlowMenagementMDI.Tracking.Views
{
    public partial class FindLocationFromMap : Form
    {
        GetFarmerVisitation db = new GetFarmerVisitation();
        List<string> LocList = new List<string>();
        string testHeaderLoc = Properties.Resources.LocationsTextHeaderParking;
        string testFooterLoc = Properties.Resources.LocationsTextFooterParkingDriveWay;
        string textLocData = Properties.Resources.LocationsTextParking;

        public FindLocationFromMap()
        {
            InitializeComponent();
        }

        public void GetFarmersDetails()
        {
            DataTable dt1 = db.GetFarmersDetails();
            CMBFieldOfficer.ValueMember = "id";
            CMBFieldOfficer.DisplayMember = "name";
            CMBFieldOfficer.DataSource = dt1;
        }//Gat Feild office Name and id To Combo

        private void FindLocationFromMap_Load(object sender, EventArgs e)
        {
            GetFarmersDetails();//Calling the combobox load
            DTPFromDate.Format = DateTimePickerFormat.Custom;
            DTPFromDate.CustomFormat = "dd/MM/yyyy";
            DTPToDate.Format = DateTimePickerFormat.Custom;
            DTPToDate.CustomFormat = "dd/MM/yyyy";
        }//Loading event

        public void LoadTable()
        {
            DataSet ds = db.FilterVisitationDetails(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBFieldOfficer.SelectedValue));
            dataGridView1.DataSource = ds.Tables["VisitationDetails"].DefaultView;
        }

        private void CMBFieldOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTable();//Table Loaing
            WrightLoactionsToText();//Re make the visit location to text file
            InsertToTEMP();
        }//Combo Box Value change

        public void InsertToTEMP()
        {
            string pc = System.Environment.MachineName.ToString();
            db.WrightVisitsToTemp(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"),
                           Convert.ToInt32(CMBFieldOfficer.SelectedValue), Settings.Default.LastUser, pc);
        }
        private void BtnGetLocations_Click(object sender, EventArgs e)
        {
            //GetDetailsToText();
        }

        public void GetDetailsToText()
        {
            StreamReader srheader = new StreamReader("LocationsTextHeaderParking.txt");
            String header = srheader.ReadToEnd();
            StreamReader sr = new StreamReader("LocationsTextParking.txt");
            String locations = sr.ReadToEnd();
            StreamReader srFooter = new StreamReader("LocationsTextFooterParking.txt");
            String footer = srFooter.ReadToEnd();
            BrowserLocation.DocumentText = @"<script type='text/javascript' src='http://maps.googleapis.com/maps/api/js?sensor=false'></script>
            <script type='text/javascript'> " + header + locations + footer + " </script> <div id='dvMap' style='width: 800px; height: 600px'> </div>";
        }//Load Map To the browser with Flight Rought view.
        public void GetDetailsToText2()
        {
            StreamReader srheader = new StreamReader("LocationsTextHeaderParking.txt");
            String header = srheader.ReadToEnd();
            StreamReader sr = new StreamReader("LocationsTextParking.txt");
            String locations = sr.ReadToEnd();
            StreamReader srFooter = new StreamReader("LocationsTextFooterParkingDriveWay.txt");
            String footer = srFooter.ReadToEnd();
            sr.Close();
            BrowserLocation.DocumentText = header + locations + footer;
            //BrowserLocation.DocumentText = testHeaderLoc + textLocData + testFooterLoc;
        }//Load map to the browser with Driving Rout view;

        public void WrightLoactionsToText()
        {
            try
            {
                File.WriteAllText(textLocData, String.Empty);//Make the file null

                DataTable dt = db.NoOfFarmersVisited(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBFieldOfficer.SelectedValue));
                DataRow ro = dt.Rows[0];
                int farmerCnt = Convert.ToInt32(ro[0]);

                LocList.Clear();

                for (int i = 0; i < farmerCnt; i++)
                {
                    DataTable table = db.VisitationLocations(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBFieldOfficer.SelectedValue));
                    DataRow row = table.Rows[i];
                    LocList.Add("{title:'" + row[0] + " - " + row[2] + "'," + "lat:" + row[3] + ", lng: " + row[4] + ",description:'" + row[0] + " - " + row[2] + " - " + row[5] + "'}" + Environment.NewLine);

                    foreach (string myInt in LocList)
                    { File.WriteAllText(textLocData, string.Join(", ", LocList.ToArray())); }
                }
            }
            catch (Exception ex) { MessageBox.Show("WrightLoactionsToText() " + ex.Message); }
        }//Creating Locations of visits to the LocationsTextParking file.

        private void BtnGetRoad_Click(object sender, EventArgs e)
        {
            GetDetailsToText2();
        }

        private void DTPSetDate_ValueChanged(object sender, EventArgs e)
        {
            LoadTable();
            WrightLoactionsToText();
            InsertToTEMP();
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        {
            ReportViewerFarmer report = new ReportViewerFarmer(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBFieldOfficer.SelectedValue), CMBFieldOfficer.Text);
            report.Show();
        }

        private void DTPToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadTable();
            WrightLoactionsToText();
            InsertToTEMP();
        }

        private void FindLocationFromMap_FormClosing(object sender, FormClosingEventArgs e)
        {
            Views.MainMenu main = new Views.MainMenu();
            main.MdiParent = this.ParentForm;
            main.Show();
            this.Hide();
        }
    }
}
