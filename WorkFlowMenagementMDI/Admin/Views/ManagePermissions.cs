using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WorkFlowMenagementMDI.Admin.Methods;

namespace WorkFlowMenagementMDI.Admin.Views
{
    public partial class ManagePermissions : Form
    {

        AdminRolesMethod db = new AdminRolesMethod();
        private Dictionary<string, string> oldMenuToolTips =
            new Dictionary<string, string>();
        private Form workingForm;

        public ManagePermissions(Form f)
        {
            InitializeComponent();
            workingForm = f;
            ShowControls(f.Controls);
        }

        private void ShowControls(Control.ControlCollection controlCollection)
        {
            foreach (Control c in controlCollection)
            {
                if (c.Controls.Count > 0)
                {
                    ShowControls(c.Controls);
                }
                if (c is MenuStrip)
                {
                    MenuStrip menuStrip = c as MenuStrip;
                    ShowToolStipItems(menuStrip.Items);
                }

                if (c is Button || c is ComboBox || c is TextBox ||
                    c is ListBox || c is DataGridView || c is RadioButton ||
                    c is RichTextBox || c is TabPage)
                {

                    //formToolTip2.SetToolTip(c, c.Name);

                    PageControls.Items.Add(c.Name);

                }
            }
        }

        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                oldMenuToolTips.Add(mi.Name, mi.ToolTipText);
                mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }

                PageControls.Items.Add(mi.Name);
            }
        }

        private void ManagePermissions_Load(object sender, EventArgs e)
        {
            label1.Text=workingForm.Name.ToString();
            LoadRolesListView();
            PopulatePermissionTree();
        }
        public void LoadRolesListView()
        {
            DataTable dt = db.LoadAllRolles();
            LBRoles.ValueMember = "id";
            LBRoles.DisplayMember = "name";
            LBRoles.DataSource = dt;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            foreach (String controlID in PageControls.SelectedItems)
            {
                foreach (DataRowView roleRow in LBRoles.SelectedItems)
                {
                    int roleID = Convert.ToInt32( roleRow["id"] );
                    int disOrInab=Disabled.Checked ? 1 : 0;
                    int visOrinvis=InVisible.Checked ? 1 : 0;
                    if (db.InsertNewControlsToRole(roleID, controlID, visOrinvis, disOrInab))
                    { PopulatePermissionTree(); }
                    else { MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); }
                }
            }
        }

        private void PopulatePermissionTree()
        {

            string queryString = @"select CW.CONRTOL_NAME,INVISIBLE,DISABLED,RW.ROLE_NAME
            FROM CONTROLS_TO_ROLES_WFMS as CTRW inner join
            CONTROLS_WFMS as CW on CTRW.FK_CONTROL_NAME=CW.CONRTOL_NAME inner join
            ROLES_WFMS as RW on CTRW.FK_ROLE_ID=RW.ROLE_ID";

            if (ByControlRB.Checked)
            {
                queryString += " order by CONRTOL_NAME";
            }
            else
            {
                queryString += " order by ROLE_NAME";
            } 

            DataTable dt = null; 
            DataSet ds = db.SelectRolesToControls(queryString);
            dt = ds.Tables[0];

            PermissionTree.BeginUpdate();
            PermissionTree.Nodes.Clear();
            TreeNode parentNode = null;
            TreeNode subNode = null;

            string currentName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                string subNodeText = ByControlRB.Checked ? row["ROLE_NAME"].ToString() : row["CONRTOL_NAME"].ToString();
                subNodeText += ":";
                subNodeText += Convert.ToInt32(row["INVISIBLE"]) == 0 ? " Visible " : " Not visible ";
                subNodeText += " and ";
                subNodeText += Convert.ToInt32(row["DISABLED"]) == 0 ? " Enabled " : " Disabled ";

                subNode = new TreeNode(subNodeText);
                string dataName = ByControlRB.Checked ? row["CONRTOL_NAME"].ToString() : row["ROLE_NAME"].ToString();
                if (currentName != dataName)
                {
                    parentNode = new TreeNode(dataName);
                    currentName = dataName;
                    PermissionTree.Nodes.Add(parentNode);
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                }
            }
            PermissionTree.EndUpdate();
        }

        private void ByControlRB_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissionTree();
        }

        private void ByRoleRB_CheckedChanged(object sender, EventArgs e)
        {
            PopulatePermissionTree();
        }

    }
}
