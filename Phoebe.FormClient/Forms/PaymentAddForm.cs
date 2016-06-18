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
            payment.CustomerId = Convert.ToInt32(this.lkuCustomer.EditValue);
            payment.PaidFee = this.nmPaidFee.Value;
            payment.PaidTime = this.dpPaidTime.DateTime.Date;
            payment.PaidType = (int)this.cmbType.EditValue;
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

            this.cmbType.Properties.Items.AddEnum(typeof(PaymentType));

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            if (this.cmbType.SelectedIndex == -1)
            {
                MessageUtil.ShowClaim("缴费方式不能为空");
                return;
            }

            if (this.nmPaidFee.Value <= 0)
            {
                MessageUtil.ShowClaim("请输入正确金额");
                return;
            }

            Payment payment = new Payment();
            SetEntity(payment);

            ErrorCode result = BusinessFactory<PaymentBusiness>.Instance.Create(payment);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加缴费成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowError("添加缴费失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
