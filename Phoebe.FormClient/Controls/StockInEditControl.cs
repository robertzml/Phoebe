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
    /// 编辑入库界面
    /// </summary>
    public partial class StockInEditControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联入库单ID
        /// </summary>
        private Guid stockInId;

        /// <summary>
        /// 关联入库单
        /// </summary>
        private StockIn stockIn;

        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        public StockInEditControl(Guid stockInId)
        {
            InitializeComponent();
            this.stockInId = stockInId;
        }
        #endregion //Constructor

        #region Function
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

        private void SetDataControl(StockIn stockIn)
        {
            var data = ModelTranslate.StockInToModel(stockIn);
            this.bsStockIn.DataSource = data;
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
        /// 保存修改
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage)
        {
            errorMessage = "";
            this.dgvStockIn.CloseEditor();

            // check input data
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
            ErrorCode result = BusinessFactory<StockInBusiness>.Instance.Edit(si, billing, siModels);

            return result;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInEditControl_Load(object sender, EventArgs e)
        {
            this.stockIn = BusinessFactory<StockInBusiness>.Instance.FindById(this.stockInId);

            SetBaseControl(this.stockIn);
            SetBillingControl(this.stockIn.Billing);
            SetDataControl(this.stockIn);

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            if ((BillingType)this.stockIn.Contract.BillingType == BillingType.VariousWeight)
                this.isEqualWeight = false;
            else
                this.isEqualWeight = true;

            UpdateCategoryView("");
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
                UpdateCategoryView(number);

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
