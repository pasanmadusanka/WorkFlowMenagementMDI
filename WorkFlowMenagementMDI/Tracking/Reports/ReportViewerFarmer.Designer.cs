namespace WorkFlowMenagementMDI.Tracking.Reports
{
    partial class ReportViewerFarmer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewerFarmer));
            this.CRViewerGeo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRViewerGeo
            // 
            this.CRViewerGeo.ActiveViewIndex = -1;
            this.CRViewerGeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewerGeo.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRViewerGeo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRViewerGeo.Location = new System.Drawing.Point(0, 0);
            this.CRViewerGeo.Name = "CRViewerGeo";
            this.CRViewerGeo.Size = new System.Drawing.Size(883, 456);
            this.CRViewerGeo.TabIndex = 0;
            // 
            // ReportViewerFarmer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 456);
            this.Controls.Add(this.CRViewerGeo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReportViewerFarmer";
            this.Text = "ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewerGeo;
    }
}