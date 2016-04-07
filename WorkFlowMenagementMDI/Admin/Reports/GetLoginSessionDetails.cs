using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Admin.Reports
{
    public class GetLoginSessionDetails
    {
        SqlConnection conn;
        public GetLoginSessionDetails()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable FillReportHeader()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("teli", typeof(string));
            dt.Columns.Add("fax", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("webAddr", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                SqlCommand scmd = new SqlCommand(@"SELECT  
                            [COMPANY_NAME] ,[ADDRESS] ,[TELE]
                           ,[FAX] ,[EMAIL] ,[WEB_ADDRESS]
                    FROM [NelnaDB].[dbo].[COMPANY_MASTER]", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["COMPANY_NAME"], sdr["ADDRESS"], sdr["TELE"], sdr["FAX"], sdr["EMAIL"], sdr["WEB_ADDRESS"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Access the Report Header

        #region populate DataSet with data from Query For Log Sessions
        public SessionLogDS GetData(string fromDate, string toDate)
        {
            SessionLogDS logSession = new SessionLogDS();
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [LOG_SESSION_ID]
      ,SH.SEC_HDR_USR_NAME ,[LOG_ST_DATE_TIME] ,[LOG_END_DATE_TIME],dbo.DATEFILTER_FUNC(LOG_ST_DATE_TIME,LOG_END_DATE_TIME) as TIME_SPENT
      FROM [NelnaDB].[dbo].[WFMS_SESSIONS_LOG] as WSL inner join
      SECURITY_HEADER AS SH ON WSL.LOG_USER_ID=SH.SEC_HDR_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(logSession, "SessionLogDT"); }
                }
            }
            catch (Exception ex) { MessageBox.Show("ReportAccess class \n" + ex.Message.ToString(), "GetData", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            return logSession;
        }
        #endregion

        public DataSet FillGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT [LOG_SESSION_ID]
      ,SH.SEC_HDR_USR_NAME ,[LOG_ST_DATE_TIME] ,[LOG_END_DATE_TIME],dbo.DATEFILTER_FUNC(LOG_ST_DATE_TIME,LOG_END_DATE_TIME) as TIME_SPENT
  FROM [NelnaDB].[dbo].[WFMS_SESSIONS_LOG] as WSL inner join
  SECURITY_HEADER AS SH ON WSL.LOG_USER_ID=SH.SEC_HDR_CODE";
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                sda.Fill(ds, "FUEL_TMP_ISSUE_HEADER_SUB");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); }
            return ds;
        }//get All Fuel Details
    }
}
