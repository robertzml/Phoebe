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
    using DevExpress.XtraEditors;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

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

        /// <summary>
        /// 设置只读
        /// </summary>
        /// <param name="isReadonly"></param>
        public void SetReadonly(bool isReadonly)
        {
            this.sluCustomer.ReadOnly = isReadonly;
        }
        #endregion //Method

        #region Delegate
        /// <summary>
        /// 客户选择事件
        /// </summary>
        [Description("客户选择事件")]
        public event EventHandler CustomerSelect;
        #endregion //Delegate

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

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sluCustomer_EditValueChanged(object sender, EventArgs e)
        {
            CustomerSelect?.Invoke(sender, e);
        }
        #endregion //Event
    }
}
