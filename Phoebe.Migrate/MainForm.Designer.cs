namespace Phoebe.Migrate
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelCustomer = new System.Windows.Forms.Button();
            this.btnDelContract = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnContract = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnContract);
            this.groupBox1.Controls.Add(this.btnCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "迁移";
            // 
            // btnCustomer
            // 
            this.btnCustomer.Location = new System.Drawing.Point(34, 31);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(112, 44);
            this.btnCustomer.TabIndex = 0;
            this.btnCustomer.Text = "迁移客户";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelContract);
            this.groupBox2.Controls.Add(this.btnDelCustomer);
            this.groupBox2.Location = new System.Drawing.Point(12, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 213);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "删除";
            // 
            // btnDelCustomer
            // 
            this.btnDelCustomer.Location = new System.Drawing.Point(34, 35);
            this.btnDelCustomer.Name = "btnDelCustomer";
            this.btnDelCustomer.Size = new System.Drawing.Size(112, 44);
            this.btnDelCustomer.TabIndex = 1;
            this.btnDelCustomer.Text = "删除客户";
            this.btnDelCustomer.UseVisualStyleBackColor = true;
            this.btnDelCustomer.Click += new System.EventHandler(this.btnDelCustomer_Click);
            // 
            // btnDelContract
            // 
            this.btnDelContract.Location = new System.Drawing.Point(190, 35);
            this.btnDelContract.Name = "btnDelContract";
            this.btnDelContract.Size = new System.Drawing.Size(112, 44);
            this.btnDelContract.TabIndex = 2;
            this.btnDelContract.Text = "删除合同";
            this.btnDelContract.UseVisualStyleBackColor = true;
            this.btnDelContract.Click += new System.EventHandler(this.btnDelContract_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(595, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(201, 430);
            this.txtMessage.TabIndex = 2;
            // 
            // btnContract
            // 
            this.btnContract.Location = new System.Drawing.Point(190, 31);
            this.btnContract.Name = "btnContract";
            this.btnContract.Size = new System.Drawing.Size(112, 44);
            this.btnContract.TabIndex = 1;
            this.btnContract.Text = "迁移合同";
            this.btnContract.UseVisualStyleBackColor = true;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 494);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "数据迁移";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelCustomer;
        private System.Windows.Forms.Button btnDelContract;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnContract;
    }
}

