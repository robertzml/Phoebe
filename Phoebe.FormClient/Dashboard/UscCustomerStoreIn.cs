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
    /// 客户在库库存
    /// </summary>
    public partial class UscCustomerStoreIn : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerStoreIn()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            var data = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(customer.Id, EntityStatus.StoreIn);
            this.sgList.DataSource = data;
        }
        #endregion //Method
    }
}
