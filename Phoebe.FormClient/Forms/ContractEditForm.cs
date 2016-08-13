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
    /// 合同编辑窗体
    /// </summary>
    public partial class ContractEditForm : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 合同ID
        /// </summary>
        private int contractId;

        /// <summary>
        /// 关联合同
        /// </summary>
        private Contract bindContract;
        #endregion //Field

        #region Constructor
        public ContractEditForm(int contractId)
        {
            InitializeComponent();
            this.contractId = contractId;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="contract"></param>
        private void SetControl(Contract contract)
        {
            this.txtNumber.Text = contract.Number;
            this.txtName.Text = contract.Name;
            this.txtCustomerNumber.Text = contract.Customer.Number;
            this.txtCustomerName.Text = contract.Customer.Name;
            this.dpSignDate.DateTime = contract.SignDate.Date;
            this.cmbType.EditValue = (ContractType)contract.Type;
            this.txtBillingType.Text = ((BillingType)contract.BillingType).DisplayName();
            this.txtRemark.Text = contract.Remark;
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="contract"></param>
        private void SetEntity(Contract contract)
        {
            contract.Number = this.txtNumber.Text.Trim();
            contract.Name = this.txtName.Text.Trim();
            contract.SignDate = this.dpSignDate.DateTime.Date;
            contract.Type = (int)this.cmbType.EditValue;
            contract.Remark = this.txtRemark.Text;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractEditForm_Load(object sender, EventArgs e)
        {
            this.cmbType.Properties.Items.AddEnum(typeof(ContractType));
            this.bindContract = BusinessFactory<ContractBusiness>.Instance.FindById(this.contractId);
            SetControl(this.bindContract);
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
                MessageUtil.ShowClaim("合同编号名称不能为空");
                return;
            }
            if (this.txtCustomerNumber.Text == "")
            {
                MessageUtil.ShowClaim("客户代码不能为空");
                return;
            }
            if (this.dpSignDate.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择签订日期");
                return;
            }
            if (this.cmbType.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择合同类型");
                return;
            }

            SetEntity(this.bindContract);

            ErrorCode result = BusinessFactory<ContractBusiness>.Instance.Update(this.bindContract);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("编辑合同成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowWarning("编辑合同失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
