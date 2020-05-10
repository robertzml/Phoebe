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
    using System.Linq;

    /// <summary>
    /// 库存服务类
    /// </summary>
    public class StoreService : AbstractService
    {
        #region Method
        /// <summary>
        /// 系统移动托盘
        /// </summary>
        /// <param name="positionId">原仓位ID</param>
        /// <param name="targetPositionNumber">目标仓位码</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        public (bool success, string errorMessage) MoveTray(int positionId, string targetPositionNumber, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 操作用户
                var user = db.Queryable<User>().InSingle(userId);

                PositionBusiness positionBusiness = new PositionBusiness();
                StoreBusiness storeBusiness = new StoreBusiness();
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();

                // 获取新仓位信息
                var targetPosition = positionBusiness.FindByNumber(targetPositionNumber, db);
                if (targetPosition == null)
                    return (false, "目标仓位码错误");

                if (targetPosition.Status != (int)EntityStatus.Available)
                    return (false, "目标仓位已占用");

                var testStores = storeViewBusiness.Query(r => r.PositionId == targetPosition.Id && r.Status == (int)EntityStatus.StoreIn, db);
                if (testStores.Count > 0)
                    return (false, "目标仓位有库存");

                // 获取原仓位
                var sourcePosition = positionBusiness.FindById(positionId, db);

                // 获取原仓位库存记录
                var oldStores = storeBusiness.Query(r => r.PositionId == positionId && r.Status == (int)EntityStatus.StoreIn, db);
                if (oldStores.Count == 0)
                    return (false, "仓位无库存记录");

                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();

                foreach (var oldStore in oldStores)
                {
                    // 创建下架任务
                    var carryOutResult = carryOutTaskBusiness.CreateByMove(oldStore, sourcePosition, user, db);

                    // 库存记录出库
                    storeBusiness.FinishOut(oldStore, carryOutResult.t, db);

                    // 修改原仓位状态
                    positionBusiness.UpdateStatus(sourcePosition, EntityStatus.Available, db);

                    // 创建上架任务
                    var carryInResult = carryInTaskBusiness.CreateByMove(oldStore, targetPosition, user, db);

                    // 创建新库存记录
                    var storeResult = storeBusiness.CreateByMove(oldStore, carryInResult.t, targetPosition.Id, db);

                    // 确认上架任务
                    carryInTaskBusiness.FinishMove(carryInResult.t, storeResult.t.Id, db);

                    // 修改新仓位状态
                    var shelf = db.Queryable<Shelf>().Single(r => r.Id == targetPosition.ShelfId);
                    if (shelf.Type == (int)ShelfType.Position)
                        positionBusiness.UpdateStatus(targetPosition, EntityStatus.Occupy, db);
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
        /// 删除库存记录
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 强行删除已入库的库存，包括前序、后序，及相关搬运任务。
        /// 仅该库存未出库才能删除，且不会修改对应仓位状态。
        /// </remarks>
        public (bool success, string errorMessage) DeleteStore(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 获取库存链表
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                var storeList = storeViewBusiness.GetInOrder(id, db);

                var first = storeList.First();
                var last = storeList.Last();
                if (first.StoreCount != last.StoreCount)
                {
                    return (false, "该库存记录已出库，无法删除");
                }

                // 找到最初入库任务
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                var carryInTask = carryInTaskBusiness.FindById(first.CarryInTaskId, db);
                if (string.IsNullOrEmpty(carryInTask.StockInTaskId))
                {
                    return (false, "未找到初始入库任务，无法删除");
                }

                StockInTaskBusiness stockInTaskBusiness = new StockInTaskBusiness();
                var stockInTask = stockInTaskBusiness.FindById(carryInTask.StockInTaskId, db);

                foreach (var store in storeList)
                {
                    // 删除搬运入库
                    if (!string.IsNullOrEmpty(store.CarryInTaskId))
                    {
                        db.Deleteable<CarryInTask>().In(store.CarryInTaskId).ExecuteCommand();
                    }

                    // 删除搬运出库
                    if (!string.IsNullOrEmpty(store.CarryOutTaskId))
                    {
                        db.Deleteable<CarryOutTask>().In(store.CarryOutTaskId).ExecuteCommand();
                    }

                    // 删除库存
                    db.Deleteable<Store>().In(store.Id).ExecuteCommand();
                }

                // 更新最初入库任务
                var carryIn = carryInTaskBusiness.Query(r => r.StockInTaskId == stockInTask.Id);
                if (carryIn.Count == 0)
                {
                    stockInTaskBusiness.Delete(stockInTask, db);
                }
                else
                {
                    stockInTask.InCount = carryIn.Sum(r => r.MoveCount);
                    stockInTask.InWeight = carryIn.Sum(r => r.MoveWeight);

                    stockInTaskBusiness.Update(stockInTask, db);
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
