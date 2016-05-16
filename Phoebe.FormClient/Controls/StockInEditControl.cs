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
    /// 编辑入库界面
    /// </summary>
    public partial class StockInEditControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联入库单
        /// </summary>
        private StockIn stockIn;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        public StockInEditControl(Guid stockInId)
        {
            InitializeComponent();

            this.stockIn = BusinessFactory<StockInBusiness>.Instance.FindById(stockInId);

            SetBaseControl(this.stockIn);
            SetBillingControl(this.stockIn.Billing);
            SetDataControl(this.stockIn);

            this.clcCategory.SetDataSource(BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory());

            if ((BillingType)this.stockIn.Contract.BillingType == BillingType.VariousWeight)
                this.isEqualWeight = false;
            else
                this.isEqualWeight = true;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基本信息
        /// </summary>
        /// <param name="stockIn"></param>
        private void SetBaseControl(StockIn stockIn)
        {
            this.txtStatus.Text = ((EntityStatus)stockIn.Status).DisplayName();
            this.txtInTime.Text = stockIn.InTime.ToShortDateString();
            this.txtUser.Text = stockIn.User.Name;
            this.txtCustomerNumber.Text = stockIn.Contract.Customer.Number;
            this.txtCustomerName.Text = stockIn.Contract.Customer.Name;
            this.txtContract.Text = stockIn.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockIn.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockIn.Remark;
            this.txtFlowNumber.Text = stockIn.FlowNumber;
        }

        /// <summary>
        /// 设置费用信息
        /// </summary>
        /// <param name="billing"></param>
        private void SetBillingControl(Billing billing)
        {
            this.nmUnitPrice.Value = billing.UnitPrice;
            this.nmHandlingUnitPrice.Value = billing.HandlingUnitPrice;
            this.nmHandlingPrice.Value = billing.HandlingPrice;
            this.nmFreezeUnitPrice.Value = billing.FreezeUnitPrice;
            this.nmFreezePrice.Value = billing.FreezePrice;
            this.nmDisposePrice.Value = billing.DisposePrice;
            this.nmPackingPrice.Value = billing.PackingPrice;
            this.nmRentPrice.Value = billing.RentPrice;
            this.nmOtherPrice.Value = billing.OtherPrice;
            this.txtBillingRemark.Text = billing.Remark;
        }

        /// <summary>
        /// 设置入库数据信息
        /// </summary>
        /// <param name="stockIn"></param>
        private void SetDataControl(StockIn stockIn)
        {
            var data = ModelTranslate.StockInToModel(stockIn);
            this.sigList.DataSource = data;
            this.sigList.SetCategoryList(BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory());
            this.sigList.SetEqualWeight(this.isEqualWeight);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage)
        {
            errorMessage = "";
            this.sigList.CloseEditor();

            // check input data
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
                    errorMessage = "仓库编号不能为空";
                    return ErrorCode.Error;
                }
            }

            // add cargo and set item field
            foreach (StockInModel item in this.sigList.DataSource)
            {
                item.ContractId = this.stockIn.ContractId;
                item.GroupType = this.stockIn.Contract.BillingType;
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
            StockIn si = this.stockIn;
            si.Remark = this.txtRemark.Text;

            // set billing
            Billing billing = si.Billing;
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
            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Edit(si, billing, this.sigList.DataSource);

            return result;
        }
        #endregion //Method

        #region Event
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
        /// 单元格更改事件
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
