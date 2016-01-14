using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.Database
{
    class FarmersMethods
    {
        SqlConnection conn;

        public FarmersMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetAllFarmers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT Farmer_ID ,Code + ' - ' + Farmer_Name as Farmer_Name
                FROM FARMER_LOCATION_MASTER";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FARMER_ID"], sdr["Farmer_Name"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } return dt;
        }

        public DataTable GetAllFarmersToDestination(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FARMER_ID, Farmer_Name, Latitude, Longitude
                FROM FARMER_LOCATION_MASTER
                WHERE (FARMER_ID <> " + id + ")";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FARMER_ID"], sdr["Farmer_Name"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } return dt;
        }
        public DataTable GetLatitudeNLongitude(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("lat", typeof(string));
            dt.Columns.Add("lon", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT Latitude, Longitude
                FROM FARMER_LOCATION_MASTER
                where FARMER_ID=" + id + "";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["Latitude"], sdr["Longitude"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } return dt;
        }
    }
}
