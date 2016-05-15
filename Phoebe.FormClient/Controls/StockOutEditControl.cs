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
    /// 出库编辑控件
    /// </summary>
    public partial class StockOutEditControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联出库单
        /// </summary>
        private StockOut stockOut;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 出库编辑控件
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        public StockOutEditControl(Guid stockOutId)
        {
            InitializeComponent();

            this.stockOut = BusinessFactory<StockOutBusiness>.Instance.FindById(stockOutId);

            SetBaseControl(this.stockOut);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基本信息
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        private void SetBaseControl(StockOut stockOut)
        {
            this.txtStatus.Text = ((EntityStatus)stockOut.Status).DisplayName();
            this.txtOutTime.Text = stockOut.OutTime.ToShortDateString();
            this.txtUser.Text = stockOut.User.Name;
            this.txtCustomerNumber.Text = stockOut.Contract.Customer.Number;
            this.txtCustomerName.Text = stockOut.Contract.Customer.Name;
            this.txtContract.Text = stockOut.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockOut.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockOut.Remark;
            this.txtFlowNumber.Text = stockOut.FlowNumber;
        }

        #endregion //Function
    }
}
