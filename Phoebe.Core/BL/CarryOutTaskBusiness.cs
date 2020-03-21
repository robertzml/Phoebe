using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库任务业务类
    /// </summary>
    public class CarryOutTaskBusiness : AbstractBusiness<CarryOutTask, string>, IBaseBL<CarryOutTask, string>
    {
        #region Method
        /// <summary>
        /// 由出库任务创建搬运出库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="stockOutTask"></param>
        /// <param name="store"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, CarryOutTask t) CreateByStockOut(CarryOutTask entity, StockOutTaskView stockOutTask, StoreView store, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            var now = DateTime.Now;

            entity.Id = Guid.NewGuid().ToString();
            entity.Type = (int)CarryOutTaskType.Out;
            entity.CustomerId = stockOutTask.CustomerId;
            entity.ContractId = stockOutTask.ContractId;
            entity.CargoId = stockOutTask.CargoId;
            entity.StockOutTaskId = stockOutTask.Id;
            entity.UnitWeight = stockOutTask.UnitWeight;
            entity.CreateTime = now;
            entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", now);
            entity.Status = (int)EntityStatus.StockOutReady;

            if (store.ShelfCode == entity.ShelfCode)
            {
                entity.PositionNumber = store.PositionNumber;
            }
            else
            {
                entity.PositionNumber = store.VicePositionNumber;
            }

            var t = db.Insertable(entity).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 由出库库存创建搬运出库任务
        /// </summary>
        /// <param name="entity">搬运出库任务</param>
        /// <param name="store">库存记录</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, CarryOutTask t) CreateByStockOut(CarryOutTask entity, StoreView store, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            var now = DateTime.Now;

            entity.Id = Guid.NewGuid().ToString();
            entity.Type = (int)CarryOutTaskType.Out;
            entity.CustomerId = store.CustomerId;
            entity.ContractId = store.ContractId;
            entity.CargoId = store.CargoId;
            //entity.StockOutTaskId = stockOutTask.Id;
            entity.UnitWeight = store.UnitWeight;
            entity.CreateTime = now;
            entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", now);
            entity.Status = (int)EntityStatus.StockOutReady;

            if (store.ShelfCode == entity.ShelfCode)
            {
                entity.PositionNumber = store.PositionNumber;
            }
            else
            {
                entity.PositionNumber = store.VicePositionNumber;
            }

            var t = db.Insertable(entity).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 由库存创建搬运出库任务
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="shelfCode">下货货架码</param>
        /// <param name="user">接单人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 叉车工自行下架时创建的搬运出库任务，此时已经下架
        /// </remarks>
        public (bool success, string errorMessage, CarryOutTask t) CreateByStore(StoreView store, string shelfCode, User user, SqlSugarClient db)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            var now = DateTime.Now;

            CarryOutTask entity = new CarryOutTask();
            entity.Id = Guid.NewGuid().ToString();
            entity.Type = (int)CarryOutTaskType.Temp; //先定位临时搬运
            entity.CustomerId = store.CustomerId;
            entity.ContractId = store.ContractId;
            entity.CargoId = store.CargoId;
            entity.StoreId = store.Id;
            entity.StoreCount = store.StoreCount;
            entity.MoveCount = 0;
            entity.StoreWeight = store.StoreWeight;
            entity.MoveWeight = 0;
            entity.UnitWeight = store.UnitWeight;
            entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryOutTask", now);
            entity.ShelfCode = shelfCode;
            entity.TrayCode = store.TrayCode;
            entity.PositionId = store.PositionId;

            if (store.ShelfCode == entity.ShelfCode)
                entity.PositionNumber = store.PositionNumber;
            else
                entity.PositionNumber = store.VicePositionNumber;

            entity.ReceiveUserId = user.Id;
            entity.ReceiveUserName = user.Name;
            entity.CreateTime = now;
            entity.ReceiveTime = now;
            entity.MoveTime = now;
            entity.Remark = "";
            entity.Status = (int)EntityStatus.StockOutLeave;

            var t = db.Insertable(entity).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 搬运出库任务下架
        /// </summary>
        /// <param name="task">搬运出库任务</param>
        /// <param name="shelfCode">下架货架码</param>
        /// <param name="store">库存记录</param>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 搬运出库任务已经指定，叉车工下架
        /// </remarks>
        public (bool success, string errorMessage) Leave(CarryOutTask task, string shelfCode, StoreView store, User user, SqlSugarClient db)
        {
            if (db == null)
                db = GetInstance();

            var now = DateTime.Now;

            task.ShelfCode = shelfCode;
            if (store.ShelfCode == task.ShelfCode)
                task.PositionNumber = store.PositionNumber;
            else
                task.PositionNumber = store.VicePositionNumber;

            task.ReceiveUserId = user.Id;
            task.ReceiveUserName = user.Name;
            task.ReceiveTime = now;
            task.MoveTime = now;
            task.Status = (int)EntityStatus.StockOutLeave;

            db.Updateable(task).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 搬运出库清点
        /// </summary>
        /// <param name="id">搬运出库ID</param>
        /// <param name="stockOutTaskId">出库任务ID</param>
        /// <param name="moveCount"></param>
        /// <param name="moveWeight"></param>
        /// <param name="remark"></param>
        /// <param name="user">清点人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 仓管选择搬运出库任务，设定出库数量、重量
        /// </remarks>
        public (bool success, string errorMessage) Check(string id, string stockOutTaskId, int moveCount, decimal moveWeight, string remark, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var task = db.Queryable<CarryOutTask>().InSingle(id);

            task.Type = (int)CarryOutTaskType.Out;
            task.StockOutTaskId = stockOutTaskId;
            task.MoveCount = moveCount;
            task.MoveWeight = moveWeight;
            task.Remark = remark;
            task.CheckUserId = user.Id;
            task.CheckUserName = user.Name;
            task.CheckTime = DateTime.Now;

            task.Status = (int)EntityStatus.StockOutCheck;

            db.Updateable(task).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 清点无需出库的搬运出库任务
        /// </summary>
        /// <param name="id">搬运出库ID</param>
        /// <param name="user">清点人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) CheckUnmove(string id, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var task = db.Queryable<CarryOutTask>().InSingle(id);

            task.Type = (int)CarryOutTaskType.Temp;
            task.CheckUserId = user.Id;
            task.CheckUserName = user.Name;
            task.CheckTime = DateTime.Now;

            task.Status = (int)EntityStatus.StockOutCheck;

            db.Updateable(task).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 搬运出库任务确认
        /// </summary>
        /// <param name="task"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(CarryOutTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.FinishTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockOutFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 撤回搬运出库任务
        /// </summary>
        /// <param name="task"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(CarryOutTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.FinishTime = null;
            task.Status = (int)EntityStatus.StockOutCheck;

            db.Updateable(task).UpdateColumns(r => new { r.FinishTime, r.Status }).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除搬运入库
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Delete(CarryOutTask entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            db.Deleteable<CarryOutTask>().In(entity.Id).ExecuteCommand();
            return (true, "");
        }
        #endregion //Method
    }
}
