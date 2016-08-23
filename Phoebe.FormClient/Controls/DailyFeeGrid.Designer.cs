namespace Phoebe.FormClient
{
    partial class DailyFeeGrid
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
            this.dgcDaily = new DevExpress.XtraGrid.GridControl();
            this.bsDailyFee = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDaily = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaseFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColdFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiscFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFee = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcDaily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDailyFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaily)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcDaily
            // 
            this.dgcDaily.DataSource = this.bsDailyFee;
            this.dgcDaily.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcDaily.Location = new System.Drawing.Point(0, 0);
            this.dgcDaily.MainView = this.dgvDaily;
            this.dgcDaily.Name = "dgcDaily";
            this.dgcDaily.Size = new System.Drawing.Size(706, 418);
            this.dgcDaily.TabIndex = 0;
            this.dgcDaily.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDaily});
            // 
            // bsDailyFee
            // 
            this.bsDailyFee.DataSource = typeof(Phoebe.Model.DailyFee);
            // 
            // dgvDaily
            // 
            this.dgvDaily.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCustomerId,
            this.colCustomerNumber,
            this.colCustomerName,
            this.colDate,
            this.colBaseFee,
            this.colColdFee,
            this.colMiscFee,
            this.colTotalFee});
            this.dgvDaily.GridControl = this.dgcDaily;
            this.dgvDaily.Name = "dgvDaily";
            this.dgvDaily.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDaily.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDaily.OptionsBehavior.Editable = false;
            this.dgvDaily.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvDaily.OptionsView.EnableAppearanceOddRow = true;
            this.dgvDaily.OptionsView.ShowFooter = true;
            this.dgvDaily.OptionsView.ShowGroupPanel = false;
            this.dgvDaily.PrintInitialize += new DevExpress.XtraGrid.Views.Base.PrintInitializeEventHandler(this.dgvDaily_PrintInitialize);
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
            // colDate
            // 
            this.colDate.Caption = "日期";
            this.colDate.FieldName = "Date";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 2;
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
            this.colBaseFee.VisibleIndex = 3;
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
            this.colColdFee.VisibleIndex = 4;
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
            this.colMiscFee.VisibleIndex = 5;
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
            this.colTotalFee.VisibleIndex = 6;
            // 
            // DailyFeeGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcDaily);
            this.Name = "DailyFeeGrid";
            this.Size = new System.Drawing.Size(706, 418);
            ((System.ComponentModel.ISupportInitialize)(this.dgcDaily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDailyFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaily)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcDaily;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDaily;
        private System.Windows.Forms.BindingSource bsDailyFee;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBaseFee;
        private DevExpress.XtraGrid.Columns.GridColumn colColdFee;
        private DevExpress.XtraGrid.Columns.GridColumn colMiscFee;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFee;
    }
}
