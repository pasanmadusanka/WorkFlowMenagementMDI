using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Properties;
using WorkFlowMenagementMDI.Tracking.Methods.Customers;
using WorkFlowMenagementMDI.Tracking.Reports;

namespace WorkFlowMenagementMDI.Tracking.Views.ReportView
{
    public partial class CustomerReports : Form
    {
        FindLocationsOfCustomersMethods db = new FindLocationsOfCustomersMethods();
        public CustomerReports()
        {
            InitializeComponent();
        }

        private void BtnReportView_Click(object sender, EventArgs e)
        {
            ReportViewerFarmer report = new ReportViewerFarmer(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"),
                DTPToDate.Value.Date.ToString("dd/MM/yyyy"), CMBRep.Text, CmbDeliveryVehi.Text);
            report.Show();
            
        }

        private void CMBRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataToCusTMP();
        }

        private void CmbDeliveryVehi_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataToCusTMP();
        }

        private void DTPFromDate_ValueChanged(object sender, EventArgs e)
        {
            GetDataToCusTMP();
        }

        private void DTPToDate_ValueChanged(object sender, EventArgs e)
        {
            GetDataToCusTMP();
        }
        public void GetRepToCombo()
        {
            DataTable dtRep = db.GetSalesRepToCMB();
            CMBRep.ValueMember = "id";
            CMBRep.DisplayMember = "repName";
            CMBRep.DataSource = dtRep;
            CMBRep.SelectedItem = null;
        }

        public void GetDelivaryVehiToCombo()
        {
            DataTable dtVhi = db.GetDelivaryVehicle();
            CmbDeliveryVehi.ValueMember = "id";
            CmbDeliveryVehi.DisplayMember = "vhiNO";
            CmbDeliveryVehi.DataSource = dtVhi;
            CmbDeliveryVehi.SelectedItem = null;
        }
        private void CustomerReports_Load(object sender, EventArgs e)
        {
            GetRepToCombo(); GetDelivaryVehiToCombo();
        }

        public void GetDataToCusTMP()
        {
            string pc = System.Environment.MachineName.ToString();
            if (db.WrightVisitsToTemp(DTPFromDate.Value.Date.ToString("dd/MM/yyyy"),
                DTPToDate.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(CmbDeliveryVehi.SelectedValue),
                Convert.ToInt32(CMBRep.SelectedValue), Settings.Default.UserID.ToString(), pc))
            { /*Do nothing*/ }
            else { MessageBox.Show("error"); }
        }

        private void CMBRep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CMBRep.SelectedItem != null)
                {
                    CmbDeliveryVehi.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Rep' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void CmbDeliveryVehi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbDeliveryVehi.SelectedItem != null)
                {
                    DTPFromDate.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Vehicle' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                {
                    MessageBox.Show("Fill the 'To Date' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
