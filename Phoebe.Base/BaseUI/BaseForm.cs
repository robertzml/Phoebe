using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.Base
{
    using Phoebe.Common;

    /// <summary>
    /// 窗体基类
    /// </summary>
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        /// <summary>
        /// 当前用户
        /// </summary>
        protected LoginUser currentUser;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 窗体基类
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();

            this.currentUser = Cache.Instance["CurrentUser"] as LoginUser;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查相关权限
        /// </summary>
        protected virtual void CheckPrivilege()
        {

        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseForm_Load(object sender, EventArgs e)
        {
            CheckPrivilege();
        }
        #endregion //Event
    }
}
