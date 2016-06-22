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
    /// 合同表格控件
    /// </summary>
    public partial class ContractGrid : UserControl
    {
        #region Constructor
        public ContractGrid()
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
            this.bsContract.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Contract GetCurrentSelect()
        {
            int rowIndex = this.dgvContract.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsContract.Count)
                return null;
            else
                return this.bsContract[rowIndex] as Contract;
        }
        #endregion //Method


        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Contract> DataSource
        {
            get
            {
                return this.bsContract.DataSource as List<Contract>;
            }
            set
            {
                this.dgvContract.BeginDataUpdate();
                this.bsContract.DataSource = value;
                this.dgvContract.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
