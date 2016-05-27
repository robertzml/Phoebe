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
    /// 客户流水
    /// </summary>
    public partial class UscCustomerFlow : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerFlow()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            var data = BusinessFactory<StoreBusiness>.Instance.GetCustomerFlow(customer.Id, true).OrderByDescending(r => r.FlowDate);
            this.sfgList.DataSource = data.ToList();
        }
        #endregion //Method
    }
}
