namespace Phoebe.FormClient
{
    partial class StockOutForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tcStockOut = new DevExpress.XtraTab.XtraTabControl();
            this.tpStockOutList = new DevExpress.XtraTab.XtraTabPage();
            this.tvStockOut = new System.Windows.Forms.TreeView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tsStockOut = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbRevert = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.plBody = new DevExpress.XtraEditors.PanelControl();
            this.plEmpty = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcStockOut)).BeginInit();
            this.tcStockOut.SuspendLayout();
            this.tpStockOutList.SuspendLayout();
            this.tsStockOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).BeginInit();
            this.plBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plEmpty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tcStockOut);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(216, 537);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "导航";
            // 
            // tcStockOut
            // 
            this.tcStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcStockOut.Location = new System.Drawing.Point(2, 21);
            this.tcStockOut.Name = "tcStockOut";
            this.tcStockOut.SelectedTabPage = this.tpStockOutList;
            this.tcStockOut.Size = new System.Drawing.Size(212, 514);
            this.tcStockOut.TabIndex = 0;
            this.tcStockOut.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpStockOutList,
            this.xtraTabPage2});
            // 
            // tpStockOutList
            // 
            this.tpStockOutList.Controls.Add(this.tvStockOut);
            this.tpStockOutList.Name = "tpStockOutList";
            this.tpStockOutList.Size = new System.Drawing.Size(206, 485);
            this.tpStockOutList.Text = "列表";
            // 
            // tvStockOut
            // 
            this.tvStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStockOut.Location = new System.Drawing.Point(0, 0);
            this.tvStockOut.Name = "tvStockOut";
            this.tvStockOut.Size = new System.Drawing.Size(206, 485);
            this.tvStockOut.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(206, 485);
            this.xtraTabPage2.Text = "查询";
            // 
            // tsStockOut
            // 
            this.tsStockOut.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.tsbClose,
            this.tsbSave,
            this.tsbConfirm,
            this.toolStripSeparator,
            this.tsbEdit,
            this.tsbRevert,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbPrint});
            this.tsStockOut.Location = new System.Drawing.Point(216, 0);
            this.tsStockOut.Name = "tsStockOut";
            this.tsStockOut.Size = new System.Drawing.Size(736, 25);
            this.tsStockOut.TabIndex = 8;
            this.tsStockOut.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::Phoebe.FormClient.Properties.Resources.AddFile_16x16;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(52, 22);
            this.tsbNew.Text = "新建";
            this.tsbNew.ToolTipText = "新建";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::Phoebe.FormClient.Properties.Resources.Close_16x16;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(52, 22);
            this.tsbClose.Text = "关闭";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::Phoebe.FormClient.Properties.Resources.Save_16x16;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(52, 22);
            this.tsbSave.Text = "保存";
            // 
            // tsbConfirm
            // 
            this.tsbConfirm.Image = global::Phoebe.FormClient.Properties.Resources.Apply_16x16;
            this.tsbConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfirm.Name = "tsbConfirm";
            this.tsbConfirm.Size = new System.Drawing.Size(76, 22);
            this.tsbConfirm.Text = "入库确认";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = global::Phoebe.FormClient.Properties.Resources.EditName_16x16;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(52, 22);
            this.tsbEdit.Text = "编辑";
            // 
            // tsbRevert
            // 
            this.tsbRevert.Image = global::Phoebe.FormClient.Properties.Resources.Reset_16x16;
            this.tsbRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRevert.Name = "tsbRevert";
            this.tsbRevert.Size = new System.Drawing.Size(52, 22);
            this.tsbRevert.Text = "撤回";
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::Phoebe.FormClient.Properties.Resources.Remove_16x16;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 22);
            this.tsbDelete.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = global::Phoebe.FormClient.Properties.Resources.Print_16x16;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(52, 22);
            this.tsbPrint.Text = "打印";
            // 
            // plBody
            // 
            this.plBody.Appearance.BackColor = System.Drawing.Color.White;
            this.plBody.Appearance.Options.UseBackColor = true;
            this.plBody.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plBody.Controls.Add(this.plEmpty);
            this.plBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plBody.Location = new System.Drawing.Point(216, 25);
            this.plBody.Name = "plBody";
            this.plBody.Size = new System.Drawing.Size(736, 512);
            this.plBody.TabIndex = 9;
            // 
            // plEmpty
            // 
            this.plEmpty.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plEmpty.Dock = System.Windows.Forms.DockStyle.Top;
            this.plEmpty.Location = new System.Drawing.Point(0, 0);
            this.plEmpty.Name = "plEmpty";
            this.plEmpty.Size = new System.Drawing.Size(736, 100);
            this.plEmpty.TabIndex = 0;
            // 
            // StockOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 537);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.tsStockOut);
            this.Controls.Add(this.groupControl1);
            this.Name = "StockOutForm";
            this.Text = "货品出库";
            this.Load += new System.EventHandler(this.StockOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcStockOut)).EndInit();
            this.tcStockOut.ResumeLayout(false);
            this.tpStockOutList.ResumeLayout(false);
            this.tsStockOut.ResumeLayout(false);
            this.tsStockOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).EndInit();
            this.plBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plEmpty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl tcStockOut;
        private DevExpress.XtraTab.XtraTabPage tpStockOutList;
        private System.Windows.Forms.TreeView tvStockOut;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ToolStrip tsStockOut;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbConfirm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbRevert;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private DevExpress.XtraEditors.PanelControl plBody;
        private DevExpress.XtraEditors.PanelControl plEmpty;
    }
}