namespace WorkFlowMenagementMDI.Tracking.Views.ReportView
{
    partial class FarmerReport
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
            this.DTPFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CMBFieldOfficer = new System.Windows.Forms.ComboBox();
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
            this.DTPToDate.Location = new System.Drawing.Point(244, 41);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(106, 20);
            this.DTPToDate.TabIndex = 15;
            this.DTPToDate.ValueChanged += new System.EventHandler(this.DTPToDate_ValueChanged);
            this.DTPToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPToDate_KeyDown);
            // 
            // DTPFromDate
            // 
            this.DTPFromDate.Location = new System.Drawing.Point(70, 41);
            this.DTPFromDate.Name = "DTPFromDate";
            this.DTPFromDate.Size = new System.Drawing.Size(102, 20);
            this.DTPFromDate.TabIndex = 13;
            this.DTPFromDate.ValueChanged += new System.EventHandler(this.DTPFromDate_ValueChanged);
            this.DTPFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFromDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "To Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Field Officer :";
            // 
            // CMBFieldOfficer
            // 
            this.CMBFieldOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CMBFieldOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CMBFieldOfficer.FormattingEnabled = true;
            this.CMBFieldOfficer.Location = new System.Drawing.Point(73, 7);
            this.CMBFieldOfficer.Name = "CMBFieldOfficer";
            this.CMBFieldOfficer.Size = new System.Drawing.Size(247, 21);
            this.CMBFieldOfficer.TabIndex = 12;
            this.CMBFieldOfficer.SelectedIndexChanged += new System.EventHandler(this.CMBFieldOfficer_SelectedIndexChanged);
            this.CMBFieldOfficer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CMBFieldOfficer_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "From Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 40);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Farmer Visits Report By Field Officer";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BtnReportView);
            this.panel2.Controls.Add(this.DTPToDate);
            this.panel2.Controls.Add(this.DTPFromDate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CMBFieldOfficer);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(14, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 72);
            this.panel2.TabIndex = 23;
            // 
            // BtnReportView
            // 
            this.BtnReportView.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnReportView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportView.Location = new System.Drawing.Point(376, 34);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(74, 32);
            this.BtnReportView.TabIndex = 24;
            this.BtnReportView.Text = "Print";
            this.BtnReportView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // FarmerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 133);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(509, 172);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(509, 172);
            this.Name = "FarmerReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Farmer Report";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FarmerReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.DateTimePicker DTPFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBFieldOfficer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnReportView;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}