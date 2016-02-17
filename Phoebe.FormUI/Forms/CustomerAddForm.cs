using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.FormUI
{
    /// <summary>
    /// 客户添加窗体
    /// </summary>
    public partial class CustomerAddForm : Form
    {
        #region Field
        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public CustomerAddForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitControls()
        {
            this.comboBoxType.SelectedIndex = 0;
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
            this.customerBusiness = new CustomerBusiness();

            InitControls();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("姓名不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.textBoxAddress.Text.Trim() == "")
            {
                MessageBox.Show("地址不能为空", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer customer = new Customer();
            customer.Name = this.textBoxName.Text.Trim();
            customer.Number = this.textBoxNumber.Text.Trim();
            customer.Address = this.textBoxAddress.Text.Trim();
            customer.Telephone = this.textBoxTelephone.Text.Trim();
            customer.Contact = this.textBoxContact.Text;
            customer.ContactTelephone = this.textBoxContactTelephone.Text;
            customer.Type = this.comboBoxType.SelectedIndex + 1;
            customer.Remark = this.textBoxRemark.Text;

            ErrorCode result = this.customerBusiness.Create(customer);
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
