using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Admin.Methods;

namespace WorkFlowMenagementMDI.Admin.Views
{
    public partial class AdminDeteteParkingData : Form
    {
        AdminDeleteParkHistoryMethods db = new AdminDeleteParkHistoryMethods();
        WorkFlowManageMethods WF = new WorkFlowManageMethods();
        int lastUserID = Properties.Settings.Default.UserID;

        public AdminDeteteParkingData()
        {
            InitializeComponent();
        }
        public int GetUserAccessable(string input)
        {
            int privlagID;
            string queryStringDisable = @"SELECT FK_USER_ID, FK_ROLE_ID, UTRW_CREATE, UTRW_UPDATE, UTRW_DELETE
            FROM USER_TO_ROLE_WFMS
            where FK_USER_ID=" + lastUserID + "";

            DataTable dt = null;
            DataSet ds = WF.SelectUserRolesToControls(queryStringDisable);

            if (lastUserID == 1)
            {
                privlagID = 1;
            }
            else
            {
                dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                privlagID = Convert.ToInt32(dr[input]);
            }
            return privlagID;
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string fromD = CmbFrmDate.SelectedValue.ToString();
            string toD = CmbToDate.SelectedValue.ToString();
            int outVal = GetUserAccessable("UTRW_DELETE");
            if (outVal == 1)
            {
                if (RBFarmer.Checked == true)
                {
                    DeleteFieldOfficer(fromD, toD);
                    GetRepOrFarmParkDatFrm(@"SELECT distinct Park_Date as dateId, CONVERT(VARCHAR(11), CAST(Park_Date AS datetime), 106) AS Date
                FROM GPS_FO_PARKING_DETAILS");
                }
                else if (RBCustomer.Checked == true) 
                {
                    Deleterepresentative(fromD, toD);
                    GetRepOrFarmParkDatFrm(@"SELECT distinct CAST(Vhi_Park_Date AS datetime),Vhi_Park_Date as dateId,CONVERT(VARCHAR(11), CAST(Vhi_Park_Date AS datetime), 106) AS Date
                        FROM GPS_TRK_VEHICLE_PARKING order by CAST(Vhi_Park_Date AS datetime)");
                }
            }
            else { MessageBox.Show("You dont have the permissions to delete this", "Privelages", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Deleterepresentative(string fromD, string toD)
        {
            DataTable dt = db.GetRecordCount(@"SELECT Count(Cast(Vhi_Park_Date as datetime)) as Count FROM GPS_TRK_VEHICLE_PARKING
WHERE (Cast(Vhi_Park_Date as datetime) >= '" + fromD + "') AND (Cast(Vhi_Park_Date as datetime) <= '" + fromD + "')");
            DataRow dr = dt.Rows[0];
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete \"" + dr[0].ToString() + "\" records of\nSales Vehicles parking details from \"" + CmbFrmDate.Text + "\" to \"" + CmbToDate.Text + "\" ?", "Confirm records deletion Sales Vehicles", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteParkingDetailsOfRep(fromD, toD))
                    {
                        MessageBox.Show("Record has been Deleted....!", "Delete info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record were Not Deleted", "Delete info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            } 
        }

        private void DeleteFieldOfficer(string fromD, string toD)
        {
            DataTable dt = db.GetRecordCount(@"SELECT Count(Cast(Park_Date as datetime)) as Count FROM GPS_FO_PARKING_DETAILS
            WHERE (Cast(Park_Date as datetime) >= '" + fromD + "') AND (Cast(Park_Date as datetime) <= '" + fromD + "')");
            DataRow dr = dt.Rows[0];
            try
            {
                DialogResult result = MessageBox.Show("Do you really want to delete \"" + dr[0].ToString() + "\" records of\nField officer parking details from \"" + CmbFrmDate.Text + "\" to \"" + CmbToDate.Text + "\" ?", "Confirm records deletion Field Officer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    if (db.DeleteParkingDetailsOfFo(fromD, toD))
                    {
                        MessageBox.Show("Record has been Deleted....!", "Delete info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                    }
                    else
                        MessageBox.Show("Sorry Somthing is Wrong.....!");
                }
                else
                    MessageBox.Show("Record were Not Deleted", "Delete info", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Record Not Deleted " + ex.ToString() + "....!", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            } 
        }

        private void AdminDeteteParkingData_Load(object sender, EventArgs e)
        {
            GetRepOrFarmParkDatFrm(@"SELECT distinct Park_Date as dateId, CONVERT(VARCHAR(11), CAST(Park_Date AS datetime), 106) AS Date
                FROM GPS_FO_PARKING_DETAILS");
        }

        public void GetRepOrFarmParkDatFrm(string query)
        {
            DataTable dt1 = db.GetAllFieldOfficerParkDateFromTo(query);
            CmbFrmDate.ValueMember = "datId";
            CmbFrmDate.DisplayMember = "datname";
            CmbFrmDate.DataSource = dt1;
        }

        public void GetRepOrFarmParkDatTo(string query)
        {
            DataTable dt1 = db.GetAllFieldOfficerParkDateFromTo(query);
            CmbToDate.ValueMember = "datId";
            CmbToDate.DisplayMember = "datname";
            CmbToDate.DataSource = dt1;
        }

        private void CmbFrmDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = (CmbFrmDate.SelectedValue).ToString();
            if (RBFarmer.Checked == true)
            {
                GetRepOrFarmParkDatTo(@"SELECT distinct Park_Date as dateId, CONVERT(VARCHAR(11), CAST(Park_Date AS datetime), 106) AS Date
            FROM GPS_FO_PARKING_DETAILS
            WHERE ((Cast(Park_Date as datetime) >= '" + id + "'))");
            }
            else if (RBCustomer.Checked == true)
            {
                GetRepOrFarmParkDatTo(@"SELECT distinct CAST(Vhi_Park_Date AS datetime),Vhi_Park_Date as dateId, CONVERT(VARCHAR(11), CAST(Vhi_Park_Date AS datetime), 106) AS Date
            FROM GPS_TRK_VEHICLE_PARKING
            WHERE ((Cast(Vhi_Park_Date as datetime) >= '" + id + "')) order by CAST(Vhi_Park_Date AS datetime)");
            }
        }

        private void RBFarmer_CheckedChanged(object sender, EventArgs e)
        {
            GetRepOrFarmParkDatFrm(@"SELECT distinct CAST(Park_Date AS datetime), Park_Date as dateId, CONVERT(VARCHAR(11), CAST(Park_Date AS datetime), 106) AS Date
                FROM GPS_FO_PARKING_DETAILS order by CAST(Park_Date AS datetime)");
        }

        private void RBCustomer_CheckedChanged(object sender, EventArgs e)
        {
            GetRepOrFarmParkDatFrm(@"SELECT distinct CAST(Vhi_Park_Date AS datetime),Vhi_Park_Date as dateId,CONVERT(VARCHAR(11), CAST(Vhi_Park_Date AS datetime), 106) AS Date
FROM GPS_TRK_VEHICLE_PARKING order by CAST(Vhi_Park_Date AS datetime)");
        }
    }
}
