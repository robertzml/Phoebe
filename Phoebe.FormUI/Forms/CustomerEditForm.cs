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
    public partial class CustomerEditForm : Form
    {
        #region Field
        private CustomerBusiness customerBusiness;

        private int currentCustomerID;
        #endregion //Field

        #region Constructor
        public CustomerEditForm(int customerID)
        {
            InitializeComponent();
            this.currentCustomerID = customerID;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
        }

        private void InitControl()
        {
            var customer = this.customerBusiness.Get(this.currentCustomerID);

            this.textBoxName.Text = customer.Name;
            this.textBoxAddress.Text = customer.Address;
            this.textBoxTelephone.Text = customer.Telephone;
            this.textBoxContact.Text = customer.Contact;
            this.textBoxContactTelephone.Text = customer.ContactTelephone;
            this.comboBoxType.SelectedIndex = customer.Type - 1;
            this.textBoxRemark.Text = customer.Remark;
        }
        #endregion //Function

        #region Event
        private void CustomerEditForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

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

            Customer customer = this.customerBusiness.Get(this.currentCustomerID);
            customer.Name = this.textBoxName.Text.Trim();
            customer.Address = this.textBoxAddress.Text.Trim();
            customer.Telephone = this.textBoxTelephone.Text.Trim();
            customer.Contact = this.textBoxContact.Text;
            customer.ContactTelephone = this.textBoxContactTelephone.Text;
            customer.Type = this.comboBoxType.SelectedIndex + 1;
            customer.Remark = this.textBoxRemark.Text;

            ErrorCode result = this.customerBusiness.Edit(customer);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("编辑客户成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("编辑客户失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
