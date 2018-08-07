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
    /// 系统登录窗体
    /// </summary>
    public partial class LoginForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 用户
        /// </summary>
        private User user;

        /// <summary>
        /// 当前用户组
        /// </summary>
        private UserGroup userGroup;
        #endregion //Field

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string userName = this.txtUserName.Text.Trim();

            if (userName == "")
            {
                MessageUtil.ShowClaim("用户名不能为空");
                return;
            }

            if (this.txtPassword.Text == "")
            {
                MessageUtil.ShowClaim("密码不能为空");
                return;
            }

            bool result = BusinessFactory<UserBusiness>.Instance.Login(userName, this.txtPassword.Text);

            if (result)
            {
                this.user = BusinessFactory<UserBusiness>.Instance.FindByUserName(userName);
                this.userGroup = BusinessFactory<UserGroupBusiness>.Instance.FindById(user.UserGroupId);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageUtil.ShowWarning("用户登录失败");
                this.txtPassword.Text = "";
                return;
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 登录用户
        /// </summary>
        public User User
        {
            get
            {
                return this.user;
            }
        }

        /// <summary>
        /// 当前用户组
        /// </summary>
        public UserGroup UserGroup
        {
            get
            {
                return this.userGroup;
            }
        }
        #endregion //Property
    }
}
