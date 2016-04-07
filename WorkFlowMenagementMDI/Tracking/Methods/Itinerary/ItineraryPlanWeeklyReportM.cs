using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;
using WorkFlowMenagementMDI.Tracking.Reports.Itinerary;

namespace WorkFlowMenagementMDI.Tracking.Methods.Itinerary
{
    public class ItineraryPlanWeeklyReportM
    {
        SqlConnection conn;
        int lastuser = Properties.Settings.Default.UserID;
        public ItineraryPlanWeeklyReportM()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
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
                                               where USERID ="+ lastuser +""+
                                                " GROUP BY Date,id "+
                                                " HAVING  COUNT(*) > 1) "+
                     " IF @@Rowcount = 0 "+
                     "    BREAK ; "+
                   " END "+
                " SET ROWCOUNT 0";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Removing duplicats"); }
            finally { conn.Close(); }
        }//Remove duplicate rows
        public ItineraryPlanDataSet GetItinaryPlanActual(int fieldOffId,int wipID)
        {
            ItineraryPlanDataSet visitDS = new ItineraryPlanDataSet();
            try
            {
                if (fieldOffId == 37)
                {
                    RemoveDuplicats();
                }
                //RemoveDuplicats();//If comment duplicate will remain
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"select substring(WIPM.ITINERARY_MST_DATE,4,3) + substring(WIPM.ITINERARY_MST_DATE,1,3)+substring(WIPM.ITINERARY_MST_DATE,7,4) as [Date],
                    convert(VARCHAR, CAST(WIPM.ITINERARY_MST_DATE AS DATETIME),106) as ITINERARY_DATE,Fl.FAR_LOC_MST_NAME,FHM.FAR_HDR_MST_CODE, FHM.FAR_HDR_MST_NAME
                , BCH.BAT_CRT_CODE,BCH.BAT_CRT_NO_CHICKS , dbo.GET_FRM_PRE_BROO_STATUS(WIPM.ITINERARY_PB_STSTUS) AS P_B_Status
                    from GPS_CUS_PARK_TBL_TMP as GCPT inner join 
                    WEEKLY_ITINERARY_PLAN_MASTER as WIPM on GCPT.IV2NAME= WIPM.FAR_HDR_MST_FAR_NO_FK inner join
                    ITINERARY_PLAN_SERIES_TBL AS IPST ON WIPM.ITINERARY_ID_FK = IPST.ITINERARY_ID inner join
                    FARMER_MASTER_FARM_DETAILS AS FMFD on WIPM.FAR_HDR_MST_FAR_NO_FK= FMFD.FAR_MST_FAM_DET_CODE Inner join
                    FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO inner join
                    FIELD_OFFICER_MASTER FOM ON FMFD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE inner join
                    FARMER_LOCATION as FL on FMFD.FAR_MST_FAM_DET_LOCATION_CODE=FL.FAR_LOC_MST_CODE inner join
                    BATCH_CREATE_HEADER as BCH on WIPM.BAT_CRT_NO_FK = BCH.BAT_CRT_NO
                    where FOM.FLD_OFF_MST_CODE=" + fieldOffId + " and GCPT.USERID=" + lastuser + " and IPST.ITINERARY_ID =" + wipID + " order by FHM.FAR_HDR_MST_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(visitDS, "ItinaryPlanDT"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GetItinaryPlanActual()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return visitDS;
        }

        public ItineraryPlanDataSet GetItinaryPlanNotVisits(int fieldOffId, int wipID)
        {
            ItineraryPlanDataSet visitDS = new ItineraryPlanDataSet();
            try
            {
                //RemoveDuplicats();//If comment duplicate will remain 
                //WIPM.ITINERARY_MST_DATE = GCPT.DATE AND 
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"select substring(WIPM.ITINERARY_MST_DATE,4,3) + substring(WIPM.ITINERARY_MST_DATE,1,3)+substring(WIPM.ITINERARY_MST_DATE,7,4) as [Date]
,convert(VARCHAR, CAST(WIPM.ITINERARY_MST_DATE AS DATETIME),106) as ITINERARY_DATE, Fl.FAR_LOC_MST_NAME,FHM.FAR_HDR_MST_CODE, FHM.FAR_HDR_MST_NAME
                , BCH.BAT_CRT_CODE,BCH.BAT_CRT_NO_CHICKS , dbo.GET_FRM_PRE_BROO_STATUS(WIPM.ITINERARY_PB_STSTUS) AS P_B_Status
                    from WEEKLY_ITINERARY_PLAN_MASTER as WIPM inner join
                    ITINERARY_PLAN_SERIES_TBL AS IPST ON WIPM.ITINERARY_ID_FK = IPST.ITINERARY_ID inner join
                    FARMER_MASTER_FARM_DETAILS AS FMFD on WIPM.FAR_HDR_MST_FAR_NO_FK= FMFD.FAR_MST_FAM_DET_CODE Inner join
                    FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO inner join
                    FIELD_OFFICER_MASTER FOM ON FMFD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE inner join
                    FARMER_LOCATION as FL on FMFD.FAR_MST_FAM_DET_LOCATION_CODE=FL.FAR_LOC_MST_CODE inner join
                    BATCH_CREATE_HEADER as BCH on WIPM.BAT_CRT_NO_FK = BCH.BAT_CRT_NO 
                    where IPST.ITINERARY_ID =" + wipID + " and FOM.FLD_OFF_MST_CODE=" + fieldOffId + " " +
                    " and NOT EXISTS(SELECT NULL "+
                   " FROM GPS_CUS_PARK_TBL_TMP as GCPT WHERE WIPM.FAR_HDR_MST_FAR_NO_FK = GCPT.IV2NAME and GCPT.USERID=" + lastuser + ") order by FHM.FAR_HDR_MST_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(visitDS, "ItinaryPlanDT"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GetItinaryPlanActual()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return visitDS;
        }

        public WIPDataSet GetWIPSereas(int wipID, string query)
        {
            WIPDataSet getWIPSeries = new WIPDataSet();
            try
            { 
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlCommand cmd = new SqlCommand(@"SELECT WIPM.ITINERARY_MST_ID, IPST.WIP_CODE, CONVERT(VARCHAR, CAST(WIPM.ITINERARY_MST_DATE AS DATETIME), 106) AS ITINERARY_MST_DATE_Order, FL.FAR_LOC_MST_NAME, FHM.FAR_HDR_MST_CODE, 
                 FHM.FAR_HDR_MST_NAME, BCH.BAT_CRT_CODE, BCH.BAT_CRT_NO_CHICKS, FOM.FLD_OFF_MST_NAME, dbo.GET_FRM_PRE_BROO_STATUS(WIPM.ITINERARY_PB_STSTUS) AS P_B_Status
                FROM WEEKLY_ITINERARY_PLAN_MASTER AS WIPM INNER JOIN
                ITINERARY_PLAN_SERIES_TBL AS IPST ON WIPM.ITINERARY_ID_FK = IPST.ITINERARY_ID INNER JOIN
                FARMER_MASTER_FARM_DETAILS AS FMFD ON WIPM.FAR_HDR_MST_FAR_NO_FK = FMFD.FAR_MST_FAM_DET_CODE INNER JOIN
                FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO INNER JOIN
                FIELD_OFFICER_MASTER AS FOM ON FMFD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE INNER JOIN
                FARMER_LOCATION AS FL ON FMFD.FAR_MST_FAM_DET_LOCATION_CODE = FL.FAR_LOC_MST_CODE INNER JOIN
                BATCH_CREATE_HEADER AS BCH ON WIPM.BAT_CRT_NO_FK = BCH.BAT_CRT_NO
                WHERE (IPST.ITINERARY_ID = "+wipID+") " +query+ " ORDER BY FOM.FLD_OFF_MST_NAME,ITINERARY_MST_DATE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(getWIPSeries, "WIPDT"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "GetItinaryPlanActual()", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally { conn.Close(); }
            return getWIPSeries;
        }
        public DataTable GetDataToReport(int wipId,int fieldOff)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fromDat", typeof(string));
            dt.Columns.Add("toDat", typeof(string));
            dt.Columns.Add("fieldOff", typeof(string));
            dt.Columns.Add("wipCode", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select fom.FLD_OFF_MST_NAME,convert(VARCHAR, CAST(IPST.DATE_FROM AS DATETIME),106) as DATE_FROM,convert(VARCHAR, CAST(IPST.DATE_TO AS DATETIME),106) as DATE_TO,IPST.WIP_CODE
                from FIELD_OFFICER_MASTER as FOM, ITINERARY_PLAN_SERIES_TBL as IPST
                where fom.FLD_OFF_MST_CODE=" + fieldOff + " and IPST.ITINERARY_ID=" + wipId + "";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["DATE_FROM"], sdr["DATE_TO"], sdr["FLD_OFF_MST_NAME"], sdr["WIP_CODE"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
