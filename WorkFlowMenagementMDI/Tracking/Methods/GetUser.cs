using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowMenagementMDI.Tracking.Methods
{
    public class GetUser
    {
        public int Returnuser()
        {
            int user = Properties.Settings.Default.UserID;
            return user;
        }
    }
}
