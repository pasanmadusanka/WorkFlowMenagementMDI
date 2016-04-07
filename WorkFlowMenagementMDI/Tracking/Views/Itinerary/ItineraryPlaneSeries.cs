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
using WorkFlowMenagementMDI.Tracking.Views.Upload;

namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    public partial class ItineraryPlaneSeries : Form
    {
        ItineraryPlaneManageMethods db = new ItineraryPlaneManageMethods(); 
        ToolTip tips = new ToolTip();
        public ItineraryPlaneSeries()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteItinerarySeries();
        }

        public void GetSeriesInToGrid()
        {
            DataSet ds = db.GetWIPToGrid();
            DgvWIPDetails.DataSource = ds.Tables["wipTable"].DefaultView;
        }
        public void DeleteItinerarySeries()
        {
            //int outVal = GetUserAccessable("UTRW_DELETE");
            //if (outVal == 1)
            //{
            try
            {
                DataTable dt = db.GetRowCountOfDeletingSeries(Convert.ToInt32(lblSeriesID.Text));
                DataRow dr = dt.Rows[0];
                string noOfRows = dr[0].ToString();

                DialogResult result = MessageBox.Show("Do you really want to delete the Record \"" + LblRecord.Text + "\", \nWhich Contains " + noOfRows + " rows of Itinerary details?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteItinarySeries(Convert.ToInt32(lblSeriesID.Text)))
                    {
                        MessageBox.Show("Record has been Deleted....!", "Record " + LblRecord.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        GetSeriesInToGrid();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record " + LblRecord.Text + " Not Deleted", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            //}
            //else { MessageBox.Show("you dont have the permissions to delete this", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        private void GetToolTips()
        { 
            tips.SetToolTip(BtnCreate, "Add New Weekly Itinerary Plan");
            tips.SetToolTip(BtnEdit, "Change WIP Dates(From/To)");
            tips.SetToolTip(BtnPrinter, "Select Serias and click to print");
            tips.SetToolTip(BtnDelete, "Delete an itinerary plan completely");
            tips.SetToolTip(BtnUploadDetails, "Upload Tracking Data downloaded from tracking.lk");
            tips.SetToolTip(BtnItinararyCompair, "Compare itinerary results with tracking data");

        }
        private void ItineraryPlaneManage_Load(object sender, EventArgs e)
        {
            GetSeriesInToGrid(); GetToolTips();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            GenarateItineraryPlan genPlan = new GenarateItineraryPlan(this);
            genPlan.ShowDialog();
        }

        private void DgvWIPDetails_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = Convert.ToInt32(DgvWIPDetails.Rows[e.RowIndex].Cells[0].Value);
            GenarateItineraryPlan GIP = new GenarateItineraryPlan(id,this);
            GIP.ShowDialog();
        }

        private void BtnItinararyCompair_Click(object sender, EventArgs e)
        {
            ItineraryPlanComparison planCompair = new ItineraryPlanComparison();
            planCompair.ShowDialog();
        }

        private void BtnUploadDetails_Click(object sender, EventArgs e)
        {
            UploadExcelParkingDetails upload = new UploadExcelParkingDetails();
            upload.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            AddWIPSeries editID = new AddWIPSeries(Convert.ToInt32(lblSeriesID.Text));
            editID.ShowDialog();
        }

        private void BtnPrinter_Click(object sender, EventArgs e)
        {
            WIPReportSelector rptView = new WIPReportSelector(Convert.ToInt32(lblSeriesID.Text), LblRecord.Text);
            rptView.ShowDialog();
        }

        private void DgvWIPDetails_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //WIP_ID
            lblSeriesID.Text = DgvWIPDetails.Rows[e.RowIndex].Cells["WIP_ID"].Value.ToString();
            LblRecord.Text = DgvWIPDetails.Rows[e.RowIndex].Cells["WIP_Code"].Value.ToString();
        }
    }
}
