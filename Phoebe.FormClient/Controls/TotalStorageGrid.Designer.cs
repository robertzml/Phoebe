namespace Phoebe.FormClient
{
    partial class TotalStorageGrid
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
            this.dgcStorage = new DevExpress.XtraGrid.GridControl();
            this.dgvStorage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bsStorage = new System.Windows.Forms.BindingSource(this.components);
            this.colStorageDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreWeight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStoreVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgcStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStorage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgcStorage
            // 
            this.dgcStorage.DataSource = this.bsStorage;
            this.dgcStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcStorage.Location = new System.Drawing.Point(0, 0);
            this.dgcStorage.MainView = this.dgvStorage;
            this.dgcStorage.Name = "dgcStorage";
            this.dgcStorage.Size = new System.Drawing.Size(692, 475);
            this.dgcStorage.TabIndex = 0;
            this.dgcStorage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvStorage});
            // 
            // dgvStorage
            // 
            this.dgvStorage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStorageDate,
            this.colCategoryId,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colStoreCount,
            this.colStoreWeight,
            this.colStoreVolume});
            this.dgvStorage.GridControl = this.dgcStorage;
            this.dgvStorage.Name = "dgvStorage";
            this.dgvStorage.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvStorage.OptionsBehavior.Editable = false;
            this.dgvStorage.OptionsCustomization.AllowGroup = false;
            this.dgvStorage.OptionsFind.AllowFindPanel = false;
            this.dgvStorage.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvStorage.OptionsView.EnableAppearanceEvenRow = true;
            this.dgvStorage.OptionsView.EnableAppearanceOddRow = true;
            this.dgvStorage.OptionsView.ShowFooter = true;
            this.dgvStorage.OptionsView.ShowGroupPanel = false;
            // 
            // bsStorage
            // 
            this.bsStorage.DataSource = typeof(Phoebe.Model.TotalStorage);
            // 
            // colStorageDate
            // 
            this.colStorageDate.Caption = "日期";
            this.colStorageDate.FieldName = "StorageDate";
            this.colStorageDate.Name = "colStorageDate";
            this.colStorageDate.Visible = true;
            this.colStorageDate.VisibleIndex = 0;
            // 
            // colCategoryId
            // 
            this.colCategoryId.FieldName = "CategoryId";
            this.colCategoryId.Name = "colCategoryId";
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.Caption = "分类编码";
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            this.colCategoryNumber.Visible = true;
            this.colCategoryNumber.VisibleIndex = 1;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "分类名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 2;
            // 
            // colStoreCount
            // 
            this.colStoreCount.Caption = "在库数量";
            this.colStoreCount.FieldName = "StoreCount";
            this.colStoreCount.Name = "colStoreCount";
            this.colStoreCount.Visible = true;
            this.colStoreCount.VisibleIndex = 3;
            // 
            // colStoreWeight
            // 
            this.colStoreWeight.Caption = "在库重量(t)";
            this.colStoreWeight.FieldName = "StoreWeight";
            this.colStoreWeight.Name = "colStoreWeight";
            this.colStoreWeight.Visible = true;
            this.colStoreWeight.VisibleIndex = 4;
            // 
            // colStoreVolume
            // 
            this.colStoreVolume.Caption = "在库体积(立方)";
            this.colStoreVolume.FieldName = "StoreVolume";
            this.colStoreVolume.Name = "colStoreVolume";
            this.colStoreVolume.Visible = true;
            this.colStoreVolume.VisibleIndex = 5;
            // 
            // TotalStorageGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgcStorage);
            this.Name = "TotalStorageGrid";
            this.Size = new System.Drawing.Size(692, 475);
            ((System.ComponentModel.ISupportInitialize)(this.dgcStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsStorage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgcStorage;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvStorage;
        private System.Windows.Forms.BindingSource bsStorage;
        private DevExpress.XtraGrid.Columns.GridColumn colStorageDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreCount;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreWeight;
        private DevExpress.XtraGrid.Columns.GridColumn colStoreVolume;
    }
}
