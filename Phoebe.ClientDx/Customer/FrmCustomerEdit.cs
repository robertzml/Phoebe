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
    /// 编辑客户窗体
    /// </summary>
    public partial class FrmCustomerEdit : BaseSingleForm
    {
        #region Field
        /// <summary>
        /// 关联客户
        /// </summary>
        private Customer currentCustomer;
        #endregion //Field

        #region Constructor
        public FrmCustomerEdit(int customerId)
        {
            InitData(customerId);
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData(int customerId)
        {
            this.currentCustomer = BusinessFactory<CustomerBusiness>.Instance.FindById(customerId);
        }

        protected override void InitForm()
        {
            this.cmbType.Properties.Items.AddEnum(typeof(CustomerType));

            this.txtName.Text = currentCustomer.Name;
            this.txtNumber.Text = currentCustomer.Number;
            this.txtAddress.Text = currentCustomer.Address;
            this.txtTelephone.Text = currentCustomer.Telephone;
            this.txtContact.Text = currentCustomer.Contact;
            this.txtContactTelephone.Text = currentCustomer.ContactTelephone;
            this.cmbType.EditValue = (CustomerType)currentCustomer.Type;
            this.txtRemark.Text = currentCustomer.Remark;

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
                Customer entity = BusinessFactory<CustomerBusiness>.Instance.FindById(this.currentCustomer.Id);
                SetEntity(entity);

                var result = BusinessFactory<CustomerBusiness>.Instance.Update(entity);

                if (result.success)
                {
                    MessageUtil.ShowInfo("编辑客户成功");
                    this.Close();
                }
                else
                {
                    MessageUtil.ShowClaim("编辑客户失败: " + result.errorMessage);
                }
            }
            catch (PoseidonException pe)
            {
                Logger.Instance.Exception("编辑客户失败", pe);
                MessageUtil.ShowError(string.Format("保存失败，错误消息:{0}", pe.Message));
            }
        }
        #endregion //Event
    }
}
