using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 客户关联组件
    /// </summary>
    public partial class UscBaseCustomer : UserControl
    {
        #region Field
        /// <summary>
        /// 当前客户
        /// </summary>
        protected Customer currentCustomer;
        #endregion //Field

        #region Constructor
        public UscBaseCustomer()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 更新控件
        /// </summary>
        /// <param name="customer">客户</param>
        public virtual void UpdateControl(Customer customer)
        {
            this.currentCustomer = customer;
        }
        #endregion //Method
    }
}
