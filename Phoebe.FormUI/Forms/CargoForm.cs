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
    public partial class CargoForm : Form
    {
        #region Field
        private CargoBusiness cargoBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;
        #endregion //Field

        #region Constructor
        public CargoForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.cargoBusiness = new CargoBusiness();
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomerType.SelectedIndex = 0;
        }
        #endregion //Function

        #region Event
        private void CargoForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void comboBoxCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomerType.SelectedIndex == -1)
            {
                this.comboBoxCustomer.Items.Clear();
                this.comboBoxContract.Items.Clear();
                return;
            }

            if (this.comboBoxCustomerType.SelectedIndex == 0)
            {
                this.comboBoxCustomer.DataSource = this.customerBusiness.GetByType(CustomerType.Group);
                this.comboBoxCustomer.DisplayMember = "Name";
                this.comboBoxCustomer.ValueMember = "ID";
            }
            else
            {
                this.comboBoxCustomer.DataSource = this.customerBusiness.GetByType(CustomerType.Scatter);
                this.comboBoxCustomer.DisplayMember = "Name";
                this.comboBoxCustomer.ValueMember = "ID";
            }
        }

        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
            {
                this.comboBoxContract.Items.Clear();
                return;
            }

            var contracts = this.contractBusiness.GetByCustomer(Convert.ToInt32(this.comboBoxCustomer.SelectedValue));
            contracts.Insert(0, new Contract { ID = 0, Name = "--请选择--" });

            this.comboBoxContract.DataSource = contracts;
            this.comboBoxContract.DisplayMember = "Name";
            this.comboBoxContract.ValueMember = "ID";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(this.comboBoxCustomer.SelectedValue);
            if (customerID == -1)
                return;

            int contractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
            if (contractID == -1 || contractID == 0)
                this.cargoBindingSource.DataSource = this.cargoBusiness.GetByCustomer(customerID);
            else
                this.cargoBindingSource.DataSource = this.cargoBusiness.GetByContract(contractID);
        }


        private void cargoDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.cargoBindingSource.Count)
            {
                var cargo = this.cargoBindingSource[e.RowIndex] as Cargo;
                var grid = this.cargoDataGridView;

                if (cargo.Contract != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnContract.Index].Value = cargo.Contract.Name;
                }

                if (cargo.FirstCategory != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnFirstCategory.Index].Value = cargo.FirstCategory.Name;
                }

                if (cargo.SecondCategory != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnSecondCategory.Index].Value = cargo.SecondCategory.Name;
                }

                if (cargo.ThirdCategory != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnThirdCategory.Index].Value = cargo.ThirdCategory.Name;
                }

                if (cargo.Warehouse != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnWarehouse.Index].Value = cargo.Warehouse.Number;
                }

                if (cargo.User != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnUserName.Index].Value = cargo.User.Name;
                }
            }
        }
        #endregion //Event

    }
}
