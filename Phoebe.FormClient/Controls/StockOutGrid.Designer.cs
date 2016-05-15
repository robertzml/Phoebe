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
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWarehouseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colStoreCount,
            this.colOutCount,
            this.colGroupType,
            this.colUnitWeight,
            this.colOutWeight,
            this.colUnitVolume,
            this.colOutVolume,
            this.colWarehouseNumber,
            this.colInTime,
            this.colOriginPlace,
            this.colShelfLife,
            this.colRemark,
            this.colStatus});
            this.dgvStockOut.GridControl = this.dgcStockOut;
            this.dgvStockOut.Name = "dgvStockOut";
            this.dgvStockOut.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockOut.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockOut.OptionsFilter.AllowFilterEditor = false;
            this.dgvStockOut.OptionsFind.AllowFindPanel = false;
            this.dgvStockOut.OptionsView.ShowFooter = true;
            this.dgvStockOut.OptionsView.ShowGroupPanel = false;
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
            // colOutCount
            // 
            this.colOutCount.FieldName = "OutCount";
            this.colOutCount.Name = "colOutCount";
            this.colOutCount.Visible = true;
            this.colOutCount.VisibleIndex = 4;
            // 
            // colGroupType
            // 
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.Visible = true;
            this.colGroupType.VisibleIndex = 5;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 6;
            // 
            // colOutWeight
            // 
            this.colOutWeight.FieldName = "OutWeight";
            this.colOutWeight.Name = "colOutWeight";
            this.colOutWeight.Visible = true;
            this.colOutWeight.VisibleIndex = 7;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 8;
            // 
            // colOutVolume
            // 
            this.colOutVolume.FieldName = "OutVolume";
            this.colOutVolume.Name = "colOutVolume";
            this.colOutVolume.Visible = true;
            this.colOutVolume.VisibleIndex = 9;
            // 
            // colWarehouseNumber
            // 
            this.colWarehouseNumber.FieldName = "WarehouseNumber";
            this.colWarehouseNumber.Name = "colWarehouseNumber";
            this.colWarehouseNumber.Visible = true;
            this.colWarehouseNumber.VisibleIndex = 10;
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
    }
}
