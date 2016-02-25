using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Customers;

namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    public partial class FindLocationsOfCustomers : Form
    {
        FindLocationsOfCustomersMethods db = new FindLocationsOfCustomersMethods();
        List<string> LocList = new List<string>();

        public void LoadCustinfo()
        {
            DataSet ds = db.LoadCustInfoToTab(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CmbDeliveryVehi.SelectedValue), Convert.ToInt32(CMBRep.SelectedValue));
            DgvCust.DataSource = ds.Tables["VisitationDetails"].DefaultView;
        }
        public FindLocationsOfCustomers()
        {
            InitializeComponent();
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        { 
            ReportViewerFarmer report = new ReportViewerFarmer(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"),
                DTPToDate.Value.Date.ToString("dd/MM/yyyy"),CMBRep.Text, CmbDeliveryVehi.Text);
            report.Show();
        }

        public void WrightLoactionsToText()
        {
            try
            {
                File.WriteAllText("LocationsTextParkingCustomers.txt", String.Empty);
                DataTable dt = db.NoOfCustomerVisited(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBRep.SelectedValue), Convert.ToInt32(CmbDeliveryVehi.SelectedValue));
                DataRow ro = dt.Rows[0];
                int farmerCnt = Convert.ToInt32(ro[0]);

                LocList.Clear();

                for (int i = 0; i < farmerCnt; i++)
                {
                    DataTable table = db.VisitationLocations(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBRep.SelectedValue), Convert.ToInt32(CmbDeliveryVehi.SelectedValue));
                    DataRow row = table.Rows[i];
                    LocList.Add("{title:'" + row[1] + " - " + row[0] + "'," + "lat:" + row[3] + ", lng: " + row[4] + ",description:'" + row[1] + " - " + row[0] + " - " + row[2] + " - Arrived @"+row[5] +"'}" + Environment.NewLine);


                    foreach (string myInt in LocList)
                    {
                        File.WriteAllText("LocationsTextParkingCustomers.txt", string.Join(", ", LocList.ToArray()));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("WrightLoactionsToText() " + ex.Message); }
        }//Creating Locations of visits to the LocationsTextParking file.

        public void GetDetailsToText2()
        {
            StreamReader srheader = new StreamReader("LocationsTextHeaderParking.txt");
            String header = srheader.ReadToEnd();
            StreamReader sr = new StreamReader("LocationsTextParkingCustomers.txt");
            String locations = sr.ReadToEnd();
            StreamReader srFooter = new StreamReader("LocationsTextFooterParkingDriveWay.txt");
            String footer = srFooter.ReadToEnd();
            sr.Close();
            
            BrowserLocation.DocumentText = @"<script type='text/javascript' src='http://maps.googleapis.com/maps/api/js?sensor=false'></script>
<script type='text/javascript'>" + header + locations + footer + "</script> <div id='dvMap' style='width: 800px; height: 600px'> </div>";
        }//Load map to the browser with Driving Rout view;

        private void BtnGetRoad_Click(object sender, EventArgs e)
        {
            GetDetailsToText2();
        }

        private void BtnGetLocations_Click(object sender, EventArgs e)
        {

        }

        private void FindLocationsOfCustomers_Load(object sender, EventArgs e)
        {
            DTPFromDate.Format = DateTimePickerFormat.Custom;
            DTPFromDate.CustomFormat = "dd/MM/yyyy";
            DTPToDate.Format = DateTimePickerFormat.Custom;
            DTPToDate.CustomFormat = "dd/MM/yyyy";
            GetRepToCombo(); GetDelivaryVehiToCombo(); LoadCustinfo();
        }

        public void GetRepToCombo()
        {
            DataTable dtRep = db.GetSalesRepToCMB();
            CMBRep.ValueMember = "id";
            CMBRep.DisplayMember = "repName";
            CMBRep.DataSource = dtRep;
            CMBRep.SelectedItem = null;
        }

        public void GetDelivaryVehiToCombo()
        {
            DataTable dtVhi = db.GetDelivaryVehicle();
            CmbDeliveryVehi.ValueMember = "id";
            CmbDeliveryVehi.DisplayMember = "vhiNO";
            CmbDeliveryVehi.DataSource = dtVhi;
            CmbDeliveryVehi.SelectedItem = null;
        }

        public void GetDataToCusTMP()
        {
            string pc = System.Environment.MachineName.ToString();
            if (db.WrightVisitsToTemp(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"),
                DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CmbDeliveryVehi.SelectedValue),
                Convert.ToInt32(CMBRep.SelectedValue), Settings.Default.UserID, pc))
            {
                /*Do nothing*/
            }
            else { MessageBox.Show("error"); }
        }

        private void DTPFromDate_ValueChanged(object sender, EventArgs e)
        {
            LoadCustinfo();
            WrightLoactionsToText(); GetDataToCusTMP();
        }

        private void DTPToDate_ValueChanged(object sender, EventArgs e)
        {
            LoadCustinfo();
            WrightLoactionsToText();
            GetDataToCusTMP();
        }

        private void CMBRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustinfo();
            WrightLoactionsToText();
            GetDataToCusTMP();
        }

        private void CmbDeliveryVehi_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCustinfo();
            WrightLoactionsToText();
            GetDataToCusTMP();
        }

        private void FindLocationsOfCustomers_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu menu = new MainMenu();
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainMenu))
                {
                    form.Activate();
                    return;
                }
            }
            menu.MdiParent = this.ParentForm;
            menu.Show();
            this.Hide();
        }

        private void CMBRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CMBRep.SelectedItem != null)
                {
                    CmbDeliveryVehi.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Rep' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbDeliveryVehi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbDeliveryVehi.SelectedItem != null)
                {
                    DTPFromDate.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Vehicle' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DTPFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DTPFromDate.Value != null)
                {
                    DTPToDate.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'From Date' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DTPToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DTPToDate.Value != null)
                {
                    BtnReportView_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'To Date' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
