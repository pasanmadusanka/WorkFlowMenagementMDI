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
    public class NewReportMethods
    {
        SqlConnection conn;
        public NewReportMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet GetAllToTable(string fromDate, string toDate)
        {
            DataSet ds = new DataSet();

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"select l.LOC_LOC_NAME as Location,FIN_DOC_DATE as [Date], FIN_DOC_TIME as [Time], FIN_REFARANCE as [Bill : No :], 
                v.VHC_MST_NO as [Vehicle No:],e1.Name1 as [Security Person], e.Name1 as [ISSUE Person],FIN_MILEAGE as [Vehicle M:R:], FIN_QTY as [Diesel Qty], 
                FIN_ST_METER as [Fuel Pump OPE:M:R:], FIN_ED_METER as [Fuel Pump CLO:M:R:]

                FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join                         
                LOCATION AS l ON main.FIN_LOC_LOC_CODE = l.LOC_LOC_CODE INNER JOIN
                ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join
                VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join
                EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join
                EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join
                EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE inner join
                SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE

                where FIN_SYS_DATE >= '" + fromDate + "' and FIN_SYS_DATE <= '" + toDate + "' ORDER BY LOC_LOC_NAME DESC";

                SqlDataAdapter sda = new SqlDataAdapter(scmd);

                sda.Fill(ds, "FUEL_TMP_ISSUE_HEADER_SUB");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                conn.Close();
            }
            return ds;
        }
    }
}
