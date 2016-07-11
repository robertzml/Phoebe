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
    /// 库存盘点表格
    /// </summary>
    public partial class InventoryGrid : UserControl
    {
        #region Constructor
        public InventoryGrid()
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
            this.bsInventory.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Inventory GetCurrentSelect()
        {
            int rowIndex = this.dgvInventory.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsInventory.Count)
                return null;
            else
                return this.bsInventory[rowIndex] as Inventory;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsInventory.ResetBindings(false);
        }
        #endregion //Method

        #region Event
        private void dgvInventory_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Inventory> DataSource
        {
            get
            {
                return this.bsInventory.DataSource as List<Inventory>;
            }
            set
            {
                this.dgvInventory.BeginDataUpdate();
                this.bsInventory.DataSource = value;
                this.dgvInventory.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
