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
    /// 冷藏费清单窗体
    /// </summary>
    public partial class ColdPriceForm : Form
    {
        #region Field
        private SettleBusiness settleBusiness;

        private BillingBusiness billingBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CargoBusiness cargoBusiness;
        #endregion //Field

        #region Constructor
        public ColdPriceForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.settleBusiness = new SettleBusiness();
            this.billingBusiness = new BillingBusiness();
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
            this.cargoBusiness = new CargoBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }

        private void SetColumnHeader(BillingType type)
        {
            if (type == BillingType.UnitVolume)
            {
                this.columnUnitMeter.HeaderText = "单位体积(立方)";
                this.columnFlowMeter.HeaderText = "出入库体积(立方)";
                this.columnStoreMeter.HeaderText = "在库体积(立方)";
            }
            else
            {
                this.columnUnitMeter.HeaderText = "单位重量(kg)";
                this.columnFlowMeter.HeaderText = "出入库重量(t)";
                this.columnStoreMeter.HeaderText = "在库重量(t)";
            }
        }
        #endregion //Function

        #region Event
        private void ColdPriceForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            var customer = this.comboBoxCustomer.SelectedItem as Customer;

            var contracts = this.contractBusiness.GetByCustomer(customer.ID);
            contracts.Insert(0, new Contract { ID = 0, Name = "--请选择--" });

            this.comboBoxContract.DataSource = contracts;
            this.comboBoxContract.DisplayMember = "Name";
            this.comboBoxContract.ValueMember = "ID";

            this.comboBoxCargo.DataSource = null;
        }

        /// <summary>
        /// 合同选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxContract.SelectedIndex == -1 || this.comboBoxContract.SelectedIndex == 0)
                return;

            var contract = this.comboBoxContract.SelectedItem as Contract;
            var cargos = this.cargoBusiness.GetByContract(contract.ID).Where(r => r.Status != (int)EntityStatus.CargoNotIn).ToList();
            cargos.Insert(0, new Cargo { Name = "--请选择--" });

            this.comboBoxCargo.DataSource = cargos;
            this.comboBoxCargo.DisplayMember = "Name";
            this.comboBoxCargo.ValueMember = "ID";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            if (this.radioContract.Checked)
            {
                if (this.comboBoxContract.SelectedIndex == -1 || this.comboBoxContract.SelectedIndex == 0)
                {
                    MessageBox.Show("未选择合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var contract = this.comboBoxContract.SelectedItem as Contract;
                SetColumnHeader((BillingType)contract.BillingType);
                var records = this.billingBusiness.GetContractColdRecord(contract.ID, dateStart.Value.Date, dateEnd.Value.Date);
                this.dailyColdRecordBindingSource.DataSource = records;
            }
            else
            {
                if (this.comboBoxCargo.SelectedIndex == -1 || this.comboBoxCargo.SelectedIndex == 0)
                {
                    MessageBox.Show("未选择货品", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cargo = this.comboBoxCargo.SelectedItem as Cargo;
                SetColumnHeader((BillingType)cargo.Contract.BillingType);
                var records = this.billingBusiness.GetCargoColdRecord(cargo.ID, dateStart.Value.Date, dateEnd.Value.Date);
                this.dailyColdRecordBindingSource.DataSource = records;
            }
        }

        private void dailyColdRecordDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.dailyColdRecordBindingSource.Count)
            {
                var record = this.dailyColdRecordBindingSource[e.RowIndex] as DailyColdRecord;

                this.dailyColdRecordDataGridView.Rows[e.RowIndex].Cells[this.columnFlowType.Index].Value = record.FlowType.DisplayName();
            }
        }
        #endregion //Event
    }
}
