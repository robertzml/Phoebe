using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phoebe.FormClient
{
    using DevExpress.XtraPrinting;
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 在库总库存表格控件
    /// </summary>
    public partial class TotalStorageGrid : UserControl
    {
        #region Constructor
        public TotalStorageGrid()
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
        public TotalStorage GetCurrentSelect()
        {
            int rowIndex = this.dgvStorage.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStorage.Count)
                return null;
            else
                return this.bsStorage[rowIndex] as TotalStorage;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcStorage.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvStorage.ShowPrintPreview();
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<TotalStorage> DataSource
        {
            get
            {
                return this.bsStorage.DataSource as List<TotalStorage>;
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
