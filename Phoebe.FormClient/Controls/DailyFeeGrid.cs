using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    public partial class DailyFeeGrid : UserControl
    {
        #region Constructor
        public DailyFeeGrid()
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
            this.bsDailyFee.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public DailyFee GetCurrentSelect()
        {
            int rowIndex = this.dgvDaily.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsDailyFee.Count)
                return null;
            else
                return this.bsDailyFee[rowIndex] as DailyFee;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<DailyFee> DataSource
        {
            get
            {
                return this.bsDailyFee.DataSource as List<DailyFee>;
            }
            set
            {
                this.dgvDaily.BeginDataUpdate();
                this.bsDailyFee.DataSource = value;
                this.dgvDaily.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
