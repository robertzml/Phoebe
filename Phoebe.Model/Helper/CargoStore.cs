using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Model
{
    /// <summary>
    /// 货品库存类
    /// </summary>
    public class CargoStore
    {
        /// <summary>
        /// 库存日期
        /// </summary>
        public DateTime StorageDate { get; set; }

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
        /// 合同ID
        /// </summary>
        public int ContractId { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        public Guid CargoId { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        public string CategoryNumber { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 在库数量
        /// </summary>
        public int StoreCount { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public decimal UnitWeight { get; set; }

        /// <summary>
        /// 在库重量(吨)
        /// </summary>
        public decimal StoreWeight { get; set; }

        /// <summary>
        /// 单位体积(立方)
        /// </summary>
        public decimal UnitVolume { get; set; }

        /// <summary>
        /// 在库体积(立方)
        /// </summary>
        public decimal StoreVolume { get; set; }
    }
}
