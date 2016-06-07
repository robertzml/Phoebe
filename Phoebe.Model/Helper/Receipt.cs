using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 实时对账模型类
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public System.DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public System.DateTime EndTime { get; set; }

        /// <summary>
        /// 已结算费用
        /// </summary>
        public decimal SettleFee { get; set; }

        /// <summary>
        /// 未结算费用
        /// </summary>
        public decimal UnSettleFee { get; set; }

        /// <summary>
        /// 实付款
        /// </summary>
        public decimal PaidFee { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal DebtFee { get; set; }
    }
}
