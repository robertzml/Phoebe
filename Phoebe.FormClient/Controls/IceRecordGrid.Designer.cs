namespace Phoebe.FormClient
{
    partial class IceRecordGrid
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
            this.dgcIce = new DevExpress.XtraGrid.GridControl();
            this.bsIceRecord = new System.Windows.Forms.BindingSource(this.components);
            this.dgvIce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcIce
            // 
            this.dgcIce.DataSource = this.bsIceRecord;
            this.dgcIce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcIce.Location = new System.Drawing.Point(0, 0);
            this.dgcIce.MainView = this.dgvIce;
            this.dgcIce.Name = "dgcIce";
            this.dgcIce.Size = new System.Drawing.Size(660, 431);
            this.dgcIce.TabIndex = 0;
            this.dgcIce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIce});
            // 
            // bsIceRecord
            // 
            this.bsIceRecord.DataSource = typeof(Phoebe.Model.IceRecord);
            // 
            // dgvIce
            // 
            this.dgvIce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIceType,
            this.colFlowCount,
            this.colFlowWeight,
            this.colSaleUnitPrice,
            this.colSaleFee,
            this.colRemark});
            this.dgvIce.GridControl = this.dgcIce;
            this.dgvIce.Name = "dgvIce";
            this.dgvIce.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsCustomization.AllowFilter = false;
            this.dgvIce.OptionsCustomization.AllowGroup = false;
            this.dgvIce.OptionsCustomization.AllowSort = false;
            this.dgvIce.OptionsFind.AllowFindPanel = false;
            this.dgvIce.OptionsMenu.EnableColumnMenu = false;
            this.dgvIce.OptionsMenu.EnableFooterMenu = false;
            this.dgvIce.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvIce.OptionsView.ShowFooter = true;
            this.dgvIce.OptionsView.ShowGroupPanel = false;
            this.dgvIce.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dgvIce_CellValueChanging);
            this.dgvIce.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvIce_CustomColumnDisplayText);
            // 
            // colIceType
            // 
            this.colIceType.AppearanceCell.Options.UseTextOptions = true;
            this.colIceType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIceType.Caption = "冰块类型";
            this.colIceType.FieldName = "IceType";
            this.colIceType.Name = "colIceType";
            this.colIceType.OptionsColumn.AllowEdit = false;
            this.colIceType.Visible = true;
            this.colIceType.VisibleIndex = 0;
            // 
            // colFlowCount
            // 
            this.colFlowCount.Caption = "流水数量";
            this.colFlowCount.FieldName = "FlowCount";
            this.colFlowCount.Name = "colFlowCount";
            this.colFlowCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FlowCount", "合计={0:0.##}")});
            this.colFlowCount.Visible = true;
            this.colFlowCount.VisibleIndex = 1;
            // 
            // colFlowWeight
            // 
            this.colFlowWeight.Caption = "流水重量(t)";
            this.colFlowWeight.DisplayFormat.FormatString = "0.000";
            this.colFlowWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowWeight.FieldName = "FlowWeight";
            this.colFlowWeight.Name = "colFlowWeight";
            this.colFlowWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FlowWeight", "合计={0:0.000}")});
            this.colFlowWeight.Visible = true;
            this.colFlowWeight.VisibleIndex = 2;
            // 
            // colSaleUnitPrice
            // 
            this.colSaleUnitPrice.Caption = "销售单价(元/袋)";
            this.colSaleUnitPrice.DisplayFormat.FormatString = "0.00";
            this.colSaleUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleUnitPrice.FieldName = "SaleUnitPrice";
            this.colSaleUnitPrice.Name = "colSaleUnitPrice";
            this.colSaleUnitPrice.Visible = true;
            this.colSaleUnitPrice.VisibleIndex = 3;
            // 
            // colSaleFee
            // 
            this.colSaleFee.Caption = "销售金额(元)";
            this.colSaleFee.DisplayFormat.FormatString = "0.##";
            this.colSaleFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleFee.FieldName = "SaleFee";
            this.colSaleFee.Name = "colSaleFee";
            this.colSaleFee.OptionsColumn.ReadOnly = true;
            this.colSaleFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleFee", "合计={0:0.##}")});
            this.colSaleFee.Visible = true;
            this.colSaleFee.VisibleIndex = 4;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // IceRecordGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceRecordGrid";
            this.Size = new System.Drawing.Size(660, 431);
            this.Load += new System.EventHandler(this.IceRecordGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcIce;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIce;
        private System.Windows.Forms.BindingSource bsIceRecord;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowCount;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleFee;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
