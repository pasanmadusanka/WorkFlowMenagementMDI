using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FuelApp.Methods
{
    class SMS_DbAccess
    {
        SqlConnection conn;
        public SMS_DbAccess()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        public DataTable FillEmpCat()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("catagory", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "SELECT DISTINCT EMP_STATUS FROM  dbo.EMPLOYEE_MASTER";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["EMP_STATUS"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); } return dt;
        }//Get the details of the employee status

        public DataTable FillEmployeeNumbers(string status)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Number", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "SELECT mob.MOB_NO, mob.MOB_OWNER, mob.MOB_TYPE_CODE FROM EMPLOYEE_MASTER AS emp INNER JOIN MOBILE_HEADER_MASTER AS mob ON emp.EMP_CODE = mob.MOB_OWNER WHERE (mob.MOB_TYPE_CODE = 1) AND (emp.EMP_STATUS = '" + status + "')";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["MOB_NO"]);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Fill The Employee Number according to the Status

        public bool SaveMessageDetails(string id, string catagory, string mobileNo, string description)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = "INSERT INTO [dbo].[SMS_SENDING_HEADER] values( '" + id + "' ,'" + catagory + "' ,'" + mobileNo + "' ,'" + description + "','')";

                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public string GetLastIndex()
        {
            string lastIndex = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = "select TOP (1)[SMS_CODE_NO] from SMS_SENDING_HEADER ORDER BY CAST([SMS_CODE_NO] AS int) DESC";
                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    { lastIndex = (read["SMS_CODE_NO"].ToString()); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            int index = Convert.ToInt32(lastIndex) + 1;
            return index.ToString();
        }//Get Last Doc SMS_CODE_NO
    }

}