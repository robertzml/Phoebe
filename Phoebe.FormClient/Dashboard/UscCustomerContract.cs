using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 客户合同
    /// </summary>
    public partial class UscCustomerContract : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerContract()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            var data = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customer.Id);
            this.bsContract.DataSource = data;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvContract_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return;

            if (e.Column.FieldName == "BillingType")
            {
                var type = (BillingType)e.Value;
                e.DisplayText = type.DisplayName();
            }
            if (e.Column.FieldName == "UserId")
            {
                var contract = this.bsContract[rowIndex] as Contract;
                e.DisplayText = contract.User.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }
        #endregion //Method
    }
}
