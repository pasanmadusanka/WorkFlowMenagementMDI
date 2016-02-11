using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.DirectoryServices;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkFlowMenagementMDI.Login
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

        public void GetAvalableServers()
        {
            DataTable table = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow server in table.Rows)
            {
                CmbAvalablePc.Items.Add(server[table.Columns["ServerName"]].ToString());
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        { 
            GetAvalableServers();
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
                LoginWindow log = new LoginWindow();
                log.Show();
            }

            else
            { MessageBox.Show("Error elect the server pc.....", "Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
