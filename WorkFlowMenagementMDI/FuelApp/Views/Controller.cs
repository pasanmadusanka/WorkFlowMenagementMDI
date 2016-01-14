using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;

namespace WorkFlowMenagementMDI.FuelApp.Views
{
    public partial class Controller : Form
    {
        int lastUserID = Properties.Settings.Default.UserID;
        private string _id;

        ControllerMethods db = new ControllerMethods();
        GetAvalableStockClass getStock = new GetAvalableStockClass();
        AdminToControllerDataMethod dataFrmMain = new AdminToControllerDataMethod();

        private Admin_Controller _mainForm;


        System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();

        public Controller()
        {
            InitializeComponent();
        }

        public Controller(string id, Admin_Controller mainform)
        {
            //GetIssuePerson(); 
            //BtnSave.Enabled = false;
            this._id = id;
            this._mainForm = mainform;
            InitializeComponent();
            GetDataFromMainForm(_id);
        }//get all from the grid

        public void GetDataFromMainForm(string id)
        {
            GetIssuePerson();
            GetVehicle();
            GetSecqurityPerson();
            DataTable dt = dataFrmMain.GetSelectedUserToControl(id);
            DataRow dr = dt.Rows[0];
            LblId.Text = id.ToString();
            CmbItem.Text = dr[0].ToString();
            DTPTime.Value = Convert.ToDateTime(dr[2].ToString());
            try { DTPSetDate.Value = Convert.ToDateTime(dr[1].ToString()); }
            catch { MessageBox.Show("Problem with Date (Setdate).....!"); }
            //CmbLocation.Text = dr[3].ToString();
            CmbVehicleNumber.Text = dr[5].ToString();
            CmbIssuePerson.Text = dr[6].ToString();
            TxtDieselQty.Text = dr[7].ToString();
            TxtStartFuelMeter.Text = dr[8].ToString();
            TxtEndFuelMeter.Text = dr[9].ToString();
            TxtMillageNew.Text = dr[4].ToString();
            CmbSecqurityPerson.Text = dr[10].ToString();
            TxtBillNo.Text = dr[11].ToString();
            CmbAuthorizePerson.Text = dr[12].ToString();
            BtnSave.Enabled = false;
        }//fill the places with grid details

        public Controller(Admin_Controller mainform)
        {
            this._mainForm = mainform;
            InitializeComponent();

            GetIssuePerson();
            GetVehicle();
            GetSecqurityPerson();

            CmbIssuePerson.SelectedItem = null;

            CmbVehicleNumber.SelectedItem = null;
            TxtPriviousMillage.Clear();
            CmbSecqurityPerson.SelectedItem = null;

            GetStartMeter();
            FillLastIndex();

        }//pass the credential

        private void Controller_Load(object sender, EventArgs e)
        {
            try
            {
                CustomezeDateTimePicker();
                AllLoadEvents();
                ToolTip();
            }
            catch { MessageBox.Show("Error with loading form.....!"); }
            GetFinalFuelStock();
        }

        #region Get Avalable Stock for fuel weediyawattha
        public double GetFuelStock()//FromProcedure PRN_GEN_STOCK_BALANCE_INDIVIDUAL
        {
            double genStock;
            string stock = getStock.GetAvalableStock(16111, 130);
            genStock = Convert.ToDouble(stock);
            return genStock;
        }

        public double GetFuelStkByDate()// From Procedure PRN_GEN_STOCK_BALANCE_AS_AT
        {
            double genStock;
            string stock = getStock.GetAvalableStkByDate(DTPSetDate.Value.Date.ToString("MM/dd/yyyy"), DTPSetDate.Value.Date.ToString("MM/dd/yyyy"));
            genStock = Convert.ToDouble(stock);
            return genStock;
        }//2920
        public double GetSumOfFuel()
        {
            double fuelSum = Convert.ToDouble(getStock.GetSumNotSubmit());
            return fuelSum;
        }//Get Sum

        public void GetFinalFuelStock()//For Table FUEL_TMP_STOCK_MOVEMENT_TB
        {
            double finalAvStock = GetFuelStock() - GetSumOfFuel();
            if (finalAvStock > 5000)
            {
                TxtRemaindval.ForeColor = Color.Blue;
                TxtRemaindval.Text = finalAvStock.ToString();
            }
            else if (finalAvStock < 5000)
            {
                TxtRemaindval.ForeColor = Color.Red;
                TxtRemaindval.Text = finalAvStock.ToString();
            }
        }

        public void InsertToFuelStockMovement()
        {
            double finalAvStock = GetFuelStock() - GetSumOfFuel() + Convert.ToDouble(TxtDieselQty.Text);
            //label14.Text = finalAvStock.ToString();
            if (db.AddFuelStkMovement(TxtBillNo.Text, finalAvStock, Convert.ToDouble(TxtDieselQty.Text), lastUserID))
            { /*MessageBox.Show("Record Sucessfully Added", "Record ");*/}
            else { MessageBox.Show("Sorry Somthing is Wrong!.. Couldent save Stock Movement...", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }//Insert into stock movement table FUEL_TMP_STOCK_MOVEMENT_TB

        public void InsertToFuelByDateTB()
        {
            double finalStkByDate = GetFuelStkByDate() - GetSumOfFuel() + Convert.ToDouble(TxtDieselQty.Text);
            if (db.AddNewToStkMovementByDat(TxtBillNo.Text, finalStkByDate, Convert.ToDouble(TxtDieselQty.Text), lastUserID)) { }
            else { MessageBox.Show("Sorry Somthing is Wrong!.. Couldent save Stock Movement...", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
        public void CustomezeDateTimePicker()
        {
            DTPSetDate.Format = DateTimePickerFormat.Custom;
            DTPSetDate.CustomFormat = "dd/MM/yyyy";

            DTPTime.Format = DateTimePickerFormat.Custom;
            DTPTime.CustomFormat = "hh:mm:ss tt";
        }
        public void AllLoadEvents()
        {
            GetItem();
            GetAuthorizePerson();
            ButtonProperty();

            DataTable dt = db.FillLastMeterCounNIndexNReference();
            DataRow row = dt.Rows[0];

            int docindex = Convert.ToInt32(row[1].ToString()) + 1;

            LblNewIndex.Text = docindex.ToString();
        }
        public void ToolTip()
        {
            ToolTip1.SetToolTip(this.BtnSave, "Save Details");
            ToolTip1.SetToolTip(this.BtnClose, "Exit From Controller");
            ToolTip1.SetToolTip(this.CmbIssuePerson, "Driver Name");
            ToolTip1.SetToolTip(this.TxtStartFuelMeter, "Open fuel meter");
            ToolTip1.SetToolTip(this.TxtEndFuelMeter, "End fuel meter");
        }//Tool Tip Text

        #region Populate all the combo boxes
        public void GetIssuePerson()
        {
            DataTable dt1 = db.FillEmployee();
            CmbIssuePerson.ValueMember = "code";
            CmbIssuePerson.DisplayMember = "name";
            CmbIssuePerson.DataSource = dt1;
        }//get issue person to combo

        public void GetSecqurityPerson()
        {
            DataTable dt = db.FillSecqurityPerson();
            CmbSecqurityPerson.ValueMember = "code";
            CmbSecqurityPerson.DisplayMember = "name";
            CmbSecqurityPerson.DataSource = dt;
        }

        public void GetAuthorizePerson()
        {
            DataTable dt1 = db.FillAthorizedPerson();
            CmbAuthorizePerson.ValueMember = "code";
            CmbAuthorizePerson.DisplayMember = "name";
            CmbAuthorizePerson.DataSource = dt1;
        }
        public void GetLocation()
        {
            DataTable dt = db.FillLoocation(Convert.ToInt32(CmbVehicleNumber.SelectedValue));
            CmbLocation.ValueMember = "id";
            CmbLocation.DisplayMember = "name";
            CmbLocation.DataSource = dt;
        }

        public void GetVehicle()
        {
            DataTable dt = db.FillVehicleNumber();
            CmbVehicleNumber.ValueMember = "id";
            CmbVehicleNumber.DisplayMember = "VNumber";
            CmbVehicleNumber.DataSource = dt;
        }

        public void GetItem()
        {
            DataTable dt = db.FillItem();
            CmbItem.ValueMember = "id";
            CmbItem.DisplayMember = "itemName";
            CmbItem.DataSource = dt;
        }
        #endregion
        private void CmbVehicleNumber_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetLocation();
            TxtMillageNew.Clear();
            LoadVhiMeter(Convert.ToInt32(CmbVehicleNumber.SelectedValue));
        }

        public void LoadVhiMeter(int vID)
        {
            TxtPriviousMillage.Text = db.FillLastMillageCount(vID);
        }
        public void GetStartMeter()
        {
            try
            {
                DataTable dt = db.FillLastMeterCounNIndexNReference();
                DataRow row = dt.Rows[0];

                TxtStartFuelMeter.Text = (row[0].ToString());
            }
            catch (Exception ex)
            { MessageBox.Show("Somthing is wrong " + ex.ToString()); }

        }

        public void FillLastIndex()
        {
            try
            {
                DataTable dt = db.FillLastMeterCounNIndexNReference();
                DataRow row = dt.Rows[0];
                int lastIndex = Convert.ToInt32(row[2]) + 1;
                TxtBillNo.Text = lastIndex.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show("Somthing is wrong " + ex.ToString()); }
        }

        public void GetVarience()
        {
            try
            {
                double DieselQuy, DieselStart, DieselEnd;
                DieselStart = Convert.ToDouble(TxtStartFuelMeter.Text);
                DieselEnd = Convert.ToDouble(TxtEndFuelMeter.Text);

                DieselQuy = DieselEnd - DieselStart;
                TxtDieselQty.Text = DieselQuy.ToString();
            }
            catch
            { Console.WriteLine("Enter some matching value to continue...."); }
        }//get the diffirence of the Diesel Qty

        private void TxtEndFuelMeter_TextChanged_1(object sender, EventArgs e)
        {

            string value = TxtEndFuelMeter.Text;
            double num;
            if (double.TryParse(value, out num))
            {
                GetVarience();
            }
            else
            { /*Do Noithing*/ }
            //InsertToFuelByDateTB();
        }
        #region All the button click evenet in Controller CRUD
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (Convert.ToDouble(TxtPriviousMillage.Text) <= Convert.ToDouble(TxtMillageNew.Text))
                    {
                        if (db.AddNewFuelDetails(Convert.ToInt32(CmbItem.SelectedValue), DTPSetDate.Value.Date.ToString("MM/dd/yyyy"), DTPTime.Value.ToString("hh:mm:ss tt"),
                            Convert.ToInt32(CmbLocation.SelectedValue), Convert.ToInt32(CmbVehicleNumber.SelectedValue), Convert.ToInt32(CmbIssuePerson.SelectedValue), TxtMillageNew.Text, Convert.ToDouble(TxtDieselQty.Text)
                            , Convert.ToDouble(TxtEndFuelMeter.Text), Convert.ToInt32(CmbSecqurityPerson.SelectedValue), lastUserID, TxtBillNo.Text))
                        {
                            MessageBox.Show("Record Sucessfully Added",
                "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                            //ReportViewMethord();

                            //InsertToFuelByDateTB();//Stock Movement Method

                            GetStartMeter();
                            TxtEndFuelMeter.Clear();
                            TxtDieselQty.Clear();

                            _mainForm.LoadGrid();
                            _mainForm.GetParentToTree();
                            GetFinalFuelStock();

                            CmbIssuePerson.SelectedItem = null;

                            CmbVehicleNumber.SelectedItem = null;

                            CmbSecqurityPerson.SelectedItem = null;
                            DTPSetDate.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button2);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vehicle mileage is wrong.! \n\n Mileage should be grater than previous mileage result.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        TxtMillageNew.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Item Didnt save....!", "Saving details",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Input strings was not in a correct format",
                        "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button2);
            }
        }

        public void ButtonProperty()
        {
            if (TxtMillageNew.Text.ToString() == "" && LblId.Text.ToString() == "")
            {
                BtnUpdate.Enabled = false;
                BtnDelete.Enabled = false;
            }
            else
            {
                if (Properties.Settings.Default.LastUser.ToLower() != "admin")
                {
                    BtnUpdate.Enabled = false;
                    BtnDelete.Enabled = false;
                }
                ToolTip1.IsBalloon = true;
                ToolTip1.SetToolTip(this.BtnUpdate, "Update Details");
                ToolTip1.SetToolTip(this.BtnDelete, "Delete Selected Details");
                GetDataFromMainForm(_id);
                TxtStartFuelMeter.Enabled = false;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.UpdateFuelDetails(LblId.Text, DTPSetDate.Value.Date.ToString("MM/dd/yyyy"),
                    DTPTime.Value.ToString("hh:mm:ss tt"), Convert.ToInt32(CmbLocation.SelectedValue),
                    Convert.ToInt32(CmbVehicleNumber.SelectedValue), Convert.ToInt32(CmbIssuePerson.SelectedValue),
                    TxtMillageNew.Text, Convert.ToDouble(TxtDieselQty.Text), Convert.ToDouble(TxtStartFuelMeter.Text),
                    Convert.ToDouble(TxtEndFuelMeter.Text), Convert.ToInt32(CmbSecqurityPerson.SelectedValue), TxtBillNo.Text.ToString(), lastUserID))
                {
                    MessageBox.Show("Record " + LblId.Text + " Sucessfully Updated!",
        "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    _mainForm.LoadGrid();
                    _mainForm.GetParentToTree();
                    this.Close();
                }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Admin_Controller admin = new Admin_Controller();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete the Record \"" + LblId.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteFuelDetails(LblId.Text))
                    {
                        MessageBox.Show("Record has been Deleted....!",
        "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        _mainForm.LoadGrid();
                        _mainForm.GetParentToTree();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record " + LblId.Text + " Not Deleted",
        "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!",
        "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }
        #endregion

        #region Enter key press key down events
        private void DTPSetDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPTime.Focus();
                e.Handled = true;
            }
        }

        private void DTPTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtBillNo.Focus();
                e.Handled = true;
            }
        }
        private void TxtBillNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CmbIssuePerson.Focus();
                e.Handled = true;
                //SelectNextControl(CmbIssuePerson, true, true, true, true);
            }
        }
        private void CmbIssuePerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbIssuePerson.SelectedItem != null)
                {
                    CmbSecqurityPerson.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the issue person to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CmbSecqurityPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbSecqurityPerson.SelectedItem != null)
                {
                    CmbVehicleNumber.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the Secqurity person to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
        private void CmbVehicleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbVehicleNumber.SelectedItem != null)
                {
                    TxtMillageNew.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the Vehicle Number to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }
        private void TxtMillage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtMillageNew.Text != "")
                {
                    if (Convert.ToDouble(TxtPriviousMillage.Text) <= Convert.ToDouble(TxtMillageNew.Text))
                    {
                        TxtEndFuelMeter.Focus();
                        e.Handled = true;
                    }
                    else { MessageBox.Show("Vehicle mileage is wrong.! \n\n Mileage should be grater than previous mileage result.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
                }
                else
                {
                    MessageBox.Show("Fill the Vehicle Millage to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        private void TxtEndFuelMeter_KeyDown(object sender, KeyEventArgs e)
        {
            string value = TxtEndFuelMeter.Text;
            double num;
            if (e.KeyCode == Keys.Enter)
            {
                if (double.TryParse(value, out num))
                {
                    if (BtnSave.Enabled == true)
                    {
                        BtnSave_Click(sender, e);
                    }
                    else if (BtnUpdate.Enabled == true && lastUserID == 1)
                    {
                        BtnUpdate_Click(sender, e);
                    }
                    //else 
                    //{
                    //    MessageBox.Show("Input Error '" + TxtEndFuelMeter.Text + "' \n\n \r Input cannot be Text value");
                    //}
                }
                else
                { MessageBox.Show("You cannot modify....!","Access error",MessageBoxButtons.OK,MessageBoxIcon.Hand); }

            }
        }

        private void Controller_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainForm.Enabled = true;
        }
    }
}
