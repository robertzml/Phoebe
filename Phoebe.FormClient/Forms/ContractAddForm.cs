using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 合同添加窗体
    /// </summary>
    public partial class ContractAddForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 客户列表
        /// </summary>
        private List<Customer> customerList;

        /// <summary>
        /// 选中客户Id
        /// </summary>
        private int customerId;
        #endregion //Field

        #region Constructor
        public ContractAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void SetEntity(Contract contract)
        {
            contract.Number = this.txtNumber.Text.Trim();
            contract.Name = this.txtName.Text.Trim();
            contract.CustomerId = this.customerId;
            contract.SignDate = this.txtSignDate.DateTime.Date;
            contract.BillingType = (int)this.cmbBillingType.EditValue;
            contract.IsTiming = this.ckbIsTiming.Checked;
            contract.UserId = this.currentUser.Id;
            contract.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractAddForm_Load(object sender, EventArgs e)
        {
            this.customerList = BusinessFactory<CustomerBusiness>.Instance.FindAll();

            this.txtSignDate.EditValue = DateTime.Now;
            this.cmbBillingType.Properties.Items.AddEnum(typeof(BillingType));

            this.clcCustomer.SetDataSource(this.customerList);
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
                this.txtCustomerName.Text = customer.Name;
                this.customerId = customer.Id;
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

            this.customerId = this.clcCustomer.SelectedId;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtNumber.Text.Trim() == "" || this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("合同编号名称不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txtCustomerNumber.Text == "")
            {
                MessageBox.Show("客户代码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.txtSignDate.EditValue == null)
            {
                MessageBox.Show("请选择签订日期", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cmbBillingType.EditValue == null)
            {
                MessageBox.Show("请选择计费方式", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contract contract = new Contract();
            SetEntity(contract);

            ErrorCode result = BusinessFactory<ContractBusiness>.Instance.Create(contract);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加合同成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加合同失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
