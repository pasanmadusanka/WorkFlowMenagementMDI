using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.FieldOfficers;

namespace WorkFlowMenagementMDI.Tracking.Views.FieldOfficers
{
    public partial class FieldOfficerCreation : Form
    {
        FieldOfficerCreationMethods db = new FieldOfficerCreationMethods();
        public FieldOfficerCreation()
        {
            InitializeComponent();
        }
        public void GridRefresh()
        {
            DataSet ds = db.GetFOffocerToGrid();
            DgvFieldOff.DataSource = ds.Tables["FoDetails"].DefaultView;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to save the Record?", "Confirm item saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int name = Convert.ToInt32(CmbFoName.SelectedValue);
                    double latitude = Convert.ToDouble(TxtLatfo.Text);
                    double longitude = Convert.ToDouble(TxtLonfo.Text);
                    string device = TxtDeviseNamefo.Text;
                    string bike = TxtBikNoFo.Text;
                    if (db.InsertNewOfficer(name, bike, device, latitude, longitude))
                    {
                        MessageBox.Show("Record Sucessfully Added", "Record Status", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                        GridRefresh(); ClearEvent();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                }
                else
                { MessageBox.Show("Item Didnt save....!", "Saving details", MessageBoxButtons.OK, MessageBoxIcon.Information); this.Close(); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LblIdfo.Text);
                int name = Convert.ToInt32(CmbFoName.SelectedValue);
                double latitude = Convert.ToDouble(TxtLatfo.Text);
                double longitude = Convert.ToDouble(TxtLonfo.Text);
                string device = TxtDeviseNamefo.Text;
                string bike = TxtBikNoFo.Text;
                if (db.UpdateOfficer(id, name, latitude, longitude, device, bike))
                {
                    MessageBox.Show("Record " + LblIdfo.Text + " Sucessfully Updated!", "Record " + LblIdfo.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    GridRefresh(); ClearEvent();
                }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete the Record \"" + LblIdfo.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteOfficer(Convert.ToInt32(LblIdfo.Text)))
                    {
                        MessageBox.Show("Record has been Deleted....!", "Record " + LblIdfo.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        GridRefresh(); ClearEvent();
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record " + LblIdfo.Text + " Not Deleted", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        private void FieldOfficerCreation_Load(object sender, EventArgs e)
        {
            GridRefresh(); GetFOFromMaster();
            CmbFoName.Select();
        }

        public void GetFOFromMaster()
        {
            DataTable dt = db.GetFOFromFoMasterCMB();
            CmbFoName.ValueMember = "id";
            CmbFoName.DisplayMember = "name";
            CmbFoName.DataSource = dt;
            CmbFoName.SelectedItem = null;
        }
        private void RBCreate_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = true;
            BtnUpdate.Enabled = false;
            BtnDelete.Enabled = false;
        }

        private void RBEdit_CheckedChanged(object sender, EventArgs e)
        {
            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
        }

        private void DgvFieldOff_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RBEdit.Checked = true;
            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
            BtnDelete.Enabled = true;
            LblIdfo.Text = DgvFieldOff.Rows[e.RowIndex].Cells[0].Value.ToString();
            CmbFoName.Text = DgvFieldOff.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtDeviseNamefo.Text = DgvFieldOff.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtBikNoFo.Text = DgvFieldOff.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtLatfo.Text = DgvFieldOff.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtLonfo.Text = DgvFieldOff.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        public void ClearEvent()
        {
            CmbFoName.SelectedItem = null;
            TxtDeviseNamefo.Clear();
            TxtBikNoFo.Clear();
            TxtLatfo.Clear();
            TxtLonfo.Clear();
            LblIdfo.Text = "";
        }

        private void FieldOfficerCreation_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void CmbFoName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CmbFoName.SelectedItem != null)
                {
                    TxtDeviseNamefo.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Field Officer' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtDeviseNamefo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtDeviseNamefo.Text != "")
                {
                    TxtBikNoFo.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Device' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtBikNoFo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBikNoFo.Text != "")
                {
                    TxtLatfo.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'Bike Number' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtLatfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value = TxtLatfo.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    TxtLonfo.Focus();
                    e.Handled = true;
                }
                else
                {
                    MessageBox.Show("Fill the 'F/O Location Latitude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TxtLonfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string value = TxtLonfo.Text;
                double num;
                if (double.TryParse(value, out num))
                {
                    if (RBCreate.Checked == true)
                    {
                        BtnAdd_Click(sender, e);
                        e.Handled = true;
                    }
                    else if (RBEdit.Checked == true)
                    {
                        BtnUpdate_Click(sender, e);
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Fill the 'F/O Location Longitude' to continue...!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
