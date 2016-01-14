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
    public class FeedIssueScheduleMethods
    {
        SqlConnection conn;
        public FeedIssueScheduleMethods()
        {
            DBAccess db = new DBAccess();
            conn=db.conn;
        }

        public bool InsertIntoFeedTemp(int bID, double wK1, double wK2, double wK3, double wK4, double wK5, 
            string wk1Dat, string wk2Dat, string wk3Dat, string wk4Dat, string wk5Dat)
        {
            int user = Properties.Settings.Default.UserID;
            bool status = false;
            string pc = System.Environment.MachineName.ToString();
            DataTable dt = GetDateTime();
            DataRow dr = dt.Rows[0];
            string date = dr[0].ToString();
            try 
            {
                string query = @"BEGIN TRANSACTION;
            INSERT INTO [dbo].[FEED_ISSUE_SCHEDULE_TEMP]
            ([FED_ISS_SCH_BATCH_ID] ,[FED_ISS_SCH_WEK1_IN] ,[FED_ISS_SCH_WEK2_IN] ,[FED_ISS_SCH_WEK3_IN] ,[FED_ISS_SCH_WEK4_IN]
            ,[FED_ISS_SCH_WEK5_IN] ,[FED_ISS_SCH_ISSUE_WEK1] ,[FED_ISS_SCH_ISSUE_WEK2] ,[FED_ISS_SCH_ISSUE_WEK3] ,[FED_ISS_SCH_ISSUE_WEK4]
            ,[FED_ISS_SCH_ISSUE_WEK5] ,[FED_ISS_SCH_ISSUE_CRE_DAT] ,[FED_ISS_SCH_ISSUE_USER] ,[FED_ISS_SCH_ISSUE_PC])
            VALUES ("+bID+","+wK1+","+wK2+","+wK3+","+wK4+","+wK5+",'"+wk1Dat+"','"+wk2Dat+"','"+wk3Dat+"',"+
                " '" + wk4Dat + "','" + wk5Dat + "','" + date + "',"+user+",'" + pc + "') COMMIT TRANSACTION;";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Insert InTo FeedTemp"); }
            finally { conn.Close(); }
            return status;
        }//Insert Feed Schedule

        public bool UpdateIntoFeedTemp(int bID,string user)
        { 
            bool status = false;   
            try
            {
                string query = @"update FEED_ISSUE_SCHEDULE_TEMP
                set FED_ISS_SCH_ISSUE_USER='" + user + "' where [FED_ISS_SCH_BATCH_ID]=" + bID + "";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Update FeedTemp"); }
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
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT CONVERT(VARCHAR(24),GETDATE(),101) as Date";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Date"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error in Get DateTime()", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
