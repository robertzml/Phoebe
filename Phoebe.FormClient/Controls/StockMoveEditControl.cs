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
    /// 移库编辑控件
    /// </summary>
    public partial class StockMoveEditControl : UserControl
    {
        #region Field
        /// <summary>
        /// 关联移库单
        /// </summary>
        private StockMove stockMove;

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
        /// 移库编辑控件
        /// </summary>
        /// <param name="stockMoveId">移库单ID</param>
        public StockMoveEditControl(Guid stockMoveId)
        {
            InitializeComponent();

            this.stockMove = BusinessFactory<StockMoveBusiness>.Instance.FindById(stockMoveId);

            SetBaseControl(this.stockMove);
            SetDataControl(this.stockMove);

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.GetLeafCategory();
            this.clcCategory.SetDataSource(this.categoryList);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置基本信息
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        private void SetBaseControl(StockMove stockMove)
        {
            this.txtStatus.Text = ((EntityStatus)stockMove.Status).DisplayName();
            this.txtMoveTime.Text = stockMove.MoveTime.ToShortDateString();
            this.txtUser.Text = stockMove.User.Name;
            this.txtCustomerNumber.Text = stockMove.Contract.Customer.Number;
            this.txtCustomerName.Text = stockMove.Contract.Customer.Name;
            this.txtContract.Text = stockMove.Contract.Name;
            this.txtBillingType.Text = ((BillingType)stockMove.Contract.BillingType).DisplayName();
            this.txtRemark.Text = stockMove.Remark;
            this.txtFlowNumber.Text = stockMove.FlowNumber;
        }

        /// <summary>
        /// 设置移库数据信息
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        private void SetDataControl(StockMove stockMove)
        {
            var data = ModelTranslate.StockMoveToModel(stockMove);
            this.smgList.DataSource = data;

            if ((BillingType)stockMove.Contract.BillingType == BillingType.VariousWeight)
                this.isEqualWeight = false;
            else
                this.isEqualWeight = true;

            this.smgList.SetEqualWeight(this.isEqualWeight);
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        /// <returns></returns>
        public ErrorCode Save(out string errorMessage)
        {
            errorMessage = "";
            this.smgList.CloseEditor();

            // check input data and format digit
            if (this.smgList.DataSource.Count == 0)
            {
                errorMessage = "没有移库货品";
                return ErrorCode.Error;
            }

            foreach (var item in this.smgList.DataSource)
            {
                if (item.MoveCount < 0)
                {
                    errorMessage = "移库数量不能为负数";
                    return ErrorCode.Error;
                }
                if (item.MoveCount > item.StoreCount)
                {
                    errorMessage = "移库数量大于在库数量";
                    return ErrorCode.Error;
                }
                if (item.MoveTime > this.stockMove.MoveTime.Date)
                {
                    errorMessage = "移库时间早于货品移入时间";
                    return ErrorCode.Error;
                }
                if (string.IsNullOrEmpty(item.NewWarehouseNumber))
                {
                    errorMessage = "新仓位编号不能为空";
                    return ErrorCode.Error;
                }

                item.MoveWeight = Math.Round(item.MoveWeight, 4);
                item.MoveVolume = Math.Round(item.MoveVolume, 4);
            }

            // set stock move
            this.stockMove.Remark = this.txtRemark.Text;

            //edit stock move
            ErrorCode result = BusinessFactory<StockMoveBusiness>.Instance.Edit(stockMove, this.smgList.DataSource);

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
        /// 搜索库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var stores = BusinessFactory<StoreBusiness>.Instance.GetByContract(this.stockMove.ContractId, true);
            var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
            if (category != null)
            {
                stores = stores.Where(r => category.Select(s => s.Id).Contains(r.Cargo.CategoryId)).ToList();
            }

            var data = ModelTranslate.StoreToStockMove(stores);
            this.smgFilter.DataSource = data;
        }

        /// <summary>
        /// 加入移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTo_Click(object sender, EventArgs e)
        {
            var select = this.smgFilter.GetCurrentSelect();
            if (select == null)
            {
                MessageBox.Show("未选择记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (this.smgList.CheckHasStore(select))
                {
                    MessageBox.Show("该货品已经加入", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int count = Convert.ToInt32(this.nmMoveCount.Value);
                if (count > select.StoreCount)
                {
                    MessageBox.Show("移库数量大于在库数量", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                select.MoveCount = count;
                if (this.isEqualWeight)
                {
                    select.MoveWeight = count * select.UnitWeight / 1000;
                }
                select.MoveVolume = count * select.UnitVolume;
                select.NewWarehouseNumber = this.txtNewWarehouse.Text;

                this.smgList.DataSource.Add(select);
                this.smgList.UpdateBindingData();
            }
        }

        /// <summary>
        /// 删除移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFrom_Click(object sender, EventArgs e)
        {
            var select = this.smgList.GetCurrentSelect();
            if (select == null)
            {
                MessageBox.Show("未选择记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                this.smgList.DataSource.Remove(select);
                this.smgList.UpdateBindingData();
            }
        }
        #endregion //Event
    }
}
