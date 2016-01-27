﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region Field
        private User currentUser;
        #endregion //Field

        #region Contructor
        public MainForm(User user)
        {
            InitializeComponent();

            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void UpdateStatus()
        {
            this.statusUser.Text = this.currentUser.Name;
        }
        #endregion //Function

        #region Event
        #region Form Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        #endregion //Form Event

        #region Menu Event
        /// <summary>
        /// 客户 - 客户列表
        /// </summary>
        private void menuCustomerList_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 客户 - 添加客户
        /// </summary>
        private void menuCustomerAdd_Click(object sender, EventArgs e)
        {
            CustomerAddForm form = new CustomerAddForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 仓库 - 仓库列表
        /// </summary>
        private void menuWarehouseList_Click(object sender, EventArgs e)
        {
            WarehouseForm form = new WarehouseForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 合同 - 合同列表
        /// </summary>
        private void menuContractList_Click(object sender, EventArgs e)
        {
            ContractForm form = new ContractForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 合同 - 签订合同
        /// </summary>
        private void menuContractSign_Click(object sender, EventArgs e)
        {
            ContractSignForm form = new ContractSignForm(this.currentUser);
            form.ShowDialog();
        }

        /// <summary>
        /// 货品 - 类别管理
        /// </summary>
        private void menuCategory_Click(object sender, EventArgs e)
        {
            CategoryForm form = new CategoryForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 货品 - 在库货品
        /// </summary>
        private void menuCargoIn_Click(object sender, EventArgs e)
        {
            CargoForm form = new CargoForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 冷库租赁 - 货品入库
        /// </summary>
        private void menuStockIn_Click(object sender, EventArgs e)
        {
            StockInForm form = new StockInForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 冷库租赁 - 货品出库
        /// </summary>
        private void menuStockOut_Click(object sender, EventArgs e)
        {
            StockOutForm form = new StockOutForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 冷库租赁 - 货品移库
        /// </summary>
        private void menuStockMove_Click(object sender, EventArgs e)
        {
            StockMoveForm form = new StockMoveForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 用户 - 用户列表
        /// </summary>
        private void menuUserList_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 用户 - 用户组列表
        /// </summary>
        private void menuUserGroupList_Click(object sender, EventArgs e)
        {
            UserGroupForm form = new UserGroupForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 用户 - 修改密码
        /// </summary>
        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(this.currentUser);
            form.ShowDialog();
        }

        #endregion //Menu Event

        #endregion //Event
    }
}
