using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.Farmers
{
    class FarmersCreationMethods
    {
        SqlConnection conn;
        public FarmersCreationMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet GetFarmerToGrid(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "farmerDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }
        public DataSet GetFarmerSerchGrid(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "farmersearchDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }
        public DataTable FarmerHeaderToCMB()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FAR_HDR_MST_FAR_NO, FAR_HDR_MST_CODE + ' - ' + FAR_HDR_MST_NAME AS FAR_HDR_MST_NAME
                FROM FARMER_HEADER_MASTER order by FAR_HDR_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FAR_HDR_MST_FAR_NO"], sdr["FAR_HDR_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetFieldOfficersCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select trk.FRM_FO_LOC_ID,mas.FLD_OFF_MST_NAME from GPS_FRM_FIELD_OFFICER_TRACKER as trk inner join 
                FIELD_OFFICER_MASTER as mas on trk.FRM_FO_MST_CODE_ID=mas.FLD_OFF_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FRM_FO_LOC_ID"], sdr["FLD_OFF_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Feild officer Filter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetAreaToCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("area", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT AREA_MST_CODE, AREA_MST_NAME FROM AREA_MASTER";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["AREA_MST_CODE"], sdr["AREA_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Farmer Area", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        #region Get CRUID method
        public string GetLastFarmerId()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @" Select top 1 GPS_FRM_lOC_ID from GPS_FARM_LOCATION_MASTER order by GPS_FRM_lOC_ID desc";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["GPS_FRM_lOC_ID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }
        public bool InsertNewFarmer(int fID, double lat, double lon, int foID, int areaID)
        {
            int index = Convert.ToInt32(GetLastFarmerId());
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; INSERT INTO GPS_FARM_LOCATION_MASTER
 (GPS_FRM_lOC_ID, GPS_FRM_HDR_MST_ID, GPS_FRM_LOC_LATITUDE, GPS_FRM_LOC_LONGITUDE, GPS_FRM_LOC_FO_TRK_ID, GPS_FRM_LOC_AR_MST_CODE)
        VALUES  ("+index+" ,"+fID+","+lat+","+lon+", "+foID+","+areaID+") COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
        public bool UpdateFarmer(int id, int farmID, double lat, double longi, int fOID, int areaID)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; UPDATE GPS_FARM_LOCATION_MASTER
            SET GPS_FRM_HDR_MST_ID ="+farmID+", GPS_FRM_LOC_LATITUDE ="+lat+", GPS_FRM_LOC_LONGITUDE ="+longi+", GPS_FRM_LOC_FO_TRK_ID ="+fOID+", GPS_FRM_LOC_AR_MST_CODE ="+areaID+" "+
            " where GPS_FRM_lOC_ID= "+id+" COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
        public bool DeleteFarmer(int id)
        {
            bool status = false;
            try 
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; DELETE FROM GPS_FARM_LOCATION_MASTER
                where GPS_FRM_lOC_ID= "+id+" COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
        #endregion

        public DataTable SearchComboBox(string query,string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr[name]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Search Method", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
