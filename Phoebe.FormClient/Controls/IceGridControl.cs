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
    /// 冰块流水表格控件
    /// </summary>
    public partial class IceGridControl : UserControl
    {
        #region Constructor
        public IceGridControl()
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
            this.bsIceFlow.Clear();
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
            if (rowIndex < 0 || rowIndex >= this.bsIceFlow.Count)
                return;

            var iceFlow = this.bsIceFlow[rowIndex] as IceFlow;
            if (e.Column.FieldName == "FlowType")
            {
                e.DisplayText = ((IceFlowType)iceFlow.FlowType).DisplayName();
            }
            else if (e.Column.FieldName == "IceType")
            {
                e.DisplayText = ((IceType)iceFlow.IceType).DisplayName();
            }
            else if (e.Column.FieldName == "UserId")
            {
                e.DisplayText = iceFlow.User.Name;
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<IceFlow> DataSource
        {
            get
            {
                return this.bsIceFlow.DataSource as List<IceFlow>;
            }
            set
            {
                this.dgvIce.BeginDataUpdate();
                this.bsIceFlow.DataSource = value;
                this.dgvIce.EndDataUpdate();
            }
        }
        #endregion //Property

    }
}
