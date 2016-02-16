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
    /// 库存盘点报表
    /// </summary>
    public partial class StockInventoryReportForm : Form
    {
        #region Field
        private StatisticBusiness statisticBusiness;

        private CustomerBusiness customerBusiness;
        #endregion //Field

        #region Constructor
        public StockInventoryReportForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.statisticBusiness = new StatisticBusiness();
            this.customerBusiness = new CustomerBusiness();
        }

        private void InitControl()
        {
            var customers = this.customerBusiness.Get();
            customers.Insert(0, new Customer { ID = 0, Name = "--全部客户--" });
            this.comboBoxCustomer.DataSource = customers;
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockInventoryReportForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }
       
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            if (this.comboBoxCustomer.SelectedIndex == -1)
                return;

            if (this.comboBoxCustomer.SelectedIndex == 0)
            {

            }
            else
            {
                var customer = this.comboBoxCustomer.SelectedItem as Customer;

                var data = this.statisticBusiness.GetInventory(this.dateStart.Value.Date, this.dateEnd.Value.Date, customer.ID);
                this.inventoryBindingSource.DataSource = data;
            }
        }
        #endregion //Event
    }
}
