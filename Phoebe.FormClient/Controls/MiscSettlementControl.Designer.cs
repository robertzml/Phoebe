namespace Phoebe.FormClient
{
    partial class MiscSettlementControl
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
            this.dgcMisc = new DevExpress.XtraGrid.GridControl();
            this.bsMisc = new System.Windows.Forms.BindingSource(this.components);
            this.dgvMisc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcMisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMisc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcMisc
            // 
            this.dgcMisc.DataSource = this.bsMisc;
            this.dgcMisc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcMisc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgcMisc.Location = new System.Drawing.Point(0, 0);
            this.dgcMisc.MainView = this.dgvMisc;
            this.dgcMisc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgcMisc.Name = "dgcMisc";
            this.dgcMisc.Size = new System.Drawing.Size(602, 292);
            this.dgcMisc.TabIndex = 0;
            this.dgcMisc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvMisc});
            // 
            // bsMisc
            // 
            this.bsMisc.DataSource = typeof(Phoebe.Model.MiscSettlement);
            // 
            // dgvMisc
            // 
            this.dgvMisc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractId,
            this.colContractName,
            this.colFeeName,
            this.colStartTime,
            this.colEndTime,
            this.colTotalFee,
            this.colRemark});
            this.dgvMisc.GridControl = this.dgcMisc;
            this.dgvMisc.Name = "dgvMisc";
            this.dgvMisc.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvMisc.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvMisc.OptionsBehavior.Editable = false;
            this.dgvMisc.OptionsFilter.AllowFilterEditor = false;
            this.dgvMisc.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvMisc.OptionsView.EnableAppearanceOddRow = true;
            this.dgvMisc.OptionsView.ShowFooter = true;
            this.dgvMisc.OptionsView.ShowGroupPanel = false;
            // 
            // colContractId
            // 
            this.colContractId.FieldName = "ContractId";
            this.colContractId.Name = "colContractId";
            // 
            // colContractName
            // 
            this.colContractName.Caption = "合同名称";
            this.colContractName.FieldName = "ContractName";
            this.colContractName.Name = "colContractName";
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 0;
            // 
            // colFeeName
            // 
            this.colFeeName.Caption = "费用名称";
            this.colFeeName.FieldName = "FeeName";
            this.colFeeName.Name = "colFeeName";
            this.colFeeName.Visible = true;
            this.colFeeName.VisibleIndex = 1;
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
            // colTotalFee
            // 
            this.colTotalFee.Caption = "费用合计(元)";
            this.colTotalFee.DisplayFormat.FormatString = "0.##";
            this.colTotalFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFee.FieldName = "TotalFee";
            this.colTotalFee.Name = "colTotalFee";
            this.colTotalFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalFee", "合计={0:0.##}")});
            this.colTotalFee.Visible = true;
            this.colTotalFee.VisibleIndex = 4;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 5;
            // 
            // MiscSettlementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcMisc);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MiscSettlementControl";
            this.Size = new System.Drawing.Size(602, 292);
            ((System.ComponentModel.ISupportInitialize)(this.dgcMisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMisc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcMisc;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvMisc;
        private System.Windows.Forms.BindingSource bsMisc;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colFeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFee;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
    }
}
