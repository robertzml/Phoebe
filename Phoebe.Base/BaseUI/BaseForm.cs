using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Common;

namespace Phoebe.Base
{
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
        public BaseForm()
        {
            this.currentUser = Cache.Instance["CurrentUser"] as LoginUser;

            InitializeComponent();
        }
        #endregion //Constructor
    }
}
