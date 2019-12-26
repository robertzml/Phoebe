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
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库任务业务类
    /// </summary>
    public class CarryOutTaskBusiness : AbstractBusiness<CarryOutTask, string>, IBaseBL<CarryOutTask, string>
    {
        #region Function
        private bool AddTempTask(CarryOutTask outTask, Position position, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            CarryOutTask task = new CarryOutTask();
            task.Id = Guid.NewGuid().ToString();
            task.Type = (int)CarryOutTaskType.Temp;
            task.StockOutTaskId = outTask.StockOutTaskId;

            // find store
            var store = db.Queryable<Store>().Single(r => r.PositionId == position.Id && r.Status == (int)EntityStatus.StoreIn);
            if (store != null)
            {
                task.StoreId = store.Id;
                task.StoreCount = store.StoreCount;
                task.MoveCount = store.StoreCount;
                task.StoreWeight = store.StoreWeight;
                task.MoveWeight = store.StoreWeight;
            }
            else
                return false;

            return true;
        }
        #endregion //Function


        #region Method
        public (bool success, string errorMessage) Create(List<CarryOutTask> data)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // find the shelfs that should carry tray out
                var shelfCodes = data.Select(r => r.ShelfCode).Distinct();
                foreach(var shelfCode in shelfCodes)
                {
                    var vice = false;
                    var positions = db.Queryable<Position>().Where(r => r.ShelfCode == shelfCode).ToList();
                    
                    if (positions.Count == 0) // from vice side
                    {
                        positions = db.Queryable<Position>().Where(r => r.ViceShelfCode == shelfCode).ToList();
                        vice = true;
                    }

                    var shelf = db.Queryable<Shelf>().InSingle(positions.First().ShelfId);

                    if (vice)
                    {
                        var tasks = data.Where(r => r.ShelfCode == shelfCode).ToList();
                        for (int i = 0; i < shelf.Depth; i++)
                        {

                        }
                    }
                }


                db.Ado.CommitTran();
                return (true, "");
            }
            catch(Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
