namespace Phoebe.FormClient
{
    partial class CustomerDashboardForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.sgList = new Phoebe.FormClient.StoreGrid();
            this.clcCustomer = new Phoebe.FormClient.CustomerListControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.sfgList = new Phoebe.FormClient.StockFlowGrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 201F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.clcCustomer, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(931, 538);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(359, 144);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "客户选择";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(355, 121);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(355, 121);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(64, 12);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Size = new System.Drawing.Size(103, 20);
            this.txtCustomerNumber.StyleController = this.layoutControl1;
            this.txtCustomerNumber.TabIndex = 4;
            this.txtCustomerNumber.EditValueChanged += new System.EventHandler(this.txtCustomerNumber_EditValueChanged);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCustomerNumber;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(159, 101);
            this.layoutControlItem1.Text = "客户代码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(223, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(120, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCustomerName;
            this.layoutControlItem2.Location = new System.Drawing.Point(159, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(176, 24);
            this.layoutControlItem2.Text = "客户姓名";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // groupControl2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl2, 2);
            this.groupControl2.Controls.Add(this.sgList);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 153);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(724, 188);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "在库库存";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(171, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(172, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSearch;
            this.layoutControlItem3.Location = new System.Drawing.Point(159, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(176, 77);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // sgList
            // 
            this.sgList.DataSource = null;
            this.sgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgList.EnableColumn = true;
            this.sgList.EnableFilter = true;
            this.sgList.EnableFind = false;
            this.sgList.EnableGroup = false;
            this.sgList.Location = new System.Drawing.Point(2, 21);
            this.sgList.Name = "sgList";
            this.sgList.ShowContract = true;
            this.sgList.ShowCustomer = false;
            this.sgList.ShowFooter = true;
            this.sgList.Size = new System.Drawing.Size(720, 165);
            this.sgList.TabIndex = 0;
            // 
            // clcCustomer
            // 
            this.clcCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clcCustomer.Location = new System.Drawing.Point(733, 3);
            this.clcCustomer.Name = "clcCustomer";
            this.clcCustomer.Size = new System.Drawing.Size(195, 144);
            this.clcCustomer.TabIndex = 2;
            this.clcCustomer.CustomerItemSelected += new Phoebe.FormClient.CustomerListControl.ItemSelectHandle(this.clcCustomer_CustomerItemSelected);
            // 
            // groupControl3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupControl3, 2);
            this.groupControl3.Controls.Add(this.sfgList);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(3, 347);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(724, 188);
            this.groupControl3.TabIndex = 3;
            this.groupControl3.Text = "流水记录";
            // 
            // sfgList
            // 
            this.sfgList.DataSource = null;
            this.sfgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfgList.Location = new System.Drawing.Point(2, 21);
            this.sfgList.Name = "sfgList";
            this.sfgList.Size = new System.Drawing.Size(720, 165);
            this.sfgList.TabIndex = 0;
            // 
            // CustomerDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 538);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CustomerDashboardForm";
            this.Text = "客户综合";
            this.Load += new System.EventHandler(this.CustomerDashboardForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
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
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private StoreGrid sgList;
        private CustomerListControl clcCustomer;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private StockFlowGrid sfgList;
    }
}