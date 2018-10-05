namespace Phoebe.ClientDx
{
    partial class CategoryTree
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
            this.treeCategory = new DevExpress.XtraTreeList.TreeList();
            this.colNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colHierarchy = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsCategory = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // treeCategory
            // 
            this.treeCategory.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colNumber,
            this.colParentId,
            this.colHierarchy,
            this.colId,
            this.colName});
            this.treeCategory.DataSource = this.bsCategory;
            this.treeCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeCategory.KeyFieldName = "Id";
            this.treeCategory.Location = new System.Drawing.Point(0, 0);
            this.treeCategory.Name = "treeCategory";
            this.treeCategory.OptionsBehavior.Editable = false;
            this.treeCategory.OptionsBehavior.PopulateServiceColumns = true;
            this.treeCategory.OptionsCustomization.AllowFilter = false;
            this.treeCategory.OptionsCustomization.AllowSort = false;
            this.treeCategory.OptionsFilter.AllowFilterEditor = false;
            this.treeCategory.OptionsMenu.EnableColumnMenu = false;
            this.treeCategory.OptionsMenu.EnableFooterMenu = false;
            this.treeCategory.ParentFieldName = "ParentId";
            this.treeCategory.Size = new System.Drawing.Size(275, 488);
            this.treeCategory.TabIndex = 0;
            this.treeCategory.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeCategory_FocusedNodeChanged);
            // 
            // colNumber
            // 
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            // 
            // colHierarchy
            // 
            this.colHierarchy.FieldName = "Hierarchy";
            this.colHierarchy.Name = "colHierarchy";
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
            // bsCategory
            // 
            this.bsCategory.DataSource = typeof(Phoebe.Core.DL.Category);
            // 
            // CategoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeCategory);
            this.Name = "CategoryTree";
            this.Size = new System.Drawing.Size(275, 488);
            ((System.ComponentModel.ISupportInitialize)(this.treeCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeCategory;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colHierarchy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource bsCategory;
    }
}
