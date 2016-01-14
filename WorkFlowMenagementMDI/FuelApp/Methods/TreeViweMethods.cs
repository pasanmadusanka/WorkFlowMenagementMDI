using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FuelApp.Methods
{
    public class TreeViweMethods
    {
        SqlConnection conn;
        public TreeViweMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        } 
        public DataTable GetRootDateTree()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("datID", typeof(string));
            dt.Columns.Add("datName", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = new SqlCommand(@"SELECT distinct Cast(FIN_DOC_DATE as datetime) as DATE1,FIN_DOC_DATE, substring(FIN_DOC_DATE,4,3) + substring(FIN_DOC_DATE,1,3)+substring(FIN_DOC_DATE,7,4) as FinDate
                FROM FUEL_TMP_ISSUE_HEADER_SUB order by DATE1 desc", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["FIN_DOC_DATE"], sdr["FinDate"]); } 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Load tree parent"); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetSubParentLocTree(string date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("locID", typeof(string));
            dt.Columns.Add("locName", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = new SqlCommand(@"SELECT distinct LO.LOC_LOC_NAME,lo.LOC_LOC_CODE FROM FUEL_TMP_ISSUE_HEADER_SUB as FTISHS INNER JOIN
             LOCATION as LO ON FTISHS.FIN_LOC_LOC_CODE = LO.LOC_LOC_CODE where FTISHS.FIN_DOC_DATE='" + date + "'", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["LOC_LOC_CODE"], sdr["LOC_LOC_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Load tree Subparent"); }
            finally { conn.Close(); }
            return dt;
        }
        public DataTable GetChildVhiTree(string date, int loc) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("vhiID", typeof(string));
            dt.Columns.Add("vhiName", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = new SqlCommand(@"SELECT VM.VHC_MST_NO,VM.VHC_MST_CODE FROM FUEL_TMP_ISSUE_HEADER_SUB as FTISHS INNER JOIN
            LOCATION as LO ON FTISHS.FIN_LOC_LOC_CODE = LO.LOC_LOC_CODE INNER JOIN
            VEHICLE_MASTER as VM ON FTISHS.FIN_VEHICLE_CODE = VM.VHC_MST_CODE AND LO.LOC_LOC_CODE = VM.ALLOCATE_LOCATION
            WHERE (FTISHS.FIN_DOC_DATE = '" + date + "') AND (FTISHS.FIN_LOC_LOC_CODE = " + loc + ")", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["VHC_MST_CODE"], sdr["VHC_MST_NO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Load tree parent"); }
            finally { conn.Close(); }
            return dt;
        } 
        public DataSet FillGridbyQuery(string query)
        { 
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                sda.Fill(ds, "FUEL_TMP_ISSUE_HEADER_SUB");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); }
            return ds;
        }
    }
}
