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
    class GetResFromTMP
    {
        SqlConnection conn;
        public GetResFromTMP()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public DataSet LoadCustInfoToTab( )
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT ID as GPS_CUST_ID,[DATE] as dat,
                substring([DATE],4,3) + substring([DATE],1,3)+substring([DATE],7,4) as Vhi_Park_Date, 
                chart.CHT_ACC_ALIAS,chart.CHT_ACC_NAME,v4 as GPS_CUST_AREA, V5 as Start_Time, V6 as End_Time, INT2 as Vhi_Parking_Duration				
                FROM GPS_CUS_PARK_TBL_TMP as tmp inner join
                CHART_ACC as chart on tmp.ILoc=chart.CHT_ACC_ACC_NO
                order by [DATE],Start_Time", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "Tmp");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }

        public DataSet LoadCustInfoToTab2()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@" SELECT ID, DATE, V1Alis, IV2NAME, IVhiID, ILoc, V4, V5, V6, INT2, USERID, TERMINAL
                FROM GPS_CUS_PARK_TBL_TMP", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "Tmp1");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }

        public DataSet ParkingDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT Vhi_Parking_ID, VHI_DEVICE_NAME, Vhi_Start_Time, Vhi_Stop_Time, Vhi_Latitude, Vhi_Longitude, Vhi_Parking_Duration, Vhi_Park_Date, Added_Date, Vhi_User_Name, Vhi_Terminal_Name
FROM GPS_TRK_VEHICLE_PARKING", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "Tmp2");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }

        public DataSet FarmerParkingDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT ParkingID, Device_Name, Start_Time, End_Time, Latitude, Longitude, Period_Of_Time, Park_Date, Added_Date, AddedUser, TerminalName
FROM GPS_FO_PARKING_DETAILS", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "frmPak");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }

        public DataSet AllCustomersTable()
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT GPS_CUST_ID, GPS_CUST_CHART_ACC_ID, GPS_CUST_AREA, GPS_CUST_DEVISE_ID, GPS_CUST_LATITUDE, GPS_CUST_LONGITUDE, GPS_CUST_SALES_REP_ID, GSP_CUST_ROUT_DAY, 
                 GPS_CUST_ROUT
                FROM GPS_CUSTOMER_LOCATION_MASTER", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "cust");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }

        public DataSet AllFarmersTable() 
        {
            DataSet ds = new DataSet();
            try
            {
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                SqlCommand sqlcmd = new SqlCommand(@"SELECT GPS_FRM_lOC_ID, GPS_FRM_HDR_MST_ID, GPS_FRM_LOC_LATITUDE, GPS_FRM_LOC_LONGITUDE, GPS_FRM_LOC_FO_TRK_ID, GPS_FRM_LOC_AR_MST_CODE
                FROM GPS_FARM_LOCATION_MASTER", conn);

                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(ds, "frm");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
            finally
            { conn.Close(); }
            return ds;
        }
    }
}
