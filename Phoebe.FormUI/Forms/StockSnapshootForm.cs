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
    /// 库存快照窗体
    /// </summary>
    public partial class StockSnapshootForm : Form
    {
        #region Field
        private StoreBusiness storeBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CargoBusiness cargoBusiness;
        #endregion //Field

        #region Constructor
        public StockSnapshootForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.storeBusiness = new StoreBusiness();
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
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockSnapshootForm_Load(object sender, EventArgs e)
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

                var storage = this.storeBusiness.GetInDay(contract.ID, this.datePicker.Value.Date);
                this.storageBindingSource.DataSource = storage;

                var flow = this.storeBusiness.GetDaysFlow(contract.ID, this.datePicker.Value.Date);
                this.stockFlowBindingSource.DataSource = flow;
            }
            else
            {
                if (this.comboBoxCargo.SelectedIndex == -1 || this.comboBoxCargo.SelectedIndex == 0)
                {
                    MessageBox.Show("未选择货品", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var cargo = this.comboBoxCargo.SelectedItem as Cargo;

                var storage = this.storeBusiness.GetInDay(cargo.ID, this.datePicker.Value.Date);
                this.storageBindingSource.DataSource = storage;

                var flow = this.storeBusiness.GetDaysFlow(cargo.ID, this.datePicker.Value.Date);
                this.stockFlowBindingSource.DataSource = flow;
            }
        }

        private void storageDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.storageBindingSource.Count)
            {
                var storage = this.storageBindingSource[e.RowIndex] as Storage;

                if (storage.Source == 0)
                {
                    this.storageDataGridView.Rows[e.RowIndex].Cells[this.columnSource.Index].Value = "入库";
                }
                else if (storage.Source == 1)
                {
                    this.storageDataGridView.Rows[e.RowIndex].Cells[this.columnSource.Index].Value = "移库";
                }
            }
        }       

        private void stockFlowDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.stockFlowBindingSource.Count)
            {
                var flow = this.stockFlowBindingSource[e.RowIndex] as StockFlow;

                this.stockFlowDataGridView.Rows[e.RowIndex].Cells[this.columnFlowType.Index].Value = flow.Type.DisplayName(); 
            }
        }
        #endregion //Event
    }
}
