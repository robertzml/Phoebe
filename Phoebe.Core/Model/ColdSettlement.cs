﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Model
{
    /// <summary>
    /// 冷藏费用结算类
    /// </summary>
    public class ColdSettlement
    {
        #region Property
        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>        
        public string ContractName { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 天数
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// 冷藏费单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 总计量
        /// </summary>
        public decimal TotalMeter { get; set; }

        /// <summary>
        /// 冷藏费用
        /// </summary>
        public decimal ColdFee { get; set; }
        #endregion //Property
    }
}
