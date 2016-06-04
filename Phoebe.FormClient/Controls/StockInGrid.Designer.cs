namespace Phoebe.FormClient
{
    partial class StockInGrid
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
            this.dgcStockIn = new DevExpress.XtraGrid.GridControl();
            this.bsStockIn = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockIn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockInId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLife = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStockIn
            // 
            this.dgcStockIn.DataSource = this.bsStockIn;
            this.dgcStockIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStockIn.Location = new System.Drawing.Point(0, 0);
            this.dgcStockIn.MainView = this.dgvStockIn;
            this.dgcStockIn.Name = "dgcStockIn";
            this.dgcStockIn.Size = new System.Drawing.Size(666, 338);
            this.dgcStockIn.TabIndex = 0;
            this.dgcStockIn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStockIn});
            // 
            // bsStockIn
            // 
            this.bsStockIn.DataSource = typeof(Phoebe.Model.StockInModel);
            // 
            // dgvStockIn
            // 
            this.dgvStockIn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStockInId,
            this.colStoreId,
            this.colContractId,
            this.colCargoId,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colSpecification,
            this.colInCount,
            this.colGroupType,
            this.colUnitWeight,
            this.colInWeight,
            this.colUnitVolume,
            this.colInVolume,
            this.colWarehouseNumber,
            this.colOriginPlace,
            this.colShelfLife,
            this.colRemark,
            this.colStatus});
            this.dgvStockIn.GridControl = this.dgcStockIn;
            this.dgvStockIn.Name = "dgvStockIn";
            this.dgvStockIn.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockIn.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockIn.OptionsBehavior.Editable = false;
            this.dgvStockIn.OptionsCustomization.AllowFilter = false;
            this.dgvStockIn.OptionsCustomization.AllowGroup = false;
            this.dgvStockIn.OptionsFilter.AllowFilterEditor = false;
            this.dgvStockIn.OptionsFind.AllowFindPanel = false;
            this.dgvStockIn.OptionsMenu.EnableFooterMenu = false;
            this.dgvStockIn.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStockIn.OptionsView.ShowFooter = true;
            this.dgvStockIn.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.dgvStockIn.OptionsView.ShowGroupPanel = false;
            this.dgvStockIn.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dgvStockIn_CellValueChanging);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStockInId
            // 
            this.colStockInId.FieldName = "StockInId";
            this.colStockInId.Name = "colStockInId";
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
            this.colCategoryNumber.Caption = "类别编码";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 0;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "类别名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 1;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 2;
            // 
            // colInCount
            // 
            this.colInCount.Caption = "入库数量";
            this.colInCount.FieldName = "InCount";
            this.colInCount.Name = "colInCount";
            this.colInCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InCount", "合计={0:0.##}")});
            this.colInCount.Visible = true;
            this.colInCount.VisibleIndex = 3;
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
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 4;
            // 
            // colInWeight
            // 
            this.colInWeight.Caption = "总重量(t)";
            this.colInWeight.DisplayFormat.FormatString = "0.####";
            this.colInWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInWeight.FieldName = "InWeight";
            this.colInWeight.Name = "colInWeight";
            this.colInWeight.OptionsColumn.AllowEdit = false;
            this.colInWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InWeight", "合计={0:0.####}")});
            this.colInWeight.Visible = true;
            this.colInWeight.VisibleIndex = 5;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.000";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 6;
            // 
            // colInVolume
            // 
            this.colInVolume.Caption = "总体积(立方)";
            this.colInVolume.DisplayFormat.FormatString = "0.####";
            this.colInVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInVolume.FieldName = "InVolume";
            this.colInVolume.Name = "colInVolume";
            this.colInVolume.OptionsColumn.AllowEdit = false;
            this.colInVolume.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "InVolume", "合计={0:0.####}")});
            this.colInVolume.Visible = true;
            this.colInVolume.VisibleIndex = 7;
            // 
            // colWarehouseNumber
            // 
            this.colWarehouseNumber.Caption = "仓位编号";
            this.colWarehouseNumber.FieldName = "WarehouseNumber";
            this.colWarehouseNumber.Name = "colWarehouseNumber";
            this.colWarehouseNumber.Visible = true;
            this.colWarehouseNumber.VisibleIndex = 8;
            // 
            // colOriginPlace
            // 
            this.colOriginPlace.Caption = "产地";
            this.colOriginPlace.FieldName = "OriginPlace";
            this.colOriginPlace.Name = "colOriginPlace";
            this.colOriginPlace.Visible = true;
            this.colOriginPlace.VisibleIndex = 9;
            // 
            // colShelfLife
            // 
            this.colShelfLife.Caption = "保质期(月)";
            this.colShelfLife.FieldName = "ShelfLife";
            this.colShelfLife.Name = "colShelfLife";
            this.colShelfLife.Visible = true;
            this.colShelfLife.VisibleIndex = 10;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // StockInGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStockIn);
            this.Name = "StockInGrid";
            this.Size = new System.Drawing.Size(666, 338);
            this.Load += new System.EventHandler(this.StockInGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStockIn;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStockIn;
        private System.Windows.Forms.BindingSource bsStockIn;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockInId;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colInCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colInWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colInVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colWarehouseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLife;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
