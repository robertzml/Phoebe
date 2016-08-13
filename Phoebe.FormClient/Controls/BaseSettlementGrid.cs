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

    /// <summary>
    /// 基本结算表格控件
    /// </summary>
    public partial class BaseSettlementGrid : UserControl
    {
        #region Constructor
        public BaseSettlementGrid()
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
            this.bsBaseSettle.Clear();
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<BaseSettlement> DataSource
        {
            get
            {
                return this.bsBaseSettle.DataSource as List<BaseSettlement>;
            }
            set
            {
                this.dgvBase.BeginDataUpdate();
                this.bsBaseSettle.DataSource = value;
                this.dgvBase.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
