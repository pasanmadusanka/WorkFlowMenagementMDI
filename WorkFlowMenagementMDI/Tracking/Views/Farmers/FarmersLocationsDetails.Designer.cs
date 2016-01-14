namespace WorkFlowMenagementMDI.Tracking.Views.Farmers
{
    partial class FarmersLocationsDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarmersLocationsDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnMapGridViews = new System.Windows.Forms.Button();
            this.PnlFO = new System.Windows.Forms.Panel();
            this.CmbFOfficer = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RbSingleFO = new System.Windows.Forms.RadioButton();
            this.RbAllFO = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.PnlFarmer = new System.Windows.Forms.Panel();
            this.GbFarmerFilt = new System.Windows.Forms.GroupBox();
            this.RbSingleFarm = new System.Windows.Forms.RadioButton();
            this.RbAllFarm = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbFarmer = new System.Windows.Forms.ComboBox();
            this.PnlArea = new System.Windows.Forms.Panel();
            this.GbByArea = new System.Windows.Forms.GroupBox();
            this.RbFiltAreaN = new System.Windows.Forms.RadioButton();
            this.RbFiltAreaY = new System.Windows.Forms.RadioButton();
            this.CmbArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PnlWebBrowser = new System.Windows.Forms.Panel();
            this.PnlGrid = new System.Windows.Forms.Panel();
            this.DGVFarmers = new System.Windows.Forms.DataGridView();
            this.WBFarmers = new System.Windows.Forms.WebBrowser();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.PnlFO.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.PnlFarmer.SuspendLayout();
            this.GbFarmerFilt.SuspendLayout();
            this.PnlArea.SuspendLayout();
            this.GbByArea.SuspendLayout();
            this.PnlWebBrowser.SuspendLayout();
            this.PnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVFarmers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 76);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Farmers Locations && Details";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BtnMapGridViews);
            this.panel2.Controls.Add(this.PnlFO);
            this.panel2.Controls.Add(this.PnlFarmer);
            this.panel2.Controls.Add(this.PnlArea);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(322, 354);
            this.panel2.TabIndex = 2;
            // 
            // BtnMapGridViews
            // 
            this.BtnMapGridViews.Location = new System.Drawing.Point(218, 318);
            this.BtnMapGridViews.Name = "BtnMapGridViews";
            this.BtnMapGridViews.Size = new System.Drawing.Size(84, 29);
            this.BtnMapGridViews.TabIndex = 3;
            this.BtnMapGridViews.Text = "Map View";
            this.BtnMapGridViews.UseVisualStyleBackColor = true;
            this.BtnMapGridViews.Click += new System.EventHandler(this.BtnMapGridViews_Click);
            // 
            // PnlFO
            // 
            this.PnlFO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlFO.Controls.Add(this.CmbFOfficer);
            this.PnlFO.Controls.Add(this.groupBox2);
            this.PnlFO.Controls.Add(this.label5);
            this.PnlFO.Enabled = false;
            this.PnlFO.Location = new System.Drawing.Point(17, 223);
            this.PnlFO.Name = "PnlFO";
            this.PnlFO.Size = new System.Drawing.Size(285, 89);
            this.PnlFO.TabIndex = 2;
            // 
            // CmbFOfficer
            // 
            this.CmbFOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFOfficer.FormattingEnabled = true;
            this.CmbFOfficer.Location = new System.Drawing.Point(89, 61);
            this.CmbFOfficer.Name = "CmbFOfficer";
            this.CmbFOfficer.Size = new System.Drawing.Size(184, 21);
            this.CmbFOfficer.TabIndex = 13;
            this.CmbFOfficer.SelectedIndexChanged += new System.EventHandler(this.CmbFOfficer_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RbSingleFO);
            this.groupBox2.Controls.Add(this.RbAllFO);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 43);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter by Field Officer";
            // 
            // RbSingleFO
            // 
            this.RbSingleFO.AutoSize = true;
            this.RbSingleFO.Location = new System.Drawing.Point(156, 19);
            this.RbSingleFO.Name = "RbSingleFO";
            this.RbSingleFO.Size = new System.Drawing.Size(76, 17);
            this.RbSingleFO.TabIndex = 3;
            this.RbSingleFO.Text = "Single F/O";
            this.RbSingleFO.UseVisualStyleBackColor = true;
            this.RbSingleFO.CheckedChanged += new System.EventHandler(this.RbSingleFO_CheckedChanged);
            // 
            // RbAllFO
            // 
            this.RbAllFO.AutoSize = true;
            this.RbAllFO.Checked = true;
            this.RbAllFO.Location = new System.Drawing.Point(76, 19);
            this.RbAllFO.Name = "RbAllFO";
            this.RbAllFO.Size = new System.Drawing.Size(58, 17);
            this.RbAllFO.TabIndex = 2;
            this.RbAllFO.TabStop = true;
            this.RbAllFO.Text = "All F/O";
            this.RbAllFO.UseVisualStyleBackColor = true;
            this.RbAllFO.CheckedChanged += new System.EventHandler(this.RbAllFO_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Field Officer:";
            // 
            // PnlFarmer
            // 
            this.PnlFarmer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlFarmer.Controls.Add(this.GbFarmerFilt);
            this.PnlFarmer.Controls.Add(this.label3);
            this.PnlFarmer.Controls.Add(this.CmbFarmer);
            this.PnlFarmer.Location = new System.Drawing.Point(17, 33);
            this.PnlFarmer.Name = "PnlFarmer";
            this.PnlFarmer.Size = new System.Drawing.Size(285, 89);
            this.PnlFarmer.TabIndex = 0;
            // 
            // GbFarmerFilt
            // 
            this.GbFarmerFilt.Controls.Add(this.RbSingleFarm);
            this.GbFarmerFilt.Controls.Add(this.RbAllFarm);
            this.GbFarmerFilt.Location = new System.Drawing.Point(10, 7);
            this.GbFarmerFilt.Name = "GbFarmerFilt";
            this.GbFarmerFilt.Size = new System.Drawing.Size(263, 43);
            this.GbFarmerFilt.TabIndex = 5;
            this.GbFarmerFilt.TabStop = false;
            this.GbFarmerFilt.Text = "Farmer";
            // 
            // RbSingleFarm
            // 
            this.RbSingleFarm.AutoSize = true;
            this.RbSingleFarm.Location = new System.Drawing.Point(156, 19);
            this.RbSingleFarm.Name = "RbSingleFarm";
            this.RbSingleFarm.Size = new System.Drawing.Size(89, 17);
            this.RbSingleFarm.TabIndex = 3;
            this.RbSingleFarm.Text = "Single Farmer";
            this.RbSingleFarm.UseVisualStyleBackColor = true;
            this.RbSingleFarm.CheckedChanged += new System.EventHandler(this.RbSingleFarm_CheckedChanged);
            // 
            // RbAllFarm
            // 
            this.RbAllFarm.AutoSize = true;
            this.RbAllFarm.Checked = true;
            this.RbAllFarm.Location = new System.Drawing.Point(76, 19);
            this.RbAllFarm.Name = "RbAllFarm";
            this.RbAllFarm.Size = new System.Drawing.Size(76, 17);
            this.RbAllFarm.TabIndex = 2;
            this.RbAllFarm.TabStop = true;
            this.RbAllFarm.Text = "All Farmers";
            this.RbAllFarm.UseVisualStyleBackColor = true;
            this.RbAllFarm.CheckedChanged += new System.EventHandler(this.RbAllFarm_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Farmers:";
            // 
            // CmbFarmer
            // 
            this.CmbFarmer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFarmer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFarmer.FormattingEnabled = true;
            this.CmbFarmer.Location = new System.Drawing.Point(116, 56);
            this.CmbFarmer.Name = "CmbFarmer";
            this.CmbFarmer.Size = new System.Drawing.Size(157, 21);
            this.CmbFarmer.TabIndex = 9;
            this.CmbFarmer.SelectedIndexChanged += new System.EventHandler(this.CmbFarmer_SelectedIndexChanged);
            // 
            // PnlArea
            // 
            this.PnlArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlArea.Controls.Add(this.GbByArea);
            this.PnlArea.Controls.Add(this.CmbArea);
            this.PnlArea.Controls.Add(this.label4);
            this.PnlArea.Enabled = false;
            this.PnlArea.Location = new System.Drawing.Point(17, 128);
            this.PnlArea.Name = "PnlArea";
            this.PnlArea.Size = new System.Drawing.Size(285, 89);
            this.PnlArea.TabIndex = 1;
            // 
            // GbByArea
            // 
            this.GbByArea.Controls.Add(this.RbFiltAreaN);
            this.GbByArea.Controls.Add(this.RbFiltAreaY);
            this.GbByArea.Location = new System.Drawing.Point(10, 9);
            this.GbByArea.Name = "GbByArea";
            this.GbByArea.Size = new System.Drawing.Size(263, 43);
            this.GbByArea.TabIndex = 6;
            this.GbByArea.TabStop = false;
            this.GbByArea.Text = "Area Wise Filter";
            // 
            // RbFiltAreaN
            // 
            this.RbFiltAreaN.AutoSize = true;
            this.RbFiltAreaN.Location = new System.Drawing.Point(156, 17);
            this.RbFiltAreaN.Name = "RbFiltAreaN";
            this.RbFiltAreaN.Size = new System.Drawing.Size(84, 17);
            this.RbFiltAreaN.TabIndex = 3;
            this.RbFiltAreaN.Text = "Single Areas";
            this.RbFiltAreaN.UseVisualStyleBackColor = true;
            this.RbFiltAreaN.CheckedChanged += new System.EventHandler(this.RbFiltAreaN_CheckedChanged);
            // 
            // RbFiltAreaY
            // 
            this.RbFiltAreaY.AutoSize = true;
            this.RbFiltAreaY.Checked = true;
            this.RbFiltAreaY.Location = new System.Drawing.Point(76, 20);
            this.RbFiltAreaY.Name = "RbFiltAreaY";
            this.RbFiltAreaY.Size = new System.Drawing.Size(66, 17);
            this.RbFiltAreaY.TabIndex = 2;
            this.RbFiltAreaY.TabStop = true;
            this.RbFiltAreaY.Text = "All Areas";
            this.RbFiltAreaY.UseVisualStyleBackColor = true;
            this.RbFiltAreaY.CheckedChanged += new System.EventHandler(this.RbFiltAreaY_CheckedChanged);
            // 
            // CmbArea
            // 
            this.CmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArea.FormattingEnabled = true;
            this.CmbArea.Location = new System.Drawing.Point(152, 58);
            this.CmbArea.Name = "CmbArea";
            this.CmbArea.Size = new System.Drawing.Size(121, 21);
            this.CmbArea.TabIndex = 11;
            this.CmbArea.SelectedIndexChanged += new System.EventHandler(this.CmbArea_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Area Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Filter Farmers";
            // 
            // PnlWebBrowser
            // 
            this.PnlWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlWebBrowser.BackColor = System.Drawing.Color.White;
            this.PnlWebBrowser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlWebBrowser.Controls.Add(this.PnlGrid);
            this.PnlWebBrowser.Controls.Add(this.WBFarmers);
            this.PnlWebBrowser.Location = new System.Drawing.Point(340, 94);
            this.PnlWebBrowser.Name = "PnlWebBrowser";
            this.PnlWebBrowser.Size = new System.Drawing.Size(463, 354);
            this.PnlWebBrowser.TabIndex = 3;
            // 
            // PnlGrid
            // 
            this.PnlGrid.Controls.Add(this.DGVFarmers);
            this.PnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlGrid.Location = new System.Drawing.Point(0, 0);
            this.PnlGrid.Name = "PnlGrid";
            this.PnlGrid.Size = new System.Drawing.Size(459, 350);
            this.PnlGrid.TabIndex = 1;
            // 
            // DGVFarmers
            // 
            this.DGVFarmers.AllowUserToAddRows = false;
            this.DGVFarmers.AllowUserToDeleteRows = false;
            this.DGVFarmers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVFarmers.BackgroundColor = System.Drawing.Color.White;
            this.DGVFarmers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVFarmers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVFarmers.Location = new System.Drawing.Point(0, 0);
            this.DGVFarmers.Name = "DGVFarmers";
            this.DGVFarmers.Size = new System.Drawing.Size(459, 350);
            this.DGVFarmers.TabIndex = 0;
            // 
            // WBFarmers
            // 
            this.WBFarmers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WBFarmers.Location = new System.Drawing.Point(0, 0);
            this.WBFarmers.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBFarmers.Name = "WBFarmers";
            this.WBFarmers.Size = new System.Drawing.Size(459, 350);
            this.WBFarmers.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(427, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Delmo Chicken && Agro (pvt) Limited GPS Tracking System For Farmers And Consumers" +
    " ©";
            // 
            // FarmersLocationsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 468);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PnlWebBrowser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FarmersLocationsDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FarmersLocationsDetails";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FarmersLocationsDetails_FormClosing);
            this.Load += new System.EventHandler(this.FarmersLocationsDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PnlFO.ResumeLayout(false);
            this.PnlFO.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.PnlFarmer.ResumeLayout(false);
            this.PnlFarmer.PerformLayout();
            this.GbFarmerFilt.ResumeLayout(false);
            this.GbFarmerFilt.PerformLayout();
            this.PnlArea.ResumeLayout(false);
            this.PnlArea.PerformLayout();
            this.GbByArea.ResumeLayout(false);
            this.GbByArea.PerformLayout();
            this.PnlWebBrowser.ResumeLayout(false);
            this.PnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVFarmers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RbSingleFO;
        private System.Windows.Forms.RadioButton RbAllFO;
        private System.Windows.Forms.GroupBox GbByArea;
        private System.Windows.Forms.RadioButton RbFiltAreaN;
        private System.Windows.Forms.RadioButton RbFiltAreaY;
        private System.Windows.Forms.GroupBox GbFarmerFilt;
        private System.Windows.Forms.RadioButton RbSingleFarm;
        private System.Windows.Forms.RadioButton RbAllFarm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PnlWebBrowser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CmbFarmer;
        private System.Windows.Forms.Panel PnlFO;
        private System.Windows.Forms.ComboBox CmbFOfficer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel PnlFarmer;
        private System.Windows.Forms.Panel PnlArea;
        private System.Windows.Forms.ComboBox CmbArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnMapGridViews;
        private System.Windows.Forms.Panel PnlGrid;
        private System.Windows.Forms.DataGridView DGVFarmers;
        private System.Windows.Forms.WebBrowser WBFarmers;
    }
}