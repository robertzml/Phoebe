using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 库存视图业务类
    /// </summary>
    public class StoreViewBusiness : AbstractBusiness<StoreView, string>, IBaseBL<StoreView, string>
    {
        #region Method
        /// <summary>
        /// 查找在库库存
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public List<StoreView> FindStoreIn(int positionId)
        {
            var db = GetInstance();
            var data = db.Queryable<StoreView>().Where(r => r.PositionId == positionId && r.Status == (int)EntityStatus.StoreIn);
            return data.ToList();
        }

        /// <summary>
        /// 按合同获取库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<StoreView> FindByContract(int contractId, bool isStoreIn)
        {
            var db = GetInstance();
            if (isStoreIn)
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId && r.Status == (int)EntityStatus.StoreIn).ToList();
                return data;
            }
            else
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId).ToList();
                return data;
            }
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="cargoId">货品ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<StoreView> FindByCargo(string cargoId, bool isStoreIn)
        {
            var db = GetInstance();
            if (isStoreIn)
            {
                var data = db.Queryable<StoreView>().Where(r => r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn).ToList();
                return data;
            }
            else
            {
                var data = db.Queryable<StoreView>().Where(r => r.CargoId == cargoId).ToList();
                return data;
            }
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <param name="isStoreIn">是否限定在库</param>
        /// <returns></returns>
        public List<StoreView> FindByCargo(int contractId, string cargoId, bool isStoreIn)
        {
            var db = GetInstance();
            if (isStoreIn)
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn).ToList();
                return data;
            }
            else
            {
                var data = db.Queryable<StoreView>().Where(r => r.ContractId == contractId && r.CargoId == cargoId).ToList();
                return data;
            }
        }
        #endregion //Method
    }
}
