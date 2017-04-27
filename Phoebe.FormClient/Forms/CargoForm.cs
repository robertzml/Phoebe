using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraEditors.Controls;
    using Phoebe.Base;
    using Phoebe.Business;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 货品列表窗体
    /// </summary>
    public partial class CargoForm : BaseForm
    {
        #region Field
        #endregion //Field

        #region Constructor
        public CargoForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetByCustomer2(customerId);

            this.cmbContract.Properties.Items.Clear();

            ImageComboBoxItem empty = new ImageComboBoxItem();
            empty.Description = "--全部合同--";
            empty.Value = 0;
            this.cmbContract.Properties.Items.Add(empty);

            foreach (var item in contracts)
            {
                ImageComboBoxItem i = new ImageComboBoxItem();
                i.Description = item.Name;
                i.Value = item.Id;

                this.cmbContract.Properties.Items.Add(i);
            }

            this.cmbContract.EditValue = 0;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargoForm_Load(object sender, EventArgs e)
        {
            this.customerLookup.Init();
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerLookup_CustomerSelect(object sender, EventArgs e)
        {
            int id = this.customerLookup.GetSelectedId();
            if (id == 0)
                UpdateContractList(0);
            else
                UpdateContractList(id);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.customerLookup.GetSelectedId() == 0)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            int customerId = this.customerLookup.GetSelectedId();
            var data = BusinessFactory<CargoBusiness>.Instance.GetByCustomer(customerId);

            if (this.cmbContract.EditValue != null && (int)this.cmbContract.EditValue != 0)
            {
                data = data.Where(r => r.ContractId == (int)this.cmbContract.EditValue).ToList();
            }

            this.cgList.DataSource = data;
        }
        #endregion //Event
    }
}
