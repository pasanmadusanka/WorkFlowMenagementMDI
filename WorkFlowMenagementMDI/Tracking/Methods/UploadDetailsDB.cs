using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using WorkFlowMenagementMDI.Database; 

namespace WorkFlowMenagementMDI.Tracking.Methods
{
    public class UploadDetailsDB
    {
        public SqlConnection conn;
        public UploadDetailsDB()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        public string GetIndexParkingDetails(string query,string readVal)
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = query;

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read[readVal].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); }
            if (index == "") { index = 1.ToString(); return index; }

            else { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get last index and add 1 to the value 

        public bool InsertByDataGridView(string device, string startTime, string endTime, double latitude, double longitude, int time, string date)
        {
            string qurey = @"SELECT top 1 ParkingID FROM GPS_FO_PARKING_DETAILS order by ParkingID desc";
            int id = Convert.ToInt32(GetIndexParkingDetails(qurey, "ParkingID"));
            string pc = System.Environment.MachineName.ToString();
            int user = Properties.Settings.Default.UserID;
            DataTable dateDT = GetDateTime();
            DataRow dateDR = dateDT.Rows[0];
            string adddate = Convert.ToDateTime(dateDR[0]).ToString("MM/dd/yyyy");

            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"INSERT INTO [dbo].[GPS_FO_PARKING_DETAILS]
                ([ParkingID] ,[Device_Name] ,[Start_Time] ,[End_Time] ,[Latitude] ,[Longitude] ,[Period_Of_Time],[Park_Date],Added_Date,AddedUser,TerminalName)
                VALUES (" + id + ",'" + device + "','" + startTime + "','" + endTime + "'," + latitude + "," + longitude +
                          " ," + time + ",'" + date + "','" + adddate + "','" + user + "','" + pc + "')";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "InsertByDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable GetDateTime()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("date", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"SELECT CONVERT(VARCHAR(24),GETDATE(),103) as date", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["date"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GetDateTime()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetDistDateInVehiPark()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed")  { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT DISTINCT Vhi_Park_Date FROM GPS_TRK_VEHICLE_PARKING";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Vhi_Park_Date"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }

        public void DeleteParkTableData()
        {
            try 
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"delete from GPS_TRK_VEHICLE_PARKING";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }

        }
        public bool InsertCustomersLoc(string device, string startTime, string endTime, double latitude, double longitude, int time, string date)
        {
            //DeleteParkTableData();
            string qurey = @"SELECT TOP 1 Vhi_Parking_ID FROM GPS_TRK_VEHICLE_PARKING order by Vhi_Parking_ID desc";
            int id = Convert.ToInt32(GetIndexParkingDetails(qurey, "Vhi_Parking_ID"));
            string pc = System.Environment.MachineName.ToString();
            int user = Properties.Settings.Default.UserID;
            DataTable dateDT = GetDateTime();
            DataRow dateDR = dateDT.Rows[0];
            string adddate = Convert.ToDateTime(dateDR[0]).ToString("MM/dd/yyyy");

            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"INSERT INTO [dbo].[GPS_TRK_VEHICLE_PARKING]
               ([Vhi_Parking_ID]  ,[VHI_DEVICE_NAME] ,[Vhi_Start_Time] ,[Vhi_Stop_Time] ,[Vhi_Latitude] ,[Vhi_Longitude]
               ,[Vhi_Parking_Duration] ,[Vhi_Park_Date] ,[Added_Date] ,[Vhi_User_Name] ,[Vhi_Terminal_Name])
                VALUES (" + id + ",'" + device + "','" + startTime + "','" + endTime + "'," + latitude + "," + longitude +
                          " ," + time + ",'" + date + "','" + adddate + "','" + user + "','" + pc + "')";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Sales Customer Visit", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable GetSalesRep()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("repName", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT LOC_LOC_CODE, LOC_LOC_SH_CODE + ' - ' + LOC_LOC_NAME AS LOC_LOC_NAME
                FROM LOCATION WHERE (LOC_LOC_GRP_CODE = 1) AND (LOC_LOC_SH_CODE + ' - ' + LOC_LOC_NAME IS NOT NULL)";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["LOC_LOC_CODE"], sdr["LOC_LOC_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }//Get EMPLOYEE_MASTER Rep to combo

        public string GetVehicleTrkIdByDevice(string device)
        {
            string trackID = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @" select track.VhiTrackerID,track.VhiDeviceName
                from GPS_TRACKING_VEHICLE_DEVICE as track where track.VhiDeviceName='"+device+"'";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { trackID = (read["VhiTrackerID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); }
            //if (trackID == "") { trackID = 1.ToString();  }

            //else { int getindex = Convert.ToInt32(trackID); return getindex.ToString(); }
            return trackID;
        }

        public string GetBikesTrkIdByDevice(string device)
        {
            string trackID = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @" select track.FRM_FO_LOC_ID,track.FRM_FO_TRACKER_NO
                from GPS_FRM_FIELD_OFFICER_TRACKER as track where track.FRM_FO_TRACKER_NO='" + device + "'";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { trackID = (read["FRM_FO_LOC_ID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); } 
            return trackID;
        }
    }
}
