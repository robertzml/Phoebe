namespace Phoebe.FormUI
{
    partial class StockSnapshootForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.radioCargo = new System.Windows.Forms.RadioButton();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioContract = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.storageDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stockFlowDataGridView = new System.Windows.Forms.DataGridView();
            this.stockFlowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFlowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockFlowDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockFlowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Controls.Add(this.radioCargo);
            this.groupBox1.Controls.Add(this.comboBoxCargo);
            this.groupBox1.Controls.Add(this.comboBoxContract);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxCustomer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioContract);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "日期选择";
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(532, 61);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 23);
            this.buttonQuery.TabIndex = 9;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(344, 64);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(145, 20);
            this.datePicker.TabIndex = 8;
            // 
            // radioCargo
            // 
            this.radioCargo.AutoSize = true;
            this.radioCargo.Location = new System.Drawing.Point(147, 64);
            this.radioCargo.Name = "radioCargo";
            this.radioCargo.Size = new System.Drawing.Size(61, 17);
            this.radioCargo.TabIndex = 7;
            this.radioCargo.Text = "按货品";
            this.radioCargo.UseVisualStyleBackColor = true;
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Location = new System.Drawing.Point(590, 25);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(145, 21);
            this.comboBoxCargo.TabIndex = 6;
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(344, 25);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(145, 21);
            this.comboBoxContract.TabIndex = 5;
            this.comboBoxContract.SelectedIndexChanged += new System.EventHandler(this.comboBoxContract_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "合同选择";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(87, 25);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(145, 21);
            this.comboBoxCustomer.TabIndex = 3;
            this.comboBoxCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomer_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(529, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "货品选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "客户选择";
            // 
            // radioContract
            // 
            this.radioContract.AutoSize = true;
            this.radioContract.Checked = true;
            this.radioContract.Location = new System.Drawing.Point(29, 64);
            this.radioContract.Name = "radioContract";
            this.radioContract.Size = new System.Drawing.Size(61, 17);
            this.radioContract.TabIndex = 0;
            this.radioContract.TabStop = true;
            this.radioContract.Text = "按合同";
            this.radioContract.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.storageDataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(944, 268);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存记录";
            // 
            // storageDataGridView
            // 
            this.storageDataGridView.AllowUserToAddRows = false;
            this.storageDataGridView.AllowUserToDeleteRows = false;
            this.storageDataGridView.AutoGenerateColumns = false;
            this.storageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.columnSource});
            this.storageDataGridView.DataSource = this.storageBindingSource;
            this.storageDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.storageDataGridView.Location = new System.Drawing.Point(3, 16);
            this.storageDataGridView.Name = "storageDataGridView";
            this.storageDataGridView.ReadOnly = true;
            this.storageDataGridView.Size = new System.Drawing.Size(938, 249);
            this.storageDataGridView.TabIndex = 0;
            this.storageDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.storageDataGridView_RowPrePaint);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn2.HeaderText = "仓库";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "CargoName";
            this.dataGridViewTextBoxColumn6.HeaderText = "货品名称";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ContractName";
            this.dataGridViewTextBoxColumn7.HeaderText = "合同名称";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "FirstCategoryName";
            this.dataGridViewTextBoxColumn9.HeaderText = "一级分类";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "SecondCategoryName";
            this.dataGridViewTextBoxColumn11.HeaderText = "二级分类";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ThirdCategoryName";
            this.dataGridViewTextBoxColumn13.HeaderText = "三级分类";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn14.HeaderText = "在库数量";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Weight";
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn15.HeaderText = "在库重量(t)";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 120;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "InTime";
            dataGridViewCellStyle6.Format = "d";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn16.HeaderText = "入库时间";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // columnSource
            // 
            this.columnSource.HeaderText = "来源";
            this.columnSource.Name = "columnSource";
            this.columnSource.ReadOnly = true;
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataSource = typeof(Phoebe.Model.Storage);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stockFlowDataGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 380);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(944, 219);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "流水记录";
            // 
            // stockFlowDataGridView
            // 
            this.stockFlowDataGridView.AllowUserToAddRows = false;
            this.stockFlowDataGridView.AllowUserToDeleteRows = false;
            this.stockFlowDataGridView.AutoGenerateColumns = false;
            this.stockFlowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockFlowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn25,
            this.columnFlowType,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24});
            this.stockFlowDataGridView.DataSource = this.stockFlowBindingSource;
            this.stockFlowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockFlowDataGridView.Location = new System.Drawing.Point(3, 16);
            this.stockFlowDataGridView.Name = "stockFlowDataGridView";
            this.stockFlowDataGridView.ReadOnly = true;
            this.stockFlowDataGridView.Size = new System.Drawing.Size(938, 200);
            this.stockFlowDataGridView.TabIndex = 0;
            this.stockFlowDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.stockFlowDataGridView_RowPrePaint);
            // 
            // stockFlowBindingSource
            // 
            this.stockFlowBindingSource.DataSource = typeof(Phoebe.Model.StockFlow);
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "FlowDate";
            dataGridViewCellStyle7.Format = "d";
            this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn25.HeaderText = "流水日期";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // columnFlowType
            // 
            this.columnFlowType.HeaderText = "流水类型";
            this.columnFlowType.Name = "columnFlowType";
            this.columnFlowType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn3.HeaderText = "客户名称";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ContractName";
            this.dataGridViewTextBoxColumn5.HeaderText = "合同名称";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "CargoName";
            this.dataGridViewTextBoxColumn10.HeaderText = "货品名称";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "FirstCategoryName";
            this.dataGridViewTextBoxColumn17.HeaderText = "一级分类";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "SecondCategoryName";
            this.dataGridViewTextBoxColumn19.HeaderText = "二级分类";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "ThirdCategoryName";
            this.dataGridViewTextBoxColumn21.HeaderText = "三级分类";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn22.HeaderText = "流水数量";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "UnitWeight";
            this.dataGridViewTextBoxColumn23.HeaderText = "单位重量(kg)";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Weight";
            dataGridViewCellStyle8.Format = "N3";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn24.HeaderText = "流水重量(t)";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // StockSnapshootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(950, 602);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "StockSnapshootForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "库存快照";
            this.Load += new System.EventHandler(this.StockSnapshootForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.storageDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockFlowDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockFlowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.RadioButton radioCargo;
        private System.Windows.Forms.ComboBox comboBoxCargo;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioContract;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView storageDataGridView;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSource;
        private System.Windows.Forms.DataGridView stockFlowDataGridView;
        private System.Windows.Forms.BindingSource stockFlowBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFlowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
    }
}