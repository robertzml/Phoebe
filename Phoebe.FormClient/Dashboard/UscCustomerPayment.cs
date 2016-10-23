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
    /// 客户缴费信息
    /// </summary>
    public partial class UscCustomerPayment : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerPayment()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            var data = BusinessFactory<PaymentBusiness>.Instance.GetByCustomer(customer.Id).OrderByDescending(r => r.PaidTime);
            this.spgList.DataSource = data.ToList();
        }
        #endregion //Method
    }
}
