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
    /// 搬运入库任务业务类
    /// </summary>
    public class CarryInTaskBusiness : AbstractBusiness<CarryInTask, string>, IBaseBL<CarryInTask, string>
    {
        #region Method
        /// <summary>
        /// 由入库单添加搬运入库任务
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="stockInTask">入库任务对象</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, CarryInTask t) CreateByStockIn(CarryInTask entity, StockInTaskView stockInTask, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            var checkUser = db.Queryable<User>().InSingle(entity.CheckUserId);

            entity.Id = Guid.NewGuid().ToString();
            entity.CustomerId = stockInTask.CustomerId;
            entity.ContractId = stockInTask.ContractId;
            entity.CargoId = stockInTask.CargoId;

            entity.CreateTime = DateTime.Now;
            entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", entity.CreateTime);
            entity.CheckTime = DateTime.Now;
            entity.CheckUserName = checkUser.Name;

            entity.Status = (int)EntityStatus.StockInCheck;

            var t = db.Insertable(entity).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 接单
        /// </summary>
        /// <param name="task"></param>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Receive(CarryInTask task, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.ReceiveUserId = user.Id;
            task.ReceiveUserName = user.Name;
            task.ReceiveTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInReceive;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="positionId">仓位ID</param>
        /// <param name="storeId">库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Enter(CarryInTask task, string shelfCode, int positionId, string storeId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.ShelfCode = shelfCode;
            task.PositionId = positionId;
            task.StoreId = storeId;
            task.MoveTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInEnter;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 入库完成
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trayCode"></param>
        /// <param name="moveCount"></param>
        /// <param name="moveWeight"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Finish(CarryInTask task, string trayCode, int moveCount, decimal moveWeight, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.TrayCode = trayCode;
            task.MoveCount = moveCount;
            task.MoveWeight = moveWeight;
            task.FinishTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 取消接单
        /// </summary>
        /// <param name="trayCode"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) UnReceive(CarryInTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.ReceiveUserId = 0;
            task.ReceiveUserName = "";
            task.ReceiveTime = null;
            task.Status = (int)EntityStatus.StockInCheck;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除搬运入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var carryIn = db.Queryable<CarryInTask>().InSingle(id);
            if (carryIn.Status != (int)EntityStatus.StockInCheck)
            {
                return (false, "仅能删除已清点状态的搬运入库任务");
            }

            return base.Delete(id, db);
        }

        /// <summary>
        /// 撤回搬运入库任务
        /// </summary>
        /// <param name="carryIn"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Revert(CarryInTask carryIn, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            carryIn.Status = (int)EntityStatus.StockInEnter;
            db.Updateable(carryIn).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 生成临时搬运入库任务
        /// 由搬运出库任务生成
        /// </summary>
        /// <param name="carryOutTask">搬运出库任务</param>
        /// <returns></returns>
        public static CarryInTask SetTempInTask(CarryOutTask carryOutTask)
        {
            CarryInTask task = new CarryInTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryInTaskType.Temp;
            task.CustomerId = carryOutTask.CustomerId;
            task.ContractId = carryOutTask.ContractId;
            task.CargoId = carryOutTask.CargoId;

            task.StoreId = carryOutTask.StoreId; // 暂时保存原库存ID

            task.StockOutTaskId = carryOutTask.StockOutTaskId;
            task.MoveCount = carryOutTask.StoreCount - carryOutTask.MoveCount;
            task.MoveWeight = carryOutTask.StoreWeight - carryOutTask.MoveWeight;

            task.TrayCode = carryOutTask.TrayCode;

            task.CheckUserId = carryOutTask.ReceiveUserId;
            task.CheckUserName = carryOutTask.ReceiveUserName;
            task.CreateTime = DateTime.Now;
            task.CheckTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInCheck;

            return task;
        }
        #endregion //Method
    }
}
