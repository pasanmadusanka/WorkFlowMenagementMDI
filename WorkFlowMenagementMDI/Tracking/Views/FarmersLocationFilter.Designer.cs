namespace WorkFlowMenagementMDI.Tracking.Views
{
    partial class FarmersLocationFilter
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
            this.BtnGetLoca = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtLongi = new System.Windows.Forms.TextBox();
            this.TxtLati = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbFarmer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbDestiFarmer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOriginLat = new System.Windows.Forms.TextBox();
            this.txtOriginLong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDestiLat = new System.Windows.Forms.TextBox();
            this.txtDestiLongi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LblDistence = new System.Windows.Forms.Label();
            this.LblDuration = new System.Windows.Forms.Label();
            this.LblDestiAdd = new System.Windows.Forms.Label();
            this.LblOriginAdd = new System.Windows.Forms.Label();
            this.TxtBrows = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.BtnViewFarmers = new System.Windows.Forms.Button();
            this.BtnUploadDetails = new System.Windows.Forms.Button();
            this.BtnVisitDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGetLoca
            // 
            this.BtnGetLoca.Location = new System.Drawing.Point(277, 19);
            this.BtnGetLoca.Name = "BtnGetLoca";
            this.BtnGetLoca.Size = new System.Drawing.Size(87, 32);
            this.BtnGetLoca.TabIndex = 0;
            this.BtnGetLoca.Text = "Location";
            this.BtnGetLoca.UseVisualStyleBackColor = true;
            this.BtnGetLoca.Click += new System.EventHandler(this.BtnGetLoca_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Longitude ";
            // 
            // TxtLongi
            // 
            this.TxtLongi.Location = new System.Drawing.Point(126, 38);
            this.TxtLongi.Name = "TxtLongi";
            this.TxtLongi.Size = new System.Drawing.Size(100, 20);
            this.TxtLongi.TabIndex = 2;
            this.TxtLongi.Text = "80.040759\r\n";
            // 
            // TxtLati
            // 
            this.TxtLati.Location = new System.Drawing.Point(126, 12);
            this.TxtLati.Name = "TxtLati";
            this.TxtLati.Size = new System.Drawing.Size(100, 20);
            this.TxtLati.TabIndex = 3;
            this.TxtLati.Text = "7.280288";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latitude ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // LblLocation
            // 
            this.LblLocation.Location = new System.Drawing.Point(32, 83);
            this.LblLocation.Multiline = true;
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(430, 64);
            this.LblLocation.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(382, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Get Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbFarmer
            // 
            this.CmbFarmer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFarmer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFarmer.FormattingEnabled = true;
            this.CmbFarmer.Location = new System.Drawing.Point(96, 153);
            this.CmbFarmer.Name = "CmbFarmer";
            this.CmbFarmer.Size = new System.Drawing.Size(121, 21);
            this.CmbFarmer.TabIndex = 8;
            this.CmbFarmer.SelectedIndexChanged += new System.EventHandler(this.CmbFarmer_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Origin Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Destination Location:";
            // 
            // CmbDestiFarmer
            // 
            this.CmbDestiFarmer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbDestiFarmer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbDestiFarmer.FormattingEnabled = true;
            this.CmbDestiFarmer.Location = new System.Drawing.Point(350, 153);
            this.CmbDestiFarmer.Name = "CmbDestiFarmer";
            this.CmbDestiFarmer.Size = new System.Drawing.Size(121, 21);
            this.CmbDestiFarmer.TabIndex = 10;
            this.CmbDestiFarmer.SelectedIndexChanged += new System.EventHandler(this.CmbDestiFarmer_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Latitude ";
            // 
            // txtOriginLat
            // 
            this.txtOriginLat.Location = new System.Drawing.Point(117, 180);
            this.txtOriginLat.Name = "txtOriginLat";
            this.txtOriginLat.Size = new System.Drawing.Size(100, 20);
            this.txtOriginLat.TabIndex = 14;
            this.txtOriginLat.Text = "7.280288";
            // 
            // txtOriginLong
            // 
            this.txtOriginLong.Location = new System.Drawing.Point(117, 206);
            this.txtOriginLong.Name = "txtOriginLong";
            this.txtOriginLong.Size = new System.Drawing.Size(100, 20);
            this.txtOriginLong.TabIndex = 13;
            this.txtOriginLong.Text = "80.040759";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Longitude ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(274, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Latitude ";
            // 
            // txtDestiLat
            // 
            this.txtDestiLat.Location = new System.Drawing.Point(371, 180);
            this.txtDestiLat.Name = "txtDestiLat";
            this.txtDestiLat.Size = new System.Drawing.Size(100, 20);
            this.txtDestiLat.TabIndex = 18;
            this.txtDestiLat.Text = "6.9218366";
            // 
            // txtDestiLongi
            // 
            this.txtDestiLongi.Location = new System.Drawing.Point(371, 206);
            this.txtDestiLongi.Name = "txtDestiLongi";
            this.txtDestiLongi.Size = new System.Drawing.Size(100, 20);
            this.txtDestiLongi.TabIndex = 17;
            this.txtDestiLongi.Text = "79.8562055";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(274, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Longitude ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 241);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Origin Address :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Destination Address :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 293);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Duration :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 319);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Distance :";
            // 
            // LblDistence
            // 
            this.LblDistence.AutoSize = true;
            this.LblDistence.Location = new System.Drawing.Point(114, 319);
            this.LblDistence.Name = "LblDistence";
            this.LblDistence.Size = new System.Drawing.Size(10, 13);
            this.LblDistence.TabIndex = 27;
            this.LblDistence.Text = ".";
            // 
            // LblDuration
            // 
            this.LblDuration.AutoSize = true;
            this.LblDuration.Location = new System.Drawing.Point(114, 293);
            this.LblDuration.Name = "LblDuration";
            this.LblDuration.Size = new System.Drawing.Size(10, 13);
            this.LblDuration.TabIndex = 26;
            this.LblDuration.Text = ".";
            // 
            // LblDestiAdd
            // 
            this.LblDestiAdd.AutoSize = true;
            this.LblDestiAdd.Location = new System.Drawing.Point(114, 267);
            this.LblDestiAdd.Name = "LblDestiAdd";
            this.LblDestiAdd.Size = new System.Drawing.Size(10, 13);
            this.LblDestiAdd.TabIndex = 25;
            this.LblDestiAdd.Text = ".";
            // 
            // LblOriginAdd
            // 
            this.LblOriginAdd.AutoSize = true;
            this.LblOriginAdd.Location = new System.Drawing.Point(114, 241);
            this.LblOriginAdd.Name = "LblOriginAdd";
            this.LblOriginAdd.Size = new System.Drawing.Size(10, 13);
            this.LblOriginAdd.TabIndex = 24;
            this.LblOriginAdd.Text = ".";
            // 
            // TxtBrows
            // 
            this.TxtBrows.Location = new System.Drawing.Point(383, 19);
            this.TxtBrows.Name = "TxtBrows";
            this.TxtBrows.Size = new System.Drawing.Size(87, 32);
            this.TxtBrows.TabIndex = 28;
            this.TxtBrows.Text = "Web Location";
            this.TxtBrows.UseVisualStyleBackColor = true;
            this.TxtBrows.Click += new System.EventHandler(this.TxtBrows_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(492, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(508, 362);
            this.webBrowser1.TabIndex = 29;
            // 
            // BtnViewFarmers
            // 
            this.BtnViewFarmers.Location = new System.Drawing.Point(382, 267);
            this.BtnViewFarmers.Name = "BtnViewFarmers";
            this.BtnViewFarmers.Size = new System.Drawing.Size(88, 33);
            this.BtnViewFarmers.TabIndex = 30;
            this.BtnViewFarmers.Text = "Farmers Map";
            this.BtnViewFarmers.UseVisualStyleBackColor = true;
            this.BtnViewFarmers.Click += new System.EventHandler(this.BtnViewFarmers_Click);
            // 
            // BtnUploadDetails
            // 
            this.BtnUploadDetails.Location = new System.Drawing.Point(382, 305);
            this.BtnUploadDetails.Name = "BtnUploadDetails";
            this.BtnUploadDetails.Size = new System.Drawing.Size(88, 33);
            this.BtnUploadDetails.TabIndex = 31;
            this.BtnUploadDetails.Text = "Upload Parking";
            this.BtnUploadDetails.UseVisualStyleBackColor = true;
            this.BtnUploadDetails.Click += new System.EventHandler(this.BtnUploadDetails_Click);
            // 
            // BtnVisitDetails
            // 
            this.BtnVisitDetails.Location = new System.Drawing.Point(382, 341);
            this.BtnVisitDetails.Name = "BtnVisitDetails";
            this.BtnVisitDetails.Size = new System.Drawing.Size(88, 33);
            this.BtnVisitDetails.TabIndex = 32;
            this.BtnVisitDetails.Text = "site Visitation";
            this.BtnVisitDetails.UseVisualStyleBackColor = true;
            this.BtnVisitDetails.Click += new System.EventHandler(this.BtnVisitDetails_Click);
            // 
            // FarmersLocationFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WorkFlowMenagementMDI.Properties.Resources.mesh_background___1280x720_by_teamsjk_d3irbsx;
            this.ClientSize = new System.Drawing.Size(1012, 385);
            this.Controls.Add(this.BtnVisitDetails);
            this.Controls.Add(this.BtnUploadDetails);
            this.Controls.Add(this.BtnViewFarmers);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.TxtBrows);
            this.Controls.Add(this.LblDistence);
            this.Controls.Add(this.LblDuration);
            this.Controls.Add(this.LblDestiAdd);
            this.Controls.Add(this.LblOriginAdd);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDestiLat);
            this.Controls.Add(this.txtDestiLongi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOriginLat);
            this.Controls.Add(this.txtOriginLong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbDestiFarmer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CmbFarmer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblLocation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLati);
            this.Controls.Add(this.TxtLongi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnGetLoca);
            this.Name = "FarmersLocationFilter";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGetLoca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtLongi;
        private System.Windows.Forms.TextBox TxtLati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LblLocation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CmbFarmer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbDestiFarmer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOriginLat;
        private System.Windows.Forms.TextBox txtOriginLong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDestiLat;
        private System.Windows.Forms.TextBox txtDestiLongi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblDistence;
        private System.Windows.Forms.Label LblDuration;
        private System.Windows.Forms.Label LblDestiAdd;
        private System.Windows.Forms.Label LblOriginAdd;
        private System.Windows.Forms.Button TxtBrows;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button BtnViewFarmers;
        private System.Windows.Forms.Button BtnUploadDetails;
        private System.Windows.Forms.Button BtnVisitDetails;
    }
}

