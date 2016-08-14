using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 冰块库存流水表格控件
    /// </summary>
    public partial class IceStoreFlowGrid : UserControl
    {
        #region Constructor
        public IceStoreFlowGrid()
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
            this.bsIce.Clear();
        }
        #endregion //Method

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIce_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsIce.Count)
                return;

            var iceFlow = this.bsIce[rowIndex] as IceStoreFlow;
            if (e.Column.FieldName == "FlowType")
            {
                e.DisplayText = ((IceFlowType)iceFlow.FlowType).DisplayName();
            }
            else if (e.Column.FieldName == "IceType")
            {
                e.DisplayText = ((IceType)iceFlow.IceType).DisplayName();
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<IceStoreFlow> DataSource
        {
            get
            {
                return this.bsIce.DataSource as List<IceStoreFlow>;
            }
            set
            {
                this.dgvIce.BeginDataUpdate();
                this.bsIce.DataSource = value;
                this.dgvIce.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
