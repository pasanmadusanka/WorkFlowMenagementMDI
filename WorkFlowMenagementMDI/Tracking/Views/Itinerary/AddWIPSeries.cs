using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Itinerary;

namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    public partial class AddWIPSeries : Form
    {
        NewWIPMethods db = new NewWIPMethods();
        private int _wipID;
        public AddWIPSeries()
        {
            InitializeComponent();
            WipIDGenerator();
        }
        public AddWIPSeries(int wipID)
        {
            InitializeComponent();
            this._wipID = wipID;
            DataTable dt = db.GetFromDateNToDateOfSeries(_wipID);
            if (dt != null)
            {
                try
                {
                    DataRow dr = dt.Rows[0];
                    TxtWIPCode.Text = dr["name"].ToString();
                    DtpPlanFrmDate.Value = Convert.ToDateTime(dr["fromD"]);
                    DtpPlanToDate.Value = Convert.ToDateTime(dr["toD"]);
                    TxtWIPCode.Enabled = false;
                    BtnAdd.Text = "Update";
                    this.Text = "Update WIP Series";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message);}
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //int outVal = privilege.GetUserAccessable("UTRW_CREATE", 1);
            //if (outVal == 1)
            //{
            if (BtnAdd.Text == "Create")
            {
                InsertSeriesData();
            }
            else if (BtnAdd.Text == "Update")
            {
                UpdateSeriesData();
            }
            //}
            //else { MessageBox.Show("You dont have the privelages to Save this....!", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        public void UpdateSeriesData()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to update the Record "+TxtWIPCode.Text+"?", "Confirm item update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (db.UpdateWIPDates(_wipID, DtpPlanFrmDate.Value.ToString("MM/dd/yyyy"), DtpPlanToDate.Value.ToString("MM/dd/yyyy")))
                    {
                        MessageBox.Show("Record Sucessfully Added", "Record Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                { MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }
        public void InsertSeriesData()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (db.InsertNewWIP(TxtWIPCode.Text, DtpPlanFrmDate.Value.ToString("MM/dd/yyyy"), DtpPlanToDate.Value.ToString("MM/dd/yyyy")))
                    {
                        MessageBox.Show("Record Sucessfully Added", "Record Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        this.Close();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                { MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }
        private void AddWIPSeries_Load(object sender, EventArgs e)
        {
            
        }

        public void WipIDGenerator()
        {
            DataTable dt = db.GetLatestWIPCode();
            DataRow dr = dt.Rows[0];
            int wip=0;
            string val = dr[0].ToString();
            if (dr[0] == null || dr[0].ToString()=="") { wip = 1; }
            else { wip = Convert.ToInt32(dr[0]) + 1; }

            if (wip.ToString().Length < 5)
            {
                int length = 5 - (wip.ToString().Length);
                switch (length)
                {
                    case 1:
                        TxtWIPCode.Text = "WIP-0" + wip.ToString();
                        break;
                    case 2:
                        TxtWIPCode.Text = "WIP-00" + wip.ToString();
                        break;
                    case 3:
                        TxtWIPCode.Text = "WIP-000" + wip.ToString();
                        break;
                    case 4:
                        TxtWIPCode.Text = "WIP-0000" + wip.ToString();
                        break;

                }
            }
            else { TxtWIPCode.Text = "WIP-" + wip.ToString(); }
        }

        private void DtpPlanFrmDate_ValueChanged(object sender, EventArgs e)
        {
            DtpPlanToDate.Value = DtpPlanFrmDate.Value.AddDays(5);
        }
    }
}
