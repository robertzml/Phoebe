namespace Phoebe.FormClient
{
    partial class SettlementGrid
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
            this.dgcSettlement = new DevExpress.XtraGrid.GridControl();
            this.bsSettlement = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSettlement = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemission = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSettleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcSettlement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSettlement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcSettlement
            // 
            this.dgcSettlement.DataSource = this.bsSettlement;
            this.dgcSettlement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcSettlement.Location = new System.Drawing.Point(0, 0);
            this.dgcSettlement.MainView = this.dgvSettlement;
            this.dgcSettlement.Name = "dgcSettlement";
            this.dgcSettlement.Size = new System.Drawing.Size(938, 514);
            this.dgcSettlement.TabIndex = 0;
            this.dgcSettlement.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvSettlement});
            // 
            // bsSettlement
            // 
            this.bsSettlement.DataSource = typeof(Phoebe.Model.Settlement);
            // 
            // dgvSettlement
            // 
            this.dgvSettlement.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNumber,
            this.colCustomerNumber,
            this.colCustomerId,
            this.colStartTime,
            this.colEndTime,
            this.colSumFee,
            this.colDiscount,
            this.colRemission,
            this.colDueFee,
            this.colSettleTime,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dgvSettlement.GridControl = this.dgcSettlement;
            this.dgvSettlement.Name = "dgvSettlement";
            this.dgvSettlement.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvSettlement.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvSettlement.OptionsBehavior.Editable = false;
            this.dgvSettlement.OptionsCustomization.AllowGroup = false;
            this.dgvSettlement.OptionsFind.AlwaysVisible = true;
            this.dgvSettlement.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvSettlement.OptionsView.EnableAppearanceOddRow = true;
            this.dgvSettlement.OptionsView.ShowGroupPanel = false;
            this.dgvSettlement.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvSettlement_CustomUnboundColumnData);
            this.dgvSettlement.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvSettlement_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNumber
            // 
            this.colNumber.Caption = "结算单号";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编号";
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
            // colStartTime
            // 
            this.colStartTime.Caption = "开始日期";
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Visible = true;
            this.colStartTime.VisibleIndex = 3;
            // 
            // colEndTime
            // 
            this.colEndTime.Caption = "结束日期";
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Visible = true;
            this.colEndTime.VisibleIndex = 4;
            // 
            // colSumFee
            // 
            this.colSumFee.Caption = "费用合计(元)";
            this.colSumFee.DisplayFormat.FormatString = "0.##";
            this.colSumFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFee.FieldName = "SumFee";
            this.colSumFee.Name = "colSumFee";
            this.colSumFee.Visible = true;
            this.colSumFee.VisibleIndex = 5;
            // 
            // colDiscount
            // 
            this.colDiscount.Caption = "折扣率(%)";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 6;
            // 
            // colRemission
            // 
            this.colRemission.Caption = "减免费用(元)";
            this.colRemission.DisplayFormat.FormatString = "0.##";
            this.colRemission.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemission.FieldName = "Remission";
            this.colRemission.Name = "colRemission";
            this.colRemission.Visible = true;
            this.colRemission.VisibleIndex = 7;
            // 
            // colDueFee
            // 
            this.colDueFee.Caption = "应付款(元)";
            this.colDueFee.DisplayFormat.FormatString = "0.##";
            this.colDueFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDueFee.FieldName = "DueFee";
            this.colDueFee.Name = "colDueFee";
            this.colDueFee.Visible = true;
            this.colDueFee.VisibleIndex = 8;
            // 
            // colSettleTime
            // 
            this.colSettleTime.Caption = "结算日期";
            this.colSettleTime.FieldName = "SettleTime";
            this.colSettleTime.Name = "colSettleTime";
            this.colSettleTime.Visible = true;
            this.colSettleTime.VisibleIndex = 9;
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
            this.colUserId.VisibleIndex = 10;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // SettlementGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcSettlement);
            this.Name = "SettlementGrid";
            this.Size = new System.Drawing.Size(938, 514);
            ((System.ComponentModel.ISupportInitialize)(this.dgcSettlement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSettlement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcSettlement;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvSettlement;
        private System.Windows.Forms.BindingSource bsSettlement;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colSumFee;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscount;
        private DevExpress.XtraGrid.Columns.GridColumn colRemission;
        private DevExpress.XtraGrid.Columns.GridColumn colDueFee;
        private DevExpress.XtraGrid.Columns.GridColumn colSettleTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
    }
}
