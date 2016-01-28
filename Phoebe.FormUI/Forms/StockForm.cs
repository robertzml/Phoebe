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
    public partial class StockForm : Form
    {
        #region Field
        private StoreBusiness storeBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;
        #endregion //Field

        #region Constructor
        public StockForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitControl()
        {
            var customers = this.customerBusiness.Get();
            customers.Insert(0, new Customer { ID = 0, Name = "--请选择--" });
            this.comboBoxCustomer.DataSource = customers;
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }

        private void InitData()
        {
            this.storeBusiness = new StoreBusiness();
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
        }
        #endregion //Function

        #region Event
        private void StockForm_Load(object sender, EventArgs e)
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
            if (this.comboBoxCustomer.SelectedIndex == -1 || this.comboBoxCustomer.SelectedIndex == 0)
            {
                this.comboBoxContract.DataSource = null;
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
            List<Stock> data;
            int customerID = Convert.ToInt32(this.comboBoxCustomer.SelectedValue);

            if (customerID == -1 || customerID == 0)
            {
                data = this.storeBusiness.GetStock();
            }
            else
            {
                int contractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
                if (contractID == -1 || contractID == 0)
                    data = this.storeBusiness.GetByCustomer(customerID);
                else
                    data = this.storeBusiness.GetByContract(contractID);
            }

            if (this.checkBoxStoreIn.Checked == false)
            {
                data = data.Where(r => r.Status != (int)EntityStatus.StoreIn).ToList();
            }

            if (this.checkBoxStoreOut.Checked == false)
            {
                data = data.Where(r => r.Status != (int)EntityStatus.StoreOut).ToList();
            }

            this.stockBindingSource.DataSource = data;
        }

        private void stockDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.stockBindingSource.Count)
            {
                var stock = this.stockBindingSource[e.RowIndex] as Stock;
                var grid = this.stockDataGridView;

                if (stock.Warehouse != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnWarehouse.Index].Value = stock.Warehouse.Number;
                }

                if (stock.Cargo != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnCargo.Index].Value = stock.Cargo.Name;
                }

                if (stock.Cargo != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnContract.Index].Value = stock.Cargo.Contract.Name;
                }

                if (stock.Source == 0)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnSource.Index].Value = "入库";
                }
                else
                {
                    grid.Rows[e.RowIndex].Cells[this.columnSource.Index].Value = "移库";
                }

                grid.Rows[e.RowIndex].Cells[this.columnStatus.Index].Value = ((EntityStatus)stock.Status).DisplayName();
            }
        }
        #endregion //Event
    }
}
