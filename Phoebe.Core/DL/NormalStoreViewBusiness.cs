using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 普通库存视图类
    /// </summary>
    public class NormalStoreViewBusiness : AbstractBusiness<NormalStoreView, string>, IBaseBL<NormalStoreView, string>
    {
        #region Query
        /// <summary>
        /// 按合同获取库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <returns></returns>
        public List<NormalStoreView> FindByContract(int contractId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<NormalStoreView>().Where(r => r.ContractId == contractId).ToList();
            return data;
        }

        /// <summary>
        /// 出库时查找库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        public List<NormalStoreView> FindForStockOut(int contractId, string cargoId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<NormalStoreView>()
                .Where(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn)
                .ToList();

            return data;
        }
        #endregion //Query
    }
}
