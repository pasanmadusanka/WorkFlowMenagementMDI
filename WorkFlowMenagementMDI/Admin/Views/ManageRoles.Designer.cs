namespace WorkFlowMenagementMDI.Admin.Views
{
    partial class ManageRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AppUsersListBox = new System.Windows.Forms.ListBox();
            this.CmbUsers = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.DeleteAppUser = new System.Windows.Forms.Button();
            this.AddUsersToRole = new System.Windows.Forms.Button();
            this.LBRoles = new System.Windows.Forms.ListBox();
            this.TxtInpuRol = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnRole = new System.Windows.Forms.Button();
            this.rbRole = new System.Windows.Forms.RadioButton();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.UsersInRoles = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.ChkCreate = new System.Windows.Forms.CheckBox();
            this.ChkFullCtrl = new System.Windows.Forms.CheckBox();
            this.ChkUpdate = new System.Windows.Forms.CheckBox();
            this.ChkDelete = new System.Windows.Forms.CheckBox();
            this.BtnRollBack = new System.Windows.Forms.Button();
            this.chkBoCollExpan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AppUsersListBox
            // 
            this.AppUsersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AppUsersListBox.DisplayMember = "Name";
            this.AppUsersListBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppUsersListBox.FormattingEnabled = true;
            this.AppUsersListBox.ItemHeight = 19;
            this.AppUsersListBox.Location = new System.Drawing.Point(22, 33);
            this.AppUsersListBox.Name = "AppUsersListBox";
            this.AppUsersListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.AppUsersListBox.Size = new System.Drawing.Size(160, 213);
            this.AppUsersListBox.TabIndex = 109;
            this.AppUsersListBox.ValueMember = "UserID";
            // 
            // CmbUsers
            // 
            this.CmbUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CmbUsers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.Location = new System.Drawing.Point(22, 252);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(160, 21);
            this.CmbUsers.TabIndex = 110;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnAdd.Location = new System.Drawing.Point(188, 250);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 23);
            this.BtnAdd.TabIndex = 111;
            this.BtnAdd.Text = "Add User";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // DeleteAppUser
            // 
            this.DeleteAppUser.Enabled = false;
            this.DeleteAppUser.Location = new System.Drawing.Point(188, 33);
            this.DeleteAppUser.Name = "DeleteAppUser";
            this.DeleteAppUser.Size = new System.Drawing.Size(75, 23);
            this.DeleteAppUser.TabIndex = 112;
            this.DeleteAppUser.Text = "Delete";
            this.DeleteAppUser.UseVisualStyleBackColor = true;
            // 
            // AddUsersToRole
            // 
            this.AddUsersToRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUsersToRole.Location = new System.Drawing.Point(442, 167);
            this.AddUsersToRole.Name = "AddUsersToRole";
            this.AddUsersToRole.Size = new System.Drawing.Size(61, 23);
            this.AddUsersToRole.TabIndex = 113;
            this.AddUsersToRole.Text = "->>";
            this.AddUsersToRole.UseVisualStyleBackColor = true;
            this.AddUsersToRole.Click += new System.EventHandler(this.AddUsersToRole_Click);
            // 
            // LBRoles
            // 
            this.LBRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LBRoles.DisplayMember = "Name";
            this.LBRoles.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBRoles.FormattingEnabled = true;
            this.LBRoles.ItemHeight = 19;
            this.LBRoles.Location = new System.Drawing.Point(272, 33);
            this.LBRoles.Name = "LBRoles";
            this.LBRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LBRoles.Size = new System.Drawing.Size(160, 213);
            this.LBRoles.TabIndex = 114;
            this.LBRoles.ValueMember = "UserID";
            // 
            // TxtInpuRol
            // 
            this.TxtInpuRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TxtInpuRol.Location = new System.Drawing.Point(272, 253);
            this.TxtInpuRol.Name = "TxtInpuRol";
            this.TxtInpuRol.Size = new System.Drawing.Size(160, 20);
            this.TxtInpuRol.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 117;
            this.label3.Text = "Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 116;
            this.label1.Text = "Users";
            // 
            // BtnRole
            // 
            this.BtnRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnRole.Location = new System.Drawing.Point(438, 253);
            this.BtnRole.Name = "BtnRole";
            this.BtnRole.Size = new System.Drawing.Size(75, 23);
            this.BtnRole.TabIndex = 118;
            this.BtnRole.Text = "Add Role";
            this.BtnRole.UseVisualStyleBackColor = true;
            this.BtnRole.Click += new System.EventHandler(this.BtnRole_Click);
            // 
            // rbRole
            // 
            this.rbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbRole.AutoSize = true;
            this.rbRole.Location = new System.Drawing.Point(586, 256);
            this.rbRole.Name = "rbRole";
            this.rbRole.Size = new System.Drawing.Size(47, 17);
            this.rbRole.TabIndex = 128;
            this.rbRole.Text = "Role";
            this.rbRole.UseVisualStyleBackColor = true;
            this.rbRole.CheckedChanged += new System.EventHandler(this.rbRole_CheckedChanged);
            // 
            // rbName
            // 
            this.rbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbName.AutoSize = true;
            this.rbName.Checked = true;
            this.rbName.Location = new System.Drawing.Point(527, 256);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(53, 17);
            this.rbName.TabIndex = 127;
            this.rbName.TabStop = true;
            this.rbName.Text = "Name";
            this.rbName.UseVisualStyleBackColor = true;
            this.rbName.CheckedChanged += new System.EventHandler(this.rbName_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(523, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 126;
            this.label4.Text = "Users in Roles";
            // 
            // UsersInRoles
            // 
            this.UsersInRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UsersInRoles.Location = new System.Drawing.Point(526, 36);
            this.UsersInRoles.Name = "UsersInRoles";
            this.UsersInRoles.Size = new System.Drawing.Size(166, 213);
            this.UsersInRoles.TabIndex = 125;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(438, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 129;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ChkCreate
            // 
            this.ChkCreate.AutoSize = true;
            this.ChkCreate.Location = new System.Drawing.Point(442, 98);
            this.ChkCreate.Name = "ChkCreate";
            this.ChkCreate.Size = new System.Drawing.Size(57, 17);
            this.ChkCreate.TabIndex = 130;
            this.ChkCreate.Text = "Create";
            this.ChkCreate.UseVisualStyleBackColor = true;
            this.ChkCreate.CheckedChanged += new System.EventHandler(this.ChkCreate_CheckedChanged);
            // 
            // ChkFullCtrl
            // 
            this.ChkFullCtrl.AutoSize = true;
            this.ChkFullCtrl.Location = new System.Drawing.Point(442, 75);
            this.ChkFullCtrl.Name = "ChkFullCtrl";
            this.ChkFullCtrl.Size = new System.Drawing.Size(80, 17);
            this.ChkFullCtrl.TabIndex = 131;
            this.ChkFullCtrl.Text = "Full Controll";
            this.ChkFullCtrl.UseVisualStyleBackColor = true;
            this.ChkFullCtrl.CheckedChanged += new System.EventHandler(this.ChkFullCtrl_CheckedChanged);
            // 
            // ChkUpdate
            // 
            this.ChkUpdate.AutoSize = true;
            this.ChkUpdate.Location = new System.Drawing.Point(442, 121);
            this.ChkUpdate.Name = "ChkUpdate";
            this.ChkUpdate.Size = new System.Drawing.Size(61, 17);
            this.ChkUpdate.TabIndex = 132;
            this.ChkUpdate.Text = "Update";
            this.ChkUpdate.UseVisualStyleBackColor = true;
            this.ChkUpdate.CheckedChanged += new System.EventHandler(this.ChkUpdate_CheckedChanged);
            // 
            // ChkDelete
            // 
            this.ChkDelete.AutoSize = true;
            this.ChkDelete.Location = new System.Drawing.Point(442, 144);
            this.ChkDelete.Name = "ChkDelete";
            this.ChkDelete.Size = new System.Drawing.Size(57, 17);
            this.ChkDelete.TabIndex = 133;
            this.ChkDelete.Text = "Delete";
            this.ChkDelete.UseVisualStyleBackColor = true;
            this.ChkDelete.CheckedChanged += new System.EventHandler(this.ChkDelete_CheckedChanged);
            // 
            // BtnRollBack
            // 
            this.BtnRollBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRollBack.Location = new System.Drawing.Point(442, 196);
            this.BtnRollBack.Name = "BtnRollBack";
            this.BtnRollBack.Size = new System.Drawing.Size(61, 23);
            this.BtnRollBack.TabIndex = 134;
            this.BtnRollBack.Text = "<<-";
            this.BtnRollBack.UseVisualStyleBackColor = true;
            this.BtnRollBack.Click += new System.EventHandler(this.BtnRollBack_Click);
            // 
            // chkBoCollExpan
            // 
            this.chkBoCollExpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoCollExpan.AutoSize = true;
            this.chkBoCollExpan.Location = new System.Drawing.Point(627, 16);
            this.chkBoCollExpan.Name = "chkBoCollExpan";
            this.chkBoCollExpan.Size = new System.Drawing.Size(56, 17);
            this.chkBoCollExpan.TabIndex = 135;
            this.chkBoCollExpan.Text = "Expan";
            this.chkBoCollExpan.UseVisualStyleBackColor = true;
            this.chkBoCollExpan.CheckedChanged += new System.EventHandler(this.chkBoCollExpan_CheckedChanged);
            // 
            // ManageRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 308);
            this.Controls.Add(this.chkBoCollExpan);
            this.Controls.Add(this.BtnRollBack);
            this.Controls.Add(this.ChkDelete);
            this.Controls.Add(this.ChkUpdate);
            this.Controls.Add(this.ChkFullCtrl);
            this.Controls.Add(this.ChkCreate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbRole);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UsersInRoles);
            this.Controls.Add(this.BtnRole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtInpuRol);
            this.Controls.Add(this.LBRoles);
            this.Controls.Add(this.AddUsersToRole);
            this.Controls.Add(this.DeleteAppUser);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.CmbUsers);
            this.Controls.Add(this.AppUsersListBox);
            this.MinimumSize = new System.Drawing.Size(720, 347);
            this.Name = "ManageRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Roles";
            this.Load += new System.EventHandler(this.ManageRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AppUsersListBox;
        private System.Windows.Forms.ComboBox CmbUsers;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button DeleteAppUser;
        private System.Windows.Forms.Button AddUsersToRole;
        private System.Windows.Forms.ListBox LBRoles;
        private System.Windows.Forms.TextBox TxtInpuRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnRole;
        private System.Windows.Forms.RadioButton rbRole;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView UsersInRoles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ChkCreate;
        private System.Windows.Forms.CheckBox ChkFullCtrl;
        private System.Windows.Forms.CheckBox ChkUpdate;
        private System.Windows.Forms.CheckBox ChkDelete;
        private System.Windows.Forms.Button BtnRollBack;
        private System.Windows.Forms.CheckBox chkBoCollExpan;
    }
}