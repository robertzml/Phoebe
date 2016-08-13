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
    /// 冷藏费用结算表格控件
    /// </summary>
    public partial class ColdSettlementGrid : UserControl
    {
        #region Constructor
        public ColdSettlementGrid()
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
            this.bsColdSettle.Clear();
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<ColdSettlement> DataSource
        {
            get
            {
                return this.bsColdSettle.DataSource as List<ColdSettlement>;
            }
            set
            {
                this.dgvCold.BeginDataUpdate();
                this.bsColdSettle.DataSource = value;
                this.dgvCold.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
