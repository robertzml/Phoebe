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
            this.txtType.Text = ((ContractType)contract.Type).DisplayName();
            this.txtBillingType.Text = ((BillingType)contract.BillingType).DisplayName();
            this.txtRemark.Text = contract.Remark;

            switch ((ContractType)contract.Type)
            {
                case ContractType.MinDuration:
                    this.lblParameter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    this.lblParameter1.Text = "最短天数";
                    this.txtParameter1.Text = contract.Parameter1;
                    break;
            }
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
            contract.Remark = this.txtRemark.Text;
            contract.Parameter1 = this.txtParameter1.Text == "" ? null : this.txtParameter1.Text;
            contract.Parameter2 = this.txtParameter2.Text == "" ? null : this.txtParameter2.Text;
            contract.Parameter3 = this.txtParameter3.Text == "" ? null : this.txtParameter3.Text;
        }

        /// <summary>
        /// 检查输入
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool CheckInput(out string message)
        {
            message = "";
            if (this.txtNumber.Text.Trim() == "" || this.txtName.Text.Trim() == "")
            {
                message = "合同编号名称不能为空";
                return false;
            }
            if (this.dpSignDate.EditValue == null)
            {
                message = "请选择签订日期";
                return false;
            }

            switch ((ContractType)this.bindContract.Type)
            {
                case ContractType.MinDuration:
                    if (this.txtParameter1.Text.Trim() == "")
                    {
                        message = "请输入最小天数";
                        return false;
                    }

                    int temp;
                    if (!Int32.TryParse(this.txtParameter1.Text, out temp))
                    {
                        message = "请输入整数";
                        return false;
                    }
                    break;
            }

            return true;
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
            string message;
            if (!CheckInput(out message))
            {
                MessageUtil.ShowClaim(message);
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
