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
    public partial class LoginForm : Form
    {
        #region Field
        /// <summary>
        /// 用户
        /// </summary>
        private User user;

        /// <summary>
        /// 用户业务类
        /// </summary>
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.userBusiness = new UserBusiness();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string userName = this.textBoxUserName.Text.Trim();

            if (userName == "")
            {
                MessageBox.Show("用户名不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.textBoxPassword.Text == "")
            {
                MessageBox.Show("密码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ErrorCode result = userBusiness.Login(userName, this.textBoxPassword.Text);

            if (result == ErrorCode.Success)
            {
                this.user = userBusiness.GetUser(userName);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.textBoxPassword.Text = "";
                return;
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 用户
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
