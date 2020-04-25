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
        #endregion //Method
    }
}
