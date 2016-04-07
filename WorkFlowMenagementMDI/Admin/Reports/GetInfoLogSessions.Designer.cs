namespace WorkFlowMenagementMDI.Admin.Reports
{
    partial class GetInfoLogSessions
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
            this.Print = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DG_LOG_SESSION_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_SEC_HDR_USR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_LOG_ST_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_LOG_END_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DG_TIME_SPENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Print
            // 
            this.Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Print.Location = new System.Drawing.Point(322, 226);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(75, 23);
            this.Print.TabIndex = 0;
            this.Print.Text = "button1";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DG_LOG_SESSION_ID,
            this.DG_SEC_HDR_USR,
            this.DG_LOG_ST_DATE_TIME,
            this.DG_LOG_END_DATE_TIME,
            this.DG_TIME_SPENT});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(385, 208);
            this.dataGridView1.TabIndex = 1;
            // 
            // DG_LOG_SESSION_ID
            // 
            this.DG_LOG_SESSION_ID.DataPropertyName = "LOG_SESSION_ID";
            this.DG_LOG_SESSION_ID.HeaderText = "Session ID";
            this.DG_LOG_SESSION_ID.Name = "DG_LOG_SESSION_ID";
            // 
            // DG_SEC_HDR_USR
            // 
            this.DG_SEC_HDR_USR.DataPropertyName = "SEC_HDR_USR_NAME";
            this.DG_SEC_HDR_USR.HeaderText = "User";
            this.DG_SEC_HDR_USR.Name = "DG_SEC_HDR_USR";
            // 
            // DG_LOG_ST_DATE_TIME
            // 
            this.DG_LOG_ST_DATE_TIME.DataPropertyName = "LOG_ST_DATE_TIME";
            this.DG_LOG_ST_DATE_TIME.HeaderText = "LogON Time";
            this.DG_LOG_ST_DATE_TIME.Name = "DG_LOG_ST_DATE_TIME";
            // 
            // DG_LOG_END_DATE_TIME
            // 
            this.DG_LOG_END_DATE_TIME.DataPropertyName = "LOG_END_DATE_TIME";
            this.DG_LOG_END_DATE_TIME.HeaderText = "LogOff Time";
            this.DG_LOG_END_DATE_TIME.Name = "DG_LOG_END_DATE_TIME";
            // 
            // DG_TIME_SPENT
            // 
            this.DG_TIME_SPENT.DataPropertyName = "TIME_SPENT";
            this.DG_TIME_SPENT.HeaderText = "Time Spent";
            this.DG_TIME_SPENT.Name = "DG_TIME_SPENT";
            // 
            // GetInfoLogSessions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Print);
            this.Name = "GetInfoLogSessions";
            this.Text = "GetInfoLogSessions";
            this.Load += new System.EventHandler(this.GetInfoLogSessions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_LOG_SESSION_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_SEC_HDR_USR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_LOG_ST_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_LOG_END_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DG_TIME_SPENT;
    }
}