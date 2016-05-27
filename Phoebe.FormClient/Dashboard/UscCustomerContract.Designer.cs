namespace Phoebe.FormClient
{
    partial class UscCustomerContract
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dgcContract = new DevExpress.XtraGrid.GridControl();
            this.bsContract = new System.Windows.Forms.BindingSource(this.components);
            this.dcvContract = new DevExpress.XtraGrid.Views.Card.CardView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSignDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCloseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillingType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTiming = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcvContract)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgcContract);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(836, 404);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "合同信息";
            // 
            // dgcContract
            // 
            this.dgcContract.DataSource = this.bsContract;
            this.dgcContract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcContract.Location = new System.Drawing.Point(2, 21);
            this.dgcContract.MainView = this.dcvContract;
            this.dgcContract.Name = "dgcContract";
            this.dgcContract.Size = new System.Drawing.Size(832, 381);
            this.dgcContract.TabIndex = 0;
            this.dgcContract.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dcvContract});
            // 
            // bsContract
            // 
            this.bsContract.DataSource = typeof(Phoebe.Model.Contract);
            // 
            // dcvContract
            // 
            this.dcvContract.CardCaptionFormat = "记录{0}: {3}";
            this.dcvContract.CardWidth = 300;
            this.dcvContract.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNumber,
            this.colName,
            this.colCustomerId,
            this.colSignDate,
            this.colCloseDate,
            this.colBillingType,
            this.colIsTiming,
            this.colUserId,
            this.colRemark,
            this.colStatus});
            this.dcvContract.FocusedCardTopFieldIndex = 0;
            this.dcvContract.GridControl = this.dgcContract;
            this.dcvContract.Name = "dcvContract";
            this.dcvContract.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dcvContract.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dcvContract.OptionsBehavior.Editable = false;
            this.dcvContract.OptionsFilter.AllowFilterEditor = false;
            this.dcvContract.OptionsFind.AllowFindPanel = false;
            this.dcvContract.OptionsView.ShowQuickCustomizeButton = false;
            this.dcvContract.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.dcvContract.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dcvContract_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colNumber
            // 
            this.colNumber.Caption = "合同编码";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "合同名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            // 
            // colSignDate
            // 
            this.colSignDate.Caption = "签订日期";
            this.colSignDate.FieldName = "SignDate";
            this.colSignDate.Name = "colSignDate";
            this.colSignDate.Visible = true;
            this.colSignDate.VisibleIndex = 2;
            // 
            // colCloseDate
            // 
            this.colCloseDate.Caption = "关闭日期";
            this.colCloseDate.FieldName = "CloseDate";
            this.colCloseDate.Name = "colCloseDate";
            this.colCloseDate.Visible = true;
            this.colCloseDate.VisibleIndex = 3;
            // 
            // colBillingType
            // 
            this.colBillingType.AppearanceCell.Options.UseTextOptions = true;
            this.colBillingType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colBillingType.Caption = "计费方式";
            this.colBillingType.FieldName = "BillingType";
            this.colBillingType.Name = "colBillingType";
            this.colBillingType.Visible = true;
            this.colBillingType.VisibleIndex = 4;
            // 
            // colIsTiming
            // 
            this.colIsTiming.Caption = "是否计时";
            this.colIsTiming.FieldName = "IsTiming";
            this.colIsTiming.Name = "colIsTiming";
            this.colIsTiming.Visible = true;
            this.colIsTiming.VisibleIndex = 5;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "登记人";
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 6;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colStatus.Caption = "状态";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            // 
            // UscCustomerContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UscCustomerContract";
            this.Size = new System.Drawing.Size(836, 404);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dcvContract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl dgcContract;
        private System.Windows.Forms.BindingSource bsContract;
        private DevExpress.XtraGrid.Views.Card.CardView dcvContract;
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
    }
}
