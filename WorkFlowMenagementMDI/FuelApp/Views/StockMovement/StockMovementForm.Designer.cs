namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    partial class StockMovementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMovementForm));
            this.DgvFuelStock = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CmbDates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblAvalableStk = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnPrintReport = new System.Windows.Forms.Button();
            this.DTPToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuelStock)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.DgvFuelStock.Size = new System.Drawing.Size(782, 194);
            this.DgvFuelStock.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DgvFuelStock);
            this.groupBox1.Location = new System.Drawing.Point(16, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 219);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuel Stock Movement Weediyawaththa";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(221, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(383, 24);
            this.label14.TabIndex = 40;
            this.label14.Text = "Weediyawaththa Fuel Stock Movement ©";
            // 
            // CmbDates
            // 
            this.CmbDates.FormattingEnabled = true;
            this.CmbDates.Location = new System.Drawing.Point(95, 48);
            this.CmbDates.Name = "CmbDates";
            this.CmbDates.Size = new System.Drawing.Size(121, 21);
            this.CmbDates.TabIndex = 43;
            this.CmbDates.SelectedIndexChanged += new System.EventHandler(this.CmbDates_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "From Date :";
            // 
            // LblAvalableStk
            // 
            this.LblAvalableStk.AutoSize = true;
            this.LblAvalableStk.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAvalableStk.Location = new System.Drawing.Point(442, 86);
            this.LblAvalableStk.Name = "LblAvalableStk";
            this.LblAvalableStk.Size = new System.Drawing.Size(15, 21);
            this.LblAvalableStk.TabIndex = 45;
            this.LblAvalableStk.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "Avalable Fuel Stock :";
            // 
            // BtnPrintReport
            // 
            this.BtnPrintReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrintReport.Image")));
            this.BtnPrintReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrintReport.Location = new System.Drawing.Point(732, 76);
            this.BtnPrintReport.Name = "BtnPrintReport";
            this.BtnPrintReport.Size = new System.Drawing.Size(75, 34);
            this.BtnPrintReport.TabIndex = 47;
            this.BtnPrintReport.Text = "Print";
            this.BtnPrintReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrintReport.UseVisualStyleBackColor = true;
            this.BtnPrintReport.Click += new System.EventHandler(this.BtnPrintReport_Click);
            // 
            // DTPToDate
            // 
            this.DTPToDate.CustomFormat = "dd/MM/yyyy";
            this.DTPToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPToDate.Location = new System.Drawing.Point(95, 76);
            this.DTPToDate.Name = "DTPToDate";
            this.DTPToDate.Size = new System.Drawing.Size(121, 20);
            this.DTPToDate.TabIndex = 51;
            this.DTPToDate.ValueChanged += new System.EventHandler(this.DTPToDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "To Date :";
            // 
            // StockMovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 339);
            this.Controls.Add(this.DTPToDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnPrintReport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblAvalableStk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbDates);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(845, 378);
            this.MinimumSize = new System.Drawing.Size(845, 378);
            this.Name = "StockMovementForm";
            this.Text = "StockMovementForm";
            this.Load += new System.EventHandler(this.StockMovementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFuelStock)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFuelStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CmbDates;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblAvalableStk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnPrintReport;
        private System.Windows.Forms.DateTimePicker DTPToDate;
        private System.Windows.Forms.Label label3;
    }
}