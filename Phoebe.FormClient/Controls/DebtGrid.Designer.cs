namespace Phoebe.FormClient
{
    partial class DebtGrid
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
            this.dgcDebt = new DevExpress.XtraGrid.GridControl();
            this.bsDebt = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDebt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSettleFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnSettleFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebtFee = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDebt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcDebt
            // 
            this.dgcDebt.DataSource = this.bsDebt;
            this.dgcDebt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcDebt.Location = new System.Drawing.Point(0, 0);
            this.dgcDebt.MainView = this.dgvDebt;
            this.dgcDebt.Name = "dgcDebt";
            this.dgcDebt.Size = new System.Drawing.Size(721, 407);
            this.dgcDebt.TabIndex = 0;
            this.dgcDebt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDebt});
            // 
            // bsDebt
            // 
            this.bsDebt.DataSource = typeof(Phoebe.Model.Debt);
            // 
            // dgvDebt
            // 
            this.dgvDebt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerId,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colStartTime,
            this.colEndTime,
            this.colSettleFee,
            this.colUnSettleFee,
            this.colSumFee,
            this.colPaidFee,
            this.colDebtFee});
            this.dgvDebt.GridControl = this.dgcDebt;
            this.dgvDebt.Name = "dgvDebt";
            this.dgvDebt.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDebt.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDebt.OptionsBehavior.Editable = false;
            this.dgvDebt.OptionsCustomization.AllowGroup = false;
            this.dgvDebt.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvDebt.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvDebt.OptionsView.EnableAppearanceOddRow = true;
            this.dgvDebt.OptionsView.ShowFooter = true;
            this.dgvDebt.OptionsView.ShowGroupPanel = false;
            this.dgvDebt.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.dgvDebt_PrintInitialize);
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
            this.colStartTime.Caption = "开始日期";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 2;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "结束日期";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 3;
            // 
            // colSettleFee
            // 
            this.colSettleFee.Caption = "已结算费用(元)";
            this.colSettleFee.DisplayFormat.FormatString = "0.000";
            this.colSettleFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSettleFee.FieldName = "SettleFee";
            this.colSettleFee.Name = "colSettleFee";
            this.colSettleFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SettleFee", "合计={0:0.000}")});
            this.colSettleFee.Visible = true;
            this.colSettleFee.VisibleIndex = 4;
            // 
            // colUnSettleFee
            // 
            this.colUnSettleFee.Caption = "未结算费用(元)";
            this.colUnSettleFee.DisplayFormat.FormatString = "0.000";
            this.colUnSettleFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnSettleFee.FieldName = "UnSettleFee";
            this.colUnSettleFee.Name = "colUnSettleFee";
            this.colUnSettleFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "UnSettleFee", "合计={0:0.000}")});
            this.colUnSettleFee.Visible = true;
            this.colUnSettleFee.VisibleIndex = 5;
            // 
            // colSumFee
            // 
            this.colSumFee.Caption = "费用合计(元)";
            this.colSumFee.DisplayFormat.FormatString = "0.000";
            this.colSumFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFee.FieldName = "SumFee";
            this.colSumFee.Name = "colSumFee";
            this.colSumFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SumFee", "合计={0:0.000}")});
            this.colSumFee.Visible = true;
            this.colSumFee.VisibleIndex = 6;
            // 
            // colPaidFee
            // 
            this.colPaidFee.Caption = "已付款(元)";
            this.colPaidFee.DisplayFormat.FormatString = "0.000";
            this.colPaidFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPaidFee.FieldName = "PaidFee";
            this.colPaidFee.Name = "colPaidFee";
            this.colPaidFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidFee", "合计={0:0.000}")});
            this.colPaidFee.Visible = true;
            this.colPaidFee.VisibleIndex = 7;
            // 
            // colDebtFee
            // 
            this.colDebtFee.Caption = "欠款(元)";
            this.colDebtFee.DisplayFormat.FormatString = "0.000";
            this.colDebtFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDebtFee.FieldName = "DebtFee";
            this.colDebtFee.Name = "colDebtFee";
            this.colDebtFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebtFee", "合计={0:0.000}")});
            this.colDebtFee.Visible = true;
            this.colDebtFee.VisibleIndex = 8;
            // 
            // DebtGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcDebt);
            this.Name = "DebtGrid";
            this.Size = new System.Drawing.Size(721, 407);
            ((System.ComponentModel.ISupportInitialize)(this.dgcDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDebt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcDebt;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDebt;
        private System.Windows.Forms.BindingSource bsDebt;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSettleFee;
        private DevExpress.XtraGrid.Columns.GridColumn colUnSettleFee;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidFee;
        private DevExpress.XtraGrid.Columns.GridColumn colDebtFee;
        private DevExpress.XtraGrid.Columns.GridColumn colSumFee;
    }
}
