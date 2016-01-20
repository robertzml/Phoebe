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
    public partial class StockOutForm : Form
    {
        #region Field
        private User currentUser;

        private StockOut currentStockOut;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CargoBusiness cargoBusiness;

        private StoreBusiness storeBusiness;

        private bool isNew = false;
        #endregion //Field

        #region Constructor
        public StockOutForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
            this.cargoBusiness = new CargoBusiness();
            this.storeBusiness = new StoreBusiness();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
         
        }

        /// <summary>
        /// 保存新建项
        /// </summary>
        /// <returns></returns>
        private ErrorCode SaveNewItem()
        {
            StockOut stockOut = new StockOut();
            stockOut.ID = Guid.NewGuid();
            stockOut.OutTime = this.dateBusinessTime.Value.Date;
            stockOut.MonthTime = stockOut.OutTime.Year + stockOut.OutTime.Month.ToString().PadLeft(2, '0');
            stockOut.FlowNumber = this.textBoxFlowNumber.Text;
            stockOut.ContractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
            stockOut.IsLock = false;
            stockOut.UserID = this.currentUser.ID;
            stockOut.Remark = this.textBoxRemark.Text;
            stockOut.Status = (int)EntityStatus.StockOutReady;

            List<StockOutDetail> details = new List<StockOutDetail>();
            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                StockOutDetail soDetail = new StockOutDetail();
            }

            ErrorCode result = this.storeBusiness.StockOut(stockOut, details);
            if (result == ErrorCode.Success)
            {
                this.currentStockOut = this.storeBusiness.GetStockOut(stockOut.ID.ToString());
                this.isNew = false;
                return ErrorCode.Success;
            }
            else
            {
                return result;
            }
        }
        #endregion //Function

        #region Event
        private void StockOutForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void toolNew_Click(object sender, EventArgs e)
        {
            this.isNew = true;
            this.groupBox2.Visible = this.groupBox3.Visible = true;

            DateTime now = DateTime.Now.Date;
            this.dateBusinessTime.Value = now;
            this.textBoxFlowNumber.Text = this.storeBusiness.GetLastStockOutFlowNumber(now);
            this.comboBoxCustomer.SelectedIndex = -1;
            this.comboBoxContract.SelectedIndex = -1;
            this.textBoxStatus.Text = EntityStatus.StockOutReady.DisplayName();
            this.textBoxUser.Text = this.currentUser.Name;
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            if (this.isNew)
            {

            }
        }


        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex != -1)
            {
                Customer customer = this.comboBoxCustomer.SelectedItem as Customer;
                this.comboBoxContract.DataSource = this.contractBusiness.GetByCustomer(customer.ID);
                this.comboBoxContract.DisplayMember = "Name";
                this.comboBoxContract.ValueMember = "ID";
            }
            else
            {
                this.comboBoxContract.DataSource = null;
            }
        }


        private void comboBoxContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxContract.SelectedIndex != -1)
            {
                int contractId = Convert.ToInt32(this.comboBoxContract.SelectedValue);
                var data = this.cargoBusiness.GetByContract(contractId);
                this.cargoBindingSource.DataSource = data;
            }
        }


        private void cargoDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.cargoBindingSource.Count)
            {
                var cargo = this.cargoBindingSource[e.RowIndex] as Cargo;
                var grid = this.cargoDataGridView;

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
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnUser.Index].Value = cargo.User.Name;
                }

                grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnStatus.Index].Value = ((EntityStatus)cargo.Status).DisplayName();
            }
        }
        #endregion //Event
    }
}
