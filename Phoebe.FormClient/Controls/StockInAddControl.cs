using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

        #region Method
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <param name="newId">新入库单ID</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage, out Guid newId)
        {
            errorMessage = "";
            newId = Guid.Empty;
            this.dgvStockIn.CloseEditor();

            // check input data
            if (this.selectCustomer == null || this.selectContract == null)
            {
                errorMessage = "请选择客户和合同";
                return ErrorCode.Error;
            }
            if (this.bsStockIn.Count == 0)
            {
                errorMessage = "没有入库货品";
                return ErrorCode.Error;
            }
            foreach (StockInModel item in this.bsStockIn)
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
                    errorMessage = "仓库编号不能为空";
                    return ErrorCode.Error;
                }
            }

            // add cargo and set item field
            List<StockInModel> siModels = new List<StockInModel>();
            foreach (StockInModel item in this.bsStockIn)
            {
                item.ContractId = this.selectContract.Id;
                item.GroupType = this.selectContract.BillingType;

                var category = BusinessFactory<CategoryBusiness>.Instance.GetByNumber(item.CategoryNumber);
                item.CategoryId = category.Id;

                var cargo = BusinessFactory<CargoBusiness>.Instance.Create(item);
                if (cargo == null)
                {
                    return ErrorCode.CargoCreateFailed;
                }
                item.CargoId = cargo.Id;
                siModels.Add(item);
            }

            // set stock in
            StockIn si = new StockIn();
            si.Id = Guid.NewGuid();
            si.InTime = Convert.ToDateTime(this.dpInTime.EditValue).Date;
            si.MonthTime = si.InTime.Year.ToString() + si.InTime.Month.ToString().PadLeft(2, '0');
            si.ContractId = this.selectContract.Id;
            si.UserId = this.currentUser.Id;
            si.CreateTime = DateTime.Now;
            si.Remark = this.txtRemark.Text;

            // set billing
            Billing billing = new Billing();
            billing.ContractId = si.ContractId;
            billing.UnitPrice = this.nmUnitPrice.Value;
            billing.HandlingUnitPrice = this.nmHandlingPrice.Value;
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
            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Create(si, billing, siModels);
            if (result == ErrorCode.Success)
                newId = si.Id;

            return result;
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

            this.clcCustomer.SetSource(BusinessFactory<CustomerBusiness>.Instance.FindAll());
            this.clcCategory.SetSource(BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory());
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
                    this.colInWeight.OptionsColumn.AllowEdit = true;
                }
                else
                {
                    this.isEqualWeight = true;
                    this.colInWeight.OptionsColumn.AllowEdit = false;
                }
                this.txtBillingType.Text = ((BillingType)this.selectContract.BillingType).DisplayName();
            }
        }

        /// <summary>
        /// 单元格更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStockIn_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Name == "colCategoryNumber")
            {
                string number = e.Value.ToString();
                this.clcCategory.UpdateView(number);

                var category = BusinessFactory<CategoryBusiness>.Instance.GetByNumber(number, true);
                if (category != null)
                {
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryName", category.Name);
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryId", category.Id);
                }
                else
                {
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryName", "");
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "CategoryId", 0);
                }
            }
            else if (e.Column.Name == "colInCount")
            {
                int count = 0;
                if (!Int32.TryParse(e.Value.ToString(), out count))
                {
                    return;
                }

                if (this.isEqualWeight)
                {
                    double unitWeight = Convert.ToDouble(this.dgvStockIn.GetRowCellValue(e.RowHandle, "UnitWeight"));
                    double totalWeight = count * unitWeight / 1000;
                    this.dgvStockIn.SetRowCellValue(e.RowHandle, "InWeight", totalWeight);
                }

                double unitVolume = Convert.ToDouble(this.dgvStockIn.GetRowCellValue(e.RowHandle, "UnitVolume"));
                double totalVolume = count * unitVolume;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InVolume", totalVolume);
            }
            else if (e.Column.Name == "colUnitWeight")
            {
                if (!this.isEqualWeight)
                    return;

                double unitWeight = 0;
                if (!double.TryParse(e.Value.ToString(), out unitWeight))
                {
                    return;
                }

                int count = Convert.ToInt32(this.dgvStockIn.GetRowCellValue(e.RowHandle, "InCount"));
                double totalWeight = count * unitWeight / 1000;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InWeight", totalWeight);
            }
            else if (e.Column.Name == "colUnitVolume")
            {
                double unitVolume = 0;
                if (!double.TryParse(e.Value.ToString(), out unitVolume))
                {
                    return;
                }

                int count = Convert.ToInt32(this.dgvStockIn.GetRowCellValue(e.RowHandle, "InCount"));
                double totalVolume = count * unitVolume;
                this.dgvStockIn.SetRowCellValue(e.RowHandle, "InVolume", totalVolume);
            }
        }
        #endregion //Event
    }
}
