using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 添加客户窗体
    /// </summary>
    public partial class CustomerAddForm : BaseSingleForm
    {
        #region Constructor
        public CustomerAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
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
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerAddForm_Load(object sender, EventArgs e)
        {
            this.cmbType.Properties.Items.AddEnum(typeof(CustomerType));
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim() == "")
            {
                MessageBox.Show("姓名不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtNumber.Text.Trim() == "")
            {
                MessageBox.Show("代码不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("地址不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("客户类型不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer customer = new Customer();
            SetEntity(customer);

            ErrorCode result = BusinessFactory<CustomerBusiness>.Instance.Create(customer);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加客户成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加客户失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
