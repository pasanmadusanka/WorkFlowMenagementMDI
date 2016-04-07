using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.FuelApp.Methods
{
    public class ControllerMethods
    {
        //public int roleCode;
        private int _role;
        SqlConnection conn;
        #region Constracture overloading
        public ControllerMethods()
        { DBAccess db = new DBAccess(); conn = db.conn; }
        public ControllerMethods(int role)
        { this._role = role; }
        #endregion
        public DataSet FillGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "FuelAdminGetAll_SP";
                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                sda.Fill(ds, "FUEL_TMP_ISSUE_HEADER_SUB");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }

            finally { conn.Close(); }
            return ds;
        }//get All Fuel Details

        #region Load All the Combo box
        public DataTable FillEmployee()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT EMP_CODE, Emp_No + ' - ' + Name1 as Name_Epf
                FROM EMPLOYEE_MASTER WHERE (JobStatus <> N'Resigned') AND 
                (EMP_STATUS = 'M' OR EMP_STATUS = 'S') OR  (JobStatus <> N'Resigned') 
                AND (EMP_STATUS = 'D') AND (DesgCode = 81) 
                ORDER BY Emp_No";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                {
                    dt.Rows.Add(sdr["EMP_CODE"], sdr["Name_Epf"]);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(),"Fill Employee()"); }
            finally { conn.Close(); }
            return dt;
        }//get Issue person
        public DataTable FillAthorizedPerson()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed")
                {
                    conn.Open();
                }
                SqlCommand scmd = new SqlCommand(@"SELECT EMP_CODE, Emp_No + ' - ' +  Name1 AS LIST 
                FROM EMPLOYEE_MASTER WHERE (JobStatus <> N'Resigned') AND (EMP_STATUS = 'M') and Name1 ='Chandrasiri N.K.'
                ORDER BY Emp_No", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;

                SqlDataReader sdr = scmd.ExecuteReader();

                while (sdr.Read())
                { dt.Rows.Add(sdr["EMP_CODE"], sdr["List"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Get Athorize Person
        public DataTable FillSecqurityPerson()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(int));
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT EMP_CODE, Emp_No + ' - ' +  Name1 AS LIST 
                FROM EMPLOYEE_MASTER WHERE (JobStatus <> N'Resigned') 
                AND ((EMP_STATUS = 'S') AND ((DepCode = 32))) OR ((EMP_STATUS = 'D') AND ((DepCode = 51))) 
                ORDER BY Emp_No";

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["EMP_CODE"], sdr["LIST"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Get Secqurity Person
        public DataTable FillVehicleNumber()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("VNumber", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"SELECT TOP 100 PERCENT VHC_MST_CODE, VHC_MST_NO
                FROM dbo.VEHICLE_MASTER WHERE (VHC_MST_CATEGORY = '1' OR VHC_MST_CATEGORY = '3' or
                VHC_MST_CATEGORY = '6') AND (ACT_STATUS = '0')
                ORDER BY VHC_MST_NO", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["VHC_MST_CODE"], sdr["VHC_MST_NO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//get Vehicle number
        public DataTable FillItem()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("itemName", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = new SqlCommand(@"SELECT IT_MST_CODE, IT_MST_DESCRIPTION
                FROM dbo.ITEM_MASTER
                WHERE (IT_MST_DESCRIPTION = 'Diesel - Weediyawaththa')", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;

                SqlDataReader sdr = scmd.ExecuteReader();

                while (sdr.Read())
                { dt.Rows.Add(sdr["IT_MST_CODE"], sdr["IT_MST_DESCRIPTION"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Get The Item
        public DataTable FillLoocation(int id)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand("FuelGetTheVehicleLocation_SP", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.Add(new SqlParameter("@vehicle", SqlDbType.VarChar)).Value = id;

                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read()) { dt.Rows.Add(sdr["code"], sdr["name"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//get Location
        #endregion
        public DataTable FillLastMeterCounNIndexNReference()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("endM", typeof(string)); dt.Columns.Add("FinDox", typeof(string)); dt.Columns.Add("lRefNo", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"
				SELECT TOP 1 FIN_ED_METER, FIN_DOC_INDEX, FIN_REFARANCE FROM dbo.FUEL_TMP_ISSUE_HEADER_SUB
                ORDER BY cast(FIN_DOC_INDEX as int) DESC", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["FIN_ED_METER"], sdr["FIN_DOC_INDEX"], sdr["FIN_REFARANCE"]); }
            }
            catch(Exception ex) { MessageBox.Show("Error with the FillLastMeterCounNIndex() \n\n"+ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }//Get top row for Meter,Index,Reff

        public string FillLastMillageCount(int vehiID)
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"SELECT MAX(CAST(DP_IS_METER_READ AS INTEGER)) AS 
                        MTR FROM DEP_ISSUES_SUB_TBL WHERE (DP_IS_VEHICLE_NO = " + vehiID + ")";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["MTR"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int mtrCountLst = Convert.ToInt32(index); mtrCountLst = mtrCountLst + 1; return mtrCountLst.ToString(); }
        }

        public string GetIndexFuelStockMovement()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"select top 1 fin_doc_index
                    from FUEL_TMP_STOCK_MOVEMENT_TB
                    order by fin_doc_index desc";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["fin_doc_index"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            //return index + "val";
            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get last index from FUEL_TMP_STOCK_MOVEMENT_TB

        #region CRUD Operations
        public bool AddNewFuelDetails(int ItemCode, string date, string time, int location,
            int vehicle, int issueBy, string millage, double totQty, double endMeter, int secqurity, int user, string reference)
        {
            DataTable dtForDocindex = FillLastMeterCounNIndexNReference();
            DataRow rowForDocIndex = dtForDocindex.Rows[0];
            int docindex = Convert.ToInt32(rowForDocIndex[1].ToString()) + 1;
            string lastIndex = docindex.ToString();

            DataTable dt = FillLastMeterCounNIndexNReference();
            DataRow row = dt.Rows[0];
            double Fuel = Convert.ToDouble((row[0].ToString()));
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand sqlCommand = new SqlCommand("FuelInsertData_SP", conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@doc_Index", SqlDbType.VarChar)).Value = lastIndex;
                sqlCommand.Parameters.Add(new SqlParameter("@item_code", SqlDbType.Int)).Value = ItemCode;
                sqlCommand.Parameters.Add(new SqlParameter("@doc_date", SqlDbType.VarChar)).Value = date;
                sqlCommand.Parameters.Add(new SqlParameter("@doc_time", SqlDbType.VarChar)).Value = time;
                sqlCommand.Parameters.Add(new SqlParameter("@location_code", SqlDbType.Int)).Value = location;
                sqlCommand.Parameters.Add(new SqlParameter("@vehicle_code", SqlDbType.Int)).Value = vehicle;
                sqlCommand.Parameters.Add(new SqlParameter("@issue_person", SqlDbType.Int)).Value = issueBy;
                sqlCommand.Parameters.Add(new SqlParameter("@millage", SqlDbType.VarChar)).Value = millage;
                sqlCommand.Parameters.Add(new SqlParameter("@d_qty", SqlDbType.Float)).Value = totQty;
                sqlCommand.Parameters.Add(new SqlParameter("@st_meter", SqlDbType.Float)).Value = Fuel;
                sqlCommand.Parameters.Add(new SqlParameter("@ed_meter", SqlDbType.Float)).Value = endMeter;
                sqlCommand.Parameters.Add(new SqlParameter("@sec_person", SqlDbType.Int)).Value = secqurity;
                sqlCommand.Parameters.Add(new SqlParameter("@reference", SqlDbType.VarChar)).Value = reference;
                sqlCommand.Parameters.Add(new SqlParameter("@serial_no", SqlDbType.VarChar)).Value = "";
                sqlCommand.Parameters.Add(new SqlParameter("@athorized", SqlDbType.Int)).Value = 755;
                sqlCommand.Parameters.Add(new SqlParameter("@user_cod", SqlDbType.Int)).Value = user;
                sqlCommand.Parameters.Add(new SqlParameter("@termin_name", SqlDbType.VarChar)).Value = System.Environment.MachineName.ToString();

                sqlCommand.ExecuteNonQuery();
                status = true;
            }
            catch(Exception ex)
            { MessageBox.Show("AddNewFuelDetails Method \n\n" + ex.Message.ToString(), "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }//Add Fuel Details

        public bool UpdateFuelDetails(string docIndex, string date, string time, int location, int vehicle,
            int issueBy, string millage, double totQty, double startFuel, double endMeter, int secqurity, string reference, int user)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); } 
                SqlCommand sqlCommand = new SqlCommand("FuelUpdateData_SP", conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@doc_Index", SqlDbType.VarChar)).Value = docIndex;
                sqlCommand.Parameters.Add(new SqlParameter("@doc_date", SqlDbType.VarChar)).Value = date;
                sqlCommand.Parameters.Add(new SqlParameter("@doc_time", SqlDbType.VarChar)).Value = time;
                sqlCommand.Parameters.Add(new SqlParameter("@location_code", SqlDbType.Int)).Value = location;
                sqlCommand.Parameters.Add(new SqlParameter("@vehicle_code", SqlDbType.Int)).Value = vehicle;
                sqlCommand.Parameters.Add(new SqlParameter("@issue_person", SqlDbType.Int)).Value = issueBy;
                sqlCommand.Parameters.Add(new SqlParameter("@millage", SqlDbType.VarChar)).Value = millage;
                sqlCommand.Parameters.Add(new SqlParameter("@d_qty", SqlDbType.Float)).Value = totQty;
                sqlCommand.Parameters.Add(new SqlParameter("@st_meter", SqlDbType.Float)).Value = startFuel;
                sqlCommand.Parameters.Add(new SqlParameter("@ed_meter", SqlDbType.Float)).Value = endMeter;
                sqlCommand.Parameters.Add(new SqlParameter("@sec_person", SqlDbType.Int)).Value = secqurity;
                sqlCommand.Parameters.Add(new SqlParameter("@reference", SqlDbType.VarChar)).Value = reference;
                sqlCommand.Parameters.Add(new SqlParameter("@user_cod", SqlDbType.Int)).Value = user;
                sqlCommand.Parameters.Add(new SqlParameter("@termin_name", SqlDbType.VarChar)).Value = System.Environment.MachineName.ToString();
                sqlCommand.Parameters.Add(new SqlParameter("@sys_time", SqlDbType.VarChar)).Value = DateTime.Now.ToString("hh:mm:ss tt");
                sqlCommand.Parameters.Add(new SqlParameter("@sys_date", SqlDbType.VarChar)).Value = DateTime.Now.ToString("MM/dd/yyyy");

                sqlCommand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("UpdateFuelDetails() Method \n\n" + ex.Message.ToString(),"Update Method",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally  {  conn.Close(); }
            return status;
        }//Update Fuel Details
        public bool DeleteFuelDetails(string id)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand Scmd = new SqlCommand("FuelDeleteData", conn);
                Scmd.Connection = conn;
                Scmd.CommandType = CommandType.StoredProcedure;

                Scmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = id;
                Scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("Delete Method() \n\n"+ex.Message.ToString(),"Delete Method",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return status;
        }//Delete The Fuel Details
        #endregion

        public string FillUserID(string user, string pwd)
        {
            string userId = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = "SELECT SEC_HDR_CODE FROM NelnaDB.dbo.SECURITY_HEADER where SEC_HDR_USR_NAME='" + user.ToLower() + "' and SEC_HDR_PWD='" + pwd + "'";
                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { userId = (read["SEC_HDR_CODE"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return userId;
        }//Get Start Meter//Get SMS_CODE_NO

        #region Fuel Stock Movement Table Controls
        public bool AddFuelStkMovement(string reference, double closeBal, double qty, int userCode)
        {
            double closeVal = Convert.ToDouble(GetLastCloseBalance());
            int index = Convert.ToInt32(GetIndexFuelStockMovement());

            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand sqlCommand = new SqlCommand("Fuel_Insert_Value_Stk_Movement_SP", conn);
                sqlCommand.Connection = conn;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = index;
                sqlCommand.Parameters.Add(new SqlParameter("@finRefer", SqlDbType.VarChar)).Value = reference;
                sqlCommand.Parameters.Add(new SqlParameter("@ClosedBal", SqlDbType.Float)).Value = closeBal;

                if (closeBal == closeVal)
                { sqlCommand.Parameters.Add(new SqlParameter("@Issued", SqlDbType.Float)).Value = 0; }
                else if (closeVal == 0)
                { sqlCommand.Parameters.Add(new SqlParameter("@Issued", SqlDbType.Float)).Value = 0; }
                else
                {
                    double NewBalance = closeBal - closeVal;
                    sqlCommand.Parameters.Add(new SqlParameter("@Issued", SqlDbType.Float)).Value = NewBalance;
                }

                sqlCommand.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Float)).Value = qty;
                sqlCommand.Parameters.Add(new SqlParameter("@USERCODE", SqlDbType.Int)).Value = userCode;
                sqlCommand.Parameters.Add(new SqlParameter("@TERMINAL", SqlDbType.VarChar)).Value = System.Environment.MachineName.ToString();

                sqlCommand.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return status;
        }

        public string GetLastIndexFuelStockMovement()
        {
            string index = String.Empty;

            try
            {
                SqlCommand scmd = conn.CreateCommand(); scmd.Connection = conn;
                string selectSql = @"SELECT top 1 [FIN_DOC_INDEX] FROM [NelnaDB].[dbo].[FUEL_TMP_STK_MOVEMENT_TBL] order by fin_doc_index desc";
                SqlCommand com = new SqlCommand(selectSql, conn);

                if (conn.State.ToString() == "Closed") { conn.Open(); }

                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["fin_doc_index"].ToString()); } }
            }

            catch (Exception ex) { MessageBox.Show("GetLastIndexFuelStockMovement()\n\n"+ex.Message.ToString()); }

            finally { conn.Close(); }

            if (index == "") { index = 1.ToString(); return index; }

            else { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get last index from FUEL_TMP_STK_MOVEMENT_TBL
        public bool AddNewToStkMovementByDat(string reference, double openBal, double qty, int userCode)
        {
            int index = Convert.ToInt32(GetLastIndexFuelStockMovement());

            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand("Fuel_Insert_Value_FUEL_TMP_STK_MOVEMENT_TBL_SP", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.StoredProcedure;

                scmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = index;
                scmd.Parameters.Add(new SqlParameter("@finRefer", SqlDbType.VarChar)).Value = reference;
                scmd.Parameters.Add(new SqlParameter("@OpenBal", SqlDbType.Float)).Value = openBal;
                scmd.Parameters.Add(new SqlParameter("@Issued", SqlDbType.Float)).Value = 0;
                scmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Float)).Value = qty;
                scmd.Parameters.Add(new SqlParameter("@USERCODE", SqlDbType.Int)).Value = userCode;
                scmd.Parameters.Add(new SqlParameter("@TERMINAL", SqlDbType.VarChar)).Value = System.Environment.MachineName.ToString();
                scmd.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex) { MessageBox.Show("AddNewToStkMovementByDat() " + ex.Message.ToString()); }

            finally { conn.Close(); }

            return status;
        }
        public string GetLastCloseBalance()
        {
            string closeValue = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"select top 1 FIN_CLOSED_BALANCE from FUEL_TMP_STOCK_MOVEMENT_TB order by Fin_doc_index desc";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { closeValue = (read["FIN_CLOSED_BALANCE"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); } 
            if (closeValue == "") { closeValue = 0.ToString(); return closeValue; }
            else { int getindex = Convert.ToInt32(closeValue); return getindex.ToString(); }
        }
        #endregion
    }
}