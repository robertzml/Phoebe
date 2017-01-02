namespace Phoebe.FormClient
{
    partial class StoreCheckForm
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
            this.chkStoreStatus = new DevExpress.XtraEditors.CheckEdit();
            this.lkuCustomer = new DevExpress.XtraEditors.LookUpEdit();
            this.bsCustomer = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnStartCheck = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btnShowStores = new DevExpress.XtraEditors.SimpleButton();
            this.chkStoreIn = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.chkStoreOut = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.btnShowFlow = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.stgList = new Phoebe.FormClient.StoreGrid();
            this.sfgList = new Phoebe.FormClient.StockFlowGrid();
            this.chkFlowCount = new DevExpress.XtraEditors.CheckEdit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkFlowCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupControl4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl5, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 598);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(284, 154);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "选择范围";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.chkStoreOut);
            this.layoutControl1.Controls.Add(this.chkStoreIn);
            this.layoutControl1.Controls.Add(this.lkuCustomer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 25);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(280, 127);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // chkStoreStatus
            // 
            this.chkStoreStatus.Location = new System.Drawing.Point(24, 43);
            this.chkStoreStatus.Name = "chkStoreStatus";
            this.chkStoreStatus.Properties.Caption = "库存状态";
            this.chkStoreStatus.Size = new System.Drawing.Size(134, 22);
            this.chkStoreStatus.TabIndex = 5;
            // 
            // lkuCustomer
            // 
            this.lkuCustomer.Location = new System.Drawing.Point(77, 14);
            this.lkuCustomer.Name = "lkuCustomer";
            this.lkuCustomer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.lkuCustomer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkuCustomer.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Number", "编号", 62, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "名称", 49, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.lkuCustomer.Properties.DataSource = this.bsCustomer;
            this.lkuCustomer.Properties.DisplayMember = "Number";
            this.lkuCustomer.Properties.DropDownRows = 10;
            this.lkuCustomer.Properties.NullText = "请选择客户";
            this.lkuCustomer.Properties.ShowFooter = false;
            this.lkuCustomer.Properties.ValueMember = "Id";
            this.lkuCustomer.Size = new System.Drawing.Size(189, 24);
            this.lkuCustomer.StyleController = this.layoutControl1;
            this.lkuCustomer.TabIndex = 4;
            // 
            // bsCustomer
            // 
            this.bsCustomer.DataSource = typeof(Phoebe.Model.Customer);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(280, 127);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkuCustomer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(256, 28);
            this.layoutControlItem1.Text = "客户选择";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 18);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnShowFlow);
            this.groupControl2.Controls.Add(this.btnShowStores);
            this.groupControl2.Controls.Add(this.btnStartCheck);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(583, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(382, 154);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "操作";
            // 
            // btnStartCheck
            // 
            this.btnStartCheck.Location = new System.Drawing.Point(119, 42);
            this.btnStartCheck.Name = "btnStartCheck";
            this.btnStartCheck.Size = new System.Drawing.Size(75, 23);
            this.btnStartCheck.TabIndex = 0;
            this.btnStartCheck.Text = "开始检查";
            this.btnStartCheck.Click += new System.EventHandler(this.btnStartCheck_Click);
            // 
            // groupControl3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl3, 3);
            this.groupControl3.Controls.Add(this.stgList);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 163);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(962, 213);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "库存记录";
            // 
            // btnShowStores
            // 
            this.btnShowStores.Location = new System.Drawing.Point(19, 42);
            this.btnShowStores.Name = "btnShowStores";
            this.btnShowStores.Size = new System.Drawing.Size(75, 23);
            this.btnShowStores.TabIndex = 1;
            this.btnShowStores.Text = "列出库存";
            this.btnShowStores.Click += new System.EventHandler(this.btnShowStores_Click);
            // 
            // chkStoreIn
            // 
            this.chkStoreIn.Location = new System.Drawing.Point(14, 42);
            this.chkStoreIn.Name = "chkStoreIn";
            this.chkStoreIn.Properties.Caption = "在库";
            this.chkStoreIn.Size = new System.Drawing.Size(124, 22);
            this.chkStoreIn.StyleController = this.layoutControl1;
            this.chkStoreIn.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.chkStoreIn;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(128, 75);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // chkStoreOut
            // 
            this.chkStoreOut.Location = new System.Drawing.Point(142, 42);
            this.chkStoreOut.Name = "chkStoreOut";
            this.chkStoreOut.Properties.Caption = "出库";
            this.chkStoreOut.Size = new System.Drawing.Size(124, 22);
            this.chkStoreOut.StyleController = this.layoutControl1;
            this.chkStoreOut.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.chkStoreOut;
            this.layoutControlItem3.Location = new System.Drawing.Point(128, 28);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(128, 75);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.chkFlowCount);
            this.groupControl4.Controls.Add(this.chkStoreStatus);
            this.groupControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl4.Location = new System.Drawing.Point(293, 3);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(284, 154);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "检查项目";
            // 
            // btnShowFlow
            // 
            this.btnShowFlow.Location = new System.Drawing.Point(218, 42);
            this.btnShowFlow.Name = "btnShowFlow";
            this.btnShowFlow.Size = new System.Drawing.Size(75, 23);
            this.btnShowFlow.TabIndex = 2;
            this.btnShowFlow.Text = "显示流水";
            this.btnShowFlow.Click += new System.EventHandler(this.btnShowFlow_Click);
            // 
            // groupControl5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl5, 2);
            this.groupControl5.Controls.Add(this.sfgList);
            this.groupControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl5.Location = new System.Drawing.Point(3, 382);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(574, 213);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "流水记录";
            // 
            // stgList
            // 
            this.stgList.DataSource = null;
            this.stgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stgList.EnableColumn = true;
            this.stgList.EnableFilter = false;
            this.stgList.EnableFind = false;
            this.stgList.EnableGroup = false;
            this.stgList.Location = new System.Drawing.Point(2, 25);
            this.stgList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.stgList.Name = "stgList";
            this.stgList.ShowContract = true;
            this.stgList.ShowCustomer = true;
            this.stgList.ShowFooter = false;
            this.stgList.Size = new System.Drawing.Size(958, 186);
            this.stgList.TabIndex = 0;
            // 
            // sfgList
            // 
            this.sfgList.DataSource = null;
            this.sfgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfgList.EndDate = new System.DateTime(((long)(0)));
            this.sfgList.Location = new System.Drawing.Point(2, 25);
            this.sfgList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sfgList.Name = "sfgList";
            this.sfgList.Size = new System.Drawing.Size(570, 186);
            this.sfgList.StartDate = new System.DateTime(((long)(0)));
            this.sfgList.TabIndex = 0;
            // 
            // chkFlowCount
            // 
            this.chkFlowCount.Location = new System.Drawing.Point(24, 85);
            this.chkFlowCount.Name = "chkFlowCount";
            this.chkFlowCount.Properties.Caption = "流水数量";
            this.chkFlowCount.Size = new System.Drawing.Size(96, 22);
            this.chkFlowCount.TabIndex = 6;
            // 
            // StoreCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 598);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StoreCheckForm";
            this.Text = "库存检查";
            this.Load += new System.EventHandler(this.StoreCheckForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuCustomer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStoreOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkFlowCount.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnStartCheck;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.LookUpEdit lkuCustomer;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.BindingSource bsCustomer;
        private DevExpress.XtraEditors.CheckEdit chkStoreStatus;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private StoreGrid stgList;
        private DevExpress.XtraEditors.SimpleButton btnShowStores;
        private DevExpress.XtraEditors.CheckEdit chkStoreIn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckEdit chkStoreOut;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.SimpleButton btnShowFlow;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private StockFlowGrid sfgList;
        private DevExpress.XtraEditors.CheckEdit chkFlowCount;
    }
}