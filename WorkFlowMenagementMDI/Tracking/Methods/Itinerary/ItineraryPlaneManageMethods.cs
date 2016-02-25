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
    public class ItineraryPlaneManageMethods
    {
        SqlConnection conn;
        public ItineraryPlaneManageMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet GetWIPToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT ITINERARY_ID, WIP_CODE, convert(VARCHAR, CAST(DATE_FROM AS DATETIME),106) as DATE_FROM, convert(VARCHAR, CAST(DATE_TO AS DATETIME),106) as DATE_TO
                FROM ITINERARY_PLAN_SERIES_TBL order by WIP_CODE desc", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "wipTable");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public bool DeleteItinarySeries(int seriesID)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand Scmd = new SqlCommand("Delate_Week_Itinerary_Plan_Series", conn);
                Scmd.Connection = conn;
                Scmd.CommandType = CommandType.StoredProcedure;

                Scmd.Parameters.Add(new SqlParameter("@itinerarySeriesID", SqlDbType.Int)).Value = seriesID;
                Scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("Delete Method() \n\n" + ex.Message.ToString(), "Delete Method", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }//Delete The Fuel Details

        public DataTable GetRowCountOfDeletingSeries(int seriesId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("count", typeof(string)); 
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select count(*) as RowCounts
                from WEEKLY_ITINERARY_PLAN_MASTER as WIPM inner join
                ITINERARY_PLAN_SERIES_TBL as IPST on WIPM.ITINERARY_ID_FK=ipst.ITINERARY_ID
                where ipst.ITINERARY_ID=" + seriesId + " ";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["RowCounts"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Access row Count"); }
            finally { conn.Close(); }
            return dt;    
        }
    }
}
