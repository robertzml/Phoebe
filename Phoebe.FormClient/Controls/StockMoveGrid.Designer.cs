namespace Phoebe.FormClient
{
    partial class StockMoveGrid
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
            this.dgcStockMove = new DevExpress.XtraGrid.GridControl();
            this.bsStockMove = new System.Windows.Forms.BindingSource();
            this.dgvStockMove = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockMoveId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSourceStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoveVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSourceWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNewWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOriginPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShelfLife = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMove)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStockMove
            // 
            this.dgcStockMove.DataSource = this.bsStockMove;
            this.dgcStockMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStockMove.Location = new System.Drawing.Point(0, 0);
            this.dgcStockMove.MainView = this.dgvStockMove;
            this.dgcStockMove.Name = "dgcStockMove";
            this.dgcStockMove.Size = new System.Drawing.Size(662, 341);
            this.dgcStockMove.TabIndex = 0;
            this.dgcStockMove.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStockMove});
            // 
            // bsStockMove
            // 
            this.bsStockMove.DataSource = typeof(Phoebe.Model.StockMoveModel);
            // 
            // dgvStockMove
            // 
            this.dgvStockMove.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStockMoveId,
            this.colSourceStoreId,
            this.colNewStoreId,
            this.colContractId,
            this.colCargoId,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colSpecification,
            this.colStoreCount,
            this.colMoveCount,
            this.colGroupType,
            this.colUnitWeight,
            this.colMoveWeight,
            this.colUnitVolume,
            this.colMoveVolume,
            this.colSourceWarehouseNumber,
            this.colNewWarehouseNumber,
            this.colInTime,
            this.colOriginPlace,
            this.colShelfLife,
            this.colRemark,
            this.colStatus});
            this.dgvStockMove.GridControl = this.dgcStockMove;
            this.dgvStockMove.Name = "dgvStockMove";
            this.dgvStockMove.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockMove.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockMove.OptionsBehavior.Editable = false;
            this.dgvStockMove.OptionsCustomization.AllowFilter = false;
            this.dgvStockMove.OptionsCustomization.AllowGroup = false;
            this.dgvStockMove.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvStockMove.OptionsFilter.AllowFilterEditor = false;
            this.dgvStockMove.OptionsFind.AllowFindPanel = false;
            this.dgvStockMove.OptionsMenu.EnableColumnMenu = false;
            this.dgvStockMove.OptionsMenu.EnableFooterMenu = false;
            this.dgvStockMove.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStockMove.OptionsView.ShowGroupPanel = false;
            this.dgvStockMove.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dgvStockMove_CellValueChanging);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStockMoveId
            // 
            this.colStockMoveId.FieldName = "StockMoveId";
            this.colStockMoveId.Name = "colStockMoveId";
            // 
            // colSourceStoreId
            // 
            this.colSourceStoreId.FieldName = "SourceStoreId";
            this.colSourceStoreId.Name = "colSourceStoreId";
            // 
            // colNewStoreId
            // 
            this.colNewStoreId.FieldName = "NewStoreId";
            this.colNewStoreId.Name = "colNewStoreId";
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
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 0;
            // 
            // colCategoryName
            // 
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 1;
            // 
            // colSpecification
            // 
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 2;
            // 
            // colStoreCount
            // 
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 3;
            // 
            // colMoveCount
            // 
            this.colMoveCount.FieldName = "MoveCount";
            this.colMoveCount.Name = "colMoveCount";
            this.colMoveCount.Visible = true;
            this.colMoveCount.VisibleIndex = 4;
            // 
            // colGroupType
            // 
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.Name = "colGroupType";
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 5;
            // 
            // colMoveWeight
            // 
            this.colMoveWeight.FieldName = "MoveWeight";
            this.colMoveWeight.Name = "colMoveWeight";
            this.colMoveWeight.Visible = true;
            this.colMoveWeight.VisibleIndex = 6;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 7;
            // 
            // colMoveVolume
            // 
            this.colMoveVolume.FieldName = "MoveVolume";
            this.colMoveVolume.Name = "colMoveVolume";
            this.colMoveVolume.Visible = true;
            this.colMoveVolume.VisibleIndex = 8;
            // 
            // colSourceWarehouseNumber
            // 
            this.colSourceWarehouseNumber.FieldName = "SourceWarehouseNumber";
            this.colSourceWarehouseNumber.Name = "colSourceWarehouseNumber";
            this.colSourceWarehouseNumber.Visible = true;
            this.colSourceWarehouseNumber.VisibleIndex = 9;
            // 
            // colNewWarehouseNumber
            // 
            this.colNewWarehouseNumber.FieldName = "NewWarehouseNumber";
            this.colNewWarehouseNumber.Name = "colNewWarehouseNumber";
            this.colNewWarehouseNumber.Visible = true;
            this.colNewWarehouseNumber.VisibleIndex = 10;
            // 
            // colInTime
            // 
            this.colInTime.FieldName = "InTime";
            this.colInTime.Name = "colInTime";
            this.colInTime.Visible = true;
            this.colInTime.VisibleIndex = 11;
            // 
            // colOriginPlace
            // 
            this.colOriginPlace.FieldName = "OriginPlace";
            this.colOriginPlace.Name = "colOriginPlace";
            this.colOriginPlace.Visible = true;
            this.colOriginPlace.VisibleIndex = 12;
            // 
            // colShelfLife
            // 
            this.colShelfLife.FieldName = "ShelfLife";
            this.colShelfLife.Name = "colShelfLife";
            this.colShelfLife.Visible = true;
            this.colShelfLife.VisibleIndex = 13;
            // 
            // colRemark
            // 
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 14;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // StockMoveGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStockMove);
            this.Name = "StockMoveGrid";
            this.Size = new System.Drawing.Size(662, 341);
            this.Load += new System.EventHandler(this.StockMoveGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStockMove;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStockMove;
        private System.Windows.Forms.BindingSource bsStockMove;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockMoveId;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colNewStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveCount;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colMoveVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colSourceWarehouseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colNewWarehouseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colOriginPlace;
        private DevExpress.XtraGrid.Columns.GridColumn colShelfLife;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
