using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 基本费用结算类
    /// </summary>
    public class BaseSettlement
    {
        /// <summary>
        /// 合同ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>        
        public string ContractName { get; set; }

        /// <summary>
        /// 入库单ID
        /// </summary>
        public Guid StockInId { get; set; }

        /// <summary>
        /// 产生日期
        /// </summary>
        public DateTime TakeTime { get; set; }

        /// <summary>
        /// 冷藏费单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 装卸费单价
        /// </summary>
        public decimal HandlingUnitPrice { get; set; }

        /// <summary>
        /// 装卸费
        /// </summary>
        public decimal HandlingPrice { get; set; }

        /// <summary>
        /// 结冻费单价
        /// </summary>
        public decimal FreezeUnitPrice { get; set; }

        /// <summary>
        /// 结冻费
        /// </summary>
        public decimal FreezePrice { get; set; }

        /// <summary>
        /// 处置费
        /// </summary>
        public decimal DisposePrice { get; set; }

        /// <summary>
        /// 包装费
        /// </summary>
        public decimal PackingPrice { get; set; }

        /// <summary>
        /// 租赁费
        /// </summary>
        public decimal RentPrice { get; set; }

        /// <summary>
        /// 其它费用
        /// </summary>
        public decimal OtherPrice { get; set; }

        /// <summary>
        /// 费用合计
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
