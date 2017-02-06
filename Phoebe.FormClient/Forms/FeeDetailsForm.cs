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
    /// 费用详细记录窗体
    /// </summary>
    public partial class FeeDetailsForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 客户ID
        /// </summary>
        private int customerId;

        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime start;

        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime end;
        #endregion //Field

        #region Constructor
        public FeeDetailsForm()
        {
            InitializeComponent();
        }

        public FeeDetailsForm(int customerId, DateTime start, DateTime end)
        {
            InitializeComponent();

            this.customerId = customerId;
            this.start = start;
            this.end = end;
        }
        #endregion //Constructor

        #region Function
        private void GetDetails()
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(this.customerId);

            List<BaseSettlement> baseSettlement = new List<BaseSettlement>();
            List<ColdSettlement> coldSettlement = new List<ColdSettlement>();
            List<MiscSettlement> miscSettlement = new List<MiscSettlement>();

            foreach (var contract in contracts)
            {
                var contractBill = ContractFactory.Create((ContractType)contract.Type);

                var baseBill = contractBill.GetBaseFee(contract.Id, this.start.Date, this.end.Date);
                if (baseBill != null)
                    baseSettlement.AddRange(baseBill);

                var coldBill = contractBill.GetColdFee(contract.Id, this.start.Date, this.end.Date);
                if (coldBill != null)
                    coldSettlement.Add(coldBill);

                var miscBill = contractBill.GetMiscFee(contract.Id, this.start.Date, this.end.Date);
                if (miscBill != null)
                    miscSettlement.AddRange(miscBill);
            }

            this.bsGrid.DataSource = baseSettlement;
            this.csGrid.DataSource = coldSettlement;
            this.msGrid.DataSource = miscSettlement;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeeDetailsForm_Load(object sender, EventArgs e)
        {
            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(this.customerId);
            this.txtCustomerNumber.Text = customer.Number;
            this.txtCustomerName.Text = customer.Name;

            this.txtStartDate.Text = start.ToDateString();
            this.txtEndDate.Text = end.ToDateString();

            GetDetails();
        }
        

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion //Event
    }
}
