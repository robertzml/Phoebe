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
    /// 新建入库界面
    /// </summary>
    public partial class StockInAddControl : UserControl
    {
        #region Field
        /// <summary>
        /// 登录用户
        /// </summary>
        private LoginUser currentUser;

        /// <summary>
        /// 客户列表
        /// </summary>
        private List<Customer> customerList;

        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;

        /// <summary>
        /// 选中客户ID
        /// </summary>
        private int customerId;

        /// <summary>
        /// 选中合同ID
        /// </summary>
        private int contractId;
        #endregion //Field

        #region Constructor
        public StockInAddControl(LoginUser user)
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
        private Customer UpdateCustomerView(string prefix)
        {
            this.lvCustomer.BeginUpdate();

            IEnumerable<Customer> customers;
            if (string.IsNullOrEmpty(prefix))
                customers = customerList.OrderBy(r => r.Number);
            else
                customers = customerList.Where(r => r.Number.StartsWith(prefix)).OrderBy(r => r.Number);

            this.lvCustomer.Items.Clear();
            foreach (var item in customers)
            {
                ListViewItem lvi = new ListViewItem(item.Number);
                lvi.Tag = item.Id;

                lvi.SubItems.Add(item.Name);

                this.lvCustomer.Items.Add(lvi);
            }

            this.lvCustomer.EndUpdate();

            if (customers.Count() == 1 && customers.First().Number == prefix)
                return customers.First();
            else
                return null;
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

        /// <summary>
        /// 更新分类列表
        /// </summary>
        /// <param name="prefix">分类前缀</param>
        private void UpdateCategoryView(string prefix)
        {
            this.lvCategory.BeginUpdate();

            IEnumerable<Category> categories;
            if (string.IsNullOrEmpty(prefix))
                categories = this.categoryList.OrderBy(r => r.Number);
            else
                categories = this.categoryList.Where(r => r.Number.StartsWith(prefix)).OrderBy(r => r.Number);

            this.lvCategory.Items.Clear();
            foreach (var item in categories)
            {
                ListViewItem lvi = new ListViewItem(item.Number);
                lvi.Tag = item.Id;

                lvi.SubItems.Add(item.Name);

                this.lvCategory.Items.Add(lvi);
            }

            this.lvCategory.EndUpdate();
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <returns></returns>
        public ErrorCode Save()
        {
            foreach (StockInModel item in this.bsStockIn)
            {
                item.ContractId = this.contractId;

                var category = BusinessFactory<CategoryBusiness>.Instance.GetByNumber(item.CategoryNumber);
                item.CategoryId = category.Id;

                var cargo = BusinessFactory<CargoBusiness>.Instance.Create(item);
                if (cargo == null)
                {
                    return ErrorCode.CargoCreateFailed;
                }
                item.CargoId = cargo.Id;
            }
        
            return ErrorCode.Success;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInAddControl_Load(object sender, EventArgs e)
        {
            this.txtStatus.Text = "新建入库";
            this.txtUser.Text = this.currentUser.Name;
            this.dpInTime.EditValue = DateTime.Now;

            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();

            UpdateCustomerView("");
            UpdateCategoryView("");
        }

        /// <summary>
        /// 输入客户代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCustomerNumber_EditValueChanged(object sender, EventArgs e)
        {
            string number = this.txtCustomerNumber.EditValue.ToString();
            var customer = UpdateCustomerView(number);

            if (customer != null)
            {
                this.txtCustomerName.Text = customer.Name;
                this.customerId = customer.Id;

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
        private void lvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvCustomer.SelectedItems.Count != 1)
                return;

            this.txtCustomerNumber.EditValueChanged -= txtCustomerNumber_EditValueChanged;

            var select = this.lvCustomer.SelectedItems[0];
            this.txtCustomerNumber.Text = select.SubItems[0].Text;
            this.txtCustomerName.Text = select.SubItems[1].Text;

            this.txtCustomerNumber.EditValueChanged += txtCustomerNumber_EditValueChanged;

            this.customerId = Convert.ToInt32(select.Tag);
            UpdateContractList(this.customerId);
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
                this.txtBillingType.Text = "";
            }
            else
            {
                this.contractId = Convert.ToInt32(this.cmbContract.EditValue);
                var contract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

                this.txtBillingType.Text = ((BillingType)contract.BillingType).DisplayName();
            }
        }
        #endregion //Event
    }
}
