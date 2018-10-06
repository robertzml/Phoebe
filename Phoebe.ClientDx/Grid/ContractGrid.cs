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
    using Poseidon.Winform.Base;
    using Poseidon.Common;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 合同表格控件
    /// </summary>
    public partial class ContractGrid : WinIntGrid<Contract>
    {
        #region Field
        /// <summary>
        /// 缓存用户列表
        /// </summary>
        private List<User> userList;

        /// <summary>
        /// 缓存客户列表
        /// </summary>
        private List<Customer> customerList;
        #endregion //Field

        #region Constructor
        public ContractGrid()
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
            this.userList = BusinessFactory<UserBusiness>.Instance.FindAll().ToList();
            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll().ToList();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return;

            var contract = this.bsEntity[rowIndex] as Contract;

            if (e.Column.FieldName == "Type")
            {
                e.DisplayText = ((ContractType)e.Value).DisplayName();
            }
            else if (e.Column.FieldName == "CustomerId")
            {
                var customer = this.customerList.Find(r => r.Id == contract.CustomerId);
                if (customer != null)
                    e.DisplayText = customer.Name;
            }
            else if (e.Column.FieldName == "BillingType")
            {
                e.DisplayText = ((BillingType)e.Value).DisplayName();
            }
            else if (e.Column.FieldName == "UserId")
            {
                var user = this.userList.Find(r => r.Id == contract.UserId);
                if (user != null)
                    e.DisplayText = user.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return;

            var contract = this.bsEntity[rowIndex] as Contract;

            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
            {
                var customer = this.customerList.Find(r => r.Id == contract.CustomerId);
                if (customer != null)
                    e.Value = customer.Number;
            }
            if (e.Column.FieldName == "colBillingDescription" && e.IsGetData)
            {
                e.Value = ((BillingType)contract.BillingType).DisplayDescription();
            }
        }
        #endregion //Event
    }
}
