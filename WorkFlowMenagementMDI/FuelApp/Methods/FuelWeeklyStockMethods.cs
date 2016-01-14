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
    public class FuelWeeklyStockMethods
    {
        SqlConnection conn;

        GetAvalableStockClass stockCls = new GetAvalableStockClass();

        public FuelWeeklyStockMethods()
        { DBAccess db = new DBAccess(); conn = db.conn; }

        public DataTable GetWeekName()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("weekName", typeof(string)); dt.Columns.Add("date", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand("select datename(dw,getdate()) as Week,CONVERT(VARCHAR(24),GETDATE(),101) as Date", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Week"], (sdr["Date"])); }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString() + " " + ex.Source.ToString(), "Error in database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); } return dt;
        }

        public string GetLastIndexFuelWeeklyStock()
        {
            string index = String.Empty;

            try
            {
                SqlCommand scmd = conn.CreateCommand(); scmd.Connection = conn;
                string selectSql = @"select top 1 FWS_ID from FUEL_TMP_WEEKLY_STOCK order by FWS_ID desc";
                SqlCommand com = new SqlCommand(selectSql, conn);

                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["FWS_ID"].ToString()); } }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error in GetLastIndexFuelWeeklyStock()", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally { conn.Close(); }

            if (index == "") { index = 1.ToString(); return index; }

            else { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get last index from FUEL_TMP_STK_MOVEMENT_TBL

        public string GetLastDatWeeklyStk()
        {
            string index = String.Empty;

            try
            {
                SqlCommand scmd = conn.CreateCommand(); scmd.Connection = conn;
                string selectSql = @"select top 1 FWS_DATE from FUEL_TMP_WEEKLY_STOCK order by FWS_ID desc";
                SqlCommand com = new SqlCommand(selectSql, conn);

                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["FWS_DATE"].ToString()); } }
            }

            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error GetLastDatWeeklyStk()", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally { conn.Close(); }

            return index;
        }//Return the last date of the Weekly stock table

        #region Get Avalable System Stock
        public double GetFuelStock()//FromProcedure PRN_GEN_STOCK_BALANCE_INDIVIDUAL
        {
            double genStock;
            string stock = stockCls.GetAvalableStock(16111, 130);
            genStock = Convert.ToDouble(stock);
            return genStock;
        }

        public double GetSumOfFuel()
        {
            double fuelSum = Convert.ToDouble(stockCls.GetSumNotSubmit());
            return fuelSum;
        }//Get Sum

        public double FuelSystemStock()
        {
            double finalAvStock = GetFuelStock() - GetSumOfFuel();
            return finalAvStock;
        }
        #endregion

        public bool AddToWeeklyStockTb(double stockBal,double meterCount)
        {
            bool status = false;
            int index = Convert.ToInt32(GetLastIndexFuelWeeklyStock());
            int userId = Convert.ToInt32(GetUser());
            string pc = System.Environment.MachineName.ToString();
            DataTable dt = GetDateTime();
            DataRow dr = dt.Rows[0];
            string date = dr[0].ToString();
            string time = dr[1].ToString();

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; 
                insert into FUEL_TMP_WEEKLY_STOCK
                ([FWS_ID] ,[FWS_DATE] ,[FWS_TIME] ,[FWS_BALANCE] ,[FWS_USER] ,[FWS_TERMINAL_NAME] ,[FWS_SYS_BALANCE],[FWS_METER_READ])
                values(" + index + ",'" + date + "','"+time+"'," +
                         stockBal + "," + userId + ",'" + pc + "'," + FuelSystemStock() + "," + meterCount + ") COMMIT TRANSACTION; ";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString() +"/n/n"+ex.Source.ToString(), "AddNewToStkMovementByDat() ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }//Add Date To Weekly stock Balance TBL

        public DataTable GetDateTime()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("date", typeof(string));
            dt.Columns.Add("time", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT CONVERT(VARCHAR(24),GETDATE(),101) as Date,CONVERT(VARCHAR(24),GETDATE(),108) as Time";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["Date"], (sdr["Time"])); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error in Get DateTime()", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public bool DeleteFromWeeklyStock(int id)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"
                BEGIN TRANSACTION;
                DELETE FROM dbo.FUEL_TMP_WEEKLY_STOCK WHERE FWS_ID=" + id + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "DeleteFromWeeklyStock", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            finally { conn.Close(); }

            return status;
        }

        public bool UpdateWeeklyStock(int id, double stock, double meter)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"
                BEGIN TRANSACTION;
                UPDATE [dbo].[FUEL_TMP_WEEKLY_STOCK] set [FWS_BALANCE]=" + stock +
                    ", FWS_METER_READ=" + meter + " where FWS_ID=" + id + " COMMIT TRANSACTION;";

                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "UpdateWeeklyStock", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }

            return status;
        }

        public DataTable GetAllFromWeeklyStock()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Balance", typeof(string));
            dt.Columns.Add("System Stock", typeof(string));
            dt.Columns.Add("M:R:(L)", typeof(string));
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("PC", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"SELECT [FWS_ID]
                ,substring(FWS_DATE,4,3) + substring(FWS_DATE,1,3)+substring(FWS_DATE,7,4) as [FWS_DATE] ,[FWS_BALANCE] ,FWS_SYS_BALANCE,[FWS_METER_READ] ,[FWS_USER] ,[FWS_TERMINAL_NAME] FROM [NelnaDB].[dbo].[FUEL_TMP_WEEKLY_STOCK]
                order by [FWS_ID] desc", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FWS_ID"], (sdr["FWS_DATE"]), (sdr["FWS_BALANCE"]), (sdr["FWS_SYS_BALANCE"]), (sdr["FWS_METER_READ"]), (sdr["FWS_USER"]), (sdr["FWS_TERMINAL_NAME"])); }
            }

            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString() + " " + ex.Source.ToString(), "Error in database", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); } return dt;
        }

        public string GetUser()
        {
            string user = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = "SELECT SEC_HDR_CODE FROM NelnaDB.dbo.SECURITY_HEADER where SEC_HDR_USR_NAME= '" + Properties.Settings.Default.LastUser + "'";
                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { user = (read["SEC_HDR_CODE"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return user;
        }

    }
}
