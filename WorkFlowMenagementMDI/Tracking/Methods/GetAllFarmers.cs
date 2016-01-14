using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods
{
    public class GetAllFarmers
    {
        SqlConnection conn;

        public GetAllFarmers()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetFarmersCount()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("count", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select count(*) as count from FARMER_LOCATION_MASTER where code is not null";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["count"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally{conn.Close();}
            return dt;
        }

        public DataTable GetFarmersLocDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("lat", typeof(string));
            dt.Columns.Add("lon", typeof(string));
            dt.Columns.Add("cod", typeof(string));
            dt.Columns.Add("foId", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT Farmer_ID , Farmer_Name , farmers.Latitude ,farmers.Longitude ,Code ,fo.Name
                FROM FARMER_LOCATION_MASTER as farmers inner join FIELD_OFFICER as fo on farmers.[O/T] = fo.Officer_ID where code is not null";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Farmer_ID"], sdr["Farmer_Name"], sdr["Latitude"], sdr["Longitude"], sdr["Code"], sdr["Name"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
