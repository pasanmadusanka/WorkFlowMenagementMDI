using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using WorkFlowMenagementMDI.Database;
using WorkFlowMenagementMDI.Tracking.Methods;

namespace WorkFlowMenagementMDI.Tracking.Views
{
    public partial class FarmersLocationFilter : Form
    {
        FarmersMethods proced = new FarmersMethods();
        GetAllFarmers db = new GetAllFarmers();
        List<string> farmerList = new List<string>();
        public FarmersLocationFilter()
        {
            InitializeComponent();
        }

        //Methods proced = new Methods();
        private void BtnGetLoca_Click(object sender, EventArgs e)
        {
            calcularRota(TxtLati.Text, TxtLongi.Text);
        }

        public void calcularRota(string latitude, string longitude)
        {

            string url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);
            XElement xml = XElement.Load(url);


            if (xml.Element("status").Value == "OK")
            { 
                label3.Text = string.Format("<b>Origem</b>: {0}", xml.Element("result").Element("formatted_address").Value);
                LblLocation.Text = xml.Element("result").Element("formatted_address").Value;
            }

            else
            { label3.Text = String.Concat("Error Occured: ", xml.Element("status").Value); }
        }

        public void GetDireactions(string origLat, string origLong, string destiLat, string destiLong)
        {
            string url = string.Format(@"https://maps.googleapis.com/maps/api/distancematrix/xml?origins={0},{1}&destinations={2},{3}&mode=driving&sensor=false", origLat, origLong, destiLat, destiLong);
            XElement xml = XElement.Load(url);


            if (xml.Element("status").Value == "OK")
            {
                LblOriginAdd.Text = xml.Element("origin_address").Value;
                LblDestiAdd.Text = xml.Element("destination_address").Value;
                LblDuration.Text = xml.Element("row").Element("element").Element("duration").Element("text").Value;
                LblDistence.Text = xml.Element("row").Element("element").Element("distance").Element("text").Value;
            }
        }

        public void GetIssuePerson()
        {
            DataTable dt1 = proced.GetAllFarmers();
            CmbFarmer.ValueMember = "id";
            CmbFarmer.DisplayMember = "name";
            CmbFarmer.DataSource = dt1;
        }

        public void GetIssuePersonDestination()
        {
            DataTable dt1 = proced.GetAllFarmersToDestination(Convert.ToInt32(CmbFarmer.SelectedValue));
            CmbDestiFarmer.ValueMember = "id";
            CmbDestiFarmer.DisplayMember = "name";
            CmbDestiFarmer.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetDireactions(txtOriginLat.Text, txtOriginLong.Text, txtDestiLat.Text, txtDestiLongi.Text);
            ReadHtml();
        }

        public void ReadHtml()
        {
            try
            {
                StreamReader srheader = new StreamReader("DireactionsHeader.txt");
                String header = srheader.ReadToEnd();
                //StreamReader srLoc = new StreamReader("DireactionsLocations.txt");
                //String locations = srLoc.ReadToEnd();
                //StreamReader srFooter = new StreamReader("DireactionsFooter.txt");
                //String footer = srFooter.ReadToEnd();
                string toBrowser = header;
                //srLoc.Close();
                webBrowser1.DocumentText = toBrowser.ToString();

                //using (StreamReader sr = new StreamReader("TestFile1.txt"))
                //{
                //    // Read the stream to a string, and write the string to the console.
                //    String line = sr.ReadToEnd();
                //    Console.WriteLine(line);

                //    webBrowser1.DocumentText = @"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                //       "<html xmlns='http://www.w3.org/1999/xhtml'> <head> <title></title> <style type='text/css'>body  { ont-family: Arial; font-size: 10pt; }  </style> </head> <body>" +
                //    line.ToString() +
                //   "<table border='0' cellpadding='0' cellspacing='3'> <tr> <td colspan='2'>" +
                //   "Source: <input type='text' id='txtSource' value='" + CmbFarmer.Text + " " + LblOriginAdd.Text + "' style='width: 200px' />" +
                //   "&nbsp; Destination: <input type='text' id='txtDestination' value='" + CmbDestiFarmer.Text + " " + LblDestiAdd.Text + "' style='width: 200px' />" +
                //   "<hr/> Source Latitude : <input type='text' id='txtsourcLat' value='" + txtOriginLat.Text + "' style='width: 200px'/>" +
                //   "&nbsp; Source Longitude : <input type='text' id='txtsourcLon' value='" + txtOriginLong.Text + "' style='width: 200px'/>" +
                //   "<br /> Destination Latitude : <input type='text' id='txtdestLat' value='" + txtDestiLat.Text + "' style='width: 200px'/>" +
                //   "&nbsp; Destination Longitude : <input type='text' id='txtdestLon' value='" + txtDestiLongi.Text + "' style='width: 200px'/>" +
                //   "<br /> <input type='button' value='Get Route' onclick='GetRoute()' />" +
                //   "<hr /> </td> </tr> <tr> <td colspan='2'> <div id='dvDistance'> </div> </td> </tr> <tr> <td> <div id='dvMap' style='width: 500px; height: 500px'>" +
                //   "</div> </td>  <td> <div id='dvPanel' style='width: 500px; height: 500px'> </div>" +
                //   "</td> </tr> </table> <br /> </body> </html>";
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetIssuePerson();
            WriteLocaFarmers();
        }

        private void CmbFarmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIssuePersonDestination();
            GetOriginLocationCode();
        }

        public void GetOriginLocationCode()
        {
            DataTable dt = proced.GetLatitudeNLongitude(Convert.ToInt32(CmbFarmer.SelectedValue));
            DataRow dr = dt.Rows[0];
            txtOriginLat.Text = dr[0].ToString();
            txtOriginLong.Text = dr[1].ToString();
        }

        public void GetDestinationLocationCode()
        {
            DataTable dt = proced.GetLatitudeNLongitude(Convert.ToInt32(CmbDestiFarmer.SelectedValue));
            DataRow dr = dt.Rows[0];
            txtDestiLat.Text = dr[0].ToString();
            txtDestiLongi.Text = dr[1].ToString();
        }

        private void CmbDestiFarmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDestinationLocationCode();
        }

        private void TxtBrows_Click(object sender, EventArgs e)
        {
            //BrowsLoaction loc = new BrowsLoaction();
            //loc.Show();
        }

        private void BtnViewFarmers_Click(object sender, EventArgs e)
        {
            GetDetailsToText2();
        }

        public void WriteLocaFarmers()
        {
            try
            {
                File.WriteAllText("LocationsTextFarmers.txt", string.Empty);
                DataTable dt = db.GetFarmersCount();
                DataRow ro = dt.Rows[0];
                int noOfFarmers = Convert.ToInt32(ro[0]);
                farmerList.Clear();
                for (int i = 0; i < noOfFarmers; i++)
                {
                    DataTable table = db.GetFarmersLocDetails();
                    DataRow row = table.Rows[i];
                    farmerList.Add("{title:'" + row[1] + " - " + row[4] + "'," + "lat:" + row[2] + ", lng: " + row[3] + ",description:'" + row[1] + " - " + row[4] + " - " + row[5] + "'}");
                    foreach (string mystr in farmerList)
                    {
                        File.WriteAllText("LocationsTextFarmers.txt", string.Join(", ", farmerList.ToArray()));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void GetDetailsToText2()
        {
            StreamReader srheader = new StreamReader("FarmersLocationsHeader.txt");
            String header = srheader.ReadToEnd();
            StreamReader sr = new StreamReader("LocationsTextFarmers.txt");
            String locations = sr.ReadToEnd();
            StreamReader srFooter = new StreamReader("FarmersLocationsFooter.txt");
            String footer = srFooter.ReadToEnd();
            webBrowser1.DocumentText =  header + locations + footer;
        }//Load map to the browser with Driving Rout view;

        private void BtnUploadDetails_Click(object sender, EventArgs e)
        {
            //ParkingDetailsOfVehicle parking = new ParkingDetailsOfVehicle();
            //parking.ShowDialog();
            Process.Start("DataGridView_Import_Excel.exe");
        }

        private void BtnVisitDetails_Click(object sender, EventArgs e)
        {
            FindLocationFromMap visits = new FindLocationFromMap();
            visits.Show();
        }
    }
}
