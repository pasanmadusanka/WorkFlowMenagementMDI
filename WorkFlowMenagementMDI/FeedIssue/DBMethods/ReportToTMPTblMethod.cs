using WorkFlowMenagementMDI.Properties;
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
    public class ReportToTMPTblMethod
    {
        SqlConnection conn;
        public ReportToTMPTblMethod()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        public void DeleteTempTableData()
        {
            try
            {
                int user = Settings.Default.UserID;
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"delete from FEED_ISSUE_SCHEDULE_TEMP_SUB where UserName = "+user+"";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }
        public bool WrightVisitsToTemp(int batch)
        {
            bool status = false;
            int user = Settings.Default.UserID;
            string pc = System.Environment.MachineName.ToString();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP_SUB] ([ID] ,[dateVar] ,[InputI] ,[weekI],ItemI,UserName, PC) 
                SELECT FED_ISS_SCH_BATCH_ID as [ID],FED_ISS_SCH_ISSUE_WEK1 as [dateVar],FED_ISS_SCH_WEK1_IN as [InputI],1 as [weekI], 24 as ItemI,"+user+",'"+pc+"' "+
                "FROM FEED_ISSUE_SCHEDULE_TEMP where FED_ISS_SCH_BATCH_ID = " + batch + "  INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP_SUB] ([ID] ,[dateVar] ,[InputI] ,[weekI], ItemI,UserName, PC) " +
                "SELECT FED_ISS_SCH_BATCH_ID as [ID],FED_ISS_SCH_ISSUE_WEK2 as [dateVar],FED_ISS_SCH_WEK2_IN as [InputI],2 as [weekI], 24 as ItemI," + user + ",'" + pc + "' " +
                "FROM FEED_ISSUE_SCHEDULE_TEMP where FED_ISS_SCH_BATCH_ID = " + batch + "  INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP_SUB] ([ID] ,[dateVar] ,[InputI] ,[weekI], ItemI,UserName, PC) " +
                "SELECT FED_ISS_SCH_BATCH_ID as [ID],FED_ISS_SCH_ISSUE_WEK3 as [dateVar],FED_ISS_SCH_WEK3_IN as [InputI],3 as [weekI],24 as ItemI," + user + ",'" + pc + "' " +
                "FROM FEED_ISSUE_SCHEDULE_TEMP where FED_ISS_SCH_BATCH_ID = " + batch + "  INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP_SUB] ([ID] ,[dateVar] ,[InputI] ,[weekI],ItemI,UserName, PC) " +
                "SELECT FED_ISS_SCH_BATCH_ID as [ID],FED_ISS_SCH_ISSUE_WEK4 as [dateVar],FED_ISS_SCH_WEK4_IN as [Input4],4 as [weekI], 21 as ItemI," + user + ",'" + pc + "'  " +
                "FROM FEED_ISSUE_SCHEDULE_TEMP where FED_ISS_SCH_BATCH_ID = " + batch + "  INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP_SUB] ([ID] ,[dateVar] ,[InputI] ,[weekI], ItemI,UserName, PC) " +
                "SELECT FED_ISS_SCH_BATCH_ID as [ID],FED_ISS_SCH_ISSUE_WEK5 as [dateVar],FED_ISS_SCH_WEK5_IN as [InputI],5 as [weekI], 21 as ItemI," + user + ",'" + pc + "' " +
                "FROM FEED_ISSUE_SCHEDULE_TEMP where FED_ISS_SCH_BATCH_ID = " + batch + "";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Wright Locations"); }
            finally { conn.Close(); }
            return status;
        }
        public DataTable GetBatchCodeByArea(int area)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("batch", typeof(int));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FED_ISS_SCH_BATCH_ID 
                FROM FEED_ISSUE_SCHEDULE_TEMP as FIST INNER JOIN BATCH_CREATE_HEADER as BCH ON FIST.FED_ISS_SCH_BATCH_ID = BCH.BAT_CRT_NO INNER JOIN  
                FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join 
                FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN 
                FARMER_LOCATION as FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE 
                where FL.FAR_LOC_MST_CODE =" + area + ""; 
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FED_ISS_SCH_BATCH_ID"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Get Batch"); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
