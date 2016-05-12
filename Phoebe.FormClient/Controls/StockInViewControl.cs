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
            this.stockIn = BusinessFactory<StockInBusiness>.Instance.FindById(stockInId); ;
        }
        #endregion //Constructor

        #region Function
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
        }

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

        private void SetDataControl(StockIn stockIn)
        {
            var data = ModelTranslate.StockInToModel(stockIn);
            this.bsStockIn.DataSource = data;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInViewControl_Load(object sender, EventArgs e)
        {
            SetBaseControl(this.stockIn);
            SetBillingControl(this.stockIn.Billing);
            SetDataControl(this.stockIn);
        }
        #endregion //Event
    }
}
