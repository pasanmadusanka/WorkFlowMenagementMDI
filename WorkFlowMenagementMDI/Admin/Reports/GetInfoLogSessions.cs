using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.Admin.Reports
{
    public partial class GetInfoLogSessions : Form
    {
        GetLoginSessionDetails db = new GetLoginSessionDetails();
        public GetInfoLogSessions()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            ReportViewerLogSessions report = new ReportViewerLogSessions();
            report.Show();
        }

        private void GetInfoLogSessions_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = db.FillGrid();
                dataGridView1.DataSource = ds.Tables["FUEL_TMP_ISSUE_HEADER_SUB"].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
}
