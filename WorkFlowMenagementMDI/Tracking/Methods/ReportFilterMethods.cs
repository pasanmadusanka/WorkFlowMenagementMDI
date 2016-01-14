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
    class ReportFilterMethods
    {
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
            catch (Exception ex) { MessageBox.Show(ex.Message); } finally { conn.Close(); }
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
                RemoveDuplicats();
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"SELECT ID as Farmer_ID, 
                substring(gps.DATE,4,3) + substring(gps.DATE,1,3)+substring(gps.DATE,7,4) as DATE, 
                frm.FAR_HDR_MST_CODE,frm.FAR_HDR_MST_NAME, area.AREA_MST_NAME, 
                V4 as Start_Time, V5 as End_Time,INT2 as Duration
                FROM GPS_CUS_PARK_TBL_TMP as gps inner join
                FARMER_HEADER_MASTER as frm on gps.IV2NAME=frm.FAR_HDR_MST_FAR_NO inner join
                AREA_MASTER as area on gps.ILoc=area.AREA_MST_CODE"))
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

//        public CustVisitDS GetCustomerDropingBuys(string fromDate, string toDate, int trackID, int repID)
//        {
//            CustVisitDS custVisit = new CustVisitDS();
//            try
//            {
//                using (SqlCommand scmd = new SqlCommand(@"select distinct gpsCus.GPS_CUST_ID,park.Vhi_Park_Date as dat,
//                substring(park.Vhi_Park_Date,4,3) + substring(park.Vhi_Park_Date,1,3)+substring(park.Vhi_Park_Date,7,4) as Vhi_Park_Date,chart.CHT_ACC_ALIAS,chart.CHT_ACC_NAME,gpsCus.GPS_CUST_AREA,
//                substring(park.Vhi_Start_Time,12,8)as Start_Time,substring(park.Vhi_Stop_Time,12,8)as End_Time,park.Vhi_Parking_Duration
//                from GPS_CUSTOMER_LOCATION_MASTER as gpsCus inner join
//                CHART_ACC as chart on gpsCus.GPS_CUST_CHART_ACC_ID=chart.CHT_ACC_ACC_NO inner join
//                GPS_TRACKING_VEHICLE_DEVICE as track on gpscus.GPS_CUST_DEVISE_ID=track.VhiTrackerID inner join
        //                GPS_TRK_VEHICLE_PARKING as park on park.VHI_DEVICE_NAME=track.VhiTrackerIDtrack.VhiTrackerID inner join
//                LOCATION as locemp on locemp.LOC_LOC_CODE=gpscus.GPS_CUST_SALES_REP_ID 
//                where CAST(ROUND(gpsCus.GPS_CUST_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Latitude, 3) AS FLOAT) and CAST(ROUND(gpsCus.GPS_CUST_LONGITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Longitude, 3) AS FLOAT) 
//                and  park.Vhi_Park_Date >='" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and park.Vhi_Park_Date<='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and locemp.LOC_LOC_CODE=" + repID + " and track.VhiTrackerID=" + trackID + " order by park.Vhi_Park_Date,substring(park.Vhi_Start_Time,12,8)"))
//                {
//                    using (SqlDataAdapter sda = new SqlDataAdapter())
//                    {
//                        scmd.Connection = conn; sda.SelectCommand = scmd;
//                        sda.Fill(custVisit, "CustVisitDT");
//                    }
//                }
//            }
//            catch (Exception ex) { MessageBox.Show("Reports " + ex.Message, "GetCustomerDropingBuys()", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
//            return custVisit;
//        }

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
