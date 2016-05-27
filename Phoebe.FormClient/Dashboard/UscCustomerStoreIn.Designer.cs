namespace Phoebe.FormClient
{
    partial class UscCustomerStoreIn
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.sgList = new Phoebe.FormClient.StoreGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.sgList);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(927, 492);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "库存信息";
            // 
            // sgList
            // 
            this.sgList.DataSource = null;
            this.sgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgList.EnableColumn = true;
            this.sgList.EnableFilter = true;
            this.sgList.EnableFind = true;
            this.sgList.EnableGroup = true;
            this.sgList.Location = new System.Drawing.Point(2, 21);
            this.sgList.Name = "sgList";
            this.sgList.ShowContract = true;
            this.sgList.ShowCustomer = false;
            this.sgList.ShowFooter = true;
            this.sgList.Size = new System.Drawing.Size(923, 469);
            this.sgList.TabIndex = 0;
            // 
            // UscCustomerStoreIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UscCustomerStoreIn";
            this.Size = new System.Drawing.Size(927, 492);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private StoreGrid sgList;
    }
}
