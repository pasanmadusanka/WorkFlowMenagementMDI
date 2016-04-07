namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    partial class WIPReportSelector
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
            this.CmbFieldOfficer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnReportView = new System.Windows.Forms.Button();
            this.RBSingleFO = new System.Windows.Forms.RadioButton();
            this.RbAllFO = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbFieldOfficer
            // 
            this.CmbFieldOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFieldOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFieldOfficer.Enabled = false;
            this.CmbFieldOfficer.FormattingEnabled = true;
            this.CmbFieldOfficer.Location = new System.Drawing.Point(77, 48);
            this.CmbFieldOfficer.Name = "CmbFieldOfficer";
            this.CmbFieldOfficer.Size = new System.Drawing.Size(193, 21);
            this.CmbFieldOfficer.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Field Officer :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.BtnReportView);
            this.groupBox1.Controls.Add(this.CmbFieldOfficer);
            this.groupBox1.Controls.Add(this.RBSingleFO);
            this.groupBox1.Controls.Add(this.RbAllFO);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(2, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 110);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Itinerary Plan";
            // 
            // BtnReportView
            // 
            this.BtnReportView.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnReportView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportView.Location = new System.Drawing.Point(94, 72);
            this.BtnReportView.Name = "BtnReportView";
            this.BtnReportView.Size = new System.Drawing.Size(94, 32);
            this.BtnReportView.TabIndex = 22;
            this.BtnReportView.Text = "Get Report";
            this.BtnReportView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportView.UseVisualStyleBackColor = true;
            this.BtnReportView.Click += new System.EventHandler(this.BtnReportView_Click);
            // 
            // RBSingleFO
            // 
            this.RBSingleFO.AutoSize = true;
            this.RBSingleFO.Location = new System.Drawing.Point(147, 19);
            this.RBSingleFO.Name = "RBSingleFO";
            this.RBSingleFO.Size = new System.Drawing.Size(113, 17);
            this.RBSingleFO.TabIndex = 21;
            this.RBSingleFO.Text = "Singel Field Officer";
            this.RBSingleFO.UseVisualStyleBackColor = true;
            this.RBSingleFO.CheckedChanged += new System.EventHandler(this.RBSingleFO_CheckedChanged);
            // 
            // RbAllFO
            // 
            this.RbAllFO.AutoSize = true;
            this.RbAllFO.Checked = true;
            this.RbAllFO.Location = new System.Drawing.Point(29, 19);
            this.RbAllFO.Name = "RbAllFO";
            this.RbAllFO.Size = new System.Drawing.Size(100, 17);
            this.RbAllFO.TabIndex = 20;
            this.RbAllFO.TabStop = true;
            this.RbAllFO.Text = "All Field Officers";
            this.RbAllFO.UseVisualStyleBackColor = true;
            this.RbAllFO.CheckedChanged += new System.EventHandler(this.RbAllFO_CheckedChanged);
            // 
            // WIPReportSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 124);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 163);
            this.MinimumSize = new System.Drawing.Size(300, 163);
            this.Name = "WIPReportSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIP Selector";
            this.Load += new System.EventHandler(this.WIPReportSelector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbFieldOfficer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBSingleFO;
        private System.Windows.Forms.RadioButton RbAllFO;
        private System.Windows.Forms.Button BtnReportView;
    }
}