﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    /// <summary>
    /// 出库计费视图业务类
    /// </summary>
    public class OutBillingViewBusiness : AbstractBusiness<OutBillingView, string>, IBaseBL<OutBillingView, string>
    {
        #region Method
        /// <summary>
        /// 查找出库单对应计费
        /// </summary>
        /// <param name="stockOutId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<OutBillingView> FindByStockOut(string stockOutId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<OutBillingView>().Where(r => r.StockOutId == stockOutId).ToList();
        }

        /// <summary>
        /// 获取一段时间内的出库费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<OutBillingView> FindPeriod(int contractId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<OutBillingView>()
                .Where(r => r.ContractId == contractId && r.OutTime >= startTime && r.OutTime <= endTime)
                .OrderBy(r => r.OutTime)
                .ToList();

            return data;
        }

        /// <summary>
        /// 获取一段时间内的出库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<OutBillingView> FindPeriodByCustomer(int customerId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<OutBillingView>()
                .Where(r => r.CustomerId == customerId && r.OutTime >= startTime && r.OutTime <= endTime)
                .OrderBy(r => r.OutTime)
                .ToList();

            return data;
        }
        #endregion //Method
    }
}
