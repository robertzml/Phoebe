using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.LookAndFeel;
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;

    public partial class MainForm : BaseForm
    {
        #region Field

        #endregion //Field

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("Office 2013");
        }
        #endregion //Constructor

        #region Function
        private void InitControl()
        {
            this.barUserName.Caption = this.currentUser.Name;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        #region Menu Event
        /// <summary>
        /// 客户管理 - 客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CustomerForm));
        }

        /// <summary>
        /// 客户管理 - 客户综合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCustomerDashboard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CustomerDashboardForm));
        }

        /// <summary>
        /// 合同管理 - 合同列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuContractList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(ContractForm));
        }

        /// <summary>
        /// 货品管理 - 类别管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CategoryForm));
        }

        /// <summary>
        /// 货品管理 - 货品列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCargoList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CargoForm));
        }

        /// <summary>
        /// 货品管理 - 货品库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCargoStore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CargoStoreForm));
        }

        /// <summary>
        /// 冷库租赁 - 货品入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StockInForm));
        }

        /// <summary>
        /// 冷库租赁 - 货品出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StockOutForm));
        }

        /// <summary>
        /// 冷库租赁 - 货品移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockMove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StockMoveForm));
        }

        /// <summary>
        /// 库存管理 - 库存记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStoreList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StoreForm));
        }

        /// <summary>
        /// 库存管理 - 库存快照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStoreSnapshot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StoreSnapshotForm));
        }

        /// <summary>
        /// 库存管理 - 库存追溯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStoreTrace_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StoreTraceForm));
        }

        /// <summary>
        /// 冰块管理 - 冰块操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIceStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(IceStockForm));
        }

        /// <summary>
        /// 冰块管理 - 冰块库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIceStore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(IceStoreForm));
        }

        /// <summary>
        /// 冰块管理 - 冰块销售
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIceSell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(IceSellForm));
        }

        /// <summary>
        /// 冰块管理 - 销售记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuIceSaleRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(IceSaleRecordForm));
        }

        /// <summary>
        /// 结算管理 - 冷藏费清单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuColdPrice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(ColdPriceForm));
        }

        /// <summary>
        /// 结算管理 - 费用结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSettlement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(SettleForm));
        }

        /// <summary>
        /// 结算管理 - 结算记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSettleList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(SettleListForm));
        }

        /// <summary>
        /// 结算管理 - 缴费管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(PaymentForm));
        }

        /// <summary>
        /// 结算管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDebt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(DebtForm));
        }

        /// <summary>
        /// 报表管理 - 出入库报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockFlowReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StockFlowReportForm));
        }

        /// <summary>
        /// 报表管理 - 库存盘点报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStockInventoryReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(StockInventoryReportForm));
        }

        /// <summary>
        /// 报表管理 - 费用日报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDailyFeeReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(DailyFeeReportForm));
        }


        /// <summary>
        /// 报表管理 - 费用期报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuPeriodFeeReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(PeriodFeeReportForm));
        }

        /// <summary>
        /// 报表管理 - 库存日报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDailyStorageReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(DailyStorageReportForm));
        }

        /// <summary>
        /// 报表管理 - 客户货品报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCustomerCargoReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(CustomerCargoReportForm));
        }

        /// <summary>
        /// 报表管理 - 实时欠费报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDebtReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(DebtReportForm));
        }

        /// <summary>
        /// 报表管理 - 货品总报表报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuTotalStorageReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(TotalStorageReportForm));
        }

        /// <summary>
        /// 用户管理 - 用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUserList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(UserForm));
        }

        /// <summary>
        /// 用户管理 - 用户组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUserGroupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(UserGroupForm));
        }

        /// <summary>
        /// 用户管理 - 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(ChangePasswordForm));
        }

        private void menuTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(TestForm));
        }
        #endregion //Menu Event

        #endregion //Event

    }
}
