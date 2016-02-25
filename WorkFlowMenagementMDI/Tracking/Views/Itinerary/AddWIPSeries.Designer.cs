using System.Windows.Forms;
namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    partial class AddWIPSeries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddWIPSeries));
            this.label1 = new System.Windows.Forms.Label();
            this.TxtWIPCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpPlanFrmDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Itinerary Plan (WIP) :";
            // 
            // TxtWIPCode
            // 
            this.TxtWIPCode.Location = new System.Drawing.Point(126, 9);
            this.TxtWIPCode.Name = "TxtWIPCode";
            this.TxtWIPCode.Size = new System.Drawing.Size(64, 20);
            this.TxtWIPCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Plan Date  From:";
            // 
            // DtpPlanFrmDate
            // 
            this.DtpPlanFrmDate.CustomFormat = "dd/MMMM/yyyy";
            this.DtpPlanFrmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpPlanFrmDate.Location = new System.Drawing.Point(126, 41);
            this.DtpPlanFrmDate.Name = "DtpPlanFrmDate";
            this.DtpPlanFrmDate.Size = new System.Drawing.Size(134, 20);
            this.DtpPlanFrmDate.TabIndex = 7;
            this.DtpPlanFrmDate.ValueChanged += new System.EventHandler(this.DtpPlanFrmDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Plan Date To :";
            // 
            // DtpPlanToDate
            // 
            this.DtpPlanToDate.CustomFormat = "dd/MMMM/yyyy";
            this.DtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpPlanToDate.Location = new System.Drawing.Point(126, 70);
            this.DtpPlanToDate.Name = "DtpPlanToDate";
            this.DtpPlanToDate.Size = new System.Drawing.Size(134, 20);
            this.DtpPlanToDate.TabIndex = 9;
            this.DtpPlanToDate.Value = new System.DateTime(2016, 2, 20, 12, 27, 37, 788);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.White;
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Image")));
            this.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdd.Location = new System.Drawing.Point(115, 96);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(68, 30);
            this.BtnAdd.TabIndex = 15;
            this.BtnAdd.Text = "Create";
            this.BtnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // AddWIPSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 129);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtpPlanToDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpPlanFrmDate);
            this.Controls.Add(this.TxtWIPCode);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddWIPSeries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add WIP Series";
            this.Load += new System.EventHandler(this.AddWIPSeries_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtWIPCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpPlanFrmDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpPlanToDate;
        private System.Windows.Forms.Button BtnAdd;
    }
}