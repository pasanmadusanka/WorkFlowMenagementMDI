using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Login
{
    public class LoginSessionMonitor
    {
        SqlConnection conn;
        public LoginSessionMonitor()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public void ExecuteLoginSession_SP(int logID)
        {
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand cmd = new SqlCommand("INSERT_LOG_SESSION_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@logUserID", logID);
                cmd.Parameters.Add("@Res", SqlDbType.Int);
                cmd.Parameters["@Res"].Direction = ParameterDirection.Output; 
                cmd.ExecuteNonQuery(); 
                Properties.Settings.Default.LogSessionID = Convert.ToInt32(cmd.Parameters["@Res"].Value);
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExecuteLoginSession " + ex.Message);
            }
            finally { conn.Close(); }
        }

        public void ExecuteLogOffSession_SP(int logSessionID)
        {
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand cmd = new SqlCommand("UPDATE_LOGSESSION_EXIT_SP", conn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@logSessionID", logSessionID);  
                cmd.ExecuteNonQuery(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("ExecuteLogOffSession " + ex.Message);
            }
            finally { conn.Close(); }
        }
    }
}
