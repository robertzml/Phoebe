namespace Phoebe.FormClient
{
    partial class StockMoveForm
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
            this.tcStockMove = new DevExpress.XtraTab.XtraTabControl();
            this.tpStockMoveList = new DevExpress.XtraTab.XtraTabPage();
            this.tvStockMove = new System.Windows.Forms.TreeView();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.tsStockMove = new System.Windows.Forms.ToolStrip();
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
            ((System.ComponentModel.ISupportInitialize)(this.tcStockMove)).BeginInit();
            this.tcStockMove.SuspendLayout();
            this.tpStockMoveList.SuspendLayout();
            this.tsStockMove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).BeginInit();
            this.plBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plEmpty)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.tcStockMove);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(216, 617);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "导航";
            // 
            // tcStockMove
            // 
            this.tcStockMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcStockMove.Location = new System.Drawing.Point(2, 21);
            this.tcStockMove.Name = "tcStockMove";
            this.tcStockMove.SelectedTabPage = this.tpStockMoveList;
            this.tcStockMove.Size = new System.Drawing.Size(212, 594);
            this.tcStockMove.TabIndex = 1;
            this.tcStockMove.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpStockMoveList,
            this.xtraTabPage2});
            // 
            // tpStockMoveList
            // 
            this.tpStockMoveList.Controls.Add(this.tvStockMove);
            this.tpStockMoveList.Name = "tpStockMoveList";
            this.tpStockMoveList.Size = new System.Drawing.Size(206, 565);
            this.tpStockMoveList.Text = "列表";
            // 
            // tvStockMove
            // 
            this.tvStockMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStockMove.Location = new System.Drawing.Point(0, 0);
            this.tvStockMove.Name = "tvStockMove";
            this.tvStockMove.Size = new System.Drawing.Size(206, 565);
            this.tvStockMove.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(226, 565);
            this.xtraTabPage2.Text = "查询";
            // 
            // tsStockMove
            // 
            this.tsStockMove.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tsStockMove.Location = new System.Drawing.Point(216, 0);
            this.tsStockMove.Name = "tsStockMove";
            this.tsStockMove.Size = new System.Drawing.Size(818, 25);
            this.tsStockMove.TabIndex = 8;
            this.tsStockMove.Text = "toolStrip1";
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
            this.plBody.Size = new System.Drawing.Size(818, 592);
            this.plBody.TabIndex = 9;
            // 
            // plEmpty
            // 
            this.plEmpty.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.plEmpty.Dock = System.Windows.Forms.DockStyle.Top;
            this.plEmpty.Location = new System.Drawing.Point(0, 0);
            this.plEmpty.Name = "plEmpty";
            this.plEmpty.Size = new System.Drawing.Size(818, 100);
            this.plEmpty.TabIndex = 0;
            // 
            // StockMoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 617);
            this.Controls.Add(this.plBody);
            this.Controls.Add(this.tsStockMove);
            this.Controls.Add(this.groupControl1);
            this.Name = "StockMoveForm";
            this.Text = "货品移库";
            this.Load += new System.EventHandler(this.StockMoveForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcStockMove)).EndInit();
            this.tcStockMove.ResumeLayout(false);
            this.tpStockMoveList.ResumeLayout(false);
            this.tsStockMove.ResumeLayout(false);
            this.tsStockMove.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBody)).EndInit();
            this.plBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plEmpty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTab.XtraTabControl tcStockMove;
        private DevExpress.XtraTab.XtraTabPage tpStockMoveList;
        private System.Windows.Forms.TreeView tvStockMove;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.ToolStrip tsStockMove;
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