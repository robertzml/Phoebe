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
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 实时结算窗体
    /// </summary>
    public partial class SettleRealForm : Form
    {
        #region Field
        private SettleBusiness settleBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;
        #endregion //Field

        #region Constructor
        public SettleRealForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.settleBusiness = new SettleBusiness();
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
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
        private void SettleRealForm_Load(object sender, EventArgs e)
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

            var customer = this.comboBoxCustomer.SelectedItem as Customer;

            var contracts = this.contractBusiness.GetByCustomer(customer.ID);
            if (contracts.Count == 0)
            {
                MessageBox.Show("该客户无合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime start = contracts.Min(r => r.SignDate);
            DateTime end = DateTime.Now.Date;

            var receipt = this.settleBusiness.GetRealTime(customer.ID, start, end);

            this.textBoxStartTime.Text = start.ToShortDateString();
            this.textBoxEndTime.Text = end.ToShortDateString();
            this.textBoxSettleFee.Text = receipt.SettleFee.ToString("f2") + " 元";
            this.textBoxRealFee.Text = receipt.RealFee.ToString("f2") + " 元";
            this.textBoxSumFee.Text = (receipt.SettleFee + receipt.RealFee).ToString("f2") + "元";
            this.textBoxPaidFee.Text = receipt.PaidFee.ToString("f2") + " 元";
            this.textBoxDifference.Text = receipt.Difference.ToString("f2") + " 元";
        }
        #endregion //Event
    }
}
