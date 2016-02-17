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
    /// 出入库报表窗体
    /// </summary>
    public partial class StockFlowReportForm : Form
    {
        #region Field
        private StatisticBusiness statisticBusiness;

        private CustomerBusiness customerBusiness;

        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public StockFlowReportForm()
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
            customers.Insert(0, new Customer { ID = 0, Name = "--请选择--" });
            this.comboBoxCustomer.DataSource = customers;
            this.comboBoxCustomer.DisplayMember = "Name";
            this.comboBoxCustomer.ValueMember = "ID";

            var fc = this.categoryBusiness.GetFirstCategory(false);
            fc.Insert(0, new FirstCategory { ID = 0, Name = "--请选择--" });
            this.comboBoxFirstCategory.DataSource = fc;
            this.comboBoxFirstCategory.DisplayMember = "Name";
            this.comboBoxFirstCategory.ValueMember = "ID";
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockFlowReportForm_Load(object sender, EventArgs e)
        {
            InitData();
            InitControl();
        }

        /// <summary>
        /// 选择一级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxFirstCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxFirstCategory.SelectedIndex == -1)
                return;
            else if (this.comboBoxFirstCategory.SelectedIndex == 0)
            {
                this.comboBoxSecondCategory.DataSource = null;
                this.comboBoxThirdCategory.DataSource = null;
                return;
            }

            var fc = this.comboBoxFirstCategory.SelectedItem as FirstCategory;
            var sc = this.categoryBusiness.GetSecondCategoryByFirst(fc.ID, false);
            sc.Insert(0, new SecondCategory { ID = 0, Name = "--请选择--" });
            this.comboBoxSecondCategory.DataSource = sc;
            this.comboBoxSecondCategory.DisplayMember = "Name";
            this.comboBoxSecondCategory.ValueMember = "ID";

            this.comboBoxThirdCategory.DataSource = null;
        }

        /// <summary>
        /// 选择二级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSecondCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBoxSecondCategory.SelectedIndex == -1)
                return;
            else if (this.comboBoxSecondCategory.SelectedIndex == 0)
            {
                this.comboBoxThirdCategory.DataSource = null;
                return;
            }

            var sc = this.comboBoxSecondCategory.SelectedItem as SecondCategory;
            var tc = this.categoryBusiness.GetThirdCategoryBySecond(sc.ID, false);
            tc.Insert(0, new ThirdCategory { ID = 0, Name = "--请选择--" });
            this.comboBoxThirdCategory.DataSource = tc;
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
            if (!this.checkBoxIn.Checked && !this.checkBoxOut.Checked)
            {
                MessageBox.Show("请选择类型", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dateStart.Value.Date > this.dateEnd.Value.Date)
            {
                MessageBox.Show("开始日期不能晚于结束日期", FormConstant.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<StockFlow> data = new List<StockFlow>();
            List<StockFlow> inFlow;
            List<StockFlow> outFlow;
            if (this.checkBoxIn.Checked)
            {
                if (this.comboBoxCustomer.SelectedIndex == -1 || this.comboBoxCustomer.SelectedIndex == 0)
                {
                    inFlow = this.statisticBusiness.GetFlowIn(this.dateStart.Value.Date, this.dateEnd.Value.Date, 0);
                }
                else
                {
                    var customer = this.comboBoxCustomer.SelectedItem as Customer;
                    inFlow = this.statisticBusiness.GetFlowIn(this.dateStart.Value.Date, this.dateEnd.Value.Date, customer.ID);
                }

                data.AddRange(inFlow);
            }

            if (this.checkBoxOut.Checked)
            {
                if (this.comboBoxCustomer.SelectedIndex == -1 || this.comboBoxCustomer.SelectedIndex == 0)
                {
                    outFlow = this.statisticBusiness.GetFlowOut(this.dateStart.Value.Date, this.dateEnd.Value.Date, 0);
                }
                else
                {
                    var customer = this.comboBoxCustomer.SelectedItem as Customer;
                    outFlow = this.statisticBusiness.GetFlowOut(this.dateStart.Value.Date, this.dateEnd.Value.Date, customer.ID);
                }

                data.AddRange(outFlow);
            }

            if (this.comboBoxFirstCategory.SelectedIndex != -1 && this.comboBoxFirstCategory.SelectedIndex != 0)
            {
                int fid = Convert.ToInt32(this.comboBoxFirstCategory.SelectedValue);
                data = data.Where(r => r.FirstCategoryID == fid).ToList();
            }
            if (this.comboBoxSecondCategory.SelectedIndex != -1 && this.comboBoxSecondCategory.SelectedIndex != 0)
            {
                int sid = Convert.ToInt32(this.comboBoxSecondCategory.SelectedValue);
                data = data.Where(r => r.SecondCategoryID == sid).ToList();
            }
            if (this.comboBoxThirdCategory.SelectedIndex != -1 && this.comboBoxThirdCategory.SelectedIndex != 0)
            {
                int tid = Convert.ToInt32(this.comboBoxThirdCategory.SelectedValue);
                data = data.Where(r => r.ThirdCategoryID == tid).ToList();
            }

            this.stockFlowBindingSource.DataSource = data;
            this.textBoxTotalCount.Text = data.Sum(r => r.Count).ToString();
            this.textBoxTotalWeight.Text = data.Sum(r => r.Weight).ToString() + " 吨";
        }

        private void stockFlowDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < this.stockFlowBindingSource.Count)
            {
                var flow = this.stockFlowBindingSource[e.RowIndex] as StockFlow;
                var grid = this.stockFlowDataGridView;

                if (flow.Type == StockFlowType.StockIn)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnType.Index].Value = "入库";
                }
                else if (flow.Type == StockFlowType.StockOut)
                {
                    grid.Rows[e.RowIndex].Cells[this.columnType.Index].Value = "出库";
                }
            }
        }
        #endregion //Event
    }
}
