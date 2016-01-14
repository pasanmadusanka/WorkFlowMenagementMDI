namespace WorkFlowMenagementMDI.FuelApp.Views
{
    partial class ReportGen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportGen));
            this.PnalPrint = new System.Windows.Forms.Panel();
            this.LblStartMeter = new System.Windows.Forms.Label();
            this.LblEndMeter = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.DgvFuel = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblfooter = new System.Windows.Forms.Label();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PnalPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuel)).BeginInit();
            this.SuspendLayout();
            // 
            // PnalPrint
            // 
            this.PnalPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnalPrint.Controls.Add(this.lblfooter);
            this.PnalPrint.Controls.Add(this.LblStartMeter);
            this.PnalPrint.Controls.Add(this.LblEndMeter);
            this.PnalPrint.Controls.Add(this.label2);
            this.PnalPrint.Controls.Add(this.LblDate);
            this.PnalPrint.Controls.Add(this.LblCompanyName);
            this.PnalPrint.Controls.Add(this.DgvFuel);
            this.PnalPrint.Location = new System.Drawing.Point(12, 5);
            this.PnalPrint.Name = "PnalPrint";
            this.PnalPrint.Size = new System.Drawing.Size(837, 400);
            this.PnalPrint.TabIndex = 0;
            // 
            // LblStartMeter
            // 
            this.LblStartMeter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblStartMeter.AutoSize = true;
            this.LblStartMeter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStartMeter.Location = new System.Drawing.Point(549, 89);
            this.LblStartMeter.Name = "LblStartMeter";
            this.LblStartMeter.Size = new System.Drawing.Size(13, 19);
            this.LblStartMeter.TabIndex = 8;
            this.LblStartMeter.Text = ".";
            // 
            // LblEndMeter
            // 
            this.LblEndMeter.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblEndMeter.AutoSize = true;
            this.LblEndMeter.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEndMeter.Location = new System.Drawing.Point(549, 335);
            this.LblEndMeter.Name = "LblEndMeter";
            this.LblEndMeter.Size = new System.Drawing.Size(13, 19);
            this.LblEndMeter.TabIndex = 7;
            this.LblEndMeter.Text = ".";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.Location = new System.Drawing.Point(51, 89);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(13, 19);
            this.LblDate.TabIndex = 5;
            this.LblDate.Text = ".";
            // 
            // DgvFuel
            // 
            this.DgvFuel.AllowUserToAddRows = false;
            this.DgvFuel.AllowUserToDeleteRows = false;
            this.DgvFuel.AllowUserToResizeColumns = false;
            this.DgvFuel.AllowUserToResizeRows = false;
            this.DgvFuel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFuel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvFuel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvFuel.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DgvFuel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvFuel.ColumnHeadersHeight = 40;
            this.DgvFuel.Location = new System.Drawing.Point(3, 118);
            this.DgvFuel.Name = "DgvFuel";
            this.DgvFuel.RowHeadersWidth = 10;
            this.DgvFuel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvFuel.Size = new System.Drawing.Size(826, 193);
            this.DgvFuel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(779, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // lblfooter
            // 
            this.lblfooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblfooter.AutoSize = true;
            this.lblfooter.Location = new System.Drawing.Point(174, 377);
            this.lblfooter.Name = "lblfooter";
            this.lblfooter.Size = new System.Drawing.Size(35, 13);
            this.lblfooter.TabIndex = 9;
            this.lblfooter.Text = "label1";
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblCompanyName.AutoSize = true;
            this.LblCompanyName.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCompanyName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblCompanyName.Location = new System.Drawing.Point(204, 6);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(450, 31);
            this.LblCompanyName.TabIndex = 4;
            this.LblCompanyName.Text = global::WorkFlowMenagementMDI.Properties.Settings.Default.CompanyName;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(365, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "FUEL PUMPING DETAILS - VEEDIWATTA";
            // 
            // ReportGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(853, 455);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PnalPrint);
            this.MaximumSize = new System.Drawing.Size(869, 650);
            this.MinimumSize = new System.Drawing.Size(869, 494);
            this.Name = "ReportGen";
            this.Text = "ReportGen";
            this.Load += new System.EventHandler(this.ReportGen_Load);
            this.PnalPrint.ResumeLayout(false);
            this.PnalPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnalPrint;
        private System.Windows.Forms.DataGridView DgvFuel;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblEndMeter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label LblStartMeter;
        private System.Windows.Forms.Label lblfooter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblCompanyName;

    }
}