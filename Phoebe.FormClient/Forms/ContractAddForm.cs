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
            this.txtSignDate.EditValue = DateTime.Now;
            this.cmbBillingType.Properties.Items.AddEnum(typeof(BillingType));

            this.bsCustomer.DataSource = BusinessFactory<CustomerBusiness>.Instance.FindAll();
            this.lkuCustomer.CustomDisplayText += new DevExpress.XtraEditors.Controls.CustomDisplayTextEventHandler(EventUtil.LkuCustomer_CustomDisplayText);
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
            if (this.lkuCustomer.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }
            if (this.txtSignDate.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择签订日期");
                return;
            }
            if (this.cmbBillingType.EditValue == null)
            {
                MessageUtil.ShowClaim("请选择计费方式");
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
