namespace Phoebe.FormClient
{
    partial class CargoStoreGrid
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
            this.dgcCargo = new DevExpress.XtraGrid.GridControl();
            this.bsCargo = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCargo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStorageDate = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colTotalCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcCargo
            // 
            this.dgcCargo.DataSource = this.bsCargo;
            this.dgcCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcCargo.Location = new System.Drawing.Point(0, 0);
            this.dgcCargo.MainView = this.dgvCargo;
            this.dgcCargo.Name = "dgcCargo";
            this.dgcCargo.Size = new System.Drawing.Size(601, 377);
            this.dgcCargo.TabIndex = 0;
            this.dgcCargo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvCargo});
            // 
            // bsCargo
            // 
            this.bsCargo.DataSource = typeof(Phoebe.Model.CargoStore);
            // 
            // dgvCargo
            // 
            this.dgvCargo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStorageDate,
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
            this.colTotalCount,
            this.colStoreCount,
            this.colUnitWeight,
            this.colStoreWeight,
            this.colUnitVolume,
            this.colStoreVolume});
            this.dgvCargo.GridControl = this.dgcCargo;
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCargo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCargo.OptionsBehavior.Editable = false;
            this.dgvCargo.OptionsCustomization.AllowGroup = false;
            this.dgvCargo.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvCargo.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvCargo.OptionsView.EnableAppearanceOddRow = true;
            this.dgvCargo.OptionsView.ShowFooter = true;
            this.dgvCargo.OptionsView.ShowGroupPanel = false;
            this.dgvCargo.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.dgvCargo_PrintInitialize);
            // 
            // colStorageDate
            // 
            this.colStorageDate.Caption = "日期";
            this.colStorageDate.FieldName = "StorageDate";
            this.colStorageDate.Name = "colStorageDate";
            this.colStorageDate.Visible = true;
            this.colStorageDate.VisibleIndex = 0;
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编号";
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 1;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户名称";
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
            this.colCategoryNumber.Caption = "分类编号";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 4;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
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
            // colTotalCount
            // 
            this.colTotalCount.Caption = "总数量";
            this.colTotalCount.FieldName = "TotalCount";
            this.colTotalCount.Name = "colTotalCount";
            this.colTotalCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCount", "合计={0:0.##}")});
            this.colTotalCount.Visible = true;
            this.colTotalCount.VisibleIndex = 7;
            // 
            // colStoreCount
            // 
            this.colStoreCount.Caption = "在库数量";
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreCount", "合计={0:0.##}")});
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 8;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 9;
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
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 11;
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
            this.colStoreVolume.VisibleIndex = 12;
            // 
            // CargoStoreGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcCargo);
            this.Name = "CargoStoreGrid";
            this.Size = new System.Drawing.Size(601, 377);
            ((System.ComponentModel.ISupportInitialize)(this.dgcCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcCargo;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvCargo;
        private System.Windows.Forms.BindingSource bsCargo;
        private DevExpress.XtraGrid.Columns.GridColumn colStorageDate;
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
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreVolume;
    }
}
