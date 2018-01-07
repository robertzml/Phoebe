using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 客户费用打印模型
    /// </summary>
    public class RCustomerFeeModel
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户编码
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 期初时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 期末时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 期初欠款
        /// </summary>
        public decimal StartDebt { get; set; }

        /// <summary>
        /// 基本费用
        /// </summary>
        public decimal BaseFee { get; set; }

        /// <summary>
        /// 冷藏费用
        /// </summary>
        public decimal ColdFee { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal MiscFee { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        public decimal TotalFee { get; set; }

        /// <summary>
        /// 回收款
        /// </summary>
        public decimal ReceiveFee { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// 期末欠款
        /// </summary>
        public decimal EndDebt { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
