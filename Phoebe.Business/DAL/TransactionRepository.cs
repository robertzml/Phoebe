using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 事务操作Repository
    /// </summary>
    public class TransactionRepository : SqlDataAccess<PhoebeContext>
    {
        #region StockIn Trans
        /// <summary>
        /// 新建入库事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <param name="billing">计费对象</param>
        /// <param name="details">入库记录对象</param>
        /// <param name="stores">库存对象</param>
        /// <returns></returns>
        public ErrorCode StockInAddTrans(StockIn stockIn, Billing billing, List<StockInDetail> details, List<Store> stores)
        {
            try
            {
                // add stock in
                this.context.StockIns.Add(stockIn);

                // add billing
                this.context.Billings.Add(billing);

                // add stores
                this.context.Stores.AddRange(stores);

                // add stock in details
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 入库确认事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <returns></returns>
        public ErrorCode StockInConfirmTrans(StockIn stockIn)
        {
            try
            {
                stockIn.Status = (int)EntityStatus.StockIn;
                stockIn.Billing.Status = (int)EntityStatus.Normal;

                foreach (var item in stockIn.StockInDetails)
                {
                    item.Status = (int)EntityStatus.StockIn;
                    item.Store.Status = (int)EntityStatus.StoreIn;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库修改事务
        /// </summary>
        /// <param name="stockIn">入库单数据</param>
        /// <param name="billing">计费数据</param>
        /// <param name="details">入库记录数据</param>
        /// <param name="stores">库存数据</param>
        /// <returns></returns>
        public ErrorCode StockInUpdateTrans(StockIn stockIn, Billing billing, List<StockInDetail> details, List<Store> stores)
        {
            try
            {
                //remove the old details and stores
                List<StockInDetail> oldDetails = new List<StockInDetail>();
                List<Store> oldStores = new List<Store>();
                foreach (var item in stockIn.StockInDetails)
                {
                    oldDetails.Add(item);
                    oldStores.Add(item.Store);
                }
                this.context.StockInDetails.RemoveRange(oldDetails);
                this.context.Stores.RemoveRange(oldStores);

                // modify stockIn and billing
                this.context.Entry(stockIn).State = EntityState.Modified;
                this.context.Entry(billing).State = EntityState.Modified;

                // add stores
                this.context.Stores.AddRange(stores);

                // add stock in details
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除入库事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <param name="stores">库存对象</param>
        /// <returns></returns>
        public ErrorCode StockInDeleteTrans(StockIn stockIn, List<Store> stores)
        {
            try
            {
                // delete stock in with cascade
                this.context.StockIns.Remove(stockIn);

                // delete store
                this.context.Stores.RemoveRange(stores);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //StockIn Trans

        #region StockOut Trans
        /// <summary>
        /// 新建出库事务
        /// </summary>
        /// <param name="stockOut">出库单数据</param>
        /// <param name="details">出库记录数据</param>
        /// <returns></returns>
        public ErrorCode StockOutAddTrans(StockOut stockOut, List<StockOutDetail> details)
        {
            try
            {
                // add stock out
                this.context.StockOuts.Add(stockOut);

                // add stock out details
                this.context.StockOutDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 出库确认事务
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public ErrorCode StockOutConfirmTrans(StockOut stockOut)
        {
            try
            {
                stockOut.Status = (int)EntityStatus.StockOut;

                // change store count and status
                foreach (var item in stockOut.StockOutDetails)
                {
                    var store = item.Store;

                    if (store.StoreCount == item.Count) // all stock out
                    {
                        store.StoreCount = 0;
                        store.StoreWeight = 0;
                        store.StoreVolume = 0;
                        store.OutTime = stockOut.OutTime;
                        store.Destination = (int)DestinationType.StockOut;
                        store.Status = (int)EntityStatus.StoreOut;
                    }
                    else
                    {
                        store.StoreCount -= item.Count;
                        store.StoreWeight -= item.OutWeight;
                        store.StoreVolume -= item.OutVolume;
                    }

                    item.Status = (int)EntityStatus.StockOut;
                }

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 出库编辑事务
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <param name="details">出库记录</param>
        /// <returns></returns>
        public ErrorCode StockOutUpdateTrans(StockOut stockOut, List<StockOutDetail> details)
        {
            try
            {
                // remove old stockout details
                List<StockOutDetail> oldDetails = new List<StockOutDetail>();
                foreach (var item in stockOut.StockOutDetails)
                {
                    oldDetails.Add(item);
                }
                this.context.StockOutDetails.RemoveRange(oldDetails);

                // edit stock out
                this.context.Entry(stockOut).State = EntityState.Modified;

                // add new stock out details
                this.context.StockOutDetails.AddRange(details);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //StockOut Trans

        #region StockMove Trans
        /// <summary>
        /// 移库新增事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <param name="details">移库记录</param>
        /// <param name="stores">新库存记录</param>
        /// <returns></returns>
        public ErrorCode StockMoveAddTrans(StockMove stockMove, List<StockMoveDetail> details, List<Store> stores)
        {
            try
            {
                // add stock move
                this.context.StockMoves.Add(stockMove);

                // add new stores
                this.context.Stores.AddRange(stores);

                // add stock move details
                this.context.StockMoveDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //StockMove Trans
    }
}
