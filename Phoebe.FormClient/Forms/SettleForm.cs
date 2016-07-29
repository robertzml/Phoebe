﻿using System;
using System.Collections.Generic;
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
    /// 结算管理窗体
    /// </summary>
    public partial class SettleForm : BaseForm
    {
        #region Field
        #endregion //Field

        #region Constructor
        public SettleForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 费用计算
        /// </summary>
        /// <returns>
        /// 应付款
        /// </returns>
        private decimal CalculateFee()
        {
            decimal dueFee = this.nmSumFee.Value * (this.nmDiscount.Value / 100) - this.nmRemission.Value;
            this.txtDueFee.Text = Math.Round(dueFee, 2, MidpointRounding.AwayFromZero).ToString();

            return dueFee;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="settlement"></param>
        private void SetEntity(Settlement settlement)
        {
            settlement.Id = Guid.NewGuid();
            settlement.CustomerId = Convert.ToInt32(this.lkuCustomer.EditValue);
            settlement.StartTime = this.dpFrom.DateTime.Date;
            settlement.EndTime = this.dpTo.DateTime.Date;
            settlement.SumFee = this.nmSumFee.Value;
            settlement.Discount = Convert.ToInt32(this.nmDiscount.Value);
            settlement.Remission = this.nmRemission.Value;
            settlement.DueFee = CalculateFee();
            settlement.SettleTime = this.dpSettleTime.DateTime.Date;
            settlement.UserId = this.currentUser.Id;
            settlement.Remark = this.txtRemark.Text;
            settlement.Status = (int)EntityStatus.Settled;
        }

        /// <summary>
        /// 设置详细信息
        /// </summary>
        /// <param name="settlementId"></param>
        /// <param name="details"></param>
        private void SetDetails(Guid settlementId, List<SettlementDetail> details)
        {
            for (int i = 0; i < this.bsBilling.Count; i++)
            {
                var billing = this.bsBilling[i] as Billing;

                SettlementDetail detail = new SettlementDetail();
                detail.Id = Guid.NewGuid();
                detail.SettlementId = settlementId;
                detail.StockInId = billing.StockInId;
                detail.ExpenseType = (int)ExpenseType.Base;
                detail.SumFee = billing.TotalPrice;
                detail.Status = (int)EntityStatus.Settled;

                if (detail.SumFee == 0)
                    continue;

                details.Add(detail);
            }

            for (int i = 0; i < this.bsCold.Count; i++)
            {
                var cold = this.bsCold[i] as ColdSettlement;

                SettlementDetail detail = new SettlementDetail();
                detail.Id = Guid.NewGuid();
                detail.SettlementId = settlementId;
                detail.ContractId = cold.ContractId;
                detail.ExpenseType = (int)ExpenseType.Cold;
                detail.SumFee = cold.ColdFee;
                detail.Status = (int)EntityStatus.Settled;

                if (detail.SumFee == 0)
                    continue;

                details.Add(detail);
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettleForm_Load(object sender, EventArgs e)
        {
            this.dpFrom.DateTime = DateTime.Now.Date;
            this.dpTo.DateTime = DateTime.Now.Date;
            this.dpSettleTime.DateTime = DateTime.Now.Date;

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkuCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                this.txtLastFrom.Text = "";
                this.txtLastTo.Text = "";
            }
            else
            {
                int customerId = Convert.ToInt32(this.lkuCustomer.EditValue);
                var last = BusinessFactory<SettlementBusiness>.Instance.GetLast(customerId);
                if (last == null)
                {
                    this.txtLastFrom.Text = this.txtLastTo.Text = "";
                }
                else
                {
                    this.txtLastFrom.Text = last.StartTime.ToShortDateString();
                    this.txtLastTo.Text = last.EndTime.ToShortDateString();
                }
            }

            this.btnSave.Enabled = false;
        }

        /// <summary>
        /// 开始结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            if (this.dpTo.DateTime < this.dpFrom.DateTime)
            {
                MessageUtil.ShowClaim("开始日期大于结束日期");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            int customerId = Convert.ToInt32(this.lkuCustomer.EditValue);

            var billings = BusinessFactory<BillingBusiness>.Instance.CalculateBaseFee(customerId, this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date);
            this.bsBilling.DataSource = billings;

            var colds = BusinessFactory<BillingBusiness>.Instance.CalculateColdFee(customerId, this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date);
            this.bsCold.DataSource = colds;

            decimal totalPrice = billings.Sum(r => r.TotalPrice) + colds.Sum(r => r.ColdFee);
            this.nmSumFee.Value = totalPrice;

            this.nmDiscount.Value = 100;
            this.nmRemission.Value = 0;
            this.txtRemark.Text = "";

            CalculateFee();

            this.btnSave.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 基本费用格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBilling_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsBilling.Count)
                return;

            var billing = this.bsBilling[rowIndex] as Billing;

            if (e.Column.FieldName == "ContractId")
            {
                e.DisplayText = billing.Contract.Name;
            }
        }

        /// <summary>
        /// 修改折扣率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nmDiscount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateFee();
        }

        /// <summary>
        /// 修改减免费用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nmRemission_EditValueChanged(object sender, EventArgs e)
        {
            CalculateFee();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            Settlement settlement = new Settlement();
            SetEntity(settlement);

            List<SettlementDetail> details = new List<SettlementDetail>();
            SetDetails(settlement.Id, details);

            ErrorCode result = BusinessFactory<SettlementBusiness>.Instance.Create(settlement, details);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("保存结算成功");
                this.btnSave.Enabled = false;
            }
            else
            {
                MessageUtil.ShowWarning("保存结算失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
