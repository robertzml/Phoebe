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

    /// <summary>
    /// 修改密码窗体
    /// </summary>
    public partial class ChangePasswordForm : BaseSingleForm
    {
        #region Constructor
        public ChangePasswordForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtOldPassword.Text == "" || this.txtNewPassword.Text == "")
            {
                MessageBox.Show("密码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtNewPassword.Text != this.txtConfirmPassword.Text)
            {
                MessageBox.Show("两次输入密码不一致", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = BusinessFactory<UserBusiness>.Instance.ChangePassword(this.currentUser.UserName, this.txtOldPassword.Text, this.txtNewPassword.Text);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("修改密码成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("修改密码失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
