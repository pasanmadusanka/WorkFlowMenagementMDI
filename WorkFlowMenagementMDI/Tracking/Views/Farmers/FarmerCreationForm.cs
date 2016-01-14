using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Farmers;

namespace WorkFlowMenagementMDI.Tracking.Views.Farmers
{
    public partial class FarmerCreationForm : Form
    {
        FarmersCreationMethods db = new FarmersCreationMethods();
        public FarmerCreationForm()
        {
            InitializeComponent();
        }

        public void GridRefresh()
        {
            DataSet ds = db.GetFarmerToGrid(@"SELECT GPS_FRM_lOC_ID as ID, mast.FAR_HDR_MST_CODE+' - '+mast.FAR_HDR_MST_NAME [Farmer Name], GPS_FRM_LOC_LATITUDE as Latitude, 
        GPS_FRM_LOC_LONGITUDE as Longitude, fo.FLD_OFF_MST_NAME as Officer, area.AREA_MST_NAME as Area
        FROM GPS_FARM_LOCATION_MASTER as farm inner join 
        FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
        GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
        FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join 
        AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE
        order by farm.GPS_FRM_lOC_ID desc");
            DgvFarmers.DataSource = ds.Tables["farmerDetails"].DefaultView;
        }

        public void SearchRes(string query)
        {
            DataSet ds = db.GetFarmerSerchGrid(query);
            DgvFarmers.DataSource = ds.Tables["farmersearchDetails"].DefaultView;
        }
        private void FarmerCreationForm_Load(object sender, EventArgs e)
        {
            GetfarmerToCombo();
            GridRefresh();
            GetFieldOffCombo();
            GetAreaToCombo();
            RBCreate.Checked = true;
            ToolTip tip = new ToolTip();
            tip.SetToolTip(BtnImportExcel, "Export to excel");
            tip.SetToolTip(ChkEnableSearch, "Check to enable search");
            CmbFarmer.Select();
        }
        #region Populate Combo boxes
        public void GetfarmerToCombo()
        {
            DataTable dt = db.FarmerHeaderToCMB();
            CmbFarmer.ValueMember = "id";
            CmbFarmer.DisplayMember = "name";
            CmbFarmer.DataSource = dt;
            CmbFarmer.SelectedItem = null;
        }
        public void GetFieldOffCombo()
        {
            DataTable dt = db.GetFieldOfficersCombo();
            CmbFOfficer.ValueMember = "id";
            CmbFOfficer.DisplayMember = "name";
            CmbFOfficer.DataSource = dt;
            CmbFOfficer.SelectedItem = null;
        }

        public void GetAreaToCombo()
        {
            DataTable dt = db.GetAreaToCombo();
            CmbFrmArea.ValueMember = "id";
            CmbFrmArea.DisplayMember = "area";
            CmbFrmArea.DataSource = dt;
            CmbFrmArea.SelectedItem = null;
        }
        #endregion
        private void DgvFarmers_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                RBEdit.Checked = true;
                BtnAdd.Enabled = false;
                BtnUpdate.Enabled = true;
                LblId.Text = DgvFarmers.Rows[e.RowIndex].Cells[0].Value.ToString();
                CmbFarmer.Text = DgvFarmers.Rows[e.RowIndex].Cells[1].Value.ToString();
                //TxtFarmerArea.Text = DgvFarmers.Rows[e.RowIndex].Cells[3].Value.ToString();
                TxtFarmerLat.Text = DgvFarmers.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtFarmarLon.Text = DgvFarmers.Rows[e.RowIndex].Cells[3].Value.ToString();
                CmbFOfficer.Text = DgvFarmers.Rows[e.RowIndex].Cells[4].Value.ToString();
                CmbFrmArea.Text = DgvFarmers.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error"); }
        }//Row Double click

        private void RBCreate_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = true;
            BtnUpdate.Enabled = false;
            TextBoxClearEvent(); 
            CmbFarmer.Focus();
        }

        public void TextBoxClearEvent()
        {
            TxtFarmerLat.Clear();
            TxtFarmarLon.Clear();
            CmbFOfficer.SelectedItem = null;
            CmbFarmer.SelectedItem = null;
            CmbFrmArea.SelectedItem = null;
        }

        private void RBEdit_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
        }
        
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?...", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int fName = Convert.ToInt32(CmbFarmer.SelectedValue);
                    double latitude = Convert.ToDouble(TxtFarmerLat.Text);
                    double longitude = Convert.ToDouble(TxtFarmarLon.Text);
                    int fieldOffID = Convert.ToInt32(CmbFOfficer.SelectedValue);
                    int areaID = Convert.ToInt32(CmbFrmArea.SelectedValue);

                    if (db.InsertNewFarmer(fName, latitude, longitude, fieldOffID, areaID))
                    {
                        MessageBox.Show("Record Sucessfully Added", "Record Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        GridRefresh();
                        TextBoxClearEvent();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                { MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LblId.Text); 
                int name = Convert.ToInt32(CmbFarmer.SelectedValue); double latitude = Convert.ToDouble(TxtFarmerLat.Text);
                double longitude = Convert.ToDouble(TxtFarmarLon.Text);
                int fieldOffID = Convert.ToInt32(CmbFOfficer.SelectedValue); int areaName = Convert.ToInt32(CmbFrmArea.SelectedValue);
                if (db.UpdateFarmer(id, name, latitude, longitude, fieldOffID, areaName))
                {
                    MessageBox.Show("Record " + LblId.Text + " Sucessfully Updated!", "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    GridRefresh(); TextBoxClearEvent(); RBCreate.Checked = true; 
                }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            /*try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete the Record \"" + LblId.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteFarmer(Convert.ToInt32(LblId.Text)))
                    {
                        MessageBox.Show("Record has been Deleted....!", "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        GridRefresh();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record " + LblId.Text + " Not Deleted", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); } */
        }

        #region Search bar
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = @"SELECT GPS_FRM_lOC_ID as ID, mast.FAR_HDR_MST_CODE+' - '+mast.FAR_HDR_MST_NAME [Farmer Name], GPS_FRM_LOC_LATITUDE as Latitude, 
        GPS_FRM_LOC_LONGITUDE as Longitude, fo.FLD_OFF_MST_NAME as Officer, area.AREA_MST_NAME as Area
        FROM GPS_FARM_LOCATION_MASTER as farm inner join 
        FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
        GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
        FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join 
        AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE ";

            if (RBNameSearch.Checked == true)
            {
                SearchRes(query + @" where mast.FAR_HDR_MST_NAME like '%" + CMBSearch.Text + "%' order by [Farmer Name]");
            }
            else if (RBCodeSearch.Checked == true)
            {
                SearchRes(query + @" where mast.FAR_HDR_MST_CODE like '%" + CMBSearch.Text + "%' order by [Farmer Name]");
            }
            else if (RBAreaSearch.Checked == true)
            {
                SearchRes(query + @" where area.AREA_MST_NAME like '%" + CMBSearch.Text + "%' order by Area");
            }
        }

        public void SearchCombo(string quer, string name)
        {
            CMBSearch.DataBindings.Clear();
            CMBSearch.DataSource = null;
            DataTable dt = db.SearchComboBox(quer, name);
            CMBSearch.DisplayMember = "name";
            CMBSearch.DataSource = dt;
            CMBSearch.SelectedItem = null;
        }
        private void RBNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            SearchCombo(@"SELECT mast.FAR_HDR_MST_NAME FROM GPS_FARM_LOCATION_MASTER as farm inner join 
FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO order by farm.GPS_FRM_lOC_ID", "FAR_HDR_MST_NAME");
            CMBSearch.Focus();
        }
        private void RBCodeSearch_CheckedChanged(object sender, EventArgs e)
        {
            SearchCombo(@"SELECT mast.FAR_HDR_MST_CODE FROM GPS_FARM_LOCATION_MASTER as farm inner join 
FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO order by FAR_HDR_MST_CODE", "FAR_HDR_MST_CODE");
            CMBSearch.Focus();
        }
        private void RBAreaSearch_CheckedChanged(object sender, EventArgs e)
        {
            SearchCombo(@"SELECT distinct area.AREA_MST_NAME FROM GPS_FARM_LOCATION_MASTER as farm inner join
            AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE order by AREA_MST_NAME", "AREA_MST_NAME");
            CMBSearch.Focus();
        }
        private void ChkEnableSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnableSearch.Checked == true)
            {
                CMBSearch.Enabled = true; GBSearchCat.Enabled = true;
                BtnSearch.Enabled = true; RBNameSearch.Checked = true;
                SearchCombo(@"SELECT mast.FAR_HDR_MST_NAME FROM GPS_FARM_LOCATION_MASTER as farm inner join 
FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO order by farm.GPS_FRM_lOC_ID", "FAR_HDR_MST_NAME");
            }
            else
            {
                CMBSearch.Enabled = false; GBSearchCat.Enabled = false; BtnSearch.Enabled = false;
                GridRefresh();
            }
        }
        #endregion
        /// <summary>
        /// Copy all Details on Grid To Excel
        /// </summary>
        private void copyAlltoClipboard()
        {
            DgvFarmers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvFarmers.SelectAll();
            DataObject dataObj = DgvFarmers.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }//Make the copy to Clipbord
        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }//Open Excel and Past it
        private void CMBSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
                e.Handled = true;
            }
        }

        private void CmbFarmer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFarmer.SelectedValue != null)
                {
                    CmbFrmArea.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer Name' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbFrmArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFrmArea.SelectedValue != null)
                {
                    TxtFarmerLat.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer Area' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtFarmerLat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value = TxtFarmerLat.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    e.Handled = true;
                    TxtFarmarLon.Focus();
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer Latitude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtFarmarLon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value = TxtFarmarLon.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    e.Handled = true;
                    CmbFOfficer.Focus();
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer Longitude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbFOfficer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFOfficer.SelectedValue != null)
                {
                    if (RBCreate.Checked == true)
                    {
                        BtnAdd_Click(sender, e);
                        e.Handled = true;
                        CmbFarmer.Select();
                    }
                    else if (RBEdit.Checked == true)
                    {
                        BtnUpdate_Click(sender, e);
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Fill the 'Field Officer' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DgvFarmers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //DataGridViewCellEventArgs e1=new DataGridViewCellEventArgs(e)
            if (Properties.Settings.Default.LastUser.ToLower() != "admin")
            {
                MessageBox.Show("You are not allow to delete", "Farmers location details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                GridRefresh();
            }
            else if (Properties.Settings.Default.LastUser.ToLower() == "admin")
            {
                DialogResult usersChoice = MessageBox.Show(@"You are about to delete " + DgvFarmers.SelectedRows.Count
                    + " Row(s).\n\n \r Click Yes to permanently delete these rows. You won’t be able to undo these changes.",
                "Farmers location details", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // cancel the delete event
                if (usersChoice == DialogResult.No)
                { e.Cancel = true; }

                else if (usersChoice == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DgvFarmers.Rows[0].Cells[0].Value);
                    //int id=DgvFuelStock.SelectedCells[0].RowIndex.Cells[0].Value.ToString();
                    object val = DgvFarmers.SelectedRows[0].Cells[0].Value;
                    int value = Convert.ToInt32(val);
                    if (db.DeleteFarmer(value))
                    {
                    }
                    else { MessageBox.Show("Somthing went wrong"); }
                    MessageBox.Show("Record has been deleted");
                }
            }
        }
    }
}
