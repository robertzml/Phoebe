using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.Service
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库业务类
    /// </summary>
    public class CarryOutService : AbstractService
    {
        #region Carry Out Service
        /// <summary>
        /// 出库下架
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="userId">操作人ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 叉车工自行扫码下架
        /// </remarks>
        public (bool success, string errorMessage, List<StoreView> stores) Leave(string trayCode, string shelfCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 找出最外侧占用的仓位
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindOutside(shelfCode, db);
                if (position == null)
                {
                    return (false, "未找到可用托盘", null);
                }

                // 获取叉车工用户
                UserBusiness userBusiness = new UserBusiness();
                var user = userBusiness.FindById(userId, db);

                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                StoreBusiness storeBusiness = new StoreBusiness();

                // 找出托盘对应库存
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                var stores = storeViewBusiness.FindByTray(trayCode, db);
                if (stores.Count == 0)
                    return (false, "托盘码上无库存", null);

                // 遍历该托盘上的库存记录
                foreach (var store in stores)
                {
                    if (store.PositionId != position.Id)
                    {
                        db.Ado.RollbackTran();
                        return (false, "托盘码与当前货架托盘不一致", null);
                    }
                    if (store.Status != (int)EntityStatus.StoreIn && store.Status != (int)EntityStatus.StoreInReady)
                    {
                        db.Ado.RollbackTran();
                        return (false, "托盘上无在库库存", null);
                    }

                    var carryOut = db.Queryable<CarryOutTask>().Single(r => r.StoreId == store.Id);
                    if (carryOut == null)
                    {
                        // 由库存记录创建搬运出库任务
                        var result = carryOutTaskBusiness.CreateByStore(store, shelfCode, user, db);
                        carryOut = result.t;
                    }
                    else
                    {
                        carryOutTaskBusiness.Leave(carryOut, shelfCode, store, user, db);
                    }

                    // 库存记录下架
                    storeBusiness.Leave(store.Id, carryOut.Id, db);
                }

                // 更新仓位状态
                positionBusiness.UpdateStatus(position, EntityStatus.Available, db);

                db.Ado.CommitTran();
                return (true, "", stores);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑搬运出库任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) EditTask(CarryOutTask task)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                var oldTask = carryOutTaskBusiness.FindById(task.Id, db);

                if (task.MoveCount > oldTask.StoreCount)
                {
                    return (false, "搬运数量操作库存数量");
                }

                if (oldTask.Status == (int)EntityStatus.StockOutReady)  // 搬运出库任务还未出库
                {
                    // 更新搬运出库任务
                    oldTask.MoveCount = task.MoveCount;
                    oldTask.MoveWeight = task.MoveWeight;
                    oldTask.Remark = task.Remark;
                    carryOutTaskBusiness.Update(oldTask, db);
                }
                else // 搬运出库任务已出库
                {
                    // 获取清点人
                    UserBusiness userBusiness = new UserBusiness();
                    var user = userBusiness.FindById(task.CheckUserId, db);

                    CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

                    if (oldTask.StoreCount == oldTask.MoveCount) //原来没有放回任务
                    {
                        StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                        var others = storeViewBusiness.Query(r => r.TrayCode == oldTask.TrayCode && r.Status == (int)EntityStatus.StoreIn, db);
                        if (others.Count > 0)
                            return (false, "该托盘有其它货物已经上架，无法修改出库数量");

                        // 更新搬运出库任务
                        oldTask.MoveCount = task.MoveCount;
                        oldTask.MoveWeight = task.MoveWeight;
                        oldTask.Remark = task.Remark;
                        carryOutTaskBusiness.Update(oldTask, db);

                        if (oldTask.StoreCount > oldTask.MoveCount)
                        {
                            // 创建放回任务
                            carryInTaskBusiness.CreateBack(oldTask, user, db);
                        }
                    }
                    else // 原来有放回任务
                    {
                        // 找到放回任务
                        // 放回任务未上架
                        var carryIn = carryInTaskBusiness.Single(r => r.TrayCode == oldTask.TrayCode && r.StoreId == oldTask.StoreId && r.Status == (int)EntityStatus.StockInCheck, db);

                        if (carryIn == null) // 放回任务已上架
                        {
                            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                            var newStore = storeViewBusiness.Single(r => r.PrevStoreId == oldTask.StoreId, db);

                            if (newStore.Status != (int)EntityStatus.StoreIn)
                                return (false, "放回库存已出库，无法修改");

                            carryIn = carryInTaskBusiness.Single(r => r.StoreId == newStore.Id, db);
                        }

                        // 更新搬运出库任务
                        oldTask.MoveCount = task.MoveCount;
                        oldTask.MoveWeight = task.MoveWeight;
                        oldTask.Remark = task.Remark;
                        carryOutTaskBusiness.Update(oldTask, db);

                        carryIn.MoveCount = oldTask.StoreCount - oldTask.MoveCount;
                        carryIn.MoveWeight = oldTask.StoreWeight - oldTask.MoveWeight;

                        if (carryIn.MoveCount > 0)
                        {
                            // 更新搬运入库任务和库存记录
                            carryInTaskBusiness.Update(carryIn, db);

                            StoreBusiness storeBusiness = new StoreBusiness();
                            var store = storeBusiness.FindById(carryIn.StoreId, db);
                            store.StoreCount = carryIn.MoveCount;
                            store.StoreWeight = carryIn.MoveWeight;

                            storeBusiness.Update(store, db);
                        }
                        else // 需要删除搬运入库任务和库存记录
                        {
                            if (carryIn.Status == (int)EntityStatus.StockInFinish)
                            {
                                StoreBusiness storeBusiness = new StoreBusiness();
                                storeBusiness.Delete(carryIn.StoreId, db);

                                // 更新仓位状态
                                PositionBusiness positionBusiness = new PositionBusiness();
                                var position = positionBusiness.FindById(carryIn.PositionId, db);

                                var stores = storeBusiness.Query(r => r.Status == (int)EntityStatus.StoreIn && r.PositionId == position.Id, db);
                                if (stores.Count == 0)
                                    positionBusiness.UpdateStatus(position, EntityStatus.Available, db);
                            }
                            carryInTaskBusiness.Delete(carryIn.Id, db);
                        }
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
        /// 删除搬运出库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteTask(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                var carryOut = carryOutTaskBusiness.FindById(id, db);
                if (carryOut.Status != (int)EntityStatus.StockOutReady)
                {
                    return (false, "仅能删除待出库状态的搬运出库任务");
                }

                // 删除搬运入库
                carryOutTaskBusiness.Delete(carryOut, db);

                db.Ado.CommitTran();
                return (true, "");
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Carry Out Servie
    }
}
