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
    /// 货品列表窗体
    /// </summary>
    public partial class CargoForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 选中客户
        /// </summary>
        private Customer selectCustomer;

        /// <summary>
        /// 客户列表，缓存页面使用
        /// </summary>
        private List<Customer> customerList;
        #endregion //Field

        #region Constructor
        public CargoForm()
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
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer(customerId);

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
        private void CargoForm_Load(object sender, EventArgs e)
        {
            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.clcCustomer.SetDataSource(customerList);
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
                this.selectCustomer = customer;
                this.txtCustomerName.Text = customer.Name;
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
        /// 客户选择
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
            this.selectCustomer = this.customerList.SingleOrDefault(r => r.Id == customerId);
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCargo_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return;

            if (e.Column.FieldName == "ContractId")
            {
                var cargo = this.bsCargo[rowIndex] as Cargo;
                e.DisplayText = cargo.Contract.Name;
            }
            else if (e.Column.FieldName == "GroupType")
            {
                var cargo = this.bsCargo[rowIndex] as Cargo;
                e.DisplayText = ((BillingType)cargo.GroupType).DisplayName();
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCargo_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsCargo.Count)
                return;

            var cargo = this.bsCargo[rowIndex] as Cargo;

            if (e.Column.FieldName == "colCategoryNumber" && e.IsGetData)
                e.Value = cargo.Category.Number;
            if (e.Column.FieldName == "colCategoryName" && e.IsGetData)
                e.Value = cargo.Category.Name;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.selectCustomer == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            var data = BusinessFactory<CargoBusiness>.Instance.GetByCustomer(this.selectCustomer.Id);

            if (this.cmbContract.EditValue != null && (int)this.cmbContract.EditValue != 0)
            {
                data = data.Where(r => r.ContractId == (int)this.cmbContract.EditValue).ToList();
            }

            this.bsCargo.DataSource = data;
        }
        #endregion //Event
    }
}
