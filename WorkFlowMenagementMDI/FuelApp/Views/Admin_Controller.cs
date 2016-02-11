using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.FuelApp.Methods;
using WorkFlowMenagementMDI.FuelApp.Views.StockMovement;

namespace WorkFlowMenagementMDI.FuelApp.Views
{
    public partial class Admin_Controller : Form
    {
        ControllerMethods db = new ControllerMethods();
        FuelWeeklyStockMethods weeklyStock = new FuelWeeklyStockMethods();
        GetAvalableStockClass avalableStk = new GetAvalableStockClass();
        TreeViweMethods tree = new TreeViweMethods();
        TreeNode parentNode = null;
        private void Admin_Controller_Load(object sender, EventArgs e)
        {
            LoadGrid();
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.BtnCreateNew, "Add New Fuel Detail");
            ToolTip1.SetToolTip(this.LblUser, "Loged user");
            GetParentToTree();
        } 
        public void GetParentToTree()
        {
            TWFuelDetails.Nodes.Clear();
            DataTable dt = tree.GetRootDateTree();
            TWFuelDetails.ImageList=imageList1;
            foreach (DataRow dr in dt.Rows)
            { 
                parentNode = TWFuelDetails.Nodes.Add(dr["datId"].ToString(),dr["datName"].ToString());

                GetSubParentToTree(dr["datID"].ToString(), parentNode);
            }
        }
        public void GetSubParentToTree(string date, TreeNode parentNode)
        {
            DataTable dt = tree.GetSubParentLocTree(date);
            TreeNode childNode;
            foreach (DataRow dr in dt.Rows)
            {
                childNode = parentNode.Nodes.Add(dr["locID"].ToString(),dr["locName"].ToString());
                GetChildToTree(date, Convert.ToInt32(dr["locID"]), childNode);
            }
        }
        public void GetChildToTree(string date, int vhiID, TreeNode parentNode)
        {
            DataTable dt = tree.GetChildVhiTree(date, vhiID);
            TreeNode childNode;
            foreach (DataRow dr in dt.Rows)
            {
                childNode = parentNode.Nodes.Add(dr["vhiId"].ToString(),dr["vhiName"].ToString());
            }
        }
        #region Get avalable details for grid

        string lastUser = Properties.Settings.Default.LastUser;
        public Admin_Controller()
        {
            InitializeComponent();
            LblWelcom.Text = "WELCOM " + lastUser.ToUpper() + "...";
            LblUser.Text = lastUser.ToLower();
        }

        private void DgvAdmin_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //LoadGrid();
            string id = DgvAdmin.Rows[e.RowIndex].Cells[0].Value.ToString();   
            Controller f1 = new Controller(id, this);
             
            //mainCon.BtnSave
            this.Enabled = false;
            f1.ShowDialog();
        }//pass all cell row cell values to Controller Form

        private void Admin_Controller_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Login log = new Login();
            //log.Close();
        }

        public void LoadGrid()
        {
            try
            {
                DataSet ds = db.FillGrid();
                DgvAdmin.DataSource = ds.Tables["FUEL_TMP_ISSUE_HEADER_SUB"].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void BtnCreateNew_Click(object sender, EventArgs e)
        {
            CreateBtnProperty();
        }
         

        private void DgvAdmin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = DgvAdmin.Rows[e.RowIndex].Cells[0].Value.ToString(); 

                Controller f1 = new Controller(id, this);

                //mainCon.BtnSave
                this.Enabled = false;
                f1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "DgvAdmin_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        #region Insert to Fuel_Temp_Weekly_stock Table (MONDAY)
        public void CreateBtnProperty()
        {
            DataTable dtWeekly = weeklyStock.GetWeekName();//Access the week name
            DataRow drWeekly = dtWeekly.Rows[0];
            //string week = drWeekly[0].ToString();//Get week name
            string date = drWeekly[1].ToString();//get current date
            if (Properties.Settings.Default.AddPhyStkOnOff == "ON")
            {
                if (weeklyStock.GetLastDatWeeklyStk() != date)
                {
                    MessageBox.Show("Add the Current physical fuel stock to continue....", "Add Fuel Phisycal Stock", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SaveWeeklyPhysicalStk stock = new SaveWeeklyPhysicalStk();
                    stock.ShowDialog();
                }
                else
                {
                    Controller f1 = new Controller(this);
                    f1.Owner = this;
                    f1.ShowDialog();
                }
            }
            else
            {
                Controller f1 = new Controller(this);
                f1.Owner = this;
                f1.ShowDialog();
            }
        }
        #endregion 
        public void LoadGridtree(string query)
        {
            try
            {
                DataSet ds = tree.FillGridbyQuery(query);
                DgvAdmin.DataSource = ds.Tables["FUEL_TMP_ISSUE_HEADER_SUB"].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        } 
        private void TWFuelDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string query = @"select FIN_DOC_INDEX, IT_MST_DESCRIPTION, substring(FIN_DOC_DATE,4,3) + substring(FIN_DOC_DATE,1,3)+substring(FIN_DOC_DATE,7,4) as Date
            , FIN_DOC_TIME as Time, l.LOC_LOC_NAME,  v.VHC_MST_NO, e.Name1 as FIN_ISSUE_PERSON_NAME,FIN_MILEAGE, FIN_QTY, FIN_ST_METER, FIN_ED_METER
            ,e1.Name1 as FIN_SECURITY, FIN_STATUS, FIN_REFARANCE, e2.Name1 as FIN_AUTORIZED,s.SEC_HDR_USR_NAME as USER_CODE, TERMINAL_NAME, substring(FIN_SYS_DATE,4,3) + substring(FIN_SYS_DATE,1,3)+substring(FIN_SYS_DATE,7,4)as FIN_SYS_DATE , FIN_SYS_TIME
            FROM FUEL_TMP_ISSUE_HEADER_SUB as main Inner Join ITEM_MASTER as i on main.FIN_ITEM_CODE=i.IT_MST_CODE inner join LOCATION as l on main.FIN_LOC_LOC_CODE=l.LOC_LOC_CODE inner join
            VEHICLE_MASTER as v on main.FIN_VEHICLE_CODE=v.VHC_MST_CODE inner join EMPLOYEE_MASTER as e on main.FIN_ISSUE_PERSON_NAME=e.EMP_CODE inner join
            EMPLOYEE_MASTER as e1 on main.FIN_SECURITY=e1.EMP_CODE inner join EMPLOYEE_MASTER as e2 on main.FIN_AUTORIZED=e2.EMP_CODE inner join SECURITY_HEADER as s on main.USER_CODE=s.SEC_HDR_CODE";

                //MessageBox.Show(TWFuelDetails.SelectedNode.Level.ToString());


                if (TWFuelDetails.SelectedNode.Level == 0)
                {
                    var date = TWFuelDetails.SelectedNode.Name;
                    LoadGridtree(query + " where FIN_DOC_DATE = '" + date + "'");
                }
                else if (TWFuelDetails.SelectedNode.Level == 1)
                {
                    var date = TWFuelDetails.SelectedNode.Parent.Name;
                    int loc = Convert.ToInt32(TWFuelDetails.SelectedNode.Name);
                    LoadGridtree(query + " where FIN_DOC_DATE = '" + date + "' and l.LOC_LOC_CODE = " + loc + "");
                }

                else if (TWFuelDetails.SelectedNode.Level == 2)
                {
                    //LoadGridtree(query + " where FIN_DOC_DATE = '" + val + "'");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void TWFuelDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                LoadGrid();
            }
        } 
    }
}
