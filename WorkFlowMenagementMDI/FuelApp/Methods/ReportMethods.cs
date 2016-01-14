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
    public class ReportMethods
    {
        SqlConnection conn;

        public ReportMethods()
        {
            DBAccess dba = new DBAccess();
            conn = dba.conn;
        }

        
        public DataSet FillReportDetails(string date)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                {  conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select FIN_REFARANCE as [Bill : No :], FIN_DOC_DATE as [Date], FIN_DOC_TIME as [Time],
                v.VHC_MST_NO as [Vehicle No:],e1.Name1 as [Security Person], e.Name1 as [ISSUE Person],FIN_MILEAGE as [Vehicle M:R:], FIN_QTY as [Diesel Qty], 
                FIN_ST_METER as [Fuel Pump OPE:M:R:], FIN_ED_METER as [Fuel Pump CLO:M:R:],FIN_SYS_DATE as [System Date]

                FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join
                ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join
                VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join
                EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join
                EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join
                EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE inner join
                SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE

                where FIN_SYS_DATE='" + date + "'";

                SqlDataAdapter sda = new SqlDataAdapter(scmd);

                sda.Fill(ds, "FUEL_TMP_ISSUE_HEADER_SUB");

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            finally { conn.Close(); }
            return ds;
        }
        public DataTable FillReport(string date)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ref", typeof(string));
            dt.Columns.Add("docDate", typeof(string));
            dt.Columns.Add("finSysDAte", typeof(string));
            dt.Columns.Add("EndMeter", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                SqlCommand scmd = new SqlCommand("FuelGetAllToReport_SP", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select FIN_REFARANCE as [Bill : No :], FIN_DOC_DATE as [Date], FIN_DOC_TIME as [Time],
                v.VHC_MST_NO as [Vehicle No:],e1.Name1 as [Security Person], e.Name1 as [ISSUE Person],FIN_MILEAGE as [Vehicle M:R:], FIN_QTY as [Diesel Qty], 
                FIN_ST_METER as [Fuel Pump OPE:M:R:], FIN_ED_METER as [Fuel Pump CLO:M:R:],FIN_SYS_DATE as [System Date]
                
                FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join
                ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join
                VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join
                EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join
                EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join
                EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE inner join
                SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE
                
                where FIN_SYS_DATE='" + date + "'";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["Bill : No :"], sdr["Date"], sdr["System Date"], sdr["Fuel Pump CLO:M:R:"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;

            //            select FIN_REFARANCE,IT_MST_DESCRIPTION, FIN_DOC_DATE, FIN_DOC_TIME,
            //v.VHC_MST_NO,e1.Name1 as FIN_SECURITY, e.Name1 as FIN_ISSUE_PERSON_NAME,FIN_MILEAGE, FIN_QTY, 
            //FIN_ST_METER, FIN_ED_METER,FIN_SYS_DATE
        }

        public string FillStartMeterCount(string date)
        {
            string count = String.Empty;
            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }

                SqlCommand com = new SqlCommand(@"select top 01 FIN_ST_METER
                from FUEL_TMP_ISSUE_HEADER_SUB
            where FIN_SYS_DATE = '"+date+"' and FIN_SYS_TIME <= '12:00:00 PM'", conn);
                com.Connection = conn;
                com.CommandType = CommandType.Text;
                //com.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = date;

                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    { count = (read["FIN_ST_METER"].ToString()); }
                }
            }
            catch
            {
                MessageBox.Show("Error",
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
            finally { conn.Close(); }
            return count;
        }
    }
}
