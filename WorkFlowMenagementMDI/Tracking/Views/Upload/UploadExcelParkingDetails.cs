using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.Drawing;
using System.Collections.Generic;
using WorkFlowMenagementMDI.Tracking.Methods;

namespace WorkFlowMenagementMDI.Tracking.Views.Upload
{
    public partial class UploadExcelParkingDetails : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        UploadDetailsDB db = new UploadDetailsDB();
        List<string> datListCust = new List<string>();
        ToolTip tool = new ToolTip();
        public UploadExcelParkingDetails()
        {
            InitializeComponent();
        }

        public void ToolTipDetails()
        {
            tool.SetToolTip(btnSelect, "Import Excel file");
            tool.SetToolTip(groupBox2, "Select Farmer/Customer");
            tool.SetToolTip(BtnInsert, "Import excel to Database");
            tool.SetToolTip(DgvUploads, "Upload Details");
            tool.SetToolTip(lblFroRadioGroup, "Import excel to Database");
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);
                string header = rbHeaderYes.Checked ? "YES" : "NO";
                string conStr, sheetName;

                conStr = string.Empty;
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            DgvUploads.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message,"Uploading Excel",MessageBoxButtons.OK,MessageBoxIcon.Hand); }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (RBFarmer.Checked == true)
            {
                InsertDetailsToFoVisitations();
            }
            else { InsertDetailsToCustomerVisits(); }
        }
        public void InsertDetailsToFoVisitations()
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to upload Feild Officer visit details?", "Confirm data uploading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < DgvUploads.Rows.Count; i++)
                    {
                        string device = DgvUploads.Rows[i].Cells[0].Value.ToString();
                        string startTime = DgvUploads.Rows[i].Cells[1].Value.ToString();
                        string endTime = DgvUploads.Rows[i].Cells[2].Value.ToString();
                        double lat = Convert.ToDouble(DgvUploads.Rows[i].Cells[3].Value);
                        double lon = Convert.ToDouble(DgvUploads.Rows[i].Cells[4].Value);
                        int time = Convert.ToInt32(DgvUploads.Rows[i].Cells[5].Value);
                        string visitDay = startTime.Substring(5, 2) + "/" + startTime.Substring(8, 2) + "/" + startTime.Substring(0, 4);

                        if (db.InsertByDataGridView(db.GetBikesTrkIdByDevice(device), startTime, endTime, lat, lon, time, visitDay) && DgvUploads.Rows[i].DefaultCellStyle.BackColor != Color.LimeGreen)
                        {
                            try
                            {
                                DgvUploads.ClearSelection();
                                DgvUploads.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                                //Thread.Sleep(1000);
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "BtnSaveToDB_Click"); }
                        }
                        else
                        {
                            //MessageBox.Show("Error with data or Alredy Exsist....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DgvUploads.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }

                    }
                }
                else { /*Do nothing*/}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }//Insert parking of the Field officers

        public bool ReturnDateConfrm()
        {
            bool status = false;
            DataTable dt = db.GetDistDateInVehiPark();
            datListCust.Add(dt.ToString());
            foreach (string myInt in datListCust)
            {
 
            }
            return status;
        }

        public void InsertDetailsToCustomerVisits()
        {
            try
            {
                if (DgvUploads.Rows.Count != 0)
                {
                    DialogResult result = MessageBox.Show("Do you want to upload sales customer visit details?", "Confirm data uploading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; i < DgvUploads.Rows.Count; i++)
                        {
                            string device = DgvUploads.Rows[i].Cells[0].Value.ToString();
                            string startTime = DgvUploads.Rows[i].Cells[1].Value.ToString();
                            string endTime = DgvUploads.Rows[i].Cells[2].Value.ToString();
                            double lat = Convert.ToDouble(DgvUploads.Rows[i].Cells[3].Value);
                            double lon = Convert.ToDouble(DgvUploads.Rows[i].Cells[4].Value);
                            int time = Convert.ToInt32(DgvUploads.Rows[i].Cells[5].Value);
                            string visitDay = startTime.Substring(5, 2) + "/" + startTime.Substring(8, 2) + "/" + startTime.Substring(0, 4);

                            if (db.InsertCustomersLoc(db.GetVehicleTrkIdByDevice(device), startTime, endTime, lat, lon, time, visitDay) && DgvUploads.Rows[i].DefaultCellStyle.BackColor != Color.LimeGreen)
                            {
                                try
                                {
                                    DgvUploads.ClearSelection();
                                    DgvUploads.Rows[i].DefaultCellStyle.BackColor = Color.LimeGreen;
                                    //Thread.Sleep(1000);
                                }
                                catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Uploading Customer visits"); }
                            }
                            else
                            {
                                DgvUploads.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                    else { /*Do nothing*/}
                }
                else { MessageBox.Show("Table is empty import excel file to continue","Null value",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }//Insert Details of the Customer visits


        private void UploadExcelParkingDetails_Load(object sender, EventArgs e)
        {
            DataTable dateDT = db.GetDateTime();
            DataRow dateDR = dateDT.Rows[0]; 
            label2.Text = Convert.ToDateTime(dateDR[0]).ToString("dd/MM/yyyy"); 
            ToolTipDetails();
        }

        private void RBFarmer_CheckedChanged(object sender, EventArgs e)
        {
            LblSeleRb.Text = "Field Officer Visitation Selected";
        }

        private void RBCustomer_CheckedChanged(object sender, EventArgs e)
        {
            LblSeleRb.Text = "Sales Representative Visitation Selected";
        }
    }
}
