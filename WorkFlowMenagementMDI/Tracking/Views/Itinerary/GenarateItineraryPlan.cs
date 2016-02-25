using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Itinerary;
using WorkFlowMenagementMDI.Tracking.Views.Upload;

namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    public partial class GenarateItineraryPlan : Form
    {
        GenarateItineraryPlanMethods db = new GenarateItineraryPlanMethods();
        private ItineraryPlaneSeries _itinerarySeries;
        private int _wipID;
        List<DateTime> allDates = new List<DateTime>();

        string ItineraryIDEdit = String.Empty;

        public GenarateItineraryPlan(ItineraryPlaneSeries itinerarySeries)
        {
            InitializeComponent();
            GetWIPCodeFromDb();
            this._itinerarySeries = itinerarySeries;
            BtnDelete.Enabled = false;
            DgvItineraryPlan.Visible = true;
            DgvItineraryPlan.Columns["fo_Id"].Visible = false;
            DgvItineraryPlan.Columns["Loc_Id"].Visible = false;
        }

        public GenarateItineraryPlan(int id, ItineraryPlaneSeries itinerarySeries)
        {
            InitializeComponent();
            GetWIPCodeFromDb();
            this._wipID = id;
            this._itinerarySeries = itinerarySeries;
            BtnAdd.Enabled = false;
            BtnReturn.Enabled = false;
            DgvGenerateItinaryDeleteEdit.Visible = true;
            GetItenaryDataSet(id);
        }

        public void GetItenaryDataSet(int id)
        {
            DataSet ds = db.GetWIPToGrid(id);
            DgvGenerateItinaryDeleteEdit.DataSource = ds.Tables["wipTable"].DefaultView;
            CmbWIP.SelectedValue = id; CmbWIP.Enabled = false; BtnNewWIP.Enabled = false;
        }

        #region Value changes events and Data Bindings to Combo boxes

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
        public void GetFarmerNCodeFromDb(int fieldOffId)
        {
            DataTable dt = db.GetFarmerNCodeToCMB(fieldOffId);
            CmbFarmerNCode.ValueMember = "id";
            CmbFarmerNCode.DisplayMember = "name";
            CmbFarmerNCode.DataSource = dt;
            CmbFarmerNCode.SelectedItem = null;
        }
        public void GetfarmerBatchToCombo()
        {
            DataTable dt = db.RetriveFarmerBatchOnCombo(Convert.ToInt32(CmbFarmerNCode.SelectedValue));
            CmbFarmerBatch.ValueMember = "id";
            CmbFarmerBatch.DisplayMember = "name";
            CmbFarmerBatch.DataSource = dt;
            CmbFarmerBatch.SelectedItem = null;
        }
        private void CmbFarmerNCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetfarmerBatchToCombo();
        }
        private void CmbFieldOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFarmerNCodeFromDb(Convert.ToInt32(CmbFieldOfficer.SelectedValue));
        }
        private void CmbFarmerBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = db.GetBatchDateNBirds(Convert.ToInt32(CmbFarmerBatch.SelectedValue));
            if (CmbFarmerBatch.SelectedItem != null)
            {
                DataRow dr = dt.Rows[0];
                string date = dr["date"].ToString();
                string editDat = date.Substring(3, 2) + "/" + date.Substring(0, 2) + "/" + date.Substring(6, 4);
                string birds = dr["chicks"].ToString();

                DateTime batchDat = Convert.ToDateTime(editDat);
                DateTime actDate = DateTime.Today;
                TimeSpan time = actDate.Subtract(batchDat);
                int days = (int)time.TotalDays;

                //lblLoc.Text = days.ToString();
                lblCap.Text = birds;
                lblDate.Text = days.ToString();
            }
        }
        private void CmbWIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbWIP.SelectedValue != null)
            {
                DataTable dt = db.GetFromDateNToDateOfSeries(Convert.ToInt32(CmbWIP.SelectedValue));
                DataRow dr = dt.Rows[0];
                DateTime dtFrom = Convert.ToDateTime(dr["fromD"]).Date;
                DtpPlanDate.Value = dtFrom;
            }
        }
        private void DtpPlanDate_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DgvItineraryPlan.Rows.Count; i++)
            {
                if (DgvItineraryPlan.Rows[i].DefaultCellStyle.BackColor == Color.LimeGreen)
                {
                    DgvItineraryPlan.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("Save Before go ferther");
                    break;
                }
            }
            if (CmbWIP.SelectedValue != null)
            {
                DataTable dt = db.GetFromDateNToDateOfSeries(Convert.ToInt32(CmbWIP.SelectedValue));
                DataRow dr = dt.Rows[0];
                DateTime dtFrom = Convert.ToDateTime(dr["fromD"]).Date;
                DateTime dtTo = Convert.ToDateTime(dr["toD"]).Date;
                DateTime setDate = DtpPlanDate.Value.Date;
                if (setDate >= dtFrom && setDate <= dtTo)
                {
                }
                else { MessageBox.Show("Error Data range should between /n" + dtFrom.ToString("dd/MMMM/yyyy") + " and " + dtTo.ToString("dd/MMMM/yyyy"), "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        #endregion

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string status = String.Empty;
                status = CmbPB.Text.ToLower() == "yes" ? "1" : "0";
                DgvItineraryPlan.Rows.Add(CmbWIP.Text, DtpPlanDate.Value.ToString("dd/MMMM/yyyy"), "", CmbFarmerNCode.Text, CmbFarmerBatch.Text,
                             lblDate.Text, lblCap.Text, CmbWIP.SelectedValue.ToString(), CmbFarmerNCode.SelectedValue.ToString(),
                             CmbFarmerBatch.SelectedValue.ToString(), "", "", status);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnNewWIP_Click(object sender, EventArgs e)
        {
            AddWIPSeries newWip = new AddWIPSeries();
            newWip.ShowDialog(); GetWIPCodeFromDb();
        }

        private void GenarateItineraryPlan_Load(object sender, EventArgs e)
        {
            GetFONameFromDb();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {

            if (DgvGenerateItinaryDeleteEdit.Visible == true)
            {//Edit/Delete Field or add new visit
                AddNewDetailsOfItinary();
                _itinerarySeries.GetSeriesInToGrid();//Calling parent grid to load or refresh
                TextClearEvent();
            }
            else
            {//Creating new itinerary
                InsertDetailsToOfItinary();
                _itinerarySeries.GetSeriesInToGrid();//Calling parent grid to load or refresh(deligate)
            }
        }
        private void TextClearEvent()
        { 
            CmbFarmerBatch.SelectedItem = null;
            CmbFarmerNCode.SelectedItem = null; CmbFarmerNCode.Text = "";
        }

        public void InsertDetailsToOfItinary()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to upload Feild Officer visit details?", "Confirm data uploading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < DgvItineraryPlan.Rows.Count; i++)
                    {
                        int wipCode = Convert.ToInt32(DgvItineraryPlan.Rows[i].Cells[7].Value);
                        int farm = Convert.ToInt32(DgvItineraryPlan.Rows[i].Cells[8].Value);
                        int batch = Convert.ToInt32(DgvItineraryPlan.Rows[i].Cells[9].Value);
                        string pbStatus = DgvItineraryPlan.Rows[i].Cells["Dg_P_B"].Value.ToString();
                        string planedDate = DtpPlanDate.Value.ToString("MM/dd/yyyy");

                        if (db.InsertIntoWIPMASTER(wipCode, planedDate, farm, batch, pbStatus) && DgvItineraryPlan.Rows[i].DefaultCellStyle.BackColor != Color.LimeGreen)
                        {
                            try
                            {
                                DgvItineraryPlan.ClearSelection();
                                DgvItineraryPlan.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "BtnSaveToDB Click"); }
                        }
                        else
                        {
                            MessageBox.Show("Error with data or Alredy Exsist....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                    }
                }
                else { /*Do nothing*/}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void AddNewDetailsOfItinary()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to update the itinerary series...?", "Confirm data uploading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string planedDate = DtpPlanDate.Value.ToString("MM/dd/yyyy"); 

                    string pbStatus = String.Empty;
                    pbStatus = CmbPB.Text.ToLower() == "yes" ? "1" : "0";

                    if (db.InsertIntoWIPMASTER(_wipID, planedDate, Convert.ToInt32(CmbFarmerNCode.SelectedValue),
                        Convert.ToInt32(CmbFarmerBatch.SelectedValue), pbStatus))
                    {
                        GetItenaryDataSet(_wipID);
                    }
                    else
                    {
                        MessageBox.Show("Error with data or Alredy Exsist....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else { /*Do nothing*/}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
        }

        private void DgvGenerateItinaryDeleteEdit_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //int outVal = privilege.GetUserAccessable("UTRW_DELETE", 1);
            //if (outVal == 1)
            //{
            DialogResult usersChoice = MessageBox.Show(@"You are about to delete " + DgvGenerateItinaryDeleteEdit.SelectedRows.Count
                + " Row(s).\n\n \r Click Yes to permanently delete these rows. You won’t be able to undo these changes.",
            "Weekly Itinerary Plan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // cancel the delete event
            if (usersChoice == DialogResult.No)
            { e.Cancel = true; }

            else if (usersChoice == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in this.DgvGenerateItinaryDeleteEdit.SelectedRows)
                {
                    object val = DgvGenerateItinaryDeleteEdit.Rows[row.Index].Cells["SubWIPID"].Value;
                    int value = Convert.ToInt32(val);
                    if (db.DeleteWIPMASTER(value))
                    { }
                    else { MessageBox.Show("Error Cannot delete row"); }
                }
            }
            //}
            //else { MessageBox.Show("You dont have the privelages to delete this....!", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); e.Cancel = true; }

        }

        private void DgvGenerateItinaryDeleteEdit_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ItineraryIDEdit = DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["SubWIPID"].Value.ToString();
            //MessageBox.Show(ItineraryIDEdit);
            string farmer = DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["Dg_FAR_HDR_MST_CODE"].Value.ToString() + " - " +
                DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["Dg_FAR_HDR_MST_NAME"].Value.ToString();

            CmbFieldOfficer.Text = DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["Dg_FLD_OFF_MST_NAME"].Value.ToString();
            CmbFarmerNCode.Text = farmer;

            CmbPB.Text = DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["SubWIPID"].Value.ToString();
            CmbFarmerBatch.Text = DgvGenerateItinaryDeleteEdit.Rows[e.RowIndex].Cells["Dg_BAT_CRT_CODE"].Value.ToString();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Update Itinerary?", "Confirm data uploading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string planedDate = DtpPlanDate.Value.ToString("MM/dd/yyyy");

                    string pbStatus = String.Empty;
                    pbStatus = CmbPB.Text.ToLower() == "yes" ? "1" : "0";

                    if (db.UpdateWIPMASTER(Convert.ToInt32(ItineraryIDEdit), pbStatus))
                    {
                        TextClearEvent(); GetItenaryDataSet(_wipID);
                        ItineraryIDEdit = "0";
                    }
                    else
                    {
                        MessageBox.Show("Error with data or Alredy Exsist....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else { /*Do nothing*/}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to clear the results added?", "Confirm data Clearing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            for (int i = 0; i < DgvItineraryPlan.Rows.Count; i++)
            {
                if (DgvItineraryPlan.Rows[i].DefaultCellStyle.BackColor == Color.LimeGreen)
                {
                    if (result == DialogResult.Yes)
                    {
                        DgvItineraryPlan.Rows.Clear();
                    }
                }
                else
                {
                    if (result == DialogResult.Yes)
                    {
                        DgvItineraryPlan.Rows.Clear();
                    }
                }
            }
        }

        private void GenarateItineraryPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            _itinerarySeries.GetSeriesInToGrid();
        }

        private void DgvGenerateItinaryDeleteEdit_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        //Insert

    }
}
