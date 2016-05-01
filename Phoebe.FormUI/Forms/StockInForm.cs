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
    /// 货品入库窗体
    /// </summary>
    public partial class StockInForm : Form
    {
        #region Field
        private User currentUser;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CategoryBusiness categoryBusiness;

        private StoreBusiness storeBusiness;

        /// <summary>
        /// 当前入库
        /// </summary>
        private StockIn currentStockIn;

        /// <summary>
        /// 是否新增
        /// </summary>
        private bool isNew = false;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;

        /// <summary>
        /// 货品代码列表
        /// </summary>
        private List<CategoryNumber> numberList;
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
            this.storeBusiness = new StoreBusiness();
        }

        private void InitControl()
        {
            UpdateTree();

            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            InitCategoryNumberList();
        }

        /// <summary>
        /// 初始化分类列表
        /// </summary>
        private void InitCategoryNumberList()
        {
            this.numberList = this.categoryBusiness.GetNumber();
            this.listBoxNumber.DataSource = numberList;
        }

        /// <summary>
        /// 更新分类列表
        /// </summary>
        /// <param name="number">输入代码</param>
        private void FilterCategoryNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
                this.listBoxNumber.DataSource = numberList;
            else
                this.listBoxNumber.DataSource = numberList.Where(r => r.Number.StartsWith(number)).ToList();
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

            for (int i = 0; i < cargos.Count; i++)
            {
                var number = cargos[i].Number;
                if (!string.IsNullOrEmpty(number))
                    this.cargoDataGridView.Rows[i].Cells[this.columnNumberName.Index].Value = this.categoryBusiness.TranslateNumber(number).GetName();
            }
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
                this.numericOtherPrice.Enabled = this.numericHandlingUnitPrice.Enabled =
                this.numericFreezeUnitPrice.Enabled = canEdit;
            this.textBoxRemark.ReadOnly = !canEdit;

            this.cargoBindingNavigator.Enabled = canEdit;
            foreach (DataGridViewColumn column in this.cargoDataGridView.Columns)
            {
                column.ReadOnly = !canEdit;
            }
            this.columnNumberName.ReadOnly = this.columnTotalWeight.ReadOnly = this.columnTotalVolume.ReadOnly = true;
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
            billing.ContractID = stockIn.ContractID;
            billing.UnitPrice = this.numericUnitPrice.Value;
            billing.HandlingPrice = this.numericHandlingPrice.Value;
            billing.FreezePrice = this.numericFreezePrice.Value;
            billing.DisposePrice = this.numericDisposePrice.Value;
            billing.PackingPrice = this.numericPackingPrice.Value;
            billing.RentPrice = this.numericRentPrice.Value;
            billing.OtherPrice = this.numericOtherPrice.Value;
            billing.InTime = stockIn.InTime;
            billing.Status = (int)EntityStatus.BillingNotInit;
            billing.TotalPrice = billing.HandlingPrice + billing.FreezePrice + billing.DisposePrice +
                billing.PackingPrice + billing.RentPrice + billing.OtherPrice;

            List<Cargo> cargos = new List<Cargo>();
            List<StockInDetail> details = new List<StockInDetail>();

            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                var cargo = row.DataBoundItem as Cargo;
                if (string.IsNullOrEmpty(cargo.WarehouseNumber))
                {
                    return ErrorCode.WarehouseCannotBeEmpty;
                }
                if (cargo.Name == "")
                {
                    return ErrorCode.EmptyName;
                }
                if (row.Cells[this.columnNumber.Index].Value == null)
                {
                    return ErrorCode.CargoNumberError;
                }

                CategoryNumber cnumber = this.categoryBusiness.TranslateNumber(row.Cells[this.columnNumber.Index].Value.ToString());
                if (cnumber == null)
                    return ErrorCode.CargoNumberError;

                cargo.ID = Guid.NewGuid();
                cargo.ContractID = stockIn.ContractID;
                cargo.FirstCategoryID = cnumber.FirstCategoryId;
                cargo.SecondCategoryID = cnumber.SecondCatgoryId;
                if (cnumber.Level == 3)
                    cargo.ThirdCategoryID = cnumber.ThirdCategoryId;
                cargo.EqualWeight = this.isEqualWeight;
                if (this.isEqualWeight)
                {
                    cargo.TotalWeight = Math.Round(cargo.Count * cargo.UnitWeight / 1000, 3);
                    cargo.TotalVolume = Math.Round(cargo.Count * cargo.UnitVolume);
                }
                cargo.StoreCount = cargo.Count;
                cargo.StoreWeight = cargo.TotalWeight;
                cargo.UnitPrice = billing.UnitPrice;
                cargo.RegisterTime = stockIn.InTime;
                cargo.UserID = stockIn.UserID;
                cargo.Status = (int)EntityStatus.CargoNotIn;
                cargos.Add(cargo);

                StockInDetail siDetail = new StockInDetail();
                siDetail.ID = Guid.NewGuid();
                siDetail.StockInID = stockIn.ID;
                siDetail.CargoID = cargo.ID;
                siDetail.WarehouseNumber = cargo.WarehouseNumber;
                siDetail.Count = cargo.Count;
                siDetail.InWeight = cargo.TotalWeight;
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

        /// <summary>
        /// 保存修改项
        /// </summary>
        /// <returns></returns>
        public ErrorCode SaveOldItem()
        {
            Billing billing = this.currentStockIn.Billing;
            billing.UnitPrice = this.numericUnitPrice.Value;
            billing.HandlingPrice = this.numericHandlingPrice.Value;
            billing.FreezePrice = this.numericFreezePrice.Value;
            billing.DisposePrice = this.numericDisposePrice.Value;
            billing.PackingPrice = this.numericPackingPrice.Value;
            billing.RentPrice = this.numericRentPrice.Value;
            billing.OtherPrice = this.numericOtherPrice.Value;

            billing.TotalPrice = billing.HandlingPrice + billing.FreezePrice + billing.DisposePrice +
                billing.PackingPrice + billing.RentPrice + billing.OtherPrice;

            List<Cargo> cargos = new List<Cargo>();
            List<StockInDetail> details = new List<StockInDetail>();

            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                var cargo = row.DataBoundItem as Cargo;
                if (string.IsNullOrEmpty(cargo.WarehouseNumber))
                {
                    return ErrorCode.WarehouseCannotBeEmpty;
                }
                if (cargo.Name == "")
                {
                    return ErrorCode.EmptyName;
                }
                if (row.Cells[this.columnNumber.Index].Value == null)
                {
                    return ErrorCode.CargoNumberError;
                }

                CategoryNumber cnumber = this.categoryBusiness.TranslateNumber(row.Cells[this.columnNumber.Index].Value.ToString());
                if (cnumber == null)
                    return ErrorCode.CargoNumberError;

                cargo.FirstCategoryID = cnumber.FirstCategoryId;
                cargo.SecondCategoryID = cnumber.SecondCatgoryId;
                if (cnumber.Level == 3)
                    cargo.ThirdCategoryID = cnumber.ThirdCategoryId;
                cargo.EqualWeight = this.isEqualWeight;
                if (this.isEqualWeight)
                {
                    cargo.TotalWeight = Math.Round(cargo.Count * cargo.UnitWeight / 1000, 3);
                    cargo.TotalVolume = Math.Round(cargo.Count * cargo.UnitVolume);
                }
                cargo.StoreCount = cargo.Count;
                cargo.StoreWeight = cargo.TotalWeight;
                cargos.Add(cargo);
            }

            ErrorCode result = this.storeBusiness.StockInUpdate(this.currentStockIn.ID, billing, cargos);
            return result;
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 树形菜单载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                this.toolDelete.Enabled = true;
                this.toolPrint.Enabled = false;
                this.toolUnlock.Enabled = false;
                this.toolLock.Enabled = false;
                this.toolEdit.Enabled = false;
                SetControlEditable(false);
            }
            else if (this.currentStockIn.Status == (int)EntityStatus.StockIn)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                this.toolDelete.Enabled = true;
                this.toolPrint.Enabled = true;
                this.toolUnlock.Enabled = true;
                this.toolLock.Enabled = false;
                this.toolEdit.Enabled = false;
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
            this.toolPrint.Enabled = false;
            this.toolLock.Enabled = false;
            this.toolUnlock.Enabled = false;
            this.toolEdit.Enabled = false;

            this.groupBox2.Visible = this.groupBox3.Visible = true;
            SetControlEditable(true);

            InitCategoryNumberList();

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
            this.numericHandlingUnitPrice.Value = 0;
            this.numericFreezeUnitPrice.Value = 0;

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

            if (this.comboBoxCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("未选择客户", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.comboBoxContract.SelectedIndex == -1)
            {
                MessageBox.Show("未选择合同", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.isNew)
            {
                ErrorCode result = SaveNewItem();
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.toolConfirm.Enabled = true;
                    this.toolSave.Enabled = false;
                    this.toolLock.Enabled = false;
                    this.toolUnlock.Enabled = false;
                    this.toolEdit.Enabled = false;
                    SetControlEditable(false);
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
                this.toolPrint.Enabled = true;
                this.toolLock.Enabled = false;
                this.toolUnlock.Enabled = true;
                this.toolEdit.Enabled = false;
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (this.currentStockIn == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = this.storeBusiness.StockInDelete(this.currentStockIn);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.currentStockIn = null;
                }
                else
                {
                    MessageBox.Show("删除失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (this.currentStockIn == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (this.currentStockIn.Status != (int)EntityStatus.StockIn)
            //{
            //    MessageBox.Show("入库记录未确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            StockInPrintForm form = new StockInPrintForm(this.currentStockIn);
            form.ShowDialog();
        }

        /// <summary>
        /// 锁定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolLock_Click(object sender, EventArgs e)
        {
            SetControlEditable(false);
            this.toolEdit.Enabled = false;
            this.toolLock.Enabled = false;
            this.toolUnlock.Enabled = true;
        }

        /// <summary>
        /// 解锁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolUnlock_Click(object sender, EventArgs e)
        {
            SetControlEditable(true);
            this.dateBusinessTime.Enabled = this.comboBoxCustomer.Enabled = this.comboBoxContract.Enabled = false;
            this.toolEdit.Enabled = true;
            this.toolLock.Enabled = true;
            this.toolUnlock.Enabled = false;
            this.cargoBindingNavigator.Enabled = false;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolEdit_Click(object sender, EventArgs e)
        {
            if (this.currentStockIn == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!this.storeBusiness.StockInUpdateCheck(this.currentStockIn.ID))
            {
                MessageBox.Show("当前入库记录无法修改", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = SaveOldItem();
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("修改成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.toolLock.Enabled = false;
                this.toolUnlock.Enabled = false;
                this.toolEdit.Enabled = false;
                this.storeBusiness = new StoreBusiness();
            }
            else
            {
                MessageBox.Show("修改失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                if ((BillingType)contract.BillingType == BillingType.VariousWeight)
                {
                    this.isEqualWeight = false;
                    this.columnTotalWeight.ReadOnly = false;
                }
                else
                {
                    this.isEqualWeight = true;
                    this.columnTotalWeight.ReadOnly = true;
                }
            }
            else
            {
                this.textBoxBillingType.Text = "";
            }
        }

        /// <summary>
        /// 计算装卸费结冻费
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCalculateFee_Click(object sender, EventArgs e)
        {
            double totalWeight = 0;

            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                var cargo = row.DataBoundItem as Cargo;
                totalWeight += cargo.TotalWeight;
            }

            decimal handleUnitPrice = this.numericHandlingUnitPrice.Value;
            decimal handlingPrice = (decimal)totalWeight * handleUnitPrice;
            this.numericHandlingPrice.Value = handlingPrice;

            decimal freezeUnitPrice = this.numericFreezeUnitPrice.Value;
            decimal freezePrice = (decimal)totalWeight * freezeUnitPrice;
            this.numericFreezePrice.Value = freezePrice;
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

            if (e.ColumnIndex == this.columnCount.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.Count < 0)
                    cargo.Count = 0;
                if (this.isEqualWeight)
                    cargo.TotalWeight = Math.Round(cargo.UnitWeight * cargo.Count / 1000, 3);
                cargo.TotalVolume = Math.Round(cargo.UnitVolume * cargo.Count, 3);
            }
            else if (e.ColumnIndex == this.columnUnitWeight.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.UnitWeight < 0)
                    cargo.UnitWeight = 0;
                if (this.isEqualWeight)
                    cargo.TotalWeight = Math.Round(cargo.UnitWeight * cargo.Count / 1000, 3);
            }
            else if (e.ColumnIndex == this.columnUnitVolume.Index)
            {
                var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;
                if (cargo.UnitVolume < 0)
                    cargo.UnitVolume = 0;
                cargo.TotalVolume = Math.Round(cargo.UnitVolume * cargo.Count, 3);
            }
            else if (e.ColumnIndex == this.columnNumber.Index)
            {
                var number = this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnNumber.Index].Value;
                if (number == null)
                {
                    this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnNumberName.Index].Value = "";
                }
                else
                {
                    var cnumber = this.categoryBusiness.TranslateNumber(number.ToString());
                    if (cnumber != null)
                        this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnNumberName.Index].Value = cnumber.GetName();
                    else
                        this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnNumberName.Index].Value = "";
                }
            }
        }

        /// <summary>
        /// 单元格更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargoDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.cargoDataGridView.CurrentCell.ColumnIndex == this.columnNumber.Index)
            {
                DataGridViewTextBoxEditingControl editingControl = e.Control as DataGridViewTextBoxEditingControl;
                editingControl.TextChanged += new EventHandler(editingControl_TextChanged);
            }
        }

        void editingControl_TextChanged(object sender, EventArgs e)
        {
            if (this.cargoDataGridView.CurrentCell.ColumnIndex == this.columnNumber.Index)
            {
                var text = sender as TextBox;
                FilterCategoryNumber(text.Text);
            }
        }
        #endregion //Event
    }
}
