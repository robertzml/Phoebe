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
    /// 移库业务类
    /// </summary>
    public class StockMoveBusiness : BaseBusiness<StockMove>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<StockMove> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 移库业务类
        /// </summary>
        public StockMoveBusiness() : base()
        {
            this.dal = RepositoryFactory<StockMoveRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="moveTime">移库时间</param>
        /// <returns></returns>
        private string GetLastFlowNumber(DateTime moveTime)
        {
            Expression<Func<StockMove, bool>> predicate = r => r.MoveTime == moveTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    moveTime.Year, moveTime.Month.ToString().PadLeft(2, '0'), moveTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", moveTime.Year, moveTime.Month.ToString().PadLeft(2, '0'),
                    moveTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取移库月份分组
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
        /// 按月度获取移库记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<StockMove> GetByMonth(string monthTime)
        {
            Expression<Func<StockMove, bool>> predicate = r => r.MonthTime == monthTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 创建移库单
        /// </summary>
        /// <param name="entity">移库单对象</param>
        /// <param name="models">移库信息</param>
        /// <returns></returns>
        public ErrorCode Create(StockMove entity, List<StockMoveModel> models)
        {
            try
            {
                // set stock move
                entity.FlowNumber = GetLastFlowNumber(entity.MoveTime.Date);
                entity.Status = (int)EntityStatus.StockMoveReady;

                // set new store
                List<Store> newStores = new List<Store>();
                foreach (var item in models)
                {
                    var sourceStore = RepositoryFactory<StoreRepository>.Instance.FindById(item.SourceStoreId);

                    Store store = new Store();
                    store.Id = Guid.NewGuid();
                    item.NewStoreId = store.Id;
                    store.CargoId = sourceStore.CargoId;
                    store.WarehouseNumber = item.NewWarehouseNumber;
                    store.TotalCount = item.MoveCount;
                    store.StoreCount = store.TotalCount;
                    store.TotalWeight = item.MoveWeight;
                    store.StoreWeight = store.TotalWeight;
                    store.TotalVolume = item.MoveVolume;
                    store.StoreVolume = store.TotalVolume;
                    store.InTime = sourceStore.InTime;
                    store.MoveTime = entity.MoveTime;
                    store.Specification = sourceStore.Specification;
                    store.OriginPlace = sourceStore.OriginPlace;
                    store.ShelfLife = sourceStore.ShelfLife;
                    store.Source = (int)SourceType.StockMove;
                    store.UnitPrice = sourceStore.UnitPrice;
                    store.UserId = entity.UserId;
                    store.Status = (int)EntityStatus.StoreMoveReady;

                    newStores.Add(store);
                }

                // generate stock move details
                List<StockMoveDetail> details = new List<StockMoveDetail>();
                foreach (var item in models)
                {
                    StockMoveDetail detail = new StockMoveDetail();
                    detail.Id = Guid.NewGuid();
                    detail.StockMoveId = entity.Id;
                    detail.SourceStoreId = item.SourceStoreId;
                    detail.NewStoreId = item.NewStoreId;
                    detail.StoreCount = item.StoreCount;
                    detail.Count = item.MoveCount;
                    detail.MoveWeight = item.MoveWeight;
                    detail.MoveVolume = item.MoveVolume;
                    detail.IsAllMove = (item.StoreCount == item.MoveCount);
                    detail.Remark = item.Remark;
                    detail.Status = (int)EntityStatus.StockMoveReady;

                    details.Add(detail);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockMoveAddTrans(entity, details, newStores);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 移库确认
        /// </summary>
        /// <param name="id">移库单ID</param>
        /// <returns></returns>
        public ErrorCode Confirm(Guid id)
        {
            try
            {
                StockMove stockMove = this.dal.FindById(id);
                if (stockMove == null)
                    return ErrorCode.ObjectNotFound;

                if (stockMove.Status == (int)EntityStatus.StockMove)
                    return ErrorCode.StockMoveHasConfirm;

                // check store count
                foreach (var item in stockMove.StockMoveDetails)
                {
                    var store = item.SourceStore;
                    if (store.StoreCount < item.Count)
                        return ErrorCode.StockMoveCountOverflow;
                }

                var trans = new TransactionRepository();
                var result = trans.StockMoveConfirmTrans(stockMove);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 移库编辑
        /// </summary>
        /// <param name="stockMove">移库单</param>
        /// <param name="models">移库数据</param>
        /// <returns></returns>
        public ErrorCode Edit(StockMove stockMove, List<StockMoveModel> models)
        {
            try
            {
                if (stockMove.Status == (int)EntityStatus.StockMove)
                    return ErrorCode.StockMoveHasConfirm;

                // set new store
                List<Store> newStores = new List<Store>();
                foreach (var item in models)
                {
                    var sourceStore = RepositoryFactory<StoreRepository>.Instance.FindById(item.SourceStoreId);

                    Store store = new Store();
                    store.Id = Guid.NewGuid();
                    item.NewStoreId = store.Id;
                    store.CargoId = sourceStore.CargoId;
                    store.WarehouseNumber = item.NewWarehouseNumber;
                    store.TotalCount = item.MoveCount;
                    store.StoreCount = store.TotalCount;
                    store.TotalWeight = item.MoveWeight;
                    store.StoreWeight = store.TotalWeight;
                    store.TotalVolume = item.MoveVolume;
                    store.StoreVolume = store.TotalVolume;
                    store.InTime = sourceStore.InTime;
                    store.MoveTime = stockMove.MoveTime;
                    store.Specification = sourceStore.Specification;
                    store.OriginPlace = sourceStore.OriginPlace;
                    store.ShelfLife = sourceStore.ShelfLife;
                    store.Source = (int)SourceType.StockMove;
                    store.UnitPrice = sourceStore.UnitPrice;
                    store.UserId = stockMove.UserId;
                    store.Status = (int)EntityStatus.StoreMoveReady;

                    newStores.Add(store);
                }

                //generate stock move details
                List<StockMoveDetail> details = new List<StockMoveDetail>();
                foreach (var item in models)
                {
                    StockMoveDetail detail = new StockMoveDetail();
                    detail.Id = Guid.NewGuid();
                    detail.StockMoveId = stockMove.Id;
                    detail.SourceStoreId = item.SourceStoreId;
                    detail.NewStoreId = item.NewStoreId;
                    detail.StoreCount = item.StoreCount;
                    detail.Count = item.MoveCount;
                    detail.MoveWeight = item.MoveWeight;
                    detail.MoveVolume = item.MoveVolume;
                    detail.IsAllMove = (item.StoreCount == item.MoveCount);
                    detail.Remark = item.Remark;
                    detail.Status = (int)EntityStatus.StockMoveReady;

                    details.Add(detail);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockMoveUpdateTrans(stockMove, details, newStores);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除移库
        /// </summary>
        /// <param name="id">移库单ID</param>
        /// <returns></returns>
        public ErrorCode Delete(Guid id)
        {
            try
            {
                StockMove stockMove = this.dal.FindById(id);

                if (stockMove == null)
                    return ErrorCode.ObjectNotFound;

                if (stockMove.Status == (int)EntityStatus.StockMove)
                    return ErrorCode.StockMoveCannotDelete;

                // find store
                List<Store> storeList = new List<Store>();
                foreach (var item in stockMove.StockMoveDetails)
                {
                    storeList.Add(item.NewStore);
                }

                var trans = new TransactionRepository();
                ErrorCode result = trans.StockMoveDeleteTrans(stockMove, storeList);

                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 移库撤回
        /// </summary>
        /// <param name="id">移库单ID</param>
        /// <returns></returns>
        public ErrorCode Revert(Guid id)
        {
            try
            {
                StockMove stockMove = this.dal.FindById(id);

                if (stockMove == null)
                    return ErrorCode.ObjectNotFound;

                if (stockMove.Status != (int)EntityStatus.StockMove)
                    return ErrorCode.StockMoveCannotRevert;

                foreach (var item in stockMove.StockMoveDetails)
                {
                    // check source store
                    var sourceStore = item.SourceStore;

                    if (RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StoreId == sourceStore.Id && r.StockOut.OutTime >= stockMove.MoveTime).Count() > 0)
                        return ErrorCode.StockMoveCannotRevert;
                    if (RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.SourceStoreId == sourceStore.Id && string.Compare(r.StockMove.FlowNumber, stockMove.FlowNumber) > 0).Count() > 0)
                        return ErrorCode.StockMoveCannotRevert;

                    // check new store
                    var newStore = item.NewStore;
                    if (RepositoryFactory<StockOutDetailsRepository>.Instance.Find(r => r.StoreId == newStore.Id && r.StockOut.OutTime >= stockMove.MoveTime).Count() > 0)
                        return ErrorCode.StockMoveCannotRevert;
                    if (RepositoryFactory<StockMoveDetailsRepository>.Instance.Find(r => r.SourceStoreId == newStore.Id && string.Compare(r.StockMove.FlowNumber, stockMove.FlowNumber) > 0).Count() > 0)
                        return ErrorCode.StockMoveCannotRevert;
                }

                var trans = new TransactionRepository();
                var result = trans.StockMoveRevertTrans(stockMove);

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
