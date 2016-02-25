using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.Itinerary
{
    public class ItineraryPlanComparisionMethods
    {
        SqlConnection conn;
        public ItineraryPlanComparisionMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetFromToDateForWIPCode(int id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fromDate", typeof(string));
            dt.Columns.Add("toDate", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT DATE_FROM, DATE_TO
                FROM ITINERARY_PLAN_SERIES_TBL WHERE (ITINERARY_ID = " + id + ")";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["DATE_FROM"], sdr["DATE_TO"]); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }

        public bool InsertTrackDataToTMP(int user,string fromDat, string toDat,int fieldOffId)
        {    
               
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand sqlCommand = new SqlCommand("Insert_Farms_Tracking_Data_To_Temp_Itinerary", conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@user", SqlDbType.Int)).Value = user;
                sqlCommand.Parameters.Add(new SqlParameter("@terminal", SqlDbType.VarChar)).Value = System.Environment.MachineName.ToString();
                sqlCommand.Parameters.Add(new SqlParameter("@fromDate", SqlDbType.VarChar)).Value = fromDat;
                sqlCommand.Parameters.Add(new SqlParameter("@toDay", SqlDbType.VarChar)).Value = toDat;
                sqlCommand.Parameters.Add(new SqlParameter("@fieldOfficer", SqlDbType.Int)).Value = fieldOffId;

                sqlCommand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            { MessageBox.Show("Get Gps Tracking Details\n\n" + ex.Message.ToString(), "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }//Add tracking fieldOfficers Details

        public DataSet GetGpsTrackFODetails()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT convert(VARCHAR, CAST(GCPT.DATE AS DATETIME),106) as DATE,FHM.FAR_HDR_MST_CODE ,FHM.FAR_HDR_MST_NAME,FL.FAR_LOC_MST_NAME,V4 as Start_Time, V5 as End_Time,INT2 as Duration
				FROM GPS_CUS_PARK_TBL_TMP as GCPT inner join
				FARMER_MASTER_FARM_DETAILS AS FMFD on GCPT.IV2NAME= FMFD.FAR_MST_FAM_DET_CODE Inner join
                FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO inner join
                FARMER_LOCATION as FL on FMFD.FAR_MST_FAM_DET_LOCATION_CODE=FL.FAR_LOC_MST_CODE ", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "FOactualTblView");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }//Get the gps Tracking data of the field visits

        public DataSet GetWeeklyItineraryDetails(int fieldoffId, int wipID, string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT IPST.WIP_CODE,convert(VARCHAR, CAST(WIPM.ITINERARY_MST_DATE AS DATETIME),106) as ITINERARY_MST_DATE, Fl.FAR_LOC_MST_NAME,FHM.FAR_HDR_MST_CODE +' - '+FHM.FAR_HDR_MST_NAME as Farmer
                , BCH.BAT_CRT_CODE,BCH.BAT_CRT_NO_CHICKS, FOM.FLD_OFF_MST_NAME
                FROM WEEKLY_ITINERARY_PLAN_MASTER AS WIPM INNER JOIN
                ITINERARY_PLAN_SERIES_TBL AS IPST ON WIPM.ITINERARY_ID_FK = IPST.ITINERARY_ID inner join
                FARMER_MASTER_FARM_DETAILS AS FMFD on WIPM.FAR_HDR_MST_FAR_NO_FK= FMFD.FAR_MST_FAM_DET_CODE Inner join
                FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO inner join
                FIELD_OFFICER_MASTER FOM ON FMFD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE inner join
                FARMER_LOCATION as FL on FMFD.FAR_MST_FAM_DET_LOCATION_CODE=FL.FAR_LOC_MST_CODE inner join
                BATCH_CREATE_HEADER as BCH on WIPM.BAT_CRT_NO_FK = BCH.BAT_CRT_NO
                where FOM.FLD_OFF_MST_CODE=" + fieldoffId + " and IPST.ITINERARY_ID =" + wipID + " "+query+"", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "FOactualTblView");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }
    }
}
