namespace Phoebe.FormClient
{
    partial class IceStockGrid
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
            this.dgcIce = new DevExpress.XtraGrid.GridControl();
            this.bsIceFlow = new System.Windows.Forms.BindingSource(this.components);
            this.dgvIce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcIce
            // 
            this.dgcIce.DataSource = this.bsIceFlow;
            this.dgcIce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcIce.Location = new System.Drawing.Point(0, 0);
            this.dgcIce.MainView = this.dgvIce;
            this.dgcIce.Name = "dgcIce";
            this.dgcIce.Size = new System.Drawing.Size(737, 385);
            this.dgcIce.TabIndex = 0;
            this.dgcIce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIce});
            // 
            // bsIceFlow
            // 
            this.bsIceFlow.DataSource = typeof(Phoebe.Model.IceFlow);
            // 
            // dgvIce
            // 
            this.dgvIce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFlowType,
            this.colIceType,
            this.colFlowCount,
            this.colFlowWeight,
            this.colFlowTime,
            this.colUserId,
            this.colCreateTime,
            this.colRemark,
            this.colStatus});
            this.dgvIce.GridControl = this.dgcIce;
            this.dgvIce.Name = "dgvIce";
            this.dgvIce.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsFilter.AllowFilterEditor = false;
            this.dgvIce.OptionsFind.AllowFindPanel = false;
            this.dgvIce.OptionsMenu.EnableColumnMenu = false;
            this.dgvIce.OptionsMenu.EnableFooterMenu = false;
            this.dgvIce.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvIce.OptionsView.ShowFooter = true;
            this.dgvIce.OptionsView.ShowGroupPanel = false;
            this.dgvIce.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvIce_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFlowType
            // 
            this.colFlowType.FieldName = "FlowType";
            this.colFlowType.Name = "colFlowType";
            // 
            // colIceType
            // 
            this.colIceType.AppearanceCell.Options.UseTextOptions = true;
            this.colIceType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIceType.Caption = "冰块类型";
            this.colIceType.FieldName = "IceType";
            this.colIceType.Name = "colIceType";
            this.colIceType.OptionsColumn.AllowEdit = false;
            this.colIceType.Visible = true;
            this.colIceType.VisibleIndex = 0;
            // 
            // colFlowCount
            // 
            this.colFlowCount.Caption = "流水数量";
            this.colFlowCount.FieldName = "FlowCount";
            this.colFlowCount.Name = "colFlowCount";
            this.colFlowCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FlowCount", "合计={0:0.##}")});
            this.colFlowCount.Visible = true;
            this.colFlowCount.VisibleIndex = 1;
            // 
            // colFlowWeight
            // 
            this.colFlowWeight.Caption = "流水重量(t)";
            this.colFlowWeight.DisplayFormat.FormatString = "0.000";
            this.colFlowWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowWeight.FieldName = "FlowWeight";
            this.colFlowWeight.Name = "colFlowWeight";
            this.colFlowWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FlowWeight", "合计={0:0.000}")});
            this.colFlowWeight.Visible = true;
            this.colFlowWeight.VisibleIndex = 2;
            // 
            // colFlowTime
            // 
            this.colFlowTime.FieldName = "FlowTime";
            this.colFlowTime.Name = "colFlowTime";
            // 
            // colUserId
            // 
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            // 
            // colCreateTime
            // 
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 3;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // IceStockGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceStockGrid";
            this.Size = new System.Drawing.Size(737, 385);
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcIce;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIce;
        private System.Windows.Forms.BindingSource bsIceFlow;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowType;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowCount;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
