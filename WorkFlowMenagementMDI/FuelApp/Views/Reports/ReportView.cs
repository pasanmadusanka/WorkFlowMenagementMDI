using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;

namespace WorkFlowMenagementMDI.FuelApp.Views.Reports
{

    public partial class ReportView : Form
    {
        private string _fromDate, _ToDate;

        NewReportMethods dba = new NewReportMethods();
        public ReportView()
        {
            InitializeComponent();
        }

        public ReportView(string fromDate, string toDate)
        {
            this._fromDate = fromDate;
            this._ToDate = toDate;
            InitializeComponent();
            LoadReport();
        }

        public void LoadReport()
        {
            DgvFuel.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8F, FontStyle.Bold);

            DgvFuel.RowTemplate.MinimumHeight = 25;//25 is height.

            //With dgvDonors
            // DgvFuel.Columns(0).Width = 150;
            //DgvFuel.Columns[3].Visible = false;

            try
            {
                DataSet ds = dba.GetAllToTable(_fromDate, _ToDate);
                DgvFuel.DataSource = ds.Tables["FUEL_TMP_ISSUE_HEADER_SUB"].DefaultView;
                //DgvFuel.Columns[1].Width = 70;
                //DgvFuel.Columns[3].Width = 80;
                //DgvFuel.Columns[4].Width = 120;
                //DgvFuel.Columns[5].Width = 110;
                //DgvFuel.Columns[6].Width = 55;
                //DgvFuel.Columns[7].Width = 50;
                //DgvFuel.Columns[8].Width = 72;
                //DgvFuel.Columns[9].Width = 72;
                //DgvFuel.Columns[10].Width = 76;
                //DgvFuel.Columns[10].Visible = ;
                DgvFuel.ClearSelection();
            }
            catch { MessageBox.Show("Error try again....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification); }

        }

        private void ReportView_Load(object sender, EventArgs e)
        {

        }
    }
}
