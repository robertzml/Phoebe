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
        /// 系统搬运创建的上架任务
        /// </summary>
        /// <param name="store">原库存记录</param>
        /// <param name="position">目标仓位</param>
        /// <param name="user">清点人</param>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <remarks>
        /// 系统调整托盘位置创建的上架任务，任务直接完成
        /// </remarks>
        public (bool success, string errorMessage, CarryInTask t) CreateByMove(Store store, Position position, User user, SqlSugarClient db)
        {
            var now = DateTime.Now;

            CarryInTask task = new CarryInTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryInTaskType.System;

            task.CustomerId = store.CustomerId;
            task.ContractId = store.ContractId;
            task.CargoId = store.CargoId;       

            task.MoveCount = store.StoreCount;
            task.MoveWeight = store.StoreWeight;
            task.UnitWeight = store.UnitWeight;

            SequenceRecordBusiness recordBusiness = new SequenceRecordBusiness();
            task.TaskCode = recordBusiness.GetNextSequence(db, "CarryInTask", now);
            task.TrayCode = store.TrayCode;
            task.ShelfCode = position.ShelfCode;
            task.PositionId = position.Id;

            task.CheckUserId = user.Id;
            task.CheckUserName = user.Name;
            task.ReceiveUserId = user.Id;
            task.ReceiveUserName = user.Name;

            task.CreateTime = now;
            task.CheckTime = now;
            task.ReceiveTime = now;
            task.MoveTime = now;
            task.FinishTime = now;

            task.Status = (int)EntityStatus.StockInFinish;
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
            task.FinishTime = now;
            task.Status = (int)EntityStatus.StockInFinish;

            db.Updateable(task).ExecuteCommand();

            return (true, "");
        }

        /// <summary>
        /// 完成系统移动上架
        /// </summary>
        /// <param name="task">搬运入库任务</param>
        /// <param name="storeId">新库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) FinishMove(CarryInTask task, string storeId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            task.StoreId = storeId;

            db.Updateable(task).UpdateColumns(r => new { r.StoreId }).ExecuteCommand();
            return (true, "");
        }

        /// <summary>
        /// 编辑搬运入库任务
        /// </summary>
        /// <param name="carryIn"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public (bool success, string errorMessage) Edit(CarryInTask carryIn, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var entity = db.Queryable<CarryInTask>().InSingle(carryIn.Id);

            entity.TrayCode = carryIn.TrayCode;
            entity.MoveCount = carryIn.MoveCount;
            entity.MoveWeight = carryIn.MoveWeight;
            entity.Remark = carryIn.Remark;

            db.Updateable(entity).UpdateColumns(r => new { r.TrayCode, r.MoveCount, r.MoveWeight, r.Remark }).ExecuteCommand();
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
        #endregion //Method
    }
}
