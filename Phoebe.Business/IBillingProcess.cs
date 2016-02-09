﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 计费方法接口
    /// </summary>
    public interface IBillingProcess
    {
        /// <summary>
        /// 货品冷藏费计算
        /// </summary>
        /// <param name="cargo">货品对象</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        decimal CalculateColdPrice(Cargo cargo, DateTime start, DateTime end);

        /// <summary>
        /// 合同冷藏费计算
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        decimal CalculateContractColdPrice(Contract contract, DateTime start, DateTime end);

        /// <summary>
        /// 获取单位计量
        /// </summary>
        /// <param name="cargo">货品</param>
        /// <returns></returns>
        decimal GetUnitMeter(Cargo cargo);

        /// <summary>
        /// 获取出入库计量
        /// </summary>
        /// <param name="flow">流水记录</param>
        /// <param name="unitMeter">单位计量</param>
        /// <returns></returns>
        decimal GetFlowMeter(StockFlow flow, decimal unitMeter);

        /// <summary>
        /// 获取在库计量
        /// </summary>
        /// <param name="storage">库存记录</param>
        /// <param name="unitMeter">单位计量</param>
        /// <returns></returns>
        decimal GetStoreMeter(Storage storage, decimal unitMeter);

        /// <summary>
        /// 计算货品日冷藏费
        /// </summary>
        /// <param name="totalMeter">日总计量</param>
        /// <param name="unitPrice">单价</param>
        /// <returns></returns>
        decimal CalculateDailyFee(decimal totalMeter, decimal unitPrice);
    }
}
