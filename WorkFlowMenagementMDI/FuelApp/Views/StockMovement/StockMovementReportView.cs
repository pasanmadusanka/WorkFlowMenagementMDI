﻿using CrystalDecisions.CrystalReports.Engine;
using WorkFlowMenagementMDI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;

namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    public partial class StockMovementReportView : Form
    {
        ReportAccess db = new ReportAccess();
        private string _id;
        public StockMovementReportView()
        {
            InitializeComponent();
            //LoadReport();
            //LoadPhysicalFuelStock();
        }
        public StockMovementReportView(string id)
        {
            InitializeComponent();
            this._id = id;
            LoadMethods();
        }
        //public void LoadReport()
        //{
        //   StockMovementRpt crystalReport2 = new StockMovementRpt();
        //    try
        //    {
        //        StockMovementDS ds = db.GetStockData();
        //        crystalReport2.SetDataSource(ds);
        //        this.crystalReportStockMove.ReportSource = crystalReport2;
        //        TextObject yr = (TextObject)crystalReport2.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
        //        yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
        //            + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
        //            + " Com : " + System.Environment.MachineName.ToString() + " UN : "
        //            + Properties.Settings.Default.LastUser + " ]";
        //    }
        //    catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        //    try
        //    {
        //        DataTable table = db.FillReportHeader();
        //        DataRow row = table.Rows[0];
        //        TextObject heder = (TextObject)crystalReport2.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
        //        heder.Text = row[0].ToString();
        //        TextObject heder2 = (TextObject)crystalReport2.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
        //        heder2.Text = row[1].ToString();
        //        TextObject heder3 = (TextObject)crystalReport2.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
        //        heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
        //        TextObject heder4 = (TextObject)crystalReport2.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
        //        heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
        //        TextObject heder5 = (TextObject)crystalReport2.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
        //        heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error loading with the report header...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    this.crystalReportStockMove.RefreshReport(); 

        //}

        /// <summary>
        /// FuelAppForWeediyawaththaFW3.0\Views\StockMovement\FuelStkReport.rpt
        /// </summary>
        public void LoadFuelStockByDateReport()
        {
            FuelStkReport fuelReport = new FuelStkReport();
            try
            {
                FuelStockDataSet ds = db.GetFuelStockData();
                fuelReport.SetDataSource(ds);
                this.crystalReportStockMove.ReportSource = fuelReport;

                TextObject yr = (TextObject)fuelReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
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
            }
            catch (Exception ex)
            { MessageBox.Show("Error loading with the report header... " + ex.Message.ToString(), "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.crystalReportStockMove.RefreshReport();
        }
        //public void LoadPhysicalFuelStock()
        //{
        //    PhysicalStockReport fuelReport = new PhysicalStockReport();
        //    try
        //    {
        //        PhysicalStockDS ds = db.GetPhysicalStock();
        //        fuelReport.SetDataSource(ds);
        //        this.crystalReportStockMove.ReportSource = fuelReport;

        //        TextObject yr = (TextObject)fuelReport.ReportDefinition.Sections["Section5"].ReportObjects["TxtObjLogUser"];
        //        yr.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
        //            + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
        //            + " Com : " + System.Environment.MachineName.ToString() + " UN : "
        //            + Properties.Settings.Default.LastUser + " ]";
        //    }
        //    catch { MessageBox.Show("Error loading with the report...", "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        //    try
        //    {
        //        DataTable table = db.FillReportHeader();
        //        DataRow row = table.Rows[0];
        //        TextObject heder = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRName"];
        //        heder.Text = row[0].ToString();
        //        TextObject heder2 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCrAddr"];
        //        heder2.Text = row[1].ToString();
        //        TextObject heder3 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCRTPNo"];
        //        heder3.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
        //        TextObject heder4 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtCREmailWeb"];
        //        heder4.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
        //        TextObject heder5 = (TextObject)fuelReport.ReportDefinition.Sections["Section1"].ReportObjects["TxtHoLine"];
        //        heder5.Text = "Hot Line : 0774410500 / " + row[2].ToString();
        //    }
        //    catch (Exception ex)
        //    { MessageBox.Show("Error loading with the report header... " + ex.Message.ToString(), "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        //    this.crystalReportStockMove.RefreshReport();
        //}

        public void LoadMethods()
        {
            if (_id == "stockMovement")
            {
                LoadFuelStockByDateReport();
            }
            else { }
        }

    }
}
