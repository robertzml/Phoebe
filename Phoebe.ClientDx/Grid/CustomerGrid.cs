using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Winform.Base;
    using Poseidon.Common;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 客户表格控件
    /// </summary>
    public partial class CustomerGrid : WinIntGrid<Customer>
    {
        #region Constructor
        public CustomerGrid()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Event
        /// <summary>
        /// 格式化数据显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEntity_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            int rowIndex = e.ListSourceRowIndex;
            if (rowIndex < 0 || rowIndex >= this.bsEntity.Count)
                return;

            if (e.Column.FieldName == "Type")
            {
                var customer = this.bsEntity[rowIndex] as Customer;
                e.DisplayText = ((CustomerType)customer.Type).DisplayName();
            }
            else if (e.Column.FieldName == "Status")
            {
                var status = (EntityStatus)e.Value;
                e.DisplayText = status.DisplayName();
            }
        }
        #endregion //Event
    }
}
