using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;
    using DevExpress.XtraEditors;

    /// <summary>
    /// 客户查找控件
    /// </summary>
    public partial class CustomerLookup : DevExpress.XtraEditors.XtraUserControl
    {
        #region Constructor
        public CustomerLookup()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
        }

        /// <summary>
        /// 获取当前选中客户
        /// </summary>
        /// <returns></returns>
        public Customer GetSelected()
        {
            if (this.sluCustomer.EditValue == null)
                return null;
            else
            {
                var dep = this.sluCustomer.GetSelectedDataRow() as Customer;
                return dep;
            }
        }

        /// <summary>
        /// 获取当前选中客户ID
        /// </summary>
        /// <returns></returns>
        public int GetSelectedId()
        {
            if (this.sluCustomer.EditValue == null)
                return 0;
            else
            {
                var dep = this.sluCustomer.GetSelectedDataRow() as Customer;
                return dep.Id;
            }
        }

        //设置选中客户
        public void SetSelectedId(int id)
        {
            if (id == 0)
                this.sluCustomer.EditValue = null;
            else
                this.sluCustomer.EditValue = id;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sluCustomer_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            var lku = sender as SearchLookUpEdit;
            if (lku.EditValue == null)
                return;

            var customer = lku.GetSelectedDataRow() as Customer;
            if (customer == null)
                return;

            e.DisplayText = string.Format("{0} - {1}", customer.Number, customer.Name);
        }
        #endregion //Event
    }
}
