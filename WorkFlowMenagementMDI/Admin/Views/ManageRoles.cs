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
    public partial class ManageRoles : Form
    {
        AdminRolesMethod db = new AdminRolesMethod();
        public ManageRoles()
        {
            InitializeComponent();
        }

        #region Users
        public void LoadCmbView()
        {
            DataTable dt = db.LoadAllUsers();
            CmbUsers.ValueMember = "id";
            CmbUsers.DisplayMember = "name";
            CmbUsers.DataSource = dt;
            CmbUsers.SelectedItem = null;
        }

        public void LoadUsersList()
        {
            DataTable dt = db.LoadAllUsersInSecqurityHdr();
            AppUsersListBox.ValueMember = "id";
            AppUsersListBox.DisplayMember = "name";
            AppUsersListBox.DataSource = dt;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.InsertNewUser(Convert.ToInt32(CmbUsers.SelectedValue)))
                { LoadUsersList(); }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }
        #endregion

        public void LoadRolesListView()
        {
            DataTable dt = db.LoadAllRolles();
            LBRoles.ValueMember = "id";
            LBRoles.DisplayMember = "name";
            LBRoles.DataSource = dt;
        }
        private void ManageRoles_Load(object sender, EventArgs e)
        {
            LoadCmbView();
            LoadUsersList();
            LoadRolesListView();
            FillUsersInRollsTree();
        }
        private void BtnRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (db.InsertNewRole(TxtInpuRol.Text))
                { LoadRolesListView(); }
                else
                    MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2); }
        }

        private void AddUsersToRole_Click(object sender, EventArgs e)
        {
            foreach (DataRowView userRow in AppUsersListBox.SelectedItems)
            {
                foreach (DataRowView roleRow in LBRoles.SelectedItems)
                {
                    int userID = Convert.ToInt32(userRow["id"]);
                    string user = userRow["name"].ToString();
                    int roleID = Convert.ToInt32(roleRow["id"]);
                    int create = ChkCreate.Checked ? 1 : 0;
                    int update = ChkUpdate.Checked ? 1 : 0;
                    int delete = ChkDelete.Checked ? 1 : 0;
                    if (user.ToLower() == "admin")
                    {
                        MessageBox.Show(user + " is a Superuser No roles needed", "Roles Assigning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillUsersInRollsTree();
                    }
                    else
                    {
                        if (db.InsertNewUsersToRole(roleID, userID, create, update, delete))
                        {
                            FillUsersInRollsTree();
                        }
                        else { MessageBox.Show("Sorry Somthing is Wrong!", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); }
                    }
                }
            }
        }

        private void FillUsersInRollsTree()
        {
            string queryString = @"select SH.SEC_HDR_USR_NAME,RW.ROLE_NAME, UTRW_CREATE, UTRW_UPDATE, UTRW_DELETE
            from USER_TO_ROLE_WFMS as UTRW inner join USERS_WFMS as UW on UTRW.FK_USER_ID=UW.UserID inner join
            ROLES_WFMS as RW on UTRW.FK_ROLE_ID=RW.ROLE_ID inner join SECURITY_HEADER as SH on UW.SecqHeaderID = SH.SEC_HDR_CODE";

            if (rbName.Checked)
            {
                queryString += " order by SH.SEC_HDR_USR_NAME";
            }
            else
            {
                queryString += " order by RW.ROLE_NAME";
            }

            UsersInRoles.BeginUpdate();
            UsersInRoles.Nodes.Clear();

            TreeNode parentNode = null;
            TreeNode subNode = null;
            TreeNode childNodeCreate = null;
            TreeNode childNodeUpdate = null;
            TreeNode childNodeDelete = null;


            DataSet ds = db.SelectRolesToUSERS(queryString);
            DataTable dt = ds.Tables[0];

            string currentName = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                string create, updatetxt, deleteTxt;
                create = Convert.ToInt32(row["UTRW_CREATE"]) == 1 ? "Create" : "Cannot Create";
                updatetxt = Convert.ToInt32(row["UTRW_UPDATE"]) == 1 ? "Update" : "Cannot Update";
                deleteTxt = Convert.ToInt32(row["UTRW_DELETE"]) == 1 ? "Delete" : "Cannot Delete";
                childNodeCreate = new TreeNode(create);
                childNodeUpdate = new TreeNode(updatetxt);
                childNodeDelete = new TreeNode(deleteTxt);
                if (rbName.Checked)
                {
                    subNode = new TreeNode(row["ROLE_NAME"].ToString());
                    if (currentName != row["SEC_HDR_USR_NAME"].ToString())
                    {
                        parentNode = new TreeNode(row["SEC_HDR_USR_NAME"].ToString());
                        currentName = row["SEC_HDR_USR_NAME"].ToString();
                        UsersInRoles.Nodes.Add(parentNode);
                    }
                }
                else
                {
                    subNode = new TreeNode(row["SEC_HDR_USR_NAME"].ToString());
                    if (currentName != row["ROLE_NAME"].ToString())
                    {
                        parentNode = new TreeNode(row["ROLE_NAME"].ToString());
                        currentName = row["ROLE_NAME"].ToString();
                        UsersInRoles.Nodes.Add(parentNode);
                    }
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                    if (chkBoCollExpan.Checked == true)
                    {
                        parentNode.ExpandAll();
                        chkBoCollExpan.Text = "Collapse";
                    }
                    else
                    {
                        parentNode.Collapse();
                        chkBoCollExpan.Text = "Expand";
                    }
                }
                if (subNode != null)
                {
                    subNode.Nodes.Add(childNodeCreate);
                    subNode.Nodes.Add(childNodeUpdate);
                    subNode.Nodes.Add(childNodeDelete);
                    if (chkBoCollExpan.Checked == true)
                    {
                        parentNode.ExpandAll();
                        chkBoCollExpan.Text = "Collapse";
                    }
                    else
                    {
                        parentNode.Collapse();
                        chkBoCollExpan.Text = "Expand";
                    }
                }
            }
            UsersInRoles.EndUpdate();
        }

        private void rbName_CheckedChanged(object sender, EventArgs e)
        {
            FillUsersInRollsTree();
        }

        private void rbRole_CheckedChanged(object sender, EventArgs e)
        {
            FillUsersInRollsTree();
        }

        private void ChkFullCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFullCtrl.Checked == true)
            {
                ChkCreate.Checked = true;
                ChkUpdate.Checked = true;
                ChkDelete.Checked = true;
            }
        }

        private void ChkCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkCreate.Checked == false)
            {
                ChkFullCtrl.Checked = false;
            }
        }

        private void ChkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUpdate.Checked == false)
            {
                ChkFullCtrl.Checked = false;
            }
        }

        private void ChkDelete_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDelete.Checked == false)
            {
                ChkFullCtrl.Checked = false;
            }
        }

        private void BtnRollBack_Click(object sender, EventArgs e)
        {
            foreach (DataRowView userRow in AppUsersListBox.SelectedItems)
            {
                foreach (DataRowView roleRow in LBRoles.SelectedItems)
                {
                    int userID = Convert.ToInt32(userRow["id"]);
                    string user = userRow["name"].ToString();
                    int roleID = Convert.ToInt32(roleRow["id"]);
                    if (user.ToLower() == "admin")
                    {
                        MessageBox.Show(user + " is a Superuser No roles needed", "Roles Removing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillUsersInRollsTree();
                    }
                    else
                    {
                        if (db.DeleteNewUsersToRole(roleID, userID))
                        {
                            FillUsersInRollsTree();
                        }
                        else { MessageBox.Show("Sorry Somthing is Wrong!", "Deleting Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2); }
                    }
                }
            }
        }

        private void chkBoCollExpan_CheckedChanged(object sender, EventArgs e)
        {
            FillUsersInRollsTree();
        }

    }
}
