namespace Phoebe.FormClient
{
    partial class CargoGrid
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
            this.dgcCargo = new DevExpress.XtraGrid.GridControl();
            this.bsCargo = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCargo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegisterTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcCargo
            // 
            this.dgcCargo.DataSource = this.bsCargo;
            this.dgcCargo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcCargo.Location = new System.Drawing.Point(0, 0);
            this.dgcCargo.MainView = this.dgvCargo;
            this.dgcCargo.Name = "dgcCargo";
            this.dgcCargo.Size = new System.Drawing.Size(726, 376);
            this.dgcCargo.TabIndex = 0;
            this.dgcCargo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvCargo});
            // 
            // bsCargo
            // 
            this.bsCargo.DataSource = typeof(Phoebe.Model.Cargo);
            // 
            // dgvCargo
            // 
            this.dgvCargo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colCategoryId,
            this.colGroupType,
            this.colUnitWeight,
            this.colUnitVolume,
            this.colContractId,
            this.colRegisterTime,
            this.colRemark,
            this.colStatus});
            this.dgvCargo.GridControl = this.dgcCargo;
            this.dgvCargo.Name = "dgvCargo";
            this.dgvCargo.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCargo.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCargo.OptionsBehavior.Editable = false;
            this.dgvCargo.OptionsFind.AlwaysVisible = true;
            this.dgvCargo.OptionsView.ShowGroupPanel = false;
            this.dgvCargo.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.dgvCargo_CustomUnboundColumnData);
            this.dgvCargo.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.dgvCargo_CustomColumnDisplayText);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "类别代码";
            this.colCategoryNumber.FieldName = "colCategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 1;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "类别名称";
            this.colCategoryName.FieldName = "colCategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 2;
            // 
            // colCategoryId
            // 
            this.colCategoryId.FieldName = "CategoryId";
            this.colCategoryId.Name = "colCategoryId";
            // 
            // colGroupType
            // 
            this.colGroupType.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroupType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colGroupType.Caption = "分组方式";
            this.colGroupType.FieldName = "GroupType";
            this.colGroupType.Name = "colGroupType";
            this.colGroupType.Visible = true;
            this.colGroupType.VisibleIndex = 3;
            // 
            // colUnitWeight
            // 
            this.colUnitWeight.Caption = "单位重量(kg)";
            this.colUnitWeight.DisplayFormat.FormatString = "0.##";
            this.colUnitWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitWeight.FieldName = "UnitWeight";
            this.colUnitWeight.Name = "colUnitWeight";
            this.colUnitWeight.Visible = true;
            this.colUnitWeight.VisibleIndex = 4;
            // 
            // colUnitVolume
            // 
            this.colUnitVolume.Caption = "单位体积(立方)";
            this.colUnitVolume.DisplayFormat.FormatString = "0.###";
            this.colUnitVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitVolume.FieldName = "UnitVolume";
            this.colUnitVolume.Name = "colUnitVolume";
            this.colUnitVolume.Visible = true;
            this.colUnitVolume.VisibleIndex = 5;
            // 
            // colContractId
            // 
            this.colContractId.AppearanceCell.Options.UseTextOptions = true;
            this.colContractId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colContractId.AppearanceHeader.Options.UseTextOptions = true;
            this.colContractId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colContractId.Caption = "合同名称";
            this.colContractId.FieldName = "ContractId";
            this.colContractId.Name = "colContractId";
            this.colContractId.Visible = true;
            this.colContractId.VisibleIndex = 0;
            // 
            // colRegisterTime
            // 
            this.colRegisterTime.Caption = "登记时间";
            this.colRegisterTime.FieldName = "RegisterTime";
            this.colRegisterTime.Name = "colRegisterTime";
            this.colRegisterTime.Visible = true;
            this.colRegisterTime.VisibleIndex = 6;
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
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // CargoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcCargo);
            this.Name = "CargoGrid";
            this.Size = new System.Drawing.Size(726, 376);
            this.Load += new System.EventHandler(this.CargoGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgcCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcCargo;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvCargo;
        private System.Windows.Forms.BindingSource bsCargo;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupType;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitVolume;
        private DevExpress.XtraGrid.Columns.GridColumn colContractId;
        private DevExpress.XtraGrid.Columns.GridColumn colRegisterTime;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
    }
}
