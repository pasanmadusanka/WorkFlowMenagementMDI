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
    public class AdminToControllerDataMethod
    {
        SqlConnection conn;
        public AdminToControllerDataMethod()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetSelectedUserToControl(string id)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("item", typeof(string)); //0
            dt.Columns.Add("date", typeof(string));//1
            dt.Columns.Add("time", typeof(string));//2
            dt.Columns.Add("location", typeof(string));//3
            dt.Columns.Add("millage", typeof(string));//4
            dt.Columns.Add("vehicle", typeof(string));//5
            dt.Columns.Add("issuePer", typeof(string));//6
            dt.Columns.Add("qty", typeof(string));//7
            dt.Columns.Add("startM", typeof(string));//8
            dt.Columns.Add("endM", typeof(string));//9
            dt.Columns.Add("secqPer", typeof(string));//10
            dt.Columns.Add("billNo", typeof(string));//11
            dt.Columns.Add("authorize", typeof(string));//12
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                #region Query
                scmd.CommandText = @"select i.IT_MST_DESCRIPTION,substring(FIN_DOC_DATE,4,3) + substring(FIN_DOC_DATE,1,3)+substring(FIN_DOC_DATE,7,4) as Date
                , FIN_DOC_TIME as Time, l.LOC_LOC_NAME, 
                v.VHC_MST_NO, e.Emp_No+' - '+e.Name1 as FIN_ISSUE_PERSON_NAME,FIN_MILEAGE, FIN_QTY, FIN_ST_METER, FIN_ED_METER
                ,e1.Emp_No+' - '+e1.Name1 as FIN_SECURITY , FIN_REFARANCE, e2.Emp_No+' - '+e2.Name1 as FIN_AUTORIZED

                FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join
                ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join
                LOCATION as l on main.FIN_LOC_LOC_CODE=l.LOC_LOC_CODE inner join
                VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join
                EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join
                EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join
                EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE 
                where FIN_DOC_INDEX='" + id + "' ORDER BY CAST(FIN_DOC_INDEX AS int) DESC";
                #endregion
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["IT_MST_DESCRIPTION"], sdr["Date"], sdr["Time"], sdr["LOC_LOC_NAME"], sdr["FIN_MILEAGE"], sdr["VHC_MST_NO"],
                        sdr["FIN_ISSUE_PERSON_NAME"], sdr["FIN_QTY"], sdr["FIN_ST_METER"], sdr["FIN_ED_METER"],
                        sdr["FIN_SECURITY"], sdr["FIN_REFARANCE"], sdr["FIN_AUTORIZED"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Fill Employee()"); }
            finally { conn.Close(); }
            return dt;
        }
    }
}