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
    public partial class CargoForm : Form
    {
        #region Field
        private CargoBusiness cargoBusiness;

        private CustomerBusiness customerBusiness;

        private ContractBusiness contractBusiness;

        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CargoForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.cargoBusiness = new CargoBusiness();
            this.customerBusiness = new CustomerBusiness();
            this.contractBusiness = new ContractBusiness();
            this.categoryBusiness = new CategoryBusiness();
        }

        private void InitControl()
        {
            var customers = this.customerBusiness.Get();
            customers.Insert(0, new Customer { ID = 0, Name = "--请选择--" });
            this.comboBoxCustomer.DataSource = customers;
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            this.comboBoxFirstCategory.DataSource = this.categoryBusiness.GetFirstCategory();
            this.comboBoxFirstCategory.DisplayMember = "Name";
            this.comboBoxFirstCategory.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        private void CargoForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 客户选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1 || this.comboBoxCustomer.SelectedIndex == 0)
            {
                this.comboBoxContract.DataSource = null;
                return;
            }

            var contracts = this.contractBusiness.GetByCustomer(Convert.ToInt32(this.comboBoxCustomer.SelectedValue));
            contracts.Insert(0, new Contract { ID = 0, Name = "--请选择--" });

            this.comboBoxContract.DataSource = contracts;
            this.comboBoxContract.DisplayMember = "Name";
            this.comboBoxContract.ValueMember = "ID";
        }

        /// <summary>
        /// 一级分类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFirstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxFirstCategory.SelectedIndex == -1 || this.comboBoxFirstCategory.SelectedIndex == 0)
            {
                this.comboBoxSecondCategory.DataSource = null;
                this.comboBoxThirdCategory.DataSource = null;
                return;
            }

            this.comboBoxSecondCategory.DataSource = this.categoryBusiness.GetSecondCategoryByFirst(Convert.ToInt32(this.comboBoxFirstCategory.SelectedValue));
            this.comboBoxSecondCategory.DisplayMember = "Name";
            this.comboBoxSecondCategory.ValueMember = "ID";
        }

        /// <summary>
        /// 二级分类选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxSecondCategory.SelectedIndex == -1 || this.comboBoxSecondCategory.SelectedIndex == 0)
            {
                this.comboBoxThirdCategory.DataSource = null;
                return;
            }

            this.comboBoxThirdCategory.DataSource = this.categoryBusiness.GetThirdCategoryBySecond(Convert.ToInt32(this.comboBoxSecondCategory.SelectedValue));
            this.comboBoxThirdCategory.DisplayMember = "Name";
            this.comboBoxThirdCategory.ValueMember = "ID";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            List<Cargo> data;
            int customerID = Convert.ToInt32(this.comboBoxCustomer.SelectedValue);

            if (customerID == -1 || customerID == 0)
            {
                data = this.cargoBusiness.Get();
            }
            else
            {
                int contractID = Convert.ToInt32(this.comboBoxContract.SelectedValue);
                if (contractID == -1 || contractID == 0)
                    data = this.cargoBusiness.GetByCustomer(customerID);
                else
                    data = this.cargoBusiness.GetByContract(contractID);
            }

            if (this.comboBoxFirstCategory.SelectedIndex > 0)
            {
                int first = Convert.ToInt32(this.comboBoxFirstCategory.SelectedValue);
                data = data.Where(r => r.FirstCategoryID == first).ToList();
            }

            if (this.comboBoxSecondCategory.SelectedIndex > 0)
            {
                int second = Convert.ToInt32(this.comboBoxSecondCategory.SelectedValue);
                data = data.Where(r => r.SecondCategoryID == second).ToList();
            }

            if (this.comboBoxThirdCategory.SelectedIndex > 0)
            {
                int third = Convert.ToInt32(this.comboBoxThirdCategory.SelectedValue);
                data = data.Where(r => r.ThirdCategoryID == third).ToList();
            }

            if (this.checkBoxStockInReady.Checked == false)
            {
                data = data.Where(r => r.Status != (int)EntityStatus.CargoStockInReady).ToList();
            }
            if (this.checkBoxStockIn.Checked == false)
            {
                data = data.Where(r => r.Status != (int)EntityStatus.CargoStockIn).ToList();
            }
            if (this.checkBoxStockOut.Checked == false)
            {
                data = data.Where(r => r.Status != (int)EntityStatus.CargoStockOut).ToList();
            }

            this.cargoBindingSource.DataSource = data;
        }        

        private void cargoDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.cargoBindingSource.Count)
            {
                var cargo = this.cargoBindingSource[e.RowIndex] as Cargo;
                var grid = this.cargoDataGridView;

                if (cargo.Contract != null)
                {
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnContract.Index].Value = cargo.Contract.Name;
                }

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
                    grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnUserName.Index].Value = cargo.User.Name;
                }

                grid.Rows[e.RowIndex].Cells[this.dataGridViewColumnStatus.Index].Value = ((EntityStatus)cargo.Status).DisplayName();
            }
        }
        #endregion //Event
    }
}
