﻿using System;
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

        private List<Cargo> currentCargoes;

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

            this.currentCargoes = new List<Cargo>();
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
            foreach(var item in this.currentStockIn.StockInDetails)
            {

            }
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            var months = this.storeBusiness.GetStockInMonthGroup();
            for(int i = 0; i < months.Length; i++)
            {
                TreeNode node = new TreeNode();
                node.Name = months[i];
                node.Text = months[i];
                node.Nodes.Add("");
                this.treeViewReceipt.Nodes.Add(node);
            }
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
            foreach(var item in data)
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
                this.toolConfirm.Enabled = true;
            }
            else
            {
                this.toolConfirm.Enabled = false;
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
            this.groupBox2.Visible = this.groupBox3.Visible = true;

            DateTime now = DateTime.Now.Date;
            this.dateBusinessTime.Value = now;
            this.textBoxFlowNumber.Text = this.storeBusiness.GetLastStockInFlowNumber(now);
            this.comboBoxCustomer.SelectedIndex = -1;
            this.comboBoxContract.SelectedIndex = -1;
            this.textBoxBillingType.Text = "";
            this.textBoxStatus.Text = EntityStatus.StockInReady.DisplayName();
            this.textBoxUser.Text = this.currentUser.Name;
        }

        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            if (this.isNew)
            {
                ErrorCode result = SaveNewItem();
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("保存成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.toolConfirm.Enabled = true;
                    UpdateTree();
                }
                else
                {
                    MessageBox.Show("保存失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                this.toolConfirm.Enabled = false;
            }
            else
            {
                MessageBox.Show("入库确认失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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