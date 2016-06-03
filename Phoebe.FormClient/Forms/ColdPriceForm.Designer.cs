namespace Phoebe.FormClient
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.dpTo = new DevExpress.XtraEditors.DateEdit();
            this.dpFrom = new DevExpress.XtraEditors.DateEdit();
            this.txtIsTiming = new DevExpress.XtraEditors.TextEdit();
            this.txtBillingType = new DevExpress.XtraEditors.TextEdit();
            this.cmbContract = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.clcCustomer = new Phoebe.FormClient.CustomerListControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dgcCold = new DevExpress.XtraGrid.GridControl();
            this.bsDailyColdRecord = new System.Windows.Forms.BindingSource(this.components);
            this.dgvCold = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRecordDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalMeter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDailyFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlowType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bsContract = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsTiming.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgcCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDailyColdRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clcCustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(917, 572);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(711, 154);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "选择";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.dpTo);
            this.layoutControl1.Controls.Add(this.dpFrom);
            this.layoutControl1.Controls.Add(this.txtIsTiming);
            this.layoutControl1.Controls.Add(this.txtBillingType);
            this.layoutControl1.Controls.Add(this.cmbContract);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(707, 131);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(537, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(158, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dpTo
            // 
            this.dpTo.EditValue = null;
            this.dpTo.Location = new System.Drawing.Point(412, 36);
            this.dpTo.Name = "dpTo";
            this.dpTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpTo.Size = new System.Drawing.Size(121, 20);
            this.dpTo.StyleController = this.layoutControl1;
            this.dpTo.TabIndex = 13;
            // 
            // dpFrom
            // 
            this.dpFrom.EditValue = null;
            this.dpFrom.Location = new System.Drawing.Point(235, 36);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpFrom.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dpFrom.Size = new System.Drawing.Size(122, 20);
            this.dpFrom.StyleController = this.layoutControl1;
            this.dpFrom.TabIndex = 12;
            // 
            // txtIsTiming
            // 
            this.txtIsTiming.Location = new System.Drawing.Point(63, 36);
            this.txtIsTiming.Name = "txtIsTiming";
            this.txtIsTiming.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtIsTiming.Properties.Appearance.Options.UseBackColor = true;
            this.txtIsTiming.Properties.ReadOnly = true;
            this.txtIsTiming.Size = new System.Drawing.Size(117, 20);
            this.txtIsTiming.StyleController = this.layoutControl1;
            this.txtIsTiming.TabIndex = 11;
            // 
            // txtBillingType
            // 
            this.txtBillingType.Location = new System.Drawing.Point(588, 12);
            this.txtBillingType.Name = "txtBillingType";
            this.txtBillingType.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtBillingType.Properties.Appearance.Options.UseBackColor = true;
            this.txtBillingType.Properties.ReadOnly = true;
            this.txtBillingType.Size = new System.Drawing.Size(107, 20);
            this.txtBillingType.StyleController = this.layoutControl1;
            this.txtBillingType.TabIndex = 10;
            // 
            // cmbContract
            // 
            this.cmbContract.Location = new System.Drawing.Point(412, 12);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.cmbContract.Properties.Appearance.Options.UseBackColor = true;
            this.cmbContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbContract.Size = new System.Drawing.Size(121, 20);
            this.cmbContract.StyleController = this.layoutControl1;
            this.cmbContract.TabIndex = 6;
            this.cmbContract.EditValueChanged += new System.EventHandler(this.cmbContract_EditValueChanged);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(235, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(122, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(63, 12);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow;
            this.txtCustomerNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(117, 20);
            this.txtCustomerNumber.StyleController = this.layoutControl1;
            this.txtCustomerNumber.TabIndex = 4;
            this.txtCustomerNumber.EditValueChanged += new System.EventHandler(this.txtCustomerNumber_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(707, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(172, 24);
            this.layoutControlItem1.Text = "客户代码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(172, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(177, 24);
            this.layoutControlItem2.Text = "客户名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbContract;
            this.layoutControlItem3.Location = new System.Drawing.Point(349, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(176, 24);
            this.layoutControlItem3.Text = "所属合同";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtBillingType;
            this.layoutControlItem7.Location = new System.Drawing.Point(525, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(162, 24);
            this.layoutControlItem7.Text = "计费方式";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtIsTiming;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(172, 87);
            this.layoutControlItem4.Text = "是否计时";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dpFrom;
            this.layoutControlItem5.Location = new System.Drawing.Point(172, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(177, 87);
            this.layoutControlItem5.Text = "开始日期";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dpTo;
            this.layoutControlItem6.Location = new System.Drawing.Point(349, 24);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(176, 87);
            this.layoutControlItem6.Text = "结束日期";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSearch;
            this.layoutControlItem8.Location = new System.Drawing.Point(525, 24);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(162, 87);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // clcCustomer
            // 
            this.clcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clcCustomer.Location = new System.Drawing.Point(720, 3);
            this.clcCustomer.Name = "clcCustomer";
            this.clcCustomer.Size = new System.Drawing.Size(194, 154);
            this.clcCustomer.TabIndex = 1;
            this.clcCustomer.CustomerItemSelected += new Phoebe.FormClient.CustomerListControl.ItemSelectHandle(this.clcCustomer_CustomerItemSelected);
            // 
            // groupControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 2);
            this.groupControl2.Controls.Add(this.dgcCold);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(911, 406);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "冷藏费清单";
            // 
            // dgcCold
            // 
            this.dgcCold.DataSource = this.bsDailyColdRecord;
            this.dgcCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgcCold.Location = new System.Drawing.Point(2, 21);
            this.dgcCold.MainView = this.dgvCold;
            this.dgcCold.Name = "dgcCold";
            this.dgcCold.Size = new System.Drawing.Size(907, 383);
            this.dgcCold.TabIndex = 0;
            this.dgcCold.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvCold});
            // 
            // bsDailyColdRecord
            // 
            this.bsDailyColdRecord.DataSource = typeof(Phoebe.Model.DailyColdRecord);
            // 
            // dgvCold
            // 
            this.dgvCold.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRecordDate,
            this.colCategoryNumber,
            this.colCategoryName,
            this.colCount,
            this.colUnitMeter,
            this.colFlowMeter,
            this.colTotalMeter,
            this.colDailyFee,
            this.colTotalFee,
            this.colFlowType});
            this.dgvCold.GridControl = this.dgcCold;
            this.dgvCold.Name = "dgvCold";
            this.dgvCold.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCold.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvCold.OptionsBehavior.Editable = false;
            this.dgvCold.OptionsCustomization.AllowFilter = false;
            this.dgvCold.OptionsCustomization.AllowGroup = false;
            this.dgvCold.OptionsCustomization.AllowQuickHideColumns = false;
            this.dgvCold.OptionsCustomization.AllowSort = false;
            this.dgvCold.OptionsFilter.AllowFilterEditor = false;
            this.dgvCold.OptionsFind.AllowFindPanel = false;
            this.dgvCold.OptionsMenu.EnableColumnMenu = false;
            this.dgvCold.OptionsMenu.EnableFooterMenu = false;
            this.dgvCold.OptionsMenu.EnableGroupPanelMenu = false;
            this.dgvCold.OptionsView.ShowGroupPanel = false;
            // 
            // colRecordDate
            // 
            this.colRecordDate.Caption = "日期";
            this.colRecordDate.FieldName = "RecordDate";
            this.colRecordDate.Name = "colRecordDate";
            this.colRecordDate.Visible = true;
            this.colRecordDate.VisibleIndex = 0;
            // 
            // colCategoryNumber
            // 
            this.colCategoryNumber.FieldName = "CategoryNumber";
            this.colCategoryNumber.Name = "colCategoryNumber";
            // 
            // colCategoryName
            // 
            this.colCategoryName.Caption = "类别名称";
            this.colCategoryName.FieldName = "CategoryName";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.Visible = true;
            this.colCategoryName.VisibleIndex = 1;
            // 
            // colCount
            // 
            this.colCount.Caption = "流水数量";
            this.colCount.FieldName = "Count";
            this.colCount.Name = "colCount";
            this.colCount.Visible = true;
            this.colCount.VisibleIndex = 3;
            // 
            // colUnitMeter
            // 
            this.colUnitMeter.Caption = "单位计量";
            this.colUnitMeter.DisplayFormat.FormatString = "0.###";
            this.colUnitMeter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colUnitMeter.FieldName = "UnitMeter";
            this.colUnitMeter.Name = "colUnitMeter";
            this.colUnitMeter.Visible = true;
            this.colUnitMeter.VisibleIndex = 4;
            // 
            // colFlowMeter
            // 
            this.colFlowMeter.Caption = "流水计量";
            this.colFlowMeter.DisplayFormat.FormatString = "0.####";
            this.colFlowMeter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFlowMeter.FieldName = "FlowMeter";
            this.colFlowMeter.Name = "colFlowMeter";
            this.colFlowMeter.Visible = true;
            this.colFlowMeter.VisibleIndex = 5;
            // 
            // colTotalMeter
            // 
            this.colTotalMeter.Caption = "在库计量";
            this.colTotalMeter.DisplayFormat.FormatString = "0.####";
            this.colTotalMeter.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalMeter.FieldName = "TotalMeter";
            this.colTotalMeter.Name = "colTotalMeter";
            this.colTotalMeter.Visible = true;
            this.colTotalMeter.VisibleIndex = 6;
            // 
            // colDailyFee
            // 
            this.colDailyFee.Caption = "日冷藏费(元)";
            this.colDailyFee.DisplayFormat.FormatString = "0.000";
            this.colDailyFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDailyFee.FieldName = "DailyFee";
            this.colDailyFee.Name = "colDailyFee";
            this.colDailyFee.Visible = true;
            this.colDailyFee.VisibleIndex = 7;
            // 
            // colTotalFee
            // 
            this.colTotalFee.Caption = "冷藏费累计(元)";
            this.colTotalFee.DisplayFormat.FormatString = "0.000";
            this.colTotalFee.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFee.FieldName = "TotalFee";
            this.colTotalFee.Name = "colTotalFee";
            this.colTotalFee.Visible = true;
            this.colTotalFee.VisibleIndex = 8;
            // 
            // colFlowType
            // 
            this.colFlowType.Caption = "流水类型";
            this.colFlowType.FieldName = "FlowType";
            this.colFlowType.Name = "colFlowType";
            this.colFlowType.Visible = true;
            this.colFlowType.VisibleIndex = 2;
            // 
            // bsContract
            // 
            this.bsContract.DataSource = typeof(Phoebe.Model.Contract);
            // 
            // ColdPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 572);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ColdPriceForm";
            this.Text = "冷藏费清单";
            this.Load += new System.EventHandler(this.ColdPriceForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIsTiming.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgcCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDailyColdRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsContract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNumber;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private CustomerListControl clcCustomer;
        private System.Windows.Forms.BindingSource bsContract;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl dgcCold;
        private System.Windows.Forms.BindingSource bsDailyColdRecord;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvCold;
        private DevExpress.XtraGrid.Columns.GridColumn colRecordDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryName;
        private DevExpress.XtraGrid.Columns.GridColumn colCount;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitMeter;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowMeter;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalMeter;
        private DevExpress.XtraGrid.Columns.GridColumn colDailyFee;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFee;
        private DevExpress.XtraGrid.Columns.GridColumn colFlowType;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbContract;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtBillingType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dpTo;
        private DevExpress.XtraEditors.DateEdit dpFrom;
        private DevExpress.XtraEditors.TextEdit txtIsTiming;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}