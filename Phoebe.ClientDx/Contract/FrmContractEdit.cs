using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Winform.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 编辑合同窗体
    /// </summary>
    public partial class FrmContractEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 关联合同
        /// </summary>
        private Contract currentContract;
        #endregion //Field

        #region Constructor
        public FrmContractEdit(int contractId)
        {
            InitializeComponent();
            InitData(contractId);
        }
        #endregion //Constructor

        #region Function
        private void InitData(int contractId)
        {
            this.currentContract = BusinessFactory<ContractBusiness>.Instance.FindById(contractId);
        }

        protected override void InitForm()
        {
            var customer = BusinessFactory<CustomerBusiness>.Instance.FindById(currentContract.CustomerId);

            this.txtNumber.Text = currentContract.Number;
            this.txtName.Text = currentContract.Name;
            this.txtCustomerNumber.Text = customer.Number;
            this.txtCustomerName.Text = customer.Name;
            this.dpSignDate.DateTime = currentContract.SignDate.Date;
            this.txtType.Text = ((ContractType)currentContract.Type).DisplayName();
            this.txtBillingType.Text = ((BillingType)currentContract.BillingType).DisplayName();
            this.txtRemark.Text = currentContract.Remark;

            switch ((ContractType)currentContract.Type)
            {
                case ContractType.MinDuration:
                    this.lblParameter1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    this.lblParameter1.Text = "最短天数";
                    this.txtParameter1.Text = currentContract.Parameter1;
                    break;
            }

            base.InitForm();
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (this.txtName.Text.Trim() == "")
            {
                errorMessage = "合同名称不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtNumber.Text.Trim() == "")
            {
                errorMessage = "合同编号不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.dpSignDate.EditValue == null)
            {
                errorMessage = "请选择签订日期";
                return new Tuple<bool, string>(false, errorMessage);
            }

            switch ((ContractType)currentContract.Type)
            {
                case ContractType.MinDuration:
                    if (this.txtParameter1.Text.Trim() == "")
                    {
                        errorMessage = "请输入最小天数";
                        return new Tuple<bool, string>(false, errorMessage);
                    }

                    int temp;
                    if (!Int32.TryParse(this.txtParameter1.Text, out temp))
                    {
                        errorMessage = "请输入整数";
                        return new Tuple<bool, string>(false, errorMessage);
                    }
                    break;
            }

            return new Tuple<bool, string>(true, "");
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
        #endregion //Function

        #region Event
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var input = CheckInput();
            if (!input.Item1)
            {
                MessageUtil.ShowError(input.Item2);
                return;
            }

            try
            {
                Contract entity = BusinessFactory<ContractBusiness>.Instance.FindById(currentContract.Id);
                SetEntity(entity);

                BusinessFactory<ContractBusiness>.Instance.Update(entity);

                MessageUtil.ShowInfo("编辑合同成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("编辑合同失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
