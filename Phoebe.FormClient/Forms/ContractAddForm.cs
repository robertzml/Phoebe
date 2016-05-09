using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;
    using DevExpress.XtraEditors.Controls;

    /// <summary>
    /// 合同添加窗体
    /// </summary>
    public partial class ContractAddForm : BaseSingleForm
    {
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
            contract.CustomerId = 1;
            contract.SignDate = this.txtSignDate.DateTime.Date;
            contract.BillingType = (int)this.cmbBillingType.EditValue;
            contract.IsTiming = this.ckbIsTiming.Checked;
            contract.UserId = this.currentUser.Id;
            contract.Remark = this.txtRemark.Text;
        }

        private void LoadCustomers()
        {
            var customers = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            foreach(var item in customers)
            {
                
            }
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
            this.cmbBillingType.Properties.Items.AddEnum(typeof(BillingType));
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
