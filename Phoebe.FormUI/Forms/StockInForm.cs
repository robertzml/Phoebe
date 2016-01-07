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

        CategoryBusiness categoryBusiness;

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

            this.currentCargoes = new List<Cargo>();
        }

        private void InitControl()
        {
            //this.textBoxUser.Text = this.currentUser.Name;

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

            //this.cargoDataGridView.DataSource = this.currentCargoes;

            //DataGridViewComboBoxCell cell = this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnFirstCategoryID.Index] as DataGridViewComboBoxCell;
            //cell.DataSource = categoryBusiness.GetFirstCategory();
            //cell.DisplayMember = "Name";
            //cell.ValueMember = "ID";

            //((DataGridViewComboBoxColumn)cargoDataGridView.Columns["dataGridViewColumnFirstCategoryID"]).DefaultCellStyle.NullValue = "--请选择--";
        }

        /// <summary>
        /// 绑定页面数据到模型
        /// </summary>
        private void ControlToModel()
        {
            this.currentStockIn.InTime = this.dateBusinessTime.Value.Date;
            this.currentStockIn.FlowNumber = this.textBoxFlowNumber.Text;
            this.currentStockIn.ContractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);

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

        }
        

        private void cargoDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //var cargo = this.cargoDataGridView.Rows[e.RowIndex].DataBoundItem as Cargo;

            //var row = this.cargoDataGridView.Rows[e.RowIndex];
            //DataGridViewComboBoxCell cell = this.cargoDataGridView.Rows[e.RowIndex].Cells[this.dataGridViewColumnFirstCategoryID.Index] as DataGridViewComboBoxCell;
          
        }
       

        private void cargoDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //string message = e.Exception.Message;
            //MessageBox.Show(message);
        }

        

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

        }
        #endregion //Event
    }
}
