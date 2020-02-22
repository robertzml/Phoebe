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
        /// 添加下架任务
        /// </summary>
        /// <param name="tasks">搬运出库任务</param>
        /// <returns></returns>
        public (bool success, string errorMessage) AddTasks(List<CarryOutTask> data)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                if (data.Count == 0)
                {
                    return (false, "无搬运任务");
                }

                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                StoreBusiness storeBusiness = new StoreBusiness();
                StockOutTaskViewBusiness stockOutTaskViewBusiness = new StockOutTaskViewBusiness();

                var stockOutTask = stockOutTaskViewBusiness.FindById(data.First().StockOutTaskId);
                List<CarryOutTask> tempOutTasks = new List<CarryOutTask>();

                // 添加搬运出库的任务
                foreach (var task in data)
                {
                    // 找出对应库存
                    var store = storeViewBusiness.FindById(task.StoreId);

                    // 设置搬运出库任务信息
                    carryOutTaskBusiness.CreateByStockOut(task, stockOutTask, store, db);
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

                // 找出仓位对应库存
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                var stores = storeViewBusiness.FindByPosition(position.Id, db);

                // 遍历该仓位上的库存记录
                foreach (var store in stores)
                {
                    if (store.TrayCode != trayCode)
                        return (false, "托盘码与当前在库托盘不一致", null);

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
        /// 确认搬运出库任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(string id, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 获取搬运出库任务
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                var task = carryOutTaskBusiness.FindById(id);

                if (task.Status != (int)EntityStatus.StockOutCheck)
                {
                    return (false, "该任务无法完成");
                }

                // 获取确认用户
                var user = db.Queryable<User>().InSingle(userId);

                // 确认搬运出库任务
                carryOutTaskBusiness.Finish(task, db);

                // 确认库存记录已出库
                StoreBusiness storeBusiness = new StoreBusiness();
                if (string.IsNullOrEmpty(task.StockOutTaskId))
                {
                    storeBusiness.FinishOut(task.StoreId, null, db);
                }
                else
                {
                    var stockOutTask = db.Queryable<StockOutTaskView>().InSingle(task.StockOutTaskId);
                    storeBusiness.FinishOut(task.StoreId, stockOutTask.OutTime, db);
                }

                // 临时搬运出库任务需要创建对应搬运入库任务
                if (task.Type == (int)CarryOutTaskType.Temp)
                {
                    CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

                    var have = carryInTaskBusiness.CheckHasBack(task, db);
                    if (!have)
                        carryInTaskBusiness.CreateBack(task, user, db);
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

                // 删除对应库存记录
                //var store = db.Queryable<Store>().Single(r => r.Id == carryOut.StoreId);
                //store.Status = (int)EntityStatus.StoreIn;

                //db.Updateable(store).ExecuteCommand();

                // 删除搬运入库
                CarryOutTaskBusiness taskBusiness = new CarryOutTaskBusiness();
                taskBusiness.Delete(id, db);

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
