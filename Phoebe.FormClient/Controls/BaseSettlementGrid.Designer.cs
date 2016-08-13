namespace Phoebe.FormClient
{
    partial class BaseSettlementGrid
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
            this.dgcBase = new DevExpress.XtraGrid.GridControl();
            this.bsBaseSettle = new System.Windows.Forms.BindingSource(this.components);
            this.dgvBase = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTakeTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandlingUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHandlingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreezeUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreezePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDisposePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPackingPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRentPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOtherPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBaseSettle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcBase
            // 
            this.dgcBase.DataSource = this.bsBaseSettle;
            this.dgcBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcBase.Location = new System.Drawing.Point(0, 0);
            this.dgcBase.MainView = this.dgvBase;
            this.dgcBase.Name = "dgcBase";
            this.dgcBase.Size = new System.Drawing.Size(795, 428);
            this.dgcBase.TabIndex = 0;
            this.dgcBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvBase});
            // 
            // bsBaseSettle
            // 
            this.bsBaseSettle.DataSource = typeof(Phoebe.Model.BaseSettlement);
            // 
            // dgvBase
            // 
            this.dgvBase.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractId,
            this.colContractName,
            this.colTakeTime,
            this.colUnitPrice,
            this.colHandlingUnitPrice,
            this.colHandlingPrice,
            this.colFreezeUnitPrice,
            this.colFreezePrice,
            this.colDisposePrice,
            this.colPackingPrice,
            this.colRentPrice,
            this.colOtherPrice,
            this.colTotalPrice,
            this.colRemark});
            this.dgvBase.GridControl = this.dgcBase;
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvBase.OptionsBehavior.Editable = false;
            this.dgvBase.OptionsFilter.AllowFilterEditor = false;
            this.dgvBase.OptionsFind.AllowFindPanel = false;
            this.dgvBase.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvBase.OptionsView.EnableAppearanceOddRow = true;
            this.dgvBase.OptionsView.ShowFooter = true;
            this.dgvBase.OptionsView.ShowGroupPanel = false;
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
            this.colContractName.VisibleIndex = 0;
            // 
            // colTakeTime
            // 
            this.colTakeTime.Caption = "产生日期";
            this.colTakeTime.FieldName = "TakeTime";
            this.colTakeTime.Name = "colTakeTime";
            this.colTakeTime.Visible = true;
            this.colTakeTime.VisibleIndex = 1;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Caption = "冷藏费单价";
            this.colUnitPrice.DisplayFormat.FormatString = "0.##";
            this.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitPrice.FieldName = "UnitPrice";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Visible = true;
            this.colUnitPrice.VisibleIndex = 2;
            // 
            // colHandlingUnitPrice
            // 
            this.colHandlingUnitPrice.Caption = "装卸费单价";
            this.colHandlingUnitPrice.DisplayFormat.FormatString = "0.##";
            this.colHandlingUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHandlingUnitPrice.FieldName = "HandlingUnitPrice";
            this.colHandlingUnitPrice.Name = "colHandlingUnitPrice";
            this.colHandlingUnitPrice.Visible = true;
            this.colHandlingUnitPrice.VisibleIndex = 3;
            // 
            // colHandlingPrice
            // 
            this.colHandlingPrice.Caption = "装卸费(元)";
            this.colHandlingPrice.DisplayFormat.FormatString = "0.##";
            this.colHandlingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colHandlingPrice.FieldName = "HandlingPrice";
            this.colHandlingPrice.Name = "colHandlingPrice";
            this.colHandlingPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "HandlingPrice", "合计={0:0.##}")});
            this.colHandlingPrice.Visible = true;
            this.colHandlingPrice.VisibleIndex = 4;
            // 
            // colFreezeUnitPrice
            // 
            this.colFreezeUnitPrice.Caption = "结冻费单价";
            this.colFreezeUnitPrice.DisplayFormat.FormatString = "0.##";
            this.colFreezeUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFreezeUnitPrice.FieldName = "FreezeUnitPrice";
            this.colFreezeUnitPrice.Name = "colFreezeUnitPrice";
            this.colFreezeUnitPrice.Visible = true;
            this.colFreezeUnitPrice.VisibleIndex = 5;
            // 
            // colFreezePrice
            // 
            this.colFreezePrice.Caption = "结冻费(元)";
            this.colFreezePrice.DisplayFormat.FormatString = "0.##";
            this.colFreezePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFreezePrice.FieldName = "FreezePrice";
            this.colFreezePrice.Name = "colFreezePrice";
            this.colFreezePrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FreezePrice", "合计={0:0.##}")});
            this.colFreezePrice.Visible = true;
            this.colFreezePrice.VisibleIndex = 6;
            // 
            // colDisposePrice
            // 
            this.colDisposePrice.Caption = "处置费(元)";
            this.colDisposePrice.DisplayFormat.FormatString = "0.##";
            this.colDisposePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDisposePrice.FieldName = "DisposePrice";
            this.colDisposePrice.Name = "colDisposePrice";
            this.colDisposePrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DisposePrice", "合计={0:0.##}")});
            this.colDisposePrice.Visible = true;
            this.colDisposePrice.VisibleIndex = 7;
            // 
            // colPackingPrice
            // 
            this.colPackingPrice.Caption = "包装费(元)";
            this.colPackingPrice.DisplayFormat.FormatString = "0.##";
            this.colPackingPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPackingPrice.FieldName = "PackingPrice";
            this.colPackingPrice.Name = "colPackingPrice";
            this.colPackingPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PackingPrice", "合计={0:0.##}")});
            this.colPackingPrice.Visible = true;
            this.colPackingPrice.VisibleIndex = 8;
            // 
            // colRentPrice
            // 
            this.colRentPrice.Caption = "租赁费(元)";
            this.colRentPrice.DisplayFormat.FormatString = "0.##";
            this.colRentPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRentPrice.FieldName = "RentPrice";
            this.colRentPrice.Name = "colRentPrice";
            this.colRentPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RentPrice", "合计={0:0.##}")});
            this.colRentPrice.Visible = true;
            this.colRentPrice.VisibleIndex = 9;
            // 
            // colOtherPrice
            // 
            this.colOtherPrice.Caption = "其它费用(元)";
            this.colOtherPrice.DisplayFormat.FormatString = "0.##";
            this.colOtherPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOtherPrice.FieldName = "OtherPrice";
            this.colOtherPrice.Name = "colOtherPrice";
            this.colOtherPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "OtherPrice", "合计={0:0.##}")});
            this.colOtherPrice.Visible = true;
            this.colOtherPrice.VisibleIndex = 10;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.Caption = "费用总计(元)";
            this.colTotalPrice.DisplayFormat.FormatString = "0.##";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "合计={0:0.##}")});
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 11;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            // 
            // BaseSettlementGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcBase);
            this.Name = "BaseSettlementGrid";
            this.Size = new System.Drawing.Size(795, 428);
            ((System.ComponentModel.ISupportInitialize)(this.dgcBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBaseSettle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcBase;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvBase;
        private System.Windows.Forms.BindingSource bsBaseSettle;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colTakeTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colHandlingUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colHandlingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colFreezeUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colFreezePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colDisposePrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPackingPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRentPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOtherPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
