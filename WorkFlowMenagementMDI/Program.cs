using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Admin;
using WorkFlowMenagementMDI.Admin.Views;
using WorkFlowMenagementMDI.FeedIssue.Views;
using WorkFlowMenagementMDI.FuelApp.Views;
using WorkFlowMenagementMDI.Login;

namespace WorkFlowMenagementMDI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new System.Threading.Mutex(false, "WorkFlowMenagement");
            try
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new AdminDeteteParkingData());
                    string serevr = "SERVER";
                    //string serevr = "SERVER";
                    string newserv = "Data Source=" + serevr + ";Initial Catalog=NelnaDB;Integrated Security=True";
                    if (Properties.Settings.Default.NewConStr == newserv)
                    {
                        #region
                        Application.Run(new Splash());
                        // After splash form closed, start the main form.
                        Application.Run(new LoginWindow());
                        #endregion
                    }
                    else
                    {
                        #region
                        Application.Run(new ProvideConstrForm());
                        //Application.Run(new Splash());
                        #endregion
                    }
                }
                else
                {
                    MessageBox.Show("An instance of the application is already running.", "Application Exsist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally { if (mutex != null) { mutex.Close(); mutex = null; } } 
        }
    }
}
