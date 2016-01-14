using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FeedIssue.DBMethods
{
    public class FeedIssueScheduleListMethods
    {
        SqlConnection conn;

        public FeedIssueScheduleListMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        } 

        public DataSet GetFeedIssueToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"
                SELECT BAT_CRT_CODE as Batch,fhm.FAR_HDR_MST_CODE as Code,FHM.FAR_HDR_MST_NAME as Farmer,fl.[FAR_LOC_MST_NAME] as Location,[FED_ISS_SCH_WEK1_IN] as [Booster W1],[FED_ISS_SCH_WEK2_IN] as [Booster W2],[FED_ISS_SCH_WEK3_IN] [Booster W3],[FED_ISS_SCH_WEK4_IN] as [Finisher W4]
                ,[FED_ISS_SCH_WEK5_IN] as [Finisher W5],[FED_ISS_SCH_ISSUE_WEK1] as [1st Week ],[FED_ISS_SCH_ISSUE_WEK2] as [2nd Week] ,[FED_ISS_SCH_ISSUE_WEK3] as [3rd Week],[FED_ISS_SCH_ISSUE_WEK4] as [4th Week]
                ,[FED_ISS_SCH_ISSUE_WEK5] as [5th Week],FED_ISS_SCH_ISSUE_USER FROM FEED_ISSUE_SCHEDULE_TEMP as FIST INNER JOIN
                BATCH_CREATE_HEADER as BCH ON FIST.FED_ISS_SCH_BATCH_ID = BCH.BAT_CRT_NO INNER JOIN
                FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join
                FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN
                FARMER_LOCATION as FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE ";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "feedIssue");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public DataSet GetFeedIssueToGridByArea(int area)
        {
            DataSet ds = new DataSet();
            try
            {
                string query = @"SELECT FED_ISS_SCH_BATCH_ID as Batch,fhm.FAR_HDR_MST_CODE as Code,FHM.FAR_HDR_MST_NAME as Farmer,FL.[FAR_LOC_MST_NAME] as Location,[FED_ISS_SCH_WEK1_IN] as [Booster W1],[FED_ISS_SCH_WEK2_IN] as [Booster W2],[FED_ISS_SCH_WEK3_IN] [Booster W3],[FED_ISS_SCH_WEK4_IN] as [Finisher W4]
              ,[FED_ISS_SCH_WEK5_IN] as [Finisher W5],[FED_ISS_SCH_ISSUE_WEK1] as [1st Week ],[FED_ISS_SCH_ISSUE_WEK2] as [2nd Week] ,[FED_ISS_SCH_ISSUE_WEK3] as [3rd Week],[FED_ISS_SCH_ISSUE_WEK4] as [4th Week]
              ,[FED_ISS_SCH_ISSUE_WEK5] as [5th Week] FROM FEED_ISSUE_SCHEDULE_TEMP as FIST INNER JOIN
            BATCH_CREATE_HEADER as BCH ON FIST.FED_ISS_SCH_BATCH_ID = BCH.BAT_CRT_NO INNER JOIN
            FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join
            FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN
            FARMER_LOCATION as FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE 
	        where FL.FAR_LOC_MST_CODE=" +area+"";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "feedIssue");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public DataTable LoadListView()
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
                scmd.CommandText = @"SELECT FAR_LOC_MST_CODE, FAR_LOC_MST_NAME FROM FARMER_LOCATION";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["FAR_LOC_MST_CODE"], sdr["FAR_LOC_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error (list box data binding)", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public bool DeleteFeedIssue(int value)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; DELETE FROM [dbo].[FEED_ISSUE_SCHEDULE_TEMP]
                WHERE  FED_ISS_SCH_BATCH_ID=" + value + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }//Detete Feed Issue Schedule
    }
}
