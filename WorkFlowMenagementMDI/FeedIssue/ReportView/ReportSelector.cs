using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FeedIssue.DBMethods;
using WorkFlowMenagementMDI.FeedIssue.ReportView;

namespace WorkFlowMenagementMDI.FeedIssue.ReportView
{
    public partial class ReportSelector : Form
    {
        FeedIssueScheduleListMethods db = new FeedIssueScheduleListMethods();
        ReportToTMPTblMethod tempMthod = new ReportToTMPTblMethod();
        public ReportSelector()
        {
            InitializeComponent();
        }
        private void ReportSelector_Load(object sender, EventArgs e)
        {
            DtpExactDate.Format = DateTimePickerFormat.Custom;
            DtpExactDate.CustomFormat = "dd/MM/yyyy";
            LoadArea();
        }
        public void LoadArea()
        {
            DataTable dt = db.LoadListView();
            CmbArea.ValueMember = "id";
            CmbArea.DisplayMember = "name";
            CmbArea.DataSource = dt;
        }
        private void RBMainFinisher_CheckedChanged(object sender, EventArgs e)
        {
                GBFinisher.Enabled = true;
                GBBooster.Enabled = false; 
        }

        private void RBMainBoost_CheckedChanged(object sender, EventArgs e)
        { 
                GBFinisher.Enabled = false;
                GBBooster.Enabled = true; 
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        {
            //GetSelectionOfUsers();
        }

        public string PassQuery(string weekIn,string week,int Location, string date)
        {
            string query = @"SELECT FED_ISS_SCH_BATCH_ID,fhm.FAR_HDR_MST_CODE," + weekIn + " as [Week], FHM.FAR_HDR_MST_NAME,BCH.BAT_CRT_NO_CHICKS " +
             "FROM FEED_ISSUE_SCHEDULE_TEMP as FIST INNER JOIN BATCH_CREATE_HEADER as BCH ON FIST.FED_ISS_SCH_BATCH_ID = BCH.BAT_CRT_NO INNER JOIN " +
             "FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join " +
             "FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN " +
             "FARMER_LOCATION as FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE " +
             "where FL.FAR_LOC_MST_CODE = " + Location + " and " + week + " = '" + date + "'";
            return query;
        }

        public void GetSelectionOfUsers()
        {
            ReportViewer report;
            string nameArea = CmbArea.Text;
            int areaID = Convert.ToInt32(CmbArea.SelectedValue);
            string dtpDat = DtpExactDate.Value.ToString("MM/dd/yyyy");
            string relDat = DtpExactDate.Value.ToString("dd/MM/yyyy");
            if (GBBooster.Enabled == true)
            {
                if (RBSubW1.Checked == true)
                {
                    report = new ReportViewer(nameArea, PassQuery("FED_ISS_SCH_WEK1_IN", "FED_ISS_SCH_ISSUE_WEK1", areaID, dtpDat)
                        ,relDat,"1");
                    report.Show();
                }
                else if (RBSubW2.Checked == true)
                {
                    report = new ReportViewer(nameArea, PassQuery("FED_ISS_SCH_WEK2_IN", "FED_ISS_SCH_ISSUE_WEK2", areaID, dtpDat), 
                        relDat, "2");
                    report.Show();
                }
                else if (RBSubW3.Checked == true)
                {
                    report = new ReportViewer(nameArea, PassQuery("FED_ISS_SCH_WEK3_IN", "FED_ISS_SCH_ISSUE_WEK3", areaID, dtpDat)
                        , relDat,"3");
                    report.Show();
                }
            }
            else
            {
                if (RBSubW4.Checked == true)
                {
                    report = new ReportViewer(nameArea, PassQuery("FED_ISS_SCH_WEK4_IN", "FED_ISS_SCH_ISSUE_WEK4", areaID, dtpDat)
                        , relDat,"4");
                    report.Show();
                }
                else if (RBSubW5.Checked == true)
                {
                    report = new ReportViewer(nameArea, PassQuery("FED_ISS_SCH_WEK5_IN", "FED_ISS_SCH_ISSUE_WEK5", areaID, dtpDat)
                        , relDat,"5");
                    report.Show();
                }
            }
        }

        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt=tempMthod.GetBatchCodeByArea(Convert.ToInt32(CmbArea.SelectedValue));
            //DataRow dr = dt.Rows[0];
            foreach (DataRow dr in dt.Rows) 
            {
                foreach (var item in dr.ItemArray) // Loop over the items.
                {
                    tempMthod.WrightVisitsToTemp(Convert.ToInt32(item));
                }
            }
        }

    }
}
