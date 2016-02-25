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
    public class NewWIPMethods
    {
        SqlConnection conn;
        public NewWIPMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetLatestWIPCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select
                max(SUBSTRING(WIP_CODE, PATINDEX('%[0-9]%', WIP_CODE), LEN(WIP_CODE))) as WIPCode
                from ITINERARY_PLAN_SERIES_TBL";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["WIPCode"]); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Latest WIP"); 
            }
            finally { conn.Close(); }
            return dt;
        }
        private string GetLastWIPId()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"select max(ITINERARY_ID) as ITINERARY_ID
                from ITINERARY_PLAN_SERIES_TBL";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["ITINERARY_ID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get Last ID

        public bool InsertNewWIP(string wipCode, string fromDate, string toDate)
        {
            int index = Convert.ToInt32(GetLastWIPId());
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; 
                if not exists(select WIP_CODE from ITINERARY_PLAN_SERIES_TBL where WIP_CODE = '" + wipCode + "') " +
                    "INSERT INTO [dbo].[ITINERARY_PLAN_SERIES_TBL] " +
                    "([ITINERARY_ID] ,[WIP_CODE] ,[DATE_FROM] ,[DATE_TO]) " +
                    "VALUES (" + index + ",'" + wipCode + "' , '" + fromDate + "' ,'" + toDate + "') " +
                "DECLARE @err_message nvarchar(255) " +
                "if exists(select WIP_CODE from ITINERARY_PLAN_SERIES_TBL where WIP_CODE = '" + wipCode + "') " +
                "BEGIN SET @err_message = '" + wipCode + "'+' Alredy exists' RAISERROR (@err_message,10, 1) END " +
                "COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public bool UpdateWIPDates(int wipID, string fromDate, string toDate)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @" BEGIN TRANSACTION;
                    UPDATE [dbo].[ITINERARY_PLAN_SERIES_TBL]
                       SET [DATE_FROM] =  '" + fromDate + "' " +
                         " ,[DATE_TO] =  '" + toDate + "' WHERE [ITINERARY_ID]=" + wipID + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
            finally { conn.Close(); }
            return status;
        }

        public DataTable GetFromDateNToDateOfSeries(int itineraryID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("fromD", typeof(DateTime));
            dt.Columns.Add("toD", typeof(DateTime));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select WIP_CODE,convert(VARCHAR, CAST(IPST.DATE_FROM AS DATETIME),106) as DATE_FROM, convert(VARCHAR, CAST(IPST.DATE_TO AS DATETIME),106) as DATE_TO
                from ITINERARY_PLAN_SERIES_TBL as IPST where IPST.ITINERARY_ID=" + itineraryID + "";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["WIP_CODE"], sdr["DATE_FROM"], sdr["DATE_TO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); dt = null; }
            finally { conn.Close(); }
            return dt;
        }
    }
}
