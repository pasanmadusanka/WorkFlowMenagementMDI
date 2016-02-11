using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Admin.Methods
{ 
    public class WorkFlowManageMethods
    {
        SqlConnection conn;
        int lastUserID = Properties.Settings.Default.UserID;
        public WorkFlowManageMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet SelectUserRolesToControls(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "usercontrolsInRoles");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "SelectUserRolesToControls()"); }
            finally { conn.Close(); }
            return ds;
        }

        public int GetUserAccessable(string input, int role)
        {
            int privlagID;
            string queryStringDisable = @"SELECT FK_USER_ID, FK_ROLE_ID, UTRW_CREATE, UTRW_UPDATE, UTRW_DELETE
            FROM USER_TO_ROLE_WFMS
            where FK_USER_ID=" + lastUserID + " and FK_ROLE_ID="+role+"";

            DataTable dt = null;
            DataSet ds =  SelectUserRolesToControls(queryStringDisable);

            if (lastUserID == 1)
            {
                privlagID = 1;
            }
            else
            {
                dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                privlagID = Convert.ToInt32(dr[input]);
            }
            return privlagID;
        }

    }
}
