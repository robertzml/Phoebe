namespace Phoebe.FormClient
{
    partial class CustomerFeeGrid
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
            this.dgcFee = new DevExpress.XtraGrid.GridControl();
            this.bsFee = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFee = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartDebt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColdFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiscFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReceiveFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndDebt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcFee
            // 
            this.dgcFee.DataSource = this.bsFee;
            this.dgcFee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcFee.Location = new System.Drawing.Point(0, 0);
            this.dgcFee.MainView = this.dgvFee;
            this.dgcFee.Name = "dgcFee";
            this.dgcFee.Size = new System.Drawing.Size(742, 408);
            this.dgcFee.TabIndex = 0;
            this.dgcFee.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvFee});
            // 
            // bsFee
            // 
            this.bsFee.DataSource = typeof(Phoebe.Model.CustomerFee);
            // 
            // dgvFee
            // 
            this.dgvFee.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerId,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colStartTime,
            this.colEndTime,
            this.colStartDebt,
            this.colBaseFee,
            this.colColdFee,
            this.colMiscFee,
            this.colTotalFee,
            this.colReceiveFee,
            this.colDiscount,
            this.colEndDebt,
            this.colRemark});
            this.dgvFee.GridControl = this.dgcFee;
            this.dgvFee.Name = "dgvFee";
            this.dgvFee.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvFee.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvFee.OptionsBehavior.Editable = false;
            this.dgvFee.OptionsCustomization.AllowGroup = false;
            this.dgvFee.OptionsFind.AllowFindPanel = false;
            this.dgvFee.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvFee.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvFee.OptionsView.EnableAppearanceOddRow = true;
            this.dgvFee.OptionsView.ShowFooter = true;
            this.dgvFee.OptionsView.ShowGroupPanel = false;
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
            // colStartTime
            // 
            this.colStartTime.Caption = "期初时间";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 2;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "期末时间";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 3;
            // 
            // colStartDebt
            // 
            this.colStartDebt.Caption = "期初欠款(元)";
            this.colStartDebt.DisplayFormat.FormatString = "0.00";
            this.colStartDebt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStartDebt.FieldName = "StartDebt";
            this.colStartDebt.Name = "colStartDebt";
            this.colStartDebt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "StartDebt", "合计={0:0.00}")});
            this.colStartDebt.Visible = true;
            this.colStartDebt.VisibleIndex = 4;
            // 
            // colBaseFee
            // 
            this.colBaseFee.Caption = "基本费用(元)";
            this.colBaseFee.DisplayFormat.FormatString = "0.00";
            this.colBaseFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBaseFee.FieldName = "BaseFee";
            this.colBaseFee.Name = "colBaseFee";
            this.colBaseFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BaseFee", "合计={0:0.00}")});
            this.colBaseFee.Visible = true;
            this.colBaseFee.VisibleIndex = 5;
            // 
            // colColdFee
            // 
            this.colColdFee.Caption = "冷藏费用(元)";
            this.colColdFee.DisplayFormat.FormatString = "0.00";
            this.colColdFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colColdFee.FieldName = "ColdFee";
            this.colColdFee.Name = "colColdFee";
            this.colColdFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ColdFee", "合计={0:0.00}")});
            this.colColdFee.Visible = true;
            this.colColdFee.VisibleIndex = 6;
            // 
            // colMiscFee
            // 
            this.colMiscFee.Caption = "杂项费用(元)";
            this.colMiscFee.DisplayFormat.FormatString = "0.00";
            this.colMiscFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMiscFee.FieldName = "MiscFee";
            this.colMiscFee.Name = "colMiscFee";
            this.colMiscFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MiscFee", "合计={0:0.00}")});
            this.colMiscFee.Visible = true;
            this.colMiscFee.VisibleIndex = 7;
            // 
            // colTotalFee
            // 
            this.colTotalFee.Caption = "费用合计(元)";
            this.colTotalFee.DisplayFormat.FormatString = "0.00";
            this.colTotalFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFee.FieldName = "TotalFee";
            this.colTotalFee.Name = "colTotalFee";
            this.colTotalFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalFee", "合计={0:0.00}")});
            this.colTotalFee.Visible = true;
            this.colTotalFee.VisibleIndex = 8;
            // 
            // colReceiveFee
            // 
            this.colReceiveFee.Caption = "回收款(元)";
            this.colReceiveFee.FieldName = "ReceiveFee";
            this.colReceiveFee.Name = "colReceiveFee";
            this.colReceiveFee.Visible = true;
            this.colReceiveFee.VisibleIndex = 9;
            // 
            // colDiscount
            // 
            this.colDiscount.Caption = "折扣(元)";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 10;
            // 
            // colEndDebt
            // 
            this.colEndDebt.Caption = "期末欠款(元)";
            this.colEndDebt.DisplayFormat.FormatString = "0.00";
            this.colEndDebt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEndDebt.FieldName = "EndDebt";
            this.colEndDebt.Name = "colEndDebt";
            this.colEndDebt.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EndDebt", "合计={0:0.00}")});
            this.colEndDebt.Visible = true;
            this.colEndDebt.VisibleIndex = 11;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 12;
            // 
            // CustomerFeeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcFee);
            this.Name = "CustomerFeeGrid";
            this.Size = new System.Drawing.Size(742, 408);
            ((System.ComponentModel.ISupportInitialize)(this.dgcFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcFee;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvFee;
        private System.Windows.Forms.BindingSource bsFee;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStartDebt;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseFee;
        private DevExpress.XtraGrid.Columns.GridColumn colColdFee;
        private DevExpress.XtraGrid.Columns.GridColumn colMiscFee;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFee;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiveFee;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colEndDebt;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
