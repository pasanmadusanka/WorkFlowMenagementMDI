using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.SalesCustomers;

namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    public partial class DeviceDetailsOfCust : Form
    {
        DeviseDetailsOfVehicleMethod db = new DeviseDetailsOfVehicleMethod();
        public DeviceDetailsOfCust()
        {
            InitializeComponent();
        }
        public void AccessGrid()
        {
            DataSet ds = db.GetVehicleToGrid();
            DgvVehicleTrack.DataSource = ds.Tables["vehicleTrack"].DefaultView;
        }
        private void DeviceDetailsOfCust_Load(object sender, EventArgs e)
        {
            AccessGrid(); 
            GetFieldOffCombo();
        }
        public void GetFieldOffCombo()
        {
            DataTable dt = db.GetVehicleToCombo();
            CmbVehicle.ValueMember = "id";
            CmbVehicle.DisplayMember = "name";
            CmbVehicle.DataSource = dt;
        }
        private void DgvVehicleTrack_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RBEdit.Checked = true;
            BtnAdd.Enabled = false;
            BtnUpdate.Enabled = true;
            BtnDelete.Enabled = true;
            LblId.Text = DgvVehicleTrack.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtDeviceName.Text = DgvVehicleTrack.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtVehicleLat.Text = DgvVehicleTrack.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtVehicleLongi.Text = DgvVehicleTrack.Rows[e.RowIndex].Cells[4].Value.ToString();
            CmbVehicle.Text = DgvVehicleTrack.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(LblId.Text);
                string name = TxtDeviceName.Text; double latitude = 0;
                double longitude = 0;
                int vehicleID = Convert.ToInt32(CmbVehicle.SelectedValue); 
                if (db.UpdateVehicleTracking(id, name, vehicleID,latitude, longitude))
                {
                    MessageBox.Show("Record " + LblId.Text + " Sucessfully Updated!", "Record " + LblId.Text + "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
                    AccessGrid();
                }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
