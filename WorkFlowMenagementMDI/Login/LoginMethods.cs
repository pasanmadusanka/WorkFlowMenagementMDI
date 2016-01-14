using WorkFlowMenagementMDI.Database;
using WorkFlowMenagementMDI.Infrastructure; 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.Methods.Login
{
    class LoginMethods
    {
        SqlConnection conn;
        public LoginMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        public bool GetEmployeAuth(string userName, string password)
        {
            try
            {
                conn.Open();

                SqlCommand NewCmd = conn.CreateCommand();
                NewCmd.CommandType = CommandType.Text;
                NewCmd.CommandText = "SELECT SEC_HDR_CODE, SEC_HDR_USR_NAME, SEC_HDR_PWD FROM SECURITY_HEADER WHERE (SEC_HDR_USR_NAME = '" + userName + "') AND (SEC_HDR_PWD = '" + password + "')";

                SqlDataReader dr = NewCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserInfo ui = new UserInfo(dr["SEC_HDR_CODE"].ToString(), dr["SEC_HDR_USR_NAME"].ToString(), dr["SEC_HDR_PWD"].ToString());
                        int i = Convert.ToInt32(dr["SEC_HDR_CODE"]);
                        //ControllerMethods dba = new ControllerMethods(Convert.ToInt32(dr["SEC_HDR_CODE"]));
                    }
                    NewCmd.Dispose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + WorkFlowMenagementMDI.Properties.Settings.Default.NewConStr, "Login Error...");
            }
            finally { conn.Close(); }
            return false;
        }
    }
}
