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
    /// 库存流水表格
    /// </summary>
    public partial class StockFlowGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime endDate;
        #endregion //Field

        #region Constructor
        public StockFlowGrid()
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
            this.bsStockFlow.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public StockFlow GetCurrentSelect()
        {
            int rowIndex = this.dgvStockFlow.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsStockFlow.Count)
                return null;
            else
                return this.bsStockFlow[rowIndex] as StockFlow;
        }

        /// <summary>
        /// 更新列表绑定数据显示
        /// </summary>
        public void UpdateBindingData()
        {
            this.bsStockFlow.ResetBindings(false);
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcStockFlow.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvStockFlow.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        private void dgvStockFlow_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "出入库报表", this.startDate.ToShortDateString() + " - " + this.endDate.ToShortDateString() });
            phf.Header.Font = new System.Drawing.Font(phf.Header.Font.FontFamily, 16);
            phf.Header.LineAlignment = BrickAlignment.Near;

            phf.Footer.Content.Clear();
            phf.Footer.Content.AddRange(new string[] { "", "", "打印时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });

            phf.Footer.LineAlignment = BrickAlignment.Far;
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 数据源
        /// </summary>
        [Description("数据源")]
        public List<StockFlow> DataSource
        {
            get
            {
                return this.bsStockFlow.DataSource as List<StockFlow>;
            }
            set
            {
                this.dgvStockFlow.BeginDataUpdate();
                this.bsStockFlow.DataSource = value;
                this.dgvStockFlow.EndDataUpdate();
            }
        }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }
            set
            {
                this.startDate = value;
            }

        }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
            }
        }
        #endregion //Property
    }
}
