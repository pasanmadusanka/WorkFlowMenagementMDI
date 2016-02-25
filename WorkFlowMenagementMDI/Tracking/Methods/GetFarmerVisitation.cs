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
    class GetFarmerVisitation
    {
        SqlConnection conn;
        int lastUserId = Properties.Settings.Default.UserID;
        public GetFarmerVisitation()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetFarmersDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT distinct track.FRM_FO_LOC_ID,fo.FLD_OFF_MST_NAME FROM GPS_FRM_FIELD_OFFICER_TRACKER as track inner join
                FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["FRM_FO_LOC_ID"], sdr["FLD_OFF_MST_NAME"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public DataSet FilterVisitationDetails(string fromDate, string toDate, int officerID)
        {
            DataSet dset = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT distinct mast.FAR_HDR_MST_NAME,park.Park_Date as Date, mast.FAR_HDR_MST_CODE,farm.GPS_FRM_LOC_LATITUDE,GPS_FRM_LOC_LONGITUDE
                FROM GPS_FARM_LOCATION_MASTER as farm inner join 
                FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
                GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
                FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join
                GPS_FO_PARKING_DETAILS as park on track.FRM_FO_LOC_ID=park.Device_Name
                where Cast(park.Park_Date as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and " +
                " Cast(park.Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and track.FRM_FO_LOC_ID=" + officerID + " and CAST(ROUND(farm.GPS_FRM_LOC_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Latitude, 3) AS FLOAT) " +
                " and CAST(ROUND(farm.GPS_FRM_LOC_LONGITUDE, 3) AS FLOAT)=cast(ROUND(park.Longitude, 3)as Float)", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dset, "VisitationDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }

            return dset;
        }

        public DataTable VisitationLocations(string fromDate, string toDate,int officerID) 
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("lat", typeof(string));
            dt.Columns.Add("lon", typeof(string));
            dt.Columns.Add("area", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                

                SqlCommand scmd = new SqlCommand(@"SELECT distinct mast.FAR_HDR_MST_NAME,park.Park_Date,farm.GPS_FRM_lOC_ID,mast.FAR_HDR_MST_CODE,farm.GPS_FRM_LOC_LATITUDE,
                farm.GPS_FRM_LOC_LONGITUDE,ar.AREA_MST_NAME FROM GPS_FARM_LOCATION_MASTER as farm inner join 
                FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
                GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
                FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join
                GPS_FO_PARKING_DETAILS as park on track.FRM_FO_LOC_ID=park.Device_Name inner join
                AREA_MASTER as ar on farm.GPS_FRM_LOC_AR_MST_CODE=ar.AREA_MST_CODE
                where Cast(park.Park_Date as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' " + 
                " and track.FRM_FO_LOC_ID= "+ officerID +"  and CAST(ROUND(farm.GPS_FRM_LOC_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Latitude, 3) AS FLOAT) " +
                " and CAST(ROUND(farm.GPS_FRM_LOC_LONGITUDE, 3) AS FLOAT)=cast(ROUND(park.Longitude, 3)as Float) order by park.Park_Date", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FAR_HDR_MST_NAME"], sdr["GPS_FRM_lOC_ID"], sdr["FAR_HDR_MST_CODE"], sdr["GPS_FRM_LOC_LATITUDE"], sdr["GPS_FRM_LOC_LONGITUDE"], sdr["AREA_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable NoOfFarmersVisited(string fromDate, string toDate, int officerID)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("nOFarmers", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"SELECT count(distinct mast.FAR_HDR_MST_NAME) as count 
                FROM GPS_FARM_LOCATION_MASTER as farm inner join 
                FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
                GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
                FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join
                GPS_FO_PARKING_DETAILS as park on track.FRM_FO_LOC_ID=park.Device_Name inner join
                AREA_MASTER as ar on farm.GPS_FRM_LOC_AR_MST_CODE=ar.AREA_MST_CODE
                where Cast(park.Park_Date as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' " +
                " and track.FRM_FO_LOC_ID= " + officerID + "  and CAST(ROUND(farm.GPS_FRM_LOC_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Latitude, 3) AS FLOAT) " +
                " and CAST(ROUND(farm.GPS_FRM_LOC_LONGITUDE, 3) AS FLOAT)=cast(ROUND(park.Longitude, 3)as Float)", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["count"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        } 
        public void DeleteTempTableData()
        {
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"delete from GPS_CUS_PARK_TBL_TMP where USERID= " + lastUserId + "";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }

        }
        public bool WrightVisitsToTemp(string fromDate, string toDate, int offID, int user, string pc)
        {
            bool status = false;
            try
            {//'"+Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy")+"'
                DeleteTempTableData();//Clear Table data.
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"INSERT INTO [dbo].[GPS_CUS_PARK_TBL_TMP]
           ( ID,[DATE] ,[IV2NAME] , [ILoc] ,[V4] ,[V5] , INT2, USERID,TERMINAL)

		   SELECT distinct farm.GPS_FRM_lOC_ID as ID, park.Park_Date as [DATE],
		   farm.GPS_FRM_HDR_MST_ID as [IV2NAME],farm.GPS_FRM_LOC_AR_MST_CODE as [ILoc], substring(park.Start_Time,12,8)as [V4],substring(park.End_Time,12,8)as [V5],
		   sum(park.Period_Of_Time) as INT2," + user + " as USERID,'" + pc + "' as TERMINAL " +
        " FROM GPS_FARM_LOCATION_MASTER as farm inner join "+
        " FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID = mast.FAR_HDR_MST_FAR_NO inner join "+
        " GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join "+
        " FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join "+
        " GPS_FO_PARKING_DETAILS as park on track.FRM_FO_LOC_ID=park.Device_Name " +
        " where Cast(park.Park_Date as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and " +
        " track.FRM_FO_LOC_ID=" + offID + " and CAST(ROUND(farm.GPS_FRM_LOC_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Latitude, 3) AS FLOAT) " +
        " and CAST(ROUND(farm.GPS_FRM_LOC_LONGITUDE, 3) AS FLOAT)=cast(ROUND(park.Longitude, 3)as Float)"+
        " group by GPS_FRM_lOC_ID,Park_Date,GPS_FRM_HDR_MST_ID,GPS_FRM_LOC_AR_MST_CODE,Start_Time,End_Time,Period_Of_Time"+
        " order by [V4] ,[V5]";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Wright Locations"); }
            finally { conn.Close(); }
            return status;
        }
    }
}
