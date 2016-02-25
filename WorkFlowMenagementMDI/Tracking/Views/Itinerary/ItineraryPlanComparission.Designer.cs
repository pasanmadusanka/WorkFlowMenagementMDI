namespace WorkFlowMenagementMDI.Tracking.Views.Itinerary
{
    partial class ItineraryPlanComparison
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItineraryPlanComparison));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.DgvGpsActualVisits = new System.Windows.Forms.DataGridView();
            this.dg_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Frm_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Frm_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_Loc_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_left_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBFailItinerary = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvItineraryView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpPlanToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpPlanFrmDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBItinary = new System.Windows.Forms.RadioButton();
            this.RBMissItinary = new System.Windows.Forms.RadioButton();
            this.CmbFieldOfficer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbWIP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPrinter = new System.Windows.Forms.Button();
            this.GbItinerary = new System.Windows.Forms.GroupBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGpsActualVisits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItineraryView)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GbItinerary.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 107);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.DgvGpsActualVisits);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CBFailItinerary);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.DgvItineraryView);
            this.splitContainer1.Size = new System.Drawing.Size(833, 391);
            this.splitContainer1.SplitterDistance = 186;
            this.splitContainer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "GPSLocation Actual View";
            // 
            // DgvGpsActualVisits
            // 
            this.DgvGpsActualVisits.AllowUserToAddRows = false;
            this.DgvGpsActualVisits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvGpsActualVisits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvGpsActualVisits.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvGpsActualVisits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvGpsActualVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGpsActualVisits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dg_DATE,
            this.dg_Frm_Code,
            this.dg_Frm_Name,
            this.dg_Loc_Name,
            this.dg_StartTime,
            this.dg_left_time,
            this.dg_duration});
            this.DgvGpsActualVisits.Location = new System.Drawing.Point(3, 24);
            this.DgvGpsActualVisits.Name = "DgvGpsActualVisits";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvGpsActualVisits.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvGpsActualVisits.Size = new System.Drawing.Size(825, 157);
            this.DgvGpsActualVisits.TabIndex = 2;
            // 
            // dg_DATE
            // 
            this.dg_DATE.DataPropertyName = "DATE";
            this.dg_DATE.HeaderText = "Date";
            this.dg_DATE.Name = "dg_DATE";
            // 
            // dg_Frm_Code
            // 
            this.dg_Frm_Code.DataPropertyName = "FAR_HDR_MST_CODE";
            this.dg_Frm_Code.HeaderText = "Code";
            this.dg_Frm_Code.Name = "dg_Frm_Code";
            // 
            // dg_Frm_Name
            // 
            this.dg_Frm_Name.DataPropertyName = "FAR_HDR_MST_NAME";
            this.dg_Frm_Name.HeaderText = "Out Grower";
            this.dg_Frm_Name.Name = "dg_Frm_Name";
            // 
            // dg_Loc_Name
            // 
            this.dg_Loc_Name.DataPropertyName = "FAR_LOC_MST_NAME";
            this.dg_Loc_Name.HeaderText = "Location";
            this.dg_Loc_Name.Name = "dg_Loc_Name";
            // 
            // dg_StartTime
            // 
            this.dg_StartTime.DataPropertyName = "Start_Time";
            this.dg_StartTime.HeaderText = "Arived @";
            this.dg_StartTime.Name = "dg_StartTime";
            // 
            // dg_left_time
            // 
            this.dg_left_time.DataPropertyName = "End_Time";
            this.dg_left_time.HeaderText = "Leave @";
            this.dg_left_time.Name = "dg_left_time";
            // 
            // dg_duration
            // 
            this.dg_duration.DataPropertyName = "Duration";
            this.dg_duration.HeaderText = "Time Spent";
            this.dg_duration.Name = "dg_duration";
            // 
            // CBFailItinerary
            // 
            this.CBFailItinerary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBFailItinerary.AutoSize = true;
            this.CBFailItinerary.Location = new System.Drawing.Point(703, 4);
            this.CBFailItinerary.Name = "CBFailItinerary";
            this.CBFailItinerary.Size = new System.Drawing.Size(125, 17);
            this.CBFailItinerary.TabIndex = 17;
            this.CBFailItinerary.Text = "Missed From Itinerary";
            this.CBFailItinerary.UseVisualStyleBackColor = true;
            this.CBFailItinerary.CheckedChanged += new System.EventHandler(this.CBFailItinerary_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(369, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "\\";
            // 
            // DgvItineraryView
            // 
            this.DgvItineraryView.AllowUserToAddRows = false;
            this.DgvItineraryView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvItineraryView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvItineraryView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvItineraryView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvItineraryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvItineraryView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.DgvItineraryView.Location = new System.Drawing.Point(3, 24);
            this.DgvItineraryView.Name = "DgvItineraryView";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DgvItineraryView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvItineraryView.Size = new System.Drawing.Size(825, 172);
            this.DgvItineraryView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WIP_CODE";
            this.dataGridViewTextBoxColumn1.HeaderText = "WIP ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ITINERARY_MST_DATE";
            this.dataGridViewTextBoxColumn2.HeaderText = "Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FAR_LOC_MST_NAME";
            this.dataGridViewTextBoxColumn3.HeaderText = "Location";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Farmer";
            this.dataGridViewTextBoxColumn4.HeaderText = "Out Grower";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BAT_CRT_CODE";
            this.dataGridViewTextBoxColumn5.HeaderText = "Batch";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Age";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BAT_CRT_NO_CHICKS";
            this.dataGridViewTextBoxColumn7.HeaderText = "Capacity";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "WIP ID No";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Farm ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "BatchID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "FLD_OFF_MST_NAME";
            this.dataGridViewTextBoxColumn11.HeaderText = "Field Officer";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(243, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "To Date :";
            // 
            // DtpPlanToDate
            // 
            this.DtpPlanToDate.CustomFormat = "dd/MMMM/yyyy";
            this.DtpPlanToDate.Enabled = false;
            this.DtpPlanToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpPlanToDate.Location = new System.Drawing.Point(312, 19);
            this.DtpPlanToDate.Name = "DtpPlanToDate";
            this.DtpPlanToDate.Size = new System.Drawing.Size(134, 20);
            this.DtpPlanToDate.TabIndex = 13;
            this.DtpPlanToDate.Value = new System.DateTime(2016, 2, 20, 12, 27, 37, 788);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(19, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "From Date :";
            // 
            // DtpPlanFrmDate
            // 
            this.DtpPlanFrmDate.CustomFormat = "dd/MMMM/yyyy";
            this.DtpPlanFrmDate.Enabled = false;
            this.DtpPlanFrmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpPlanFrmDate.Location = new System.Drawing.Point(85, 19);
            this.DtpPlanFrmDate.Name = "DtpPlanFrmDate";
            this.DtpPlanFrmDate.Size = new System.Drawing.Size(134, 20);
            this.DtpPlanFrmDate.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.CmbFieldOfficer);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.CmbWIP);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.BtnPrinter);
            this.panel1.Controls.Add(this.GbItinerary);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 89);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBItinary);
            this.groupBox1.Controls.Add(this.RBMissItinary);
            this.groupBox1.Location = new System.Drawing.Point(104, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 46);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Type";
            // 
            // RBItinary
            // 
            this.RBItinary.AutoSize = true;
            this.RBItinary.Checked = true;
            this.RBItinary.Location = new System.Drawing.Point(9, 19);
            this.RBItinary.Name = "RBItinary";
            this.RBItinary.Size = new System.Drawing.Size(62, 17);
            this.RBItinary.TabIndex = 1;
            this.RBItinary.TabStop = true;
            this.RBItinary.Text = "Itinerary";
            this.RBItinary.UseVisualStyleBackColor = true;
            // 
            // RBMissItinary
            // 
            this.RBMissItinary.AutoSize = true;
            this.RBMissItinary.Location = new System.Drawing.Point(77, 19);
            this.RBMissItinary.Name = "RBMissItinary";
            this.RBMissItinary.Size = new System.Drawing.Size(86, 17);
            this.RBMissItinary.TabIndex = 0;
            this.RBMissItinary.Text = "Miss Itinerary";
            this.RBMissItinary.UseVisualStyleBackColor = true;
            // 
            // CmbFieldOfficer
            // 
            this.CmbFieldOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbFieldOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbFieldOfficer.FormattingEnabled = true;
            this.CmbFieldOfficer.Location = new System.Drawing.Point(572, 7);
            this.CmbFieldOfficer.Name = "CmbFieldOfficer";
            this.CmbFieldOfficer.Size = new System.Drawing.Size(244, 21);
            this.CmbFieldOfficer.TabIndex = 18;
            this.CmbFieldOfficer.SelectedIndexChanged += new System.EventHandler(this.CmbFieldOfficer_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(497, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Field Officer :";
            // 
            // CmbWIP
            // 
            this.CmbWIP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbWIP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbWIP.FormattingEnabled = true;
            this.CmbWIP.Location = new System.Drawing.Point(220, 7);
            this.CmbWIP.Name = "CmbWIP";
            this.CmbWIP.Size = new System.Drawing.Size(271, 21);
            this.CmbWIP.TabIndex = 16;
            this.CmbWIP.SelectedIndexChanged += new System.EventHandler(this.CmbWIP_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(110, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Itinerary Plan (WIP) :";
            // 
            // BtnPrinter
            // 
            this.BtnPrinter.BackColor = System.Drawing.Color.White;
            this.BtnPrinter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPrinter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPrinter.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrinter.Image")));
            this.BtnPrinter.Location = new System.Drawing.Point(3, 3);
            this.BtnPrinter.Name = "BtnPrinter";
            this.BtnPrinter.Size = new System.Drawing.Size(85, 81);
            this.BtnPrinter.TabIndex = 2;
            this.BtnPrinter.UseVisualStyleBackColor = false;
            this.BtnPrinter.Click += new System.EventHandler(this.BtnPrinter_Click);
            // 
            // GbItinerary
            // 
            this.GbItinerary.Controls.Add(this.DtpPlanToDate);
            this.GbItinerary.Controls.Add(this.DtpPlanFrmDate);
            this.GbItinerary.Controls.Add(this.label3);
            this.GbItinerary.Controls.Add(this.label2);
            this.GbItinerary.Enabled = false;
            this.GbItinerary.Location = new System.Drawing.Point(318, 34);
            this.GbItinerary.Name = "GbItinerary";
            this.GbItinerary.Size = new System.Drawing.Size(468, 46);
            this.GbItinerary.TabIndex = 19;
            this.GbItinerary.TabStop = false;
            this.GbItinerary.Text = "Itinerary Planed Week";
            // 
            // ItineraryPlanComparison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ItineraryPlanComparison";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Itinerary Plan Comparison";
            this.Load += new System.EventHandler(this.ItineraryPlanComparison_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGpsActualVisits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItineraryView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GbItinerary.ResumeLayout(false);
            this.GbItinerary.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DgvGpsActualVisits;
        private System.Windows.Forms.DataGridView DgvItineraryView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpPlanToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpPlanFrmDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnPrinter;
        private System.Windows.Forms.ComboBox CmbWIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbFieldOfficer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_Frm_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_Frm_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_Loc_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_left_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn dg_duration;
        private System.Windows.Forms.GroupBox GbItinerary;
        private System.Windows.Forms.CheckBox CBFailItinerary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBItinary;
        private System.Windows.Forms.RadioButton RBMissItinary;
    }
}