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
    using Poseidon.Base.Framework;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 用户列表窗体
    /// </summary>
    public partial class FrmUserList : BaseMdiForm
    {
        #region Constructor
        public FrmUserList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function       
        protected override void InitForm()
        {
            this.userGrid.Init();
            LoadUsers();
            base.InitForm();
        }

        /// <summary>
        /// 载入用户
        /// </summary>
        private void LoadUsers()
        {
            var data = BusinessFactory<UserBusiness>.Instance.FindAll(this.currentUser.IsRoot);
            this.userGrid.DataSource = data;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(FrmUserAdd));
            LoadUsers();
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisable_Click(object sender, EventArgs e)
        {
            var user = this.userGrid.GetCurrentSelect();
            if (user != null)
            {
                BusinessFactory<UserBusiness>.Instance.Disable(user.Id);
                LoadUsers();
            }
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnable_Click(object sender, EventArgs e)
        {
            var user = this.userGrid.GetCurrentSelect();
            if (user != null)
            {
                BusinessFactory<UserBusiness>.Instance.Enable(user.Id);
                LoadUsers();
            }
        }
        #endregion //Event
    }
}
