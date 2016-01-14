namespace WorkFlowMenagementMDI.FeedIssue.ReportView
{
    partial class ReportSelector
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBMainFinisher = new System.Windows.Forms.RadioButton();
            this.RBMainBoost = new System.Windows.Forms.RadioButton();
            this.DtpExactDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnReportView = new System.Windows.Forms.Button();
            this.GBBooster = new System.Windows.Forms.GroupBox();
            this.RBSubW3 = new System.Windows.Forms.RadioButton();
            this.RBSubW2 = new System.Windows.Forms.RadioButton();
            this.RBSubW1 = new System.Windows.Forms.RadioButton();
            this.GBFinisher = new System.Windows.Forms.GroupBox();
            this.RBSubW5 = new System.Windows.Forms.RadioButton();
            this.RBSubW4 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbArea = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.GBBooster.SuspendLayout();
            this.GBFinisher.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(467, 61);
            this.panel3.TabIndex = 14;
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
            this.label4.Location = new System.Drawing.Point(66, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "FEED ISSUE SCHEDULE REPORT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.RBMainFinisher);
            this.panel1.Controls.Add(this.RBMainBoost);
            this.panel1.Controls.Add(this.DtpExactDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnReportView);
            this.panel1.Controls.Add(this.GBBooster);
            this.panel1.Controls.Add(this.GBFinisher);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbArea);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 163);
            this.panel1.TabIndex = 15;
            // 
            // RBMainFinisher
            // 
            this.RBMainFinisher.AutoSize = true;
            this.RBMainFinisher.Location = new System.Drawing.Point(318, 37);
            this.RBMainFinisher.Name = "RBMainFinisher";
            this.RBMainFinisher.Size = new System.Drawing.Size(61, 17);
            this.RBMainFinisher.TabIndex = 29;
            this.RBMainFinisher.Text = "Finisher";
            this.RBMainFinisher.UseVisualStyleBackColor = true;
            this.RBMainFinisher.CheckedChanged += new System.EventHandler(this.RBMainFinisher_CheckedChanged);
            // 
            // RBMainBoost
            // 
            this.RBMainBoost.AutoSize = true;
            this.RBMainBoost.Checked = true;
            this.RBMainBoost.Location = new System.Drawing.Point(71, 37);
            this.RBMainBoost.Name = "RBMainBoost";
            this.RBMainBoost.Size = new System.Drawing.Size(61, 17);
            this.RBMainBoost.TabIndex = 28;
            this.RBMainBoost.TabStop = true;
            this.RBMainBoost.Text = "Booster";
            this.RBMainBoost.UseVisualStyleBackColor = true;
            this.RBMainBoost.CheckedChanged += new System.EventHandler(this.RBMainBoost_CheckedChanged);
            // 
            // DtpExactDate
            // 
            this.DtpExactDate.Location = new System.Drawing.Point(297, 11);
            this.DtpExactDate.Name = "DtpExactDate";
            this.DtpExactDate.Size = new System.Drawing.Size(163, 20);
            this.DtpExactDate.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Date :";
            // 
            // BtnReportView
            // 
            this.BtnReportView.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnReportView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportView.Location = new System.Drawing.Point(391, 124);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(69, 32);
            this.BtnReportView.TabIndex = 25;
            this.BtnReportView.Text = "Print";
            this.BtnReportView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // GBBooster
            // 
            this.GBBooster.Controls.Add(this.RBSubW3);
            this.GBBooster.Controls.Add(this.RBSubW2);
            this.GBBooster.Controls.Add(this.RBSubW1);
            this.GBBooster.Location = new System.Drawing.Point(8, 55);
            this.GBBooster.Name = "GBBooster";
            this.GBBooster.Size = new System.Drawing.Size(223, 66);
            this.GBBooster.TabIndex = 3;
            this.GBBooster.TabStop = false;
            this.GBBooster.Text = "Booster";
            // 
            // RBSubW3
            // 
            this.RBSubW3.AutoSize = true;
            this.RBSubW3.Location = new System.Drawing.Point(16, 42);
            this.RBSubW3.Name = "RBSubW3";
            this.RBSubW3.Size = new System.Drawing.Size(63, 17);
            this.RBSubW3.TabIndex = 2;
            this.RBSubW3.Text = "Week 3";
            this.RBSubW3.UseVisualStyleBackColor = true;
            // 
            // RBSubW2
            // 
            this.RBSubW2.AutoSize = true;
            this.RBSubW2.Location = new System.Drawing.Point(122, 19);
            this.RBSubW2.Name = "RBSubW2";
            this.RBSubW2.Size = new System.Drawing.Size(63, 17);
            this.RBSubW2.TabIndex = 1;
            this.RBSubW2.Text = "Week 2";
            this.RBSubW2.UseVisualStyleBackColor = true;
            // 
            // RBSubW1
            // 
            this.RBSubW1.AutoSize = true;
            this.RBSubW1.Checked = true;
            this.RBSubW1.Location = new System.Drawing.Point(16, 19);
            this.RBSubW1.Name = "RBSubW1";
            this.RBSubW1.Size = new System.Drawing.Size(63, 17);
            this.RBSubW1.TabIndex = 0;
            this.RBSubW1.TabStop = true;
            this.RBSubW1.Text = "Week 1";
            this.RBSubW1.UseVisualStyleBackColor = true;
            // 
            // GBFinisher
            // 
            this.GBFinisher.Controls.Add(this.RBSubW5);
            this.GBFinisher.Controls.Add(this.RBSubW4);
            this.GBFinisher.Enabled = false;
            this.GBFinisher.Location = new System.Drawing.Point(237, 55);
            this.GBFinisher.Name = "GBFinisher";
            this.GBFinisher.Size = new System.Drawing.Size(223, 66);
            this.GBFinisher.TabIndex = 2;
            this.GBFinisher.TabStop = false;
            this.GBFinisher.Text = "Finisher";
            // 
            // RBSubW5
            // 
            this.RBSubW5.AutoSize = true;
            this.RBSubW5.Location = new System.Drawing.Point(122, 19);
            this.RBSubW5.Name = "RBSubW5";
            this.RBSubW5.Size = new System.Drawing.Size(63, 17);
            this.RBSubW5.TabIndex = 1;
            this.RBSubW5.Text = "Week 5";
            this.RBSubW5.UseVisualStyleBackColor = true;
            // 
            // RBSubW4
            // 
            this.RBSubW4.AutoSize = true;
            this.RBSubW4.Checked = true;
            this.RBSubW4.Location = new System.Drawing.Point(16, 19);
            this.RBSubW4.Name = "RBSubW4";
            this.RBSubW4.Size = new System.Drawing.Size(63, 17);
            this.RBSubW4.TabIndex = 0;
            this.RBSubW4.TabStop = true;
            this.RBSubW4.Text = "Week 4";
            this.RBSubW4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Area Name :";
            // 
            // CmbArea
            // 
            this.CmbArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbArea.FormattingEnabled = true;
            this.CmbArea.Location = new System.Drawing.Point(87, 10);
            this.CmbArea.Name = "CmbArea";
            this.CmbArea.Size = new System.Drawing.Size(144, 21);
            this.CmbArea.TabIndex = 0;
            this.CmbArea.SelectedIndexChanged += new System.EventHandler(this.CmbArea_SelectedIndexChanged);
            // 
            // ReportSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 254);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Name = "ReportSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportSelector";
            this.Load += new System.EventHandler(this.ReportSelector_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBBooster.ResumeLayout(false);
            this.GBBooster.PerformLayout();
            this.GBFinisher.ResumeLayout(false);
            this.GBFinisher.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DtpExactDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnReportView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbArea;
        private System.Windows.Forms.RadioButton RBMainFinisher;
        private System.Windows.Forms.RadioButton RBMainBoost;
        private System.Windows.Forms.GroupBox GBBooster;
        private System.Windows.Forms.RadioButton RBSubW3;
        private System.Windows.Forms.RadioButton RBSubW2;
        private System.Windows.Forms.RadioButton RBSubW1;
        private System.Windows.Forms.GroupBox GBFinisher;
        private System.Windows.Forms.RadioButton RBSubW5;
        private System.Windows.Forms.RadioButton RBSubW4;
    }
}