namespace Phoebe.FormUI
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.客户列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLease = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVehicle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFinance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatus = new System.Windows.Forms.StatusStrip();
            this.零散客户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.托盘管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.类目管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.货品查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCustomer,
            this.menuWarehouse,
            this.menuCargo,
            this.menuLease,
            this.menuVehicle,
            this.menuFinance,
            this.menuStatistic,
            this.menuSystem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(942, 25);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuCustomer
            // 
            this.menuCustomer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.客户列表ToolStripMenuItem,
            this.零散客户ToolStripMenuItem});
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Size = new System.Drawing.Size(68, 21);
            this.menuCustomer.Text = "客户管理";
            // 
            // 客户列表ToolStripMenuItem
            // 
            this.客户列表ToolStripMenuItem.Name = "客户列表ToolStripMenuItem";
            this.客户列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.客户列表ToolStripMenuItem.Text = "团体客户";
            // 
            // menuWarehouse
            // 
            this.menuWarehouse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.仓库信息ToolStripMenuItem,
            this.库存管理ToolStripMenuItem,
            this.历史库存ToolStripMenuItem});
            this.menuWarehouse.Name = "menuWarehouse";
            this.menuWarehouse.Size = new System.Drawing.Size(68, 21);
            this.menuWarehouse.Text = "仓库管理";
            // 
            // menuCargo
            // 
            this.menuCargo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.托盘管理ToolStripMenuItem,
            this.toolStripSeparator2,
            this.类目管理ToolStripMenuItem,
            this.货品查询ToolStripMenuItem});
            this.menuCargo.Name = "menuCargo";
            this.menuCargo.Size = new System.Drawing.Size(68, 21);
            this.menuCargo.Text = "货品管理";
            // 
            // menuLease
            // 
            this.menuLease.Name = "menuLease";
            this.menuLease.Size = new System.Drawing.Size(68, 21);
            this.menuLease.Text = "冷库租赁";
            // 
            // menuVehicle
            // 
            this.menuVehicle.Name = "menuVehicle";
            this.menuVehicle.Size = new System.Drawing.Size(68, 21);
            this.menuVehicle.Text = "车辆管理";
            // 
            // menuFinance
            // 
            this.menuFinance.Name = "menuFinance";
            this.menuFinance.Size = new System.Drawing.Size(68, 21);
            this.menuFinance.Text = "财务结算";
            // 
            // menuStatistic
            // 
            this.menuStatistic.Name = "menuStatistic";
            this.menuStatistic.Size = new System.Drawing.Size(68, 21);
            this.menuStatistic.Text = "统计报表";
            // 
            // menuSystem
            // 
            this.menuSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改密码ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.menuSystem.Name = "menuSystem";
            this.menuSystem.Size = new System.Drawing.Size(68, 21);
            this.menuSystem.Text = "系统维护";
            // 
            // mainStatus
            // 
            this.mainStatus.Location = new System.Drawing.Point(0, 520);
            this.mainStatus.Name = "mainStatus";
            this.mainStatus.Size = new System.Drawing.Size(942, 22);
            this.mainStatus.TabIndex = 2;
            this.mainStatus.Text = "statusStrip1";
            // 
            // 零散客户ToolStripMenuItem
            // 
            this.零散客户ToolStripMenuItem.Name = "零散客户ToolStripMenuItem";
            this.零散客户ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.零散客户ToolStripMenuItem.Text = "零散客户";
            // 
            // 仓库信息ToolStripMenuItem
            // 
            this.仓库信息ToolStripMenuItem.Name = "仓库信息ToolStripMenuItem";
            this.仓库信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.仓库信息ToolStripMenuItem.Text = "仓库信息";
            // 
            // 库存管理ToolStripMenuItem
            // 
            this.库存管理ToolStripMenuItem.Name = "库存管理ToolStripMenuItem";
            this.库存管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.库存管理ToolStripMenuItem.Text = "库存管理";
            // 
            // 历史库存ToolStripMenuItem
            // 
            this.历史库存ToolStripMenuItem.Name = "历史库存ToolStripMenuItem";
            this.历史库存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.历史库存ToolStripMenuItem.Text = "历史库存";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 托盘管理ToolStripMenuItem
            // 
            this.托盘管理ToolStripMenuItem.Name = "托盘管理ToolStripMenuItem";
            this.托盘管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.托盘管理ToolStripMenuItem.Text = "托盘管理";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // 类目管理ToolStripMenuItem
            // 
            this.类目管理ToolStripMenuItem.Name = "类目管理ToolStripMenuItem";
            this.类目管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.类目管理ToolStripMenuItem.Text = "类目管理";
            // 
            // 货品查询ToolStripMenuItem
            // 
            this.货品查询ToolStripMenuItem.Name = "货品查询ToolStripMenuItem";
            this.货品查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.货品查询ToolStripMenuItem.Text = "货品查询";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 542);
            this.Controls.Add(this.mainStatus);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "华润冷库管理系统";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.StatusStrip mainStatus;
        private System.Windows.Forms.ToolStripMenuItem menuCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuCargo;
        private System.Windows.Forms.ToolStripMenuItem menuLease;
        private System.Windows.Forms.ToolStripMenuItem menuVehicle;
        private System.Windows.Forms.ToolStripMenuItem menuFinance;
        private System.Windows.Forms.ToolStripMenuItem menuStatistic;
        private System.Windows.Forms.ToolStripMenuItem menuSystem;
        private System.Windows.Forms.ToolStripMenuItem 客户列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 零散客户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 库存管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 托盘管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 类目管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 货品查询ToolStripMenuItem;
    }
}

