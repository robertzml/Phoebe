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
    /// 杂项费用结算表格控件
    /// </summary>
    public partial class MiscSettlementControl : UserControl
    {
        #region Constructor
        public MiscSettlementControl()
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
            this.bsMisc.Clear();
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<MiscSettlement> DataSource
        {
            get
            {
                return this.bsMisc.DataSource as List<MiscSettlement>;
            }
            set
            {
                this.dgvMisc.BeginDataUpdate();
                this.bsMisc.DataSource = value;
                this.dgvMisc.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
