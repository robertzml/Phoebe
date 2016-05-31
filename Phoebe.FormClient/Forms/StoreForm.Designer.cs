namespace Phoebe.FormClient
{
    partial class StoreForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.chkReady = new DevExpress.XtraEditors.CheckEdit();
            this.chkOut = new DevExpress.XtraEditors.CheckEdit();
            this.chkIn = new DevExpress.XtraEditors.CheckEdit();
            this.txtCategoryName = new DevExpress.XtraEditors.TextEdit();
            this.txtCategoryNumber = new DevExpress.XtraEditors.TextEdit();
            this.cmbContract = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.sgList = new Phoebe.FormClient.StoreGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.clcCustomer = new Phoebe.FormClient.CustomerListControl();
            this.clcCategory = new Phoebe.FormClient.CategoryListControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkReady.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(678, 234);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "选择";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.chkReady);
            this.layoutControl1.Controls.Add(this.chkOut);
            this.layoutControl1.Controls.Add(this.chkIn);
            this.layoutControl1.Controls.Add(this.txtCategoryName);
            this.layoutControl1.Controls.Add(this.txtCategoryNumber);
            this.layoutControl1.Controls.Add(this.cmbContract);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(674, 211);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(427, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(240, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkReady
            // 
            this.chkReady.Location = new System.Drawing.Point(134, 55);
            this.chkReady.Name = "chkReady";
            this.chkReady.Properties.Caption = "未入库";
            this.chkReady.Size = new System.Drawing.Size(74, 19);
            this.chkReady.StyleController = this.layoutControl1;
            this.chkReady.TabIndex = 19;
            // 
            // chkOut
            // 
            this.chkOut.Location = new System.Drawing.Point(68, 55);
            this.chkOut.Name = "chkOut";
            this.chkOut.Properties.Caption = "出库";
            this.chkOut.Size = new System.Drawing.Size(62, 19);
            this.chkOut.StyleController = this.layoutControl1;
            this.chkOut.TabIndex = 18;
            // 
            // chkIn
            // 
            this.chkIn.EditValue = true;
            this.chkIn.Location = new System.Drawing.Point(7, 55);
            this.chkIn.Name = "chkIn";
            this.chkIn.Properties.Caption = "入库";
            this.chkIn.Size = new System.Drawing.Size(57, 19);
            this.chkIn.StyleController = this.layoutControl1;
            this.chkIn.TabIndex = 17;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(263, 31);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCategoryName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCategoryName.Properties.ReadOnly = true;
            this.txtCategoryName.Size = new System.Drawing.Size(160, 20);
            this.txtCategoryName.StyleController = this.layoutControl1;
            this.txtCategoryName.TabIndex = 16;
            // 
            // txtCategoryNumber
            // 
            this.txtCategoryNumber.Location = new System.Drawing.Point(58, 31);
            this.txtCategoryNumber.Name = "txtCategoryNumber";
            this.txtCategoryNumber.Size = new System.Drawing.Size(150, 20);
            this.txtCategoryNumber.StyleController = this.layoutControl1;
            this.txtCategoryNumber.TabIndex = 15;
            this.txtCategoryNumber.EditValueChanged += new System.EventHandler(this.txtCategoryNumber_EditValueChanged);
            // 
            // cmbContract
            // 
            this.cmbContract.Location = new System.Drawing.Point(478, 7);
            this.cmbContract.Name = "cmbContract";
            this.cmbContract.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbContract.Size = new System.Drawing.Size(189, 20);
            this.cmbContract.StyleController = this.layoutControl1;
            this.cmbContract.TabIndex = 14;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(263, 7);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(160, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(58, 7);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtCustomerNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(150, 20);
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
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(674, 211);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(205, 24);
            this.layoutControlItem1.Text = "客户代码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(205, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(215, 24);
            this.layoutControlItem2.Text = "客户名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cmbContract;
            this.layoutControlItem3.Location = new System.Drawing.Point(420, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(244, 24);
            this.layoutControlItem3.Text = "所属合同";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCategoryNumber;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(205, 24);
            this.layoutControlItem4.Text = "类别编码";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtCategoryName;
            this.layoutControlItem5.Location = new System.Drawing.Point(205, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(215, 47);
            this.layoutControlItem5.Text = "类别名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(420, 24);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(244, 21);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.chkIn;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(61, 23);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.chkOut;
            this.layoutControlItem7.Location = new System.Drawing.Point(61, 48);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(66, 23);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.chkReady;
            this.layoutControlItem8.Location = new System.Drawing.Point(127, 48);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(78, 23);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnSearch;
            this.layoutControlItem9.Location = new System.Drawing.Point(420, 45);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(244, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 71);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(664, 130);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // groupControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 3);
            this.groupControl2.Controls.Add(this.sgList);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 243);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1078, 306);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "库存数据";
            // 
            // sgList
            // 
            this.sgList.DataSource = null;
            this.sgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgList.EnableColumn = true;
            this.sgList.EnableFilter = true;
            this.sgList.EnableFind = true;
            this.sgList.EnableGroup = true;
            this.sgList.Location = new System.Drawing.Point(2, 21);
            this.sgList.Name = "sgList";
            this.sgList.ShowContract = true;
            this.sgList.ShowCustomer = true;
            this.sgList.ShowFooter = true;
            this.sgList.Size = new System.Drawing.Size(1074, 283);
            this.sgList.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clcCustomer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clcCategory, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1084, 552);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // clcCustomer
            // 
            this.clcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clcCustomer.Location = new System.Drawing.Point(687, 3);
            this.clcCustomer.Name = "clcCustomer";
            this.clcCustomer.Size = new System.Drawing.Size(194, 234);
            this.clcCustomer.TabIndex = 6;
            this.clcCustomer.CustomerItemSelected += new Phoebe.FormClient.CustomerListControl.ItemSelectHandle(this.clcCustomer_CustomerItemSelected);
            // 
            // clcCategory
            // 
            this.clcCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clcCategory.Location = new System.Drawing.Point(887, 3);
            this.clcCategory.Name = "clcCategory";
            this.clcCategory.Size = new System.Drawing.Size(194, 234);
            this.clcCategory.TabIndex = 7;
            this.clcCategory.CategoryItemSelected += new Phoebe.FormClient.CategoryListControl.ItemSelectHandle(this.clcCategory_CategoryItemSelected);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 552);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StoreForm";
            this.Text = "库存记录";
            this.Load += new System.EventHandler(this.StoreForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkReady.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategoryNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNumber;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CustomerListControl clcCustomer;
        private StoreGrid sgList;
        private CategoryListControl clcCategory;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.CheckEdit chkReady;
        private DevExpress.XtraEditors.CheckEdit chkOut;
        private DevExpress.XtraEditors.CheckEdit chkIn;
        private DevExpress.XtraEditors.TextEdit txtCategoryName;
        private DevExpress.XtraEditors.TextEdit txtCategoryNumber;
        private DevExpress.XtraEditors.ImageComboBoxEdit cmbContract;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}