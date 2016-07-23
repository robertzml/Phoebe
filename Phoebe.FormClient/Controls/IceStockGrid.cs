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
    /// 冰块操作控件
    /// </summary>
    public partial class IceStockGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 是否能编辑
        /// </summary>
        private bool editable = true;
        #endregion //Field

        #region Constructor
        public IceStockGrid()
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

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public IceFlow GetCurrentSelect()
        {
            int rowIndex = this.dgvIce.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsIceFlow.Count)
                return null;
            else
                return this.bsIceFlow[rowIndex] as IceFlow;
        }

        /// <summary>
        /// 新增行
        /// </summary>
        /// <param name="flow">冰块流水</param>
        public void AddNew(IceFlow flow)
        {
            this.bsIceFlow.Add(flow);
            this.bsIceFlow.ResetBindings(false);
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
            if (e.Column.FieldName == "IceType")
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

        /// <summary>
        /// 是否能编辑
        /// </summary>
        [Description("是否能编辑")]
        public bool Editable
        {
            get
            {
                return this.editable;
            }
            set
            {
                this.editable = value;
            }
        }
        #endregion //Property
    }
}
