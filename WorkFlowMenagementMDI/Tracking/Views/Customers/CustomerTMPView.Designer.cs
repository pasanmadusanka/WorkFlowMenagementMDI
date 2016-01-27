namespace WorkFlowMenagementMDI.Tracking.Views.Customers
{
    partial class CustomerTMPView
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
            this.DgvCustomers = new System.Windows.Forms.DataGridView();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnParking = new System.Windows.Forms.Button();
            this.BtnCustomers = new System.Windows.Forms.Button();
            this.BtnFarmers = new System.Windows.Forms.Button();
            this.btnFoParking = new System.Windows.Forms.Button();
            this.BtnTrackVehi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvCustomers
            // 
            this.DgvCustomers.AllowUserToAddRows = false;
            this.DgvCustomers.AllowUserToDeleteRows = false;
            this.DgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCustomers.Location = new System.Drawing.Point(12, 58);
            this.DgvCustomers.Name = "DgvCustomers";
            this.DgvCustomers.Size = new System.Drawing.Size(703, 244);
            this.DgvCustomers.TabIndex = 1;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Location = new System.Drawing.Point(548, 29);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "Refresh";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "TMP view";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnParking
            // 
            this.BtnParking.Location = new System.Drawing.Point(386, 29);
            this.BtnParking.Name = "BtnParking";
            this.BtnParking.Size = new System.Drawing.Size(75, 23);
            this.BtnParking.TabIndex = 4;
            this.BtnParking.Text = "Parking view";
            this.BtnParking.UseVisualStyleBackColor = true;
            this.BtnParking.Click += new System.EventHandler(this.BtnParking_Click);
            // 
            // BtnCustomers
            // 
            this.BtnCustomers.Location = new System.Drawing.Point(144, 29);
            this.BtnCustomers.Name = "BtnCustomers";
            this.BtnCustomers.Size = new System.Drawing.Size(115, 23);
            this.BtnCustomers.TabIndex = 5;
            this.BtnCustomers.Text = "Customers";
            this.BtnCustomers.UseVisualStyleBackColor = true;
            this.BtnCustomers.Click += new System.EventHandler(this.BtnCustomers_Click);
            // 
            // BtnFarmers
            // 
            this.BtnFarmers.Location = new System.Drawing.Point(23, 29);
            this.BtnFarmers.Name = "BtnFarmers";
            this.BtnFarmers.Size = new System.Drawing.Size(115, 23);
            this.BtnFarmers.TabIndex = 6;
            this.BtnFarmers.Text = "Farmers";
            this.BtnFarmers.UseVisualStyleBackColor = true;
            this.BtnFarmers.Click += new System.EventHandler(this.BtnFarmers_Click);
            // 
            // btnFoParking
            // 
            this.btnFoParking.Location = new System.Drawing.Point(265, 29);
            this.btnFoParking.Name = "btnFoParking";
            this.btnFoParking.Size = new System.Drawing.Size(115, 23);
            this.btnFoParking.TabIndex = 7;
            this.btnFoParking.Text = "Customers";
            this.btnFoParking.UseVisualStyleBackColor = true;
            this.btnFoParking.Click += new System.EventHandler(this.btnFoParking_Click);
            // 
            // BtnTrackVehi
            // 
            this.BtnTrackVehi.Location = new System.Drawing.Point(640, 29);
            this.BtnTrackVehi.Name = "BtnTrackVehi";
            this.BtnTrackVehi.Size = new System.Drawing.Size(75, 23);
            this.BtnTrackVehi.TabIndex = 8;
            this.BtnTrackVehi.Text = "Track Vehi";
            this.BtnTrackVehi.UseVisualStyleBackColor = true;
            this.BtnTrackVehi.Click += new System.EventHandler(this.BtnTrackVehi_Click);
            // 
            // CustomerTMPView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 314);
            this.Controls.Add(this.BtnTrackVehi);
            this.Controls.Add(this.btnFoParking);
            this.Controls.Add(this.BtnFarmers);
            this.Controls.Add(this.BtnCustomers);
            this.Controls.Add(this.BtnParking);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnRefresh);
            this.Controls.Add(this.DgvCustomers);
            this.Name = "CustomerTMPView";
            this.Text = "CustomerTMPView";
            this.Load += new System.EventHandler(this.CustomerTMPView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvCustomers;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnParking;
        private System.Windows.Forms.Button BtnCustomers;
        private System.Windows.Forms.Button BtnFarmers;
        private System.Windows.Forms.Button btnFoParking;
        private System.Windows.Forms.Button BtnTrackVehi;
    }
}