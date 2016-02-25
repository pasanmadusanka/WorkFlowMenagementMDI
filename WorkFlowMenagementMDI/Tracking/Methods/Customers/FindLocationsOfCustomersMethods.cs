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
    class FindLocationsOfCustomersMethods
    {
        SqlConnection conn;
        public FindLocationsOfCustomersMethods()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataTable GetSalesRepToCMB()
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
                FROM LOCATION WHERE LOC_LOC_GRP_CODE = 1 AND LOC_LOC_SH_CODE + ' - ' + LOC_LOC_NAME IS NOT NULL";
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["LOC_LOC_CODE"], sdr["LOC_LOC_NAME"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Getting Locations"); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable GetDelivaryVehicle()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("vhiNO", typeof(string));

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
        }

        public DataSet LoadCustInfoToTab(string fromDate, string toDate, int trackID, int repID)
        {
            DataSet ds = new DataSet();
            try
            {
                string frmd = Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy");
                string toD = Convert.ToDateTime(toDate).ToString("MM/dd/yyyy");
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"select distinct chart.CHT_ACC_ALIAS,chart.CHT_ACC_NAME,gpsCus.GPS_CUST_AREA,
                substring(park.Vhi_Start_Time,12,8)as Start_Time,substring(park.Vhi_Stop_Time,12,8)as End_Time,park.Vhi_Parking_Duration
                from GPS_CUSTOMER_LOCATION_MASTER as gpsCus inner join
                CHART_ACC as chart on gpsCus.GPS_CUST_CHART_ACC_ID=chart.CHT_ACC_ACC_NO inner join
                GPS_TRACKING_VEHICLE_DEVICE as track on gpscus.GPS_CUST_DEVISE_ID=track.VhiTrackerID inner join
                GPS_TRK_VEHICLE_PARKING as park on park.VHI_DEVICE_NAME=track.VhiTrackerID inner join
                LOCATION as locemp on locemp.LOC_LOC_CODE=gpscus.GPS_CUST_SALES_REP_ID
                where CAST(ROUND(gpsCus.GPS_CUST_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Latitude, 3) AS FLOAT) and CAST(ROUND(gpsCus.GPS_CUST_LONGITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Longitude, 3) AS FLOAT)
                and Cast(park.Vhi_Park_Date as datetime) >='" + frmd + "' and Cast(park.Vhi_Park_Date as datetime) <='" + toD + "'" +
                "and locemp.LOC_LOC_CODE=" + repID + " and track.VhiTrackerID=" + trackID + " order by substring(park.Vhi_Start_Time,12,8)", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "VisitationDetails");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }//Lode to table for report gess

        public DataTable VisitationLocations(string fromDate, string toDate, int repID, int trackID)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("alias", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("area", typeof(string));
            dt.Columns.Add("lat", typeof(string));
            dt.Columns.Add("lon", typeof(string));
            dt.Columns.Add("stTim", typeof(string));
            dt.Columns.Add("edTim", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"select distinct substring(park.Vhi_Start_Time,12,8) as Start,chart.CHT_ACC_ALIAS,chart.CHT_ACC_NAME,gpsCus.GPS_CUST_AREA,gpsCus.GPS_CUST_LATITUDE,gpscus.GPS_CUST_LONGITUDE,
                substring(park.Vhi_Start_Time,12,8) as start, substring(park.Vhi_Stop_Time,12,8) as [end]
                from GPS_CUSTOMER_LOCATION_MASTER as gpsCus inner join
                CHART_ACC as chart on gpsCus.GPS_CUST_CHART_ACC_ID=chart.CHT_ACC_ACC_NO inner join
                GPS_TRACKING_VEHICLE_DEVICE as track on gpscus.GPS_CUST_DEVISE_ID=track.VhiTrackerID inner join
                GPS_TRK_VEHICLE_PARKING as park on park.VHI_DEVICE_NAME=track.VhiTrackerID inner join
                LOCATION as locemp on locemp.LOC_LOC_CODE=gpscus.GPS_CUST_SALES_REP_ID
                where CAST(ROUND(gpsCus.GPS_CUST_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Latitude, 3) AS FLOAT) and CAST(ROUND(gpsCus.GPS_CUST_LONGITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Longitude, 3) AS FLOAT)
                --where gpsCus.GPS_CUST_LATITUDE= park.Vhi_Latitude and gpsCus.GPS_CUST_LONGITUDE = park.Vhi_Longitude 
                and  Cast(park.Vhi_Park_Date as datetime) >='" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Vhi_Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and locemp.LOC_LOC_CODE=" + repID + " and track.VhiTrackerID=" + trackID + "" +
                " order by substring(park.Vhi_Start_Time,12,8)", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["CHT_ACC_ALIAS"], sdr["CHT_ACC_NAME"], sdr["GPS_CUST_AREA"], sdr["GPS_CUST_LATITUDE"], sdr["GPS_CUST_LONGITUDE"], sdr["start"], sdr["end"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public DataTable NoOfCustomerVisited(string fromDate, string toDate, int repID, int trackID)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("nOcus", typeof(string));

            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }

                SqlCommand scmd = new SqlCommand(@"select count(DISTinct gpsCus.GPS_CUST_ID) as count
                from GPS_CUSTOMER_LOCATION_MASTER as gpsCus inner join
                CHART_ACC as chart on gpsCus.GPS_CUST_CHART_ACC_ID=chart.CHT_ACC_ACC_NO inner join
                GPS_TRACKING_VEHICLE_DEVICE as track on gpscus.GPS_CUST_DEVISE_ID=track.VhiTrackerID inner join
                GPS_TRK_VEHICLE_PARKING as park on park.VHI_DEVICE_NAME=track.VhiTrackerID inner join
                LOCATION as locemp on locemp.LOC_LOC_CODE=gpscus.GPS_CUST_SALES_REP_ID
                where CAST(ROUND(gpsCus.GPS_CUST_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Latitude, 3) AS FLOAT) and CAST(ROUND(gpsCus.GPS_CUST_LONGITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Longitude, 3) AS FLOAT)
                --where gpsCus.GPS_CUST_LATITUDE= park.Vhi_Latitude and gpsCus.GPS_CUST_LONGITUDE = park.Vhi_Longitude 
                and  Cast(park.Vhi_Park_Date as datetime) >='" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Vhi_Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and locemp.LOC_LOC_CODE=" + repID + " and track.VhiTrackerID=" + trackID + "", conn);
                scmd.Connection = conn;
                scmd.CommandType = CommandType.Text;
                SqlDataReader sdr = scmd.ExecuteReader();
                while (sdr.Read())
                { dt.Rows.Add(sdr["count"]); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally { conn.Close(); }
            return dt;
        }

        public void DeleteTempTableData()
        {
            try
            {
                if (conn.State.ToString() == "Closed") { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"delete  from GPS_CUS_PARK_TBL_TMP";
                scmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); }
        }

        public bool WrightVisitsToTemp(string fromDate, string toDate, int trackID, int repID,int user,string pc)
        {
            bool status = false;
            try
            {
                DeleteTempTableData();//Clear Table data.
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand scmd = conn.CreateCommand();
                scmd.CommandType = CommandType.Text;
                scmd.CommandText = @"INSERT INTO [dbo].[GPS_CUS_PARK_TBL_TMP]
           ( ID,[DATE] ,[IV2NAME] ,[IVhiID] ,[ILoc] ,[V4] ,[V5] ,[V6] , INT2, USERID,TERMINAL)

            select gpsCus.GPS_CUST_ID,park.Vhi_Park_Date as [DATE],locemp.LOC_LOC_CODE as [IV2NAME],track.VhiTrackerID as [IVhiID],
            chart.CHT_ACC_ACC_NO as [ILoc],gpsCus.GPS_CUST_AREA as [V4],substring(park.Vhi_Start_Time,12,8)as [V5],
            substring(park.Vhi_Stop_Time,12,8)as [V6],park.Vhi_Parking_Duration as INT2,'" + user + "','" + pc + "' " +
            " from GPS_CUSTOMER_LOCATION_MASTER as gpsCus inner join CHART_ACC as chart on gpsCus.GPS_CUST_CHART_ACC_ID=chart.CHT_ACC_ACC_NO inner join " +
            " GPS_TRACKING_VEHICLE_DEVICE as track on gpscus.GPS_CUST_DEVISE_ID=track.VhiTrackerID inner join GPS_TRK_VEHICLE_PARKING as park on park.VHI_DEVICE_NAME=track.VhiTrackerID inner join " +
            " LOCATION as locemp on locemp.LOC_LOC_CODE=gpscus.GPS_CUST_SALES_REP_ID where CAST(ROUND(gpsCus.GPS_CUST_LATITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Latitude, 3) AS FLOAT) and CAST(ROUND(gpsCus.GPS_CUST_LONGITUDE, 3) AS FLOAT) = CAST(ROUND(park.Vhi_Longitude, 3) AS FLOAT) " +
            " and Cast(park.Vhi_Park_Date as datetime) >='" + Convert.ToDateTime(fromDate).ToString("MM/dd/yyyy") + "' and Cast(park.Vhi_Park_Date as datetime) <='" + Convert.ToDateTime(toDate).ToString("MM/dd/yyyy") + "' and locemp.LOC_LOC_CODE=" + repID + " and track.VhiTrackerID=" + trackID + " order by [DATE],substring(park.Vhi_Start_Time,12,8)";
                scmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Wright Locations"); }
            finally { conn.Close(); }
            return status;
        }

        //public bool Get
    }
}
