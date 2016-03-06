namespace Phoebe.FormUI
{
    partial class StockFlowPrintForm
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
            this.StockFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.StockFlowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // StockFlowBindingSource
            // 
            this.StockFlowBindingSource.DataSource = typeof(Phoebe.Model.StockFlow);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Phoebe.FormUI.Report.StockFlow.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(857, 492);
            this.reportViewer1.TabIndex = 0;
            // 
            // StockFlowPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 498);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StockFlowPrintForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "库存流水打印";
            this.Load += new System.EventHandler(this.StockFlowPrintForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.StockFlowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource StockFlowBindingSource;
    }
}