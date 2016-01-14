using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WorkFlowMenagementMDI.Database
{
    public class ConnectionManager
    {
        public static SqlConnection Newcon; 

        public static string constr = WorkFlowMenagementMDI.Properties.Settings.Default.NewConStr; 
        //
        //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            Newcon = new SqlConnection(constr);
            return Newcon;
        } 
    }
}
