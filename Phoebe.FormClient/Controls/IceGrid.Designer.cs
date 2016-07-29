namespace Phoebe.FormClient
{
    partial class IceGrid
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
            this.dgcIce = new DevExpress.XtraGrid.GridControl();
            this.bsIceFlow = new System.Windows.Forms.BindingSource(this.components);
            this.dgvIce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcIce
            // 
            this.dgcIce.DataSource = this.bsIceFlow;
            this.dgcIce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcIce.Location = new System.Drawing.Point(0, 0);
            this.dgcIce.MainView = this.dgvIce;
            this.dgcIce.Name = "dgcIce";
            this.dgcIce.Size = new System.Drawing.Size(751, 445);
            this.dgcIce.TabIndex = 0;
            this.dgcIce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIce});
            // 
            // bsIceFlow
            // 
            this.bsIceFlow.DataSource = typeof(Phoebe.Model.IceFlow);
            // 
            // dgvIce
            // 
            this.dgvIce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFlowType,
            this.colFlowTime,
            this.colIceType,
            this.colFlowCount,
            this.colFlowWeight,
            this.colUserId,
            this.colCreateTime,
            this.colRemark,
            this.colStatus});
            this.dgvIce.GridControl = this.dgcIce;
            this.dgvIce.Name = "dgvIce";
            this.dgvIce.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.Editable = false;
            this.dgvIce.OptionsCustomization.AllowGroup = false;
            this.dgvIce.OptionsFind.AlwaysVisible = true;
            this.dgvIce.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvIce.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvIce.OptionsView.EnableAppearanceOddRow = true;
            this.dgvIce.OptionsView.ShowFooter = true;
            this.dgvIce.OptionsView.ShowGroupPanel = false;
            this.dgvIce.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvIce_CustomUnboundColumnData);
            this.dgvIce.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvIce_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFlowType
            // 
            this.colFlowType.AppearanceCell.Options.UseTextOptions = true;
            this.colFlowType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFlowType.Caption = "流水类型";
            this.colFlowType.FieldName = "FlowType";
            this.colFlowType.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colFlowType.Name = "colFlowType";
            this.colFlowType.Visible = true;
            this.colFlowType.VisibleIndex = 0;
            // 
            // colFlowTime
            // 
            this.colFlowTime.Caption = "流水时间";
            this.colFlowTime.FieldName = "FlowTime";
            this.colFlowTime.Name = "colFlowTime";
            this.colFlowTime.Visible = true;
            this.colFlowTime.VisibleIndex = 1;
            // 
            // colIceType
            // 
            this.colIceType.Caption = "冰块类型";
            this.colIceType.FieldName = "colIceType";
            this.colIceType.Name = "colIceType";
            this.colIceType.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colIceType.Visible = true;
            this.colIceType.VisibleIndex = 2;
            // 
            // colFlowCount
            // 
            this.colFlowCount.Caption = "流水数量";
            this.colFlowCount.FieldName = "colFlowCount";
            this.colFlowCount.Name = "colFlowCount";
            this.colFlowCount.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colFlowCount.Visible = true;
            this.colFlowCount.VisibleIndex = 3;
            // 
            // colFlowWeight
            // 
            this.colFlowWeight.Caption = "流水重量(t)";
            this.colFlowWeight.DisplayFormat.FormatString = "0.000";
            this.colFlowWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowWeight.FieldName = "colFlowWeight";
            this.colFlowWeight.Name = "colFlowWeight";
            this.colFlowWeight.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            this.colFlowWeight.Visible = true;
            this.colFlowWeight.VisibleIndex = 4;
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
            this.colUserId.VisibleIndex = 5;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 6;
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
            // IceGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceGrid";
            this.Size = new System.Drawing.Size(751, 445);
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIceFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcIce;
        private System.Windows.Forms.BindingSource bsIceFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIce;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowCount;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowWeight;
    }
}
