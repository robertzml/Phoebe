namespace Phoebe.FormClient
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcPayment = new DevExpress.XtraGrid.GridControl();
            this.bsPayment = new System.Windows.Forms.BindingSource(this.components);
            this.dgvPayment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTicketNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaidType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnPrint);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(793, 110);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(326, 43);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "删除缴费";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(44, 43);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 40);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "客户缴费";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dgcPayment);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 110);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(793, 355);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "缴费记录";
            // 
            // dgcPayment
            // 
            this.dgcPayment.DataSource = this.bsPayment;
            this.dgcPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcPayment.Location = new System.Drawing.Point(2, 21);
            this.dgcPayment.MainView = this.dgvPayment;
            this.dgcPayment.Name = "dgcPayment";
            this.dgcPayment.Size = new System.Drawing.Size(789, 332);
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
            this.dgvPayment.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvPayment.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvPayment.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvPayment.OptionsView.EnableAppearanceOddRow = true;
            this.dgvPayment.OptionsView.ShowFooter = true;
            this.dgvPayment.OptionsView.ShowGroupPanel = false;
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
            // colCustomerId
            // 
            this.colCustomerId.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCustomerId.Caption = "客户名称";
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 1;
            // 
            // colPaidFee
            // 
            this.colPaidFee.Caption = "缴费金额(元)";
            this.colPaidFee.FieldName = "PaidFee";
            this.colPaidFee.Name = "colPaidFee";
            this.colPaidFee.Visible = true;
            this.colPaidFee.VisibleIndex = 2;
            // 
            // colPaidTime
            // 
            this.colPaidTime.Caption = "缴费时间";
            this.colPaidTime.FieldName = "PaidTime";
            this.colPaidTime.Name = "colPaidTime";
            this.colPaidTime.Visible = true;
            this.colPaidTime.VisibleIndex = 3;
            // 
            // colPaidType
            // 
            this.colPaidType.AppearanceHeader.Options.UseTextOptions = true;
            this.colPaidType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colPaidType.Caption = "缴费方式";
            this.colPaidType.FieldName = "PaidType";
            this.colPaidType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colPaidType.Name = "colPaidType";
            this.colPaidType.Visible = true;
            this.colPaidType.VisibleIndex = 4;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colUserId.Caption = "收款人";
            this.colUserId.FieldName = "UserId";
            this.colUserId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 5;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 6;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(185, 43);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(90, 40);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "打印收据";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 465);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "PaymentForm";
            this.Text = "缴费管理";
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl dgcPayment;
        private System.Windows.Forms.BindingSource bsPayment;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvPayment;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTicketNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidFee;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPaidType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
    }
}