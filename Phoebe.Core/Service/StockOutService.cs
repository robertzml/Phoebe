using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 出库服务类
    /// </summary>
    public class StockOutService : AbstractService
    {
        #region Stock Out Service
        /// <summary>
        /// 添加出库单
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public (bool success, string errorMessage, StockOut t) AddReceipt(StockOut stockOut)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var result = stockOutBusiness.Create(stockOut, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage, result.t);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑出库单
        /// </summary>
        /// <param name="stockOut"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UpdateReceipt(StockOut stockOut)
        {
            var db = GetInstance();
            try
            {
                db.Ado.BeginTran();

                StockOutBusiness stockOutBusiness = new StockOutBusiness();
                var result = stockOutBusiness.Update(stockOut, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Stock Out Service
    }
}
