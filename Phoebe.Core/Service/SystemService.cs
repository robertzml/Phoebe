using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Utility;
    using Phoebe.Core.BL;
    using System.Runtime.InteropServices;
    using Phoebe.Core.DL;

    /// <summary>
    /// 系统级操作
    /// </summary>
    public class SystemService : AbstractService
    {
        #region Method
        /// <summary>
        /// 修复普通库初始入库单ID
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) FixNormalStoreStockInId()
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                NormalStoreBusiness normalStoreBusiness = new NormalStoreBusiness();
                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();

                // 找出初始库存记录
                var baseStore = normalStoreBusiness.Query(r => r.PrevStoreId == null, db);

                foreach (var item in baseStore)
                {
                    var inTask = stockInTaskBusiness.Single(r => r.Id == item.StockInTaskId, db);

                    item.StockInId = inTask.StockInId;
                    db.Updateable(item).UpdateColumns(r => new { r.StockInId }).ExecuteCommand();
                }

                foreach (var store in baseStore)
                {
                    string next = store.Id;
                    while (!string.IsNullOrEmpty(next))
                    {
                        var find = normalStoreBusiness.Single(r => r.PrevStoreId == next, db);
                        if (find != null)
                        {
                            find.StockInId = store.StockInId;
                            db.Updateable(find).UpdateColumns(r => new { r.StockInId }).ExecuteCommand();

                            next = find.Id;
                        }
                        else
                            next = "";
                    }
                }

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 修复普通库初始入库时间
        /// </summary>
        /// <returns></returns>
        public (bool success, string errorMessage) FixNormalStoreInitialTime()
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                NormalStoreBusiness normalStoreBusiness = new NormalStoreBusiness();
                StockInBusiness stockInBusiness = new StockInBusiness();

                // 找出后续库存记录
                var nextStore = normalStoreBusiness.Query(r => r.PrevStoreId != null, db);

                foreach (var item in nextStore)
                {
                    var stockIn = stockInBusiness.FindById(item.StockInId, db);

                    item.InitialTime = stockIn.InTime;
                   
                    db.Updateable(item).UpdateColumns(r => new { r.InitialTime }).ExecuteCommand();
                }

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
