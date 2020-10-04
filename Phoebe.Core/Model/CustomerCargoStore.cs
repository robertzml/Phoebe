using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Model
{
    /// <summary>
    /// 客户货品库存
    /// </summary>
    public class CustomerCargoStore
    {
        #region Property
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
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }

        /// <summary>
        /// 货品ID
        /// </summary>
        public string CargoId { get; set; }      
        
        /// <summary>
        /// 货品名称
        /// </summary>
        public string CargoName { get; set; }

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
        /// 批次
        /// </summary>
        public string Batch { get; set; }

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
        /// 资产价格(元)
        /// </summary>
        public decimal AssetAmount { get; set; }
        #endregion //Property
    }
}
