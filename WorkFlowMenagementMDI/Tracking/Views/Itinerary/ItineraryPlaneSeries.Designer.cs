namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    partial class ItineraryPlaneSeries
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItineraryPlaneSeries));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvWIPDetails = new System.Windows.Forms.DataGridView();
            this.WIP_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WIP_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frm_Dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnUploadDetails = new System.Windows.Forms.Button();
            this.BtnItinararyCompair = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnPrinter = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.LblRecord = new System.Windows.Forms.Label();
            this.lblSeriesID = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvWIPDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(165, 339);
            this.treeView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 107);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvWIPDetails);
            this.splitContainer1.Size = new System.Drawing.Size(833, 347);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 1;
            // 
            // DgvWIPDetails
            // 
            this.DgvWIPDetails.AllowUserToAddRows = false;
            this.DgvWIPDetails.AllowUserToDeleteRows = false;
            this.DgvWIPDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvWIPDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvWIPDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvWIPDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DgvWIPDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvWIPDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WIP_ID,
            this.WIP_Code,
            this.Frm_Dat,
            this.To_Dat});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvWIPDetails.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvWIPDetails.Location = new System.Drawing.Point(3, 3);
            this.DgvWIPDetails.Name = "DgvWIPDetails";
            this.DgvWIPDetails.ReadOnly = true;
            this.DgvWIPDetails.Size = new System.Drawing.Size(648, 339);
            this.DgvWIPDetails.TabIndex = 0;
            this.DgvWIPDetails.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvWIPDetails_RowHeaderMouseClick);
            this.DgvWIPDetails.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvWIPDetails_RowHeaderMouseDoubleClick);
            // 
            // WIP_ID
            // 
            this.WIP_ID.DataPropertyName = "ITINERARY_ID";
            this.WIP_ID.HeaderText = "WIP ID";
            this.WIP_ID.Name = "WIP_ID";
            this.WIP_ID.ReadOnly = true;
            this.WIP_ID.Visible = false;
            // 
            // WIP_Code
            // 
            this.WIP_Code.DataPropertyName = "WIP_CODE";
            this.WIP_Code.HeaderText = "WIP Code";
            this.WIP_Code.Name = "WIP_Code";
            this.WIP_Code.ReadOnly = true;
            // 
            // Frm_Dat
            // 
            this.Frm_Dat.DataPropertyName = "DATE_FROM";
            this.Frm_Dat.HeaderText = "From Date";
            this.Frm_Dat.Name = "Frm_Dat";
            this.Frm_Dat.ReadOnly = true;
            // 
            // To_Dat
            // 
            this.To_Dat.DataPropertyName = "DATE_TO";
            this.To_Dat.HeaderText = "To Date";
            this.To_Dat.Name = "To_Dat";
            this.To_Dat.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnUploadDetails);
            this.panel1.Controls.Add(this.BtnItinararyCompair);
            this.panel1.Controls.Add(this.BtnDelete);
            this.panel1.Controls.Add(this.BtnPrinter);
            this.panel1.Controls.Add(this.BtnEdit);
            this.panel1.Controls.Add(this.BtnCreate);
            this.panel1.Controls.Add(this.LblRecord);
            this.panel1.Controls.Add(this.lblSeriesID);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 89);
            this.panel1.TabIndex = 2;
            // 
            // BtnUploadDetails
            // 
            this.BtnUploadDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUploadDetails.BackColor = System.Drawing.Color.White;
            this.BtnUploadDetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUploadDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnUploadDetails.Image = ((System.Drawing.Image)(resources.GetObject("BtnUploadDetails.Image")));
            this.BtnUploadDetails.Location = new System.Drawing.Point(652, 3);
            this.BtnUploadDetails.Name = "BtnUploadDetails";
            this.BtnUploadDetails.Size = new System.Drawing.Size(85, 81);
            this.BtnUploadDetails.TabIndex = 22;
            this.BtnUploadDetails.UseVisualStyleBackColor = false;
            this.BtnUploadDetails.Click += new System.EventHandler(this.BtnUploadDetails_Click);
            // 
            // BtnItinararyCompair
            // 
            this.BtnItinararyCompair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnItinararyCompair.BackColor = System.Drawing.Color.White;
            this.BtnItinararyCompair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnItinararyCompair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnItinararyCompair.Image = ((System.Drawing.Image)(resources.GetObject("BtnItinararyCompair.Image")));
            this.BtnItinararyCompair.Location = new System.Drawing.Point(743, 3);
            this.BtnItinararyCompair.Name = "BtnItinararyCompair";
            this.BtnItinararyCompair.Size = new System.Drawing.Size(85, 81);
            this.BtnItinararyCompair.TabIndex = 4;
            this.BtnItinararyCompair.UseVisualStyleBackColor = false;
            this.BtnItinararyCompair.Click += new System.EventHandler(this.BtnItinararyCompair_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.White;
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("BtnDelete.Image")));
            this.BtnDelete.Location = new System.Drawing.Point(276, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(85, 81);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnPrinter
            // 
            this.BtnPrinter.BackColor = System.Drawing.Color.White;
            this.BtnPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrinter.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrinter.Image")));
            this.BtnPrinter.Location = new System.Drawing.Point(185, 3);
            this.BtnPrinter.Name = "BtnPrinter";
            this.BtnPrinter.Size = new System.Drawing.Size(85, 81);
            this.BtnPrinter.TabIndex = 2;
            this.BtnPrinter.UseVisualStyleBackColor = false;
            this.BtnPrinter.Click += new System.EventHandler(this.BtnPrinter_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.White;
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdit.Image")));
            this.BtnEdit.Location = new System.Drawing.Point(94, 3);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(85, 81);
            this.BtnEdit.TabIndex = 1;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnCreate
            // 
            this.BtnCreate.BackColor = System.Drawing.Color.White;
            this.BtnCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCreate.Image = ((System.Drawing.Image)(resources.GetObject("BtnCreate.Image")));
            this.BtnCreate.Location = new System.Drawing.Point(3, 3);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(85, 81);
            this.BtnCreate.TabIndex = 0;
            this.BtnCreate.UseVisualStyleBackColor = false;
            this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // LblRecord
            // 
            this.LblRecord.AutoSize = true;
            this.LblRecord.Location = new System.Drawing.Point(402, 48);
            this.LblRecord.Name = "LblRecord";
            this.LblRecord.Size = new System.Drawing.Size(10, 13);
            this.LblRecord.TabIndex = 24;
            this.LblRecord.Text = ".";
            this.LblRecord.Visible = false;
            // 
            // lblSeriesID
            // 
            this.lblSeriesID.AutoSize = true;
            this.lblSeriesID.Location = new System.Drawing.Point(402, 23);
            this.lblSeriesID.Name = "lblSeriesID";
            this.lblSeriesID.Size = new System.Drawing.Size(13, 13);
            this.lblSeriesID.TabIndex = 23;
            this.lblSeriesID.Text = "0";
            this.lblSeriesID.Visible = false;
            // 
            // ItineraryPlaneSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ItineraryPlaneSeries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Itinerary Plane Manage";
            this.Load += new System.EventHandler(this.ItineraryPlaneManage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvWIPDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvWIPDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPrinter;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIP_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn WIP_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frm_Dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Dat;
        private System.Windows.Forms.Button BtnItinararyCompair;
        private System.Windows.Forms.Button BtnUploadDetails;
        private System.Windows.Forms.Label lblSeriesID;
        private System.Windows.Forms.Label LblRecord;
    }
}