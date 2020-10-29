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
        /// 按出库任务获取库存
        /// </summary>
        /// <param name="stockOutTaskId">出库任务ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public NormalStoreView FindByStockOutTask(string stockOutTaskId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var store = db.Queryable<NormalStoreView>().Single(r => r.StockOutTaskId == stockOutTaskId);
            return store;
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

            List<IConditionalModel> conditions = new List<IConditionalModel>();
            conditions.Add(new ConditionalModel { FieldName = "ContractId", ConditionalType = ConditionalType.Equal, FieldValue = contractId.ToString() });
            conditions.Add(new ConditionalModel { FieldName = "Status", ConditionalType = ConditionalType.Equal, FieldValue = ((int)EntityStatus.StoreIn).ToString() });

            if (!string.IsNullOrEmpty(cargoId))
            {
                conditions.Add(new ConditionalModel { FieldName = "CargoId", ConditionalType = ConditionalType.Equal, FieldValue = cargoId });
            }

            //var data = db.Queryable<NormalStoreView>()
            //    .Where(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn)
            //    .ToList();
            var data = db.Queryable<NormalStoreView>().Where(conditions).ToList();

            return data;
        }

        /// <summary>
        /// 找放回的库存记录
        /// </summary>
        /// <param name="prevStoreId">前序库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public NormalStoreView FindNext(string prevStoreId, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<NormalStoreView>().Single(r => r.PrevStoreId == prevStoreId);

            return data;
        }
        #endregion //Query

        #region Storage
        /// <summary>
        /// 获取库存记录链表
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<NormalStoreView> GetInOrder(string id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            List<NormalStoreView> data = new List<NormalStoreView>();

            // 获取当前库存记录
            var store = db.Queryable<NormalStoreView>().InSingle(id);
            data.Add(store);

            // 查找前序记录
            string prev = store.PrevStoreId;
            while (!string.IsNullOrEmpty(prev))
            {
                var find = db.Queryable<NormalStoreView>().InSingle(prev);
                prev = find.PrevStoreId;

                data.Insert(0, find);
            }

            string next = store.Id;
            while (!string.IsNullOrEmpty(next))
            {
                var find = db.Queryable<NormalStoreView>().Single(r => r.PrevStoreId == next);
                if (find != null)
                {
                    next = find.Id;
                    data.Add(find);
                }
                else
                    next = "";
            }

            return data;
        }

        /// <summary>
        /// 获取合同指定日库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public List<NormalStoreView> GetInDay(int contractId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            date = date.Date;

            var stores = db.Queryable<NormalStoreView>()
                .Where(r => r.ContractId == contractId && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
                .ToList();

            return stores;
        }

        /// <summary>
        /// 获取客户指定日库存
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="date">日期</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<NormalStoreView> GetInDayByCustomer(int customerId, DateTime date, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            date = date.Date;

            var stores = db.Queryable<NormalStoreView>()
                .Where(r => r.CustomerId == customerId && r.InTime <= date && (r.OutTime == null || r.OutTime > date))
                .ToList();

            return stores;
        }
        #endregion //Storage
    }
}
