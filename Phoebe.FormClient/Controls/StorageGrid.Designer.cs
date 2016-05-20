namespace Phoebe.FormClient
{
    partial class StorageGrid
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
            this.dgcStorage = new DevExpress.XtraGrid.GridControl();
            this.bsStorage = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStorage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStorageDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStorage
            // 
            this.dgcStorage.DataSource = this.bsStorage;
            this.dgcStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStorage.Location = new System.Drawing.Point(0, 0);
            this.dgcStorage.MainView = this.dgvStorage;
            this.dgcStorage.Name = "dgcStorage";
            this.dgcStorage.Size = new System.Drawing.Size(714, 370);
            this.dgcStorage.TabIndex = 0;
            this.dgcStorage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStorage});
            // 
            // bsStorage
            // 
            this.bsStorage.DataSource = typeof(Phoebe.Model.Storage);
            // 
            // dgvStorage
            // 
            this.dgvStorage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStorageDate,
            this.colStoreId,
            this.colCustomerId,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colContractId,
            this.colContractName,
            this.colCargoId,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colSpecification,
            this.colCount,
            this.colUnitWeight,
            this.colStoreWeight,
            this.colUnitVolume,
            this.colStoreVolume,
            this.colNumber,
            this.colInTime,
            this.colSource,
            this.colRemark});
            this.dgvStorage.GridControl = this.dgcStorage;
            this.dgvStorage.Name = "dgvStorage";
            this.dgvStorage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.Editable = false;
            this.dgvStorage.OptionsCustomization.AllowGroup = false;
            this.dgvStorage.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStorage.OptionsView.ShowFooter = true;
            this.dgvStorage.OptionsView.ShowGroupPanel = false;
            // 
            // colStorageDate
            // 
            this.colStorageDate.Caption = "库存日期";
            this.colStorageDate.FieldName = "StorageDate";
            this.colStorageDate.Name = "colStorageDate";
            this.colStorageDate.Visible = true;
            this.colStorageDate.VisibleIndex = 0;
            // 
            // colStoreId
            // 
            this.colStoreId.FieldName = "StoreId";
            this.colStoreId.Name = "colStoreId";
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户代码";
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 1;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户姓名";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 2;
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
            this.colContractName.VisibleIndex = 3;
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
            this.colCategoryNumber.VisibleIndex = 4;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "类别名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 5;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 6;
            // 
            // colCount
            // 
            this.colCount.Caption = "在库数量";
            this.colCount.FieldName = "Count";
            this.colCount.Name = "colCount";
            this.colCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Count", "合计={0:0.##}")});
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 7;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 8;
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
            this.colStoreWeight.VisibleIndex = 9;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.###";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 10;
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
            this.colStoreVolume.VisibleIndex = 11;
            // 
            // colNumber
            // 
            this.colNumber.Caption = "库位编号";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 12;
            // 
            // colInTime
            // 
            this.colInTime.Caption = "入库时间";
            this.colInTime.FieldName = "InTime";
            this.colInTime.Name = "colInTime";
            this.colInTime.Visible = true;
            this.colInTime.VisibleIndex = 13;
            // 
            // colSource
            // 
            this.colSource.Caption = "来源";
            this.colSource.FieldName = "Source";
            this.colSource.Name = "colSource";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 14;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 15;
            // 
            // StorageGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStorage);
            this.Name = "StorageGrid";
            this.Size = new System.Drawing.Size(714, 370);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStorage;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStorage;
        private System.Windows.Forms.BindingSource bsStorage;
        private DevExpress.XtraGrid.Columns.GridColumn colStorageDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colCargoId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colInTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
