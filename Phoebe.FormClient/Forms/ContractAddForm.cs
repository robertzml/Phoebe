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
        #endregion //Field

        #region Constructor
        public ContractAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 设置对象
        /// </summary>
        /// <param name="contract">合同</param>
        private void SetEntity(Contract contract)
        {
            contract.Number = this.txtNumber.Text.Trim();
            contract.Name = this.txtName.Text.Trim();
            contract.CustomerId = Convert.ToInt32(this.lkuCustomer.EditValue);
            contract.SignDate = this.txtSignDate.DateTime.Date;
            contract.Type = (int)this.cmbType.EditValue;
            contract.BillingType = (int)this.cmbBillingType.EditValue;
            contract.Parameter1 = this.txtParameter1.Text == "" ? null : this.txtParameter1.Text;
            contract.Parameter2 = this.txtParameter2.Text == "" ? null : this.txtParameter2.Text;
            contract.Parameter3 = this.txtParameter3.Text == "" ? null : this.txtParameter3.Text;
            contract.UserId = this.currentUser.Id;
            contract.Remark = this.txtRemark.Text;
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
            if (this.lkuCustomer.EditValue == null)
            {
                message = "请选择客户";
                return false;
            }
            if (this.txtSignDate.EditValue == null)
            {
                message = "请选择签订日期";
                return false;
            }
            if (this.cmbType.EditValue == null)
            {
                message = "请选择合同类型";
                return false;
            }
            if (this.cmbBillingType.EditValue == null)
            {
                message = "请选择计费方式";
                return false;
            }

            switch ((ContractType)this.cmbType.EditValue)
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
        private void ContractAddForm_Load(object sender, EventArgs e)
        {
            this.txtSignDate.EditValue = DateTime.Now;
            this.cmbType.Properties.Items.AddEnum(typeof(ContractType));
            this.cmbBillingType.Properties.Items.AddEnum(typeof(BillingType));

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
        }

        /// <summary>
        /// 合同类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ContractType)this.cmbType.EditValue) == ContractType.MinDuration)
            {
                this.lblParameter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                this.lblParameter1.Text = "最短天数";
            }
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

            Contract contract = new Contract();
            SetEntity(contract);

            ErrorCode result = BusinessFactory<ContractBusiness>.Instance.Create(contract);
            if (result == ErrorCode.Success)
            {
                MessageUtil.ShowInfo("添加合同成功");
                this.Close();
            }
            else
            {
                MessageUtil.ShowWarning("添加合同失败：" + result.DisplayName());
            }
        }
        #endregion //Event
    }
}
