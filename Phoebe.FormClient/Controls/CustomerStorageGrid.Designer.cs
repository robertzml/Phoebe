namespace Phoebe.FormClient
{
    partial class CustomerStorageGrid
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
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecification = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreVolume = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.dgcStorage.Size = new System.Drawing.Size(793, 464);
            this.dgcStorage.TabIndex = 0;
            this.dgcStorage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStorage});
            // 
            // bsStorage
            // 
            this.bsStorage.DataSource = typeof(Phoebe.Model.CustomerStorage);
            // 
            // dgvStorage
            // 
            this.dgvStorage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStorageDate,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colCustomerId,
            this.colCustomerName,
            this.colCustomerNumber,
            this.colSpecification,
            this.colUnitWeight,
            this.colUnitVolume,
            this.colStoreCount,
            this.colStoreWeight,
            this.colStoreVolume});
            this.dgvStorage.GridControl = this.dgcStorage;
            this.dgvStorage.Name = "dgvStorage";
            this.dgvStorage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.Editable = false;
            this.dgvStorage.OptionsCustomization.AllowGroup = false;
            this.dgvStorage.OptionsFind.AllowFindPanel = false;
            this.dgvStorage.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStorage.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvStorage.OptionsView.EnableAppearanceOddRow = true;
            this.dgvStorage.OptionsView.ShowFooter = true;
            this.dgvStorage.OptionsView.ShowGroupPanel = false;
            this.dgvStorage.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.dgvStorage_PrintInitialize);
            // 
            // colStorageDate
            // 
            this.colStorageDate.Caption = "日期";
            this.colStorageDate.FieldName = "StorageDate";
            this.colStorageDate.Name = "colStorageDate";
            this.colStorageDate.Visible = true;
            this.colStorageDate.VisibleIndex = 0;
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
            this.colCategoryNumber.VisibleIndex = 1;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 2;
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户姓名";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编号";
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 3;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量";
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积";
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            // 
            // colStoreCount
            // 
            this.colStoreCount.Caption = "在库数量";
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreCount", "合计={0:0.##}")});
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 5;
            // 
            // colStoreWeight
            // 
            this.colStoreWeight.Caption = "在库重量(t)";
            this.colStoreWeight.DisplayFormat.FormatString = "0.000";
            this.colStoreWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStoreWeight.FieldName = "StoreWeight";
            this.colStoreWeight.Name = "colStoreWeight";
            this.colStoreWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreWeight", "合计={0:0.000}")});
            this.colStoreWeight.Visible = true;
            this.colStoreWeight.VisibleIndex = 6;
            // 
            // colStoreVolume
            // 
            this.colStoreVolume.Caption = "在库体积(立方)";
            this.colStoreVolume.DisplayFormat.FormatString = "0.000";
            this.colStoreVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStoreVolume.FieldName = "StoreVolume";
            this.colStoreVolume.Name = "colStoreVolume";
            this.colStoreVolume.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StoreVolume", "合计={0:0.000}")});
            this.colStoreVolume.Visible = true;
            this.colStoreVolume.VisibleIndex = 7;
            // 
            // CustomerStorageGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStorage);
            this.Name = "CustomerStorageGrid";
            this.Size = new System.Drawing.Size(793, 464);
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
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecification;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreVolume;
    }
}
