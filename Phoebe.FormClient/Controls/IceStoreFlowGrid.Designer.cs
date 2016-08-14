namespace Phoebe.FormClient
{
    partial class IceStoreFlowGrid
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
            this.bsIce = new System.Windows.Forms.BindingSource(this.components);
            this.dgvIce = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFlowType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcIce
            // 
            this.dgcIce.DataSource = this.bsIce;
            this.dgcIce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcIce.Location = new System.Drawing.Point(0, 0);
            this.dgcIce.MainView = this.dgvIce;
            this.dgcIce.Name = "dgcIce";
            this.dgcIce.Size = new System.Drawing.Size(951, 490);
            this.dgcIce.TabIndex = 0;
            this.dgcIce.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvIce});
            // 
            // bsIce
            // 
            this.bsIce.DataSource = typeof(Phoebe.Model.IceStoreFlow);
            // 
            // dgvIce
            // 
            this.dgvIce.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFlowType,
            this.colFlowNumber,
            this.colFlowTime,
            this.colIceType,
            this.colFlowCount,
            this.colUnitWeight,
            this.colFlowWeight,
            this.colUserName,
            this.colCreateTime,
            this.colRemark});
            this.dgvIce.GridControl = this.dgcIce;
            this.dgvIce.Name = "dgvIce";
            this.dgvIce.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvIce.OptionsBehavior.Editable = false;
            this.dgvIce.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvIce.OptionsView.EnableAppearanceOddRow = true;
            this.dgvIce.OptionsView.ShowFooter = true;
            this.dgvIce.OptionsView.ShowGroupPanel = false;
            this.dgvIce.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvIce_CustomColumnDisplayText);
            // 
            // colFlowType
            // 
            this.colFlowType.AppearanceCell.Options.UseTextOptions = true;
            this.colFlowType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colFlowType.Caption = "流水类型";
            this.colFlowType.FieldName = "FlowType";
            this.colFlowType.Name = "colFlowType";
            this.colFlowType.Visible = true;
            this.colFlowType.VisibleIndex = 0;
            // 
            // colFlowNumber
            // 
            this.colFlowNumber.Caption = "流水单号";
            this.colFlowNumber.FieldName = "FlowNumber";
            this.colFlowNumber.Name = "colFlowNumber";
            this.colFlowNumber.Visible = true;
            this.colFlowNumber.VisibleIndex = 1;
            // 
            // colFlowTime
            // 
            this.colFlowTime.Caption = "流水日期";
            this.colFlowTime.FieldName = "FlowTime";
            this.colFlowTime.Name = "colFlowTime";
            this.colFlowTime.Visible = true;
            this.colFlowTime.VisibleIndex = 2;
            // 
            // colIceType
            // 
            this.colIceType.AppearanceCell.Options.UseTextOptions = true;
            this.colIceType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colIceType.Caption = "冰块类型";
            this.colIceType.FieldName = "IceType";
            this.colIceType.Name = "colIceType";
            this.colIceType.Visible = true;
            this.colIceType.VisibleIndex = 3;
            // 
            // colFlowCount
            // 
            this.colFlowCount.Caption = "流水数量";
            this.colFlowCount.FieldName = "FlowCount";
            this.colFlowCount.Name = "colFlowCount";
            this.colFlowCount.Visible = true;
            this.colFlowCount.VisibleIndex = 4;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 5;
            // 
            // colFlowWeight
            // 
            this.colFlowWeight.Caption = "流水重量(kg)";
            this.colFlowWeight.DisplayFormat.FormatString = "0.##";
            this.colFlowWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowWeight.FieldName = "FlowWeight";
            this.colFlowWeight.Name = "colFlowWeight";
            this.colFlowWeight.Visible = true;
            this.colFlowWeight.VisibleIndex = 6;
            // 
            // colUserName
            // 
            this.colUserName.Caption = "操作人";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 7;
            // 
            // colCreateTime
            // 
            this.colCreateTime.Caption = "创建时间";
            this.colCreateTime.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreateTime.FieldName = "CreateTime";
            this.colCreateTime.Name = "colCreateTime";
            this.colCreateTime.Visible = true;
            this.colCreateTime.VisibleIndex = 8;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            // 
            // IceStoreFlowGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcIce);
            this.Name = "IceStoreFlowGrid";
            this.Size = new System.Drawing.Size(951, 490);
            ((System.ComponentModel.ISupportInitialize)(this.dgcIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsIce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcIce;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvIce;
        private System.Windows.Forms.BindingSource bsIce;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowTime;
        private DevExpress.XtraGrid.Columns.GridColumn colIceType;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowCount;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateTime;
    }
}
