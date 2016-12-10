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
    /// 费用结算表格控件
    /// </summary>
    public partial class SettlementGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否允许查找
        /// </summary>
        private bool enableFind = true;
        #endregion //Field

        #region Constructor
        public SettlementGrid()
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
            this.bsSettlement.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Settlement GetCurrentSelect()
        {
            int rowIndex = this.dgvSettlement.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                return null;
            else
                return this.bsSettlement[rowIndex] as Settlement;
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 控件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettlementGrid_Load(object sender, EventArgs e)
        {
            this.dgvSettlement.OptionsFind.AllowFindPanel = this.enableFind;
            this.dgvSettlement.OptionsFind.AlwaysVisible = this.enableFind;
        }

        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSettlement_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                return;

            if (e.Column.FieldName == "CustomerId")
            {
                var settlement = this.bsSettlement[rowIndex] as Settlement;
                e.DisplayText = settlement.Customer.Name;
            }
            else if (e.Column.FieldName == "UserId")
            {
                var settlement = this.bsSettlement[rowIndex] as Settlement;
                e.DisplayText = settlement.User.Name;
            }
        }

        /// <summary>
        /// 自定义数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSettlement_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsSettlement.Count)
                return;

            var settlement = this.bsSettlement[rowIndex] as Settlement;

            if (e.Column.FieldName == "colCustomerNumber" && e.IsGetData)
                e.Value = settlement.Customer.Number;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Settlement> DataSource
        {
            get
            {
                return this.bsSettlement.DataSource as List<Settlement>;
            }
            set
            {
                this.dgvSettlement.BeginDataUpdate();
                this.bsSettlement.DataSource = value;
                this.dgvSettlement.EndDataUpdate();
            }
        }

        /// <summary>
        /// 是否允许查找
        /// </summary>
        [Description("是否允许查找")]
        public bool EnableFind
        {
            get
            {
                return this.enableFind;
            }
            set
            {
                this.enableFind = value;
            }
        }
        #endregion //Property
    }
}
