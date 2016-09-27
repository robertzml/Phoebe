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
    /// 费用期报表表格控件
    /// </summary>
    public partial class PeriodFeeGrid : UserControl
    {
        #region Field
        /// <summary>
        /// 费用开始日期
        /// </summary>
        private DateTime startDate;

        /// <summary>
        /// 费用结束日期
        /// </summary>
        private DateTime endDate;
        #endregion //Field

        #region Constructor
        public PeriodFeeGrid()
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
        public PeriodFee GetCurrentSelect()
        {
            int rowIndex = this.dgvFee.GetFocusedDataSourceRowIndex();
            if (rowIndex < 0 || rowIndex >= this.bsFee.Count)
                return null;
            else
                return this.bsFee[rowIndex] as PeriodFee;
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

        #region Event
        private void dgvFee_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4;

            PageHeaderFooter phf = e.Link.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { "", "费用期报表", this.startDate.ToShortDateString() + " - " + this.endDate.ToShortDateString() });
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
        public List<PeriodFee> DataSource
        {
            get
            {
                return this.bsFee.DataSource as List<PeriodFee>;
            }
            set
            {
                this.dgvFee.BeginDataUpdate();
                this.bsFee.DataSource = value;
                this.dgvFee.EndDataUpdate();
            }
        }

        /// <summary>
        /// 费用开始日期
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
        /// 费用结束日期
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
