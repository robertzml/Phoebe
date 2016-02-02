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

        /// <summary>
        /// 当前入库
        /// </summary>
        private StockIn currentStockIn;

        /// <summary>
        /// 是否新增
        /// </summary>
        private bool isNew = false;
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
        }

        private void InitControl()
        {
            UpdateTree();

            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            DataGridViewComboBoxColumn fcColumn = this.dataGridViewColumnFirstCategoryID;
            fcColumn.DataSource = categoryBusiness.GetFirstCategory();
            fcColumn.DisplayMember = "Name";
            fcColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn scColumn = this.dataGridViewColumnSecondCategoryID;
            scColumn.DataSource = categoryBusiness.GetSecondCategory();
            scColumn.DisplayMember = "Name";
            scColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn tcColumn = this.dataGridViewColumnThirdCategoryID;
            tcColumn.DataSource = categoryBusiness.GetThirdCategory();
            tcColumn.DisplayMember = "Name";
            tcColumn.ValueMember = "ID";

            DataGridViewComboBoxColumn whColumn = this.dataGridViewColumnWarehouse;
            whColumn.DataSource = this.warehouseBusiness.Get();
            whColumn.DisplayMember = "Number";
            whColumn.ValueMember = "ID";
        }

        /// <summary>
        /// 初始化二级分类
        /// </summary>
        /// <param name="firstId"></param>
        private void InitSecondColumn(int firstId)
        {
            DataGridViewComboBoxColumn scColumn = this.dataGridViewColumnSecondCategoryID;
            scColumn.DataSource = categoryBusiness.GetSecondCategoryByFirst(firstId);
            scColumn.DisplayMember = "Name";
            scColumn.ValueMember = "ID";
        }

        /// <summary>
        ///  初始化三级分类
        /// </summary>
        /// <param name="secondId"></param>
        private void InitThirdColumn(int secondId)
        {
            DataGridViewComboBoxColumn tcColumn = this.dataGridViewColumnThirdCategoryID;
            tcColumn.DataSource = categoryBusiness.GetThirdCategoryBySecond(secondId);
            tcColumn.DisplayMember = "Name";
            tcColumn.ValueMember = "ID";
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
                this.textBoxBillingType.Text = ((BillingType)this.currentStockIn.Contract.BillingType).DisplayName();
            }

            this.textBoxUser.Text = this.currentStockIn.User.Name;
            this.textBoxRemark.Text = this.currentStockIn.Remark;

            this.numericUnitPrice.Value = this.currentStockIn.Billing.UnitPrice;
            this.numericHandlingPrice.Value = this.currentStockIn.Billing.HandlingPrice;
            this.numericFreezePrice.Value = this.currentStockIn.Billing.FreezePrice;
            this.numericDisposePrice.Value = this.currentStockIn.Billing.DisposePrice;
            this.numericRentPrice.Value = this.currentStockIn.Billing.RentPrice;
            this.numericOtherPrice.Value = this.currentStockIn.Billing.OtherPrice;

            List<Cargo> cargos = new List<Cargo>();
            foreach (var item in this.currentStockIn.StockInDetails)
            {
                cargos.Add(item.Cargo);
            }

            this.cargoBindingSource.DataSource = cargos;
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            this.treeViewReceipt.Nodes.Clear();

            var months = this.storeBusiness.GetStockInMonthGroup();
            for (int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.Nodes.Add("");
                this.treeViewReceipt.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 设置控件能否修改
        /// </summary>
        /// <param name="canEdit">能否修改</param>
        private void SetControlEditable(bool canEdit)
        {
            this.dateBusinessTime.Enabled = this.comboBoxCustomer.Enabled = this.comboBoxContract.Enabled =
                this.numericUnitPrice.Enabled = this.numericHandlingPrice.Enabled = this.numericFreezePrice.Enabled =
                this.numericDisposePrice.Enabled = this.numericPackingPrice.Enabled = this.numericRentPrice.Enabled =
                this.numericOtherPrice.Enabled = canEdit;
            this.textBoxRemark.ReadOnly = !canEdit;

            this.cargoBindingNavigator.Enabled = canEdit;
            foreach (DataGridViewColumn column in this.cargoDataGridView.Columns)
            {
                column.ReadOnly = !canEdit;
            }
            this.columnTotalWeight.ReadOnly = this.columnTotalVolume.ReadOnly = true;
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
                if (cargo.WarehouseID == null)
                {
                    return ErrorCode.WarehouseCannotBeEmpty;
                }

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
                siDetail.WarehouseID = cargo.WarehouseID.Value;
                siDetail.Count = cargo.Count;
                siDetail.Status = (int)EntityStatus.StockInReady;
                details.Add(siDetail);
            }

            ErrorCode result = this.storeBusiness.StockIn(stockIn, details, billing, cargos);
            if (result == ErrorCode.Success)
            {
                this.currentStockIn = this.storeBusiness.GetStockIn(stockIn.ID.ToString());
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
        private void StockInForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        private void treeViewReceipt_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = this.storeBusiness.GetStockInByMonth(e.Node.Name);
            e.Node.Nodes.Clear();
            foreach (var item in data)
            {
                TreeNode node = new TreeNode();
                node.Name = item.ID.ToString();
                node.Text = item.FlowNumber;
                node.Tag = item;
                e.Node.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 选择历史单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewReceipt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                return;

            this.groupBox2.Visible = this.groupBox3.Visible = true;

            this.currentStockIn = e.Node.Tag as StockIn;
            ModelToControl();
            this.isNew = false;
            if (this.currentStockIn.Status == (int)EntityStatus.StockInReady)
            {
                this.toolSave.Enabled = true;
                this.toolConfirm.Enabled = true;
                SetControlEditable(true);
            }
            else if (this.currentStockIn.Status == (int)EntityStatus.StockIn)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                SetControlEditable(false);
            }
        }

        /// <summary>
        /// 新建入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolNew_Click(object sender, EventArgs e)
        {
            this.isNew = true;
            this.currentStockIn = null;

            this.toolSave.Enabled = true;
            this.toolConfirm.Enabled = false;
            this.groupBox2.Visible = this.groupBox3.Visible = true;
            SetControlEditable(true);

            DateTime now = DateTime.Now.Date;
            this.dateBusinessTime.Value = now;
            this.textBoxFlowNumber.Text = this.storeBusiness.GetLastStockInFlowNumber(now);
            this.comboBoxCustomer.SelectedIndex = -1;
            this.comboBoxContract.SelectedIndex = -1;
            this.textBoxBillingType.Text = "";
            this.textBoxStatus.Text = EntityStatus.StockInReady.DisplayName();
            this.textBoxUser.Text = this.currentUser.Name;
            this.textBoxRemark.Text = "";

            this.numericUnitPrice.Value = 0;
            this.numericHandlingPrice.Value = 0;
            this.numericFreezePrice.Value = 0;
            this.numericDisposePrice.Value = 0;
            this.numericPackingPrice.Value = 0;
            this.numericRentPrice.Value = 0;
            this.numericOtherPrice.Value = 0;

            this.cargoBindingSource.DataSource = new List<Cargo>();
        }

        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            this.textBoxRemark.Focus(); //force datagrid complete change

            if (this.isNew)
            {
                ErrorCode result = SaveNewItem();
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.toolConfirm.Enabled = true;
                    this.storeBusiness = new StoreBusiness();
                }
                else
                {
                    MessageBox.Show("保存失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentStockIn == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.currentStockIn.Status != (int)EntityStatus.StockInReady)
            {
                MessageBox.Show("当前记录已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.storeBusiness.StockInConfirm(this.currentStockIn.ID);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("入库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxStatus.Text = EntityStatus.StockIn.DisplayName();
                this.toolConfirm.Enabled = false;
                SetControlEditable(false);
            }
            else
            {
                MessageBox.Show("入库确认失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolRefresh_Click(object sender, EventArgs e)
        {
            this.storeBusiness = new StoreBusiness();
            UpdateTree();
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 合同选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        private void cargoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //string message = e.Exception.Message;
            //MessageBox.Show(message);
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

                InitSecondColumn(first);
                this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnSecondCategoryID.Index].Value = 0;
                this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnThirdCategoryID.Index].Value = null;
            }
            else if (e.ColumnIndex == this.dataGridViewColumnSecondCategoryID.Index)
            {
                int second = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnSecondCategoryID.Index].Value);

                InitThirdColumn(second);
                this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnThirdCategoryID.Index].Value = null;
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

        private void cargoDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int first = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnFirstCategoryID.Index].Value);
            if (first > 0)
            {
                InitSecondColumn(first);
            }

            int second = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnSecondCategoryID.Index].Value);
            if (second > 0)
            {
                InitThirdColumn(second);
            }
        }
        #endregion //Event
    }
}
