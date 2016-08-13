namespace Phoebe.FormClient
{
    partial class ColdSettlementGrid
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgcCold = new DevExpress.XtraGrid.GridControl();
            this.bsColdSettle = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCold = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColdFee = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColdSettle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCold)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcCold
            // 
            this.dgcCold.DataSource = this.bsColdSettle;
            this.dgcCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcCold.Location = new System.Drawing.Point(0, 0);
            this.dgcCold.MainView = this.dgvCold;
            this.dgcCold.Name = "dgcCold";
            this.dgcCold.Size = new System.Drawing.Size(716, 424);
            this.dgcCold.TabIndex = 0;
            this.dgcCold.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvCold});
            // 
            // bsColdSettle
            // 
            this.bsColdSettle.DataSource = typeof(Phoebe.Model.ColdSettlement);
            // 
            // dgvCold
            // 
            this.dgvCold.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractId,
            this.colContractName,
            this.colStartTime,
            this.colEndTime,
            this.colColdFee});
            this.dgvCold.GridControl = this.dgcCold;
            this.dgvCold.Name = "dgvCold";
            this.dgvCold.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCold.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCold.OptionsBehavior.Editable = false;
            this.dgvCold.OptionsFilter.AllowFilterEditor = false;
            this.dgvCold.OptionsFind.AllowFindPanel = false;
            this.dgvCold.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvCold.OptionsView.EnableAppearanceOddRow = true;
            this.dgvCold.OptionsView.ShowFooter = true;
            this.dgvCold.OptionsView.ShowGroupPanel = false;
            // 
            // colContractId
            // 
            this.colContractId.FieldName = "ContractId";
            this.colContractId.Name = "colContractId";
            // 
            // colContractName
            // 
            this.colContractName.Caption = "合同名称";
            this.colContractName.FieldName = "ContractName";
            this.colContractName.Name = "colContractName";
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 0;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "开始日期";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 1;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "结束日期";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 2;
            // 
            // colColdFee
            // 
            this.colColdFee.Caption = "冷藏费用(元)";
            this.colColdFee.DisplayFormat.FormatString = "0.###";
            this.colColdFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colColdFee.FieldName = "ColdFee";
            this.colColdFee.Name = "colColdFee";
            this.colColdFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ColdFee", "合计={0:0.###}")});
            this.colColdFee.Visible = true;
            this.colColdFee.VisibleIndex = 3;
            // 
            // ColdSettlementGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcCold);
            this.Name = "ColdSettlementGrid";
            this.Size = new System.Drawing.Size(716, 424);
            ((System.ComponentModel.ISupportInitialize)(this.dgcCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsColdSettle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcCold;
        private System.Windows.Forms.BindingSource bsColdSettle;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvCold;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colColdFee;
    }
}
