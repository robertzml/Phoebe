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
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 出库编辑控件
    /// </summary>
    public partial class StockOutEditControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联出库单
        /// </summary>
        private StockOut stockOut;

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
        /// 出库编辑控件
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        public StockOutEditControl(Guid stockOutId)
        {
            InitializeComponent();

            this.stockOut = BusinessFactory<StockOutBusiness>.Instance.FindById(stockOutId);

            SetBaseControl(this.stockOut);
            SetDataControl(this.stockOut);

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            this.clcCategory.SetDataSource(this.categoryList);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基本信息
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        private void SetBaseControl(StockOut stockOut)
        {
            this.txtStatus.Text = ((EntityStatus)stockOut.Status).DisplayName();
            this.txtOutTime.Text = stockOut.OutTime.ToShortDateString();
            this.txtUser.Text = stockOut.User.Name;
            this.txtCustomerNumber.Text = stockOut.Contract.Customer.Number;
            this.txtCustomerName.Text = stockOut.Contract.Customer.Name;
            this.txtContract.Text = stockOut.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockOut.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockOut.Remark;
            this.txtFlowNumber.Text = stockOut.FlowNumber;
        }

        /// <summary>
        /// 设置出库数据信息
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        private void SetDataControl(StockOut stockOut)
        {
            var data = ModelTranslate.StockOutToModel(stockOut);
            this.sogList.DataSource = data;

            if ((BillingType)stockOut.Contract.BillingType == BillingType.VariousWeight)
                this.isEqualWeight = false;
            else
                this.isEqualWeight = true;

            this.sogList.SetEqualWeight(this.isEqualWeight);
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

            // check input data and format digit
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
                if (item.InTime > this.stockOut.OutTime.Date)
                {
                    errorMessage = "出库时间早于货品入库时间";
                    return ErrorCode.Error;
                }

                item.OutWeight = Math.Round(item.OutWeight, 4);
                item.OutVolume = Math.Round(item.OutVolume, 4);
            }

            // set stock out
            this.stockOut.Remark = this.txtRemark.Text;

            //edit stock out
            ErrorCode result = BusinessFactory<StockOutBusiness>.Instance.Edit(stockOut, this.sogList.DataSource);

            return result;
        }
        #endregion //Method

        #region Event
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
        /// 搜索库存记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var data = BusinessFactory<StoreBusiness>.Instance.GetByContract(this.stockOut.ContractId, true);
            var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
            if (category != null)
            {
                data = data.Where(r => category.Select(s => s.Id).Contains(r.Cargo.CategoryId)).ToList();
            }

            var details = ModelTranslate.StoreToStockOut(data);
            this.sogFilter.DataSource = details;
        }

        /// <summary>
        /// 加入出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTo_Click(object sender, EventArgs e)
        {
            var select = this.sogFilter.GetCurrentSelect();
            if (select == null)
            {
                MessageBox.Show("未选择货品", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (this.sogList.CheckHasStore(select))
                {
                    MessageBox.Show("该货品已经加入", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

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
