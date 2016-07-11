using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 库存流水表格
    /// </summary>
    public partial class StockFlowGrid : UserControl
    {
        #region Constructor
        public StockFlowGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {
            this.bsStockFlow.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public StockFlow GetCurrentSelect()
        {
            int rowIndex = this.dgvStockFlow.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStockFlow.Count)
                return null;
            else
                return this.bsStockFlow[rowIndex] as StockFlow;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStockFlow.ResetBindings(false);
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StockFlow> DataSource
        {
            get
            {
                return this.bsStockFlow.DataSource as List<StockFlow>;
            }
            set
            {
                this.dgvStockFlow.BeginDataUpdate();
                this.bsStockFlow.DataSource = value;
                this.dgvStockFlow.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
