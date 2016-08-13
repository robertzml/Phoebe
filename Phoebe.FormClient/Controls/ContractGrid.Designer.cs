namespace Phoebe.FormClient
{
    partial class ContractGrid
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
            this.dgcContract = new DevExpress.XtraGrid.GridControl();
            this.bsContract = new System.Windows.Forms.BindingSource(this.components);
            this.dgvContract = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTiming = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcContract
            // 
            this.dgcContract.DataSource = this.bsContract;
            this.dgcContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcContract.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgcContract.Location = new System.Drawing.Point(0, 0);
            this.dgcContract.MainView = this.dgvContract;
            this.dgcContract.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgcContract.Name = "dgcContract";
            this.dgcContract.Size = new System.Drawing.Size(939, 515);
            this.dgcContract.TabIndex = 0;
            this.dgcContract.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvContract});
            // 
            // bsContract
            // 
            this.bsContract.DataSource = typeof(Phoebe.Model.Contract);
            // 
            // dgvContract
            // 
            this.dgvContract.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNumber,
            this.colName,
            this.colCustomerNumber,
            this.colCustomerId,
            this.colSignDate,
            this.colCloseDate,
            this.colType,
            this.colBillingType,
            this.colBillingDescription,
            this.colIsTiming,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dgvContract.GridControl = this.dgcContract;
            this.dgvContract.Name = "dgvContract";
            this.dgvContract.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvContract.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvContract.OptionsBehavior.Editable = false;
            this.dgvContract.OptionsFind.AlwaysVisible = true;
            this.dgvContract.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvContract.OptionsView.EnableAppearanceOddRow = true;
            this.dgvContract.OptionsView.ShowGroupPanel = false;
            this.dgvContract.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvContract_CustomUnboundColumnData);
            this.dgvContract.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvContract_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNumber
            // 
            this.colNumber.Caption = "编号";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colCustomerId
            // 
            this.colCustomerId.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCustomerId.Caption = "所属客户";
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 3;
            // 
            // colSignDate
            // 
            this.colSignDate.Caption = "签订日期";
            this.colSignDate.FieldName = "SignDate";
            this.colSignDate.Name = "colSignDate";
            this.colSignDate.Visible = true;
            this.colSignDate.VisibleIndex = 4;
            // 
            // colCloseDate
            // 
            this.colCloseDate.Caption = "关闭日期";
            this.colCloseDate.FieldName = "CloseDate";
            this.colCloseDate.Name = "colCloseDate";
            this.colCloseDate.Visible = true;
            this.colCloseDate.VisibleIndex = 5;
            // 
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colType.Caption = "合同类型";
            this.colType.FieldName = "Type";
            this.colType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 6;
            // 
            // colBillingType
            // 
            this.colBillingType.AppearanceCell.Options.UseTextOptions = true;
            this.colBillingType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBillingType.Caption = "计费方式";
            this.colBillingType.FieldName = "BillingType";
            this.colBillingType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colBillingType.Name = "colBillingType";
            this.colBillingType.Visible = true;
            this.colBillingType.VisibleIndex = 7;
            // 
            // colBillingDescription
            // 
            this.colBillingDescription.Caption = "计费说明";
            this.colBillingDescription.FieldName = "colBillingDescription";
            this.colBillingDescription.Name = "colBillingDescription";
            this.colBillingDescription.OptionsFilter.AllowFilter = false;
            this.colBillingDescription.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBillingDescription.Visible = true;
            this.colBillingDescription.VisibleIndex = 9;
            // 
            // colIsTiming
            // 
            this.colIsTiming.Caption = "是否计时";
            this.colIsTiming.FieldName = "IsTiming";
            this.colIsTiming.Name = "colIsTiming";
            this.colIsTiming.Visible = true;
            this.colIsTiming.VisibleIndex = 8;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "登记人";
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
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 11;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 12;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客户编号";
            this.colCustomerNumber.FieldName = "colCustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 2;
            // 
            // ContractGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcContract);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ContractGrid";
            this.Size = new System.Drawing.Size(939, 515);
            ((System.ComponentModel.ISupportInitialize)(this.dgcContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcContract;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvContract;
        private System.Windows.Forms.BindingSource bsContract;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingType;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTiming;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
    }
}
