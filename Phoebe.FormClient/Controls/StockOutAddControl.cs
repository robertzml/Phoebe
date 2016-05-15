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
        /// 设置数据筛选表格
        /// </summary>
        /// <param name="stores">数据</param>
        private void SetFilterDataControl(List<Store> stores)
        {
            var data = ModelTranslate.StoreToStockOut(stores);
            this.sogFilter.DataSource = data;
        }
        #endregion //Function

        #region Method
        public ErrorCode Save(out string errorMessage, out Guid newId)
        {
            errorMessage = "";
            newId = Guid.Empty;
            this.sogList.CloseEditor();

            // check input data and format digit
            if (this.selectCustomer == null || this.selectContract == null)
            {
                errorMessage = "请选择客户和合同";
                return ErrorCode.Error;
            }
            if (this.sogList.DataSource.Count == 0)
            {
                errorMessage = "没有出库货品";
                return ErrorCode.Error;
            }
            foreach (var item in this.sogList.DataSource)
            {
                if (item.OutCount > item.StoreCount)
                {
                    errorMessage = "出库数量大于在库数量";
                    return ErrorCode.Error;
                }
                if (item.InTime > this.dpOutTime.DateTime.Date)
                {
                    errorMessage = "出库时间早于货品入库时间";
                    return ErrorCode.Error;
                }

                item.OutWeight = Math.Round(item.OutWeight, 4);
                item.OutVolume = Math.Round(item.OutVolume, 4);
            }

            // set stock out
            StockOut so = new StockOut();
            so.Id = Guid.NewGuid();
            so.OutTime = this.dpOutTime.DateTime.Date;
            so.MonthTime = so.OutTime.Year.ToString() + so.OutTime.Month.ToString().PadLeft(2, '0');
            so.ContractId = this.selectContract.Id;
            so.UserId = this.currentUser.Id;
            so.CreateTime = DateTime.Now;
            so.Remark = this.txtRemark.Text;

            // add stock out
            ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Create(so, this.sogList.DataSource);
            if (result == ErrorCode.Success)
                newId = so.Id;

            return result;
        }
        #endregion //Method

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

            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);
            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            this.clcCategory.SetDataSource(this.categoryList);

            this.sogList.DataSource = new List<StockOutModel>();
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
                this.txtCustomerName.Text = customer.Name;
                this.selectCustomer = customer;

                UpdateContractList(customer.Id);
            }
            else
            {
                this.txtCustomerName.Text = "";
                this.selectCustomer = null;
                this.cmbContract.Properties.Items.Clear();
            }
        }

        /// <summary>
        /// 选择客户
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
                this.selectContract = null;
            }
            else
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                this.selectContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

                if ((BillingType)this.selectContract.BillingType == BillingType.VariousWeight)
                {
                    this.isEqualWeight = false;
                    this.sogList.SetEqualWeight(false);
                }
                else
                {
                    this.isEqualWeight = true;
                    this.sogList.SetEqualWeight(true);
                }
                this.txtBillingType.Text = ((BillingType)this.selectContract.BillingType).DisplayName();
            }

            this.sogFilter.Clear();
            this.sogList.Clear();
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
        /// 搜索库存记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.selectContract == null)
            {
                MessageBox.Show("未选择合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetByContract(this.selectContract.Id, true);
            var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
            if (category != null)
            {
                data = data.Where(r => category.Select(s => s.Id).Contains(r.Cargo.CategoryId)).ToList();
            }

            SetFilterDataControl(data);
        }

        /// <summary>
        /// 加入出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTo_Click(object sender, EventArgs e)
        {
            if (this.selectContract == null)
            {
                MessageBox.Show("未选择合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var select = this.sogFilter.GetCurrentSelect();
            if (select == null)
            {
                MessageBox.Show("未选择货品", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int count = Convert.ToInt32(this.nmOutCount.Value);
                if (count > select.StoreCount)
                {
                    MessageBox.Show("出库数量大于在库数量", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                select.OutCount = count;
                if (this.isEqualWeight)
                {
                    select.OutWeight = count * select.UnitWeight / 1000;
                }
                select.OutVolume = count * select.UnitVolume;

                this.sogList.DataSource.Add(select);
                this.sogList.UpdateBindingData();
            }
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFrom_Click(object sender, EventArgs e)
        {
            var select = this.sogList.GetCurrentSelect();
            if (select == null)
            {
                MessageBox.Show("未选择货品", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.sogList.DataSource.Remove(select);
                this.sogList.UpdateBindingData();
            }
        }
        #endregion //Event
    }
}
