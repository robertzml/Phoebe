using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 出库添加控件
    /// </summary>
    public partial class StockOutAddControl : UserControl
    {
        #region Field
        /// <summary>
        /// 登录用户
        /// </summary>
        private LoginUser currentUser;

        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;

        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;

        /// <summary>
        /// 选中合同
        /// </summary>
        private Contract selectContract;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 出库添加控件
        /// </summary>
        /// <param name="user">登录用户</param>
        public StockOutAddControl(LoginUser user)
        {
            InitializeComponent();

            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新客户列表
        /// </summary>
        /// <param name="prefix">客户编码前缀</param>
        /// <returns></returns>
        private void UpdateCustomerView(string prefix)
        {
            //this.lvCustomer.BeginUpdate();

            //IEnumerable<Customer> customers;
            //if (string.IsNullOrEmpty(prefix))
            //    customers = customerList.OrderBy(r => r.Number);
            //else
            //    customers = customerList.Where(r => r.Number.StartsWith(prefix)).OrderBy(r => r.Number);

            //this.lvCustomer.Items.Clear();
            //foreach (var item in customers)
            //{
            //    ListViewItem lvi = new ListViewItem(item.Number);
            //    lvi.Tag = item.Id;

            //    lvi.SubItems.Add(item.Name);

            //    this.lvCustomer.Items.Add(lvi);
            //}

            //this.lvCustomer.EndUpdate();
        }

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
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutAddControl_Load(object sender, EventArgs e)
        {
            this.txtStatus.Text = "新建出库";
            this.txtUser.Text = this.currentUser.Name;
            this.dpOutTime.EditValue = DateTime.Now;

            this.clcCustomer.SetSource(BusinessFactory<CustomerBusiness>.Instance.FindAll());

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();

            UpdateCustomerView("");
        }

        /// <summary>
        /// 输入客户代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            string number = this.txtCustomerNumber.EditValue.ToString();
            // UpdateCustomerView(number);
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
        /// 选择客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clcCustomer_CustomerItemSelected(object sender, EventArgs e)
        {
            var lvCustomer = sender as ListView;
            if (lvCustomer.SelectedItems.Count != 1)
                return;
            
            this.txtCustomerNumber.EditValueChanged -= txtCustomerNumber_EditValueChanged;

            var select = lvCustomer.SelectedItems[0];
            this.txtCustomerNumber.Text = this.clcCustomer.SelectedNumber;
            this.txtCustomerName.Text = this.clcCustomer.SelectedName;

            this.txtCustomerNumber.EditValueChanged += txtCustomerNumber_EditValueChanged;

            int customerId = this.clcCustomer.SelectedId;
            UpdateContractList(customerId);
            this.selectCustomer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);
        }

        /// <summary>
        /// 选择合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbContract_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cmbContract.SelectedIndex == -1)
            {
                this.txtBillingType.Text = "";
            }
            else
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                this.selectContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

                if ((BillingType)this.selectContract.BillingType == BillingType.VariousWeight)
                {
                    this.isEqualWeight = false;
                    // this.colInWeight.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    this.isEqualWeight = true;
                    // this.colInWeight.OptionsColumn.AllowEdit = false;
                }
                this.txtBillingType.Text = ((BillingType)this.selectContract.BillingType).DisplayName();
            }
        }
        #endregion //Event

    }
}
