namespace Phoebe.FormClient
{
    partial class IceSaleGrid
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
            this.bsIceSale = new System.Windows.Forms.BindingSource(this.components);
            this.dgvIce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcIce
            // 
            this.dgcIce.DataSource = this.bsIceSale;
            this.dgcIce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcIce.Location = new System.Drawing.Point(0, 0);
            this.dgcIce.MainView = this.dgvIce;
            this.dgcIce.Name = "dgcIce";
            this.dgcIce.Size = new System.Drawing.Size(770, 396);
            this.dgcIce.TabIndex = 0;
            this.dgcIce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIce});
            // 
            // bsIceSale
            // 
            this.bsIceSale.DataSource = typeof(Phoebe.Model.IceSale);
            // 
            // dgvIce
            // 
            this.dgvIce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFlowId,
            this.colIceType,
            this.colSaleCount,
            this.colSaleWeight,
            this.colSaleUnitPrice,
            this.colSaleFee,
            this.colRemark,
            this.colStatus});
            this.dgvIce.GridControl = this.dgcIce;
            this.dgvIce.Name = "dgvIce";
            this.dgvIce.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.Editable = false;
            this.dgvIce.OptionsFind.AlwaysVisible = true;
            this.dgvIce.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvIce.OptionsView.EnableAppearanceOddRow = true;
            this.dgvIce.OptionsView.ShowFooter = true;
            this.dgvIce.OptionsView.ShowGroupPanel = false;
            this.dgvIce.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvIce_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFlowId
            // 
            this.colFlowId.FieldName = "FlowId";
            this.colFlowId.Name = "colFlowId";
            // 
            // colIceType
            // 
            this.colIceType.AppearanceCell.Options.UseTextOptions = true;
            this.colIceType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIceType.Caption = "冰块类型";
            this.colIceType.FieldName = "IceType";
            this.colIceType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colIceType.Name = "colIceType";
            this.colIceType.Visible = true;
            this.colIceType.VisibleIndex = 0;
            // 
            // colSaleCount
            // 
            this.colSaleCount.Caption = "售出数量";
            this.colSaleCount.FieldName = "SaleCount";
            this.colSaleCount.Name = "colSaleCount";
            this.colSaleCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleCount", "合计={0:0.##}")});
            this.colSaleCount.Visible = true;
            this.colSaleCount.VisibleIndex = 1;
            // 
            // colSaleWeight
            // 
            this.colSaleWeight.Caption = "售出重量(t)";
            this.colSaleWeight.DisplayFormat.FormatString = "0.000";
            this.colSaleWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleWeight.FieldName = "SaleWeight";
            this.colSaleWeight.Name = "colSaleWeight";
            this.colSaleWeight.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleWeight", "合计={0:0.000}")});
            this.colSaleWeight.Visible = true;
            this.colSaleWeight.VisibleIndex = 2;
            // 
            // colSaleUnitPrice
            // 
            this.colSaleUnitPrice.Caption = "单价";
            this.colSaleUnitPrice.FieldName = "SaleUnitPrice";
            this.colSaleUnitPrice.Name = "colSaleUnitPrice";
            this.colSaleUnitPrice.Visible = true;
            this.colSaleUnitPrice.VisibleIndex = 3;
            // 
            // colSaleFee
            // 
            this.colSaleFee.Caption = "售出金额(元)";
            this.colSaleFee.DisplayFormat.FormatString = "0.00";
            this.colSaleFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaleFee.FieldName = "SaleFee";
            this.colSaleFee.Name = "colSaleFee";
            this.colSaleFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleFee", "合计={0:0.00}")});
            this.colSaleFee.Visible = true;
            this.colSaleFee.VisibleIndex = 4;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // IceSaleGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceSaleGrid";
            this.Size = new System.Drawing.Size(770, 396);
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcIce;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIce;
        private System.Windows.Forms.BindingSource bsIceSale;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowId;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleFee;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleUnitPrice;
    }
}
