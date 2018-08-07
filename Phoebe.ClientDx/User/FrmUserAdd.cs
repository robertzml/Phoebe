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
    using DevExpress.XtraEditors.Controls;
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 添加用户窗体
    /// </summary>
    public partial class FrmUserAdd : BaseSingleForm
    {
        #region Constructor
        public FrmUserAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            SetUserGroupList();
            base.InitForm();
        }

        /// <summary>
        /// 设置用户组列表
        /// </summary>
        private void SetUserGroupList()
        {
            var groups = BusinessFactory<UserGroupBusiness>.Instance.GetAll(false);
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
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (this.txtUserName.Text.Trim() == "")
            {
                errorMessage = "用户名不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtName.Text.Trim() == "")
            {
                errorMessage = "姓名不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                errorMessage = "密码不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtPassword.Text.Trim() != this.txtConfirmPassword.Text)
            {
                errorMessage = "两次输入密码不一致";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.cmbUserGroup.EditValue == null)
            {
                errorMessage = "用户组不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
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
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            try
            {
                User entity = new User();
                SetEntity(entity);

                BusinessFactory<UserBusiness>.Instance.Create(entity);

                MessageUtil.ShowInfo("添加用户成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("添加用户失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
