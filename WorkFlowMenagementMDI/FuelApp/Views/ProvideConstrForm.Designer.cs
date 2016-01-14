namespace FuelApp.Views
{
    partial class ProvideConstrForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SavePcbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbAvalablePc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = ".";
            this.label2.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 14);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(10, 13);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = ".";
            this.lblProgress.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 33);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search Server";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SavePcbtn
            // 
            this.SavePcbtn.Location = new System.Drawing.Point(115, 58);
            this.SavePcbtn.Name = "SavePcbtn";
            this.SavePcbtn.Size = new System.Drawing.Size(94, 33);
            this.SavePcbtn.TabIndex = 8;
            this.SavePcbtn.Text = "Save";
            this.SavePcbtn.UseVisualStyleBackColor = true;
            this.SavePcbtn.Click += new System.EventHandler(this.SavePcbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "PC Names :";
            // 
            // CmbAvalablePc
            // 
            this.CmbAvalablePc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbAvalablePc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbAvalablePc.FormattingEnabled = true;
            this.CmbAvalablePc.Location = new System.Drawing.Point(101, 31);
            this.CmbAvalablePc.Name = "CmbAvalablePc";
            this.CmbAvalablePc.Size = new System.Drawing.Size(87, 21);
            this.CmbAvalablePc.TabIndex = 6;
            this.CmbAvalablePc.DropDown += new System.EventHandler(this.CmbAvalablePc_DropDown);
            // 
            // ProvideConstrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(221, 104);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.SavePcbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbAvalablePc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(237, 143);
            this.MinimizeBox = false;
            this.Name = "ProvideConstrForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection PC";
            this.Load += new System.EventHandler(this.ProvideConstrForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button SavePcbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbAvalablePc;
    }
}