namespace WorkFlowMenagementMDI.Admin.Views
{
    partial class AdminDeteteParkingData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFroRadioGroup = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RBFarmer = new System.Windows.Forms.RadioButton();
            this.RBCustomer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.CmbFrmDate = new System.Windows.Forms.ComboBox();
            this.CmbToDate = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 76);
            this.panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(107, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(228, 27);
            this.label4.TabIndex = 0;
            this.label4.Text = "Delete Parking Details";
            // 
            // lblFroRadioGroup
            // 
            this.lblFroRadioGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFroRadioGroup.AutoSize = true;
            this.lblFroRadioGroup.Location = new System.Drawing.Point(12, 98);
            this.lblFroRadioGroup.Name = "lblFroRadioGroup";
            this.lblFroRadioGroup.Size = new System.Drawing.Size(184, 13);
            this.lblFroRadioGroup.TabIndex = 18;
            this.lblFroRadioGroup.Text = "Customer Visitation/Farmer Visitation :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBFarmer);
            this.groupBox2.Controls.Add(this.RBCustomer);
            this.groupBox2.Location = new System.Drawing.Point(202, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 33);
            this.groupBox2.TabIndex = 17;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "To Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "From Date :";
            // 
            // BtnDelete
            // 
            this.BtnDelete.Location = new System.Drawing.Point(412, 131);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 23);
            this.BtnDelete.TabIndex = 23;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = true;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // CmbFrmDate
            // 
            this.CmbFrmDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFrmDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFrmDate.FormattingEnabled = true;
            this.CmbFrmDate.Location = new System.Drawing.Point(79, 132);
            this.CmbFrmDate.Name = "CmbFrmDate";
            this.CmbFrmDate.Size = new System.Drawing.Size(121, 21);
            this.CmbFrmDate.TabIndex = 24;
            this.CmbFrmDate.SelectedIndexChanged += new System.EventHandler(this.CmbFrmDate_SelectedIndexChanged);
            // 
            // CmbToDate
            // 
            this.CmbToDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbToDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbToDate.FormattingEnabled = true;
            this.CmbToDate.Location = new System.Drawing.Point(276, 132);
            this.CmbToDate.Name = "CmbToDate";
            this.CmbToDate.Size = new System.Drawing.Size(121, 21);
            this.CmbToDate.TabIndex = 25;
            // 
            // AdminDeteteParkingData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 169);
            this.Controls.Add(this.CmbToDate);
            this.Controls.Add(this.CmbFrmDate);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFroRadioGroup);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminDeteteParkingData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detete Parking Data";
            this.Load += new System.EventHandler(this.AdminDeteteParkingData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFroRadioGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBFarmer;
        private System.Windows.Forms.RadioButton RBCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ComboBox CmbFrmDate;
        private System.Windows.Forms.ComboBox CmbToDate;
    }
}