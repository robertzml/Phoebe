namespace Phoebe.FormClient
{
    partial class InventoryGrid
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
            this.dgcInventory = new DevExpress.XtraGrid.GridControl();
            this.bsInventory = new System.Windows.Forms.BindingSource(this.components);
            this.dgvInventory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcInventory
            // 
            this.dgcInventory.DataSource = this.bsInventory;
            this.dgcInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcInventory.Location = new System.Drawing.Point(0, 0);
            this.dgcInventory.MainView = this.dgvInventory;
            this.dgcInventory.Name = "dgcInventory";
            this.dgcInventory.Size = new System.Drawing.Size(778, 493);
            this.dgcInventory.TabIndex = 0;
            this.dgcInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvInventory});
            // 
            // bsInventory
            // 
            this.bsInventory.DataSource = typeof(Phoebe.Model.Inventory);
            // 
            // dgvInventory
            // 
            this.dgvInventory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerNumber,
            this.colCustomerName,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colUnitWeight,
            this.colUnitVolume,
            this.colStartTime,
            this.colStartCount,
            this.colStartWeight,
            this.colEndTime,
            this.colEndCount,
            this.colEndWeight});
            this.dgvInventory.GridControl = this.dgcInventory;
            this.dgvInventory.IndicatorWidth = 30;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvInventory.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvInventory.OptionsBehavior.Editable = false;
            this.dgvInventory.OptionsFind.AlwaysVisible = true;
            this.dgvInventory.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvInventory.OptionsView.EnableAppearanceOddRow = true;
            this.dgvInventory.OptionsView.ShowFooter = true;
            this.dgvInventory.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.dgvInventory_CustomDrawRowIndicator);
            this.dgvInventory.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.dgvInventory_PrintInitialize);
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编码";
            this.colCustomerNumber.FieldName = "CustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 0;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "客户姓名";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 1;
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "分类编码";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 2;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 3;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.000";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 4;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.000";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 5;
            // 
            // colStartTime
            // 
            this.colStartTime.Caption = "期初时间";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 6;
            // 
            // colStartCount
            // 
            this.colStartCount.Caption = "期初数量";
            this.colStartCount.FieldName = "StartCount";
            this.colStartCount.Name = "colStartCount";
            this.colStartCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StartCount", "合计={0:0.##}")});
            this.colStartCount.Visible = true;
            this.colStartCount.VisibleIndex = 7;
            // 
            // colStartWeight
            // 
            this.colStartWeight.Caption = "期初重量(t)";
            this.colStartWeight.DisplayFormat.FormatString = "0.0000";
            this.colStartWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartWeight.FieldName = "StartWeight";
            this.colStartWeight.Name = "colStartWeight";
            this.colStartWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StartWeight", "合计={0:0.0000}")});
            this.colStartWeight.Visible = true;
            this.colStartWeight.VisibleIndex = 8;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "期末时间";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 9;
            // 
            // colEndCount
            // 
            this.colEndCount.Caption = "期末数量";
            this.colEndCount.FieldName = "EndCount";
            this.colEndCount.Name = "colEndCount";
            this.colEndCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndCount", "合计={0:0.##}")});
            this.colEndCount.Visible = true;
            this.colEndCount.VisibleIndex = 10;
            // 
            // colEndWeight
            // 
            this.colEndWeight.Caption = "期末重量(t)";
            this.colEndWeight.DisplayFormat.FormatString = "0.0000";
            this.colEndWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEndWeight.FieldName = "EndWeight";
            this.colEndWeight.Name = "colEndWeight";
            this.colEndWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndWeight", "合计={0:0.0000}")});
            this.colEndWeight.Visible = true;
            this.colEndWeight.VisibleIndex = 11;
            // 
            // InventoryGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcInventory);
            this.Name = "InventoryGrid";
            this.Size = new System.Drawing.Size(778, 493);
            ((System.ComponentModel.ISupportInitialize)(this.dgcInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvInventory;
        private System.Windows.Forms.BindingSource bsInventory;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStartCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStartWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndCount;
        private DevExpress.XtraGrid.Columns.GridColumn colEndWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
    }
}
