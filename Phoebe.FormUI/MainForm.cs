using System;
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
        /// <summary>
        /// 当前用户
        /// </summary>
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
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// 货品 - 货品信息
        /// </summary>
        private void menuCargoList_Click(object sender, EventArgs e)
        {
            CargoForm form = new CargoForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 货品 - 库存记录
        /// </summary>
        private void menuStockList_Click(object sender, EventArgs e)
        {
            StockForm form = new StockForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 货品 - 库存快照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockSnapshoot_Click(object sender, EventArgs e)
        {
            StockSnapshootForm form = new StockSnapshootForm();
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
        /// 结算管理 - 冷藏费清单
        /// </summary>
        private void menuColdPriceList_Click(object sender, EventArgs e)
        {
            ColdPriceForm form = new ColdPriceForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 结算管理 - 费用结算
        /// </summary>
        private void menuSettleCreate_Click(object sender, EventArgs e)
        {
            SettleForm form = new SettleForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 结算管理 - 客户缴费
        /// </summary>
        private void menuPayment_Click(object sender, EventArgs e)
        {
            PaymentForm form = new PaymentForm(this.currentUser);
            form.ShowDialog();
        }

        /// <summary>
        /// 结算管理 - 客户对账
        /// </summary>
        private void menuAccount_Click(object sender, EventArgs e)
        {
            AccountForm form = new AccountForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 结算管理 - 结算记录
        /// </summary>
        private void menuSettleList_Click(object sender, EventArgs e)
        {
            SettleListForm form = new SettleListForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 结算管理 - 实时结算
        /// </summary>
        private void menuSettleReal_Click(object sender, EventArgs e)
        {
            SettleRealForm form = new SettleRealForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 报表管理 - 日报表
        /// </summary>
        private void menuDailyReport_Click(object sender, EventArgs e)
        {
            DailyReportForm form = new DailyReportForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 报表管理 - 出入库报表
        /// </summary>
        private void menuStockFlowReport_Click(object sender, EventArgs e)
        {
            StockFlowReportForm form = new StockFlowReportForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 报表管理 - 库存盘点报表
        /// </summary>
        private void menuStockInventoryReport_Click(object sender, EventArgs e)
        {
            StockInventoryReportForm form = new StockInventoryReportForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 报表管理 - 客户对账报表
        /// </summary>
        private void menuCustomerAccountReport_Click(object sender, EventArgs e)
        {
            CustomerAccountReportForm form = new CustomerAccountReportForm();
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
