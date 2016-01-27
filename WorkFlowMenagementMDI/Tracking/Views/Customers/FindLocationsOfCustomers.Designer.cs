namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    partial class FindLocationsOfCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindLocationsOfCustomers));
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DgvCust = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbDeliveryVehi = new System.Windows.Forms.ComboBox();
            this.CMBRep = new System.Windows.Forms.ComboBox();
            this.DTPFromDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BrowserLocation = new System.Windows.Forms.WebBrowser();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BtnGetLocations = new System.Windows.Forms.Button();
            this.BtnGetRoad = new System.Windows.Forms.Button();
            this.BtnReportView = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCust)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Map View";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.DgvCust);
            this.panel4.Location = new System.Drawing.Point(3, 93);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(511, 221);
            this.panel4.TabIndex = 19;
            // 
            // DgvCust
            // 
            this.DgvCust.AllowUserToAddRows = false;
            this.DgvCust.AllowUserToDeleteRows = false;
            this.DgvCust.AllowUserToOrderColumns = true;
            this.DgvCust.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCust.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DgvCust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCust.Location = new System.Drawing.Point(2, 3);
            this.DgvCust.Name = "DgvCust";
            this.DgvCust.Size = new System.Drawing.Size(502, 211);
            this.DgvCust.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 84);
            this.panel3.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sales Rep. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DTPToDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CmbDeliveryVehi);
            this.groupBox1.Controls.Add(this.CMBRep);
            this.groupBox1.Controls.Add(this.DTPFromDate);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Field Visits Details";
            // 
            // DTPToDate
            // 
            this.DTPToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DTPToDate.Location = new System.Drawing.Point(337, 46);
            this.DTPToDate.MinimumSize = new System.Drawing.Size(160, 20);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(160, 20);
            this.DTPToDate.TabIndex = 9;
            this.DTPToDate.ValueChanged += new System.EventHandler(this.DTPToDate_ValueChanged);
            this.DTPToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPToDate_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(279, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "To Date :";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(243, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Delivery Vehicle :";
            // 
            // CmbDeliveryVehi
            // 
            this.CmbDeliveryVehi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CmbDeliveryVehi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbDeliveryVehi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbDeliveryVehi.FormattingEnabled = true;
            this.CmbDeliveryVehi.Location = new System.Drawing.Point(337, 19);
            this.CmbDeliveryVehi.MaximumSize = new System.Drawing.Size(210, 0);
            this.CmbDeliveryVehi.MinimumSize = new System.Drawing.Size(160, 0);
            this.CmbDeliveryVehi.Name = "CmbDeliveryVehi";
            this.CmbDeliveryVehi.Size = new System.Drawing.Size(160, 21);
            this.CmbDeliveryVehi.TabIndex = 4;
            this.CmbDeliveryVehi.SelectedIndexChanged += new System.EventHandler(this.CmbDeliveryVehi_SelectedIndexChanged);
            this.CmbDeliveryVehi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDeliveryVehi_KeyDown);
            // 
            // CMBRep
            // 
            this.CMBRep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMBRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBRep.FormattingEnabled = true;
            this.CMBRep.Location = new System.Drawing.Point(77, 18);
            this.CMBRep.MaximumSize = new System.Drawing.Size(210, 0);
            this.CMBRep.MinimumSize = new System.Drawing.Size(160, 0);
            this.CMBRep.Name = "CMBRep";
            this.CMBRep.Size = new System.Drawing.Size(160, 21);
            this.CMBRep.TabIndex = 1;
            this.CMBRep.SelectedIndexChanged += new System.EventHandler(this.CMBRep_SelectedIndexChanged);
            this.CMBRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMBRep_KeyDown);
            // 
            // DTPFromDate
            // 
            this.DTPFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DTPFromDate.Location = new System.Drawing.Point(77, 46);
            this.DTPFromDate.MaximumSize = new System.Drawing.Size(160, 20);
            this.DTPFromDate.Name = "DTPFromDate";
            this.DTPFromDate.Size = new System.Drawing.Size(160, 20);
            this.DTPFromDate.TabIndex = 3;
            this.DTPFromDate.ValueChanged += new System.EventHandler(this.DTPFromDate_ValueChanged);
            this.DTPFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFromDate_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BrowserLocation);
            this.panel2.Location = new System.Drawing.Point(18, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 321);
            this.panel2.TabIndex = 18;
            // 
            // BrowserLocation
            // 
            this.BrowserLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserLocation.Location = new System.Drawing.Point(0, 0);
            this.BrowserLocation.MinimumSize = new System.Drawing.Size(20, 20);
            this.BrowserLocation.Name = "BrowserLocation";
            this.BrowserLocation.Size = new System.Drawing.Size(459, 317);
            this.BrowserLocation.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sales Customers Locations && Details";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 76);
            this.panel1.TabIndex = 17;
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
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.AutoScroll = true;
            this.panel5.AutoSize = true;
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.BtnGetLocations);
            this.panel5.Controls.Add(this.BtnGetRoad);
            this.panel5.Controls.Add(this.BtnReportView);
            this.panel5.Location = new System.Drawing.Point(3, 315);
            this.panel5.MinimumSize = new System.Drawing.Size(518, 42);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(518, 43);
            this.panel5.TabIndex = 20;
            // 
            // BtnGetLocations
            // 
            this.BtnGetLocations.Location = new System.Drawing.Point(8, 4);
            this.BtnGetLocations.Name = "BtnGetLocations";
            this.BtnGetLocations.Size = new System.Drawing.Size(75, 32);
            this.BtnGetLocations.TabIndex = 6;
            this.BtnGetLocations.Text = "Direact view";
            this.BtnGetLocations.UseVisualStyleBackColor = true;
            this.BtnGetLocations.Click += new System.EventHandler(this.BtnGetLocations_Click);
            // 
            // BtnGetRoad
            // 
            this.BtnGetRoad.Image = ((System.Drawing.Image)(resources.GetObject("BtnGetRoad.Image")));
            this.BtnGetRoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGetRoad.Location = new System.Drawing.Point(125, 4);
            this.BtnGetRoad.Name = "BtnGetRoad";
            this.BtnGetRoad.Size = new System.Drawing.Size(85, 32);
            this.BtnGetRoad.TabIndex = 7;
            this.BtnGetRoad.Text = "Road View";
            this.BtnGetRoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGetRoad.UseVisualStyleBackColor = true;
            this.BtnGetRoad.Click += new System.EventHandler(this.BtnGetRoad_Click);
            // 
            // BtnReportView
            // 
            this.BtnReportView.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnReportView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportView.Location = new System.Drawing.Point(406, 4);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(94, 32);
            this.BtnReportView.TabIndex = 8;
            this.BtnReportView.Text = "Get Report";
            this.BtnReportView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 92);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Size = new System.Drawing.Size(1021, 362);
            this.splitContainer1.SplitterDistance = 520;
            this.splitContainer1.TabIndex = 22;
            // 
            // FindLocationsOfCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 466);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindLocationsOfCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindLocationsOfCustomers";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FindLocationsOfCustomers_FormClosed);
            this.Load += new System.EventHandler(this.FindLocationsOfCustomers_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCust)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView DgvCust;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBRep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.WebBrowser BrowserLocation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BtnGetLocations;
        private System.Windows.Forms.Button BtnGetRoad;
        private System.Windows.Forms.Button BtnReportView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDeliveryVehi;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}