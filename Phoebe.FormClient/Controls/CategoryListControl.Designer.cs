namespace Phoebe.FormClient
{
    partial class CategoryListControl
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
            this.gpMain = new DevExpress.XtraEditors.GroupControl();
            this.lvCategory = new System.Windows.Forms.ListView();
            this.CategoryNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.gpMain)).BeginInit();
            this.gpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpMain
            // 
            this.gpMain.Controls.Add(this.lvCategory);
            this.gpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpMain.Location = new System.Drawing.Point(0, 0);
            this.gpMain.Name = "gpMain";
            this.gpMain.Size = new System.Drawing.Size(220, 262);
            this.gpMain.TabIndex = 0;
            this.gpMain.Text = "类别编码";
            // 
            // lvCategory
            // 
            this.lvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CategoryNumber,
            this.CategoryName});
            this.lvCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCategory.FullRowSelect = true;
            this.lvCategory.Location = new System.Drawing.Point(2, 21);
            this.lvCategory.MultiSelect = false;
            this.lvCategory.Name = "lvCategory";
            this.lvCategory.Size = new System.Drawing.Size(216, 239);
            this.lvCategory.TabIndex = 1;
            this.lvCategory.UseCompatibleStateImageBehavior = false;
            this.lvCategory.View = System.Windows.Forms.View.Details;
            // 
            // CategoryNumber
            // 
            this.CategoryNumber.Text = "编码";
            this.CategoryNumber.Width = 100;
            // 
            // CategoryName
            // 
            this.CategoryName.Text = "名称";
            this.CategoryName.Width = 150;
            // 
            // CategoryListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpMain);
            this.Name = "CategoryListControl";
            this.Size = new System.Drawing.Size(220, 262);
            ((System.ComponentModel.ISupportInitialize)(this.gpMain)).EndInit();
            this.gpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpMain;
        private System.Windows.Forms.ListView lvCategory;
        private System.Windows.Forms.ColumnHeader CategoryNumber;
        private System.Windows.Forms.ColumnHeader CategoryName;
    }
}
