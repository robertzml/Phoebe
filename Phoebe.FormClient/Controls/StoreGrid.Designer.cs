namespace Phoebe.FormClient
{
    partial class StoreGrid
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
            this.dgcStore = new DevExpress.XtraGrid.GridControl();
            this.bsStore = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStore = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLife = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestination = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStore
            // 
            this.dgcStore.DataSource = this.bsStore;
            this.dgcStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStore.Location = new System.Drawing.Point(0, 0);
            this.dgcStore.MainView = this.dgvStore;
            this.dgcStore.Name = "dgcStore";
            this.dgcStore.Size = new System.Drawing.Size(754, 398);
            this.dgcStore.TabIndex = 0;
            this.dgcStore.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStore});
            // 
            // bsStore
            // 
            this.bsStore.DataSource = typeof(Phoebe.Model.Store);
            // 
            // dgvStore
            // 
            this.dgvStore.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colContractName,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colWarehouseNumber,
            this.colTotalCount,
            this.colStoreCount,
            this.colUnitWeight,
            this.colTotalWeight,
            this.colStoreWeight,
            this.colUnitVolume,
            this.colTotalVolume,
            this.colStoreVolume,
            this.colInTime,
            this.colOutTime,
            this.colMoveTime,
            this.colSpecification,
            this.colOriginPlace,
            this.colShelfLife,
            this.colSource,
            this.colDestination,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dgvStore.GridControl = this.dgcStore;
            this.dgvStore.Name = "dgvStore";
            this.dgvStore.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStore.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStore.OptionsBehavior.Editable = false;
            this.dgvStore.OptionsView.ShowFooter = true;
            this.dgvStore.OptionsView.ShowGroupPanel = false;
            this.dgvStore.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvStore_CustomUnboundColumnData);
            this.dgvStore.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvStore_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编码";
            this.colCustomerNumber.FieldName = "colCustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 0;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户姓名";
            this.colCustomerName.FieldName = "colCustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colContractName
            // 
            this.colContractName.Caption = "所属合同";
            this.colContractName.FieldName = "colContractName";
            this.colContractName.Name = "colContractName";
            this.colContractName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 2;
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "分类编码";
            this.colCategoryNumber.FieldName = "colCategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 3;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
            this.colCategoryName.FieldName = "colCategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 4;
            // 
            // colWarehouseNumber
            // 
            this.colWarehouseNumber.Caption = "库位编号";
            this.colWarehouseNumber.FieldName = "WarehouseNumber";
            this.colWarehouseNumber.Name = "colWarehouseNumber";
            this.colWarehouseNumber.Visible = true;
            this.colWarehouseNumber.VisibleIndex = 5;
            // 
            // colTotalCount
            // 
            this.colTotalCount.Caption = "总数量";
            this.colTotalCount.FieldName = "TotalCount";
            this.colTotalCount.Name = "colTotalCount";
            this.colTotalCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCount", "合计={0:0.##}")});
            this.colTotalCount.Visible = true;
            this.colTotalCount.VisibleIndex = 6;
            // 
            // colStoreCount
            // 
            this.colStoreCount.Caption = "在库数量";
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreCount", "合计={0:0.##}")});
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 7;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "colUnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 8;
            // 
            // colTotalWeight
            // 
            this.colTotalWeight.Caption = "总重量(t)";
            this.colTotalWeight.DisplayFormat.FormatString = "0.####";
            this.colTotalWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalWeight.FieldName = "TotalWeight";
            this.colTotalWeight.Name = "colTotalWeight";
            this.colTotalWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalWeight", "合计={0:0.####}")});
            this.colTotalWeight.Visible = true;
            this.colTotalWeight.VisibleIndex = 9;
            // 
            // colStoreWeight
            // 
            this.colStoreWeight.Caption = "在库重量(t)";
            this.colStoreWeight.DisplayFormat.FormatString = "0.####";
            this.colStoreWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStoreWeight.FieldName = "StoreWeight";
            this.colStoreWeight.Name = "colStoreWeight";
            this.colStoreWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreWeight", "合计={0:0.####}")});
            this.colStoreWeight.Visible = true;
            this.colStoreWeight.VisibleIndex = 10;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.###";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "colUnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 11;
            // 
            // colTotalVolume
            // 
            this.colTotalVolume.Caption = "总体积(立方)";
            this.colTotalVolume.DisplayFormat.FormatString = "0.####";
            this.colTotalVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalVolume.FieldName = "TotalVolume";
            this.colTotalVolume.Name = "colTotalVolume";
            this.colTotalVolume.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalVolume", "合计={0:0.####}")});
            this.colTotalVolume.Visible = true;
            this.colTotalVolume.VisibleIndex = 12;
            // 
            // colStoreVolume
            // 
            this.colStoreVolume.Caption = "在库体积(立方)";
            this.colStoreVolume.DisplayFormat.FormatString = "0.####";
            this.colStoreVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStoreVolume.FieldName = "StoreVolume";
            this.colStoreVolume.Name = "colStoreVolume";
            this.colStoreVolume.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreVolume", "合计={0:0.####}")});
            this.colStoreVolume.Visible = true;
            this.colStoreVolume.VisibleIndex = 13;
            // 
            // colInTime
            // 
            this.colInTime.Caption = "入库时间";
            this.colInTime.FieldName = "InTime";
            this.colInTime.Name = "colInTime";
            this.colInTime.Visible = true;
            this.colInTime.VisibleIndex = 14;
            // 
            // colOutTime
            // 
            this.colOutTime.Caption = "出库时间";
            this.colOutTime.FieldName = "OutTime";
            this.colOutTime.Name = "colOutTime";
            this.colOutTime.Visible = true;
            this.colOutTime.VisibleIndex = 15;
            // 
            // colMoveTime
            // 
            this.colMoveTime.Caption = "移入时间";
            this.colMoveTime.FieldName = "MoveTime";
            this.colMoveTime.Name = "colMoveTime";
            this.colMoveTime.Visible = true;
            this.colMoveTime.VisibleIndex = 16;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 17;
            // 
            // colOriginPlace
            // 
            this.colOriginPlace.Caption = "产地";
            this.colOriginPlace.FieldName = "OriginPlace";
            this.colOriginPlace.Name = "colOriginPlace";
            this.colOriginPlace.Visible = true;
            this.colOriginPlace.VisibleIndex = 18;
            // 
            // colShelfLife
            // 
            this.colShelfLife.Caption = "保质期(月)";
            this.colShelfLife.FieldName = "ShelfLife";
            this.colShelfLife.Name = "colShelfLife";
            this.colShelfLife.Visible = true;
            this.colShelfLife.VisibleIndex = 19;
            // 
            // colSource
            // 
            this.colSource.AppearanceCell.Options.UseTextOptions = true;
            this.colSource.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colSource.Caption = "来源";
            this.colSource.FieldName = "Source";
            this.colSource.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colSource.Name = "colSource";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 20;
            // 
            // colDestination
            // 
            this.colDestination.AppearanceCell.Options.UseTextOptions = true;
            this.colDestination.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colDestination.Caption = "目的地";
            this.colDestination.FieldName = "Destination";
            this.colDestination.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colDestination.Name = "colDestination";
            this.colDestination.Visible = true;
            this.colDestination.VisibleIndex = 21;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "登记人";
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 22;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 23;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 24;
            // 
            // StoreGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStore);
            this.Name = "StoreGrid";
            this.Size = new System.Drawing.Size(754, 398);
            this.Load += new System.EventHandler(this.StoreGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStore;
        private System.Windows.Forms.BindingSource bsStore;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStore;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOutTime;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLife;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDestination;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
    }
}
