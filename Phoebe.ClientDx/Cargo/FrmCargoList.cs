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
    using Poseidon.Winform.Base;
    using Phoebe.Base;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using DevExpress.XtraEditors.Controls;

    /// <summary>
    /// 货品列表窗体
    /// </summary>
    public partial class FrmCargoList : BaseMdiForm
    {
        #region Constructor
        public FrmCargoList()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        protected override void InitForm()
        {
            this.customerLookup.Init();
            base.InitForm();
        }

        /// <summary>
        /// 更新合同选择
        /// </summary>
        /// <param name="customerId">客户Id</param>
        private void UpdateContractList(int customerId)
        {
            var contracts = BusinessFactory<ContractBusiness>.Instance.GetColdByCustomer(customerId);

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
            int customerId = this.customerLookup.GetSelectedId();

            if (customerId == 0)
            {
                MessageUtil.ShowClaim("请选择客户");
                return;
            }

            var data = BusinessFactory<CargoBusiness>.Instance.GetByCustomer(customerId);

            if (this.cmbContract.EditValue != null && (int)this.cmbContract.EditValue != 0)
            {
                data = data.Where(r => r.ContractId == (int)this.cmbContract.EditValue).ToList();
            }

            this.cargoGrid.DataSource = data.ToList();
        }
        #endregion //Event
    }
}
