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
    /// 客户对账报表窗体
    /// </summary>
    public partial class CustomerAccountReportForm : Form
    {
        #region Field
        private SettleBusiness settleBusiness;

        private PaymentBusiness paymentBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public CustomerAccountReportForm()
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

        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerAccountReportForm_Load(object sender, EventArgs e)
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
            List<AccountStatement> data = new List<AccountStatement>();

            var customers = this.customerBusiness.Get();
            foreach (var customer in customers)
            {
                var settles = this.settleBusiness.Get(customer.ID);
                var payments = this.paymentBusiness.Get(customer.ID);

                if (settles.Count == 0 && payments.Count == 0)
                    continue;

                AccountStatement state = new AccountStatement();
                state.CustomerID = customer.ID;
                state.CustomerName = customer.Name;
                state.DueFee = settles.Sum(r => r.DueFee);
                state.PaidFee = payments.Sum(r => r.PaidFee);
                state.DebtFee = state.DueFee - state.PaidFee;

                data.Add(state);
            }

            this.textBoxTotalDueFee.Text = data.Sum(r => r.DueFee).ToString("f2") + " 元";
            this.textBoxTotalPaidFee.Text = data.Sum(r => r.PaidFee).ToString("f2") + " 元";
            this.textBoxTotalDebtFee.Text = data.Sum(r => r.DebtFee).ToString("f2") + " 元";

            this.accountStatementBindingSource.DataSource = data;
        }
        #endregion //Event
    }
}
