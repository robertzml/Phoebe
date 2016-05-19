namespace Phoebe.FormClient
{
    partial class StockMoveViewControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtStatus = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtMoveTime = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCustomerNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtCustomerName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtContract = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtBillingType = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtFlowNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.smgList = new Phoebe.FormClient.StockMoveGrid();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoveTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContract.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlowNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupControl2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(994, 154);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "基本信息";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.smgList);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(3, 163);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(994, 434);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "移库信息";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtFlowNumber);
            this.layoutControl1.Controls.Add(this.txtRemark);
            this.layoutControl1.Controls.Add(this.txtBillingType);
            this.layoutControl1.Controls.Add(this.txtContract);
            this.layoutControl1.Controls.Add(this.txtCustomerName);
            this.layoutControl1.Controls.Add(this.txtCustomerNumber);
            this.layoutControl1.Controls.Add(this.txtUser);
            this.layoutControl1.Controls.Add(this.txtMoveTime);
            this.layoutControl1.Controls.Add(this.txtStatus);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(990, 131);
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
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlGroup1.Size = new System.Drawing.Size(990, 131);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(59, 7);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.txtStatus.Properties.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(154, 20);
            this.txtStatus.StyleController = this.layoutControl1;
            this.txtStatus.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtStatus;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(210, 29);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 5);
            this.layoutControlItem1.Text = "业务状态";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtMoveTime
            // 
            this.txtMoveTime.Location = new System.Drawing.Point(269, 7);
            this.txtMoveTime.Name = "txtMoveTime";
            this.txtMoveTime.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtMoveTime.Properties.Appearance.Options.UseBackColor = true;
            this.txtMoveTime.Properties.ReadOnly = true;
            this.txtMoveTime.Size = new System.Drawing.Size(186, 20);
            this.txtMoveTime.StyleController = this.layoutControl1;
            this.txtMoveTime.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtMoveTime;
            this.layoutControlItem2.Location = new System.Drawing.Point(210, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(242, 29);
            this.layoutControlItem2.Text = "业务日期";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(511, 7);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtUser.Properties.Appearance.Options.UseBackColor = true;
            this.txtUser.Properties.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(155, 20);
            this.txtUser.StyleController = this.layoutControl1;
            this.txtUser.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtUser;
            this.layoutControlItem3.Location = new System.Drawing.Point(452, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(211, 29);
            this.layoutControlItem3.Text = "业务员";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtCustomerNumber
            // 
            this.txtCustomerNumber.Location = new System.Drawing.Point(59, 36);
            this.txtCustomerNumber.Name = "txtCustomerNumber";
            this.txtCustomerNumber.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerNumber.Properties.ReadOnly = true;
            this.txtCustomerNumber.Size = new System.Drawing.Size(154, 20);
            this.txtCustomerNumber.StyleController = this.layoutControl1;
            this.txtCustomerNumber.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtCustomerNumber;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(210, 29);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 5);
            this.layoutControlItem4.Text = "客户代码";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(269, 36);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtCustomerName.Properties.Appearance.Options.UseBackColor = true;
            this.txtCustomerName.Properties.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(186, 20);
            this.txtCustomerName.StyleController = this.layoutControl1;
            this.txtCustomerName.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtCustomerName;
            this.layoutControlItem5.Location = new System.Drawing.Point(210, 29);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(242, 29);
            this.layoutControlItem5.Text = "客户名称";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(511, 36);
            this.txtContract.Name = "txtContract";
            this.txtContract.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtContract.Properties.Appearance.Options.UseBackColor = true;
            this.txtContract.Properties.ReadOnly = true;
            this.txtContract.Size = new System.Drawing.Size(155, 20);
            this.txtContract.StyleController = this.layoutControl1;
            this.txtContract.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtContract;
            this.layoutControlItem6.Location = new System.Drawing.Point(452, 29);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(211, 29);
            this.layoutControlItem6.Text = "所属合同";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtBillingType
            // 
            this.txtBillingType.Location = new System.Drawing.Point(59, 65);
            this.txtBillingType.Name = "txtBillingType";
            this.txtBillingType.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtBillingType.Properties.Appearance.Options.UseBackColor = true;
            this.txtBillingType.Properties.ReadOnly = true;
            this.txtBillingType.Size = new System.Drawing.Size(154, 20);
            this.txtBillingType.StyleController = this.layoutControl1;
            this.txtBillingType.TabIndex = 10;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtBillingType;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 58);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(210, 63);
            this.layoutControlItem7.Text = "计费方式";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(269, 65);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtRemark.Properties.Appearance.Options.UseBackColor = true;
            this.txtRemark.Properties.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(186, 20);
            this.txtRemark.StyleController = this.layoutControl1;
            this.txtRemark.TabIndex = 11;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.txtRemark;
            this.layoutControlItem8.Location = new System.Drawing.Point(210, 58);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(242, 63);
            this.layoutControlItem8.Text = "备注";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txtFlowNumber
            // 
            this.txtFlowNumber.Location = new System.Drawing.Point(511, 65);
            this.txtFlowNumber.Name = "txtFlowNumber";
            this.txtFlowNumber.Properties.Appearance.BackColor = System.Drawing.Color.Lavender;
            this.txtFlowNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtFlowNumber.Properties.ReadOnly = true;
            this.txtFlowNumber.Size = new System.Drawing.Size(155, 20);
            this.txtFlowNumber.StyleController = this.layoutControl1;
            this.txtFlowNumber.TabIndex = 12;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtFlowNumber;
            this.layoutControlItem9.Location = new System.Drawing.Point(452, 58);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(211, 63);
            this.layoutControlItem9.Text = "流水号";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(48, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(663, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(317, 121);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // smgList
            // 
            this.smgList.DataSource = null;
            this.smgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.smgList.Editable = false;
            this.smgList.Location = new System.Drawing.Point(2, 21);
            this.smgList.Name = "smgList";
            this.smgList.ShowFooter = true;
            this.smgList.ShowMoveCount = true;
            this.smgList.Size = new System.Drawing.Size(990, 411);
            this.smgList.TabIndex = 0;
            // 
            // StockMoveViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StockMoveViewControl";
            this.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoveTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtContract.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlowNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtStatus;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtMoveTime;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtCustomerName;
        private DevExpress.XtraEditors.TextEdit txtCustomerNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.TextEdit txtBillingType;
        private DevExpress.XtraEditors.TextEdit txtContract;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.TextEdit txtFlowNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private StockMoveGrid smgList;
    }
}
