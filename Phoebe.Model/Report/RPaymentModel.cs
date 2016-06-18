using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model.Report
{
    /// <summary>
    /// 缴费打印模型
    /// </summary>
    public class RPaymentModel
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNumber { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// 缴费金额
        /// </summary>
        public decimal PaidFee { get; set; }

        /// <summary>
        /// 缴费日期
        /// </summary>
        public DateTime PaidTime { get; set; }

        /// <summary>
        /// 缴费方式
        /// </summary>
        public string PaidType { get; set; }

        /// <summary>
        /// 大写金额
        /// </summary>
        public string Captial { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
