namespace Phoebe.FormClient
{
    partial class SettleListForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcSettlement = new DevExpress.XtraGrid.GridControl();
            this.bsSettlement = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSettlement = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcSettlement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSettlement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(953, 577);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl1, 2);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(947, 94);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "操作";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(53, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 43);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "删除结算";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 2);
            this.groupControl2.Controls.Add(this.dgcSettlement);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 103);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(947, 471);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "结算列表";
            // 
            // dgcSettlement
            // 
            this.dgcSettlement.DataSource = this.bsSettlement;
            this.dgcSettlement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcSettlement.Location = new System.Drawing.Point(2, 21);
            this.dgcSettlement.MainView = this.dgvSettlement;
            this.dgcSettlement.Name = "dgcSettlement";
            this.dgcSettlement.Size = new System.Drawing.Size(943, 448);
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
            this.dgvSettlement.OptionsFind.AlwaysVisible = true;
            this.dgvSettlement.OptionsMenu.EnableFooterMenu = false;
            this.dgvSettlement.OptionsView.ShowGroupPanel = false;
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
            // colCustomerId
            // 
            this.colCustomerId.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colCustomerId.Caption = "客户名称";
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 1;
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
            // colSumFee
            // 
            this.colSumFee.Caption = "费用合计(元)";
            this.colSumFee.DisplayFormat.FormatString = "0.##";
            this.colSumFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSumFee.FieldName = "SumFee";
            this.colSumFee.Name = "colSumFee";
            this.colSumFee.Visible = true;
            this.colSumFee.VisibleIndex = 4;
            // 
            // colDiscount
            // 
            this.colDiscount.Caption = "折扣率(%)";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Visible = true;
            this.colDiscount.VisibleIndex = 5;
            // 
            // colRemission
            // 
            this.colRemission.Caption = "减免费用(元)";
            this.colRemission.DisplayFormat.FormatString = "0.##";
            this.colRemission.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRemission.FieldName = "Remission";
            this.colRemission.Name = "colRemission";
            this.colRemission.Visible = true;
            this.colRemission.VisibleIndex = 6;
            // 
            // colDueFee
            // 
            this.colDueFee.Caption = "应付款(元)";
            this.colDueFee.DisplayFormat.FormatString = "0.##";
            this.colDueFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDueFee.FieldName = "DueFee";
            this.colDueFee.Name = "colDueFee";
            this.colDueFee.Visible = true;
            this.colDueFee.VisibleIndex = 7;
            // 
            // colSettleTime
            // 
            this.colSettleTime.Caption = "结算日期";
            this.colSettleTime.FieldName = "SettleTime";
            this.colSettleTime.Name = "colSettleTime";
            this.colSettleTime.Visible = true;
            this.colSettleTime.VisibleIndex = 8;
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
            this.colUserId.VisibleIndex = 9;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsFilter.AllowFilter = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 10;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // SettleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SettleListForm";
            this.Text = "结算记录";
            this.Load += new System.EventHandler(this.SettleListForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcSettlement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsSettlement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettlement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.GroupControl groupControl2;
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
    }
}