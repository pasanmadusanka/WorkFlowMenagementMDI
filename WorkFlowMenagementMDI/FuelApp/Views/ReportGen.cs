using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;

namespace WorkFlowMenagementMDI.FuelApp.Views
{
    public partial class ReportGen : Form
    {
        ReportMethods dba = new ReportMethods();
        ScreenCapture capScreen = new ScreenCapture();
        ReportAccess db = new ReportAccess();
        
        public ReportGen()
        {
            InitializeComponent();
        }

        private void ReportGen_Load(object sender, EventArgs e)
        {
            
            DgvFuel.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8F, FontStyle.Bold);
            
            DgvFuel.RowTemplate.MinimumHeight = 25;//25 is height.
            GetHeader();
            //With dgvDonors
            // DgvFuel.Columns(0).Width = 150;
            //DgvFuel.Columns[3].Visible = false;

            try
            {
                DataSet ds = dba.FillReportDetails(DateTime.Now.ToString("MM/dd/yyyy"));
                DgvFuel.DataSource = ds.Tables["FUEL_TMP_ISSUE_HEADER_SUB"].DefaultView;
                DgvFuel.Columns[1].Width = 70;
                DgvFuel.Columns[3].Width = 80;
                DgvFuel.Columns[4].Width = 83;
                DgvFuel.Columns[5].Width = 120;
                DgvFuel.Columns[6].Width = 55;
                DgvFuel.Columns[7].Width = 50;
                DgvFuel.Columns[8].Width = 72;
                DgvFuel.Columns[9].Width = 72;
                DgvFuel.Columns[10].Width = 76;
                //DgvFuel.Columns[10].Visible = false;
                DgvFuel.ClearSelection();
            }
            catch { MessageBox.Show("Error try again....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2, MessageBoxOptions.ServiceNotification); }

            try
            {
                DataTable table = dba.FillReport(DateTime.Now.ToString("MM/dd/yyyy"));
                DataRow row = table.Rows[0];

                LblDate.Text = "Date:- " + row[2].ToString();
                LblEndMeter.Text = "CLOSING FUEL PUMP M:R:- " + row[3].ToString();

                LblStartMeter.Text = "OPENING FUEL PUMP M:R:- " + dba.FillStartMeterCount(DateTime.Now.ToString("MM/dd/yyyy"));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        Bitmap bitmap;
        private void button1_Click(object sender, EventArgs e)
        {
            DgvFuel.ClearSelection();
            int height = PnalPrint.Height;
            //DgvFuel.Height = DgvFuel.RowCount * DgvFuel.RowTemplate.Height;

            //Create a Bitmap and draw the pnal on it.
            bitmap = new Bitmap(this.PnalPrint.Width, this.PnalPrint.Height);
            PnalPrint.DrawToBitmap(bitmap, new Rectangle(0, 0, this.PnalPrint.Width, this.PnalPrint.Height));

            //Resize DataGridView back to original height.
            PnalPrint.Height = height;

            //Show the Print Preview Dialog.
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print the contents.
            //printDocument1.DefaultPageSettings.Landscape = true;
            e.Graphics.DrawImage(bitmap, 99, 35);
        }

        public void GetHeader()
        {
            lblfooter.Text = "[ Copyright \u00A9 " + DateTime.Now.Year.ToString() + " Delmo IT " + " PD : "
                    + DateTime.Now.ToString("dd/MM/yyyy") + " PT : " + DateTime.Now.ToString("hh:mm:ss tt")
                    + " Com : " + System.Environment.MachineName.ToString() + " UN : "
                    + Properties.Settings.Default.LastUser + " ]";

            DataTable table = db.FillReportHeader();
            DataRow row = table.Rows[0];
            //LblCompanyName.Text = row[0].ToString() + Environment.NewLine + row[1].ToString();
            //label1.Text = row[0].ToString();
            //label3.Text = row[1].ToString();
            //label4.Text = "Tel : " + row[2].ToString() + " / Fax : " + row[3].ToString();
            //label5.Text = "E-Mail : " + row[4].ToString() + " / Web Address : " + row[5].ToString();
            //label6.Text = "Hot Line : 0774410500 / " + row[2].ToString();
        }
    }
}
