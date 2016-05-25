using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 用户列表窗体
    /// </summary>
    public partial class UserForm : BaseForm
    {
        #region Constructor
        /// <summary>
        /// 用户列表窗体
        /// </summary>
        public UserForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查权限
        /// </summary>
        protected override void CheckPrivilege()
        {
            if (this.currentUser.UserGroupName == "Root" || this.currentUser.UserGroupName == "Administrator")
            {
                this.btnEnable.Visible = true;
                this.btnDisable.Visible = true;
                this.btnAdd.Visible = true;
            }
            else
            {
                this.btnEnable.Visible = false;
                this.btnDisable.Visible = false;
                this.btnAdd.Visible = false;
            }
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        private void LoadData()
        {
            this.bsUser.DataSource = BusinessFactory<UserBusiness>.Instance.Get(this.currentUser.IsRoot);
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnable_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvUser.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsUser.Count)
                return;

            var user = this.bsUser[rowIndex] as User;
            BusinessFactory<UserBusiness>.Instance.Enable(user.Id);

            this.bsUser.ResetBindings(false);
        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisable_Click(object sender, EventArgs e)
        {
            int rowIndex = this.dgvUser.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsUser.Count)
                return;

            var user = this.bsUser[rowIndex] as User;
            BusinessFactory<UserBusiness>.Instance.Disable(user.Id);

            this.bsUser.ResetBindings(false);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ChildFormManage.ShowDialogForm(typeof(UserAddForm));
            LoadData();
        }

        /// <summary>
        /// 自定义显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUser_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsUser.Count)
                return;

            if (e.Column.FieldName == "UserGroupId")
            {
                var user = this.bsUser[rowIndex] as User;
                e.DisplayText = user.UserGroup.Title;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }
        #endregion //Event
    }
}
