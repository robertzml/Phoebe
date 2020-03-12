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
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage, CarryInTask t) CreateByStockIn(CarryInTask entity, StockInTaskView stockInTask, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            var now = DateTime.Now;           

            entity.Id = Guid.NewGuid().ToString();
            entity.Type = (int)CarryInTaskType.In;
            entity.CustomerId = stockInTask.CustomerId;
            entity.ContractId = stockInTask.ContractId;
            entity.CargoId = stockInTask.CargoId;
            entity.UnitWeight = stockInTask.UnitWeight;

            entity.CreateTime = now;
            entity.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", now);
            entity.CheckTime = now;
            entity.CheckUserId = user.Id;
            entity.CheckUserName = user.Name;

            entity.Status = (int)EntityStatus.StockInCheck;

            var t = db.Insertable(entity).ExecuteReturnEntity();
            return (true, "", t);
        }

        /// <summary>
        /// 创建放回搬运入库任务
        /// </summary>
        /// <param name="carryOutTask">搬运出库任务</param>
        /// <param name="user">清点人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 托盘未完全出清，需要创建放回任务，或者下架后直接上架
        /// </remarks>
        public (bool success, string errorMessage, CarryInTask t) CreateBack(CarryOutTask carryOutTask, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var now = DateTime.Now;

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
            task.UnitWeight = carryOutTask.UnitWeight;

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            task.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", now);
            task.TrayCode = carryOutTask.TrayCode;

            task.CheckUserId = user.Id;
            task.CheckUserName = user.Name;
            task.CreateTime = now;
            task.CheckTime = now;

            task.Status = (int)EntityStatus.StockInCheck;
            task.Remark = "";

            var t = db.Insertable(task).ExecuteReturnEntity();

            return (true, "", t);
        }

        /// <summary>
        /// 上架
        /// </summary>
        /// <param name="task">入库任务</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="positionId">仓位ID</param>
        /// <param name="storeId">库存ID</param>
        /// <param name="user"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Enter(CarryInTask task, string shelfCode, int positionId, string storeId, User user, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var now = DateTime.Now;

            task.ShelfCode = shelfCode;
            task.PositionId = positionId;
            task.StoreId = storeId;

            task.ReceiveUserId = user.Id;
            task.ReceiveUserName = user.Name;
            task.ReceiveTime = now;
            task.MoveTime = now;
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

            if (task.Type != (int)CarryInTaskType.Temp)
            {
                task.TrayCode = trayCode;
                task.MoveCount = moveCount;
                task.MoveWeight = moveWeight;
            }
            task.FinishTime = DateTime.Now;
            task.Status = (int)EntityStatus.StockInFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 删除搬运入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Delete(CarryInTask entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
           
            db.Deleteable<CarryInTask>().In(entity.Id).ExecuteCommand();
            return (true, "");
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
        /// 检查临时出库任务是否创建放回任务
        /// </summary>
        /// <param name="task"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public bool CheckHasBack(CarryOutTask task, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<CarryInTask>().Count(r => r.TrayCode == task.TrayCode && r.Status != (int)EntityStatus.StockInFinish);
            return count > 0;
        }
        #endregion //Method
    }
}
