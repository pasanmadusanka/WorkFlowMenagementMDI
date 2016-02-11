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
    public partial class FeedIssueScheduleList : Form
    {
        FeedIssueScheduleListMethods db = new FeedIssueScheduleListMethods();
        WorkFlowManageMethods privilege = new WorkFlowManageMethods();

        public FeedIssueScheduleList()
        {
            InitializeComponent();
        }

        public void GetTableFilledFeed()
        {
            DataSet ds = db.GetFeedIssueToGrid();
            DGVFeedIssue.DataSource = ds.Tables["feedIssue"].DefaultView;
        }

        private void FeedIssueScheduleList_Load(object sender, EventArgs e)
        {
            LoadListView(); GetTableFilledFeed();
        }

        public void LoadListView()
        {
            DataTable dt = db.LoadListView();
            //foreach (DataRow row in dt.Rows)
            //listBox1.Items.Add(row[1]);
            LBArea.ValueMember = "id";
            LBArea.DisplayMember = "name";
            LBArea.DataSource = dt;
            LBArea.SelectedItem = null;
        }

        private void LBArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = db.GetFeedIssueToGridByArea(Convert.ToInt32(LBArea.SelectedValue));
            DGVFeedIssue.DataSource = ds.Tables["feedIssue"].DefaultView;
        }

        private void DGVFeedIssue_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string farmer = DGVFeedIssue.Rows[e.RowIndex].Cells[1].Value.ToString() + " - " + DGVFeedIssue.Rows[e.RowIndex].Cells[2].Value.ToString();
            string batch = DGVFeedIssue.Rows[e.RowIndex].Cells[0].Value.ToString();
            string wk1In = DGVFeedIssue.Rows[e.RowIndex].Cells[4].Value.ToString();
            //string wk2In = DGVFeedIssue.Rows[e.RowIndex].Cells[5].Value.ToString();
            string wk3In = DGVFeedIssue.Rows[e.RowIndex].Cells[6].Value.ToString();
            string wk4In = DGVFeedIssue.Rows[e.RowIndex].Cells[7].Value.ToString();
            //string wk5In = DGVFeedIssue.Rows[e.RowIndex].Cells[8].Value.ToString();
            string user = DGVFeedIssue.Rows[e.RowIndex].Cells[14].Value.ToString();
            FeedIssueSchedule feed = new FeedIssueSchedule(farmer, batch, wk1In, wk3In, wk4In,user);
            feed.ShowDialog();
        }

        private void LBArea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LBArea.SelectedItem = null;
                GetTableFilledFeed();
            }
        }

        private void DGVFeedIssue_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           
            int outVal = privilege.GetUserAccessable("UTRW_DELETE", 3);
            if (outVal == 1)
            {
                DialogResult usersChoice = MessageBox.Show(@"You are about to delete " + DGVFeedIssue.SelectedRows.Count
                    + " Row(s).\n\n \r Click Yes to permanently delete these rows. You won’t be able to undo these changes.",
                "Feed Issue details", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // cancel the delete event
                if (usersChoice == DialogResult.No)
                { e.Cancel = true; }

                else if (usersChoice == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DGVFeedIssue.Rows[0].Cells[0].Value);
                    //int id=DgvFuelStock.SelectedCells[0].RowIndex.Cells[0].Value.ToString();
                    object val = DGVFeedIssue.SelectedRows[0].Cells[0].Value;
                    int value = Convert.ToInt32(val);
                    if (db.DeleteFeedIssue(value))
                    { GetTableFilledFeed(); }
                }
            }
            else { MessageBox.Show("You dont have the privelage to delete this....!", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); e.Cancel = true; }
        }
    }
}
