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

        private CategoryBusiness categoryBusiness;
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
            this.categoryBusiness = new CategoryBusiness();
        }

        private void InitControl()
        {
            var customers = this.customerBusiness.Get();
            customers.Insert(0, new Customer { ID = 0, Name = "--全部客户--" });
            this.comboBoxCustomer.DataSource = customers;
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";
        }

        /// <summary>
        /// 分组盘点结果
        /// </summary>
        /// <param name="input">数据输入</param>
        /// <param name="category">分组标准，1:一级分类  2:二级分类</param>
        /// <returns></returns>
        private List<Inventory> GroupInventory(List<Inventory> input, int category)
        {
            List<Inventory> data = new List<Inventory>();

            if (category == 2)
            {
                foreach (var item in input)
                {
                    var inv = data.SingleOrDefault(r => r.CustomerID == item.CustomerID && r.FirstCategoryID == item.FirstCategoryID &&
                        r.SecondCategoryID == item.SecondCategoryID);

                    if (inv == null)
                    {
                        item.ThirdCategoryID = 0;
                        item.ThirdCategoryName = "";
                        data.Add(item);
                    }
                    else
                    {
                        inv.StartCount += item.StartCount;
                        inv.StartWeight += item.StartWeight;
                        inv.EndCount += item.EndCount;
                        inv.EndWeight += item.EndWeight;
                    }
                }
            }
            else if (category == 1)
            {
                foreach (var item in input)
                {
                    var inv = data.SingleOrDefault(r => r.CustomerID == item.CustomerID && r.FirstCategoryID == item.FirstCategoryID);

                    if (inv == null)
                    {
                        item.SecondCategoryID = 0;
                        item.SecondCategoryName = "";
                        data.Add(item);
                    }
                    else
                    {
                        inv.StartCount += item.StartCount;
                        inv.StartWeight += item.StartWeight;
                        inv.EndCount += item.EndCount;
                        inv.EndWeight += item.EndWeight;
                    }
                }
            }

            return data;
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

            if (this.dateStart.Value.Date > this.dateEnd.Value.Date)
            {
                MessageBox.Show("开始日期不能晚于结束日期", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Inventory> data = new List<Inventory>();
            if (this.comboBoxCustomer.SelectedIndex == 0)
            {
                var customers = this.customerBusiness.Get();
                foreach (var customer in customers)
                {
                    var inv = this.statisticBusiness.GetInventory(this.dateStart.Value.Date, this.dateEnd.Value.Date, customer.ID);
                    data.AddRange(inv);
                }
            }
            else
            {
                var customer = this.comboBoxCustomer.SelectedItem as Customer;
                data = this.statisticBusiness.GetInventory(this.dateStart.Value.Date, this.dateEnd.Value.Date, customer.ID);
            }

            if (!this.checkBoxThirdCategory.Checked && this.checkBoxSecondCategory.Checked)
            {
                data = GroupInventory(data, 2);
            }
            else if (!this.checkBoxThirdCategory.Checked && !this.checkBoxSecondCategory.Checked)
            {
                data = GroupInventory(data, 1);
            }

            int index = 1;
            data.ForEach(r => r.Number = index++);

            int totalStartCount = data.Sum(r => r.StartCount);
            double totalStartWeight = data.Sum(r => r.StartWeight);
            int totalEndCount = data.Sum(r => r.EndCount);
            double totalEndWeight = data.Sum(r => r.EndWeight);

            this.textBoxStartCount.Text = totalStartCount.ToString();
            this.textBoxStartWeight.Text = totalStartWeight.ToString("f3") + "吨";
            this.textBoxEndCount.Text = totalEndCount.ToString();
            this.textBoxEndWeight.Text = totalEndWeight.ToString("f3") + " 吨";

            this.inventoryBindingSource.DataSource = data;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (this.inventoryBindingSource.DataSource == null)
            {
                MessageBox.Show("未选择数据", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<Inventory> data = this.inventoryBindingSource.DataSource as List<Inventory>;
            StockInventoryPrintForm form = new StockInventoryPrintForm(data, this.dateStart.Value.Date, this.dateEnd.Value.Date);
            form.ShowDialog();
        }
        #endregion //Event
    }
}
