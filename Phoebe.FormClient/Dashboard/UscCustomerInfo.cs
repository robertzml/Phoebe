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
    /// 客户信息
    /// </summary>
    public partial class UscCustomerInfo : UscBaseCustomer
    {
        #region Constructor
        public UscCustomerInfo()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        public override void UpdateControl(Customer customer)
        {
            base.UpdateControl(customer);

            this.txtCustomerNumber.Text = customer.Number;
            this.txtCustomerName.Text = customer.Name;
            this.txtAddress.Text = customer.Address;
            this.txtTelephone.Text = customer.Telephone;
            this.txtContact.Text = customer.Contact;
            this.txtContactTelephone.Text = customer.ContactTelephone;
            this.txtType.Text = ((CustomerType)customer.Type).DisplayName();
            this.txtRemark.Text = customer.Remark;
            this.txtStatus.Text = ((EntityStatus)customer.Status).DisplayName();
        }
        #endregion //Method
    }
}
