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
    /// 添加客户窗体
    /// </summary>
    public partial class FrmCustomerAdd : BaseSingleForm
    {
        #region Constructor
        public FrmCustomerAdd()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.cmbType.Properties.Items.AddEnum(typeof(CustomerType));
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
                errorMessage = "姓名不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtNumber.Text.Trim() == "")
            {
                errorMessage = "代码不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.txtAddress.Text.Trim() == "")
            {
                errorMessage = "地址不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }
            if (this.cmbType.EditValue == null)
            {
                errorMessage = "客户类型不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="customer"></param>
        private void SetEntity(Customer customer)
        {
            customer.Name = this.txtName.Text.Trim();
            customer.Number = this.txtNumber.Text.Trim();
            customer.Address = this.txtAddress.Text.Trim();
            customer.Telephone = this.txtTelephone.Text.Trim();
            customer.Contact = this.txtContact.Text;
            customer.ContactTelephone = this.txtContactTelephone.Text;
            customer.Type = (int)this.cmbType.EditValue;
            customer.Remark = this.txtRemark.Text;
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
                Customer entity = new Customer();
                SetEntity(entity);

                BusinessFactory<CustomerBusiness>.Instance.Create(entity);

                MessageUtil.ShowInfo("添加客户成功");
                this.Close();
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("添加客户失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
