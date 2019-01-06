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
        /// 选中合同
        /// </summary>
        private Contract selectContract;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;

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

            this.txtStatus.Text = "新建出库";
            this.txtUser.Text = this.currentUser.Name;
            this.dpOutTime.DateTime = DateTime.Now;

            this.customerLookup.Init();

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            this.clcCategory.SetDataSource(this.categoryList);

            this.sogList.DataSource = new List<StockOutModel>();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer2(customerId);

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

        /// <summary>
        /// 获取客户当前欠费
        /// </summary>
        /// <param name="customerId">客户ID</param>
        private void LoadCustomerDebt(int customerId)
        {
            if (customerId == 0)
            {
                this.txtDebt.Text = "";
                return;
            }

            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);

            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customer.Id);
            if (contracts.Count == 0)
            {
                this.txtDebt.Text = "";
                return;
            }

            DateTime start = contracts.Min(r => r.SignDate);
            DateTime end = DateTime.Now.Date;

            var debt = BusinessFactory<SettlementBusiness>.Instance.GetDebt(customer.Id, start, end);
            this.txtDebt.Text = debt.DebtFee.ToString("f2") + " 元";
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存出库
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <param name="newId">新出库单ID</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage, out Guid newId, out string month)
        {
            errorMessage = "";
            month = "";
            newId = Guid.Empty;
            this.sogList.CloseEditor();

            // check input data and format digit
            if (this.customerLookup.GetSelectedId() == 0)
            {
                errorMessage = "请选择客户";
                return ErrorCode.Error;
            }
            if (this.selectContract == null)
            {
                errorMessage = "请选择合同";
                return ErrorCode.Error;
            }
            if (this.sogList.DataSource.Count == 0)
            {
                errorMessage = "没有出库货品";
                return ErrorCode.Error;
            }
            foreach (var item in this.sogList.DataSource)
            {
                if (item.OutCount < 0)
                {
                    errorMessage = "出库数量不能为负数";
                    return ErrorCode.Error;
                }
                if (item.OutCount > item.StoreCount)
                {
                    errorMessage = "出库数量大于在库数量";
                    return ErrorCode.Error;
                }
                if (item.MoveTime > this.dpOutTime.DateTime.Date)
                {
                    errorMessage = "出库时间早于货品移入时间";
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
            {
                newId = so.Id;
                month = so.MonthTime;
            }

            return result;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerLookup_CustomerSelect(object sender, EventArgs e)
        {
            int id = this.customerLookup.GetSelectedId();
            if (id == 0)
            {
                UpdateContractList(0);
                LoadCustomerDebt(id);
            }
            else
            {
                UpdateContractList(id);
                LoadCustomerDebt(id);
            }
        }

        /// <summary>
        /// 选择合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbContract_EditValueChanged(object sender, EventArgs e)
        {
            if (this.cmbContract.EditValue == null)
            {
                this.selectContract = null;
                this.txtBillingType.Text = "";
            }
            else
            {
                int contractId = Convert.ToInt32(this.cmbContract.EditValue);
                this.selectContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

                if ((BillingType)this.selectContract.BillingType == BillingType.VariousWeight)
                    this.isEqualWeight = false;
                else
                    this.isEqualWeight = true;

                this.sogList.SetEqualWeight(this.isEqualWeight);
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
        /// 分类名称输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCategoryName_EditValueChanged(object sender, EventArgs e)
        {
            string name = this.txtCategoryName.EditValue.ToString();
            this.clcCategory.SearchName(name);

            var category = this.categoryList.SingleOrDefault(r => r.Name == name);
            if (category != null)
            {
                this.txtCategoryNumber.Text = category.Number;
            }
            else
            {
                this.txtCategoryNumber.Text = "";
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
            this.txtCategoryName.EditValueChanged -= txtCategoryName_EditValueChanged;

            this.txtCategoryNumber.Text = this.clcCategory.SelectedNumber;
            this.txtCategoryName.Text = this.clcCategory.SelectedName;

            this.txtCategoryName.EditValueChanged += txtCategoryName_EditValueChanged;
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
                MessageUtil.ShowClaim("未选择合同");
                return;
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetByContract(this.selectContract.Id, true);
            var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
            if (category != null)
            {
                data = data.Where(r => category.Select(s => s.Id).Contains(r.Cargo.CategoryId)).ToList();
            }

            var models = ModelTranslate.StoreToStockOut(data);
            this.sogFilter.DataSource = models;
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
                MessageUtil.ShowClaim("未选择合同");
                return;
            }

            var select = this.sogFilter.GetCurrentSelect();
            if (select == null)
            {
                MessageUtil.ShowClaim("未选择记录");
                return;
            }
            else
            {
                if (this.sogList.CheckHasStore(select))
                {
                    MessageUtil.ShowClaim("该货品已经加入");
                    return;
                }

                int count = Convert.ToInt32(this.nmOutCount.Value);
                if (count > select.StoreCount)
                {
                    MessageUtil.ShowClaim("出库数量大于在库数量");
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
                MessageUtil.ShowClaim("未选择记录");
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
