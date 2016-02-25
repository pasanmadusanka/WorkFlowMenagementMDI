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
    public class GenarateItineraryPlanMethods
    {
        SqlConnection conn;
        public GenarateItineraryPlanMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetWIPCodeToCMB()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("code", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT ITINERARY_ID, WIP_CODE+' - '+convert(VARCHAR, CAST(DATE_FROM AS DATETIME),106)+' ~ '+convert(VARCHAR, CAST(DATE_TO AS DATETIME),106)  as WIP_CODE
                FROM ITINERARY_PLAN_SERIES_TBL order by WIP_CODE desc";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["ITINERARY_ID"], sdr["WIP_CODE"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetFieldOfficerToCMB()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FLD_OFF_MST_CODE, FLD_OFF_MST_NAME
                FROM FIELD_OFFICER_MASTER WHERE (FLD_OFF_MST_STATUS <> 'N') order by FLD_OFF_MST_NAME";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FLD_OFF_MST_CODE"], sdr["FLD_OFF_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetFarmerNCodeToCMB(int fieldOffId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FMAD.FAR_MST_FAM_DET_CODE, FHM.FAR_HDR_MST_CODE +' - '+FHM.FAR_HDR_MST_NAME as Farmer 
                FROM FARMER_MASTER_FARM_DETAILS AS FMAD INNER JOIN
                 FARMER_HEADER_MASTER AS FHM ON FMAD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO Inner JOIN
                 FIELD_OFFICER_MASTER FOM ON FMAD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE
                 where FOM.FLD_OFF_MST_CODE=" + fieldOffId + " order by FHM.FAR_HDR_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FAR_MST_FAM_DET_CODE"], sdr["Farmer"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable RetriveFarmerBatchOnCombo(int farCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select BAT_CRT_NO,BAT_CRT_CODE 
                from BATCH_CREATE_HEADER as BCH inner join
                FARMER_MASTER_FARM_DETAILS as FMFD on BCH.BAT_CRT_FARMER_CODE=FMFD.FAR_MST_FAM_DET_CODE inner join
                FARMER_HEADER_MASTER as FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO
                where FMFD.FAR_MST_FAM_DET_CODE=" + farCode + " order by BAT_CRT_NO desc";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["BAT_CRT_NO"], sdr["BAT_CRT_CODE"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Loading Farmer_Batch Combo"); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetBatchDateNBirds(int idNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("chicks", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT  BAT_CRT_ST_DATE,BAT_CRT_NO_CHICKS
                from BATCH_CREATE_HEADER where BAT_CRT_NO = " + idNo + "";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["BAT_CRT_ST_DATE"], sdr["BAT_CRT_NO_CHICKS"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Loading Farmer Batch"); }
            finally { conn.Close(); }
            return dt;
        }

        public string GetMaxIDOfWIP()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"select max(ITINERARY_MST_ID) as maxID
                from WEEKLY_ITINERARY_PLAN_MASTER";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["maxID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }

        public bool InsertIntoWIPMASTER(int wipID, string planedDate, int farm, int batchCode, string pbStatus)
        {

            bool status = false;
            int id = Convert.ToInt32(GetMaxIDOfWIP());
            try
            {
                string query = @"BEGIN TRANSACTION; 
                INSERT INTO WEEKLY_ITINERARY_PLAN_MASTER
                (ITINERARY_MST_ID, ITINERARY_ID_FK, ITINERARY_MST_DATE, FAR_HDR_MST_FAR_NO_FK, BAT_CRT_NO_FK,ITINERARY_PB_STSTUS)
                VALUES        (" + id + "," + wipID + ",'" + planedDate + "'," + farm + "," + batchCode + "," + pbStatus + ") COMMIT TRANSACTION;";
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

        public DataSet GetWIPToGrid(int itinearyId)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT WIPM.ITINERARY_MST_ID, IPST.WIP_CODE, 
                convert(VARCHAR, CAST(WIPM.ITINERARY_MST_DATE AS DATETIME),106) as ITINERARY_MST_DATE, Fl.FAR_LOC_MST_NAME,FHM.FAR_HDR_MST_CODE, FHM.FAR_HDR_MST_NAME
                , BCH.BAT_CRT_CODE,BCH.BAT_CRT_NO_CHICKS, FOM.FLD_OFF_MST_NAME, dbo.GET_FRM_PRE_BROO_STATUS(WIPM.ITINERARY_PB_STSTUS) AS P_B_Status
                FROM WEEKLY_ITINERARY_PLAN_MASTER AS WIPM INNER JOIN
                ITINERARY_PLAN_SERIES_TBL AS IPST ON WIPM.ITINERARY_ID_FK = IPST.ITINERARY_ID inner join
                FARMER_MASTER_FARM_DETAILS AS FMFD on WIPM.FAR_HDR_MST_FAR_NO_FK= FMFD.FAR_MST_FAM_DET_CODE Inner join
                FARMER_HEADER_MASTER AS FHM ON FMFD.FAR_MST_FAM_DET_CODE = FHM.FAR_HDR_MST_FAR_NO inner join
                FIELD_OFFICER_MASTER FOM ON FMFD.FAR_MST_FAM_DET_FIELD_OFFICER = FOM.FLD_OFF_MST_CODE inner join
                FARMER_LOCATION as FL on FMFD.FAR_MST_FAM_DET_LOCATION_CODE=FL.FAR_LOC_MST_CODE inner join
                BATCH_CREATE_HEADER as BCH on WIPM.BAT_CRT_NO_FK = BCH.BAT_CRT_NO
                WHERE (IPST.ITINERARY_ID = " + itinearyId + ") order by WIPM.ITINERARY_MST_ID", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "wipTable");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public bool DeleteWIPMASTER(int id)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; 
                DELETE FROM WEEKLY_ITINERARY_PLAN_MASTER
                where  ITINERARY_MST_ID =" + id + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
        public DataTable GetFromDateNToDateOfSeries(int itineraryID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("fromD", typeof(DateTime));
            dt.Columns.Add("toD", typeof(DateTime));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select convert(VARCHAR, CAST(IPST.DATE_FROM AS DATETIME),106) as DATE_FROM, convert(VARCHAR, CAST(IPST.DATE_TO AS DATETIME),106) as DATE_TO
                from ITINERARY_PLAN_SERIES_TBL as IPST where IPST.ITINERARY_ID=" + itineraryID + "";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["DATE_FROM"], sdr["DATE_TO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }

        public bool UpdateWIPMASTER(int wipID, string pbStatus)
        {

            bool status = false;
            int id = Convert.ToInt32(GetMaxIDOfWIP());
            try
            {
                string query = @"BEGIN TRANSACTION; 
                    UPDATE WEEKLY_ITINERARY_PLAN_MASTER
                    SET ITINERARY_PB_STSTUS='" + pbStatus + "' where ITINERARY_MST_ID=" + wipID + " COMMIT TRANSACTION;";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Update InTo FeedTemp"); }
            finally { conn.Close(); }
            return status;
        }//Insert Feed Schedule

    }
}
