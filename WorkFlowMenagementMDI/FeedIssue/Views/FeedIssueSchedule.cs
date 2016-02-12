using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Admin.Methods;
using WorkFlowMenagementMDI.FeedIssue.DBMethods;

namespace WorkFlowMenagementMDI.FeedIssue.Views
{
    public partial class FeedIssueSchedule : Form
    {
        const int AvgD1 = 4, AvgD2 = 10, AvgD3 = 11, AvgD4 = 14, AvgD5 = 21;
        GetFarmerDetails db = new GetFarmerDetails();
        FeedIssueScheduleMethods scheduleDB = new FeedIssueScheduleMethods();
        ToolTip dTips = new ToolTip();
        WorkFlowManageMethods privilege = new WorkFlowManageMethods();
        private string _farmer, _batch, _wk1In, _wk3In, _wk4In, _user;

        public FeedIssueSchedule()
        {
            InitializeComponent();
        }
        public void TipsofDate()
        {
            dTips.SetToolTip(this.DtpReqWeek2, "Second Week feed required date");
            dTips.SetToolTip(this.DtpReqWeek3, "Third Week feed required date");
            dTips.SetToolTip(this.DtpReqWeek4, "Forth Week feed required date");
            dTips.SetToolTip(this.DtpReqWeek5, "Fifth Week feed required date");
            dTips.SetToolTip(this.DtpReqWeek6, "Sixth Week feed required date");
            dTips.SetToolTip(this.CmbFarmer, "Farmer with code");
            dTips.SetToolTip(this.CmbFarmerBatch, "Farmer Batch code");
            dTips.SetToolTip(this.TxtInputWk1, "Week 1 Bosster input");
            dTips.SetToolTip(this.TxtInputWk2, "Week 2 Bosster input");
            dTips.SetToolTip(this.TxtInputWk3, "Week 3 Bosster input");
            dTips.SetToolTip(this.TxtInputWk4, "Week 4 Finisher input");
            dTips.SetToolTip(this.TxtInputWk5, "Week 5 Finisher input");
        }
        public FeedIssueSchedule(string farmer, string batch, string wk1In, string wk3In, string wk4In, string user)
        {
            this._farmer = farmer;
            this._batch = batch;
            this._wk1In = wk1In;
            this._wk3In = wk3In;
            this._wk4In = wk4In;
            this._user = user;

            InitializeComponent();
            EditViewOfFeedSchedule();
            BtnSave.Text = "Update";
            BtnSave.Update();
        }
        public void EditViewOfFeedSchedule()
        {
            GetfarmerToCombo();
            CmbFarmer.Text = _farmer;
            CmbFarmerBatch.Text = _batch;
            TxtInputWk1.Text = _wk1In;
            TxtInputWk3.Text = _wk3In;
            TxtInputWk4.Text = _wk4In;
            txtUser.Text = _user;
        }
        public void GetAvalableSchedules(int batch)
        {
            if (db.GetFeedInFinisherAndBooster(batch))
            {
                DataSet ds = db.ItemsSentToBatchTBL(batch);
                DgvAvalableBatch.DataSource = ds.Tables["feedIssue"].DefaultView;
                //MessageBox.Show(batch + " Search Proc Executed");
            }
        }
        #region Load information from the DB

        public void GetfarmerToCombo()
        {
            CmbFarmer.DataBindings.Clear();
            CmbFarmer.DataSource = null;
            DataTable dt = db.RetriveFarmerOnCombo();
            CmbFarmer.ValueMember = "id";
            CmbFarmer.DisplayMember = "name";
            CmbFarmer.DataSource = dt;
            CmbFarmer.SelectedItem = null;
        }
        public void GetfarmerBatchToCombo()
        {
            CmbFarmerBatch.DataBindings.Clear();
            CmbFarmerBatch.DataSource = null;
            DataTable dt = db.RetriveFarmerBatchOnCombo(Convert.ToInt32(CmbFarmer.SelectedValue));
            CmbFarmerBatch.ValueMember = "id";
            CmbFarmerBatch.DisplayMember = "name";
            CmbFarmerBatch.DataSource = dt;
            CmbFarmerBatch.SelectedItem = null;
        }
        public void CustomezeDateTimePicker()
        {
            DtpD1.Format = DateTimePickerFormat.Custom;
            DtpD1.CustomFormat = "dd/MM/yyyy";
            DtpD2.Format = DateTimePickerFormat.Custom;
            DtpD2.CustomFormat = "dd/MM/yyyy";
            DtpD3.Format = DateTimePickerFormat.Custom;
            DtpD3.CustomFormat = "dd/MM/yyyy";
            DtpD4.Format = DateTimePickerFormat.Custom;
            DtpD4.CustomFormat = "dd/MM/yyyy";
            DtpD5.Format = DateTimePickerFormat.Custom;
            DtpD5.CustomFormat = "dd/MM/yyyy";
            DtpReqWeek2.Format = DateTimePickerFormat.Custom;
            DtpReqWeek2.CustomFormat = "dd/MM/yyyy";
            DtpReqWeek3.Format = DateTimePickerFormat.Custom;
            DtpReqWeek3.CustomFormat = "dd/MM/yyyy";
            DtpReqWeek4.Format = DateTimePickerFormat.Custom;
            DtpReqWeek4.CustomFormat = "dd/MM/yyyy";
            DtpReqWeek5.Format = DateTimePickerFormat.Custom;
            DtpReqWeek5.CustomFormat = "dd/MM/yyyy";
            DtpReqWeek6.Format = DateTimePickerFormat.Custom;
            DtpReqWeek6.CustomFormat = "dd/MM/yyyy";

            DtpInputDat.Format = DateTimePickerFormat.Custom;
            DtpInputDat.CustomFormat = "dd/MM/yyyy";
        }
        private void FeedIssueSchedule_Load(object sender, EventArgs e)
        {
            GetfarmerToCombo();
            CustomezeDateTimePicker();
            TipsofDate();
        }
        private void CmbFarmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearText();
            GetfarmerBatchToCombo();
        }
        private void CmbFarmerBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetfarmerBatchDateToCombo();
            GetNoOfBirds();
            ClearText();
            GetAvalableSchedules(Convert.ToInt32(CmbFarmerBatch.SelectedValue));
        }
        public void GetfarmerBatchDateToCombo()
        {
            try
            {
                string date = db.GetBatchDate(Convert.ToInt32(CmbFarmerBatch.SelectedValue));

                string DateString = date.Substring(6, 4) + "|" + date.Substring(0, 2) + "|" + date.Substring(3, 2);

                DtpInputDat.Value = DateTime.ParseExact(DateString, "yyyy|MM|dd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);
            }
            catch {/* DtpBatchDate.Value = DateTime.ParseExact(DateString, "yyyy|MM|dd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None);*/ }
        }
        public void GetNoOfBirds()
        {
            try
            {
                string birds = db.GetBatchNoOfBirds(Convert.ToInt32(CmbFarmerBatch.SelectedValue));
                TxtBirdInput.Text = birds;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void CmbFarmer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFarmer.SelectedValue != null)
                {
                    CmbFarmerBatch.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer name' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void CmbFarmerBatch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFarmer.SelectedValue != null)
                {
                    TxtInputWk1.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Farmer batch' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtInputWk1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtInputWk1.Text != "" || TxtInputWk1.Text != "0")
                {
                    TxtInputWk3.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Week 1 input' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.KeyCode == Keys.Clear)
            {
                TxtInputWk1.Text = "0";
            }
        }

        private void TxtInputWk3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtInputWk3.Text != "" || TxtInputWk1.Text != "0")
                {
                    TxtInputWk4.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Week 3 input' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtInputWk4_KeyDown(object sender, KeyEventArgs e)
        {
            if (BtnSave.Visible == false)
            { /*Do nothing*/ }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BtnSave_Click(sender, e);
                    e.Handled = true;
                }
            }
        }
        #endregion
        private void BtnSave_Click(object sender, EventArgs e)
        {
            int outVal = privilege.GetUserAccessable("UTRW_CREATE", 3);
            if (outVal == 1)
            {
                InsertScheduleAddToTable();
            }
            else { MessageBox.Show("You dont have the privelages to Save this....!", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }
        public void ClearText()
        {
            TxtInputWk1.Text = "0";
            TxtInputWk2.Text = "0";
            TxtInputWk3.Text = "0";
            TxtInputWk4.Text = "0";
            TxtInputWk5.Text = "0";
        }//make inputs as 0
        public void InsertScheduleAddToTable()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    #region Input parameters for query
                    int batchNo = Convert.ToInt32(CmbFarmerBatch.SelectedValue);
                    double week1Input = Convert.ToDouble(TxtInputWk1.Text);
                    double week2Input = Convert.ToDouble(TxtInputWk2.Text);
                    double week3Input = Convert.ToDouble(TxtInputWk3.Text);
                    double week4Input = Convert.ToDouble(TxtInputWk4.Text);
                    double week5Input = Convert.ToDouble(TxtInputWk5.Text);
                    string week1 = DtpInputDat.Value.Date.ToString("MM/dd/yyyy");
                    string week2 = DtpReqWeek2.Value.Date.ToString("MM/dd/yyyy");
                    string week3 = DtpReqWeek3.Value.Date.ToString("MM/dd/yyyy");
                    string week4 = DtpReqWeek4.Value.Date.ToString("MM/dd/yyyy");
                    string week5 = DtpReqWeek5.Value.Date.ToString("MM/dd/yyyy");
                    #endregion

                    if (scheduleDB.InsertIntoFeedTemp(batchNo, week1Input, week2Input, week3Input, week4Input, week5Input, week1, week2, week3, week4, week5))
                    { MessageBox.Show("Record Sucessfully Added", "Record " + CmbFarmerBatch.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); }
                    else
                    { MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
                }
                else
                {
                    MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        #region Calculation part of the feed issue schedule
        public void GetDaysAferInput()
        {
            DtpD1.Value = DtpInputDat.Value.AddDays(0);
            DtpD2.Value = DtpInputDat.Value.AddDays(7);
            DtpD3.Value = DtpInputDat.Value.AddDays(14);
            DtpD4.Value = DtpInputDat.Value.AddDays(21);
            DtpD5.Value = DtpInputDat.Value.AddDays(28);
        }//After input of birds days supply feed

        private void TxtBirdInput_TextChanged(object sender, EventArgs e)
        {
            string value = TxtBirdInput.Text;
            double num;
            if (double.TryParse(value, out num))
            {
                GetDaysAferInput();
                LblW1In.Text = ((num * AvgD1) / 1000).ToString();
                LblW2In.Text = ((num * AvgD2) / 1000).ToString();
                LblW3In.Text = ((num * AvgD3) / 1000).ToString();
                LblW4In.Text = ((num * AvgD4) / 1000).ToString();
                LblW5In.Text = ((num * AvgD5) / 1000).ToString();
            }
            else
            {
                MessageBox.Show("Fill the 'Input Birds Amount' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DtpInputDat_ValueChanged(object sender, EventArgs e)
        {
            GetDaysAferInput();
        }

        public double ReturnFormulaRes(double weeksInput)
        {
            double val = 0;
            val = weeksInput / 7;
            return val;
        }

        public double TotalBoosterCount()
        {
            double wk1, wk2, wk3, totalBooster = 0;
            try
            {
                string val1 = TxtInputWk1.Text, val2 = TxtInputWk2.Text, val3 = TxtInputWk3.Text;
                if (double.TryParse(val1, out wk1) && double.TryParse(val2, out wk2) && double.TryParse(val3, out wk3))
                {
                    totalBooster = wk1 + wk2 + wk3;
                }
            }
            catch { TxtInputWk1.Clear(); }
            return totalBooster;//25
        }

        public double ActTotBoosterCount()
        {
            double maxBooster = 0;
            maxBooster = Convert.ToDouble(LblW1In.Text) + Convert.ToDouble(LblW2In.Text) + Convert.ToDouble(LblW3In.Text);
            return maxBooster;
        }//Get actual booster count

        public double TotalFinisherCount()
        {
            double wk4, wk5, totalFinisher = 0;
            try
            {
                wk4 = Convert.ToDouble(TxtInputWk4.Text);//14
                wk5 = Convert.ToDouble(TxtInputWk5.Text);//21
                totalFinisher = wk4 + wk5;
            }
            catch { TxtInputWk4.Text = "0"; }
            return totalFinisher;//35
        }

        public double ActTotFinishrCount()
        {
            double maxFinishr = 0;
            maxFinishr = Convert.ToDouble(LblW4In.Text) + Convert.ToDouble(LblW5In.Text);
            return maxFinishr;
        }//Get actual booster count

        public bool BoosterOverloded()
        {
            //ex for 1000 chicks -: 25=4+10+11
            bool status = false;
            if (TotalBoosterCount() > ActTotBoosterCount())
            { status = false; }
            else { status = true; }
            return status;
        }

        #endregion

        #region Text change events
        private void TxtInputWk1_TextChanged(object sender, EventArgs e)
        {
            string value = TxtInputWk1.Text;
            TxtInputWk2.Text = "0";
            double num, preDay;
            if (double.TryParse(value, out num) && LblW1In.Text != "0" && BoosterOverloded() || value != "")
            {
                double week1 = Convert.ToDouble(LblW1In.Text);//4
                double week2 = Convert.ToDouble(LblW2In.Text);//10
                if (num < week1)
                {
                    double formula = ReturnFormulaRes(week1);
                    preDay = num / ReturnFormulaRes(week1);
                    LblPreDay1.Text = preDay.ToString();
                    DtpReqWeek2.Value = DtpD1.Value.AddDays((int)preDay);
                    double newAvgD1 = week1 - num;
                    TxtInputWk2.Text = (week2 + newAvgD1).ToString();
                }
                else if (num > week1)
                { //if num=6
                    //double actualW1 = Convert.ToDouble(LblW1In.Text);
                    double formulaw1 = ReturnFormulaRes(week1);
                    double formulaw2 = ReturnFormulaRes(week2);
                    double amt = num - week1; //6-4=2
                    preDay = week1 / ReturnFormulaRes(week1);//7
                    double newPreday = amt / ReturnFormulaRes(week2);//1.4
                    LblPreDay1.Text = String.Format("{0:0.00}", (preDay + newPreday)).ToString();
                    //int y = Convert.ToInt32(preDay);
                    DtpReqWeek2.Value = DtpD1.Value.AddDays((int)Convert.ToDouble(LblPreDay1.Text));
                    double newAvgD1 = num - Convert.ToDouble(LblW1In.Text);
                    TxtInputWk2.Text = (Convert.ToDouble(LblW2In.Text) - newAvgD1).ToString();
                }
                else
                {
                    preDay = num / ReturnFormulaRes(week1);
                    LblPreDay1.Text = preDay.ToString();
                    DtpReqWeek2.Value = DtpD1.Value.AddDays((int)Convert.ToDouble(LblPreDay1.Text));
                    TxtInputWk2.Text = week2.ToString();
                }
            }
            else if (!BoosterOverloded()) { TxtInputWk1.Text = "0"; TxtInputWk2.Text = "0"; }
            else
            { ClearText(); }
        }
        private void TxtInputWk2_TextChanged(object sender, EventArgs e)
        {
            string value = TxtInputWk2.Text;//8
            string week1in = TxtInputWk1.Text;
            double week1 = Convert.ToDouble(LblW1In.Text);//4
            double week2 = Convert.ToDouble(LblW2In.Text);//10
            double num, preDay;
            if (double.TryParse(value, out num) && LblW2In.Text != "0" || value != "")
            {
                double wk1Input;
                double.TryParse(week1in, out wk1Input);

                double getTwoWeek = wk1Input + num;//TwoWeeks Input

                if (wk1Input > week1) /*6>4*/
                {
                    double overFlowAmt = wk1Input - week1;//2
                    double newNum = num + overFlowAmt;//8+2=10 
                    preDay = newNum / ReturnFormulaRes(week2);//10/1.42=7 
                    LblPreDay2.Text = String.Format("{0:0.00}", (preDay)).ToString();//7
                    DtpReqWeek3.Value = DtpD2.Value.AddDays((int)preDay);
                    if (ActTotBoosterCount() < getTwoWeek)
                    { TxtInputWk3.Text = "0"; }
                    else { TxtInputWk3.Text = (ActTotBoosterCount() - getTwoWeek).ToString(); }
                }
                else
                {   //if input is 10
                    preDay = num / ReturnFormulaRes(week2);/* 10/1.42= 7*/
                    LblPreDay2.Text = String.Format("{0:0.00}", (preDay)).ToString();//7
                    DtpReqWeek3.Value = DtpD2.Value.AddDays((int)preDay);
                    if (ActTotBoosterCount() < getTwoWeek)
                    { TxtInputWk3.Text = "0"; }
                    else { TxtInputWk3.Text = (ActTotBoosterCount() - getTwoWeek).ToString(); }
                }
            }
            else { ClearText(); }
        }
        private void TxtInputWk3_TextChanged(object sender, EventArgs e)
        {
            string value = TxtInputWk3.Text;
            double week3 = Convert.ToDouble(LblW3In.Text);
            double num;
            if (double.TryParse(value, out num) && LblW3In.Text != "0" || value != "")
            {
                double preDay = num / ReturnFormulaRes(week3);
                LblPreDay3.Text = String.Format("{0:0.00}", (preDay)).ToString();
                DtpReqWeek4.Value = DtpReqWeek3.Value.AddDays((int)preDay);

                if (ActTotBoosterCount() != TotalBoosterCount())
                {
                    lblGapHeader.Visible = true;
                    LblGap.Visible = true;
                    LblGap.Text = (ActTotBoosterCount() - TotalBoosterCount()).ToString();
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(this.LblGap, "Gap between inputs and actual");
                }
                else
                {
                    lblGapHeader.Visible = false;
                    LblGap.Visible = false;
                }
            }
            else { ClearText(); }
        }
        private void TxtInputWk4_TextChanged(object sender, EventArgs e)
        {
            string value = TxtInputWk4.Text;
            double week4 = Convert.ToDouble(LblW4In.Text);
            double week5 = Convert.ToDouble(LblW5In.Text);
            double num, preDay;
            if (double.TryParse(value, out num) && LblW4In.Text != "0" || value != "")
            {
                if (num < week4)
                {
                    preDay = num / ReturnFormulaRes(week4);
                    LblPreDay4.Text = preDay.ToString();
                    DtpReqWeek5.Value = DtpD4.Value.AddDays((int)preDay);
                    double newAvg4 = Convert.ToDouble(LblW4In.Text) - num;
                    TxtInputWk5.Text = (Convert.ToDouble(LblW5In.Text) + newAvg4).ToString();
                }

                else if (num > week4)
                {
                    // num=16
                    double actWk4 = Convert.ToDouble(LblW4In.Text);//14
                    double actWk5 = Convert.ToDouble(LblW5In.Text);//21
                    double amt = num - actWk4;//16-14=2
                    preDay = actWk4 / ReturnFormulaRes(week4);//7
                    double newPreDay = amt / ReturnFormulaRes(week5);//0.666
                    LblPreDay4.Text = String.Format("{0:0.00}", (preDay + newPreDay)).ToString();
                    DtpReqWeek5.Value = DtpD4.Value.AddDays((int)preDay + (int)newPreDay);
                    double newAvgD4 = num - actWk4;
                    TxtInputWk5.Text = (actWk5 - newAvgD4).ToString();
                }
                else
                {
                    preDay = num / ReturnFormulaRes(week4);
                    LblPreDay4.Text = preDay.ToString();
                    DtpReqWeek5.Value = DtpD4.Value.AddDays((int)preDay);
                    TxtInputWk5.Text = week5.ToString();
                }
            }
            else
            { ClearText(); }
        }
        private void TxtInputWk5_TextChanged(object sender, EventArgs e)
        {
            string value = TxtInputWk5.Text;
            double week4 = Convert.ToDouble(LblW4In.Text);
            double week5 = Convert.ToDouble(LblW5In.Text);
            double num, preDay;
            if (double.TryParse(value, out num) && LblW5In.Text != "0" || value != "")
            {
                double wk4Input = Convert.ToDouble(TxtInputWk4.Text);
                if (wk4Input > week4)
                {
                    double overFlowAmt = wk4Input - week4;//2
                    double newNum = num + overFlowAmt;

                    preDay = newNum / ReturnFormulaRes(week5);
                    LblPreDay5.Text = String.Format("{0:0.00}", (preDay)).ToString();
                    DtpReqWeek6.Value = DtpD5.Value.AddDays((int)preDay);

                    if (ActTotFinishrCount() != TotalFinisherCount())
                    {
                        label15.Visible = true;
                        lblFinisherGap.Visible = true;
                        lblFinisherGap.Text = (ActTotFinishrCount() - TotalFinisherCount()).ToString();
                        ToolTip tip = new ToolTip();
                        tip.SetToolTip(this.LblGap, "Gap between inputs and actual");
                    }
                    else
                    {
                        label15.Visible = false;
                        lblFinisherGap.Visible = false;
                    }
                }
                else
                {
                    preDay = num / ReturnFormulaRes(week5);
                    LblPreDay5.Text = String.Format("{0:0.00}", (preDay)).ToString();
                    DtpReqWeek6.Value = DtpD5.Value.AddDays((int)preDay);

                    if (ActTotFinishrCount() != TotalFinisherCount())
                    {
                        label15.Visible = true;
                        lblFinisherGap.Visible = true;
                        lblFinisherGap.Text = (ActTotFinishrCount() - TotalFinisherCount()).ToString();
                        ToolTip tip = new ToolTip();
                        tip.SetToolTip(this.LblGap, "Gap between inputs and actual");
                    }
                    else
                    {
                        label15.Visible = false;
                        lblFinisherGap.Visible = false;
                    }
                }
            }
            else
            { }
        }
        #endregion

        private void DtpReqWeek5_ValueChanged(object sender, EventArgs e)
        {
            BtnSave.Enabled = true;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (scheduleDB.UpdateIntoFeedTemp(Convert.ToInt32(CmbFarmerBatch.Text), txtUser.Text))
            { MessageBox.Show("Record Sucessfully Updated", "Record " + CmbFarmerBatch.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); }
            else
            { MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        private void DgvAvalableBatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
                {
                    double qty = Convert.ToDouble(DgvAvalableBatch.Rows[e.RowIndex].Cells[5].Value);
                    string week = DgvAvalableBatch.Rows[e.RowIndex].Cells[0].Value.ToString().ToLower();

                    switch (week)
                    {
                        case "week 1":
                            TxtInputWk1.Text = qty.ToString();
                            break;
                        case "week 1+":
                            TxtInputWk1.Text = (Convert.ToInt32(TxtInputWk1.Text) + qty).ToString();
                            break;

                        case "week 2":
                            TxtInputWk2.Text = qty.ToString(); ;
                            break;
                        case "week 2+":
                            TxtInputWk2.Text = (Convert.ToInt32(TxtInputWk2.Text) + qty).ToString(); ;
                            break;

                        case "week 3":
                            TxtInputWk3.Text = qty.ToString(); ;
                            break;
                        case "week 3+":
                            TxtInputWk3.Text = (Convert.ToInt32(TxtInputWk3.Text) + qty).ToString(); ;
                            break;

                        case "week 4":
                            TxtInputWk4.Text = qty.ToString(); ;
                            break;
                        case "week 4+":
                            TxtInputWk4.Text = (Convert.ToInt32(TxtInputWk4.Text) + qty).ToString(); ;
                            break;

                        case "week 5":
                            TxtInputWk5.Text = qty.ToString();
                            break;
                        case "week 5+":
                            TxtInputWk5.Text = (Convert.ToInt32(TxtInputWk5.Text) + qty).ToString();
                            break;
                        default:
                            {
                                MessageBox.Show("Error select a week");
                                break;
                            }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
