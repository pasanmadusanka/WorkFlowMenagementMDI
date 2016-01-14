namespace WorkFlowMenagementMDI.FuelApp.Views.StockMovement
{
    partial class StockMovementReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMovementReportView));
            this.crystalReportStockMove = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportStockMove
            // 
            this.crystalReportStockMove.ActiveViewIndex = -1;
            this.crystalReportStockMove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportStockMove.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportStockMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportStockMove.Location = new System.Drawing.Point(0, 0);
            this.crystalReportStockMove.Name = "crystalReportStockMove";
            this.crystalReportStockMove.Size = new System.Drawing.Size(761, 460);
            this.crystalReportStockMove.TabIndex = 0;
            // 
            // StockMovementReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 460);
            this.Controls.Add(this.crystalReportStockMove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockMovementReportView";
            this.Text = "StockMovementReportView";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportStockMove;
    }
}