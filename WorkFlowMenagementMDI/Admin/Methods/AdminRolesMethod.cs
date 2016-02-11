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
    public class AdminRolesMethod
    {
        SqlConnection conn;
        public AdminRolesMethod()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }
        private string GetLastFarmerId(string query,string id)
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = query;

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read[id].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }

        #region All Avalable Users
        public DataTable LoadAllUsers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT SEC_HDR_CODE, SEC_HDR_USR_NAME FROM SECURITY_HEADER";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["SEC_HDR_CODE"], sdr["SEC_HDR_USR_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error (list box data binding)", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable LoadAllUsersInSecqurityHdr()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT UWR.UserID, SH.SEC_HDR_USR_NAME FROM USERS_WFMS AS UWR INNER JOIN 
                    SECURITY_HEADER AS SH ON UWR.SecqHeaderID = SH.SEC_HDR_CODE order by UWR.UserID desc";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["UserID"], sdr["SEC_HDR_USR_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error (list box data binding)", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public bool InsertNewUser(int seqHdrID)
        {
            int index = Convert.ToInt32(GetLastFarmerId("Select top 1 UserID from USERS_WFMS order by UserID desc", "UserID"));
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; if not exists (Select * from USERS_WFMS as UWR where UWR.SecqHeaderID=" + seqHdrID + " )" +
                " INSERT INTO USERS_WFMS (UserID, SecqHeaderID) VALUES        (" + index + "," + seqHdrID + ") COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        #endregion

        #region All Avalable Roles
        public bool InsertNewRole(string role)
        {
            int index = Convert.ToInt32(GetLastFarmerId("Select top 1 ROLE_ID from ROLES_WFMS order by ROLE_ID desc", "ROLE_ID"));
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; if not exists (Select * from ROLES_WFMS as RW where RW.ROLE_NAME='" + role + "')" +
                "  INSERT INTO [dbo].[ROLES_WFMS] ([ROLE_ID] ,[ROLE_NAME]) VALUES ( " + index + ",'" + role + "' ) COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable LoadAllRolles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT ROLE_ID, ROLE_NAME FROM ROLES_WFMS order by ROLE_ID desc";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["ROLE_ID"], sdr["ROLE_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error (list box data binding)", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }
        #endregion

        #region Manage Users To Roles

        public bool InsertNewUsersToRole(int roleID, int userID,int create,int update, int delete)
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
                if exists (select * from [USER_TO_ROLE_WFMS] where FK_USER_ID="+ userID +" and FK_ROLE_ID="+ roleID +") "+
                "update USER_TO_ROLE_WFMS set UTRW_CREATE=" + create + ",UTRW_UPDATE=" + update + ",UTRW_DELETE=" + delete + " where " +
                "FK_USER_ID=" + userID + " and FK_ROLE_ID=" + roleID + " " +
                "else "+
                "INSERT INTO [dbo].[USER_TO_ROLE_WFMS] ([FK_USER_ID] ,[FK_ROLE_ID],UTRW_CREATE,UTRW_UPDATE, "+
                "UTRW_DELETE) VALUES ( " + userID + "," + roleID + "," + create + "," + 
                                        update + ","+ delete +") COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public bool DeleteNewUsersToRole(int roleID, int userID)
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
             if exists (select * from [USER_TO_ROLE_WFMS] where FK_USER_ID="+userID+" and FK_ROLE_ID="+roleID+") "+
               "delete  from USER_TO_ROLE_WFMS where FK_USER_ID=" + userID + " and FK_ROLE_ID=" + roleID + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }


        #endregion

        public DataSet SelectRolesToUSERS(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "usersInRoles");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "SelectRolesToUSERS()"); }
            finally { conn.Close(); }
            return ds;
        }

        public DataSet SelectRolesToControls(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "controlsInRoles");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "SelectRolesToControls()"); }
            finally { conn.Close(); }
            return ds;
        }

        #region Manage Permissions
        public bool InsertNewControlsToRole(int roleID, string controlName, int invisible, int disabled)
        {
            bool status = false;
            try
            {
                int index = Convert.ToInt32(GetLastFarmerId("Select top 1 PAGEID from CONTROLS_WFMS order by PAGEID desc", "PAGEID"));

                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; 
                if not exists (select * from CONTROLS_WFMS where CONRTOL_NAME = '" + controlName + "')" +
                    " Insert into CONTROLS_WFMS (PAGEID, CONRTOL_NAME) values (" + index + ", '" + controlName + "') " +

             "  if exists (select * from CONTROLS_TO_ROLES_WFMS where FK_ROLE_ID=" + roleID + " and FK_CONTROL_NAME= '" + controlName + "') " +
	         "      UPDATE CONTROLS_TO_ROLES_WFMS " +
              "     SET INVISIBLE =" + invisible + ", DISABLED =" + disabled + " " +
               "    where FK_ROLE_ID=" + roleID + " and FK_CONTROL_NAME= '" + controlName + "' " +

               " else "+
                "   insert into CONTROLS_TO_ROLES_WFMS (FK_ROLE_ID, FK_CONTROL_NAME, INVISIBLE, DISABLED)" +
                  " values (" + roleID + ", '" + controlName + "', " + invisible + ", " + disabled + ") COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }
        #endregion
    }
}
