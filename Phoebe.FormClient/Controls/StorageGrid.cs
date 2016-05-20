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
    /// 库存记录表格
    /// </summary>
    public partial class StorageGrid : UserControl
    {
        #region Constructor
        public StorageGrid()
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
            this.bsStorage.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public Storage GetCurrentSelect()
        {
            int rowIndex = this.dgvStorage.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStorage.Count)
                return null;
            else
                return this.bsStorage[rowIndex] as Storage;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStorage.ResetBindings(false);
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<Storage> DataSource
        {
            get
            {
                return this.bsStorage.DataSource as List<Storage>;
            }
            set
            {
                this.dgvStorage.BeginDataUpdate();
                this.bsStorage.DataSource = value;
                this.dgvStorage.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
