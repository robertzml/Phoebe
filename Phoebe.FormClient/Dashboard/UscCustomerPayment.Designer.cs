namespace Phoebe.FormClient
{
    partial class UscCustomerPayment
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
            this.spgList = new Phoebe.FormClient.PaymentGrid();
            this.SuspendLayout();
            // 
            // spgList
            // 
            this.spgList.DataSource = null;
            this.spgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spgList.EnableFind = false;
            this.spgList.Location = new System.Drawing.Point(0, 0);
            this.spgList.Margin = new System.Windows.Forms.Padding(2);
            this.spgList.Name = "spgList";
            this.spgList.Size = new System.Drawing.Size(593, 350);
            this.spgList.TabIndex = 0;
            // 
            // UscCustomerPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spgList);
            this.Name = "UscCustomerPayment";
            this.Size = new System.Drawing.Size(593, 350);
            this.ResumeLayout(false);

        }

        #endregion

        private PaymentGrid spgList;
    }
}
