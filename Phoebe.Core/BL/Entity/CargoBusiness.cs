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
    /// 货品业务类
    /// </summary>
    public class CargoBusiness : AbstractBusiness<Cargo, string>, IBaseBL<Cargo, string>
    {
        #region Method
        /// <summary>
        /// 根据入库任务添加货品
        /// </summary>
        /// <param name="db"></param>
        /// <param name="stockIn">入库单</param>
        /// <param name="task">入库任务</param>
        /// <returns></returns>
        public (bool success, string errorMessage, Cargo t) Create(SqlSugarClient db, StockIn stockIn, StockInTask task)
        {
            Cargo cargo = new Cargo();
            cargo.Id = Guid.NewGuid().ToString();
            cargo.CategoryId = task.CategoryId;           
            cargo.CustomerId = stockIn.CustomerId;
            cargo.UnitWeight = task.UnitWeight;
            cargo.RegisterTime = DateTime.Now;
            cargo.Status = 0;

            var exist = db.Queryable<Cargo>()
                .Where(r => r.CategoryId == cargo.CategoryId && r.UnitWeight == cargo.UnitWeight)
                .ToList();
            if (exist.Count() == 0)
            {
                var t = db.Insertable(cargo).ExecuteReturnEntity();
                return (true, "", t);
            }
            else
            {
                return (true, "", exist.First());
            }
        }
        #endregion //Method
    }
}
