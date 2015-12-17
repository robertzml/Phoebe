using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region Field
        private User currentUser;
        #endregion //Field

        #region Contructor
        public MainForm(User user)
        {
            InitializeComponent();

            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void UpdateStatus()
        {
            this.statusUser.Text = this.currentUser.Name;
        }
        #endregion //Function

        #region Event
        #region Form Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        #endregion //Form Event

        #region Menu Event
        /// <summary>
        /// 客户 - 客户列表
        /// </summary>
        private void menuCustomerList_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 客户 - 添加客户
        /// </summary>
        private void menuCustomerAdd_Click(object sender, EventArgs e)
        {
            CustomerAddForm form = new CustomerAddForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 用户 - 用户组列表
        /// </summary>
        private void menuUserGroupList_Click(object sender, EventArgs e)
        {
            UserGroupForm form = new UserGroupForm(this.currentUser);
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        /// <summary>
        /// 用户 - 修改密码
        /// </summary>
        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm(this.currentUser);
            form.ShowDialog();
        }
        #endregion //Menu Event

        #endregion //Event


    }
}
