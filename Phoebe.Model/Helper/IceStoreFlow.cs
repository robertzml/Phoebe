using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 冰块库存流水类
    /// </summary>
    /// <remarks>
    /// 总流水记录
    /// </remarks>
    public class IceStoreFlow
    {
        /// <summary>
        /// 流水类型
        /// </summary>
        public int FlowType { get; set; }

        /// <summary>
        /// 流水单号
        /// </summary>
        public string FlowNumber { get; set; }

        /// <summary>
        /// 流水日期
        /// </summary>
        public DateTime FlowTime { get; set; }

        /// <summary>
        /// 冰块类型
        /// </summary>
        public int IceType { get; set; }

        /// <summary>
        /// 流水数量
        /// </summary>
        public int FlowCount { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 流水重量(kg)
        /// </summary>
        public decimal FlowWeight { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
