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
    public partial class ContractSignForm : Form
    {
        #region Field
        private User currentUser;

        private ContractBusiness contractBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public ContractSignForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.contractBusiness = new ContractBusiness();
            this.customerBusiness = new CustomerBusiness();
        }

        private void InitControl()
        {
            foreach(BillingType type in Enum.GetValues(typeof(BillingType)))
            {
                this.comboBoxBillingType.Items.Add(type.DisplayName());
            }
        }
        #endregion //Function

        #region Event
        private void ContractSignForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void comboBoxCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomerType.SelectedIndex == -1)
            {
                this.comboBoxCustomer.Items.Clear();
            }
            else
            {
                int type = this.comboBoxCustomerType.SelectedIndex + 1;
                this.comboBoxCustomer.DataSource = this.customerBusiness.GetByType((CustomerType)type);
                this.comboBoxCustomer.DisplayMember = "Name";
                this.comboBoxCustomer.ValueMember = "ID";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxNumber.Text.Trim() == "" || this.textBoxName.Text.Trim() == "")
            {
                MessageBox.Show("请输入信息", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.comboBoxCustomer.SelectedIndex == -1 || this.comboBoxBillingType.SelectedIndex == -1)
            {
                MessageBox.Show("请选择信息", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contract contract = new Contract();
            contract.Number = this.textBoxNumber.Text.Trim();
            contract.Name = this.textBoxName.Text.Trim();
            contract.CustomerID = Convert.ToInt32(this.comboBoxCustomer.SelectedValue);
            contract.SignDate = this.datePickerSign.Value.Date;
            contract.CertificateNumber = this.textBoxCertificateNumber.Text;
            contract.BillingType = this.comboBoxBillingType.SelectedIndex + 1;
            contract.IsTiming = this.radioTimeYes.Checked;
            contract.UserID = this.currentUser.ID;
            contract.Remark = this.textBoxRemark.Text;

            ErrorCode result = this.contractBusiness.Create(contract);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("添加合同成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("添加合同失败：" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion //Event
    }
}
