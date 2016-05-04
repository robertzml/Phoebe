using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Base;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormClient
{
    /// <summary>
    /// 系统登录窗体
    /// </summary>
    public partial class LoginForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 用户业务类
        /// </summary>
        private UserBusiness userBusiness;

        /// <summary>
        /// 用户
        /// </summary>
        private User user;
        #endregion //Field

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
       
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
        }

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
                MessageBox.Show("用户名不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.txtPassword.Text == "")
            {
                MessageBox.Show("密码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ErrorCode result = userBusiness.Login(userName, this.txtPassword.Text);

            if (result == ErrorCode.Success)
            {
                this.user = userBusiness.GetUser(userName);               
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        #endregion //Property
    }
}
