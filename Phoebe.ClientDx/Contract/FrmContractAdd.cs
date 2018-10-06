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
    /// 添加合同窗体
    /// </summary>
    public partial class FrmContractAdd : BaseSingleForm
    {
        #region Constructor
        public FrmContractAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.txtSignDate.EditValue = DateTime.Now;
            this.cmbType.Properties.Items.AddEnum(typeof(ContractType));
            this.cmbBillingType.Properties.Items.AddEnum(typeof(BillingType));

            this.customerLookup.Init();

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
            if (this.txtSignDate.EditValue == null)
            {
                errorMessage = "请选择签订日期";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.cmbType.EditValue == null)
            {
                errorMessage = "请选择合同类型";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.cmbBillingType.EditValue == null)
            {
                errorMessage = "请选择计费方式";
                return new Tuple<bool, string>(false, errorMessage);
            }

            switch ((ContractType)this.cmbType.EditValue)
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
        /// 设置对象
        /// </summary>
        /// <param name="contract">合同</param>
        private void SetEntity(Contract contract)
        {
            contract.Number = this.txtNumber.Text.Trim();
            contract.Name = this.txtName.Text.Trim();
            contract.CustomerId = this.customerLookup.GetSelectedId();
            contract.SignDate = this.txtSignDate.DateTime.Date;
            contract.Type = (int)this.cmbType.EditValue;
            contract.BillingType = (int)this.cmbBillingType.EditValue;
            contract.Parameter1 = this.txtParameter1.Text == "" ? null : this.txtParameter1.Text;
            contract.Parameter2 = this.txtParameter2.Text == "" ? null : this.txtParameter2.Text;
            contract.Parameter3 = this.txtParameter3.Text == "" ? null : this.txtParameter3.Text;
            contract.UserId = Convert.ToInt32(this.currentUser.Id);
            contract.Remark = this.txtRemark.Text;
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
                Contract entity = new Contract();
                SetEntity(entity);

                BusinessFactory<ContractBusiness>.Instance.Create(entity);

                MessageUtil.ShowInfo("添加合同成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("添加合同失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
