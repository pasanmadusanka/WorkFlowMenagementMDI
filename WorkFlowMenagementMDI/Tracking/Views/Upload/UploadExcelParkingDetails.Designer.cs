namespace WorkFlowMenagementMDI.Tracking.Views.Upload
{
    partial class UploadExcelParkingDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadExcelParkingDetails));
            this.BtnInsert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbHeaderYes = new System.Windows.Forms.RadioButton();
            this.rbHeaderNo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.DgvUploads = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblSeleRb = new System.Windows.Forms.Label();
            this.lblFroRadioGroup = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBFarmer = new System.Windows.Forms.RadioButton();
            this.RBCustomer = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUploads)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnInsert
            // 
            this.BtnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInsert.Image = global::WorkFlowMenagementMDI.Properties.Resources.upload1;
            this.BtnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnInsert.Location = new System.Drawing.Point(782, 337);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(77, 34);
            this.BtnInsert.TabIndex = 15;
            this.BtnInsert.Text = "Upload";
            this.BtnInsert.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInsert.UseVisualStyleBackColor = true;
            this.BtnInsert.Click += new System.EventHandler(this.BtnInsert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbHeaderYes);
            this.groupBox1.Controls.Add(this.rbHeaderNo);
            this.groupBox1.Location = new System.Drawing.Point(145, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(93, 33);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // rbHeaderYes
            // 
            this.rbHeaderYes.AutoSize = true;
            this.rbHeaderYes.Checked = true;
            this.rbHeaderYes.Location = new System.Drawing.Point(6, 11);
            this.rbHeaderYes.Name = "rbHeaderYes";
            this.rbHeaderYes.Size = new System.Drawing.Size(43, 17);
            this.rbHeaderYes.TabIndex = 7;
            this.rbHeaderYes.TabStop = true;
            this.rbHeaderYes.Text = "Yes";
            this.rbHeaderYes.UseVisualStyleBackColor = true;
            // 
            // rbHeaderNo
            // 
            this.rbHeaderNo.Location = new System.Drawing.Point(50, 11);
            this.rbHeaderNo.Name = "rbHeaderNo";
            this.rbHeaderNo.Size = new System.Drawing.Size(42, 17);
            this.rbHeaderNo.TabIndex = 6;
            this.rbHeaderNo.Text = "No";
            this.rbHeaderNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Header";
            // 
            // btnSelect
            // 
            this.btnSelect.Image = global::WorkFlowMenagementMDI.Properties.Resources._1393431532_Excel_D;
            this.btnSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelect.Location = new System.Drawing.Point(11, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 33);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Import";
            this.btnSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // DgvUploads
            // 
            this.DgvUploads.AllowUserToAddRows = false;
            this.DgvUploads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvUploads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvUploads.BackgroundColor = System.Drawing.Color.White;
            this.DgvUploads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvUploads.Location = new System.Drawing.Point(12, 137);
            this.DgvUploads.Name = "DgvUploads";
            this.DgvUploads.Size = new System.Drawing.Size(852, 194);
            this.DgvUploads.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Excel Files|*.xls;*.xlsx";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
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
            this.panel3.Size = new System.Drawing.Size(852, 61);
            this.panel3.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(304, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(267, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Upload Field Visits Details";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.LblSeleRb);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lblFroRadioGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 52);
            this.panel1.TabIndex = 17;
            // 
            // LblSeleRb
            // 
            this.LblSeleRb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LblSeleRb.AutoSize = true;
            this.LblSeleRb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSeleRb.Location = new System.Drawing.Point(243, 16);
            this.LblSeleRb.Name = "LblSeleRb";
            this.LblSeleRb.Size = new System.Drawing.Size(222, 19);
            this.LblSeleRb.TabIndex = 17;
            this.LblSeleRb.Text = "Field Officer Visitation Selected";
            // 
            // lblFroRadioGroup
            // 
            this.lblFroRadioGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFroRadioGroup.AutoSize = true;
            this.lblFroRadioGroup.Location = new System.Drawing.Point(495, 18);
            this.lblFroRadioGroup.Name = "lblFroRadioGroup";
            this.lblFroRadioGroup.Size = new System.Drawing.Size(184, 13);
            this.lblFroRadioGroup.TabIndex = 16;
            this.lblFroRadioGroup.Text = "Customer Visitation/Farmer Visitation :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.RBFarmer);
            this.groupBox2.Controls.Add(this.RBCustomer);
            this.groupBox2.Location = new System.Drawing.Point(685, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 33);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // RBFarmer
            // 
            this.RBFarmer.AutoSize = true;
            this.RBFarmer.Checked = true;
            this.RBFarmer.Location = new System.Drawing.Point(6, 11);
            this.RBFarmer.Name = "RBFarmer";
            this.RBFarmer.Size = new System.Drawing.Size(57, 17);
            this.RBFarmer.TabIndex = 7;
            this.RBFarmer.TabStop = true;
            this.RBFarmer.Text = "Farmer";
            this.RBFarmer.UseVisualStyleBackColor = true;
            this.RBFarmer.CheckedChanged += new System.EventHandler(this.RBFarmer_CheckedChanged);
            // 
            // RBCustomer
            // 
            this.RBCustomer.Location = new System.Drawing.Point(74, 12);
            this.RBCustomer.Name = "RBCustomer";
            this.RBCustomer.Size = new System.Drawing.Size(71, 16);
            this.RBCustomer.TabIndex = 6;
            this.RBCustomer.Text = "Customer";
            this.RBCustomer.UseVisualStyleBackColor = true;
            this.RBCustomer.CheckedChanged += new System.EventHandler(this.RBCustomer_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 348);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = ".";
            // 
            // UploadExcelParkingDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 383);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.DgvUploads);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadExcelParkingDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Excel Sheets";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UploadExcelParkingDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvUploads)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbHeaderYes;
        private System.Windows.Forms.RadioButton rbHeaderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView DgvUploads;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFroRadioGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBFarmer;
        private System.Windows.Forms.RadioButton RBCustomer;
        private System.Windows.Forms.Label LblSeleRb;
    }
}

