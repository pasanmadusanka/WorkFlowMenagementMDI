using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Customers;

namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    public partial class CustomerTMPView : Form
    {
        GetResFromTMP db = new GetResFromTMP();
        public CustomerTMPView()
        {
            InitializeComponent();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            getTable();
        }

        private void CustomerTMPView_Load(object sender, EventArgs e)
        {
            getTable();
        }

        public void getTable()
        {
            DataSet ds = db.LoadCustInfoToTab();
            DgvCustomers.DataSource = ds.Tables["Tmp"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = db.LoadCustInfoToTab2();
            DgvCustomers.DataSource = ds.Tables["Tmp1"].DefaultView;
        }

        private void BtnParking_Click(object sender, EventArgs e)
        {
            DataSet ds = db.ParkingDetails();
            DgvCustomers.DataSource = ds.Tables["Tmp2"].DefaultView;
        }

        private void BtnCustomers_Click(object sender, EventArgs e)
        {
            DataSet ds = db.AllCustomersTable();
            DgvCustomers.DataSource = ds.Tables["cust"].DefaultView;
        }

        private void BtnFarmers_Click(object sender, EventArgs e)
        {
            DataSet ds = db.AllFarmersTable();
            DgvCustomers.DataSource = ds.Tables["frm"].DefaultView;
        }
    }
}
