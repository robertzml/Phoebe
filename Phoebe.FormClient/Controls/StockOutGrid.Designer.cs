namespace Phoebe.FormClient
{
    partial class StockOutGrid
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
            this.dgcStockOut = new DevExpress.XtraGrid.GridControl();
            this.bsStockOut = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockOut = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockOutId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLife = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStockOut
            // 
            this.dgcStockOut.DataSource = this.bsStockOut;
            this.dgcStockOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStockOut.Location = new System.Drawing.Point(0, 0);
            this.dgcStockOut.MainView = this.dgvStockOut;
            this.dgcStockOut.Name = "dgcStockOut";
            this.dgcStockOut.Size = new System.Drawing.Size(799, 353);
            this.dgcStockOut.TabIndex = 0;
            this.dgcStockOut.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStockOut});
            // 
            // bsStockOut
            // 
            this.bsStockOut.DataSource = typeof(Phoebe.Model.StockOutModel);
            // 
            // dgvStockOut
            // 
            this.dgvStockOut.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStockOutId,
            this.colStoreId,
            this.colContractId,
            this.colCargoId,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colSpecification,
            this.colTotalCount,
            this.colStoreCount,
            this.colOutCount,
            this.colGroupType,
            this.colUnitWeight,
            this.colOutWeight,
            this.colUnitVolume,
            this.colOutVolume,
            this.colWarehouseNumber,
            this.colInTime,
            this.colMoveTime,
            this.colOriginPlace,
            this.colShelfLife,
            this.colRemark,
            this.colStatus});
            this.dgvStockOut.GridControl = this.dgcStockOut;
            this.dgvStockOut.Name = "dgvStockOut";
            this.dgvStockOut.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockOut.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockOut.OptionsBehavior.Editable = false;
            this.dgvStockOut.OptionsCustomization.AllowFilter = false;
            this.dgvStockOut.OptionsCustomization.AllowGroup = false;
            this.dgvStockOut.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvStockOut.OptionsFilter.AllowFilterEditor = false;
            this.dgvStockOut.OptionsFind.AllowFindPanel = false;
            this.dgvStockOut.OptionsMenu.EnableColumnMenu = false;
            this.dgvStockOut.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStockOut.OptionsView.ShowFooter = true;
            this.dgvStockOut.OptionsView.ShowGroupPanel = false;
            this.dgvStockOut.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dgvStockOut_CellValueChanging);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStockOutId
            // 
            this.colStockOutId.FieldName = "StockOutId";
            this.colStockOutId.Name = "colStockOutId";
            // 
            // colStoreId
            // 
            this.colStoreId.FieldName = "StoreId";
            this.colStoreId.Name = "colStoreId";
            // 
            // colContractId
            // 
            this.colContractId.FieldName = "ContractId";
            this.colContractId.Name = "colContractId";
            // 
            // colCargoId
            // 
            this.colCargoId.FieldName = "CargoId";
            this.colCargoId.Name = "colCargoId";
            // 
            // colCategoryId
            // 
            this.colCategoryId.FieldName = "CategoryId";
            this.colCategoryId.Name = "colCategoryId";
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "分类编码";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.OptionsColumn.AllowEdit = false;
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 0;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.OptionsColumn.AllowEdit = false;
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 1;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.OptionsColumn.AllowEdit = false;
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 2;
            // 
            // colTotalCount
            // 
            this.colTotalCount.Caption = "总数量";
            this.colTotalCount.FieldName = "TotalCount";
            this.colTotalCount.Name = "colTotalCount";
            this.colTotalCount.OptionsColumn.AllowEdit = false;
            this.colTotalCount.Visible = true;
            this.colTotalCount.VisibleIndex = 3;
            // 
            // colStoreCount
            // 
            this.colStoreCount.Caption = "在库数量";
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.OptionsColumn.AllowEdit = false;
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 4;
            // 
            // colOutCount
            // 
            this.colOutCount.Caption = "出库数量";
            this.colOutCount.FieldName = "OutCount";
            this.colOutCount.Name = "colOutCount";
            this.colOutCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutCount", "合计={0:0.##}")});
            this.colOutCount.Visible = true;
            this.colOutCount.VisibleIndex = 5;
            // 
            // colGroupType
            // 
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.Name = "colGroupType";
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.00";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.OptionsColumn.AllowEdit = false;
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 6;
            // 
            // colOutWeight
            // 
            this.colOutWeight.Caption = "出库重量(t)";
            this.colOutWeight.DisplayFormat.FormatString = "0.####";
            this.colOutWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOutWeight.FieldName = "OutWeight";
            this.colOutWeight.Name = "colOutWeight";
            this.colOutWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutWeight", "合计={0:0.####}")});
            this.colOutWeight.Visible = true;
            this.colOutWeight.VisibleIndex = 7;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.000";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.OptionsColumn.AllowEdit = false;
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 8;
            // 
            // colOutVolume
            // 
            this.colOutVolume.Caption = "出库体积(立方)";
            this.colOutVolume.DisplayFormat.FormatString = "0.####";
            this.colOutVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOutVolume.FieldName = "OutVolume";
            this.colOutVolume.Name = "colOutVolume";
            this.colOutVolume.OptionsColumn.AllowEdit = false;
            this.colOutVolume.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OutVolume", "合计={0:0.####}")});
            this.colOutVolume.Visible = true;
            this.colOutVolume.VisibleIndex = 9;
            // 
            // colWarehouseNumber
            // 
            this.colWarehouseNumber.Caption = "仓位编号";
            this.colWarehouseNumber.FieldName = "WarehouseNumber";
            this.colWarehouseNumber.Name = "colWarehouseNumber";
            this.colWarehouseNumber.OptionsColumn.AllowEdit = false;
            this.colWarehouseNumber.Visible = true;
            this.colWarehouseNumber.VisibleIndex = 10;
            // 
            // colInTime
            // 
            this.colInTime.Caption = "入库时间";
            this.colInTime.FieldName = "InTime";
            this.colInTime.Name = "colInTime";
            this.colInTime.OptionsColumn.AllowEdit = false;
            this.colInTime.Visible = true;
            this.colInTime.VisibleIndex = 11;
            // 
            // colMoveTime
            // 
            this.colMoveTime.Caption = "移入时间";
            this.colMoveTime.FieldName = "MoveTime";
            this.colMoveTime.Name = "colMoveTime";
            this.colMoveTime.OptionsColumn.AllowEdit = false;
            this.colMoveTime.Visible = true;
            this.colMoveTime.VisibleIndex = 12;
            // 
            // colOriginPlace
            // 
            this.colOriginPlace.Caption = "产地";
            this.colOriginPlace.FieldName = "OriginPlace";
            this.colOriginPlace.Name = "colOriginPlace";
            this.colOriginPlace.OptionsColumn.AllowEdit = false;
            this.colOriginPlace.Visible = true;
            this.colOriginPlace.VisibleIndex = 13;
            // 
            // colShelfLife
            // 
            this.colShelfLife.Caption = "保质期(月)";
            this.colShelfLife.FieldName = "ShelfLife";
            this.colShelfLife.Name = "colShelfLife";
            this.colShelfLife.OptionsColumn.AllowEdit = false;
            this.colShelfLife.Visible = true;
            this.colShelfLife.VisibleIndex = 14;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 15;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // StockOutGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgcStockOut);
            this.Name = "StockOutGrid";
            this.Size = new System.Drawing.Size(799, 353);
            this.Load += new System.EventHandler(this.StockOutGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStockOut;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStockOut;
        private System.Windows.Forms.BindingSource bsStockOut;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockOutId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colOutCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colOutWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colOutVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLife;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCount;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveTime;
    }
}
