using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Admin.Methods
{
    public class AdminDeleteParkHistoryMethods
    {
        SqlConnection conn;
        public AdminDeleteParkHistoryMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetAllFieldOfficerParkDateFromTo(string query)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("datId", typeof(string));
            dt.Columns.Add("datname", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["dateId"], sdr["Date"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } return dt;
        }


        public bool DeleteParkingDetailsOfFo(string fromDate, string toDate)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand Scmd = new SqlCommand(@"Delete FROM GPS_FO_PARKING_DETAILS
                WHERE (Cast(Park_Date as datetime) >= '" + fromDate + "') AND (Cast(Park_Date as datetime) <= '" + toDate + "')", conn);
                Scmd.Connection = conn;
                Scmd.CommandType = CommandType.Text;
                Scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("Delete Method() \n\n" + ex.Message.ToString(), "Delete Method", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable GetRecordCount(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                dt.Columns.Add("count", typeof(string));
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["Count"]); }
            }
            catch (Exception ex) { MessageBox.Show("Error with the GetRecordCount \n\n" + ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public bool DeleteParkingDetailsOfRep(string fromDate, string toDate)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand Scmd = new SqlCommand(@"Delete FROM GPS_TRK_VEHICLE_PARKING
                WHERE (Cast(Vhi_Park_Date as datetime) >= '" + fromDate + "') AND (Cast(Vhi_Park_Date as datetime) <= '" + toDate + "')", conn);
                Scmd.Connection = conn;
                Scmd.CommandType = CommandType.Text;
                Scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("Delete Method() \n\n" + ex.Message.ToString(), "Delete Method", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }
    }
}
