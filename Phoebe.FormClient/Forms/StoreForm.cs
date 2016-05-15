using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
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
        /// 客户列表
        /// </summary>
        //private List<Customer> customerList;

        /// <summary>
        /// 分类列表
        /// </summary>
        private List<Category> categoryList;

        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;
        #endregion //Field

        #region Constructor
        public StoreForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
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

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StoreForm_Load(object sender, EventArgs e)
        {
            this.selectCustomer = null;

            var customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);

            this.categoryList = BusinessFactory<CategoryBusiness>.Instance.FindAll();

         
            UpdateCategoryView("");
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

                //UpdateContractList(customer.Id);
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
            this.selectCustomer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Store> data = new List<Store>();
            if (this.selectCustomer != null)
            {
                data = BusinessFactory<StoreBusiness>.Instance.GetByCustomer(this.selectCustomer.Id);
            }
            else
            {
                data = BusinessFactory<StoreBusiness>.Instance.FindAll();
            }
            this.bsStore.DataSource = data;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStore_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return;

            var store = this.bsStore[rowIndex] as Store;

            if (e.Column.FieldName == "Source")
            {
                if (store.Source == 0)
                    e.DisplayText = "入库";
                else
                    e.DisplayText = "移库";
            }
            else if (e.Column.FieldName == "Destination")
            {
                if (store.Destination != null)
                {
                    if (store.Destination.Value == 0)
                        e.DisplayText = "出库";
                    else
                        e.DisplayText = "移库";
                }
            }
            else if (e.Column.FieldName == "UserId")
            {
                e.DisplayText = store.User.Name;
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStore_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsStore.Count)
                return;

            var store = this.bsStore[rowIndex] as Store;

            if (e.Column.FieldName == "colCustomerName" && e.IsGetData)
                e.Value = store.Cargo.Contract.Customer.Name;
            if (e.Column.FieldName == "colCategoryNumber" && e.IsGetData)
                e.Value = store.Cargo.Category.Number;
            if (e.Column.FieldName == "colCategoryName" && e.IsGetData)
                e.Value = store.Cargo.Category.Name;
        }
        #endregion //Event

    }
}
