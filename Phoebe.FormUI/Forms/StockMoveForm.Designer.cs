namespace Phoebe.FormUI
{
    partial class StockMoveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockMoveForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeViewReceipt = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolNew = new System.Windows.Forms.ToolStripButton();
            this.打开OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolConfirm = new System.Windows.Forms.ToolStripButton();
            this.toolRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.comboBoxContract = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFlowNumber = new System.Windows.Forms.TextBox();
            this.dateBusinessTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.textBoxBusinessType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cargoDataGridView = new System.Windows.Forms.DataGridView();
            this.columnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnFirstCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnSecondCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnThirdCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMoveCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMoveWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnWarehouseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnNewWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cargoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingNavigator)).BeginInit();
            this.cargoBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeViewReceipt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 570);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单据";
            // 
            // treeViewReceipt
            // 
            this.treeViewReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewReceipt.Location = new System.Drawing.Point(3, 17);
            this.treeViewReceipt.Name = "treeViewReceipt";
            this.treeViewReceipt.Size = new System.Drawing.Size(166, 550);
            this.treeViewReceipt.TabIndex = 0;
            this.treeViewReceipt.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewReceipt_BeforeExpand);
            this.treeViewReceipt.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewReceipt_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolNew,
            this.打开OToolStripButton,
            this.toolSave,
            this.打印PToolStripButton,
            this.toolStripSeparator,
            this.toolConfirm,
            this.toolRefresh,
            this.toolDelete});
            this.toolStrip1.Location = new System.Drawing.Point(175, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(719, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolNew
            // 
            this.toolNew.Image = ((System.Drawing.Image)(resources.GetObject("toolNew.Image")));
            this.toolNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolNew.Name = "toolNew";
            this.toolNew.Size = new System.Drawing.Size(70, 22);
            this.toolNew.Text = "新建(&N)";
            this.toolNew.Click += new System.EventHandler(this.toolNew_Click);
            // 
            // 打开OToolStripButton
            // 
            this.打开OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripButton.Image")));
            this.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripButton.Name = "打开OToolStripButton";
            this.打开OToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.打开OToolStripButton.Text = "打开(&O)";
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(67, 22);
            this.toolSave.Text = "保存(&S)";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(67, 22);
            this.打印PToolStripButton.Text = "打印(&P)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolConfirm
            // 
            this.toolConfirm.Image = global::Phoebe.FormUI.Properties.Resources.check;
            this.toolConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolConfirm.Name = "toolConfirm";
            this.toolConfirm.Size = new System.Drawing.Size(76, 22);
            this.toolConfirm.Text = "移库确认";
            this.toolConfirm.Click += new System.EventHandler(this.toolConfirm_Click);
            // 
            // toolRefresh
            // 
            this.toolRefresh.Image = global::Phoebe.FormUI.Properties.Resources.refresh;
            this.toolRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolRefresh.Name = "toolRefresh";
            this.toolRefresh.Size = new System.Drawing.Size(52, 22);
            this.toolRefresh.Text = "刷新";
            this.toolRefresh.Click += new System.EventHandler(this.toolRefresh_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.Enabled = false;
            this.toolDelete.Image = global::Phoebe.FormUI.Properties.Resources.close_delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(52, 22);
            this.toolDelete.Text = "删除";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(175, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本信息";
            this.groupBox2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(1200, 0);
            this.panel1.Controls.Add(this.textBoxRemark);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.textBoxUser);
            this.panel1.Controls.Add(this.comboBoxContract);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxCustomer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxFlowNumber);
            this.panel1.Controls.Add(this.dateBusinessTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxStatus);
            this.panel1.Controls.Add(this.textBoxBusinessType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 124);
            this.panel1.TabIndex = 0;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(893, 60);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(147, 21);
            this.textBoxRemark.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(858, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 43;
            this.label15.Text = "备注";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(573, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 41;
            this.label16.Text = "业务员";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(620, 60);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.ReadOnly = true;
            this.textBoxUser.Size = new System.Drawing.Size(147, 21);
            this.textBoxUser.TabIndex = 42;
            this.textBoxUser.TabStop = false;
            // 
            // comboBoxContract
            // 
            this.comboBoxContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxContract.FormattingEnabled = true;
            this.comboBoxContract.Location = new System.Drawing.Point(338, 60);
            this.comboBoxContract.Name = "comboBoxContract";
            this.comboBoxContract.Size = new System.Drawing.Size(147, 20);
            this.comboBoxContract.TabIndex = 2;
            this.comboBoxContract.SelectedIndexChanged += new System.EventHandler(this.comboBoxContract_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "所属客户";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(75, 60);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(147, 20);
            this.comboBoxCustomer.TabIndex = 1;
            this.comboBoxCustomer.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomer_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "所属合同";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(834, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "流水单号";
            // 
            // textBoxFlowNumber
            // 
            this.textBoxFlowNumber.Location = new System.Drawing.Point(893, 16);
            this.textBoxFlowNumber.Name = "textBoxFlowNumber";
            this.textBoxFlowNumber.ReadOnly = true;
            this.textBoxFlowNumber.Size = new System.Drawing.Size(147, 21);
            this.textBoxFlowNumber.TabIndex = 18;
            this.textBoxFlowNumber.TabStop = false;
            // 
            // dateBusinessTime
            // 
            this.dateBusinessTime.Location = new System.Drawing.Point(620, 16);
            this.dateBusinessTime.Name = "dateBusinessTime";
            this.dateBusinessTime.Size = new System.Drawing.Size(147, 21);
            this.dateBusinessTime.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "业务日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "业务状态";
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Location = new System.Drawing.Point(338, 16);
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.Size = new System.Drawing.Size(147, 21);
            this.textBoxStatus.TabIndex = 14;
            this.textBoxStatus.TabStop = false;
            // 
            // textBoxBusinessType
            // 
            this.textBoxBusinessType.Location = new System.Drawing.Point(75, 16);
            this.textBoxBusinessType.Name = "textBoxBusinessType";
            this.textBoxBusinessType.ReadOnly = true;
            this.textBoxBusinessType.Size = new System.Drawing.Size(147, 21);
            this.textBoxBusinessType.TabIndex = 12;
            this.textBoxBusinessType.TabStop = false;
            this.textBoxBusinessType.Text = "货品移库";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "业务类型";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cargoDataGridView);
            this.groupBox3.Controls.Add(this.cargoBindingNavigator);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(175, 172);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(719, 401);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "货品信息";
            this.groupBox3.Visible = false;
            // 
            // cargoDataGridView
            // 
            this.cargoDataGridView.AllowUserToAddRows = false;
            this.cargoDataGridView.AllowUserToDeleteRows = false;
            this.cargoDataGridView.AutoGenerateColumns = false;
            this.cargoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cargoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSelect,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewColumnFirstCategory,
            this.dataGridViewColumnSecondCategory,
            this.dataGridViewColumnThirdCategory,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn11,
            this.columnMoveCount,
            this.dataGridViewTextBoxColumn7,
            this.columnMoveWeight,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.columnWarehouseNumber,
            this.columnNewWarehouse,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewColumnUser,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewColumnStatus});
            this.cargoDataGridView.DataSource = this.cargoBindingSource;
            this.cargoDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cargoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.cargoDataGridView.Location = new System.Drawing.Point(3, 42);
            this.cargoDataGridView.Name = "cargoDataGridView";
            this.cargoDataGridView.RowTemplate.Height = 23;
            this.cargoDataGridView.Size = new System.Drawing.Size(713, 356);
            this.cargoDataGridView.TabIndex = 0;
            this.cargoDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.cargoDataGridView_CellValueChanged);
            this.cargoDataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.cargoDataGridView_RowPrePaint);
            // 
            // columnSelect
            // 
            this.columnSelect.HeaderText = "选择";
            this.columnSelect.Name = "columnSelect";
            this.columnSelect.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewColumnFirstCategory
            // 
            this.dataGridViewColumnFirstCategory.HeaderText = "一级分类";
            this.dataGridViewColumnFirstCategory.Name = "dataGridViewColumnFirstCategory";
            this.dataGridViewColumnFirstCategory.ReadOnly = true;
            // 
            // dataGridViewColumnSecondCategory
            // 
            this.dataGridViewColumnSecondCategory.HeaderText = "二级分类";
            this.dataGridViewColumnSecondCategory.Name = "dataGridViewColumnSecondCategory";
            this.dataGridViewColumnSecondCategory.ReadOnly = true;
            // 
            // dataGridViewColumnThirdCategory
            // 
            this.dataGridViewColumnThirdCategory.HeaderText = "三级分类";
            this.dataGridViewColumnThirdCategory.Name = "dataGridViewColumnThirdCategory";
            this.dataGridViewColumnThirdCategory.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Count";
            this.dataGridViewTextBoxColumn6.HeaderText = "总数量";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "StoreCount";
            this.dataGridViewTextBoxColumn11.HeaderText = "在库数量";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // columnMoveCount
            // 
            this.columnMoveCount.HeaderText = "移库数量";
            this.columnMoveCount.Name = "columnMoveCount";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "UnitWeight";
            this.dataGridViewTextBoxColumn7.HeaderText = "单位重量(kg)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // columnMoveWeight
            // 
            this.columnMoveWeight.HeaderText = "移库重量(t)";
            this.columnMoveWeight.Name = "columnMoveWeight";
            this.columnMoveWeight.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TotalWeight";
            this.dataGridViewTextBoxColumn8.HeaderText = "总重量(t)";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "UnitVolume";
            this.dataGridViewTextBoxColumn9.HeaderText = "单位体积(立方)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TotalVolume";
            this.dataGridViewTextBoxColumn10.HeaderText = "总体积(立方)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 120;
            // 
            // columnWarehouseNumber
            // 
            this.columnWarehouseNumber.DataPropertyName = "WarehouseNumber";
            this.columnWarehouseNumber.HeaderText = "原仓库";
            this.columnWarehouseNumber.Name = "columnWarehouseNumber";
            this.columnWarehouseNumber.ReadOnly = true;
            // 
            // columnNewWarehouse
            // 
            this.columnNewWarehouse.HeaderText = "新仓库";
            this.columnNewWarehouse.Name = "columnNewWarehouse";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "OriginPlace";
            this.dataGridViewTextBoxColumn13.HeaderText = "产地";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ShelfLife";
            this.dataGridViewTextBoxColumn14.HeaderText = "保质期";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Specification";
            this.dataGridViewTextBoxColumn15.HeaderText = "规格";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewColumnUser
            // 
            this.dataGridViewColumnUser.HeaderText = "登记人";
            this.dataGridViewColumnUser.Name = "dataGridViewColumnUser";
            this.dataGridViewColumnUser.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "InTime";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn19.HeaderText = "入库时间";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn21.HeaderText = "备注";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            // 
            // dataGridViewColumnStatus
            // 
            this.dataGridViewColumnStatus.HeaderText = "状态";
            this.dataGridViewColumnStatus.Name = "dataGridViewColumnStatus";
            this.dataGridViewColumnStatus.ReadOnly = true;
            // 
            // cargoBindingSource
            // 
            this.cargoBindingSource.DataSource = typeof(Phoebe.Model.Cargo);
            // 
            // cargoBindingNavigator
            // 
            this.cargoBindingNavigator.AddNewItem = null;
            this.cargoBindingNavigator.BindingSource = this.cargoBindingSource;
            this.cargoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.cargoBindingNavigator.DeleteItem = null;
            this.cargoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.cargoBindingNavigator.Location = new System.Drawing.Point(3, 17);
            this.cargoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.cargoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.cargoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.cargoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.cargoBindingNavigator.Name = "cargoBindingNavigator";
            this.cargoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.cargoBindingNavigator.Size = new System.Drawing.Size(713, 25);
            this.cargoBindingNavigator.TabIndex = 4;
            this.cargoBindingNavigator.Text = "bindingNavigator1";
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
            // StockMoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 576);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "StockMoveForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "货品移库";
            this.Load += new System.EventHandler(this.StockMoveForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cargoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargoBindingNavigator)).EndInit();
            this.cargoBindingNavigator.ResumeLayout(false);
            this.cargoBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolNew;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFlowNumber;
        private System.Windows.Forms.DateTimePicker dateBusinessTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.TextBox textBoxBusinessType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.ComboBox comboBoxContract;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView treeViewReceipt;
        private System.Windows.Forms.ToolStripButton toolConfirm;
        private System.Windows.Forms.DataGridView cargoDataGridView;
        private System.Windows.Forms.BindingSource cargoBindingSource;
        private System.Windows.Forms.BindingNavigator cargoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolRefresh;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnFirstCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnSecondCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnThirdCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMoveCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMoveWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnWarehouseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnNewWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnStatus;
    }
}