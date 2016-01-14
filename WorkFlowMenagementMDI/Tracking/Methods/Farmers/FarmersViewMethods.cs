using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.Farmers
{
    public class FarmersViewMethods
    {
        SqlConnection conn;
        public FarmersViewMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetAllFarmersCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select GPS_FRM_lOC_ID,FHM.FAR_HDR_MST_CODE+' - '+FHM.FAR_HDR_MST_NAME as 
                FAR_HDR_MST_NAME from GPS_FARM_LOCATION_MASTER as GFLM inner join
                FARMER_HEADER_MASTER as FHM on GFLM.GPS_FRM_HDR_MST_ID=FHM.FAR_HDR_MST_FAR_NO
                order by FHM.FAR_HDR_MST_CODE";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["GPS_FRM_lOC_ID"], sdr["FAR_HDR_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(),"Farmers Method",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { conn.Close(); } return dt;
        }//Get farmers with locs
        public DataTable GetAreasCombo()
        {
            DataTable dt= new DataTable();
            dt.Columns.Add("area", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select distinct Am.AREA_MST_NAME
            from GPS_FARM_LOCATION_MASTER as GFLM inner join
            AREA_MASTER as AM on GFLM.GPS_FRM_LOC_AR_MST_CODE=AM.AREA_MST_CODE ";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["AREA_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Areas Filter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); } return dt;
        }//Get Area of Farmers
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
                scmd.CommandText = @"SELECT GFFOT.FRM_FO_LOC_ID,FOM.FLD_OFF_MST_NAME
                From GPS_FRM_FIELD_OFFICER_TRACKER AS GFFOT INNER JOIN
                FIELD_OFFICER_MASTER AS FOM ON GFFOT.FRM_FO_MST_CODE_ID=FOM.FLD_OFF_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FRM_FO_LOC_ID"], sdr["FLD_OFF_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Feild officer Filter", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }//Get FO Of farmersS

        public DataSet GetFarmerToGrid(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "VisitationDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public DataTable GetFarmersCount(string countQuery)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("count", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = countQuery;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["count"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetFarmersLocDetails(string query)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fName", typeof(string)); 
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("area", typeof(string));
            dt.Columns.Add("lat", typeof(string));
            dt.Columns.Add("lon", typeof(string));
            dt.Columns.Add("foId", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Farmer_Name"], sdr["Code"], sdr["Area_Name"], sdr["Latitude"], sdr["Longitude"], sdr["Name"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
        public string ViewDetailsOnBrowser()
        {
            StreamReader srheader = new StreamReader("FarmersLocationsHeader.txt");
            String header = srheader.ReadToEnd();
            StreamReader sr = new StreamReader("LocationsTextFarmers.txt");
            String locations = sr.ReadToEnd();
            StreamReader srFooter = new StreamReader("FarmersLocationsFooter.txt");
            String footer = srFooter.ReadToEnd();
            string toBrowser = header + locations + footer;
            sr.Close();
            return toBrowser;
        }//Load map to the browser with Driving Rout view;
    }
}
