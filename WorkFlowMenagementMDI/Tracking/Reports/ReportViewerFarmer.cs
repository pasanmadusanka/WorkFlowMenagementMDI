using CrystalDecisions.CrystalReports.Engine;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Reports.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods;

namespace WorkFlowMenagementMDI.Tracking.Reports
{
    public partial class ReportViewerFarmer : Form
    {
        ReportFilterMethods db = new ReportFilterMethods();
        private string _fromDate, _toDate,_officer,_repName,_trackName;
        private int _officerID;//,_repID,_trackID
        public ReportViewerFarmer()
        {
            InitializeComponent();
        } 
        public ReportViewerFarmer(string fromDate,string toDate,int officerId,string officer)
        {
            InitializeComponent();
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._officerID = officerId;
            this._officer = officer;
            LoadReportOfficerVisits();
        } 
        public ReportViewerFarmer(string fromDate, string toDate, string repName, string trackName)
        {
            InitializeComponent();
            this._fromDate = fromDate;
            this._toDate = toDate;
            this._repName = repName;
            this._trackName = trackName;
            CustomerVisitToReport2();
        } 
        public void LoadReportOfficerVisits()
        {
            OfficerVisitsCR crystalReport = new OfficerVisitsCR();
            try
            {
                FOVisitsDataSet VisitDataSet = db.GetFeildOffVisitation();
                crystalReport.SetDataSource(VisitDataSet);
                this.CRViewerGeo.ReportSource = crystalReport;
                TextObject yr = (TextObject)crystalReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
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
                TextObject heder = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
                heder.Text = row[0].ToString();
                TextObject heder2 = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
                heder2.Text = row[1].ToString();
                TextObject heder3 = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
                heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
                TextObject heder4 = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
                heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
                TextObject heder5 = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
                heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();

                TextObject fromD = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
                TextObject headerTxt = (TextObject)crystalReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = _officer + " Extension Officer Field Visit Report";
            }
            catch
            {
                MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.CRViewerGeo.RefreshReport();
        }

        public void CustomerVisitToReport()
        {//GetCustDropingBuysNew()
            CustomerDropingbuysCR cusReport = new CustomerDropingbuysCR();
            try
            {
                CustVisitDS VisitDataSet = db.GetCustDropingBuysNew();//Get report data from GPSCUStemp
                cusReport.SetDataSource(VisitDataSet);
                this.CRViewerGeo.ReportSource = cusReport;

                TextObject copyRight = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtCopy"];
                copyRight.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD :";
                TextObject date = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtDate"];
                date.Text = DateTime.Now.ToString("dd/MM/yyyy");//TxtTime
                TextObject time = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtTime"];
                time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                TextObject pc = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtPC"];
                pc.Text = System.Environment.MachineName.ToString();
                TextObject user = (TextObject)cusReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtUN"];
                user.Text = Settings.Default.LastUser + " ]";
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

                TextObject fromD = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
                TextObject headerTxt = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = _repName + " (" + _trackName + ")";
            }
            catch
            { MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.CRViewerGeo.RefreshReport();
        }

        public void CustomerVisitToReport2()
        {//GetCustDropingBuysNew()
            GetREportCusAMT cusReport = new GetREportCusAMT();
            try
            {
                CustVisitDS VisitDataSet = db.GetCustDropingBuysNew();//Get report data from GPSCUStemp
                cusReport.SetDataSource(VisitDataSet);
                this.CRViewerGeo.ReportSource = cusReport;

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
                TextObject fromD = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
                TextObject headerTxt = (TextObject)cusReport.ReportDefinition.Sections["Section1"].ReportObjects["VisitHeader"];
                headerTxt.Text = _repName + " (" + _trackName + ")";
            }
            catch
            { MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            this.CRViewerGeo.RefreshReport();
        }
    }
}
