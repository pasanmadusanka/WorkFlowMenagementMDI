using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.SalesCustomers
{
    public class DeviseDetailsOfVehicleMethod
    {
        SqlConnection conn;
        public DeviseDetailsOfVehicleMethod()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet GetVehicleToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT VhiTrackerID, VhiDeviceName, VehicleID, VhiLatitude, VhiLongitude
                FROM GPS_TRACKING_VEHICLE_DEVICE", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "vehicleTrack");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public DataTable GetVehicleToCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT VHC_MST_CODE, VHC_MST_NO FROM dbo.VEHICLE_MASTER
                WHERE (VHC_MST_CATEGORY = '1' OR VHC_MST_CATEGORY = '6') AND (ACT_STATUS = '0')
                ORDER BY VHC_MST_NO";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["VHC_MST_CODE"], sdr["VHC_MST_NO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Vehicle Access", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public bool UpdateVehicleTracking(int id, string fName, int vehicle, double lat, double longi)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION;  UPDATE [dbo].[GPS_TRACKING_VEHICLE_DEVICE]
                    SET [VhiDeviceName] = '" + fName + "' ,[VehicleID] = " + vehicle + ",VhiLatitude = " + lat + ", [VhiLongitude] = " + longi + "" +
                    "WHERE [VhiTrackerID]=" + id + "COMMIT TRANSACTION;";

                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
    }
}
