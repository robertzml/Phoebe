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
    /// 货品移库窗体
    /// </summary>
    public partial class StockMoveForm : Form
    {
        #region Field
        private User currentUser;

        private StockMove currentStockMove;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CargoBusiness cargoBusiness;

        private StoreBusiness storeBusiness;

        /// <summary>
        /// 是否新增
        /// </summary>
        private bool isNew = false;

        /// <summary>
        /// 货品是否等重
        /// </summary>
        private bool isEqualWeight = true;
        #endregion //Field

        #region Constructor
        public StockMoveForm(User user)
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
            this.textBoxStatus.Text = ((EntityStatus)this.currentStockMove.Status).DisplayName();
            this.dateBusinessTime.Value = this.currentStockMove.MoveTime;
            this.textBoxFlowNumber.Text = this.currentStockMove.FlowNumber.ToString();
            if (this.currentStockMove.ContractID == 0)
            {
                this.comboBoxCustomer.SelectedIndex = -1;
                this.comboBoxContract.SelectedIndex = -1;
            }
            else
            {
                this.comboBoxCustomer.SelectedValue = this.currentStockMove.Contract.CustomerID;
                this.comboBoxContract.SelectedValue = this.currentStockMove.ContractID;
            }
            this.textBoxUser.Text = this.currentStockMove.User.Name;
            this.textBoxRemark.Text = this.currentStockMove.Remark;

            List<Cargo> cargos = new List<Cargo>();
            foreach (var item in this.currentStockMove.StockMoveDetails)
            {
                cargos.Add(item.SourceCargo);
            }

            this.cargoBindingSource.DataSource = cargos;

            for (int i = 0; i < this.currentStockMove.StockMoveDetails.Count; i++)
            {
                this.cargoDataGridView.Rows[i].Cells[this.columnSelect.Index].Value = true;
                this.cargoDataGridView.Rows[i].Cells[this.columnMoveCount.Index].Value = this.currentStockMove.StockMoveDetails.ElementAt(i).Count;
                this.cargoDataGridView.Rows[i].Cells[this.columnMoveWeight.Index].Value = this.currentStockMove.StockMoveDetails.ElementAt(i).MoveWeight;
                this.cargoDataGridView.Rows[i].Cells[this.columnNewWarehouse.Index].Value = this.currentStockMove.StockMoveDetails.ElementAt(i).WarehouseNumber;
            }
        }

        /// <summary>
        /// 更新票据列表
        /// </summary>
        private void UpdateTree()
        {
            this.treeViewReceipt.Nodes.Clear();

            var months = this.storeBusiness.GetStockMoveMonthGroup();
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
            this.dateBusinessTime.Enabled = this.comboBoxCustomer.Enabled = this.comboBoxContract.Enabled = canEdit;
            this.textBoxRemark.ReadOnly = !canEdit;

            this.cargoBindingNavigator.Enabled = canEdit;
            this.columnSelect.ReadOnly = this.columnMoveCount.ReadOnly = this.columnNewWarehouse.ReadOnly = !canEdit;
        }

        /// <summary>
        /// 保存新项
        /// </summary>
        /// <returns></returns>
        public ErrorCode SaveNewItem()
        {
            StockMove stockMove = new StockMove();
            stockMove.ID = Guid.NewGuid();
            stockMove.MoveTime = this.dateBusinessTime.Value.Date;
            stockMove.MonthTime = stockMove.MoveTime.Year + stockMove.MoveTime.Month.ToString().PadLeft(2, '0');
            stockMove.FlowNumber = this.textBoxFlowNumber.Text;
            stockMove.ContractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
            stockMove.IsLock = false;
            stockMove.UserID = this.currentUser.ID;
            stockMove.Remark = this.textBoxRemark.Text;
            stockMove.Status = (int)EntityStatus.StockMoveReady;

            List<StockMoveDetail> details = new List<StockMoveDetail>();
            foreach (DataGridViewRow row in this.cargoDataGridView.Rows)
            {
                bool isSelect = Convert.ToBoolean(row.Cells[this.columnSelect.Index].Value);
                if (isSelect)
                {
                    var cargo = row.DataBoundItem as Cargo;
                    if (row.Cells[this.columnNewWarehouse.Index].Value == null)
                    {
                        return ErrorCode.WarehouseCannotBeEmpty;
                    }

                    StockMoveDetail smDetail = new StockMoveDetail();
                    smDetail.ID = Guid.NewGuid();
                    smDetail.StockMoveID = stockMove.ID;
                    smDetail.SourceCargoID = cargo.ID;
                    smDetail.WarehouseNumber = row.Cells[this.columnNewWarehouse.Index].Value.ToString();
                    smDetail.StoreCount = cargo.StoreCount;
                    smDetail.Count = Convert.ToInt32(row.Cells[this.columnMoveCount.Index].Value);
                    if (smDetail.Count == 0)
                    {
                        return ErrorCode.StockMoveCountZero;
                    }
                    if (smDetail.Count > cargo.StoreCount)
                    {
                        return ErrorCode.StockMoveCountOverflow;
                    }
                    smDetail.IsAllMove = (smDetail.StoreCount == smDetail.Count);
                    if (this.isEqualWeight)
                        smDetail.MoveWeight = cargo.UnitWeight * smDetail.Count / 1000;
                    else
                        smDetail.MoveWeight = Convert.ToDouble(row.Cells[this.columnMoveWeight.Index].Value);
                    smDetail.Status = (int)EntityStatus.StockMoveReady;
                    details.Add(smDetail);
                }
            }
            if (details.Count == 0)
            {
                return ErrorCode.EmptySelect;
            }

            ErrorCode result = this.storeBusiness.StockMove(stockMove, details);
            if (result == ErrorCode.Success)
            {
                this.currentStockMove = this.storeBusiness.GetStockMove(stockMove.ID.ToString());
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
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockMoveForm_Load(object sender, EventArgs e)
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
            var data = this.storeBusiness.GetStockMoveByMonth(e.Node.Name);
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

            this.currentStockMove = e.Node.Tag as StockMove;
            ModelToControl();
            this.isNew = false;
            if (this.currentStockMove.Status == (int)EntityStatus.StockMoveReady)
            {
                this.toolSave.Enabled = true;
                this.toolConfirm.Enabled = true;
                this.toolDelete.Enabled = true;
                SetControlEditable(true);
            }
            else if (this.currentStockMove.Status == (int)EntityStatus.StockMove)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                this.toolDelete.Enabled = false;
                SetControlEditable(false);
            }
        }

        /// <summary>
        /// 新建移库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolNew_Click(object sender, EventArgs e)
        {
            this.isNew = true;
            this.currentStockMove = null;

            this.toolSave.Enabled = true;
            this.toolConfirm.Enabled = false;
            this.groupBox2.Visible = this.groupBox3.Visible = true;
            SetControlEditable(true);

            DateTime now = DateTime.Now.Date;
            this.dateBusinessTime.Value = now;
            this.textBoxFlowNumber.Text = this.storeBusiness.GetLastStockMoveFlowNumber(now);
            this.comboBoxCustomer.SelectedIndex = -1;
            this.comboBoxContract.SelectedIndex = -1;
            this.textBoxStatus.Text = EntityStatus.StockMoveReady.DisplayName();
            this.textBoxUser.Text = this.currentUser.Name;

            this.cargoBindingSource.DataSource = null;
        }

        /// <summary>
        /// 保存移库
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
                    this.storeBusiness = new StoreBusiness();
                }
                else
                {
                    MessageBox.Show("保存失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolConfirm_Click(object sender, EventArgs e)
        {
            if (this.currentStockMove == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.currentStockMove.Status != (int)EntityStatus.StockMoveReady)
            {
                MessageBox.Show("当前记录已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ErrorCode result = this.storeBusiness.StockMoveConfirm(this.currentStockMove.ID);
            if (result == ErrorCode.Success)
            {
                MessageBox.Show("移库已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.textBoxStatus.Text = EntityStatus.StockMove.DisplayName();
                this.toolConfirm.Enabled = false;
                SetControlEditable(false);
            }
            else
            {
                MessageBox.Show("移库确认失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.currentStockMove == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.currentStockMove.Status != (int)EntityStatus.StockMoveReady)
            {
                MessageBox.Show("当前记录已确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("是否确认删除选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = this.storeBusiness.StockMoveDelete(this.currentStockMove);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.currentStockMove = null;
                }
                else
                {
                    MessageBox.Show("删除失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 选择客户
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
            else
            {
                this.comboBoxContract.DataSource = null;
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
                var contract = this.comboBoxContract.SelectedItem as Contract;
                var data = this.cargoBusiness.GetInByContract(contract.ID);
                this.cargoBindingSource.DataSource = data;

                if ((BillingType)contract.BillingType == BillingType.VariousWeight)
                {
                    this.isEqualWeight = false;
                    this.columnMoveWeight.ReadOnly = false;
                }
                else
                {
                    this.isEqualWeight = true;
                    this.columnMoveWeight.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 单元格值更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargoDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;

            if (e.ColumnIndex == this.columnMoveCount.Index)
            {
                int moveCount = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnMoveCount.Index].Value);
                if (moveCount < 0)
                {
                    this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnMoveCount.Index].Value = 0;
                    moveCount = 0;
                }
                if (this.isEqualWeight)
                    this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnMoveWeight.Index].Value = Math.Round(cargo.UnitWeight * moveCount / 1000, 3);
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
