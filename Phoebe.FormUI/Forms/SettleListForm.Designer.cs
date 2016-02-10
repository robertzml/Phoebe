namespace Phoebe.FormUI
{
    partial class SettleListForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.settlementDataGridView = new System.Windows.Forms.DataGridView();
            this.settlementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settleTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settlementDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settlementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.comboBoxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(635, 31);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 2;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(78, 33);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(140, 21);
            this.comboBoxCustomer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.settlementDataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(764, 305);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结算记录";
            // 
            // settlementDataGridView
            // 
            this.settlementDataGridView.AllowUserToAddRows = false;
            this.settlementDataGridView.AllowUserToDeleteRows = false;
            this.settlementDataGridView.AutoGenerateColumns = false;
            this.settlementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.settlementDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn,
            this.endTimeDataGridViewTextBoxColumn,
            this.sumFeeDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.remissionDataGridViewTextBoxColumn,
            this.dueFeeDataGridViewTextBoxColumn,
            this.settleTimeDataGridViewTextBoxColumn,
            this.columnUser,
            this.remarkDataGridViewTextBoxColumn,
            this.columnStatus});
            this.settlementDataGridView.DataSource = this.settlementBindingSource;
            this.settlementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settlementDataGridView.Location = new System.Drawing.Point(3, 16);
            this.settlementDataGridView.Name = "settlementDataGridView";
            this.settlementDataGridView.ReadOnly = true;
            this.settlementDataGridView.Size = new System.Drawing.Size(758, 286);
            this.settlementDataGridView.TabIndex = 0;
            this.settlementDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.settlementDataGridView_RowPrePaint);
            // 
            // settlementBindingSource
            // 
            this.settlementBindingSource.DataSource = typeof(Phoebe.Model.Settlement);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "结算单号";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "开始日期";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "结束日期";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumFeeDataGridViewTextBoxColumn
            // 
            this.sumFeeDataGridViewTextBoxColumn.DataPropertyName = "SumFee";
            this.sumFeeDataGridViewTextBoxColumn.HeaderText = "费用合计";
            this.sumFeeDataGridViewTextBoxColumn.Name = "sumFeeDataGridViewTextBoxColumn";
            this.sumFeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // discountDataGridViewTextBoxColumn
            // 
            this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
            this.discountDataGridViewTextBoxColumn.HeaderText = "折扣率(%)";
            this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
            this.discountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remissionDataGridViewTextBoxColumn
            // 
            this.remissionDataGridViewTextBoxColumn.DataPropertyName = "Remission";
            this.remissionDataGridViewTextBoxColumn.HeaderText = "减免费用";
            this.remissionDataGridViewTextBoxColumn.Name = "remissionDataGridViewTextBoxColumn";
            this.remissionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dueFeeDataGridViewTextBoxColumn
            // 
            this.dueFeeDataGridViewTextBoxColumn.DataPropertyName = "DueFee";
            this.dueFeeDataGridViewTextBoxColumn.HeaderText = "应付款";
            this.dueFeeDataGridViewTextBoxColumn.Name = "dueFeeDataGridViewTextBoxColumn";
            this.dueFeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // settleTimeDataGridViewTextBoxColumn
            // 
            this.settleTimeDataGridViewTextBoxColumn.DataPropertyName = "SettleTime";
            dataGridViewCellStyle1.Format = "d";
            this.settleTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.settleTimeDataGridViewTextBoxColumn.HeaderText = "结算时间";
            this.settleTimeDataGridViewTextBoxColumn.Name = "settleTimeDataGridViewTextBoxColumn";
            this.settleTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnUser
            // 
            this.columnUser.HeaderText = "结算人";
            this.columnUser.Name = "columnUser";
            this.columnUser.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnStatus
            // 
            this.columnStatus.HeaderText = "状态";
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.ReadOnly = true;
            // 
            // SettleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 395);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettleListForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "结算记录";
            this.Load += new System.EventHandler(this.SettleListForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settlementDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settlementBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView settlementDataGridView;
        private System.Windows.Forms.BindingSource settlementBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn settleTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatus;
    }
}