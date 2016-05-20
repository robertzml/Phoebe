namespace Phoebe.FormClient
{
    partial class StockFlowGrid
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
            this.dgcStockFlow = new DevExpress.XtraGrid.GridControl();
            this.bsStockFlow = new System.Windows.Forms.BindingSource(this.components);
            this.dgvStockFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStockId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowNumber = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colFlowWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStockFlow
            // 
            this.dgcStockFlow.DataSource = this.bsStockFlow;
            this.dgcStockFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStockFlow.Location = new System.Drawing.Point(0, 0);
            this.dgcStockFlow.MainView = this.dgvStockFlow;
            this.dgcStockFlow.Name = "dgcStockFlow";
            this.dgcStockFlow.Size = new System.Drawing.Size(740, 298);
            this.dgcStockFlow.TabIndex = 0;
            this.dgcStockFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStockFlow});
            // 
            // bsStockFlow
            // 
            this.bsStockFlow.DataSource = typeof(Phoebe.Model.StockFlow);
            // 
            // dgvStockFlow
            // 
            this.dgvStockFlow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStockId,
            this.colFlowNumber,
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
            this.colFlowWeight,
            this.colUnitVolume,
            this.colFlowVolume,
            this.colFlowDate,
            this.colType});
            this.dgvStockFlow.GridControl = this.dgcStockFlow;
            this.dgvStockFlow.Name = "dgvStockFlow";
            this.dgvStockFlow.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockFlow.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStockFlow.OptionsBehavior.Editable = false;
            this.dgvStockFlow.OptionsCustomization.AllowGroup = false;
            this.dgvStockFlow.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvStockFlow.OptionsFind.AllowFindPanel = false;
            this.dgvStockFlow.OptionsMenu.EnableColumnMenu = false;
            this.dgvStockFlow.OptionsMenu.EnableFooterMenu = false;
            this.dgvStockFlow.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStockFlow.OptionsView.ShowGroupPanel = false;
            // 
            // colStockId
            // 
            this.colStockId.FieldName = "StockId";
            this.colStockId.Name = "colStockId";
            // 
            // colFlowNumber
            // 
            this.colFlowNumber.Caption = "流水单号";
            this.colFlowNumber.FieldName = "FlowNumber";
            this.colFlowNumber.Name = "colFlowNumber";
            this.colFlowNumber.Visible = true;
            this.colFlowNumber.VisibleIndex = 2;
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编码";
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 3;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户姓名";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
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
            this.colContractName.VisibleIndex = 5;
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
            this.colCategoryNumber.VisibleIndex = 6;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "类别名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 7;
            // 
            // colSpecification
            // 
            this.colSpecification.Caption = "规格";
            this.colSpecification.FieldName = "Specification";
            this.colSpecification.Name = "colSpecification";
            this.colSpecification.Visible = true;
            this.colSpecification.VisibleIndex = 8;
            // 
            // colCount
            // 
            this.colCount.Caption = "流水数量";
            this.colCount.FieldName = "Count";
            this.colCount.Name = "colCount";
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 9;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 10;
            // 
            // colFlowWeight
            // 
            this.colFlowWeight.Caption = "流水重量(t)";
            this.colFlowWeight.DisplayFormat.FormatString = "0.####";
            this.colFlowWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowWeight.FieldName = "FlowWeight";
            this.colFlowWeight.Name = "colFlowWeight";
            this.colFlowWeight.Visible = true;
            this.colFlowWeight.VisibleIndex = 11;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.###";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 12;
            // 
            // colFlowVolume
            // 
            this.colFlowVolume.Caption = "流水体积(立方)";
            this.colFlowVolume.DisplayFormat.FormatString = "0.####";
            this.colFlowVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowVolume.FieldName = "FlowVolume";
            this.colFlowVolume.Name = "colFlowVolume";
            this.colFlowVolume.Visible = true;
            this.colFlowVolume.VisibleIndex = 13;
            // 
            // colFlowDate
            // 
            this.colFlowDate.Caption = "流水日期";
            this.colFlowDate.FieldName = "FlowDate";
            this.colFlowDate.Name = "colFlowDate";
            this.colFlowDate.Visible = true;
            this.colFlowDate.VisibleIndex = 0;
            // 
            // colType
            // 
            this.colType.Caption = "流水类型";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 1;
            // 
            // StockFlowGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStockFlow);
            this.Name = "StockFlowGrid";
            this.Size = new System.Drawing.Size(740, 298);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStockFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStockFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStockFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStockFlow;
        private System.Windows.Forms.BindingSource bsStockFlow;
        private DevExpress.XtraGrid.Columns.GridColumn colStockId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowNumber;
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
        private DevExpress.XtraGrid.Columns.GridColumn colFlowWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowDate;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
    }
}
