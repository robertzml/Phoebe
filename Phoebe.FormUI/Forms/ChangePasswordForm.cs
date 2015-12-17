using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public partial class ChangePasswordForm : Form
    {
        #region Field
        private UserBusiness userBusiness;

        private User currentUser;
        #endregion //Field

        #region Constructor
        public ChangePasswordForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Event
        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxOldPassword.Text == "" || this.textBoxNewPassword.Text == "")
            {
                MessageBox.Show("密码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.textBoxNewPassword.Text != this.textBoxPasswordConfirm.Text)
            {
                MessageBox.Show("两次输入密码不一致", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.userBusiness.ChangePassword(this.currentUser.Username, this.textBoxOldPassword.Text, this.textBoxNewPassword.Text.Trim());
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
