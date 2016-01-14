using System.Windows.Forms;
namespace WorkFlowMenagementMDI.FuelApp.Views.Reports
{
    partial class DateSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateSelection));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.DTPToDate);
            this.panel1.Controls.Add(this.BtnSubmit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DTPFromDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 67);
            this.panel1.TabIndex = 3;
            // 
            // DTPToDate
            // 
            this.DTPToDate.CustomFormat = "dd/MM/yyyy";
            this.DTPToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPToDate.Location = new System.Drawing.Point(75, 29);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(113, 20);
            this.DTPToDate.TabIndex = 3;
            this.DTPToDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPToDate_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "To Date :";
            // 
            // DTPFromDate
            // 
            this.DTPFromDate.CustomFormat = "dd/MM/yyyy";
            this.DTPFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPFromDate.Location = new System.Drawing.Point(75, 3);
            this.DTPFromDate.Name = "DTPFromDate";
            this.DTPFromDate.Size = new System.Drawing.Size(113, 20);
            this.DTPFromDate.TabIndex = 1;
            this.DTPFromDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DTPFromDate_KeyDown);
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblHeader.Location = new System.Drawing.Point(56, 11);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(193, 24);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "General Fuel Report";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(7, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.BackColor = System.Drawing.Color.White;
            this.BtnSubmit.Image = global::WorkFlowMenagementMDI.Properties.Resources.print;
            this.BtnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmit.Location = new System.Drawing.Point(194, 16);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(74, 33);
            this.BtnSubmit.TabIndex = 4;
            this.BtnSubmit.Text = "Print";
            this.BtnSubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSubmit.UseVisualStyleBackColor = false;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblHeader);
            this.panel2.Location = new System.Drawing.Point(9, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 46);
            this.panel2.TabIndex = 6;
            // 
            // DateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 125);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 164);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 164);
            this.Name = "DateSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Date Selection";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DateSelection_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DTPFromDate;
        private System.Windows.Forms.Label lblHeader;
        private PictureBox pictureBox1;
        private Panel panel2;
    }
}