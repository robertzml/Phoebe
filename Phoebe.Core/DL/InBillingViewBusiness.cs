using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    /// <summary>
    /// 入库计费视图业务类
    /// </summary>
    public class InBillingViewBusiness : AbstractBusiness<InBillingView, string>, IBaseBL<InBillingView, string>
    {
        #region Method
        /// <summary>
        /// 查找入库单对应计费
        /// </summary>
        /// <param name="stockInId"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<InBillingView> FindByStockIn(string stockInId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<InBillingView>().Where(r => r.StockInId == stockInId).ToList();
        }

        /// <summary>
        /// 获取一段时间内的入库费用
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <returns></returns>
        public List<InBillingView> FindPeriod(int contractId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<InBillingView>()
                .Where(r => r.ContractId == contractId && r.InTime >= startTime && r.InTime <= endTime)
                .OrderBy(r => r.InTime)
                .ToList();

            return data;
        }

        /// <summary>
        /// 获取一段时间内的入库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime">开始日期</param>
        /// <param name="endTime">结束日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<InBillingView> FindPeriodByCustomer(int customerId, DateTime startTime, DateTime endTime, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<InBillingView>()
               .Where(r => r.CustomerId == customerId && r.InTime >= startTime && r.InTime <= endTime)
               .OrderBy(r => r.InTime)
               .ToList();

            return data;
        }
        #endregion //Method
    }
}
