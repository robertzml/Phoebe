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
    using DevExpress.XtraPrinting;
    using Phoebe.Base;
    using Phoebe.Common;
    using Phoebe.Model;

    /// <summary>
    /// 费用日报表表格控件
    /// </summary>
    public partial class DailyFeeGrid : UserControl
    {
        #region Constructor
        public DailyFeeGrid()
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
            this.bsDailyFee.Clear();
        }

        /// <summary>
        /// 获取选中数据
        /// </summary>
        /// <returns></returns>
        public DailyFee GetCurrentSelect()
        {
            int rowIndex = this.dgvDaily.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsDailyFee.Count)
                return null;
            else
                return this.bsDailyFee[rowIndex] as DailyFee;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        public void PrintPriview()
        {
            if (!this.dgcDaily.IsPrintingAvailable)
            {
                MessageUtil.ShowClaim("打印程序出错");
                return;
            }

            // Open the Preview window.
            this.dgvDaily.ShowPrintPreview();
        }
        #endregion //Method

        #region Event
        private void dgvDaily_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "费用日报表", DateTime.Now.ToShortDateString() });
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
        public List<DailyFee> DataSource
        {
            get
            {
                return this.bsDailyFee.DataSource as List<DailyFee>;
            }
            set
            {
                this.dgvDaily.BeginDataUpdate();
                this.bsDailyFee.DataSource = value;
                this.dgvDaily.EndDataUpdate();
            }
        }
        #endregion //Property
    }
}
