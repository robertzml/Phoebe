using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 客户对账单
    /// </summary>
    public class AccountStatement
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 应付款
        /// </summary>
        public decimal DueFee { get; set; }

        /// <summary>
        /// 实缴款
        /// </summary>
        public decimal PaidFee { get; set; }

        /// <summary>
        /// 欠款
        /// </summary>
        public decimal DebtFee { get; set; }
    }
}
