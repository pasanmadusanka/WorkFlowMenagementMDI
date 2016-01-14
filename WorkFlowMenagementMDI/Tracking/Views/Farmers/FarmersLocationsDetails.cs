using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Tracking.Methods.Farmers;

namespace WorkFlowMenagementMDI.Tracking.Views.Farmers
{
    public partial class FarmersLocationsDetails : Form
    {
        FarmersViewMethods db = new FarmersViewMethods();
        List<string> farmerList = new List<string>();

        string gridQuery = @"SELECT mast.FAR_HDR_MST_NAME [Farmer Name],mast.FAR_HDR_MST_CODE as Code, area.AREA_MST_NAME as Area, GPS_FRM_LOC_LATITUDE as Latitude, 
        GPS_FRM_LOC_LONGITUDE as Longitude, fo.FLD_OFF_MST_NAME as Officer
        FROM GPS_FARM_LOCATION_MASTER as farm inner join 
        FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
        GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
        FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join 
        AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE ";

        public string GetCountOfLocsQuery()
        {
            string Locations = @"select count(*) as count
FROM GPS_FARM_LOCATION_MASTER as farm inner join 
        FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
        GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
        FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join 
        AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE";
            return Locations;
        }

        public string GetLocsOfLocsQuery()
        {
            string Locations = @"SELECT mast.FAR_HDR_MST_NAME Farmer_Name,mast.FAR_HDR_MST_CODE as Code, area.AREA_MST_NAME as Area_Name, GPS_FRM_LOC_LATITUDE as Latitude, 
        GPS_FRM_LOC_LONGITUDE as Longitude, fo.FLD_OFF_MST_NAME as Name
        FROM GPS_FARM_LOCATION_MASTER as farm inner join 
        FARMER_HEADER_MASTER as mast on farm.GPS_FRM_HDR_MST_ID=mast.FAR_HDR_MST_FAR_NO inner join
        GPS_FRM_FIELD_OFFICER_TRACKER as track on farm.GPS_FRM_LOC_FO_TRK_ID=track.FRM_FO_LOC_ID inner join
        FIELD_OFFICER_MASTER as fo on track.FRM_FO_MST_CODE_ID=fo.FLD_OFF_MST_CODE inner join 
        AREA_MASTER as area on farm.GPS_FRM_LOC_AR_MST_CODE=area.AREA_MST_CODE";
            return Locations;
        }
        public FarmersLocationsDetails()
        {
            InitializeComponent();
        }

        private void BtnMapGridViews_Click(object sender, EventArgs e)
        {
            if (PnlGrid.Visible == true)
            { PnlGrid.Visible = false; BtnMapGridViews.Text = "Grid View"; }
            else { PnlGrid.Visible = true; BtnMapGridViews.Text = "Map View"; }
        }

        private void FarmersLocationsDetails_Load(object sender, EventArgs e)
        {
            GetFarmersToCombo();
        }

        #region Load Farmers, Areas and Field Officers combo box 
        public void GetFarmersToCombo()
        {
            DataTable dt1 = db.GetAllFarmersCombo();
            CmbFarmer.ValueMember = "id";
            CmbFarmer.DisplayMember = "name";
            CmbFarmer.DataSource = dt1;
        }
        public void GetAreaNamesToCombo()
        {
            DataTable dt = db.GetAreasCombo();
            CmbArea.DisplayMember = "area";
            CmbArea.DataSource = dt;
        }
        public void GetFieldOffCombo()
        {
            DataTable dt = db.GetFieldOfficersCombo();
            CmbFOfficer.ValueMember = "id"; 
            CmbFOfficer.DisplayMember = "name";
            CmbFOfficer.DataSource = dt;
        }
        #endregion

        public void GetTableFiltered(string query)
        {
            DataSet ds = db.GetFarmerToGrid(query);
            DGVFarmers.DataSource = ds.Tables["VisitationDetails"].DefaultView;
        }

        public void WriteLocaFarmers(string countQuerys,string locQuery)
        {
            try
            {
                File.WriteAllText("LocationsTextFarmers.txt", string.Empty);
                DataTable dt = db.GetFarmersCount(countQuerys);
                DataRow ro = dt.Rows[0];
                int noOfFarmers = Convert.ToInt32(ro[0]);
                farmerList.Clear();
                for (int i = 0; i < noOfFarmers; i++)
                {
                    DataTable table = db.GetFarmersLocDetails(locQuery);
                    DataRow row = table.Rows[i];
                    farmerList.Add("{title:'" + row[0] + " - " + row[1] + "'," + "lat:" + row[3] + ", lng: " + row[4] + ",description:'" + row[0] + " - " + row[1] + " - " + row[5] + "- " + row[2] + "'}");
                    foreach (string mystr in farmerList)
                    {
                        File.WriteAllText("LocationsTextFarmers.txt", string.Join(", ", farmerList.ToArray()));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }//Write All to the Farmer location text file

        #region Queries To pass
        public void GetDefaulQuery()
        {
            GetTableFiltered(gridQuery +" order by farm.GPS_FRM_lOC_ID desc");
        }
        public void OnlyFarmerIdQuery()
        {
            GetTableFiltered(gridQuery + @"where GPS_FRM_lOC_ID = " + Convert.ToInt32(CmbFarmer.SelectedValue) + "");
        }
        public void OnlyOfficerIDQuery()
        {
            GetTableFiltered(gridQuery + @"where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + " order by farm.GPS_FRM_lOC_ID desc");
        }
        public void OnlyAreaIDQuery()
        {
            GetTableFiltered(gridQuery + @"where area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "' order by farm.GPS_FRM_lOC_ID desc");
        }
        public void OnlyOfficerAndAreaIDQuery()
        {
            GetTableFiltered(gridQuery + @"where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + " and area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "'");
        }
        #endregion

        #region Get Queries of count
        public void GetDefaulQueryCountMap()
        {
            string count = GetCountOfLocsQuery();
            string location = GetLocsOfLocsQuery();
            WriteLocaFarmers(count, location);
        }
        public void OnlyFarmerIdQueryCountMap()
        {
            string count = GetCountOfLocsQuery() + @" where GPS_FRM_lOC_ID = " + Convert.ToInt32(CmbFarmer.SelectedValue) + "";
            string location = GetLocsOfLocsQuery() + @" where GPS_FRM_lOC_ID = " + Convert.ToInt32(CmbFarmer.SelectedValue) + "";
            farmerList.Clear();
            WriteLocaFarmers(count, location);
        }
        public void OnlyOfficerIDQueryCountMap()
        {
            string count = GetCountOfLocsQuery() + @" where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + "";
            string location = GetLocsOfLocsQuery() + @" where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + "";
            
            WriteLocaFarmers(count, location);
        }
        public void OnlyAreaIDQueryCountMap()
        {
            string count = GetCountOfLocsQuery() + @" where area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "'";
            string location = GetLocsOfLocsQuery() + @" where area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "'";
            WriteLocaFarmers(count, location);
        }
        public void OnlyOfficerAndAreaIDQueryCountMap()
        {
            string count = GetCountOfLocsQuery() + @" where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + " and area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "'";
            string location = GetLocsOfLocsQuery() + @" where farm.GPS_FRM_LOC_FO_TRK_ID = " + Convert.ToInt32(CmbFOfficer.SelectedValue) + " and area.AREA_MST_NAME = '" + CmbArea.Text.ToString() + "'";
            WriteLocaFarmers(count, location);
        }
        #endregion

        private void RbAllFarm_CheckedChanged(object sender, EventArgs e)
        {
            RbFiltAreaY.Checked = true;
            RbAllFO.Checked = true;
            WBFarmers.DocumentText.Remove(0, WBFarmers.DocumentText.Length);
            CmbFarmer.Enabled = false;
            PnlArea.Enabled = true;
            PnlFO.Enabled = true;
            GetDefaulQuery();
            GetDefaulQueryCountMap();
            WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
        }

        private void RbSingleFarm_CheckedChanged(object sender, EventArgs e)
        {
            CmbFarmer.Enabled = true;
            PnlArea.Enabled = false;
            PnlFO.Enabled = false;
            OnlyFarmerIdQuery();
            OnlyFarmerIdQueryCountMap();
            WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
        }

        private void CmbFarmer_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnlyFarmerIdQueryCountMap();
            OnlyFarmerIdQuery();
            WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
        }

        private void RbFiltAreaY_CheckedChanged(object sender, EventArgs e)
        {
            CmbArea.Enabled = false;
            if (RbAllFO.Checked == true)
            {
                GetDefaulQuery(); GetDefaulQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
            else
            {
                OnlyOfficerIDQuery(); OnlyOfficerIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
        }
        private void RbFiltAreaN_CheckedChanged(object sender, EventArgs e)
        {
            CmbArea.Enabled = true;
            GetAreaNamesToCombo();
            if (RbAllFO.Checked == true)
            {
                OnlyAreaIDQuery(); OnlyAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
            else
            {
                OnlyOfficerAndAreaIDQuery(); OnlyOfficerAndAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
        }
        private void CmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbAllFO.Checked == true)
            {
                OnlyAreaIDQuery(); OnlyAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
            else if (RbSingleFO.Checked == true)
            {
                OnlyOfficerAndAreaIDQuery(); OnlyOfficerAndAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
        }//When area Combobox change
        private void RbAllFO_CheckedChanged(object sender, EventArgs e)
        {
            CmbFOfficer.Enabled = false;
            if (RbFiltAreaY.Checked == true)
            {
                GetDefaulQuery(); GetDefaulQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
            else
            {
                OnlyAreaIDQuery(); OnlyAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
        }

        private void RbSingleFO_CheckedChanged(object sender, EventArgs e)
        {
            CmbFOfficer.Enabled = true;
            GetFieldOffCombo();
        }

        private void CmbFOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbFiltAreaY.Checked == true)
            {
                OnlyOfficerIDQuery(); OnlyOfficerIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            } 
            else
            {
                OnlyOfficerAndAreaIDQuery(); OnlyOfficerAndAreaIDQueryCountMap();
                WBFarmers.DocumentText = db.ViewDetailsOnBrowser();
            }
        }

        private void FarmersLocationsDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(MainMenu))
                {
                    form.Activate();
                    return;
                }
            }
            Views.MainMenu main = new Views.MainMenu();
            main.MdiParent = this.ParentForm;
            main.Show();
            this.Hide();
        }
    }
}
