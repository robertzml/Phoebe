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
                    Store store = new Store();
                    store.Id = Guid.NewGuid();
                    item.NewStoreId = store.Id;
                    store.CargoId = item.CargoId;
                    store.WarehouseNumber = item.NewWarehouseNumber;
                    store.TotalCount = item.MoveCount;
                    store.StoreCount = store.TotalCount;
                    store.TotalWeight = item.MoveWeight;
                    store.StoreWeight = store.TotalWeight;
                    store.TotalVolume = item.MoveVolume;
                    store.StoreVolume = store.TotalVolume;
                    store.InTime = item.InTime;
                    store.MoveTime = entity.MoveTime;
                    store.Specification = item.Specification;
                    store.OriginPlace = item.OriginPlace;
                    store.ShelfLife = item.ShelfLife;
                    store.Source = (int)SourceType.StockMove;
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
        #endregion //Method
    }
}
