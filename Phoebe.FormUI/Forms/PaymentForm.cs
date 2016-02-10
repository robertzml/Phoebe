using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 客户缴费窗体
    /// </summary>
    public partial class PaymentForm : Form
    {
        #region Field
        private User currentUser;

        private CustomerBusiness customerBusiness;

        private PaymentBusiness paymentBusiness;
        #endregion //Field

        #region Constructor
        public PaymentForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
            this.paymentBusiness = new PaymentBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            this.textBoxUser.Text = this.currentUser.Name;
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
            InitData();
            InitControl();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("未选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer customer = this.comboBoxCustomer.SelectedItem as Customer;

            Payment payment = new Payment();
            payment.ID = Guid.NewGuid();
            payment.CustomerID = customer.ID;
            payment.PaidFee = this.numericPaidFee.Value;
            payment.PaidTime = this.datePaid.Value.Date;
            payment.UserID = this.currentUser.ID;
            payment.Remark = this.textBoxRemark.Text;
            payment.Status = (int)EntityStatus.PaymentPaid;

            ErrorCode result = this.paymentBusiness.Create(payment);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("保存缴费成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("保存缴费失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
