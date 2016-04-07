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
    public class StockMovementProcedure
    {
        SqlConnection conn;
        
        public StockMovementProcedure()
        {
            DBAccess db = new DBAccess();
            conn = db.conn;
        }

        //exec dbo.Fuel_Stock_Movement_SP 25,1,'HO51','8229'

        public bool GetAvalableStock(double issueQty, string billNo )
        {
            bool status = false;
            int userID = Properties.Settings.Default.UserID;
            string pcName = System.Environment.MachineName.ToString();
            //@issueAmt FLOAT,@userID int, @pc varchar(10), @refNo varchar(10) 
            try
            { 
                SqlCommand cmd = new SqlCommand("dbo.Fuel_Stock_Movement_SP", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@issueAmt", issueQty);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@pc", pcName);
                cmd.Parameters.AddWithValue("@refNo", billNo); 
                conn.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (Exception ex) { MessageBox.Show("Procedure Stock 'GetAvalableStock' " + ex.ToString()); }

            finally { conn.Close(); }
            return status;
        }
    }
}
