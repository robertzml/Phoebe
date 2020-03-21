using System;
using System.Collections.Generic;
using System.Linq;
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
    /// 合同服务类
    /// </summary>
    public class ContractService : AbstractService
    {
        #region Method
        /// <summary>
        /// 强制删除合同
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) ForceDelete(int id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                PositionBusiness positionBusiness = new PositionBusiness();

                // 找出在库库存记录
                var inStores = db.Queryable<Store>()
                    .Where(r => r.ContractId == id && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady))
                    .ToList();
                foreach (var item in inStores)
                {
                    // 修改相关在库库存对应仓位为可用
                    var position = db.Queryable<Position>().Single(r => r.Id == item.PositionId);
                    positionBusiness.UpdateStatus(position, EntityStatus.Available, db);
                }

                // 删除库存记录
                db.Deleteable<Store>().Where(r => r.ContractId == id).ExecuteCommand();

                // 删除普通库存记录
                db.Deleteable<NormalStore>().Where(r => r.ContractId == id).ExecuteCommand();

                // 删除搬运入库记录
                db.Deleteable<CarryInTask>().Where(r => r.ContractId == id).ExecuteCommand();

                // 删除搬运出库记录
                db.Deleteable<CarryOutTask>().Where(r => r.ContractId == id).ExecuteCommand();

                // 找出入库单
                var stockIns = db.Queryable<StockIn>().Where(r => r.ContractId == id).ToList();
                foreach (var item in stockIns)
                {
                    // 删除入库计费
                    db.Deleteable<InBilling>().Where(r => r.StockInId == item.Id).ExecuteCommand();

                    // 删除入库任务
                    db.Deleteable<StockInTask>().Where(r => r.StockInId == item.Id).ExecuteCommand();
                }
                // 删除入库单
                db.Deleteable<StockIn>().Where(r => r.ContractId == id).ExecuteCommand();

                // 找出出库单
                var stockOuts = db.Queryable<StockOut>().Where(r => r.ContractId == id).ToList();
                foreach (var item in stockOuts)
                {
                    // 删除出库任务
                    db.Deleteable<StockOutTask>().Where(r => r.StockOutId == item.Id).ExecuteCommand();
                }
                // 删除出库单
                db.Deleteable<StockOut>().Where(r => r.ContractId == id).ExecuteCommand();

                // 删除合同
                db.Deleteable<Contract>().In(id).ExecuteCommand();

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
