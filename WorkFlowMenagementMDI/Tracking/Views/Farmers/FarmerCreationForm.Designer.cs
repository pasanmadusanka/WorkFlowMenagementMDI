namespace WorkFlowMenagementMDI.Tracking.Views.Farmers
{
    partial class FarmerCreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarmerCreationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbFrmArea = new System.Windows.Forms.ComboBox();
            this.CmbFarmer = new System.Windows.Forms.ComboBox();
            this.LblId = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBEdit = new System.Windows.Forms.RadioButton();
            this.RBCreate = new System.Windows.Forms.RadioButton();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.CmbFOfficer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtFarmarLon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtFarmerLat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvFarmers = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnImportExcel = new System.Windows.Forms.Button();
            this.ChkEnableSearch = new System.Windows.Forms.CheckBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.CMBSearch = new System.Windows.Forms.ComboBox();
            this.GBSearchCat = new System.Windows.Forms.GroupBox();
            this.RBAreaSearch = new System.Windows.Forms.RadioButton();
            this.RBCodeSearch = new System.Windows.Forms.RadioButton();
            this.RBNameSearch = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFarmers)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.GBSearchCat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.CmbFrmArea);
            this.panel1.Controls.Add(this.CmbFarmer);
            this.panel1.Controls.Add(this.LblId);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.CmbFOfficer);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtFarmarLon);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TxtFarmerLat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Location = new System.Drawing.Point(12, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 93);
            this.panel1.TabIndex = 1;
            // 
            // CmbFrmArea
            // 
            this.CmbFrmArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFrmArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFrmArea.FormattingEnabled = true;
            this.CmbFrmArea.Location = new System.Drawing.Point(91, 37);
            this.CmbFrmArea.Name = "CmbFrmArea";
            this.CmbFrmArea.Size = new System.Drawing.Size(195, 21);
            this.CmbFrmArea.TabIndex = 19;
            this.CmbFrmArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFrmArea_KeyDown);
            // 
            // CmbFarmer
            // 
            this.CmbFarmer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFarmer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFarmer.FormattingEnabled = true;
            this.CmbFarmer.Location = new System.Drawing.Point(91, 8);
            this.CmbFarmer.Name = "CmbFarmer";
            this.CmbFarmer.Size = new System.Drawing.Size(232, 21);
            this.CmbFarmer.TabIndex = 18;
            this.CmbFarmer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFarmer_KeyDown);
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(29, 66);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(10, 13);
            this.LblId.TabIndex = 17;
            this.LblId.Text = ".";
            this.LblId.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBEdit);
            this.groupBox1.Controls.Add(this.RBCreate);
            this.groupBox1.Controls.Add(this.BtnUpdate);
            this.groupBox1.Controls.Add(this.BtnAdd);
            this.groupBox1.Location = new System.Drawing.Point(649, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 83);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // RBEdit
            // 
            this.RBEdit.AutoSize = true;
            this.RBEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBEdit.Location = new System.Drawing.Point(160, 14);
            this.RBEdit.Name = "RBEdit";
            this.RBEdit.Size = new System.Drawing.Size(43, 17);
            this.RBEdit.TabIndex = 17;
            this.RBEdit.TabStop = true;
            this.RBEdit.Text = "Edit";
            this.RBEdit.UseVisualStyleBackColor = true;
            this.RBEdit.CheckedChanged += new System.EventHandler(this.RBEdit_CheckedChanged);
            // 
            // RBCreate
            // 
            this.RBCreate.AutoSize = true;
            this.RBCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBCreate.Location = new System.Drawing.Point(69, 14);
            this.RBCreate.Name = "RBCreate";
            this.RBCreate.Size = new System.Drawing.Size(81, 17);
            this.RBCreate.TabIndex = 16;
            this.RBCreate.TabStop = true;
            this.RBCreate.Text = "Create New";
            this.RBCreate.UseVisualStyleBackColor = true;
            this.RBCreate.CheckedChanged += new System.EventHandler(this.RBCreate_CheckedChanged);
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Enabled = false;
            this.BtnUpdate.Image = global::WorkFlowMenagementMDI.Properties.Resources.saveIMG;
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdate.Location = new System.Drawing.Point(160, 34);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(75, 39);
            this.BtnUpdate.TabIndex = 14;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.Enabled = false;
            this.BtnAdd.Image = global::WorkFlowMenagementMDI.Properties.Resources.plus_sign_icon_gray;
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdd.Location = new System.Drawing.Point(46, 34);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 39);
            this.BtnAdd.TabIndex = 13;
            this.BtnAdd.Text = "Create";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // CmbFOfficer
            // 
            this.CmbFOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFOfficer.FormattingEnabled = true;
            this.CmbFOfficer.Location = new System.Drawing.Point(432, 60);
            this.CmbFOfficer.Name = "CmbFOfficer";
            this.CmbFOfficer.Size = new System.Drawing.Size(211, 21);
            this.CmbFOfficer.TabIndex = 12;
            this.CmbFOfficer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbFOfficer_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Feild Officer :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Farmer Longitude :";
            // 
            // TxtFarmarLon
            // 
            this.TxtFarmarLon.Location = new System.Drawing.Point(432, 34);
            this.TxtFarmarLon.Name = "TxtFarmarLon";
            this.TxtFarmarLon.Size = new System.Drawing.Size(211, 20);
            this.TxtFarmarLon.TabIndex = 9;
            this.TxtFarmarLon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFarmarLon_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Farmer Latitude :";
            // 
            // TxtFarmerLat
            // 
            this.TxtFarmerLat.Location = new System.Drawing.Point(432, 8);
            this.TxtFarmerLat.Name = "TxtFarmerLat";
            this.TxtFarmerLat.Size = new System.Drawing.Size(211, 20);
            this.TxtFarmerLat.TabIndex = 7;
            this.TxtFarmerLat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtFarmerLat_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Farmer Area :";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Location = new System.Drawing.Point(9, 11);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(76, 13);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "Farmer Name :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DgvFarmers);
            this.panel2.Location = new System.Drawing.Point(12, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(920, 249);
            this.panel2.TabIndex = 2;
            // 
            // DgvFarmers
            // 
            this.DgvFarmers.AllowUserToAddRows = false;
            this.DgvFarmers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFarmers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFarmers.BackgroundColor = System.Drawing.Color.White;
            this.DgvFarmers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFarmers.Location = new System.Drawing.Point(3, 3);
            this.DgvFarmers.Name = "DgvFarmers";
            this.DgvFarmers.Size = new System.Drawing.Size(910, 239);
            this.DgvFarmers.TabIndex = 0;
            this.DgvFarmers.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvFarmers_RowHeaderMouseDoubleClick);
            this.DgvFarmers.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvFarmers_UserDeletingRow);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(920, 61);
            this.panel3.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Avalable Farmers and Details";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.BtnImportExcel);
            this.panel4.Controls.Add(this.ChkEnableSearch);
            this.panel4.Controls.Add(this.BtnSearch);
            this.panel4.Controls.Add(this.CMBSearch);
            this.panel4.Controls.Add(this.GBSearchCat);
            this.panel4.Location = new System.Drawing.Point(12, 66);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(920, 56);
            this.panel4.TabIndex = 13;
            // 
            // BtnImportExcel
            // 
            this.BtnImportExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtnImportExcel.Image")));
            this.BtnImportExcel.Location = new System.Drawing.Point(857, 14);
            this.BtnImportExcel.Name = "BtnImportExcel";
            this.BtnImportExcel.Size = new System.Drawing.Size(43, 30);
            this.BtnImportExcel.TabIndex = 20;
            this.BtnImportExcel.UseVisualStyleBackColor = true;
            this.BtnImportExcel.Click += new System.EventHandler(this.BtnImportExcel_Click);
            // 
            // ChkEnableSearch
            // 
            this.ChkEnableSearch.AutoSize = true;
            this.ChkEnableSearch.Location = new System.Drawing.Point(22, 18);
            this.ChkEnableSearch.Name = "ChkEnableSearch";
            this.ChkEnableSearch.Size = new System.Drawing.Size(60, 17);
            this.ChkEnableSearch.TabIndex = 19;
            this.ChkEnableSearch.Text = "Search";
            this.ChkEnableSearch.UseVisualStyleBackColor = true;
            this.ChkEnableSearch.CheckedChanged += new System.EventHandler(this.ChkEnableSearch_CheckedChanged);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSearch.Enabled = false;
            this.BtnSearch.Location = new System.Drawing.Point(770, 18);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 22);
            this.BtnSearch.TabIndex = 17;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // CMBSearch
            // 
            this.CMBSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBSearch.Enabled = false;
            this.CMBSearch.FormattingEnabled = true;
            this.CMBSearch.Location = new System.Drawing.Point(382, 18);
            this.CMBSearch.Name = "CMBSearch";
            this.CMBSearch.Size = new System.Drawing.Size(388, 21);
            this.CMBSearch.TabIndex = 16;
            this.CMBSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMBSearch_KeyDown);
            // 
            // GBSearchCat
            // 
            this.GBSearchCat.Controls.Add(this.RBAreaSearch);
            this.GBSearchCat.Controls.Add(this.RBCodeSearch);
            this.GBSearchCat.Controls.Add(this.RBNameSearch);
            this.GBSearchCat.Enabled = false;
            this.GBSearchCat.Location = new System.Drawing.Point(91, 2);
            this.GBSearchCat.Name = "GBSearchCat";
            this.GBSearchCat.Size = new System.Drawing.Size(264, 47);
            this.GBSearchCat.TabIndex = 15;
            this.GBSearchCat.TabStop = false;
            this.GBSearchCat.Text = " Search Catagory";
            // 
            // RBAreaSearch
            // 
            this.RBAreaSearch.AutoSize = true;
            this.RBAreaSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBAreaSearch.Location = new System.Drawing.Point(184, 18);
            this.RBAreaSearch.Name = "RBAreaSearch";
            this.RBAreaSearch.Size = new System.Drawing.Size(62, 17);
            this.RBAreaSearch.TabIndex = 20;
            this.RBAreaSearch.Text = "By Area";
            this.RBAreaSearch.UseVisualStyleBackColor = true;
            this.RBAreaSearch.CheckedChanged += new System.EventHandler(this.RBAreaSearch_CheckedChanged);
            // 
            // RBCodeSearch
            // 
            this.RBCodeSearch.AutoSize = true;
            this.RBCodeSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBCodeSearch.Location = new System.Drawing.Point(92, 18);
            this.RBCodeSearch.Name = "RBCodeSearch";
            this.RBCodeSearch.Size = new System.Drawing.Size(86, 17);
            this.RBCodeSearch.TabIndex = 19;
            this.RBCodeSearch.Text = "By Far. Code";
            this.RBCodeSearch.UseVisualStyleBackColor = true;
            this.RBCodeSearch.CheckedChanged += new System.EventHandler(this.RBCodeSearch_CheckedChanged);
            // 
            // RBNameSearch
            // 
            this.RBNameSearch.AutoSize = true;
            this.RBNameSearch.Checked = true;
            this.RBNameSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBNameSearch.Location = new System.Drawing.Point(19, 18);
            this.RBNameSearch.Name = "RBNameSearch";
            this.RBNameSearch.Size = new System.Drawing.Size(68, 17);
            this.RBNameSearch.TabIndex = 18;
            this.RBNameSearch.TabStop = true;
            this.RBNameSearch.Text = "By Name";
            this.RBNameSearch.UseVisualStyleBackColor = true;
            this.RBNameSearch.CheckedChanged += new System.EventHandler(this.RBNameSearch_CheckedChanged);
            // 
            // FarmerCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 487);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FarmerCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FarmerCreationForm";
            this.Load += new System.EventHandler(this.FarmerCreationForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFarmers)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.GBSearchCat.ResumeLayout(false);
            this.GBSearchCat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ComboBox CmbFOfficer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtFarmarLon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtFarmerLat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.DataGridView DgvFarmers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBEdit;
        private System.Windows.Forms.RadioButton RBCreate;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ComboBox CMBSearch;
        private System.Windows.Forms.GroupBox GBSearchCat;
        private System.Windows.Forms.RadioButton RBAreaSearch;
        private System.Windows.Forms.RadioButton RBCodeSearch;
        private System.Windows.Forms.RadioButton RBNameSearch;
        private System.Windows.Forms.CheckBox ChkEnableSearch;
        private System.Windows.Forms.ComboBox CmbFarmer;
        private System.Windows.Forms.ComboBox CmbFrmArea;
        private System.Windows.Forms.Button BtnImportExcel;

    }
}