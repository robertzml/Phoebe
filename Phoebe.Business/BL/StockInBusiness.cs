using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 入库业务类
    /// </summary>
    public class StockInBusiness : BaseBusiness<StockIn>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<StockIn> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 入库业务类
        /// </summary>
        public StockInBusiness() : base()
        {
            this.dal = new StockInRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="inTime">入库时间</param>
        /// <returns></returns>
        private string GetLastFlowNumber(DateTime inTime)
        {
            Expression<Func<StockIn, bool>> predicate = r => r.InTime == inTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    inTime.Year, inTime.Month.ToString().PadLeft(2, '0'), inTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", inTime.Year, inTime.Month.ToString().PadLeft(2, '0'),
                    inTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取入库月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetMonthGroup()
        {
            var data = this.dal.FindAll().GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return data.ToArray();
        }

        /// <summary>
        /// 按月度获取入库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockIn> GetByMonth(string monthTime)
        {
            Expression<Func<StockIn, bool>> predicate = r => r.MonthTime == monthTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        [Obsolete]
        public override ErrorCode Create(StockIn entity)
        {
            return ErrorCode.NotImplement;
        }

        /// <summary>
        /// 创建入库单
        /// </summary>
        /// <param name="entity">入库对象</param>
        /// <param name="billing">计费对象</param>
        /// <param name="models">入库记录</param>
        /// <returns></returns>
        public ErrorCode Create(StockIn entity, Billing billing, List<StockInModel> models)
        {
            try
            {
                // set stock in
                entity.FlowNumber = GetLastFlowNumber(entity.InTime.Date);
                entity.Status = (int)EntityStatus.StockInReady;

                // set billing
                billing.StockInId = entity.Id;
                billing.Status = (int)EntityStatus.BillingNotInit;

                // set store
                List<Store> storeList = new List<Store>();
                foreach (var item in models)
                {
                    Store store = new Store();
                    store.Id = Guid.NewGuid();
                    item.StoreId = store.Id;
                    store.CargoId = item.CargoId;
                    store.WarehouseNumber = item.WarehouseNumber;
                    store.TotalCount = item.InCount;
                    store.StoreCount = store.TotalCount;
                    store.TotalWeight = item.InWeight;
                    store.StoreWeight = store.TotalWeight;
                    store.TotalVolume = item.InVolume;
                    store.StoreVolume = store.TotalVolume;
                    store.InTime = entity.InTime;
                    store.MoveTime = entity.InTime;
                    store.Specification = item.Specification;
                    store.OriginPlace = item.OriginPlace;
                    store.ShelfLife = item.ShelfLife;
                    store.Source = (int)SourceType.StockIn;
                    store.UserId = entity.UserId;
                    store.Status = (int)EntityStatus.StoreReady;

                    storeList.Add(store);
                }

                // generate stock in details
                List<StockInDetail> details = new List<StockInDetail>();
                foreach (var item in models)
                {
                    StockInDetail detail = new StockInDetail();
                    detail.Id = Guid.NewGuid();
                    detail.StockInId = entity.Id;
                    detail.StoreId = item.StoreId;
                    detail.Count = item.InCount;
                    detail.InWeight = item.InWeight;
                    detail.InVolume = item.InVolume;
                    detail.Remark = item.Remark;
                    detail.Status = (int)EntityStatus.StockInReady;

                    details.Add(detail);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockInAddTrans(entity, billing, details, storeList);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="id">入库单ID</param>
        /// <returns></returns>
        public ErrorCode Confirm(Guid id)
        {
            try
            {
                StockIn stockIn = this.dal.FindById(id);
                if (stockIn == null)
                    return ErrorCode.ObjectNotFound;

                if (stockIn.Status == (int)EntityStatus.StockIn)
                    return ErrorCode.StockInHasConfirm;

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockInConfirmTrans(stockIn);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库编辑
        /// </summary>
        /// <param name="entity">入库单</param>
        /// <param name="billing">计费信息</param>
        /// <param name="siModels">入库信息模型</param>
        /// <returns></returns>
        public ErrorCode Edit(StockIn entity, Billing billing, List<StockInModel> siModels)
        {
            try
            {
                if (entity.Status == (int)EntityStatus.StockIn)
                    return ErrorCode.StockInHasConfirm;

                // set store
                List<Store> stores = new List<Store>();
                foreach (var item in siModels)
                {
                    Store store = new Store();
                    store.Id = Guid.NewGuid();
                    item.StoreId = store.Id;
                    store.CargoId = item.CargoId;
                    store.WarehouseNumber = item.WarehouseNumber;
                    store.TotalCount = item.InCount;
                    store.StoreCount = store.TotalCount;
                    store.TotalWeight = item.InWeight;
                    store.StoreWeight = store.TotalWeight;
                    store.TotalVolume = item.InVolume;
                    store.StoreVolume = store.TotalVolume;
                    store.InTime = entity.InTime;
                    store.MoveTime = entity.InTime;
                    store.Specification = item.Specification;
                    store.OriginPlace = item.OriginPlace;
                    store.ShelfLife = item.ShelfLife;
                    store.Source = (int)SourceType.StockIn;
                    store.UserId = entity.UserId;
                    store.Status = (int)EntityStatus.StoreReady;

                    stores.Add(store);
                }

                // generate stock in details
                List<StockInDetail> details = new List<StockInDetail>();
                foreach (var item in siModels)
                {
                    StockInDetail detail = new StockInDetail();
                    detail.Id = Guid.NewGuid();
                    detail.StockInId = entity.Id;
                    detail.StoreId = item.StoreId;
                    detail.Count = item.InCount;
                    detail.InWeight = item.InWeight;
                    detail.InVolume = item.InVolume;
                    detail.Remark = item.Remark;
                    detail.Status = (int)EntityStatus.StockInReady;

                    details.Add(detail);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockInUpdateTrans(entity, billing, details, stores);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除入库
        /// </summary>
        /// <param name="id">入库单ID</param>
        /// <returns></returns>
        public ErrorCode Delete(Guid id)
        {
            try
            {
                StockIn stockIn = this.dal.FindById(id);
                if (stockIn == null)
                    return ErrorCode.ObjectNotFound;

                if (stockIn.Status == (int)EntityStatus.StockIn)
                    return ErrorCode.StockInCannotDelete;

                // find store
                List<Store> storeList = new List<Store>();
                foreach (var item in stockIn.StockInDetails)
                {
                    storeList.Add(item.Store);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockInDeleteTrans(stockIn, storeList);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
