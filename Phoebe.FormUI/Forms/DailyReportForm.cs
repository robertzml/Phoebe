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
    public partial class DailyReportForm : Form
    {
        #region Field
        private StatisticBusiness statisticBusiness;
        #endregion //Field

        #region Constructor
        public DailyReportForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        private void InitData()
        {
            this.statisticBusiness = new StatisticBusiness();
        }

        private void InitControl()
        {
            this.comboBoxType.SelectedIndex = 0;
        }
        #endregion //Function

        #region Event
        private void DailyReportForm_Load(object sender, EventArgs e)
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
            if (this.comboBoxType.SelectedIndex == 0)
            {
                var data = this.statisticBusiness.GetDailyFlowIn(this.datePicker.Value.Date);
                this.stockFlowBindingSource.DataSource = data;

                this.textBoxTotalCount.Text = data.Sum(r => r.Count).ToString();
                this.textBoxTotalWeight.Text = data.Sum(r => r.Weight).ToString() + " 吨";
            }
            else
            {
                var data = this.statisticBusiness.GetDailyFlowOut(this.datePicker.Value.Date);
                this.stockFlowBindingSource.DataSource = data;

                this.textBoxTotalCount.Text = data.Sum(r => r.Count).ToString();
                this.textBoxTotalWeight.Text = data.Sum(r => r.Weight).ToString() + " 吨";
            }
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
