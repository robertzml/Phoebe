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
    /// 货品入库查看
    /// </summary>
    public partial class StockInViewControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联入库单
        /// </summary>
        private StockIn stockIn;
        #endregion //Field

        #region Constructor
        public StockInViewControl(Guid stockInId)
        {
            InitializeComponent();

            this.stockIn = BusinessFactory<StockInBusiness>.Instance.FindById(stockInId);

            SetBaseControl(this.stockIn);
            SetBillingControl(this.stockIn.Billing);
            SetDataControl(this.stockIn);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基础信息
        /// </summary>
        /// <param name="stockIn"></param>
        private void SetBaseControl(StockIn stockIn)
        {
            this.txtStatus.Text = ((EntityStatus)stockIn.Status).DisplayName();
            this.txtInTime.Text = stockIn.InTime.ToShortDateString();
            this.txtUser.Text = stockIn.User.Name;
            this.txtCustomerNumber.Text = stockIn.Contract.Customer.Number;
            this.txtCustomerName.Text = stockIn.Contract.Customer.Name;
            this.txtContract.Text = stockIn.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockIn.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockIn.Remark;
            this.txtFlowNumber.Text = stockIn.FlowNumber;
            this.txtCreateTime.Text = stockIn.CreateTime.ToDateTimeString();
        }

        /// <summary>
        /// 设置费用信息
        /// </summary>
        /// <param name="billing"></param>
        private void SetBillingControl(Billing billing)
        {
            this.nmUnitPrice.Value = billing.UnitPrice;
            this.nmHandlingUnitPrice.Value = billing.HandlingUnitPrice;
            this.nmHandlingPrice.Value = billing.HandlingPrice;
            this.nmFreezeUnitPrice.Value = billing.FreezeUnitPrice;
            this.nmFreezePrice.Value = billing.FreezePrice;
            this.nmDisposePrice.Value = billing.DisposePrice;
            this.nmPackingPrice.Value = billing.PackingPrice;
            this.nmRentPrice.Value = billing.RentPrice;
            this.nmOtherPrice.Value = billing.OtherPrice;
            this.txtBillingRemark.Text = billing.Remark;
        }

        /// <summary>
        /// 设置入库数据信息
        /// </summary>
        /// <param name="stockIn"></param>
        private void SetDataControl(StockIn stockIn)
        {
            var data = ModelTranslate.StockInToModel(stockIn);
            this.sigList.DataSource = data;
        }
        #endregion //Function

        #region Event
        #endregion //Event
    }
}
