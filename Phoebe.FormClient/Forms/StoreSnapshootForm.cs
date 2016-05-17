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
    public partial class StoreSnapshootForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;

        /// <summary>
        /// 选中合同
        /// </summary>
        private Contract selectContract;

        /// <summary>
        /// 客户列表，缓存页面使用
        /// </summary>
        private List<Customer> customerList;
        #endregion //Field

        #region Constructor
        public StoreSnapshootForm()
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

            if (this.cmbContract.Properties.Items.Count > 0)
                this.cmbContract.SelectedIndex = 0;
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
                this.txtCustomerName.Text = "";
        }

        /// <summary>
        /// 选择合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbContract.SelectedIndex == -1)
            {
                
            }
            else
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                this.selectContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);              
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeach_Click(object sender, EventArgs e)
        {
            if (this.selectContract == null)
            {
                return;
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetDayFlow(this.selectContract.Id, this.dpTime.DateTime.Date);
            this.bsStockFlow.DataSource = data;
        }
        #endregion //Event
    }
}
