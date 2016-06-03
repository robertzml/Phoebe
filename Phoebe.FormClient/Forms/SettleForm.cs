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
    /// 结算管理窗体
    /// </summary>
    public partial class SettleForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;

        /// <summary>
        /// 客户列表，缓存页面使用
        /// </summary>
        private List<Customer> customerList;
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
            decimal dueFee = this.nmSumFee.Value * this.nmDiscount.Value / 100 - this.nmRemission.Value;
            this.txtDueFee.Text = Math.Round(dueFee, 2).ToString();

            return dueFee;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="settlement"></param>
        private void SetEntity(Settlement settlement)
        {
            settlement.Id = Guid.NewGuid();
            settlement.CustomerId = this.selectCustomer.Id;
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

        /// <summary>
        /// 客户更改
        /// </summary>
        /// <param name="customer">客户对象</param>
        private void CustomerChange(Customer customer)
        {
            if (customer != null)
            {
                this.selectCustomer = customer;
                this.txtCustomerName.Text = customer.Name;

                var last = BusinessFactory<SettlementBusiness>.Instance.GetLast(customer.Id);
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
            else
            {
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";

                this.txtLastFrom.Text = "";
                this.txtLastTo.Text = "";
            }

            this.btnSave.Enabled = false;
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

            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);
        }

        /// <summary>
        /// 输入客户代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            string number = this.txtCustomerNumber.EditValue.ToString();
            this.clcCustomer.UpdateView(number);

            var customer = this.customerList.SingleOrDefault(r => r.Number == number);
            CustomerChange(customer);
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clcCustomer_CustomerItemSelected(object sender, EventArgs e)
        {
            this.txtCustomerNumber.EditValueChanged -= txtCustomerNumber_EditValueChanged;

            this.txtCustomerNumber.Text = this.clcCustomer.SelectedNumber;
            this.txtCustomerName.Text = this.clcCustomer.SelectedName;

            this.txtCustomerNumber.EditValueChanged += txtCustomerNumber_EditValueChanged;

            int customerId = this.clcCustomer.SelectedId;
            var customer = this.customerList.SingleOrDefault(r => r.Id == customerId);
            CustomerChange(customer);
        }

        /// <summary>
        /// 开始结算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettle_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dpTo.DateTime < this.dpFrom.DateTime)
            {
                MessageBox.Show("开始日期大于结束日期", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var billings = BusinessFactory<BillingBusiness>.Instance.CalculateBaseFee(this.selectCustomer.Id, this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date);
            this.bsBilling.DataSource = billings;

            var colds = BusinessFactory<BillingBusiness>.Instance.CalculateColdFee(this.selectCustomer.Id, this.dpFrom.DateTime.Date, this.dpTo.DateTime.Date);
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
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Settlement settlement = new Settlement();
            SetEntity(settlement);

            List<SettlementDetail> details = new List<SettlementDetail>();
            SetDetails(settlement.Id, details);

            ErrorCode result = BusinessFactory<SettlementBusiness>.Instance.Create(settlement, details);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("保存结算成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("保存结算失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
