namespace Phoebe.ClientDx
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
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameter1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameter2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameter3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).BeginInit();
            this.SuspendLayout();
            // 
            // bsEntity
            // 
            this.bsEntity.DataSource = typeof(Phoebe.Core.DL.Contract);
            // 
            // dgcEntity
            // 
            this.dgcEntity.Size = new System.Drawing.Size(735, 378);
            // 
            // dgvEntity
            // 
            this.dgvEntity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colNumber,
            this.colCustomerNumber,
            this.colCustomerId,
            this.colType,
            this.colSignDate,
            this.colCloseDate,
            this.colBillingType,
            this.colBillingDescription,
            this.colParameter1,
            this.colParameter2,
            this.colParameter3,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dgvEntity.IndicatorWidth = 40;
            this.dgvEntity.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvEntity.OptionsBehavior.Editable = false;
            this.dgvEntity.OptionsDetail.EnableMasterViewMode = false;
            this.dgvEntity.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvEntity.OptionsView.EnableAppearanceOddRow = true;
            this.dgvEntity.OptionsView.ShowGroupPanel = false;
            this.dgvEntity.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvEntity_CustomUnboundColumnData);
            this.dgvEntity.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvEntity_CustomColumnDisplayText);
            // 
            // colNumber
            // 
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
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
            // colType
            // 
            this.colType.AppearanceCell.Options.UseTextOptions = true;
            this.colType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colType.FieldName = "Type";
            this.colType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 4;
            // 
            // colSignDate
            // 
            this.colSignDate.FieldName = "SignDate";
            this.colSignDate.Name = "colSignDate";
            this.colSignDate.Visible = true;
            this.colSignDate.VisibleIndex = 5;
            // 
            // colCloseDate
            // 
            this.colCloseDate.FieldName = "CloseDate";
            this.colCloseDate.Name = "colCloseDate";
            this.colCloseDate.Visible = true;
            this.colCloseDate.VisibleIndex = 6;
            // 
            // colBillingType
            // 
            this.colBillingType.AppearanceCell.Options.UseTextOptions = true;
            this.colBillingType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBillingType.FieldName = "BillingType";
            this.colBillingType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colBillingType.Name = "colBillingType";
            this.colBillingType.Visible = true;
            this.colBillingType.VisibleIndex = 7;
            // 
            // colParameter1
            // 
            this.colParameter1.FieldName = "Parameter1";
            this.colParameter1.Name = "colParameter1";
            this.colParameter1.Visible = true;
            this.colParameter1.VisibleIndex = 9;
            // 
            // colParameter2
            // 
            this.colParameter2.FieldName = "Parameter2";
            this.colParameter2.Name = "colParameter2";
            this.colParameter2.Visible = true;
            this.colParameter2.VisibleIndex = 10;
            // 
            // colParameter3
            // 
            this.colParameter3.FieldName = "Parameter3";
            this.colParameter3.Name = "colParameter3";
            this.colParameter3.Visible = true;
            this.colParameter3.VisibleIndex = 11;
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
            this.colUserId.VisibleIndex = 12;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colRemark
            // 
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 13;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.FieldName = "Status";
            this.colStatus.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 14;
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
            // colBillingDescription
            // 
            this.colBillingDescription.Caption = "计费说明";
            this.colBillingDescription.FieldName = "colBillingDescription";
            this.colBillingDescription.Name = "colBillingDescription";
            this.colBillingDescription.OptionsFilter.AllowFilter = false;
            this.colBillingDescription.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colBillingDescription.Visible = true;
            this.colBillingDescription.VisibleIndex = 8;
            // 
            // ContractGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ContractGrid";
            this.Size = new System.Drawing.Size(735, 378);
            ((System.ComponentModel.ISupportInitialize)(this.bsEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcEntity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colSignDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCloseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingType;
        private DevExpress.XtraGrid.Columns.GridColumn colParameter1;
        private DevExpress.XtraGrid.Columns.GridColumn colParameter2;
        private DevExpress.XtraGrid.Columns.GridColumn colParameter3;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colBillingDescription;
    }
}
