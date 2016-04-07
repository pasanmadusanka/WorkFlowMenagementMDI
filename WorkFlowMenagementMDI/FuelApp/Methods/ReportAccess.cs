using WorkFlowMenagementMDI.FuelApp.Views.Reports;
using WorkFlowMenagementMDI.FuelApp.Views.StockMovement;
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
    class ReportAccess
    {
        SqlConnection conn;
        public ReportAccess()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        public DataTable FillReportHeader()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("teli", typeof(string));
            dt.Columns.Add("fax", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("webAddr", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                SqlCommand scmd = new SqlCommand(@"SELECT  
                            [COMPANY_NAME] ,[ADDRESS] ,[TELE]
                           ,[FAX] ,[EMAIL] ,[WEB_ADDRESS]
                    FROM [NelnaDB].[dbo].[COMPANY_MASTER]", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["COMPANY_NAME"], sdr["ADDRESS"], sdr["TELE"], sdr["FAX"], sdr["EMAIL"], sdr["WEB_ADDRESS"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Access the Report Header

        #region populate DataSet with data from Query For Fuel General Report 
        public DataSet2 GetData(string fromDate, string toDate)
        {
            DataSet2 dsCustomers = new DataSet2();
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"select l.LOC_LOC_NAME as Location,
                substring(FIN_DOC_DATE,4,3) + substring(FIN_DOC_DATE,1,3)+substring(FIN_DOC_DATE,7,4) as [Date], 
                FIN_DOC_TIME as [Time], FIN_REFARANCE as [Bill : No :], v.VHC_MST_NO as [Vehicle No:],e1.Name1 as [Security Person], e.Name1 as [ISSUE Person],        
                FIN_MILEAGE as [Vehicle M:R:], FIN_QTY as [Diesel Qty], FIN_ST_METER as [Fuel Pump OPE:M:R:], FIN_ED_METER as [Fuel Pump CLO:M:R:]            

                FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join LOCATION AS l ON main.FIN_LOC_LOC_CODE = l.LOC_LOC_CODE INNER JOIN        
                ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join        
                EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join        
                EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE inner join SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE        
                where Cast(FIN_DOC_DATE as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(FIN_DOC_DATE as datetime) <= '" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' ORDER BY FIN_DOC_INDEX DESC"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(dsCustomers, "DataTable1"); }
                }
            }
            catch (Exception ex) { MessageBox.Show("ReportAccess class \n" + ex.Message.ToString(), "GetData", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            return dsCustomers;
        } 
        #endregion

        public FuelStockDataSet GetFuelStockData(string fromDate,string toDate)
        {
            FuelStockDataSet stockMove = new FuelStockDataSet();
            try
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [FIN_DOC_INDEX] ,[FIN_DOC_DATE] ,[FIN_DOC_TIME] ,'TFIN - '+[FIN_REFARANCE] as REFARANCE
                ,[FIN_OPEN_BAL] ,[FIN_RECIVED] ,FIN_OUT ,[FIN_CLOSED_BALANCE] ,s.SEC_HDR_USR_NAME as [user]
                ,[TERMINAL_NAME] FROM FUEL_TMP_STK_MOVEMENT_TBL as main inner join SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE 
                where [FIN_DOC_DATE] between '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and '" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "'"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    { cmd.Connection = conn; sda.SelectCommand = cmd; sda.Fill(stockMove, "StockDataTable"); }
                }
            }
            catch (Exception ex) { MessageBox.Show("ReportAccess class \n" + ex.Message.ToString(), 
                "GetFuelStockData()", MessageBoxButtons.OK, MessageBoxIcon.Hand); }
            return stockMove;
        }//Populate DataSet FuelStockDataSet(Stock Movement)

        public PhysicalStockDS GetPhysicalStock(string fromDate, string toDate)
        {
            PhysicalStockDS physicalDS = new PhysicalStockDS();
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT [FWS_ID] ,  convert(VARCHAR, CAST(FWS_DATE AS DATETIME),106) as FWS_DATE , 
				[FWS_TIME],[FWS_BALANCE],FWS_SYS_BALANCE  ,FWS_BALANCE-FWS_SYS_BALANCE as Stock_Gap,FWS_METER_READ,s.SEC_HDR_USR_NAME as FWS_USER ,[FWS_TERMINAL_NAME]
                FROM FUEL_TMP_WEEKLY_STOCK as main inner Join SECURITY_HEADER as s on main.[FWS_USER]=s.SEC_HDR_CODE
                where Cast(FWS_DATE as datetime) >= '" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(FWS_DATE as datetime) <= '" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' "+
                "order by FWS_ID desc";
                SqlDataAdapter sdas = new SqlDataAdapter(scmd);
                sdas.Fill(physicalDS, "PhysicalStockDT");
            }
            catch (Exception ex) { MessageBox.Show("ReportAccess class \n" + ex.Message.ToString(), "GetPhysicalStock()", MessageBoxButtons.OK, MessageBoxIcon.Hand); }

            return physicalDS;
        }//Populate PhysicalStockDS(Physical Stock)
    }
}
