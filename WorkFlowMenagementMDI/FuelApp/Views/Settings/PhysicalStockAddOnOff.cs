using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.FuelApp.Views.Settings
{
    public partial class PhysicalStockAddOnOff : Form
    {
        public PhysicalStockAddOnOff()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AddPhyStkOnOff = CmbWeekDays.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeDayOfWeeklyStock_Load(object sender, EventArgs e)
        {
            CmbWeekDays.Text = Properties.Settings.Default.AddPhyStkOnOff;
        }
    }
}
