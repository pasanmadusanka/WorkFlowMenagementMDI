using FuelApp.Views.Reports;
using FuelApp.Views.Settings;
using FuelApp.Views.StockMovement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuelApp.Views
{
    public partial class MainMDI : Form
    {

        string lastUser = Properties.Settings.Default.LastUser;
        public MainMDI()
        {
            InitializeComponent();
        }
        private void MainMDI_Load(object sender, EventArgs e)
        {
            if (lastUser != "admin")
            {
                sMSControllerToolStripMenuItem.Enabled = false;
                settingsToolStripMenuItem.Enabled = false;
            }
        }

        private void fuelControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainPannelMDI.Controls.Clear();//contentpnl is the panelname
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(Admin_Controller))
                {
                    form.Activate();
                    return;
                }
            }
            Admin_Controller main = new Admin_Controller();
            main.MdiParent = this;
            main.Show();
        }

        private void sMSControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastUser == "admin")
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(SMS_Sender))
                    {
                        form.Activate();
                        return;
                    }
                }
                SMS_Sender sms = new SMS_Sender();
                sms.MdiParent = this;
                sms.Show();

                sms.WindowState = FormWindowState.Normal;
            }
            else
            { sMSControllerToolStripMenuItem.Enabled = false; }
        }

        private void MainMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void fuelReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "LoadMain";  
            DateSelection report = new DateSelection(id); 
            report.Show();  
        }

        private void generalReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ReportGen))
                {
                    form.Activate();
                    return;
                }
            }
            ReportGen report = new ReportGen();
            report.MdiParent = this;
            report.Show();

            report.WindowState = FormWindowState.Normal;
        }

        private void fuelStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastUser == "admin")
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(StockMovementForm))
                    {
                        form.Activate();
                        return;
                    }
                }
                StockMovementForm report = new StockMovementForm();
                report.MdiParent = this;
                report.Show();

                report.WindowState = FormWindowState.Normal;
            }
            else { sMSControllerToolStripMenuItem.Enabled = false; }
        }
        
        private void changeStockDateToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            PhysicalStockAddOnOff weeklyStoc = new PhysicalStockAddOnOff(); 
            weeklyStoc.Show(); 
        }

        private void addFuelPhysicalStockToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            SaveWeeklyPhysicalStk weeklyStoc = new SaveWeeklyPhysicalStk(); 
            weeklyStoc.ShowDialog(); 
        }

        #region All reports views
        private void fuelReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = "LoadMain"; 
            DateSelection report = new DateSelection(id); 
            report.Show(); 
        }

        private void fuelWeeklyPhysicalStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = "PhycisalLoad"; 
            DateSelection report = new DateSelection(id); 
            report.Show(); 
        }

        private void fuelStockMovementReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string id = "stockMovement";
            StockMovementReportView report = new StockMovementReportView(id);
            report.Show();
        }
        #endregion

    }
}
