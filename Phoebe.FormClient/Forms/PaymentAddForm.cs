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
    /// 客户缴费
    /// </summary>
    public partial class PaymentAddForm : BaseSingleForm
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
        public PaymentAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void SetEntity(Payment payment)
        {
            payment.CustomerId = this.selectCustomer.Id;
            payment.PaidFee = this.nmPaidFee.Value;
            payment.PaidTime = this.dpPaidTime.DateTime.Date;
            payment.UserId = this.currentUser.Id;
            payment.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaymentForm_Load(object sender, EventArgs e)
        {
            this.dpPaidTime.DateTime = DateTime.Now.Date;
            this.txtUser.Text = this.currentUser.Name;

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
            if (customer != null)
            {
                this.selectCustomer = customer;
                this.txtCustomerName.Text = customer.Name;
            }
            else
            {
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";
            }
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
            this.selectCustomer = this.customerList.SingleOrDefault(r => r.Id == customerId);
        }
       
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.nmPaidFee.Value <= 0)
            {
                MessageBox.Show("请输入正确金额", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Payment payment = new Payment();
            SetEntity(payment);

            ErrorCode result = BusinessFactory<PaymentBusiness>.Instance.Create(payment);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加缴费成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加缴费失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
