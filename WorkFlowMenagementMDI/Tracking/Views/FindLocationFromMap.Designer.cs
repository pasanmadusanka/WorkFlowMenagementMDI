namespace WorkFlowMenagementMDI.Tracking.Views
{
    partial class FindLocationFromMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindLocationFromMap));
            this.label1 = new System.Windows.Forms.Label();
            this.CMBFieldOfficer = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DTPFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowserLocation = new System.Windows.Forms.WebBrowser();
            this.BtnGetLocations = new System.Windows.Forms.Button();
            this.BtnGetRoad = new System.Windows.Forms.Button();
            this.BtnReportView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field Officer :";
            // 
            // CMBFieldOfficer
            // 
            this.CMBFieldOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBFieldOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBFieldOfficer.FormattingEnabled = true;
            this.CMBFieldOfficer.Location = new System.Drawing.Point(80, 18);
            this.CMBFieldOfficer.Name = "CMBFieldOfficer";
            this.CMBFieldOfficer.Size = new System.Drawing.Size(247, 21);
            this.CMBFieldOfficer.TabIndex = 1;
            this.CMBFieldOfficer.SelectedIndexChanged += new System.EventHandler(this.CMBFieldOfficer_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(452, 212);
            this.dataGridView1.TabIndex = 2;
            // 
            // DTPFromDate
            // 
            this.DTPFromDate.Location = new System.Drawing.Point(80, 45);
            this.DTPFromDate.Name = "DTPFromDate";
            this.DTPFromDate.Size = new System.Drawing.Size(146, 20);
            this.DTPFromDate.TabIndex = 3;
            this.DTPFromDate.ValueChanged += new System.EventHandler(this.DTPSetDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "From Date :";
            // 
            // BrowserLocation
            // 
            this.BrowserLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserLocation.Location = new System.Drawing.Point(0, 0);
            this.BrowserLocation.MinimumSize = new System.Drawing.Size(20, 20);
            this.BrowserLocation.Name = "BrowserLocation";
            this.BrowserLocation.Size = new System.Drawing.Size(454, 333);
            this.BrowserLocation.TabIndex = 5;
            // 
            // BtnGetLocations
            // 
            this.BtnGetLocations.Location = new System.Drawing.Point(2, 1);
            this.BtnGetLocations.Name = "BtnGetLocations";
            this.BtnGetLocations.Size = new System.Drawing.Size(75, 32);
            this.BtnGetLocations.TabIndex = 6;
            this.BtnGetLocations.Text = "Direact view";
            this.BtnGetLocations.UseVisualStyleBackColor = true;
            this.BtnGetLocations.Click += new System.EventHandler(this.BtnGetLocations_Click);
            // 
            // BtnGetRoad
            // 
            this.BtnGetRoad.Location = new System.Drawing.Point(83, 1);
            this.BtnGetRoad.Name = "BtnGetRoad";
            this.BtnGetRoad.Size = new System.Drawing.Size(85, 32);
            this.BtnGetRoad.TabIndex = 7;
            this.BtnGetRoad.Text = "Road View";
            this.BtnGetRoad.UseVisualStyleBackColor = true;
            this.BtnGetRoad.Click += new System.EventHandler(this.BtnGetRoad_Click);
            // 
            // BtnReportView
            // 
            this.BtnReportView.Location = new System.Drawing.Point(351, 1);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(100, 32);
            this.BtnReportView.TabIndex = 8;
            this.BtnReportView.Text = "Get Report";
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "To Date :";
            // 
            // DTPToDate
            // 
            this.DTPToDate.Location = new System.Drawing.Point(290, 47);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(156, 20);
            this.DTPToDate.TabIndex = 9;
            this.DTPToDate.ValueChanged += new System.EventHandler(this.DTPToDate_ValueChanged);
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
            this.panel1.Size = new System.Drawing.Size(927, 76);
            this.panel1.TabIndex = 11;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Farmers Locations && Details";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.BrowserLocation);
            this.panel2.Location = new System.Drawing.Point(481, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(458, 337);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Location = new System.Drawing.Point(12, 94);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 86);
            this.panel3.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTPToDate);
            this.groupBox1.Controls.Add(this.DTPFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CMBFieldOfficer);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(452, 73);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter Field Visits Details";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(12, 187);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(462, 222);
            this.panel4.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.BtnGetLocations);
            this.panel5.Controls.Add(this.BtnGetRoad);
            this.panel5.Controls.Add(this.BtnReportView);
            this.panel5.Location = new System.Drawing.Point(12, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(462, 39);
            this.panel5.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(482, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Map View";
            // 
            // FindLocationFromMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 466);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindLocationFromMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FindLocationFromMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindLocationFromMap_FormClosing);
            this.Load += new System.EventHandler(this.FindLocationFromMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBFieldOfficer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker DTPFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.WebBrowser BrowserLocation;
        private System.Windows.Forms.Button BtnGetLocations;
        private System.Windows.Forms.Button BtnGetRoad;
        private System.Windows.Forms.Button BtnReportView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
    }
}