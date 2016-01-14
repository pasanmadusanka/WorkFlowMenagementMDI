namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    partial class SaveWeeklyPhysicalStk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveWeeklyPhysicalStk));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DgvFuelStock = new System.Windows.Forms.DataGridView();
            this.LblId = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtMeterCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LBLAvalable_Stock = new System.Windows.Forms.Label();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnPrintReport = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.TxtPhysicalStock = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuelStock)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(468, 49);
            this.panel3.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(37, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(388, 26);
            this.label7.TabIndex = 30;
            this.label7.Text = "Add Physical Stock Weediyawaththa";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 345);
            this.panel1.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DgvFuelStock);
            this.groupBox1.Controls.Add(this.LblId);
            this.groupBox1.Location = new System.Drawing.Point(3, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 226);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuel Weekly Physical Stock Weediyawaththa";
            // 
            // DgvFuelStock
            // 
            this.DgvFuelStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFuelStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFuelStock.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvFuelStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFuelStock.Location = new System.Drawing.Point(9, 19);
            this.DgvFuelStock.Name = "DgvFuelStock";
            this.DgvFuelStock.Size = new System.Drawing.Size(439, 201);
            this.DgvFuelStock.TabIndex = 38;
            this.DgvFuelStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFuelStock_CellClick);
            this.DgvFuelStock.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.DgvFuelStock_UserDeletingRow);
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(231, 3);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(10, 13);
            this.LblId.TabIndex = 48;
            this.LblId.Text = ".";
            this.LblId.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.TxtMeterCount);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.LBLAvalable_Stock);
            this.panel2.Controls.Add(this.BtnUpdate);
            this.panel2.Controls.Add(this.BtnPrintReport);
            this.panel2.Controls.Add(this.BtnSave);
            this.panel2.Controls.Add(this.BtnClose);
            this.panel2.Controls.Add(this.TxtPhysicalStock);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(8, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 85);
            this.panel2.TabIndex = 47;
            // 
            // TxtMeterCount
            // 
            this.TxtMeterCount.Location = new System.Drawing.Point(93, 47);
            this.TxtMeterCount.Name = "TxtMeterCount";
            this.TxtMeterCount.Size = new System.Drawing.Size(119, 20);
            this.TxtMeterCount.TabIndex = 51;
            this.TxtMeterCount.TextChanged += new System.EventHandler(this.TxtMeterCount_TextChanged);
            this.TxtMeterCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtMeterCount_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Meter Value :";
            // 
            // LBLAvalable_Stock
            // 
            this.LBLAvalable_Stock.AutoSize = true;
            this.LBLAvalable_Stock.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLAvalable_Stock.Location = new System.Drawing.Point(296, 55);
            this.LBLAvalable_Stock.Name = "LBLAvalable_Stock";
            this.LBLAvalable_Stock.Size = new System.Drawing.Size(10, 15);
            this.LBLAvalable_Stock.TabIndex = 49;
            this.LBLAvalable_Stock.Text = ".";
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.White;
            this.BtnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("BtnUpdate.Image")));
            this.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdate.Location = new System.Drawing.Point(297, 2);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(67, 35);
            this.BtnUpdate.TabIndex = 47;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnPrintReport
            // 
            this.BtnPrintReport.BackColor = System.Drawing.Color.White;
            this.BtnPrintReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrintReport.Image")));
            this.BtnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrintReport.Location = new System.Drawing.Point(222, 44);
            this.BtnPrintReport.Name = "BtnPrintReport";
            this.BtnPrintReport.Size = new System.Drawing.Size(67, 34);
            this.BtnPrintReport.TabIndex = 48;
            this.BtnPrintReport.Text = "Print";
            this.BtnPrintReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrintReport.UseVisualStyleBackColor = false;
            this.BtnPrintReport.Click += new System.EventHandler(this.BtnPrintReport_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(222, 2);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(67, 35);
            this.BtnSave.TabIndex = 45;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.White;
            this.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClose.Image = ((System.Drawing.Image)(resources.GetObject("BtnClose.Image")));
            this.BtnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClose.Location = new System.Drawing.Point(372, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(67, 35);
            this.BtnClose.TabIndex = 46;
            this.BtnClose.Text = "Close";
            this.BtnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // TxtPhysicalStock
            // 
            this.TxtPhysicalStock.Location = new System.Drawing.Point(93, 9);
            this.TxtPhysicalStock.Name = "TxtPhysicalStock";
            this.TxtPhysicalStock.Size = new System.Drawing.Size(119, 20);
            this.TxtPhysicalStock.TabIndex = 44;
            this.TxtPhysicalStock.TextChanged += new System.EventHandler(this.TxtPhysicalStock_TextChanged);
            this.TxtPhysicalStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPhysicalStock_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Physical Stock :";
            // 
            // SaveWeeklyPhysicalStk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(492, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(508, 454);
            this.MinimumSize = new System.Drawing.Size(508, 454);
            this.Name = "SaveWeeklyPhysicalStk";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Physical Stock Weediyawaththa";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SaveWeeklyPhysicalStk_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuelStock)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgvFuelStock;
        private System.Windows.Forms.TextBox TxtPhysicalStock;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.Button BtnPrintReport;
        private System.Windows.Forms.Label LBLAvalable_Stock;
        private System.Windows.Forms.TextBox TxtMeterCount;
        private System.Windows.Forms.Label label1;
    }
}