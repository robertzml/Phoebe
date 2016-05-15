namespace Phoebe.FormClient
{
    partial class CustomerListControl
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
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.CustomerNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.gpMain)).BeginInit();
            this.gpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpMain
            // 
            this.gpMain.Controls.Add(this.lvCustomer);
            this.gpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpMain.Location = new System.Drawing.Point(0, 0);
            this.gpMain.Name = "gpMain";
            this.gpMain.Size = new System.Drawing.Size(220, 285);
            this.gpMain.TabIndex = 0;
            this.gpMain.Text = "客户列表";
            // 
            // lvCustomer
            // 
            this.lvCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CustomerNumber,
            this.CustomerName});
            this.lvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomer.FullRowSelect = true;
            this.lvCustomer.Location = new System.Drawing.Point(2, 21);
            this.lvCustomer.MultiSelect = false;
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.Size = new System.Drawing.Size(216, 262);
            this.lvCustomer.TabIndex = 2;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.View = System.Windows.Forms.View.Details;
            this.lvCustomer.SelectedIndexChanged += new System.EventHandler(this.lvCustomer_SelectedIndexChanged);
            // 
            // CustomerNumber
            // 
            this.CustomerNumber.Text = "编号";
            this.CustomerNumber.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "名称";
            this.CustomerName.Width = 150;
            // 
            // CustomerListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpMain);
            this.Name = "CustomerListControl";
            this.Size = new System.Drawing.Size(220, 285);
            this.Load += new System.EventHandler(this.CustomerListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gpMain)).EndInit();
            this.gpMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gpMain;
        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.ColumnHeader CustomerNumber;
        private System.Windows.Forms.ColumnHeader CustomerName;
    }
}
