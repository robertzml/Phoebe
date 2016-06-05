using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 添加用户窗体
    /// </summary>
    public partial class UserAddForm : BaseSingleForm
    {
        #region Constructor
        /// <summary>
        /// 添加用户窗体
        /// </summary>
        public UserAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置用户组列表
        /// </summary>
        private void SetUserGroupList()
        {
            var groups = BusinessFactory<UserGroupBusiness>.Instance.Get(false);
            foreach (var item in groups)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Title;
                i.Value = item.Id;

                this.cmbUserGroup.Properties.Items.Add(i);
            }

            if (groups.Count > 0)
                this.cmbUserGroup.EditValue = groups[0].Id;
        }

        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="user">用户</param>
        private void SetEntity(User user)
        {
            user.UserName = this.txtUserName.Text.Trim();
            user.Name = this.txtName.Text.Trim();
            user.Password = Hasher.SHA1Encrypt(this.txtPassword.Text.Trim());
            user.UserGroupId = Convert.ToInt32(this.cmbUserGroup.EditValue);
            user.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserAddForm_Load(object sender, EventArgs e)
        {
            SetUserGroupList();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtUserName.Text.Trim() == "")
            {
                MessageUtil.ShowClaim("用户名不能为空");
                return;
            }
            if (this.txtName.Text.Trim() == "")
            {
                MessageUtil.ShowClaim("姓名不能为空");
                return;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                MessageUtil.ShowClaim("密码不能为空");
                return;
            }
            if (this.txtPassword.Text.Trim() != this.txtConfirmPassword.Text)
            {
                MessageUtil.ShowClaim("两次输入密码不一致");
                return;
            }
            if (this.cmbUserGroup.EditValue == null)
            {
                MessageUtil.ShowClaim("用户组不能为空");
                return;
            }

            User user = new User();
            SetEntity(user);

            var result = BusinessFactory<UserBusiness>.Instance.Create(user);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加用户成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加用户失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
