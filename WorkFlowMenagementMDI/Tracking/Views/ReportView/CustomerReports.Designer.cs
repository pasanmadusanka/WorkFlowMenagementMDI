namespace WorkFlowMenagementMDI.Tracking.Views.ReportView
{
    partial class CustomerReports
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
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbDeliveryVehi = new System.Windows.Forms.ComboBox();
            this.CMBRep = new System.Windows.Forms.ComboBox();
            this.DTPFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnReportView = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DTPToDate
            // 
            this.DTPToDate.Location = new System.Drawing.Point(332, 34);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(160, 20);
            this.DTPToDate.TabIndex = 18;
            this.DTPToDate.ValueChanged += new System.EventHandler(this.DTPToDate_ValueChanged);
            this.DTPToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPToDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "To Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Delivery Vehicle :";
            // 
            // CmbDeliveryVehi
            // 
            this.CmbDeliveryVehi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbDeliveryVehi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbDeliveryVehi.FormattingEnabled = true;
            this.CmbDeliveryVehi.Location = new System.Drawing.Point(332, 7);
            this.CmbDeliveryVehi.Name = "CmbDeliveryVehi";
            this.CmbDeliveryVehi.Size = new System.Drawing.Size(160, 21);
            this.CmbDeliveryVehi.TabIndex = 16;
            this.CmbDeliveryVehi.SelectedIndexChanged += new System.EventHandler(this.CmbDeliveryVehi_SelectedIndexChanged);
            this.CmbDeliveryVehi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbDeliveryVehi_KeyDown);
            // 
            // CMBRep
            // 
            this.CMBRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBRep.FormattingEnabled = true;
            this.CMBRep.Location = new System.Drawing.Point(72, 6);
            this.CMBRep.Name = "CMBRep";
            this.CMBRep.Size = new System.Drawing.Size(160, 21);
            this.CMBRep.TabIndex = 14;
            this.CMBRep.SelectedIndexChanged += new System.EventHandler(this.CMBRep_SelectedIndexChanged);
            this.CMBRep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMBRep_KeyDown);
            // 
            // DTPFromDate
            // 
            this.DTPFromDate.Location = new System.Drawing.Point(72, 34);
            this.DTPFromDate.Name = "DTPFromDate";
            this.DTPFromDate.Size = new System.Drawing.Size(160, 20);
            this.DTPFromDate.TabIndex = 15;
            this.DTPFromDate.ValueChanged += new System.EventHandler(this.DTPFromDate_ValueChanged);
            this.DTPFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFromDate_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sales Rep. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "From Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(2, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 40);
            this.panel1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(8, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(132, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Sales Customers Locations && Details";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DTPToDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.CmbDeliveryVehi);
            this.panel2.Controls.Add(this.CMBRep);
            this.panel2.Controls.Add(this.DTPFromDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 60);
            this.panel2.TabIndex = 22;
            // 
            // BtnReportView
            // 
            this.BtnReportView.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnReportView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportView.Location = new System.Drawing.Point(435, 122);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(69, 32);
            this.BtnReportView.TabIndex = 23;
            this.BtnReportView.Text = "Print";
            this.BtnReportView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // CustomerReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 158);
            this.Controls.Add(this.BtnReportView);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(522, 197);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(522, 197);
            this.Name = "CustomerReports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerReports";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CustomerReports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbDeliveryVehi;
        private System.Windows.Forms.ComboBox CMBRep;
        private System.Windows.Forms.DateTimePicker DTPFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnReportView;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}