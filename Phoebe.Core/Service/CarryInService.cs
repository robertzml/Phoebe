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
    /// 搬运入库业务类
    /// </summary>
    public class CarryInService : AbstractService
    {
        #region Carry In Service
        /// <summary>
        /// 添加搬运入库任务
        /// </summary>
        /// <param name="carryInTask"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) AddTask(CarryInTask carryInTask)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 检查托盘是否在架上
                var trayUse = db.Queryable<StoreView>().Where(r => r.TrayCode == carryInTask.TrayCode
                    && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
                if (trayUse.Count() > 0)
                {
                    return (false, "托盘已使用");
                }

                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                carryInTask.Type = (int)CarryInTaskType.In;

                var result = carryInTaskBusiness.CreateByStockIn(carryInTask, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 搬运入库任务接单
        /// </summary>
        /// <param name="trayCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) ReceiveTask(string trayCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                var tasks = db.Queryable<CarryInTask>().Where(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck).ToList();
                if (tasks.Count == 0)
                    return (false, "该托盘无入库任务");

                var user = db.Queryable<User>().InSingle(userId);

                // 检查用户情况
                var exists = db.Queryable<CarryInTask>().Count(r => r.ReceiveUserId == user.Id && r.Status == (int)EntityStatus.StockInReceive);
                if (exists != 0)
                    return (false, "用户还有入库任务未完成");

                // 更新任务状态到接单
                CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();
                foreach (var task in tasks)
                {
                    carryInTaskBusiness.Receive(task, user, db);
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
        /// 删除搬运入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) DeleteTask(string id)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

                var result = taskBusiness.Delete(id, db);

                db.Ado.CommitTran();
                return (result.success, result.errorMessage);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Carry In Service
    }
}
