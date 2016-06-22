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
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colCustomerId,
            this.colFlowId,
            this.colSaleTime,
            this.colIceType,
            this.colSaleCount,
            this.colSaleWeight,
            this.colSaleFee,
            this.colUserId,
            this.colCreateTime,
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
            // colCustomerId
            // 
            this.colCustomerId.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCustomerId.Caption = "客户";
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 0;
            // 
            // colFlowId
            // 
            this.colFlowId.FieldName = "FlowId";
            this.colFlowId.Name = "colFlowId";
            // 
            // colSaleTime
            // 
            this.colSaleTime.Caption = "售出日期";
            this.colSaleTime.FieldName = "SaleTime";
            this.colSaleTime.Name = "colSaleTime";
            this.colSaleTime.Visible = true;
            this.colSaleTime.VisibleIndex = 1;
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
            this.colIceType.VisibleIndex = 2;
            // 
            // colSaleCount
            // 
            this.colSaleCount.Caption = "售出数量";
            this.colSaleCount.FieldName = "SaleCount";
            this.colSaleCount.Name = "colSaleCount";
            this.colSaleCount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaleCount", "合计={0:0.##}")});
            this.colSaleCount.Visible = true;
            this.colSaleCount.VisibleIndex = 3;
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
            this.colSaleWeight.VisibleIndex = 4;
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
            this.colSaleFee.VisibleIndex = 5;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "操作人";
            this.colUserId.FieldName = "UserId";
            this.colUserId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 6;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 7;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // IceSaleGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceSaleGridControl";
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
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowId;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCount;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleFee;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}
