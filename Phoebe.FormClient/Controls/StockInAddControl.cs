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
    /// 入库添加控件
    /// </summary>
    public partial class StockInAddControl : UserControl
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
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 入库添加控件
        /// </summary>
        /// <param name="user">登录用户</param>
        public StockInAddControl(LoginUser user)
        {
            InitializeComponent();

            this.currentUser = user;
            this.txtStatus.Text = "新建入库";
            this.txtUser.Text = this.currentUser.Name;
            this.dpInTime.EditValue = DateTime.Now;

            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);

            this.clcCategory.SetDataSource(BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory());

            this.sigList.DataSource = new List<StockInModel>();
            this.sigList.SetCategoryList(BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory());
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
            {
                this.cmbContract.SelectedIndex = 0;
            }
            else
            {
                this.selectContract = null;
                this.txtBillingType.Text = "";
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <param name="newId">新入库单ID</param>
        /// <param name="month">月份</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage, out Guid newId, out string month)
        {
            errorMessage = "";
            month = "";
            newId = Guid.Empty;
            this.sigList.CloseEditor();
        
            // check input data
            if (this.selectCustomer == null || this.selectContract == null)
            {
                errorMessage = "请选择客户和合同";
                return ErrorCode.Error;
            }
            if (this.sigList.DataSource.Count == 0)
            {
                errorMessage = "没有入库货品";
                return ErrorCode.Error;
            }
            foreach (StockInModel item in this.sigList.DataSource)
            {
                if (item.CategoryId == 0)
                {
                    errorMessage = "请输入正确分类编码";
                    return ErrorCode.Error;
                }
                if (item.InCount < 0)
                {
                    errorMessage = "入库数量不能为负数";
                    return ErrorCode.Error;
                }
                if (string.IsNullOrEmpty(item.WarehouseNumber))
                {
                    errorMessage = "仓位编号不能为空";
                    return ErrorCode.Error;
                }
            }

            // add cargo and set item field
            foreach (StockInModel item in this.sigList.DataSource)
            {
                item.ContractId = this.selectContract.Id;
                item.GroupType = this.selectContract.BillingType;
                item.UnitWeight = Math.Round(item.UnitWeight, 2);
                item.UnitVolume = Math.Round(item.UnitVolume, 3);
                item.InWeight = Math.Round(item.InWeight, 4);
                item.InVolume = Math.Round(item.InVolume, 4);

                var category = BusinessFactory<CategoryBusiness>.Instance.GetByNumber(item.CategoryNumber);
                item.CategoryId = category.Id;

                var cargo = BusinessFactory<CargoBusiness>.Instance.Create(item);
                if (cargo == null)
                {
                    return ErrorCode.CargoCreateFailed;
                }
                item.CargoId = cargo.Id;
            }

            // set stock in
            StockIn si = new StockIn();
            si.Id = Guid.NewGuid();
            si.InTime = this.dpInTime.DateTime.Date;
            si.MonthTime = si.InTime.Year.ToString() + si.InTime.Month.ToString().PadLeft(2, '0');
            si.ContractId = this.selectContract.Id;
            si.UserId = this.currentUser.Id;
            si.CreateTime = DateTime.Now;
            si.Remark = this.txtRemark.Text;

            // set billing
            Billing billing = new Billing();
            billing.ContractId = si.ContractId;
            billing.UnitPrice = this.nmUnitPrice.Value;
            billing.HandlingUnitPrice = this.nmHandlingUnitPrice.Value;
            billing.HandlingPrice = this.nmHandlingPrice.Value;
            billing.FreezeUnitPrice = this.nmFreezeUnitPrice.Value;
            billing.FreezePrice = this.nmFreezePrice.Value;
            billing.DisposePrice = this.nmDisposePrice.Value;
            billing.PackingPrice = this.nmPackingPrice.Value;
            billing.RentPrice = this.nmRentPrice.Value;
            billing.OtherPrice = this.nmOtherPrice.Value;
            billing.TotalPrice = billing.HandlingPrice + billing.FreezePrice + billing.DisposePrice +
                billing.PackingPrice + billing.RentPrice + billing.OtherPrice;
            billing.Remark = this.txtBillingRemark.Text;

            // add stock in
            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Create(si, billing, this.sigList.DataSource);
            if (result == ErrorCode.Success)
            {
                newId = si.Id;
                month = si.MonthTime;
            }

            return result;
        }
        #endregion //Method

        #region Event
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
                this.selectCustomer = null;
                this.txtCustomerName.Text = "";
                UpdateContractList(0);
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
        private void cmbContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            int contractId = Convert.ToInt32(this.cmbContract.EditValue);
            this.selectContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);

            if ((BillingType)this.selectContract.BillingType == BillingType.VariousWeight)
                this.isEqualWeight = false;
            else
                this.isEqualWeight = true;

            this.sigList.SetEqualWeight(this.isEqualWeight);
            this.txtBillingType.Text = ((BillingType)this.selectContract.BillingType).DisplayName();
        }

        /// <summary>
        /// 计算装卸费结冻费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            decimal totalWeight = this.sigList.DataSource.Sum(r => r.InWeight);

            decimal unitHandling = this.nmHandlingUnitPrice.Value;
            this.nmHandlingPrice.Value = totalWeight * unitHandling;

            decimal unitFreeze = this.nmFreezeUnitPrice.Value;
            this.nmFreezePrice.Value = totalWeight * unitFreeze;
        }

        /// <summary>
        /// 新增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            this.sigList.AddNew();
        }

        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            this.sigList.RemoveCurrent();
        }

        /// <summary>
        /// 单元格更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sigList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.clcCategory.UpdateView(e.Value.ToString());
        }
        #endregion //Event
    }
}
