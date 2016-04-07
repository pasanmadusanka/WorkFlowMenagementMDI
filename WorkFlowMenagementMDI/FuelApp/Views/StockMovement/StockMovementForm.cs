using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;
using WorkFlowMenagementMDI.FuelApp.Views.Reports;

namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    public partial class StockMovementForm : Form
    {
        FuelStockMovementMethods db = new FuelStockMovementMethods();
        GetAvalableStockClass getStock = new GetAvalableStockClass();
        public StockMovementForm()
        {
            InitializeComponent();
        }

        private void StockMovementForm_Load(object sender, EventArgs e)
        {
            LoadDateCmbo();
            DataTable dt = db.GetAllFuelDetals();
            DgvFuelStock.DataSource = dt;
            GetFinalFuelStock();
            //LblstkBalByDate.Text = getStock.GetAvalableStkByDate(CmbDates.Text.ToString(), DTPToDate.Value.Date.ToString("MM/dd/yyyy"));
        }

        public void LoadDateCmbo()
        {
            DataTable dt = db.GetDistinctDates();
            CmbDates.DisplayMember = "date";
            CmbDates.DataSource = dt;
        }

        private void CmbDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetStockByDate(CmbDates.Text.ToString());
            DgvFuelStock.DataSource = dt;
        }

        #region Get Avalable Stock for fuel weediyawattha
        public double GetFuelStock()//FromProcedure
        {
            double genStock;
            string stock = getStock.GetAvalableStock(16111, 130);
            genStock = Convert.ToDouble(stock);
            return genStock;
        }
        public double GetSumOfFuel()
        {
            double fuelSum = Convert.ToDouble(getStock.GetSumNotSubmit());
            return fuelSum;
        }//Get Sum

        public void GetFinalFuelStock()
        {
            try
            {
                double finalAvStock = GetFuelStock() - GetSumOfFuel();
                if (finalAvStock > 5000)
                {
                    LblAvalableStk.ForeColor = Color.Blue;
                    LblAvalableStk.Text = finalAvStock.ToString() + " L";
                }
                else if (finalAvStock < 5000)
                {
                    LblAvalableStk.ForeColor = Color.Red;
                    LblAvalableStk.Text = finalAvStock.ToString() + " L (Low)";
                }
            }
            catch { MessageBox.Show("Error with loading stock...", "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            string id = "stockMovement";
            //StockMovementReportView report = new StockMovementReportView(id);
            //report.ShowDialog();
            DateSelection reptView = new DateSelection(id);
            reptView.ShowDialog();

        }//Views\StockMovement\FuelStkReport.rpt

        private void DTPToDate_ValueChanged(object sender, EventArgs e)
        {}
    }
}
