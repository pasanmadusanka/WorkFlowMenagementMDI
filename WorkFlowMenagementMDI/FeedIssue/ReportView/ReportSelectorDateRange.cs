using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FeedIssue.DBMethods;

namespace WorkFlowMenagementMDI.FeedIssue.ReportView
{
    public partial class ReportSelectorDateRange : Form
    {
        FeedIssueScheduleListMethods db = new FeedIssueScheduleListMethods();
        ReportToTMPTblMethod tempMthod = new ReportToTMPTblMethod();
        public ReportSelectorDateRange()
        { InitializeComponent(); }

        private void ReportSelectorDateRange_Load(object sender, EventArgs e)
        {
            DtpFromDate.Format = DateTimePickerFormat.Custom;
            DtpFromDate.CustomFormat = "dd/MM/yyyy";
            DtpToDate.Format = DateTimePickerFormat.Custom;
            DtpToDate.CustomFormat = "dd/MM/yyyy";
            LoadArea();
        }

        private void LoadArea()
        {
            DataTable dt = db.LoadListView();
            CmbArea.ValueMember = "id";
            CmbArea.DisplayMember = "name";
            CmbArea.DataSource = dt;
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        {
            if (RBDatSort.Checked == true)
            {
                ReportViewer repView = new ReportViewer(DtpFromDate.Value.ToString("MM/dd/yyyy"), DtpToDate.Value.ToString("MM/dd/yyyy"), CmbArea.Text,1);
                repView.Show();
            }
            else if (RBGenRep.Checked == true)
            {
                ReportViewer repView = new ReportViewer(DtpFromDate.Value.ToString("MM/dd/yyyy"), DtpToDate.Value.ToString("MM/dd/yyyy"), CmbArea.Text,0);
                repView.Show();
            }
        }

        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tempMthod.DeleteTempTableData();
                DataTable dt = tempMthod.GetBatchCodeByArea(Convert.ToInt32(CmbArea.SelectedValue));
                //DataRow dr = dt.Rows[0];
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (var item in dr.ItemArray) // Loop over the items.
                    { tempMthod.WrightVisitsToTemp(Convert.ToInt32(item)); }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Area change"); }
        }
    }
}
