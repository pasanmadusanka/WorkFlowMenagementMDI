using CrystalDecisions.CrystalReports.Engine; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FeedIssue.DBMethods;
using WorkFlowMenagementMDI.Properties;

namespace WorkFlowMenagementMDI.FeedIssue.ReportView
{
    public partial class ReportViewer : Form
    {
        private string _query,_week,_area,_fromDate,_toDate;
        private string _date;
        private int _repType;

        ReportAccessMethods db = new ReportAccessMethods();
        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(string area,string query,string date,string week)
        {
            this._query = query;
            this._date = date;
            this._area = area;
            this._week = week;
            InitializeComponent();
            ScheduleVisitToReport();
        }
        public ReportViewer(string fromDate, string ToDate, string area, int repType)
        {
            this._area = area;
            this._fromDate = fromDate;
            this._toDate = ToDate;
            this._repType = repType;
            InitializeComponent();
            if (repType == 1)
            { ScheduleVisitToReportByRange(); }
            else { ScheduleVisitAll(); }
        }
        public void ScheduleVisitToReport()
        {//GetCustDropingBuysNew()
            FeedIssueScheduleCR cusReport = new FeedIssueScheduleCR();
            try
            {
                DSReportFeedIssue VisitDataSet = db.FeedReqDateReport(_query);//Get report data from GPSCUStemp
                cusReport.SetDataSource(VisitDataSet);
                this.CRFeed.ReportSource = cusReport;

                TextObject yr = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
                yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Settings.Default.LastUser + " ]";
            }
            catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                DataTable table = db.FillReportHeader();
                DataRow row = table.Rows[0];
                TextObject heder = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
                heder.Text = row[0].ToString();
                TextObject heder2 = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
                heder2.Text = row[1].ToString();
                TextObject heder3 = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
                heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
                TextObject heder4 = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
                heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
                TextObject heder5 = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
                heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();

                TextObject week = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRWeekName"];
                week.Text = "Week "+_week+" Input";
                TextObject headerTxt = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = @"Feed Issue Schedule For "+_date+" "+" " +_area +" Area";
            }
            catch
            { MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.CRFeed.RefreshReport();
        }

        public void ScheduleVisitToReportByRange() 
        {  
            ScheduleDateToItemCR scheduleReport = new ScheduleDateToItemCR();
            try
            {
                DSFeedIssueWeekPlan VisitDataSet = db.FeedReqDateRangeReport(_fromDate,_toDate);//Get report data from GPSCUStemp
                scheduleReport.SetDataSource(VisitDataSet);
                this.CRFeed.ReportSource = scheduleReport;

                TextObject yr = (TextObject)scheduleReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
                yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Settings.Default.LastUser + " ]";
            }
            catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                DataTable table = db.FillReportHeader();
                DataRow row = table.Rows[0];
                TextObject heder = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
                heder.Text = row[0].ToString();
                TextObject heder2 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
                heder2.Text = row[1].ToString();
                TextObject heder3 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
                heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
                TextObject heder4 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
                heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
                TextObject heder5 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
                heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();

                TextObject fromD = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
                TextObject headerTxt = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = "Feed Issue Schedule For " + _area + " Area";
            }
            catch
            { MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.CRFeed.RefreshReport();
        }

        public void ScheduleVisitAll()
        { 
            FeedIssueDateRangeCR scheduleReport = new FeedIssueDateRangeCR();
            try
            {
                DSFeedIssueWeekPlan VisitDataSet = db.FeedReqDateRangeReport(_fromDate, _toDate);//Get report data from GPSCUStemp
                scheduleReport.SetDataSource(VisitDataSet);
                this.CRFeed.ReportSource = scheduleReport;

                TextObject yr = (TextObject)scheduleReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
                yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Settings.Default.LastUser + " ]";
            }
            catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                DataTable table = db.FillReportHeader();
                DataRow row = table.Rows[0];
                TextObject heder = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
                heder.Text = row[0].ToString();
                TextObject heder2 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
                heder2.Text = row[1].ToString();
                TextObject heder3 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
                heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
                TextObject heder4 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
                heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
                TextObject heder5 = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
                heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();

                TextObject fromD = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
                TextObject headerTxt = (TextObject)scheduleReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = "Feed Issue Schedule For " + _area + " Area";
            }
            catch
            { MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.CRFeed.RefreshReport();
        }
    }
}
