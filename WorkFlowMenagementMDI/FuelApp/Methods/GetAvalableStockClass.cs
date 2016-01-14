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
    public class GetAvalableStockClass
    {
        SqlConnection conn;

        public GetAvalableStockClass()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        public string GetSumNotSubmit()
        {
            string index = String.Empty;
            try
            {
                SqlCommand scmd = conn.CreateCommand();
                scmd.Connection = conn;

                string selectSql = @"SELECT SUM(FIN_QTY) AS QTY 
                FROM FUEL_TMP_ISSUE_HEADER_SUB WHERE FIN_STATUS='N'";

                SqlCommand com = new SqlCommand(selectSql, conn);
                if (conn.State.ToString() == "Closed")
                { conn.Open(); }
                using (SqlDataReader read = com.ExecuteReader())
                {
                    while (read.Read())
                    {
                        index = (read["QTY"].ToString());
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
            finally { conn.Close(); }
            //return index + "val";
            if (index == "")
            {
                index = 0.ToString();
                return index;
            }
            else
            {
                int getindex = Convert.ToInt32(index);

                return getindex.ToString();
            }
        }

        public string GetAvalableStock(int itemCode, int locCode)
        {
            string avalablestk = String.Empty;
            try
            {
                SqlCommand cmd = new SqlCommand("PRN_GEN_STOCK_BALANCE_INDIVIDUAL", conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ITEM_CODE", itemCode);

                cmd.Parameters.AddWithValue("@LOC_CODE", locCode);

                cmd.Parameters.Add("@SUC_MES", SqlDbType.Float);
                cmd.Parameters["@SUC_MES"].Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                avalablestk = cmd.Parameters["@SUC_MES"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Procedure Stock 'GetAvalableStock' " + ex.ToString());
            }
            return avalablestk;
        }

        public string GetAvalableStkByDate(string fromd,string toDate)
        {
            string avalableStk = String.Empty;
            try
            {
                SqlCommand scmd = new SqlCommand("PRN_GEN_STOCK_BALANCE_AS_AT", conn);

                scmd.CommandType = CommandType.StoredProcedure;
                scmd.Parameters.AddWithValue("@ITEM_CODE_FROM", "OT0081");
                scmd.Parameters.AddWithValue("@ITEM_CODE_TO", "OT0081");
                scmd.Parameters.AddWithValue("@LOC_CODE_BUFF", 130);
                scmd.Parameters.AddWithValue("@DATE_F", fromd);
                scmd.Parameters.AddWithValue("@DATE_T", toDate);
                scmd.Parameters.AddWithValue("@USER_CODE", 1);

                scmd.Parameters.Add("@SUC_MES", SqlDbType.Float);
                scmd.Parameters["@SUC_MES"].Direction = ParameterDirection.Output;
                conn.Open();
                scmd.ExecuteNonQuery();
                conn.Close();
                avalableStk = scmd.Parameters["@SUC_MES"].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetAvalableStkByDate() Procedure " + ex.ToString());
            }
            return avalableStk;
        }
    }
}
