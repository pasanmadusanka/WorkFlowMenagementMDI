using WorkFlowMenagementMDI.FuelApp.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;

namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    public partial class SaveWeeklyPhysicalStk : Form
    {
        FuelWeeklyStockMethods weeklyStock = new FuelWeeklyStockMethods();
        public SaveWeeklyPhysicalStk()
        {
            InitializeComponent();
            ToolTipShow();
            TxtPhysicalStock.Focus();
        }

        public void ToolTipShow()
        {
            ToolTip tips = new ToolTip();
            tips.SetToolTip(this.TxtPhysicalStock, "The current fuel stock");
            tips.SetToolTip(this.BtnPrintReport, "Print the report");
            tips.SetToolTip(this.BtnSave, "Save");
            tips.SetToolTip(this.DgvFuelStock, "Fuel physical stock table");
            tips.SetToolTip(this.TxtMeterCount, "Fuel meter count");
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtWeekly = weeklyStock.GetWeekName();
                DataRow drWeekly = dtWeekly.Rows[0];
                //string week = drWeekly[0].ToString();//Get week name
                string date = drWeekly[1].ToString();//get current date

                if (weeklyStock.GetLastDatWeeklyStk() != date)//check fo db date with current date
                {   //Adding operation
                    DialogResult usersChoice = MessageBox.Show(@"Do you want to save the value " + TxtPhysicalStock.Text.ToString()
                           + ".\n \n\r Click 'Yes' to save the value.",
                            "Fuel Physical Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (usersChoice == DialogResult.Yes)
                    {
                        if (weeklyStock.AddToWeeklyStockTb(Convert.ToDouble(TxtPhysicalStock.Text),Convert.ToDouble(TxtMeterCount.Text)))
                        {
                            LoadGrid(); MessageBox.Show("Sucessfully Add the Weekly stock Table....!", "Weekly physical Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                        else { MessageBox.Show("Something is wrong.....!", "Error with adding details", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else { TxtPhysicalStock.Clear(); }
                }
                else { MessageBox.Show(date.Substring(3, 2) + "/" + date.Substring(0, 2) + "/" + date.Substring(6, 4) + " Date physical stock is alredy exsist.....!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Hand); }

            }
            catch (Exception ex)
            { MessageBox.Show("Check the input\n\n" + ex.Message.ToString(), "Error in Btn Save Click", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadGrid()
        {
            DataTable dt = weeklyStock.GetAllFromWeeklyStock();
            DgvFuelStock.DataSource = dt;
        }
        private void SaveWeeklyPhysicalStk_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGrid();
                BtnProperty();
                TxtPhysicalStock.Focus();
                LBLAvalable_Stock.Text = "Avalable Fuel Stock: "+weeklyStock.FuelSystemStock().ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void DgvFuelStock_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //DataGridViewCellEventArgs e1=new DataGridViewCellEventArgs(e)
            if (Properties.Settings.Default.LastUser.ToLower() != "admin")
            {
                MessageBox.Show("You are not allow to delete", "Weekly physical Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                LoadGrid();
            }
            else if (Properties.Settings.Default.LastUser.ToLower() == "admin")
            {
                DialogResult usersChoice = MessageBox.Show(@"You are about to delete " + DgvFuelStock.SelectedRows.Count
                    + " Row(s).\n\n \r Click Yes to permanently delete these rows. You won’t be able to undo these changes.",
                "Fuel Physical Stock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // cancel the delete event
                if (usersChoice == DialogResult.No)
                { e.Cancel = true; }

                else if (usersChoice == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(DgvFuelStock.Rows[0].Cells[0].Value);
                    //int id=DgvFuelStock.SelectedCells[0].RowIndex.Cells[0].Value.ToString();
                    object val = DgvFuelStock.SelectedRows[0].Cells[0].Value;
                    int value = Convert.ToInt32(val);
                    if (weeklyStock.DeleteFromWeeklyStock(value))
                    { MessageBox.Show("Record has been deleted"); TxtPhysicalStock.Clear(); TxtPhysicalStock.Focus(); }
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (weeklyStock.UpdateWeeklyStock(Convert.ToInt32(LblId.Text), Convert.ToDouble(TxtPhysicalStock.Text), Convert.ToDouble(TxtMeterCount.Text)))
                {
                    MessageBox.Show("Table is sucessfully updated", "Weekly Physical Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGrid();
                }
                else { MessageBox.Show("Somthing is went wrong", "Weekly Physical Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Weekly Physical Stock", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
        }

        public void BtnProperty()
        {
            if (Properties.Settings.Default.LastUser.ToLower() != "admin")
            {
                BtnUpdate.Enabled = false;
            }
        }

        private void DgvFuelStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                LblId.Text = DgvFuelStock.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtPhysicalStock.Text = DgvFuelStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                TxtMeterCount.Text = DgvFuelStock.Rows[e.RowIndex].Cells[4].Value.ToString();
                //BtnSave.Enabled = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void BtnPrintReport_Click(object sender, EventArgs e)
        {
            //StockMovementReportView report = new StockMovementReportView();
            //report.ShowDialog();

            string id = "PhycisalLoad";
            DateSelection report = new DateSelection(id);//purchasebook is a formname
            report.ShowDialog();
        }//Views\StockMovement\PhysicalStockReport.rpt

        private void TxtPhysicalStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtPhysicalStock.Text != "")
                {
                    //BtnSave_Click(sender, e);
                    TxtMeterCount.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Stock cannot Be empty...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtMeterCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtMeterCount.Text != "")
                {
                    BtnSave_Click(sender, e);
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Meter Value cannot Be empty...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtPhysicalStock_TextChanged(object sender, EventArgs e)
        {
            string tString = TxtPhysicalStock.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (char.IsLetter(tString[i]))
                {
                    MessageBox.Show("Stock accept numaric values only...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPhysicalStock.Text = "";
                    return;
                }
            }
        }

        private void TxtMeterCount_TextChanged(object sender, EventArgs e)
        {
            string tString = TxtMeterCount.Text;
            if (tString.Trim() == "") return;
            for (int i = 0; i < tString.Length; i++)
            {
                if (char.IsLetter(tString[i]))
                {
                    MessageBox.Show("Meter accept numaric values only...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtMeterCount.Text = "";
                    return;
                }
            }
        }
    }
}
