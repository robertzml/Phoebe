using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace Phoebe.FormClient
{
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
        #endregion //Menu Event

        #endregion //Event
    }
}
