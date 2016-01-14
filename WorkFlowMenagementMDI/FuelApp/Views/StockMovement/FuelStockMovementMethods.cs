using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    public class FuelStockMovementMethods
    {
        SqlConnection conn;
        public FuelStockMovementMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetAllFuelDetals()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(string)); dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time", typeof(string)); dt.Columns.Add("RefNo.", typeof(string));
            dt.Columns.Add("Open Balance(L)", typeof(string)); dt.Columns.Add("Recive(L)", typeof(string));
            dt.Columns.Add("PumpQty(L)", typeof(string)); dt.Columns.Add("ClosingBalance(L)", typeof(string));
            dt.Columns.Add("User", typeof(string)); dt.Columns.Add("PC", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT [FIN_DOC_INDEX] ,[FIN_DOC_DATE] ,[FIN_DOC_TIME] ,'TFIN - '+[FIN_REFARANCE] as REFARANCE
                ,[FIN_OPEN_BAL] ,[FIN_RECIVED] ,FIN_OUT ,[FIN_CLOSED_BALANCE] ,s.SEC_HDR_USR_NAME as [user]
                ,[TERMINAL_NAME] FROM FUEL_TMP_STK_MOVEMENT_TBL as main inner join SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE 
                order by [FIN_DOC_INDEX] desc";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {  dt.Rows.Add(sdr["FIN_DOC_INDEX"], sdr["FIN_DOC_DATE"], sdr["FIN_DOC_TIME"], sdr["REFARANCE"],
                        sdr["FIN_OPEN_BAL"], sdr["FIN_RECIVED"], sdr["FIN_OUT"], sdr["FIN_CLOSED_BALANCE"],
                        sdr["user"], sdr["TERMINAL_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetDistinctDates()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @" SELECT  DISTINCT  [FIN_DOC_DATE] FROM [NelnaDB].[dbo].FUEL_TMP_STK_MOVEMENT_TBL";
                SqlDataReader sdr = scmd.ExecuteReader();

                while (sdr.Read()) { dt.Rows.Add(sdr["FIN_DOC_DATE"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetStockByDate(string date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Index", typeof(string)); dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Time", typeof(string)); dt.Columns.Add("RefNo.", typeof(string));
            dt.Columns.Add("OpenBalance(L)", typeof(string)); dt.Columns.Add("Recive(L)", typeof(string));
            dt.Columns.Add("PumpQty(L)", typeof(string)); dt.Columns.Add("Closing Balance(L)", typeof(string));
            dt.Columns.Add("User", typeof(string)); dt.Columns.Add("PC", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"  SELECT [FIN_DOC_INDEX] ,[FIN_DOC_DATE] ,[FIN_DOC_TIME] ,'TFIN - '+[FIN_REFARANCE] as REFARANCE
                    ,[FIN_OPEN_BAL] ,[FIN_RECIVED] ,FIN_OUT ,[FIN_CLOSED_BALANCE] ,s.SEC_HDR_USR_NAME as [user]
                    ,[TERMINAL_NAME] FROM FUEL_TMP_STK_MOVEMENT_TBL as main inner join SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE 
                where [FIN_DOC_DATE]='" + date + "' order by [FIN_DOC_INDEX] desc";

                SqlDataReader sdr = scmd.ExecuteReader();

                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["FIN_DOC_INDEX"], sdr["FIN_DOC_DATE"], sdr["FIN_DOC_TIME"], sdr["REFARANCE"],
                          sdr["FIN_OPEN_BAL"], sdr["FIN_RECIVED"], sdr["FIN_OUT"], sdr["FIN_CLOSED_BALANCE"],
                          sdr["user"], sdr["TERMINAL_NAME"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }
    }
}
