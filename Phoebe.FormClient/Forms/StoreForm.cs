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
    /// 库存记录窗体
    /// </summary>
    public partial class StoreForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;
        #endregion //Field

        #region Constructor
        public StoreForm()
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
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer2(customerId);

            this.cmbContract.Properties.Items.Clear();

            ImageComboBoxItem empty = new ImageComboBoxItem();
            empty.Description = "--全部合同--";
            empty.Value = 0;
            this.cmbContract.Properties.Items.Add(empty);

            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            this.cmbContract.EditValue = 0;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreForm_Load(object sender, EventArgs e)
        {
            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.FindAll();
            this.clcCategory.SetDataSource(categoryList);
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lkuCustomer_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lkuCustomer.EditValue == null)
                UpdateContractList(0);
            else
                UpdateContractList(Convert.ToInt32(this.lkuCustomer.EditValue));
        }

        /// <summary>
        /// 输入类别代码
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
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<Func<Store, bool>> filter = new List<Func<Store, bool>>();
            if (this.lkuCustomer.EditValue != null)
            {
                filter.Add(r => r.Cargo.Contract.CustomerId == Convert.ToInt32(this.lkuCustomer.EditValue));
            }

            var category = BusinessFactory<CategoryBusiness>.Instance.GetByParent(this.txtCategoryNumber.Text);
            if (category != null)
            {
                filter.Add(r => category.Select(s => s.Id).Contains(r.Cargo.CategoryId));
            }

            if (this.cmbContract.EditValue != null && Convert.ToInt32(this.cmbContract.EditValue) != 0)
            {
                filter.Add(r => r.Cargo.ContractId == Convert.ToInt32(this.cmbContract.EditValue));
            }

            if (!this.chkIn.Checked)
            {
                filter.Add(r => r.Status != (int)EntityStatus.StoreIn);
            }
            if (!this.chkOut.Checked)
            {
                filter.Add(r => r.Status != (int)EntityStatus.StoreOut);
            }
            if (!this.chkReady.Checked)
            {
                filter.Add(r => r.Status != (int)EntityStatus.StoreReady && r.Status != (int)EntityStatus.StoreMoveReady);
            }

            var data = BusinessFactory<StoreBusiness>.Instance.GetByConditions(filter);
            this.sgList.DataSource = data;

            this.Cursor = Cursors.Default;
        }
        #endregion //Event
    }
}
