using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.FieldOfficers
{
    public class FieldOfficerCreationMethods
    {
        SqlConnection conn;
        public FieldOfficerCreationMethods()
        { DBAccess db = new DBAccess(); conn = db.conn; }

        public DataSet GetFOffocerToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT track.FRM_FO_LOC_ID, fom.FLD_OFF_MST_NAME, track.FRM_FO_BIKE_NO, track.FRM_FO_TRACKER_NO, track.FRM_FO_LATITUDE, track.FRM_FO_LONGITUDE
FROM GPS_FRM_FIELD_OFFICER_TRACKER AS track INNER JOIN FIELD_OFFICER_MASTER AS fom ON track.FRM_FO_MST_CODE_ID = fom.FLD_OFF_MST_CODE", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "FoDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public string GetLastOfficerId()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"SELECT TOP 1 FRM_FO_LOC_ID FROM GPS_FRM_FIELD_OFFICER_TRACKER
                ORDER BY FRM_FO_LOC_ID DESC";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["FRM_FO_LOC_ID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }

        public bool InsertNewOfficer(int foID, string bikNo, string deviceName, double lat, double longi)
        {
            int index = Convert.ToInt32(GetLastOfficerId());
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; INSERT INTO GPS_FRM_FIELD_OFFICER_TRACKER
           ( FRM_FO_LOC_ID ,FRM_FO_MST_CODE_ID ,FRM_FO_BIKE_NO ,FRM_FO_TRACKER_NO ,FRM_FO_LATITUDE ,FRM_FO_LONGITUDE)
                VALUES (" + index + ", '" + foID + "', '" + bikNo + "', '" + deviceName + "'," + lat + ", " + longi + ") COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public bool UpdateOfficer(int id, int fOid, double lat, double longi, string bikNo, string deviceName)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @" BEGIN TRANSACTION;
                UPDATE [dbo].[GPS_FRM_FIELD_OFFICER_TRACKER]
                SET [FRM_FO_MST_CODE_ID] ="+fOid+" ,[FRM_FO_BIKE_NO] = '"+bikNo+"' ,[FRM_FO_TRACKER_NO] ='"+deviceName+"' ,[FRM_FO_LATITUDE] ="+lat+" ,[FRM_FO_LONGITUDE] ="+longi+""+
                " WHERE FRM_FO_LOC_ID=" + id + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public bool DeleteOfficer(int id)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION;
                DELETE FROM [dbo].[GPS_FRM_FIELD_OFFICER_TRACKER] WHERE [FRM_FO_LOC_ID]=" + id + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable GetFOFromFoMasterCMB() 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FLD_OFF_MST_CODE, FLD_OFF_MST_NAME FROM FIELD_OFFICER_MASTER";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["FLD_OFF_MST_CODE"], sdr["FLD_OFF_MST_NAME"]); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
