using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;

    /// <summary>
    /// 入库业务类
    /// </summary>
    public class StockInService : AbstractService
    {
        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockIn t) AddReceipt(StockIn stockIn)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockInBusiness stockInBusiness = new StockInBusiness();
                var result = stockInBusiness.Insert(stockIn, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage, result.t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }
    }
}
