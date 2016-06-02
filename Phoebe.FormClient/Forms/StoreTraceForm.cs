using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    /// 库存追溯窗体
    /// </summary>
    public partial class StoreTraceForm : BaseForm
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

        /// <summary>
        /// 分类列表，缓存页面使用
        /// </summary>
        private List<Category> categoryList;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 库存追溯窗体
        /// </summary>
        public StoreTraceForm()
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

            this.sfgList.Clear();
            this.sgList.Clear();
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreTraceForm_Load(object sender, EventArgs e)
        {
            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);
            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            this.clcCategory.SetDataSource(this.categoryList);
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

            var customer = this.customerList.SingleOrDefault(r => r.Number == number);
            if (customer != null)
            {
                this.selectCustomer = customer;
                this.txtCustomerName.Text = customer.Name;
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
        /// 分类代码输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCategoryNumber_EditValueChanged(object sender, EventArgs e)
        {
            string number = this.txtCategoryNumber.EditValue.ToString();
            this.clcCategory.UpdateView(number);

            var category = this.categoryList.SingleOrDefault(r => r.Number == number);
            if (category != null)
            {
                this.txtCategoryName.Text = category.Name;
            }
            else
            {
                this.txtCategoryName.Text = "";
            }
        }

        /// <summary>
        /// 选择分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clcCategory_CategoryItemSelected(object sender, EventArgs e)
        {
            this.txtCategoryNumber.EditValueChanged -= txtCategoryNumber_EditValueChanged;

            this.txtCategoryNumber.Text = this.clcCategory.SelectedNumber;
            this.txtCategoryName.Text = this.clcCategory.SelectedName;

            this.txtCategoryNumber.EditValueChanged += txtCategoryNumber_EditValueChanged;
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageBox.Show("请选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            EntityStatus storeStatus = EntityStatus.StoreIn;
            if (rbStoreIn.Checked)
                storeStatus = EntityStatus.StoreIn;
            else
                storeStatus = EntityStatus.StoreOut;

            List<Store> data = new List<Store>();
            data = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(this.selectCustomer.Id, storeStatus);

            // filter contract
            if (this.cmbContract.EditValue != null)
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                data = data.Where(r => r.Cargo.ContractId == contractId).ToList();
            }

            // filter category
            var category = this.categoryList.SingleOrDefault(r => r.Number == this.txtCategoryNumber.Text);
            if (category != null)
            {
                var parent = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
                if (parent != null)
                {
                    data = data.Where(r => parent.Select(s => s.Id).Contains(r.Cargo.CategoryId)).ToList();
                }
            }

            this.sgList.DataSource = data;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 追溯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrace_Click(object sender, EventArgs e)
        {
            var store = this.sgList.GetCurrentSelect();
            if (store == null)
            {
                MessageBox.Show("未选择记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            var flow = BusinessFactory<StoreBusiness>.Instance.GetStoreFlow(store.Id).OrderBy(r => r.FlowDate).ToList();
            this.sfgList.DataSource = flow;

            this.Cursor = Cursors.Default;
        }
        #endregion //Event
    }
}
