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
    /// 客户综合窗体
    /// </summary>
    public partial class CustomerDashboardForm : BaseForm
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
        public CustomerDashboardForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
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

            var customer = BusinessFactory<CustomerBusiness>.Instance.GetByNumber(number);
            if (customer != null)
            {
                this.txtCustomerName.Text = customer.Name;
                this.selectCustomer = customer;
                //UpdateContractList(customer.Id);
            }
            else
            {
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";
                //UpdateContractList(0);
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
            //UpdateContractList(customerId);
            this.selectCustomer = this.customerList.SingleOrDefault(r => r.Id == customerId);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(this.selectCustomer.Id);
            this.sgList.DataSource = data;

            var flows = BusinessFactory<StoreBusiness>.Instance.GetCustomerFlow(this.selectCustomer.Id, true);
            this.sfgList.DataSource = flows;
        }
        #endregion //Event
    }
}
