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
    using Phoebe.Model;

    /// <summary>
    /// 客户费用表格控件
    /// </summary>
    public partial class CustomerFeeGrid : UserControl
    {
        #region Constructor
        public CustomerFeeGrid()
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
            this.bsFee.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public CustomerFee GetCurrentSelect()
        {
            int rowIndex = this.dgvFee.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsFee.Count)
                return null;
            else
                return this.bsFee[rowIndex] as CustomerFee;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcFee.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvFee.ShowPrintPreview();
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<CustomerFee> DataSource
        {
            get
            {
                return this.bsFee.DataSource as List<CustomerFee>;
            }
            set
            {
                this.dgvFee.BeginDataUpdate();
                this.bsFee.DataSource = value;
                this.dgvFee.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
