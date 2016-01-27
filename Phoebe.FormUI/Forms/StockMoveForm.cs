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
    public partial class StockMoveForm : Form
    {
        #region Field
        private User currentUser;

        private StockMove currentStockMove;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CargoBusiness cargoBusiness;

        private StoreBusiness storeBusiness;

        private WarehouseBusiness warehouseBusiness;

        private bool isNew = false;
        #endregion //Field

        #region Function
        private void InitData()
        {
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
            this.cargoBusiness = new CargoBusiness();
            this.storeBusiness = new StoreBusiness();
            this.warehouseBusiness = new WarehouseBusiness();
        }

        private void InitControl()
        {
            //UpdateTree();

            this.comboBoxCustomer.DataSource = this.customerBusiness.Get();
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            DataGridViewComboBoxColumn whColumn = this.dataGridViewColumnNewWarehouse;
            whColumn.DataSource = this.warehouseBusiness.Get();
            whColumn.DisplayMember = "Number";
            whColumn.ValueMember = "ID";
        }
        #endregion //Function

        #region Constructor
        public StockMoveForm(User user)
        {
            InitializeComponent();
            this.currentUser = user;
        }
        #endregion //Constructor

        #region Event
        private void StockMoveForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }
        

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

        private void treeViewReceipt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                return;

            this.groupBox2.Visible = this.groupBox3.Visible = true;

            this.currentStockMove = e.Node.Tag as StockMove;
            //ModelToControl();
            this.isNew = false;
            if (this.currentStockMove.Status == (int)EntityStatus.StockMoveReady)
            {
                this.toolSave.Enabled = true;
                this.toolConfirm.Enabled = true;
                this.groupBox2.Enabled = true;
            }
            else if (this.currentStockMove.Status == (int)EntityStatus.StockOut)
            {
                this.toolSave.Enabled = false;
                this.toolConfirm.Enabled = false;
                this.groupBox2.Enabled = false;
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
            this.toolSave.Enabled = true;
            this.toolConfirm.Enabled = false;
            this.groupBox2.Visible = this.groupBox3.Visible = true;
            this.groupBox2.Enabled = true;
           

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
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnSourceWarehouse.Index].Value = cargo.Warehouse.Number;
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
