namespace Phoebe.FormUI
{
    partial class ColdPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColdPriceForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.radioCargo = new System.Windows.Forms.RadioButton();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.radioContract = new System.Windows.Forms.RadioButton();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dailyColdRecordDataGridView = new System.Windows.Forms.DataGridView();
            this.dailyColdRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dailyColdRecordBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFlowType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnUnitMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnFlowMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStoreMeter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordBindingNavigator)).BeginInit();
            this.dailyColdRecordBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateEnd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.radioCargo);
            this.groupBox1.Controls.Add(this.buttonQuery);
            this.groupBox1.Controls.Add(this.radioContract);
            this.groupBox1.Controls.Add(this.dateStart);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxCargo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxContract);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxCustomer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(916, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(621, 86);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(175, 20);
            this.dateEnd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "结束日期";
            // 
            // radioCargo
            // 
            this.radioCargo.AutoSize = true;
            this.radioCargo.Location = new System.Drawing.Point(136, 88);
            this.radioCargo.Name = "radioCargo";
            this.radioCargo.Size = new System.Drawing.Size(61, 17);
            this.radioCargo.TabIndex = 9;
            this.radioCargo.Text = "按货品";
            this.radioCargo.UseVisualStyleBackColor = true;
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(835, 84);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(75, 25);
            this.buttonQuery.TabIndex = 8;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // radioContract
            // 
            this.radioContract.AutoSize = true;
            this.radioContract.Checked = true;
            this.radioContract.Location = new System.Drawing.Point(18, 88);
            this.radioContract.Name = "radioContract";
            this.radioContract.Size = new System.Drawing.Size(61, 17);
            this.radioContract.TabIndex = 8;
            this.radioContract.TabStop = true;
            this.radioContract.Text = "按合同";
            this.radioContract.UseVisualStyleBackColor = true;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(346, 86);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(175, 20);
            this.dateStart.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "开始日期";
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Location = new System.Drawing.Point(621, 32);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(175, 21);
            this.comboBoxCargo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "货品选择";
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(344, 32);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(175, 21);
            this.comboBoxContract.TabIndex = 3;
            this.comboBoxContract.SelectedIndexChanged += new System.EventHandler(this.comboBoxContract_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "合同选择";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(74, 32);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(175, 21);
            this.comboBoxCustomer.TabIndex = 1;
            this.comboBoxCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomer_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户选择";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dailyColdRecordDataGridView);
            this.groupBox2.Controls.Add(this.dailyColdRecordBindingNavigator);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(916, 385);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "冷藏费清单";
            // 
            // dailyColdRecordDataGridView
            // 
            this.dailyColdRecordDataGridView.AllowUserToAddRows = false;
            this.dailyColdRecordDataGridView.AllowUserToDeleteRows = false;
            this.dailyColdRecordDataGridView.AutoGenerateColumns = false;
            this.dailyColdRecordDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyColdRecordDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.columnFlowType,
            this.dataGridViewTextBoxColumn3,
            this.columnUnitMeter,
            this.columnFlowMeter,
            this.columnStoreMeter,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dailyColdRecordDataGridView.DataSource = this.dailyColdRecordBindingSource;
            this.dailyColdRecordDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyColdRecordDataGridView.Location = new System.Drawing.Point(3, 41);
            this.dailyColdRecordDataGridView.Name = "dailyColdRecordDataGridView";
            this.dailyColdRecordDataGridView.ReadOnly = true;
            this.dailyColdRecordDataGridView.Size = new System.Drawing.Size(910, 341);
            this.dailyColdRecordDataGridView.TabIndex = 0;
            this.dailyColdRecordDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dailyColdRecordDataGridView_RowPrePaint);
            // 
            // dailyColdRecordBindingSource
            // 
            this.dailyColdRecordBindingSource.DataSource = typeof(Phoebe.Model.DailyColdRecord);
            // 
            // dailyColdRecordBindingNavigator
            // 
            this.dailyColdRecordBindingNavigator.AddNewItem = null;
            this.dailyColdRecordBindingNavigator.BindingSource = this.dailyColdRecordBindingSource;
            this.dailyColdRecordBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dailyColdRecordBindingNavigator.DeleteItem = null;
            this.dailyColdRecordBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.dailyColdRecordBindingNavigator.Location = new System.Drawing.Point(3, 16);
            this.dailyColdRecordBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dailyColdRecordBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dailyColdRecordBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dailyColdRecordBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dailyColdRecordBindingNavigator.Name = "dailyColdRecordBindingNavigator";
            this.dailyColdRecordBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dailyColdRecordBindingNavigator.Size = new System.Drawing.Size(910, 25);
            this.dailyColdRecordBindingNavigator.TabIndex = 3;
            this.dailyColdRecordBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(32, 22);
            this.bindingNavigatorCountItem.Text = "/ {0}";
            this.bindingNavigatorCountItem.ToolTipText = "总项数";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到第一条记录";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一条记录";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "当前位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一条记录";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最后一条记录";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RecordDate";
            dataGridViewCellStyle1.Format = "d";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "日期";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "CargoName";
            this.dataGridViewTextBoxColumn2.HeaderText = "货品名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // columnFlowType
            // 
            this.columnFlowType.HeaderText = "出入库类型";
            this.columnFlowType.Name = "columnFlowType";
            this.columnFlowType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn3.HeaderText = "出入库数量";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // columnUnitMeter
            // 
            this.columnUnitMeter.DataPropertyName = "UnitMeter";
            this.columnUnitMeter.HeaderText = "单位重量(kg)";
            this.columnUnitMeter.Name = "columnUnitMeter";
            this.columnUnitMeter.ReadOnly = true;
            this.columnUnitMeter.Width = 120;
            // 
            // columnFlowMeter
            // 
            this.columnFlowMeter.DataPropertyName = "FlowMeter";
            this.columnFlowMeter.HeaderText = "出入库重量(t)";
            this.columnFlowMeter.Name = "columnFlowMeter";
            this.columnFlowMeter.ReadOnly = true;
            this.columnFlowMeter.Width = 120;
            // 
            // columnStoreMeter
            // 
            this.columnStoreMeter.DataPropertyName = "TotalMeter";
            this.columnStoreMeter.HeaderText = "在库重量(t)";
            this.columnStoreMeter.Name = "columnStoreMeter";
            this.columnStoreMeter.ReadOnly = true;
            this.columnStoreMeter.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DailyFee";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn7.HeaderText = "日冷藏费(元)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TotalFee";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.HeaderText = "冷藏费累计(元)";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // ColdPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 526);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ColdPriceForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "冷藏费清单";
            this.Load += new System.EventHandler(this.ColdPriceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dailyColdRecordBindingNavigator)).EndInit();
            this.dailyColdRecordBindingNavigator.ResumeLayout(false);
            this.dailyColdRecordBindingNavigator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxCargo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioCargo;
        private System.Windows.Forms.RadioButton radioContract;
        private System.Windows.Forms.DataGridView dailyColdRecordDataGridView;
        private System.Windows.Forms.BindingSource dailyColdRecordBindingSource;
        private System.Windows.Forms.BindingNavigator dailyColdRecordBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFlowType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnUnitMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnFlowMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnStoreMeter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}