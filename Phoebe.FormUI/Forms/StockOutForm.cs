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
            UpdateTree();

            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }

        /// <summary>
        /// 更新模型数据到页面
        /// </summary>
        private void ModelToControl()
        {
            this.textBoxStatus.Text = ((EntityStatus)this.currentStockOut.Status).DisplayName();
            this.dateBusinessTime.Value = this.currentStockOut.OutTime;
            this.textBoxFlowNumber.Text = this.currentStockOut.FlowNumber.ToString();
            if (this.currentStockOut.ContractID == 0)
            {
                this.comboBoxCustomer.SelectedIndex = -1;
                this.comboBoxContract.SelectedIndex = -1;
            }
            else
            {
                this.comboBoxCustomer.SelectedValue = this.currentStockOut.Contract.CustomerID;
                this.comboBoxContract.SelectedValue = this.currentStockOut.ContractID;
            }
            this.textBoxUser.Text = this.currentStockOut.User.Name;
            this.textBoxRemark.Text = this.currentStockOut.Remark;

            List<Cargo> cargos = new List<Cargo>();
            foreach (var item in this.currentStockOut.StockOutDetails)
            {
                cargos.Add(item.Cargo);
            }

            this.cargoBindingSource.DataSource = cargos;

            for (int i = 0; i < this.currentStockOut.StockOutDetails.Count; i++)
            {
                this.cargoDataGridView.Rows[i].Cells[this.dataGridViewColumnOutCount.Index].Value = this.currentStockOut.StockOutDetails.ElementAt(i).Count;
            }
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            this.treeViewReceipt.Nodes.Clear();

            var months = this.storeBusiness.GetStockOutMonthGroup();
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
                bool isSelect = Convert.ToBoolean(row.Cells[this.dataGridViewColumnSelect.Index].Value);
                if (isSelect)
                {
                    var cargo = row.DataBoundItem as Cargo;

                    StockOutDetail soDetail = new StockOutDetail();
                    soDetail.ID = Guid.NewGuid();
                    soDetail.StockOutID = stockOut.ID;
                    soDetail.CargoID = cargo.ID;
                    soDetail.WarehouseID = cargo.WarehouseID.Value;
                    soDetail.StoreCount = cargo.StoreCount;
                    soDetail.Count = Convert.ToInt32(row.Cells[this.dataGridViewColumnOutCount.Index].Value);
                    soDetail.Status = (int)EntityStatus.StockOutReady;
                    details.Add(soDetail);
                }
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

        private void treeViewReceipt_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var data = this.storeBusiness.GetStockOutByMonth(e.Node.Name);
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

            this.currentStockOut = e.Node.Tag as StockOut;
            ModelToControl();
            this.isNew = false;
            if (this.currentStockOut.Status == (int)EntityStatus.StockOutReady)
            {
                this.toolSave.Enabled = true;
                this.toolConfirm.Enabled = true;
                this.groupBox2.Enabled = true;
                this.dataGridViewColumnOutCount.ReadOnly = false;
            }
            else if (this.currentStockOut.Status == (int)EntityStatus.StockOut)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                this.groupBox2.Enabled = false;
                this.dataGridViewColumnOutCount.ReadOnly = true;
            }
        }

        /// <summary>
        /// 新建出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolNew_Click(object sender, EventArgs e)
        {
            this.isNew = true;
            this.toolSave.Enabled = true;
            this.toolConfirm.Enabled = false;
            this.groupBox2.Visible = this.groupBox3.Visible = true;
            this.groupBox2.Enabled = true;
            this.dataGridViewColumnOutCount.ReadOnly = false;

            DateTime now = DateTime.Now.Date;
            this.dateBusinessTime.Value = now;
            this.textBoxFlowNumber.Text = this.storeBusiness.GetLastStockOutFlowNumber(now);
            this.comboBoxCustomer.SelectedIndex = -1;
            this.comboBoxContract.SelectedIndex = -1;
            this.textBoxStatus.Text = EntityStatus.StockOutReady.DisplayName();
            this.textBoxUser.Text = this.currentUser.Name;

            this.cargoBindingSource.DataSource = null;
        }

        /// <summary>
        /// 出库保存
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
        /// 出库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentStockOut == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.currentStockOut.Status != (int)EntityStatus.StockOutReady)
            {
                MessageBox.Show("当前记录已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.storeBusiness.StockOutConfirm(this.currentStockOut.ID);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("出库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxStatus.Text = EntityStatus.StockOut.DisplayName();
                this.toolConfirm.Enabled = false;
            }
            else
            {
                MessageBox.Show("出库确认失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 锁定记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolLock_Click(object sender, EventArgs e)
        {
            if (this.currentStockOut == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.storeBusiness.StockOutLock(this.currentStockOut.ID, true);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("出库已锁定", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.groupBox2.Enabled = false;
                this.cargoDataGridView.ReadOnly = true;

                this.toolLock.Enabled = false;
                this.toolUnlock.Enabled = true;
            }
            else
            {
                MessageBox.Show("出库锁定失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 解锁记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolUnlock_Click(object sender, EventArgs e)
        {
            if (this.currentStockOut == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.storeBusiness.StockOutLock(this.currentStockOut.ID, false);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("出库已解锁", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.groupBox2.Enabled = true;
                this.cargoDataGridView.ReadOnly = false;

                this.toolLock.Enabled = true;
                this.toolUnlock.Enabled = false;
            }
            else
            {
                MessageBox.Show("出库解锁失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var data = this.cargoBusiness.GetInByContract(contractId);
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
