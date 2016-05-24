using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存快照窗体
    /// </summary>
    public partial class StoreSnapshotForm : BaseForm
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
        /// <summary>
        /// 库存快照窗体
        /// </summary>
        public StoreSnapshotForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

            this.cmbContract.Properties.Items.Clear();
            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            if (contracts.Count > 0)
                this.cmbContract.EditValue = contracts[0].Id;
            else
                this.cmbContract.EditValue = null;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreSnapshootForm_Load(object sender, EventArgs e)
        {
            this.dpTime.DateTime = DateTime.Now.Date;

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

                UpdateContractList(customer.Id);
            }
            else
            {
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";
                UpdateContractList(0);
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
            UpdateContractList(customerId);
            this.selectCustomer = this.customerList.SingleOrDefault(r => r.Id == customerId);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeach_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cmbContract.EditValue == null)
            {
                MessageBox.Show("请选择合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int contractId = Convert.ToInt32(this.cmbContract.EditValue);

            if (this.dpTime.DateTime.Date > DateTime.Now)
            {
                MessageBox.Show("日期超过今天", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var storage = BusinessFactory<StoreBusiness>.Instance.GetInDay(contractId, this.dpTime.DateTime.Date);
            this.srgList.DataSource = storage;

            var flow = BusinessFactory<StoreBusiness>.Instance.GetDayFlow(contractId, this.dpTime.DateTime.Date);
            this.sfgList.DataSource = flow;
        }
        #endregion //Event     
    }
}
