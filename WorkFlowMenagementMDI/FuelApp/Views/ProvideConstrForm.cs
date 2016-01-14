using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FuelApp.Views
{
    public partial class ProvideConstrForm : Form
    {
        public ProvideConstrForm()
        {
            InitializeComponent();
        }
        string constr;
        string dataSource;

        private void ProvideConstrForm_Load(object sender, EventArgs e)
        {

        }

        private void CmbAvalablePc_DropDown(object sender, EventArgs e)
        {
            if (CmbAvalablePc.Text == null && CmbAvalablePc.Text == "")
            {
                DirectoryEntry root = new DirectoryEntry("WinNT:");
                foreach (DirectoryEntry computers in root.Children)
                {
                    foreach (DirectoryEntry computer in computers.Children)
                    {
                        if (computer.Name != "Schema")
                        {
                            CmbAvalablePc.Items.Add(computer.Name);
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CmbAvalablePc.Text = System.Environment.MachineName.ToString();

            GetItems();
        }
        public void GetItems()
        {
            DirectoryEntry root = new DirectoryEntry("WinNT:");
            foreach (DirectoryEntry computers in root.Children)
            {
                foreach (DirectoryEntry computer in computers.Children)
                {
                    if (computer.Name != "Schema")
                    {
                        CmbAvalablePc.Items.Add(computer.Name);
                    }
                }
            }

        }
        private void SavePcbtn_Click(object sender, EventArgs e)
        {
            if (CmbAvalablePc.Text != null && CmbAvalablePc.Text != "")
            {
                dataSource = CmbAvalablePc.Text;
                constr = "Data Source=" + dataSource + ";Initial Catalog=NelnaDB;Integrated Security=True";
                Properties.Settings.Default.NewConStr = constr;
                Properties.Settings.Default.Save();
                this.Hide();
                Login log = new Login();
                log.Show();
            }

            else
            { MessageBox.Show("Error elect the server pc.....", "Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
