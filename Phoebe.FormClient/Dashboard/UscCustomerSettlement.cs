using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
    /// 客户结算信息
    /// </summary>
    public partial class UscCustomerSettlement : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerSettlement()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            var data = BusinessFactory<SettlementBusiness>.Instance.GetByCustomer(customer.Id).OrderByDescending(r => r.SettleTime);
            this.sgList.DataSource = data.ToList();
        }
        #endregion //Method
    }
}
