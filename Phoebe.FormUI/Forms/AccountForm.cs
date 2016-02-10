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
    /// 客户对账窗体
    /// </summary>
    public partial class AccountForm : Form
    {
        #region Field
        private SettleBusiness settleBusiness;

        private PaymentBusiness paymentBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public AccountForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.settleBusiness = new SettleBusiness();
            this.paymentBusiness = new PaymentBusiness();
            this.customerBusiness = new CustomerBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            Customer customer = this.comboBoxCustomer.SelectedItem as Customer;

            var settles = this.settleBusiness.Get(customer.ID);
            this.settlementBindingSource.DataSource = settles;

            var payments = this.paymentBusiness.Get(customer.ID);
            this.paymentBindingSource.DataSource = payments;

            var dueFee = settles.Sum(r => r.DueFee);
            this.numericDueFee.Value = dueFee;

            var paidFee = payments.Sum(r => r.PaidFee);
            this.numericPaidFee.Value = paidFee;

            this.numericDebtFee.Value = dueFee - paidFee;
        }

        private void settlementDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.settlementBindingSource.Count)
            {
                var settlement = this.settlementBindingSource[e.RowIndex] as Settlement;

                if (settlement.User != null)
                {
                    this.settlementDataGridView.Rows[e.RowIndex].Cells[this.columnSettlementUser.Index].Value = settlement.User.Name;
                }
            }
        }

        private void paymentDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.paymentBindingSource.Count)
            {
                var payment = this.paymentBindingSource[e.RowIndex] as Payment;

                if (payment.User != null)
                {
                    this.paymentDataGridView.Rows[e.RowIndex].Cells[this.columnPaymentUser.Index].Value = payment.User.Name;
                }
            }
        }
        #endregion //Event
    }
}
