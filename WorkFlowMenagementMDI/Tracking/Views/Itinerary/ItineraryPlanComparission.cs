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
    public partial class ItineraryPlanComparison : Form
    {

        GenarateItineraryPlanMethods db = new GenarateItineraryPlanMethods();
        ItineraryPlanComparisionMethods compairMethods = new ItineraryPlanComparisionMethods();
        ToolTip tips = new ToolTip();
        int lastUser = Properties.Settings.Default.UserID;
        string fromDate = String.Empty;
        string toDate = String.Empty;
        public ItineraryPlanComparison()
        {
            InitializeComponent();
        }
        private void GetToolTips()
        {
            tips.SetToolTip(BtnPrinter, "Print itinerary");
            tips.SetToolTip(CBFailItinerary, "Click to get miss itinerarys"); 

        }
        public void GetWIPCodeFromDb()
        {
            DataTable dt = db.GetWIPCodeToCMB();
            CmbWIP.ValueMember = "id";
            CmbWIP.DisplayMember = "code";
            CmbWIP.DataSource = dt;
            CmbWIP.SelectedItem = null;
        }
        public void GetFONameFromDb()
        {
            DataTable dt = db.GetFieldOfficerToCMB();
            CmbFieldOfficer.ValueMember = "id";
            CmbFieldOfficer.DisplayMember = "name";
            CmbFieldOfficer.DataSource = dt;
            CmbFieldOfficer.SelectedItem = null;
        }

        private void ItineraryPlanComparison_Load(object sender, EventArgs e)
        {
            GetWIPCodeFromDb();
            GetFONameFromDb(); GetToolTips();
        }
        public void InsertTrackingData()
        {
            if (compairMethods.InsertTrackDataToTMP(lastUser, fromDate, toDate, Convert.ToInt32(CmbFieldOfficer.SelectedValue)))
            { /**/}
            else { MessageBox.Show("Error Canot insert tracking data...", "Tracking Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void GetGpsFieldofficerVisits()
        {
            DataSet ds = compairMethods.GetGpsTrackFODetails();
            DgvGpsActualVisits.DataSource = ds.Tables["FOactualTblView"].DefaultView;
        }
        public void GetItineraryWeekPlan()
        {//WIPM.ITINERARY_MST_DATE = GCPT.DATE AND (Not check the date)
            string qurery=@" and NOT EXISTS(SELECT NULL
                    FROM GPS_CUS_PARK_TBL_TMP as GCPT 
        WHERE WIPM.FAR_HDR_MST_FAR_NO_FK = GCPT.IV2NAME and GCPT.USERID="+lastUser+")";
            if (CBFailItinerary.Checked == true)
            {
                DataSet ds = compairMethods.GetWeeklyItineraryDetails
                    (Convert.ToInt32(CmbFieldOfficer.SelectedValue), Convert.ToInt32(CmbWIP.SelectedValue), qurery);
                DgvItineraryView.DataSource = ds.Tables["FOactualTblView"].DefaultView;
            }
            else 
            {
                DataSet ds = compairMethods.GetWeeklyItineraryDetails
                                   (Convert.ToInt32(CmbFieldOfficer.SelectedValue), Convert.ToInt32(CmbWIP.SelectedValue), "");
                DgvItineraryView.DataSource = ds.Tables["FOactualTblView"].DefaultView;
            }
        }
        private void CBFailItinerary_CheckedChanged(object sender, EventArgs e)
        {
            GetItineraryWeekPlan();
        }
        private void CmbWIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = compairMethods.GetFromToDateForWIPCode(Convert.ToInt32(CmbWIP.SelectedValue));
            if (CmbWIP.SelectedItem != null)
            {
                DataRow dr = dt.Rows[0];
                fromDate = dr["fromDate"].ToString();
                string editfromDat = fromDate.Substring(3, 2) + "/" + fromDate.Substring(0, 2) + "/" + fromDate.Substring(6, 4);
                toDate = dr["toDate"].ToString();
                string editToDat = toDate.Substring(3, 2) + "/" + toDate.Substring(0, 2) + "/" + toDate.Substring(6, 4);
                DtpPlanFrmDate.Value = Convert.ToDateTime(editfromDat);
                DtpPlanToDate.Value = Convert.ToDateTime(editToDat);
                InsertTrackingData();
                GetGpsFieldofficerVisits();
                GetItineraryWeekPlan();
            }
        }

        private void CmbFieldOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbFieldOfficer.SelectedItem != null)
            {
                InsertTrackingData();
                GetGpsFieldofficerVisits();
                GetItineraryWeekPlan();
            }
        }

        private void BtnPrinter_Click(object sender, EventArgs e)
        {
            string rptType=String.Empty;
            if (RBItinary.Checked == true)
            {
                rptType = "itinary";
                ReportViewerFarmer rpt = new ReportViewerFarmer(rptType, Convert.ToInt32(CmbFieldOfficer.SelectedValue), Convert.ToInt32(CmbWIP.SelectedValue));
                rpt.Show();
            }
            else if (RBMissItinary.Checked == true)
            {
                rptType = "missItinary";
                ReportViewerFarmer rpt = new ReportViewerFarmer(rptType, Convert.ToInt32(CmbFieldOfficer.SelectedValue), Convert.ToInt32(CmbWIP.SelectedValue));
                rpt.Show();
            }
        }

    }
}
