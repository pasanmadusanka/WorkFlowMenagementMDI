namespace WorkFlowMenagementMDI.FuelApp.Views
{
    partial class Admin_Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Controller));
            this.DgvAdmin = new System.Windows.Forms.DataGridView();
            this.BtnCreateNew = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblWelcom = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblUser = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.TWFuelDetails = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdmin)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvAdmin
            // 
            this.DgvAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvAdmin.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvAdmin.ColumnHeadersHeight = 40;
            this.DgvAdmin.Location = new System.Drawing.Point(3, 58);
            this.DgvAdmin.Name = "DgvAdmin";
            this.DgvAdmin.Size = new System.Drawing.Size(676, 307);
            this.DgvAdmin.TabIndex = 37;
            this.DgvAdmin.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvAdmin_CellDoubleClick);
            this.DgvAdmin.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvAdmin_RowHeaderMouseDoubleClick);
            // 
            // BtnCreateNew
            // 
            this.BtnCreateNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnCreateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCreateNew.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreateNew.Image")));
            this.BtnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCreateNew.Location = new System.Drawing.Point(12, 5);
            this.BtnCreateNew.Name = "BtnCreateNew";
            this.BtnCreateNew.Size = new System.Drawing.Size(95, 34);
            this.BtnCreateNew.TabIndex = 38;
            this.BtnCreateNew.Text = "Create New";
            this.BtnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCreateNew.UseVisualStyleBackColor = true;
            this.BtnCreateNew.Click += new System.EventHandler(this.BtnCreateNew_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.LblWelcom);
            this.panel3.Controls.Add(this.BtnCreateNew);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(676, 49);
            this.panel3.TabIndex = 43;
            // 
            // LblWelcom
            // 
            this.LblWelcom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LblWelcom.AutoSize = true;
            this.LblWelcom.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWelcom.Location = new System.Drawing.Point(258, 9);
            this.LblWelcom.Name = "LblWelcom";
            this.LblWelcom.Size = new System.Drawing.Size(17, 23);
            this.LblWelcom.TabIndex = 40;
            this.LblWelcom.Text = ".";
            this.LblWelcom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.DgvAdmin);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Location = new System.Drawing.Point(190, 104);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(688, 372);
            this.panel5.TabIndex = 49;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.LblUser);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Location = new System.Drawing.Point(190, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(688, 87);
            this.panel4.TabIndex = 50;
            // 
            // LblUser
            // 
            this.LblUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUser.AutoSize = true;
            this.LblUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUser.Location = new System.Drawing.Point(540, 12);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(11, 16);
            this.LblUser.TabIndex = 5;
            this.LblUser.Text = ".";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label12.Location = new System.Drawing.Point(481, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 28);
            this.label12.TabIndex = 4;
            this.label12.Text = "User :";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(141, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(394, 26);
            this.label13.TabIndex = 3;
            this.label13.Text = "Delmo Chicken && Agro (pvt) Limited";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.Control;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.label14);
            this.panel6.Location = new System.Drawing.Point(3, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(676, 40);
            this.panel6.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(201, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(292, 24);
            this.label14.TabIndex = 0;
            this.label14.Text = "Weediyawaththa Fuel Details ©";
            // 
            // TWFuelDetails
            // 
            this.TWFuelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TWFuelDetails.Location = new System.Drawing.Point(12, 12);
            this.TWFuelDetails.Name = "TWFuelDetails";
            this.TWFuelDetails.Size = new System.Drawing.Size(172, 459);
            this.TWFuelDetails.TabIndex = 51;
            this.TWFuelDetails.DoubleClick += new System.EventHandler(this.TWFuelDetails_DoubleClick);
            this.TWFuelDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TWFuelDetails_KeyDown);
            // 
            // Admin_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(887, 489);
            this.Controls.Add(this.TWFuelDetails);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin_Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Controller";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Admin_Controller_FormClosed);
            this.Load += new System.EventHandler(this.Admin_Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAdmin)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvAdmin;
        private System.Windows.Forms.Button BtnCreateNew;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblWelcom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TreeView TWFuelDetails;
    }
}