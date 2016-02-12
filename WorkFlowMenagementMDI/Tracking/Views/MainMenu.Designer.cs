namespace WorkFlowMenagementMDI.Tracking.Views
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.BtnCusAreaRouts = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnFieldVisits = new System.Windows.Forms.Button();
            this.BtnFarmersLoc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 96);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WorkFlowMenagementMDI.Properties.Resources.DELMO_LOGO21;
            this.pictureBox1.Location = new System.Drawing.Point(12, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delmo GPS Tracking and Navigation System for \r\n                     Farmers and C" +
    "onsumers ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.BtnCusAreaRouts);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.BtnFieldVisits);
            this.panel2.Controls.Add(this.BtnFarmersLoc);
            this.panel2.Location = new System.Drawing.Point(12, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 342);
            this.panel2.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button5.BackgroundImage")));
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(425, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(135, 135);
            this.button5.TabIndex = 4;
            this.button5.Text = "Upload Details of Parking";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BtnCusAreaRouts
            // 
            this.BtnCusAreaRouts.BackgroundImage = global::WorkFlowMenagementMDI.Properties.Resources.CustomerLocs;
            this.BtnCusAreaRouts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCusAreaRouts.Location = new System.Drawing.Point(37, 184);
            this.BtnCusAreaRouts.Name = "BtnCusAreaRouts";
            this.BtnCusAreaRouts.Size = new System.Drawing.Size(135, 135);
            this.BtnCusAreaRouts.TabIndex = 3;
            this.BtnCusAreaRouts.Text = "Agents Routs";
            this.BtnCusAreaRouts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCusAreaRouts.UseVisualStyleBackColor = true;
            this.BtnCusAreaRouts.Click += new System.EventHandler(this.BtnCusAreaRouts_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(425, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 135);
            this.button3.TabIndex = 2;
            this.button3.Text = "Customer Loacations";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // BtnFieldVisits
            // 
            this.BtnFieldVisits.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnFieldVisits.BackgroundImage")));
            this.BtnFieldVisits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFieldVisits.Location = new System.Drawing.Point(231, 14);
            this.BtnFieldVisits.Name = "BtnFieldVisits";
            this.BtnFieldVisits.Size = new System.Drawing.Size(135, 135);
            this.BtnFieldVisits.TabIndex = 1;
            this.BtnFieldVisits.Text = "Feild Visits";
            this.BtnFieldVisits.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnFieldVisits.UseVisualStyleBackColor = true;
            this.BtnFieldVisits.Click += new System.EventHandler(this.BtnFieldVisits_Click);
            // 
            // BtnFarmersLoc
            // 
            this.BtnFarmersLoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnFarmersLoc.BackgroundImage")));
            this.BtnFarmersLoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnFarmersLoc.Location = new System.Drawing.Point(37, 14);
            this.BtnFarmersLoc.Name = "BtnFarmersLoc";
            this.BtnFarmersLoc.Size = new System.Drawing.Size(135, 135);
            this.BtnFarmersLoc.TabIndex = 0;
            this.BtnFarmersLoc.Text = "Farmers Locations";
            this.BtnFarmersLoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnFarmersLoc.UseVisualStyleBackColor = true;
            this.BtnFarmersLoc.Click += new System.EventHandler(this.BtnFarmersLoc_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(641, 507);
            this.MinimumSize = new System.Drawing.Size(641, 507);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnCusAreaRouts;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtnFieldVisits;
        private System.Windows.Forms.Button BtnFarmersLoc;
        private System.Windows.Forms.Button button5;
    }
}