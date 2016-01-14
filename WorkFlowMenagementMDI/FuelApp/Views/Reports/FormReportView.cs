using CrystalDecisions.CrystalReports.Engine;
using WorkFlowMenagementMDI.FuelApp.Methods;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.FuelApp.Views.Reports;
using WorkFlowMenagementMDI.FuelApp.Views.StockMovement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.FuelApp.Views.Reports
{
    public partial class FormReportView : Form
    {
        private string _fromDate, _toDate, _id;
        ReportAccess db = new ReportAccess();
        public FormReportView()
        {
            InitializeComponent();
        }
        public FormReportView(string id,string fromDate, string toDate)
        {
            InitializeComponent();
            this._id = id;
            this._fromDate = fromDate;
            this._toDate = toDate;
            LoadForms();
        }

        public void LoadForms()
        {
            if (_id == "LoadMain")
            { LoadNewRpt(); }//Load the General Stock report
            else if (_id == "PhycisalLoad")
            { LoadPhysicalFuelStock(); }//Load physical Stock report
        }

        #region Load Report From the DataSet2 and pass values to Headder and Footer
        public void LoadNewRpt()
        {
            FuelreportCR crystalReport = new FuelreportCR();
            try
            {
                DataSet2 dsCustomers = db.GetData(_fromDate, _toDate);
                crystalReport.SetDataSource(dsCustomers);
                this.crystalReportViewer1.ReportSource = crystalReport;
                TextObject yr = (TextObject)crystalReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
                yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Properties.Settings.Default.LastUser + " ]";
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
            }
            catch
            {
                MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.crystalReportViewer1.RefreshReport();
        }
        #endregion

        public void LoadPhysicalFuelStock()
        {
            PhysicalStockReport fuelReport = new PhysicalStockReport();
            try
            {
                PhysicalStockDS ds = db.GetPhysicalStock(_fromDate, _toDate);
                fuelReport.SetDataSource(ds);
                this.crystalReportViewer1.ReportSource = fuelReport;

                TextObject yr = (TextObject)fuelReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
                yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Properties.Settings.Default.LastUser + " ]";

                //TextObject fromD = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                //yr.Text = _fromDate.ToString();
            }
            catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            try
            {
                DataTable table = db.FillReportHeader();
                DataRow row = table.Rows[0];
                TextObject heder = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
                heder.Text = row[0].ToString();
                TextObject heder2 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
                heder2.Text = row[1].ToString();
                TextObject heder3 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
                heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
                TextObject heder4 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
                heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
                TextObject heder5 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
                heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();

                TextObject fromD = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["CrFromDatTxt"];
                fromD.Text = _fromDate;
                TextObject toDay = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["CrToDatTxt"];
                toDay.Text = _toDate;
            }
            catch (Exception ex)
            { MessageBox.Show("Error loading with the report header... " + ex.Message.ToString(), "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.crystalReportViewer1.RefreshReport();
        }

    }
}
