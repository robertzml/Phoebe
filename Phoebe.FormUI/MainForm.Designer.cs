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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomerList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCustomerAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWarehouse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWarehouseList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContract = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContractList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContractSign = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserGroupList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStauts = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.mainStauts.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCustomer,
            this.menuWarehouse,
            this.menuContract,
            this.menuCargo,
            this.menuStock,
            this.menuUser});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(949, 25);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuCustomer
            // 
            this.menuCustomer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCustomerList,
            this.menuCustomerAdd});
            this.menuCustomer.Name = "menuCustomer";
            this.menuCustomer.Size = new System.Drawing.Size(68, 21);
            this.menuCustomer.Text = "客户管理";
            // 
            // menuCustomerList
            // 
            this.menuCustomerList.Name = "menuCustomerList";
            this.menuCustomerList.Size = new System.Drawing.Size(124, 22);
            this.menuCustomerList.Text = "客户列表";
            this.menuCustomerList.Click += new System.EventHandler(this.menuCustomerList_Click);
            // 
            // menuCustomerAdd
            // 
            this.menuCustomerAdd.Name = "menuCustomerAdd";
            this.menuCustomerAdd.Size = new System.Drawing.Size(124, 22);
            this.menuCustomerAdd.Text = "添加客户";
            this.menuCustomerAdd.Click += new System.EventHandler(this.menuCustomerAdd_Click);
            // 
            // menuWarehouse
            // 
            this.menuWarehouse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWarehouseList});
            this.menuWarehouse.Name = "menuWarehouse";
            this.menuWarehouse.Size = new System.Drawing.Size(68, 21);
            this.menuWarehouse.Text = "仓库管理";
            // 
            // menuWarehouseList
            // 
            this.menuWarehouseList.Name = "menuWarehouseList";
            this.menuWarehouseList.Size = new System.Drawing.Size(152, 22);
            this.menuWarehouseList.Text = "仓库列表";
            this.menuWarehouseList.Click += new System.EventHandler(this.menuWarehouseList_Click);
            // 
            // menuContract
            // 
            this.menuContract.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuContractList,
            this.menuContractSign});
            this.menuContract.Name = "menuContract";
            this.menuContract.Size = new System.Drawing.Size(68, 21);
            this.menuContract.Text = "合同管理";
            // 
            // menuContractList
            // 
            this.menuContractList.Name = "menuContractList";
            this.menuContractList.Size = new System.Drawing.Size(152, 22);
            this.menuContractList.Text = "合同列表";
            this.menuContractList.Click += new System.EventHandler(this.menuContractList_Click);
            // 
            // menuContractSign
            // 
            this.menuContractSign.Name = "menuContractSign";
            this.menuContractSign.Size = new System.Drawing.Size(152, 22);
            this.menuContractSign.Text = "签订合同";
            this.menuContractSign.Click += new System.EventHandler(this.menuContractSign_Click);
            // 
            // menuUser
            // 
            this.menuUser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserList,
            this.menuUserGroupList,
            this.toolStripSeparator1,
            this.menuChangePassword});
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(68, 21);
            this.menuUser.Text = "用户管理";
            // 
            // menuUserList
            // 
            this.menuUserList.Name = "menuUserList";
            this.menuUserList.Size = new System.Drawing.Size(152, 22);
            this.menuUserList.Text = "用户列表";
            this.menuUserList.Click += new System.EventHandler(this.menuUserList_Click);
            // 
            // menuUserGroupList
            // 
            this.menuUserGroupList.Name = "menuUserGroupList";
            this.menuUserGroupList.Size = new System.Drawing.Size(152, 22);
            this.menuUserGroupList.Text = "用户组列表";
            this.menuUserGroupList.Click += new System.EventHandler(this.menuUserGroupList_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuChangePassword
            // 
            this.menuChangePassword.Name = "menuChangePassword";
            this.menuChangePassword.Size = new System.Drawing.Size(152, 22);
            this.menuChangePassword.Text = "修改密码";
            this.menuChangePassword.Click += new System.EventHandler(this.menuChangePassword_Click);
            // 
            // mainStauts
            // 
            this.mainStauts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusUser});
            this.mainStauts.Location = new System.Drawing.Point(0, 519);
            this.mainStauts.Name = "mainStauts";
            this.mainStauts.Size = new System.Drawing.Size(949, 26);
            this.mainStauts.TabIndex = 2;
            this.mainStauts.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 21);
            this.toolStripStatusLabel1.Text = "当前用户:";
            // 
            // statusUser
            // 
            this.statusUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusUser.Name = "statusUser";
            this.statusUser.Size = new System.Drawing.Size(44, 21);
            this.statusUser.Text = "name";
            // 
            // menuCargo
            // 
            this.menuCargo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCategory});
            this.menuCargo.Name = "menuCargo";
            this.menuCargo.Size = new System.Drawing.Size(68, 21);
            this.menuCargo.Text = "货品管理";
            // 
            // menuStock
            // 
            this.menuStock.Name = "menuStock";
            this.menuStock.Size = new System.Drawing.Size(68, 21);
            this.menuStock.Text = "冷库租赁";
            // 
            // menuCategory
            // 
            this.menuCategory.Name = "menuCategory";
            this.menuCategory.Size = new System.Drawing.Size(152, 22);
            this.menuCategory.Text = "类别管理";
            this.menuCategory.Click += new System.EventHandler(this.menuCategory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 545);
            this.Controls.Add(this.mainStauts);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "华润冷链管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.mainStauts.ResumeLayout(false);
            this.mainStauts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuCustomerList;
        private System.Windows.Forms.StatusStrip mainStauts;
        private System.Windows.Forms.ToolStripMenuItem menuCustomerAdd;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuUserList;
        private System.Windows.Forms.ToolStripMenuItem menuUserGroupList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuChangePassword;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusUser;
        private System.Windows.Forms.ToolStripMenuItem menuWarehouse;
        private System.Windows.Forms.ToolStripMenuItem menuWarehouseList;
        private System.Windows.Forms.ToolStripMenuItem menuContract;
        private System.Windows.Forms.ToolStripMenuItem menuContractList;
        private System.Windows.Forms.ToolStripMenuItem menuContractSign;
        private System.Windows.Forms.ToolStripMenuItem menuCargo;
        private System.Windows.Forms.ToolStripMenuItem menuCategory;
        private System.Windows.Forms.ToolStripMenuItem menuStock;
    }
}

