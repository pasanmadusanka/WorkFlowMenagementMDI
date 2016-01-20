using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Methods;
using WorkFlowMenagementMDI.Tracking.Reports;

namespace WorkFlowMenagementMDI.Tracking.Views.ReportView
{
    public partial class FarmerReport : Form
    {
        GetFarmerVisitation db = new GetFarmerVisitation();
        public FarmerReport()
        {
            InitializeComponent();
        }

        public void GetFarmersDetails()
        {
            DataTable dt1 = db.GetFarmersDetails();
            CMBFieldOfficer.ValueMember = "id";
            CMBFieldOfficer.DisplayMember = "name";
            CMBFieldOfficer.DataSource = dt1;
        }//Gat Feild office Name and id To Combo

        public void InsertToTEMP()
        {
            string pc = System.Environment.MachineName.ToString();
            db.WrightVisitsToTemp(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"),
                           Convert.ToInt32(CMBFieldOfficer.SelectedValue), Settings.Default.LastUser, pc);
        }
        private void BtnReportView_Click(object sender, EventArgs e)
        {
            ReportViewerFarmer report = new ReportViewerFarmer(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CMBFieldOfficer.SelectedValue), CMBFieldOfficer.Text);
            report.Show();
        }

        private void CMBFieldOfficer_SelectedIndexChanged(object sender, EventArgs e)
        { 
            InsertToTEMP();
        }

        private void DTPFromDate_ValueChanged(object sender, EventArgs e)
        {
            InsertToTEMP();
        }

        private void DTPToDate_ValueChanged(object sender, EventArgs e)
        {
            InsertToTEMP();
        }

        private void CMBFieldOfficer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CMBFieldOfficer.SelectedItem != null)
                {
                    DTPFromDate.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the 'Field Officer' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void DTPFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DTPFromDate.Value != null)
                {
                    DTPToDate.Focus();
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the 'From Date' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void DTPToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (DTPToDate.Value != null)
                {
                    BtnReportView_Click(sender, e);
                    e.Handled = true;
                }
                else
                { MessageBox.Show("Fill the 'To Date' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void FarmerReport_Load(object sender, EventArgs e)
        {
            GetFarmersDetails();//Calling the combobox load
            DTPFromDate.Format = DateTimePickerFormat.Custom;
            DTPFromDate.CustomFormat = "dd/MM/yyyy";
            DTPToDate.Format = DateTimePickerFormat.Custom;
            DTPToDate.CustomFormat = "dd/MM/yyyy";
        }
    }
}
