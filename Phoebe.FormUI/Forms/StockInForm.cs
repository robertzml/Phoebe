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
    public partial class StockInForm : Form
    {
        #region Field
        private User currentUser;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CategoryBusiness categoryBusiness;

        private WarehouseBusiness warehouseBusiness;

        private StoreBusiness storeBusiness;

        private StockIn currentStockIn;

        private List<Cargo> currentCargoes;
        #endregion //Field

        #region Constructor
        public StockInForm(User user)
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
            this.categoryBusiness = new CategoryBusiness();
            this.warehouseBusiness = new WarehouseBusiness();
            this.storeBusiness = new StoreBusiness();

            this.currentCargoes = new List<Cargo>();
        }

        private void InitControl()
        {
            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            DataGridViewComboBoxColumn fcColumn = this.dataGridViewColumnFirstCategoryID;
            fcColumn.DataSource = categoryBusiness.GetFirstCategory();
            fcColumn.DisplayMember = "Name";
            fcColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn scColumn = this.dataGridViewColumnSecondCategoryID;
            scColumn.DataSource = categoryBusiness.GetSecondEmpty();
            scColumn.DisplayMember = "Name";
            scColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn whColumn = this.dataGridViewColumnWarehouse;
            whColumn.DataSource = this.warehouseBusiness.Get();
            whColumn.DisplayMember = "Number";
            whColumn.ValueMember = "ID";
        }

        /// <summary>
        /// 绑定页面数据到模型
        /// </summary>
        private void ControlToModel()
        {
            this.currentStockIn.InTime = this.dateBusinessTime.Value.Date;
            this.currentStockIn.FlowNumber = this.textBoxFlowNumber.Text;
            this.currentStockIn.ContractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
            this.currentStockIn.UserID = this.currentUser.ID;
            this.currentStockIn.Remark = this.textBoxRemark.Text;            
        }

        /// <summary>
        /// 更新模型数据到页面
        /// </summary>
        private void ModelToControl()
        {
            this.textBoxStatus.Text = ((EntityStatus)this.currentStockIn.Status).DisplayName();
            this.dateBusinessTime.Value = this.currentStockIn.InTime;
            this.textBoxFlowNumber.Text = this.currentStockIn.FlowNumber.ToString();
            if (this.currentStockIn.ContractID == 0)
            {
                this.comboBoxCustomer.SelectedIndex = -1;
                this.comboBoxContract.SelectedIndex = -1;
                this.textBoxBillingType.Text = "";
            }
            else
            {
                this.comboBoxCustomer.SelectedValue = this.currentStockIn.Contract.CustomerID;
                this.comboBoxContract.SelectedValue = this.currentStockIn.ContractID;
            }

            this.textBoxUser.Text = this.currentStockIn.User.Name;
        }

        /// <summary>
        /// 保存新项
        /// </summary>
        /// <returns></returns>
        private ErrorCode SaveNewItem()
        {
            StockIn stockIn = new StockIn();
            stockIn.ID = Guid.NewGuid();
            stockIn.InTime = this.dateBusinessTime.Value.Date;
            stockIn.MonthTime = stockIn.InTime.Year + stockIn.InTime.Month.ToString().PadLeft(2, '0');
            stockIn.FlowNumber = this.textBoxFlowNumber.Text;
            stockIn.ContractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
            stockIn.IsLock = false;
            stockIn.UserID = this.currentUser.ID;
            stockIn.Remark = this.textBoxRemark.Text;
            stockIn.Status = (int)EntityStatus.StockInReady;

            Billing billing = new Billing();
            billing.StockInID = stockIn.ID;
            billing.UnitPrice = this.numericUnitPrice.Value;
            billing.HandlingPrice = this.numericHandlingPrice.Value;
            billing.FreezePrice = this.numericFreezePrice.Value;
            billing.DisposePrice = this.numericDisposePrice.Value;
            billing.PackingPrice = this.numericPackingPrice.Value;
            billing.RentPrice = this.numericRentPrice.Value;
            billing.OtherPrice = this.numericOtherPrice.Value;
            billing.Status = (int)EntityStatus.BillingUnsettle;

            List<Cargo> cargos = new List<Cargo>();
            List<StockInDetail> details = new List<StockInDetail>();

            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                var cargo = row.DataBoundItem as Cargo;
                cargo.ID = Guid.NewGuid();
                cargo.ContractID = stockIn.ContractID;
                cargo.StoreCount = cargo.Count;
                cargo.RegisterTime = stockIn.InTime;
                cargo.UserID = stockIn.UserID;
                cargo.Status = (int)EntityStatus.CargoStockInReady;
                cargos.Add(cargo);

                StockInDetail siDetail = new StockInDetail();
                siDetail.ID = Guid.NewGuid();
                siDetail.StockInID = stockIn.ID;
                siDetail.CargoID = cargo.ID;
                siDetail.WarehouseID = Convert.ToInt32(row.Cells[this.dataGridViewColumnWarehouse.Index].Value);
                siDetail.Count = cargo.Count;
                siDetail.Status = (int)EntityStatus.StockInReady;
                details.Add(siDetail);
            }

            return this.storeBusiness.StockIn(stockIn, details, billing, cargos);
        }
        #endregion //Function

        #region Event
        private void StockInForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
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
        }

        private void comboBoxContract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxContract.SelectedIndex != -1)
            {
                Contract contract = this.comboBoxContract.SelectedItem as Contract;
                this.textBoxBillingType.Text = ((BillingType)contract.BillingType).DisplayName();
            }
            else
            {
                this.textBoxBillingType.Text = "";
            }
        }

        /// <summary>
        /// 新建入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolNew_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = this.groupBox3.Visible = true;

            this.currentStockIn = new StockIn();
            this.currentStockIn.InTime = DateTime.Now.Date;
            this.currentStockIn.Status = (int)EntityStatus.StockInReady;
            this.currentStockIn.FlowNumber = "";
            this.currentStockIn.User = this.currentUser;

            ModelToControl();
        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            ErrorCode result = SaveNewItem();
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("保存成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cargoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string message = e.Exception.Message;
            MessageBox.Show(message);
        }

        /// <summary>
        /// 单元格更改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == this.dataGridViewColumnFirstCategoryID.Index)
            {
                int first = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnFirstCategoryID.Index].Value);

                DataGridViewComboBoxColumn scColumn = this.dataGridViewColumnSecondCategoryID;
                scColumn.DataSource = categoryBusiness.GetSecondCategoryByFirst(first);
                scColumn.DisplayMember = "Name";
                scColumn.ValueMember = "ID";
            }
            else if (e.ColumnIndex == this.dataGridViewColumnSecondCategoryID.Index)
            {
                int second = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnSecondCategoryID.Index].Value);

                DataGridViewComboBoxColumn tcColumn = this.dataGridViewColumnThirdCategoryID;
                tcColumn.DataSource = categoryBusiness.GetThirdCategoryBySecond(second);
                tcColumn.DisplayMember = "Name";
                tcColumn.ValueMember = "ID";
            }
            else if (e.ColumnIndex == this.dataGridViewColumnCount.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.Count < 0)
                    cargo.Count = 0;
                cargo.TotalWeight = Math.Round(cargo.UnitWeight * cargo.Count, 3);
            }
            else if (e.ColumnIndex == this.dataGridViewColumnUnitWeight.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.UnitWeight < 0)
                    cargo.UnitWeight = 0;
                cargo.TotalWeight = Math.Round(cargo.UnitWeight * cargo.Count / 1000, 3);
            }
            else if (e.ColumnIndex == this.dataGridViewColumnUnitVolume.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.UnitVolume < 0)
                    cargo.UnitVolume = 0;
                cargo.TotalVolume = Math.Round(cargo.UnitVolume * cargo.Count, 3);
            }
        }
        #endregion //Event
    }
}
