using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Itinerary;
using WorkFlowMenagementMDI.Tracking.Reports;

namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    public partial class WIPReportSelector : Form
    {
        private int _seriesID;
        private string _seriesCode;
        GenarateItineraryPlanMethods db = new GenarateItineraryPlanMethods();
        public WIPReportSelector(int seriesID, string seriesCode)
        {
            this._seriesCode = seriesCode;
            this._seriesID = seriesID;
            InitializeComponent();
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        {
            if (RbAllFO.Checked == true)
            {

                string query = "";
                ReportViewerFarmer rptView = new ReportViewerFarmer(_seriesID, _seriesCode, query);
                rptView.Show();
            }
            else if (RBSingleFO.Checked == true)
            {
                string query = "and FOM.FLD_OFF_MST_CODE =" + Convert.ToInt32(CmbFieldOfficer.SelectedValue) + "";
                ReportViewerFarmer rptView = new ReportViewerFarmer(_seriesID, _seriesCode, query);
                rptView.Show();
            }
        }
        public void GetFONameFromDb()
        {
            DataTable dt = db.GetFieldOfficerToCMB();
            CmbFieldOfficer.ValueMember = "id";
            CmbFieldOfficer.DisplayMember = "name";
            CmbFieldOfficer.DataSource = dt;
            CmbFieldOfficer.SelectedItem = null;
        }

        private void WIPReportSelector_Load(object sender, EventArgs e)
        {
            GetFONameFromDb();
        }

        private void RbAllFO_CheckedChanged(object sender, EventArgs e)
        {
            CmbFieldOfficer.Enabled = false;
        }

        private void RBSingleFO_CheckedChanged(object sender, EventArgs e)
        {
            CmbFieldOfficer.Enabled = true;
        }
    }
}
