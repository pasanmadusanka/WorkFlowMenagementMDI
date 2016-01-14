using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Database;

namespace WorkFlowMenagementMDI.Tracking.Methods.Customers
{
    class CustomerLocationCreationMethods
    {
        SqlConnection conn;

        public CustomerLocationCreationMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet GetCustomerToGrid()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"Select  GPS_CUST_ID as ID, cus.CHT_ACC_ALIAS as Alias,
                cus.CHT_ACC_NAME as Name,cusgroup.ACC_GRP_GRP_NAME as [Group], GPS_CUST_AREA as Area,vmas.VHC_MST_NO as [Vehicle No],[GSP_CUST_ROUT_DAY] as Day, locemp.LOC_LOC_SH_CODE + ' - ' + locemp.LOC_LOC_NAME as [Sales Rep], GPS_CUST_LATITUDE as Latitude, GPS_CUST_LONGITUDE as Longitude
                from GPS_CUSTOMER_LOCATION_MASTER as gpscus inner join 
		        GPS_TRACKING_VEHICLE_DEVICE as vehi on gpscus.GPS_CUST_DEVISE_ID=vehi.VhiTrackerID inner join
                VEHICLE_MASTER as vmas on vehi.VehicleID=vmas.VHC_MST_CODE inner join 
				CHART_ACC as cus on gpscus.GPS_CUST_CHART_ACC_ID=cus.CHT_ACC_ACC_NO inner join
                ACC_GROUP as cusgroup on cus.CHT_ACC_GROUP_CODE=cusgroup.ACC_GRP_GRP_CODE inner join 
				LOCATION as locemp on gpscus.GPS_CUST_SALES_REP_ID=locemp.LOC_LOC_CODE 
				order by GPS_CUST_ID desc", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "custLocation");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }

        public DataTable GetGPSDeviceID()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("vhiNO",typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT VhiTrackerID, vehi.VHC_MST_NO 
                FROM GPS_TRACKING_VEHICLE_DEVICE as tracker inner join
                VEHICLE_MASTER as vehi on tracker.VehicleID=vehi.VHC_MST_CODE";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["VhiTrackerID"], sdr["VHC_MST_NO"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }//Get Device Details

        public DataTable GetChatAccCustomer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("custName", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT CHT_ACC_ACC_NO, CHT_ACC_ALIAS + ' - ' + CHT_ACC_NAME AS CHT_ACC_NAME
                FROM CHART_ACC";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["CHT_ACC_ACC_NO"], sdr["CHT_ACC_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }//Get CHART_ACC Customer to combo

        public DataTable GetSalesRep()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("repName", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"SELECT LOC_LOC_CODE, LOC_LOC_SH_CODE + ' - ' + LOC_LOC_NAME AS LOC_LOC_NAME
                FROM LOCATION WHERE (LOC_LOC_GRP_CODE = 1) AND (LOC_LOC_SH_CODE + ' - ' + LOC_LOC_NAME IS NOT NULL)";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["LOC_LOC_CODE"], sdr["LOC_LOC_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return dt;
        }//Get EMPLOYEE_MASTER Rep to combo

        public string GetLastCustomerId()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"SELECT TOP 1 GPS_CUST_ID
                FROM GPS_CUSTOMER_LOCATION_MASTER ORDER BY GPS_CUST_ID DESC";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                { while (read.Read()) { index = (read["GPS_CUST_ID"].ToString()); } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); } //return index + "val";

            if (index == "") { index = 1.ToString(); return index; }
            else
            { int getindex = Convert.ToInt32(index); getindex = getindex + 1; return getindex.ToString(); }
        }//Get Last ID of the GPSSAlesCustomer

        public bool InsertNewCustomer(int custID, string area, int deviceID, double latitude, double longi,int repId,string day)
        {
            int index = Convert.ToInt32(GetLastCustomerId());
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; INSERT INTO dbo.GPS_CUSTOMER_LOCATION_MASTER
               (GPS_CUST_ID ,GPS_CUST_CHART_ACC_ID ,GPS_CUST_AREA ,GPS_CUST_DEVISE_ID ,GPS_CUST_LATITUDE ,GPS_CUST_LONGITUDE,GPS_CUST_SALES_REP_ID,GSP_CUST_ROUT_DAY)
                VALUES ( " + index + "," + custID + ",'" + area + "', " + deviceID + "," + latitude + ", " + longi + "," + repId + ",'" + day + "') COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public bool UpdateCustomer(int gpsCusID, int custID, string area, int deviceID, double latitude, double longi, int repId, string day)
        {
            bool status = false;
            try 
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; UPDATE       GPS_CUSTOMER_LOCATION_MASTER
                SET GPS_CUST_CHART_ACC_ID = " + custID + ", GPS_CUST_AREA = '" + area + "', GPS_CUST_DEVISE_ID = " + deviceID +
                ", GPS_CUST_LATITUDE = " + latitude + ", GPS_CUST_LONGITUDE = " + longi + ",GPS_CUST_SALES_REP_ID=" + repId + ",GSP_CUST_ROUT_DAY='" + day + "' WHERE GPS_CUST_ID = " + gpsCusID + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message+" Error select a row you want to update","Update Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            finally { conn.Close(); }
            return status;
        }

        public bool DeleteCustomer(int id)
        {
            bool status = false;
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"BEGIN TRANSACTION; DELETE FROM [dbo].[GPS_CUSTOMER_LOCATION_MASTER]
                WHERE  GPS_CUST_ID=" + id + " COMMIT TRANSACTION;";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
            return status;
        }

        public DataTable SearchComboBox(string query, string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = query;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr[name]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Search Method", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { conn.Close(); }
            return dt;
        }

        public DataSet GetCustomerSerchGrid(string query)
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(query, conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "CusSearchDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return ds;
        }
    }
}
