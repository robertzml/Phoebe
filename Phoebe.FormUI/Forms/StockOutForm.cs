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
    /// 货品出库窗体
    /// </summary>
    public partial class StockOutForm : Form
    {
        #region Field
        private User currentUser;

        private StockOut currentStockOut;

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
                this.cargoDataGridView.Rows[i].Cells[this.columnSelect.Index].Value = true;
                this.cargoDataGridView.Rows[i].Cells[this.columnOutCount.Index].Value = this.currentStockOut.StockOutDetails.ElementAt(i).Count;
                this.cargoDataGridView.Rows[i].Cells[this.columnOutWeight.Index].Value = this.currentStockOut.StockOutDetails.ElementAt(i).OutWeight;
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
        /// 设置控件能否修改
        /// </summary>
        /// <param name="canEdit">能否修改</param>
        private void SetControlEditable(bool canEdit)
        {
            this.dateBusinessTime.Enabled = this.comboBoxCustomer.Enabled = this.comboBoxContract.Enabled = canEdit;
            this.textBoxRemark.ReadOnly = !canEdit;

            this.cargoBindingNavigator.Enabled = canEdit;
            this.columnSelect.ReadOnly = this.columnOutCount.ReadOnly = !canEdit;
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
                bool isSelect = Convert.ToBoolean(row.Cells[this.columnSelect.Index].Value);
                if (isSelect)
                {
                    var cargo = row.DataBoundItem as Cargo;

                    StockOutDetail soDetail = new StockOutDetail();
                    soDetail.ID = Guid.NewGuid();
                    soDetail.StockOutID = stockOut.ID;
                    soDetail.CargoID = cargo.ID;
                    soDetail.WarehouseNumber = cargo.WarehouseNumber;
                    soDetail.StoreCount = cargo.StoreCount;
                    soDetail.Count = Convert.ToInt32(row.Cells[this.columnOutCount.Index].Value);
                    if (soDetail.Count == 0)
                    {
                        return ErrorCode.StockOutCountZero;
                    }
                    if (soDetail.Count > cargo.StoreCount)
                    {
                        return ErrorCode.StockMoveCountOverflow;
                    }
                    if (this.isEqualWeight)
                        soDetail.OutWeight = Math.Round(cargo.UnitWeight * soDetail.Count / 1000, 3);
                    else
                        soDetail.OutWeight = Convert.ToDouble(row.Cells[this.columnOutWeight.Index].Value);
                    soDetail.Status = (int)EntityStatus.StockOutReady;
                    details.Add(soDetail);
                }
            }
            if (details.Count == 0)
            {
                return ErrorCode.EmptySelect;
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
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockOutForm_Load(object sender, EventArgs e)
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
                this.toolDelete.Enabled = true;
                this.toolPrint.Enabled = false;
                SetControlEditable(true);
            }
            else if (this.currentStockOut.Status == (int)EntityStatus.StockOut)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                this.toolDelete.Enabled = false;
                this.toolPrint.Enabled = true;
                SetControlEditable(false);
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
            this.currentStockOut = null;

            this.toolSave.Enabled = true;
            this.toolConfirm.Enabled = false;
            this.groupBox2.Visible = this.groupBox3.Visible = true;
            SetControlEditable(true);

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
                this.toolPrint.Enabled = true;
                SetControlEditable(false);
            }
            else
            {
                MessageBox.Show("出库确认失败:" + result.DisplayName(), FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            DialogResult dr = MessageBox.Show("是否确认删除选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                ErrorCode result = this.storeBusiness.StockOutDelete(this.currentStockOut);
                if (result == ErrorCode.Success)
                {
                    MessageBox.Show("删除成功", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.currentStockOut = null;
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
            if (this.currentStockOut == null)
            {
                MessageBox.Show("当前未选中记录", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.currentStockOut.Status != (int)EntityStatus.StockOut)
            {
                MessageBox.Show("出库记录未确认", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StockOutPrintForm form = new StockOutPrintForm(this.currentStockOut);
            form.ShowDialog();
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
                    this.columnOutWeight.ReadOnly = false;
                }
                else
                {
                    this.isEqualWeight = true;
                    this.columnOutWeight.ReadOnly = true;
                }
            }
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

            var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;

            if (e.ColumnIndex == this.columnOutCount.Index)
            {
                int outCount = Convert.ToInt32(this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnOutCount.Index].Value);
                if (outCount < 0)
                {
                    this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnOutCount.Index].Value = 0;
                    outCount = 0;
                }
                if (this.isEqualWeight)
                    this.cargoDataGridView.Rows[e.RowIndex].Cells[this.columnOutWeight.Index].Value = Math.Round(cargo.UnitWeight * outCount / 1000, 3);
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
