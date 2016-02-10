namespace Phoebe.FormUI
{
    partial class AccountForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.settlementDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.settlementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paymentDataGridView = new System.Windows.Forms.DataGridView();
            this.paymentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remissionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dueFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settleTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSettlementUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paidTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPaymentUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericDueFee = new System.Windows.Forms.NumericUpDown();
            this.numericPaidFee = new System.Windows.Forms.NumericUpDown();
            this.numericDebtFee = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settlementDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settlementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDueFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPaidFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDebtFee)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(880, 449);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.comboBoxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(293, 48);
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
            this.comboBoxCustomer.Location = new System.Drawing.Point(78, 50);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(140, 21);
            this.comboBoxCustomer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.settlementDataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 323);
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
            this.columnSettlementUser,
            this.remarkDataGridViewTextBoxColumn});
            this.settlementDataGridView.DataSource = this.settlementBindingSource;
            this.settlementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settlementDataGridView.Location = new System.Drawing.Point(3, 16);
            this.settlementDataGridView.Name = "settlementDataGridView";
            this.settlementDataGridView.ReadOnly = true;
            this.settlementDataGridView.Size = new System.Drawing.Size(428, 304);
            this.settlementDataGridView.TabIndex = 0;
            this.settlementDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.settlementDataGridView_RowPrePaint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericDebtFee);
            this.groupBox3.Controls.Add(this.numericPaidFee);
            this.groupBox3.Controls.Add(this.numericDueFee);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(443, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 114);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "费用信息";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.paymentDataGridView);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(443, 123);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(434, 323);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "缴费记录";
            // 
            // settlementBindingSource
            // 
            this.settlementBindingSource.DataSource = typeof(Phoebe.Model.Settlement);
            // 
            // paymentDataGridView
            // 
            this.paymentDataGridView.AllowUserToAddRows = false;
            this.paymentDataGridView.AllowUserToDeleteRows = false;
            this.paymentDataGridView.AutoGenerateColumns = false;
            this.paymentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paidFeeDataGridViewTextBoxColumn,
            this.paidTimeDataGridViewTextBoxColumn,
            this.columnPaymentUser,
            this.remarkDataGridViewTextBoxColumn1});
            this.paymentDataGridView.DataSource = this.paymentBindingSource;
            this.paymentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paymentDataGridView.Location = new System.Drawing.Point(3, 16);
            this.paymentDataGridView.Name = "paymentDataGridView";
            this.paymentDataGridView.ReadOnly = true;
            this.paymentDataGridView.Size = new System.Drawing.Size(428, 304);
            this.paymentDataGridView.TabIndex = 0;
            this.paymentDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.paymentDataGridView_RowPrePaint);
            // 
            // paymentBindingSource
            // 
            this.paymentBindingSource.DataSource = typeof(Phoebe.Model.Payment);
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
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "开始时间";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            this.endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            this.endTimeDataGridViewTextBoxColumn.HeaderText = "结束时间";
            this.endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            this.endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumFeeDataGridViewTextBoxColumn
            // 
            this.sumFeeDataGridViewTextBoxColumn.DataPropertyName = "SumFee";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.sumFeeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.sumFeeDataGridViewTextBoxColumn.HeaderText = "费用合计(元)";
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
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.remissionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.remissionDataGridViewTextBoxColumn.HeaderText = "减免费用(元)";
            this.remissionDataGridViewTextBoxColumn.Name = "remissionDataGridViewTextBoxColumn";
            this.remissionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dueFeeDataGridViewTextBoxColumn
            // 
            this.dueFeeDataGridViewTextBoxColumn.DataPropertyName = "DueFee";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dueFeeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dueFeeDataGridViewTextBoxColumn.HeaderText = "应付款(元)";
            this.dueFeeDataGridViewTextBoxColumn.Name = "dueFeeDataGridViewTextBoxColumn";
            this.dueFeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // settleTimeDataGridViewTextBoxColumn
            // 
            this.settleTimeDataGridViewTextBoxColumn.DataPropertyName = "SettleTime";
            dataGridViewCellStyle4.Format = "d";
            this.settleTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.settleTimeDataGridViewTextBoxColumn.HeaderText = "结算时间";
            this.settleTimeDataGridViewTextBoxColumn.Name = "settleTimeDataGridViewTextBoxColumn";
            this.settleTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnSettlementUser
            // 
            this.columnSettlementUser.HeaderText = "结算人";
            this.columnSettlementUser.Name = "columnSettlementUser";
            this.columnSettlementUser.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paidFeeDataGridViewTextBoxColumn
            // 
            this.paidFeeDataGridViewTextBoxColumn.DataPropertyName = "PaidFee";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.paidFeeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.paidFeeDataGridViewTextBoxColumn.HeaderText = "缴费金额(元)";
            this.paidFeeDataGridViewTextBoxColumn.Name = "paidFeeDataGridViewTextBoxColumn";
            this.paidFeeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // paidTimeDataGridViewTextBoxColumn
            // 
            this.paidTimeDataGridViewTextBoxColumn.DataPropertyName = "PaidTime";
            this.paidTimeDataGridViewTextBoxColumn.HeaderText = "缴费时间";
            this.paidTimeDataGridViewTextBoxColumn.Name = "paidTimeDataGridViewTextBoxColumn";
            this.paidTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // columnPaymentUser
            // 
            this.columnPaymentUser.HeaderText = "收款人";
            this.columnPaymentUser.Name = "columnPaymentUser";
            this.columnPaymentUser.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn1
            // 
            this.remarkDataGridViewTextBoxColumn1.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn1.HeaderText = "备注";
            this.remarkDataGridViewTextBoxColumn1.Name = "remarkDataGridViewTextBoxColumn1";
            this.remarkDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "累计应缴费";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "累计实缴费";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "累计欠款";
            // 
            // numericDueFee
            // 
            this.numericDueFee.DecimalPlaces = 2;
            this.numericDueFee.Location = new System.Drawing.Point(80, 31);
            this.numericDueFee.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericDueFee.Name = "numericDueFee";
            this.numericDueFee.ReadOnly = true;
            this.numericDueFee.Size = new System.Drawing.Size(120, 20);
            this.numericDueFee.TabIndex = 3;
            // 
            // numericPaidFee
            // 
            this.numericPaidFee.DecimalPlaces = 2;
            this.numericPaidFee.Location = new System.Drawing.Point(301, 31);
            this.numericPaidFee.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericPaidFee.Name = "numericPaidFee";
            this.numericPaidFee.ReadOnly = true;
            this.numericPaidFee.Size = new System.Drawing.Size(120, 20);
            this.numericPaidFee.TabIndex = 4;
            // 
            // numericDebtFee
            // 
            this.numericDebtFee.DecimalPlaces = 2;
            this.numericDebtFee.Location = new System.Drawing.Point(80, 72);
            this.numericDebtFee.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericDebtFee.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.numericDebtFee.Name = "numericDebtFee";
            this.numericDebtFee.ReadOnly = true;
            this.numericDebtFee.Size = new System.Drawing.Size(120, 20);
            this.numericDebtFee.TabIndex = 5;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 455);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AccountForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "客户对账";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settlementDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.settlementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paymentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDueFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPaidFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDebtFee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView settlementDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource settlementBindingSource;
        private System.Windows.Forms.DataGridView paymentDataGridView;
        private System.Windows.Forms.BindingSource paymentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remissionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dueFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn settleTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSettlementUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paidTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPaymentUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.NumericUpDown numericDebtFee;
        private System.Windows.Forms.NumericUpDown numericPaidFee;
        private System.Windows.Forms.NumericUpDown numericDueFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}