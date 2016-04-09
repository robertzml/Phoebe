namespace Phoebe.FormUI
{
    partial class SettleRealForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDifference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPaidFee = new System.Windows.Forms.TextBox();
            this.textBoxRealFee = new System.Windows.Forms.TextBox();
            this.textBoxSettleFee = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSumFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(841, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(75, 32);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(154, 20);
            this.comboBoxCustomer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "客户选择";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(291, 30);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 0;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxSumFee);
            this.groupBox2.Controls.Add(this.textBoxDifference);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxPaidFee);
            this.groupBox2.Controls.Add(this.textBoxRealFee);
            this.groupBox2.Controls.Add(this.textBoxSettleFee);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(841, 145);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结算信息";
            // 
            // textBoxDifference
            // 
            this.textBoxDifference.Location = new System.Drawing.Point(301, 98);
            this.textBoxDifference.Name = "textBoxDifference";
            this.textBoxDifference.ReadOnly = true;
            this.textBoxDifference.Size = new System.Drawing.Size(120, 21);
            this.textBoxDifference.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "差额";
            // 
            // textBoxPaidFee
            // 
            this.textBoxPaidFee.Location = new System.Drawing.Point(75, 98);
            this.textBoxPaidFee.Name = "textBoxPaidFee";
            this.textBoxPaidFee.ReadOnly = true;
            this.textBoxPaidFee.Size = new System.Drawing.Size(120, 21);
            this.textBoxPaidFee.TabIndex = 5;
            // 
            // textBoxRealFee
            // 
            this.textBoxRealFee.Location = new System.Drawing.Point(301, 45);
            this.textBoxRealFee.Name = "textBoxRealFee";
            this.textBoxRealFee.ReadOnly = true;
            this.textBoxRealFee.Size = new System.Drawing.Size(120, 21);
            this.textBoxRealFee.TabIndex = 4;
            // 
            // textBoxSettleFee
            // 
            this.textBoxSettleFee.Location = new System.Drawing.Point(75, 45);
            this.textBoxSettleFee.Name = "textBoxSettleFee";
            this.textBoxSettleFee.ReadOnly = true;
            this.textBoxSettleFee.Size = new System.Drawing.Size(120, 21);
            this.textBoxSettleFee.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "已付款";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "未结算费用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "结算费用";
            // 
            // textBoxSumFee
            // 
            this.textBoxSumFee.Location = new System.Drawing.Point(539, 45);
            this.textBoxSumFee.Name = "textBoxSumFee";
            this.textBoxSumFee.ReadOnly = true;
            this.textBoxSumFee.Size = new System.Drawing.Size(120, 21);
            this.textBoxSumFee.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "费用合计";
            // 
            // SettleRealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettleRealForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "实时结算";
            this.Load += new System.EventHandler(this.SettleRealForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRealFee;
        private System.Windows.Forms.TextBox textBoxSettleFee;
        private System.Windows.Forms.TextBox textBoxDifference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPaidFee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSumFee;
    }
}