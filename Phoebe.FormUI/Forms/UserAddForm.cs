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
    public partial class UserAddForm : Form
    {
        #region Field
        private UserBusiness userBusiness;
        #endregion //Field

        #region Constructor
        public UserAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.userBusiness = new UserBusiness();
        }

        private void InitControl()
        {
            this.comboBoxUserGroup.DataSource = this.userBusiness.GetUserGroup(false);
            this.comboBoxUserGroup.DisplayMember = "Title";
            this.comboBoxUserGroup.ValueMember = "ID";

            this.comboBoxUserGroup.SelectedIndex = 0;
        }
        #endregion //Function

        #region Event
        private void UserAddForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxUserName.Text.Trim() == "" || this.textBoxPassword.Text == "" || this.textBoxName.Text == "")
            {
                MessageBox.Show("字段不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.textBoxConfirmPassword.Text != this.textBoxPassword.Text)
            {
                MessageBox.Show("两次输入密码不一致", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            User user = new User
            {
                Username = this.textBoxUserName.Text.Trim(),
                Password = this.textBoxPassword.Text,
                Name = this.textBoxName.Text.Trim(),
                UserGroupID = Convert.ToInt32(this.comboBoxUserGroup.SelectedValue),
                Remark = this.textBoxRemark.Text
            };

            ErrorCode result = this.userBusiness.CreateUser(user);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加用户成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加用户失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
