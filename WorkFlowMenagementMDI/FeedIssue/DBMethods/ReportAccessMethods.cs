using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;
using WorkFlowMenagementMDI.FeedIssue.ReportView;

namespace WorkFlowMenagementMDI.FeedIssue.DBMethods
{
    public class ReportAccessMethods
    {
        SqlConnection conn;
        public ReportAccessMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable FillReportHeader()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string)); dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("teli", typeof(string)); dt.Columns.Add("fax", typeof(string));
            dt.Columns.Add("email", typeof(string)); dt.Columns.Add("webAddr", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = new SqlCommand(@"SELECT [COMPANY_NAME] ,[ADDRESS] ,[TELE] ,[FAX] ,[EMAIL] ,[WEB_ADDRESS] FROM [NelnaDB].[dbo].[COMPANY_MASTER]", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["COMPANY_NAME"], sdr["ADDRESS"], sdr["TELE"], sdr["FAX"], sdr["EMAIL"], sdr["WEB_ADDRESS"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }//Access the Report Header
         
        public DSReportFeedIssue FeedReqDateReport(string query)
        {
            DSReportFeedIssue visitDS = new DSReportFeedIssue();
            try
            { 
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(visitDS, "DTFeed"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report Filter\n" + ex.Message.ToString(), "GetFeildOffVisitation()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return visitDS;
        }

        public DSFeedIssueWeekPlan FeedReqDateRangeReport(string fromDate, string toDate)
        {
            DSFeedIssueWeekPlan feedSche = new DSFeedIssueWeekPlan();
            int userID = Properties.Settings.Default.UserID;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID,FHM.FAR_HDR_MST_CODE,FHM.FAR_HDR_MST_NAME,FL.FAR_LOC_MST_NAME,  
                substring(dateVar,4,3) + substring(dateVar,1,3)+substring(dateVar,7,4) as dateVara,dateVar, weekI, InputI,cc.COM_CAT_NAME, BCH.BAT_CRT_NO_CHICKS
                FROM FEED_ISSUE_SCHEDULE_TEMP_SUB as FISTS INNER JOIN BATCH_CREATE_HEADER as BCH ON FISTS.ID = BCH.BAT_CRT_NO INNER JOIN  
                FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join 
                FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN 
                FARMER_LOCATION as FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE inner join
                COMMON_CATEGORY as CC ON FISTS.ItemI = cc.COM_CAT_CODE
                where CAST(dateVar AS datetime) >= '" + fromDate + "' and CAST(dateVar AS datetime) <='" + toDate + "' and UserName="+userID+" order by CAST(dateVar AS datetime)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(feedSche, "DTFeedIssue"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report Filter\n" + ex.Message.ToString(), "GetFeildOffVisitation()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return feedSche;
        }
    }
}
