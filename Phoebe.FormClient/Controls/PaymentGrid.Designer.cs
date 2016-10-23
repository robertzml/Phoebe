namespace Phoebe.FormClient
{
    partial class PaymentGrid
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
            this.dgcPayment = new DevExpress.XtraGrid.GridControl();
            this.bsPayment = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTicketNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcPayment
            // 
            this.dgcPayment.DataSource = this.bsPayment;
            this.dgcPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcPayment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.dgcPayment.Location = new System.Drawing.Point(0, 0);
            this.dgcPayment.MainView = this.dgvPayment;
            this.dgcPayment.Margin = new System.Windows.Forms.Padding(2);
            this.dgcPayment.Name = "dgcPayment";
            this.dgcPayment.Size = new System.Drawing.Size(750, 395);
            this.dgcPayment.TabIndex = 0;
            this.dgcPayment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvPayment});
            // 
            // bsPayment
            // 
            this.bsPayment.DataSource = typeof(Phoebe.Model.Payment);
            // 
            // dgvPayment
            // 
            this.dgvPayment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTicketNumber,
            this.colCustomerNumber,
            this.colCustomerId,
            this.colPaidFee,
            this.colPaidTime,
            this.colPaidType,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dgvPayment.GridControl = this.dgcPayment;
            this.dgvPayment.Name = "dgvPayment";
            this.dgvPayment.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvPayment.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvPayment.OptionsBehavior.Editable = false;
            this.dgvPayment.OptionsCustomization.AllowGroup = false;
            this.dgvPayment.OptionsFind.AlwaysVisible = true;
            this.dgvPayment.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvPayment.OptionsView.EnableAppearanceOddRow = true;
            this.dgvPayment.OptionsView.ShowFooter = true;
            this.dgvPayment.OptionsView.ShowGroupPanel = false;
            this.dgvPayment.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvPayment_CustomUnboundColumnData);
            this.dgvPayment.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvPayment_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colTicketNumber
            // 
            this.colTicketNumber.Caption = "票号";
            this.colTicketNumber.FieldName = "TicketNumber";
            this.colTicketNumber.Name = "colTicketNumber";
            this.colTicketNumber.Visible = true;
            this.colTicketNumber.VisibleIndex = 0;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编码";
            this.colCustomerNumber.FieldName = "colCustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 1;
            // 
            // colCustomerId
            // 
            this.colCustomerId.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCustomerId.Caption = "客户名称";
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 2;
            // 
            // colPaidFee
            // 
            this.colPaidFee.Caption = "缴费金额(元)";
            this.colPaidFee.FieldName = "PaidFee";
            this.colPaidFee.Name = "colPaidFee";
            this.colPaidFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PaidFee", "合计={0:0.##}")});
            this.colPaidFee.Visible = true;
            this.colPaidFee.VisibleIndex = 3;
            // 
            // colPaidTime
            // 
            this.colPaidTime.Caption = "缴费时间";
            this.colPaidTime.FieldName = "PaidTime";
            this.colPaidTime.Name = "colPaidTime";
            this.colPaidTime.Visible = true;
            this.colPaidTime.VisibleIndex = 4;
            // 
            // colPaidType
            // 
            this.colPaidType.AppearanceCell.Options.UseTextOptions = true;
            this.colPaidType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPaidType.Caption = "缴费方式";
            this.colPaidType.FieldName = "PaidType";
            this.colPaidType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPaidType.Name = "colPaidType";
            this.colPaidType.Visible = true;
            this.colPaidType.VisibleIndex = 5;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "收款人";
            this.colUserId.FieldName = "UserId";
            this.colUserId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 6;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // PaymentGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcPayment);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PaymentGrid";
            this.Size = new System.Drawing.Size(750, 395);
            this.Load += new System.EventHandler(this.PaymentGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvPayment;
        private System.Windows.Forms.BindingSource bsPayment;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTicketNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidFee;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
    }
}
