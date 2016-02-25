using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;
using WorkFlowMenagementMDI.Tracking.Reports;
using WorkFlowMenagementMDI.Tracking.Reports.Customers;

namespace WorkFlowMenagementMDI.Tracking.Methods
{
    public class ReportFilterMethods
    {
        int lastUserId = Properties.Settings.Default.UserID;
        SqlConnection conn;
        public ReportFilterMethods()
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

        public void RemoveDuplicats()
        {
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SET NOCOUNT ON
                SET ROWCOUNT 1
                WHILE 1 = 1
                   BEGIN
                      DELETE   FROM GPS_CUS_PARK_TBL_TMP
                      WHERE    id IN (SELECT  id
                                               FROM    GPS_CUS_PARK_TBL_TMP
                                               GROUP BY Date,id
                                               HAVING  COUNT(*) > 1)
                      IF @@Rowcount = 0
                         BREAK ;
                   END
                SET ROWCOUNT 0";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Removing duplicats"); }
            finally { conn.Close(); }
        }//Remove duplicate rows

        public FOVisitsDataSet GetFeildOffVisitation()
        {
            FOVisitsDataSet visitDS = new FOVisitsDataSet();
            try
            {
                //RemoveDuplicats();//If comment duplicate will remain
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID as Farmer_ID, 
                substring(gps.DATE,4,3) + substring(gps.DATE,1,3)+substring(gps.DATE,7,4) as DATE, 
                frm.FAR_HDR_MST_CODE,frm.FAR_HDR_MST_NAME, area.AREA_MST_NAME, 
                V4 as Start_Time, V5 as End_Time,INT2 as Duration
                FROM GPS_CUS_PARK_TBL_TMP as gps inner join
                FARMER_HEADER_MASTER as frm on gps.IV2NAME=frm.FAR_HDR_MST_FAR_NO inner join
                AREA_MASTER as area on gps.ILoc=area.AREA_MST_CODE where USERID=" + lastUserId + " order by DATE,Start_Time"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(visitDS, "VisitsDT"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report Filter\n" + ex.Message.ToString(), "GetFeildOffVisitation()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return visitDS;
        }//Populate DataSet Feild Officer Visitations3

        public CustVisitDS GetCustDropingBuysNew()
        {
            CustVisitDS custVisit = new CustVisitDS();
            try
            {//TMP.[DATE]
                RemoveDuplicats();
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand scmd = new SqlCommand(@"SELECT ID as GPS_CUST_ID,[DATE] as dat,
                substring([DATE],4,3) + substring([DATE],1,3)+substring([DATE],7,4) as Vhi_Park_Date, 
                chart.CHT_ACC_ALIAS,chart.CHT_ACC_NAME,v4 as GPS_CUST_AREA, V5 as Start_Time, V6 as End_Time, INT2 as Vhi_Parking_Duration,
				(select [dbo].GET_CUS_SALES_INFORMATIONS(TMP.[DATE],tmp.IV2NAME,tmp.ILoc,'QTY')) as QTY,
                    (select [dbo].GET_CUS_SALES_INFORMATIONS(TMP.[DATE],tmp.IV2NAME,tmp.ILoc,'AMT')) as AMT
                FROM GPS_CUS_PARK_TBL_TMP as tmp inner join
                CHART_ACC as chart on tmp.ILoc=chart.CHT_ACC_ACC_NO
                order by [DATE],Start_Time"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        scmd.Connection = conn; sda.SelectCommand = scmd;
                        sda.Fill(custVisit, "CustVisitDT");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Reports " + ex.Message, "GetCustomerDropingBuys()", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            finally { conn.Close(); }
            return custVisit;
        }
    }
}
