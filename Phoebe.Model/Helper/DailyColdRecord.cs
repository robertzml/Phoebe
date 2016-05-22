using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 日冷藏费记录
    /// </summary>
    public class DailyColdRecord
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 单位计量
        /// </summary>
        public decimal UnitMeter { get; set; }

        /// <summary>
        /// 出入库计量
        /// </summary>
        public decimal FlowMeter { get; set; }

        /// <summary>
        ///  在库总计量
        /// </summary>
        public decimal TotalMeter { get; set; }

        /// <summary>
        /// 日冷藏费(元)
        /// </summary>
        public decimal DailyFee { get; set; }

        /// <summary>
        /// 冷藏费累计(元)
        /// </summary>
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 出入库类型
        /// </summary>
        public StockFlowType FlowType { get; set; }
    }
}
