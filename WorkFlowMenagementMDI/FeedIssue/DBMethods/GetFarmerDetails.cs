using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FeedIssue.DBMethods
{
    public class GetFarmerDetails
    {
        SqlConnection conn;

        public GetFarmerDetails()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable RetriveFarmerOnCombo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try 
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT FAR_HDR_MST_FAR_NO, FAR_HDR_MST_CODE + ' - ' + FAR_HDR_MST_NAME AS FAR_HDR_MST_NAME
                FROM FARMER_HEADER_MASTER order by FAR_HDR_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FAR_HDR_MST_FAR_NO"], sdr["FAR_HDR_MST_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Loading Farmer Combo"); }
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
                where FMFD.FAR_MST_FAM_DET_CODE=" + farCode + "";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["BAT_CRT_NO"], sdr["BAT_CRT_CODE"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Loading Farmer_Batch Combo"); }
            finally { conn.Close(); }
            return dt;
        }

        public string GetBatchDate(int idNo)
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn; 
                string selectSql = @"SELECT  BAT_CRT_ST_DATE
                from BATCH_CREATE_HEADER where BAT_CRT_NO=" + idNo + ""; 
                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["BAT_CRT_ST_DATE"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";
            return  index;
        }
        public string GetBatchNoOfBirds(int idNo)
        {
            string noOfBirds = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                string selectSql = @"SELECT  BAT_CRT_NO_CHICKS
                from BATCH_CREATE_HEADER where BAT_CRT_NO=" + idNo + "";
                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { noOfBirds = (read["BAT_CRT_NO_CHICKS"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";
            if (noOfBirds == "") { noOfBirds = "0"; return noOfBirds; }
            else
            {
                return noOfBirds;
            }
        }

        public bool GetFeedInFinisherAndBooster(int batch)
        {
            bool status = false;
            int user=Properties.Settings.Default.UserID;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand sqlCommand = new SqlCommand("GetBatchScheduleProcedure", conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@LOG_ID", SqlDbType.Int)).Value = user; 
                sqlCommand.Parameters.Add(new SqlParameter("@Res", SqlDbType.Int)).Value = 1;
                sqlCommand.Parameters.Add(new SqlParameter("@BATCH_CRT_NO", SqlDbType.Int)).Value = batch;
                sqlCommand.Parameters.Add(new SqlParameter("@FLAG", SqlDbType.VarChar)).Value = "A";
                
                sqlCommand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString(), "GetFeedInFinisherAndBooster Executing...!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            finally { conn.Close(); }
            return status;
        }

        public DataSet ItemsSentToBatchTBL(int batch)
        {
            int user=Properties.Settings.Default.UserID;
            DataSet ds = new DataSet();
            try
            {
                string query = @" SELECT PRN_BAT_DET_IT_CAT_NAME, CONVERT(VARCHAR(24),CAST(PRN_BAT_DET_IT_DATE AS datetime),103) as Btchdate
                , PRN_BAT_DET_IT_ITEM_NAME, PRN_BAT_DET_IT_ITEM_QTY, PRN_BAT_DET_IT_VALUE, PRN_BAT_DET_IT_bat_crt_no
                FROM Prn_Detail_Item_SentTo_Batch_Per_Batch WHERE (PRN_BAT_DET_IT_bat_crt_no = " + batch + ") AND (PRN_BAT_DET_IT_USERID = " + user + ") ORDER BY CAST(PRN_BAT_DET_IT_DATE AS datetime)";
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "feedIssue");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return ds;
        }
    }
}
