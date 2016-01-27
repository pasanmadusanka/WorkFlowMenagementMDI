using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Customers; 

namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    public partial class CustomerCreations : Form
    {
        CustomerLocationCreationMethods db = new CustomerLocationCreationMethods();

        public CustomerCreations()
        {
            InitializeComponent();
        }

        public void GridViewLoad()
        {
            DataSet ds = db.GetCustomerToGrid();
            DgvCustomers.DataSource = ds.Tables["custLocation"].DefaultView;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int customerID = Convert.ToInt32(CmbCustID.SelectedValue);
                    string area = TxtAreaName.Text;
                    double latitude = Convert.ToDouble(TxtCustLat.Text);
                    double longitude = Convert.ToDouble(TxtCustLon.Text);
                    int deviceID = Convert.ToInt32(CmbVhiID.SelectedValue);
                    string days = CmbDaysOfWeek.Text; int repID = Convert.ToInt32(CmbSalesRep.SelectedValue);
                    if (db.InsertNewCustomer(customerID, area, deviceID, latitude, longitude, repID, days))
                    {
                        MessageBox.Show("Record Sucessfully Added", "Record Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        GridViewLoad(); TextBoxClearEvent(); CmbCustID.Focus();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                { MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        #region Populating the combo boxes
        public void LoadCustomerCombo()
        {
            System.Data.DataTable dtcust = db.GetChatAccCustomer();
            CmbCustID.ValueMember = "id";
            CmbCustID.DisplayMember = "custName";
            CmbCustID.DataSource = dtcust;
            CmbCustID.SelectedItem = null;
        }

        public void LoadSalesRepCombo()
        {
            System.Data.DataTable dtRep = db.GetSalesRep();
            CmbSalesRep.ValueMember = "id";
            CmbSalesRep.DisplayMember = "repName";
            CmbSalesRep.DataSource = dtRep;
            CmbSalesRep.SelectedItem = null;
        }

        public void LoadVehicleCombo()
        {
            DataTable dt = db.GetGPSDeviceID();
            CmbVhiID.ValueMember = "id";
            CmbVhiID.DisplayMember = "vhiNO";
            CmbVhiID.DataSource = dt;
            CmbVhiID.SelectedItem = null;
        }
        #endregion

        private void CustomerCreations_Load(object sender, EventArgs e)
        {
            LoadCustomerCombo();
            LoadVehicleCombo();
            GridViewLoad();
            LoadSalesRepCombo();
            CmbCustID.Select();
            ToolTip tip = new ToolTip();
            tip.SetToolTip(BtnExcel,"Export to excel");
            tip.SetToolTip(ChkEnableSearch, "Check to enable search");
        }

        private void DgvCustomers_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                LblId.Text = DgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                CmbCustID.Text = DgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString() + " - " + DgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtAreaName.Text = DgvCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                CmbVhiID.Text = DgvCustomers.Rows[e.RowIndex].Cells[5].Value.ToString();
                CmbDaysOfWeek.Text = DgvCustomers.Rows[e.RowIndex].Cells[6].Value.ToString();
                TxtCustLat.Text = DgvCustomers.Rows[e.RowIndex].Cells[8].Value.ToString();
                TxtCustLon.Text = DgvCustomers.Rows[e.RowIndex].Cells[9].Value.ToString();
                CmbSalesRep.Text = DgvCustomers.Rows[e.RowIndex].Cells[7].Value.ToString();
                RBEdit.Checked = true;
                BtnAdd.Enabled = false;
                BtnUpdate.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Customers Table"); }
        }

        private void RBCreate_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = true;
            BtnUpdate.Enabled = false;
            TextBoxClearEvent();
            CmbCustID.Focus();
        }

        public void TextBoxClearEvent()
        {
            TxtAreaName.Clear();
            TxtCustLat.Clear();
            TxtCustLon.Clear();
            CmbCustID.SelectedItem = null;
            CmbVhiID.SelectedItem = null;
            CmbVhiID.SelectedItem = null;
            LblId.Text = "";
        }

        private void RBEdit_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LblId.Text);
                string days = CmbDaysOfWeek.Text;
                int repID = Convert.ToInt32(CmbSalesRep.SelectedValue);
                if (db.UpdateCustomer(id, Convert.ToInt32(CmbCustID.SelectedValue), TxtAreaName.Text, Convert.ToInt32(CmbVhiID.SelectedValue),
                    Convert.ToDouble(TxtCustLat.Text), Convert.ToDouble(TxtCustLon.Text), repID, days))
                {
                    MessageBox.Show("Record " + LblId.Text + " Sucessfully Updated!", "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    GridViewLoad(); TextBoxClearEvent();
                }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message + " Error select a row you want to update", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult result = MessageBox.Show("Do you really want to delete the Record \"" + LblId.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (db.DeleteCustomer(Convert.ToInt32(LblId.Text)))
            //        {
            //            MessageBox.Show("Record has been Deleted....!", "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //            GridViewLoad(); TextBoxClearEvent();
            //        }
            //        else
            //            MessageBox.Show("Sorry Somthing is Wrong.....!");
            //    }
            //    else
            //        MessageBox.Show("Record " + LblId.Text + " Not Deleted", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            //}
            //catch (Exception ex) { MessageBox.Show("Record Not Deleted " + ex.Message + " Please select the row you want to delete....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2); }
        }

        private void CmbCustID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbCustID.SelectedItem != null)
                {
                    TxtAreaName.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Customer' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtAreaName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtAreaName.Text != "")
                {
                    CmbVhiID.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Customer Area' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbVhiID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbVhiID.SelectedItem != null)
                {
                    CmbSalesRep.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the 'Vehicle No' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void TxtCustLat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value = TxtCustLat.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    TxtCustLon.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Customer Latitude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtCustLon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string value = TxtCustLon.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    if (RBCreate.Checked == true)
                    {
                        BtnAdd_Click(sender, e);
                        e.Handled = true;
                    }
                    else if (RBEdit.Checked == true)
                    {
                        BtnUpdate_Click(sender, e);
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Fill the 'Customer Longotude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbSalesRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbSalesRep.SelectedItem != null)
                {
                    TxtCustLat.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the 'Sales Rep' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        #region Search Items hear
        public void SearchCombo(string quer, string name)
        {
            DataTable dt = db.SearchComboBox(quer, name);
            CMBSearch.DisplayMember = "name";
            CMBSearch.DataSource = dt;
            CMBSearch.SelectedItem = null;
        }

        private void ChkEnableSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkEnableSearch.Checked == true)
            {
                CMBSearch.Enabled = true; GBSearchCat.Enabled = true;
                BtnSearch.Enabled = true; RBNameSearch.Checked = true;
                SearchCombo(@"Select cus.CHT_ACC_NAME from GPS_CUSTOMER_LOCATION_MASTER as gpscus inner join 
                CHART_ACC as cus on gpscus.GPS_CUST_CHART_ACC_ID=cus.CHT_ACC_ACC_NO order by cus.CHT_ACC_NAME", "CHT_ACC_NAME");
            }
            else
            {
                CMBSearch.Enabled = false; GBSearchCat.Enabled = false; BtnSearch.Enabled = false;
                GridViewLoad();
            }
        }

        public void SearchRes(string query)
        {
            try
            {
                DataSet ds = db.GetCustomerSerchGrid(query);
                DgvCustomers.DataSource = ds.Tables["CusSearchDetails"].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string query = @"Select  GPS_CUST_ID as ID, cus.CHT_ACC_ALIAS as Alias,
                cus.CHT_ACC_NAME as Name,cusgroup.ACC_GRP_GRP_NAME as [Group], GPS_CUST_AREA as Area,vmas.VHC_MST_NO as [Vehicle No],[GSP_CUST_ROUT_DAY] as Day, locemp.LOC_LOC_SH_CODE + ' - ' + locemp.LOC_LOC_NAME as [Sales Rep], GPS_CUST_LATITUDE as Latitude, GPS_CUST_LONGITUDE as Longitude
                from GPS_CUSTOMER_LOCATION_MASTER as gpscus inner join 
		        GPS_TRACKING_VEHICLE_DEVICE as vehi on gpscus.GPS_CUST_DEVISE_ID=vehi.VhiTrackerID inner join
                VEHICLE_MASTER as vmas on vehi.VehicleID=vmas.VHC_MST_CODE inner join 
				CHART_ACC as cus on gpscus.GPS_CUST_CHART_ACC_ID=cus.CHT_ACC_ACC_NO inner join
                ACC_GROUP as cusgroup on cus.CHT_ACC_GROUP_CODE=cusgroup.ACC_GRP_GRP_CODE inner join 
				LOCATION as locemp on gpscus.GPS_CUST_SALES_REP_ID=locemp.LOC_LOC_CODE ";

            if (RBNameSearch.Checked == true)
            {
                SearchRes(query + " where cus.CHT_ACC_NAME like '" + CMBSearch.Text + "%' order by cus.CHT_ACC_NAME");
            }
            else if (RBCodeSearch.Checked == true)
            {
                SearchRes(query + " where cus.CHT_ACC_ALIAS like '" + CMBSearch.Text + "%'	order by cus.CHT_ACC_ALIAS");
            }
            else if (RBAreaSearch.Checked == true)
            {
                SearchRes(query + " where GPS_CUST_AREA like '" + CMBSearch.Text + "%'	order by GPS_CUST_AREA");
            }
            else if (RBDaySearch.Checked == true)
            {
                SearchRes(query + " where GSP_CUST_ROUT_DAY like '" + CMBSearch.Text + "%'	order by GSP_CUST_ROUT_DAY");
            }
            else if (RbRepSearch.Checked == true)
            {
                SearchRes(query + " where locemp.LOC_LOC_SH_CODE + ' - ' + locemp.LOC_LOC_NAME like '" + CMBSearch.Text + "%'	order by GSP_CUST_ROUT_DAY");
            }
        }//Search Button click events

        private void RBNameSearch_CheckedChanged(object sender, EventArgs e)
        {
            CMBSearch.DataSource = null;
            SearchCombo(@"Select cus.CHT_ACC_NAME from GPS_CUSTOMER_LOCATION_MASTER as gpscus inner join 
                CHART_ACC as cus on gpscus.GPS_CUST_CHART_ACC_ID=cus.CHT_ACC_ACC_NO order by cus.CHT_ACC_NAME", "CHT_ACC_NAME");
        }

        private void RBCodeSearch_CheckedChanged(object sender, EventArgs e)
        {
            CMBSearch.DataSource = null;
            SearchCombo(@"Select cus.CHT_ACC_ALIAS  from GPS_CUSTOMER_LOCATION_MASTER as gpscus inner join 
                CHART_ACC as cus on gpscus.GPS_CUST_CHART_ACC_ID=cus.CHT_ACC_ACC_NO order by cus.CHT_ACC_ALIAS ", "CHT_ACC_ALIAS");
        }

        private void RBAreaSearch_CheckedChanged(object sender, EventArgs e)
        {
            CMBSearch.DataSource = null;
            SearchCombo(@"SELECT DISTINCT GPS_CUST_AREA FROM GPS_CUSTOMER_LOCATION_MASTER", "GPS_CUST_AREA");
        }

        private void RBDaySearch_CheckedChanged(object sender, EventArgs e)
        {
            CMBSearch.DataSource = null;
            SearchCombo(@"SELECT DISTINCT GSP_CUST_ROUT_DAY FROM GPS_CUSTOMER_LOCATION_MASTER ", "GSP_CUST_ROUT_DAY");
        }

        private void RbRepSearch_CheckedChanged(object sender, EventArgs e)
        {
            CMBSearch.DataBindings.Clear();
            CMBSearch.DataSource = null;
            DataTable dtRep = db.GetSalesRep();
            CMBSearch.ValueMember = "id";
            CMBSearch.DisplayMember = "repName";
            CMBSearch.DataSource = dtRep;
            CMBSearch.SelectedItem = null;
        }

        private void CMBSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
        #endregion

        private void CustomerCreations_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        /// <summary>
        /// Copy all Details on Grid To Excel
        /// </summary>
        private void copyAlltoClipboard()
        {
            DgvCustomers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvCustomers.SelectAll();
            DataObject dataObj = DgvCustomers.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }//Make the copy to Clipbord
        private void BtnExcel_Click(object sender, EventArgs e)
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

        private void DgvCustomers_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //DataGridViewCellEventArgs e1=new DataGridViewCellEventArgs(e)
            if (Properties.Settings.Default.LastUser.ToLower() != "admin")
            {
                MessageBox.Show("You are not allow to delete", "Customers tracking details", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                GridViewLoad();
            }
            else if (Properties.Settings.Default.LastUser.ToLower() == "admin")
            {
                DialogResult usersChoice = MessageBox.Show(@"You are about to delete " + DgvCustomers.SelectedRows.Count
                    + " Row(s).\n\n \r Click Yes to permanently delete these rows. You won’t be able to undo these changes.",
                "Customers tracking details", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // cancel the delete event
                if (usersChoice == DialogResult.No)
                { e.Cancel = true; }

                else if (usersChoice == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DgvCustomers.Rows[0].Cells[0].Value);
                    //int id=DgvFuelStock.SelectedCells[0].RowIndex.Cells[0].Value.ToString();
                    object val = DgvCustomers.SelectedRows[0].Cells[0].Value;
                    int value = Convert.ToInt32(val);
                    if (db.DeleteCustomer(value))
                    { MessageBox.Show("Record has been deleted"); LblId.Text = ""; }
                }
            }
        }


    }
}
