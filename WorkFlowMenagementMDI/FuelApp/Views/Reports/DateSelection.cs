using WorkFlowMenagementMDI.FuelApp.Views.StockMovement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.FuelApp.Views.Reports
{
    public partial class DateSelection : Form
    {
        private string _id;
        public DateSelection()
        {
            InitializeComponent();
        }

        public DateSelection(string id)
        {
            InitializeComponent();
            this._id = id;
            if (id == "PhycisalLoad")
            {
            }
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (_id == "LoadMain")
            {
                this.Hide();
                FormReportView report = new FormReportView(_id, DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"));
                report.Show();
            }
            else if (_id == "PhycisalLoad")
            {
                this.Hide();
                FormReportView report = new FormReportView(_id, DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"));
                report.Show();
            }
            else if (_id == "stockMovement")
            {
                this.Hide();
                StockMovementReportView report = new StockMovementReportView(_id, DTPFromDate.Value.Date.ToString("dd/MM/yyyy"), DTPToDate.Value.Date.ToString("dd/MM/yyyy"));
                report.Show();
            }
        }

        private void DateSelection_Load(object sender, EventArgs e)
        {
            if (_id == "LoadMain")
            {
                lblHeader.Text = "General Fuel Report";
            }
            else if (_id == "PhycisalLoad")
            {
                lblHeader.Text = "Physical Stock Report";
            }
            else if (_id == "stockMovement")
            {
                lblHeader.Text = "Stock Movement Report";
            }
        }

        private void DTPFromDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DTPToDate.Focus();
                e.Handled = true;
            }
        }

        private void DTPToDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSubmit_Click(sender, e);
            }
        }
    }
}
