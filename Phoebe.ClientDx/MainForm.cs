using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Winform.Base;

    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2013");
        }
        #endregion //Constructor

        #region Function        
        /// <summary>
        /// 初始化界面控件
        /// </summary>
        private void InitControls()
        {
            this.barUserName.Caption = GlobalAction.CurrentUser.Name;
            this.barUserGroup.Caption = GlobalAction.CurrentUser.UserGroupTitle;
        }
        #endregion //Function

        #region Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        #region Customer Menu Event
        /// <summary>
        /// 客户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCustomerList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmCustomerList));
        }
        #endregion //Customer Menu Event

        #region Cargo Menu Event
        /// <summary>
        /// 类别管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmCategoryManage));
        }
        #endregion //Cargo Menu Event

        #region User Menu Event
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmUserList));
        }

        /// <summary>
        /// 用户组列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuUserGroupList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChildFormManage.LoadMdiForm(this, typeof(FrmUserGroupList));
        }
        #endregion //User Menu Event

        #endregion //Event
    }
}
