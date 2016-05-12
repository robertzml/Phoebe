using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 事务操作Repository
    /// </summary>
    public class TransactionRepository : SqlDataAccess<PhoebeContext>
    {
        #region Method
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

                foreach(var item in stockIn.StockInDetails)
                {
                    item.Status = (int)EntityStatus.StockIn;
                    item.Store.Status = (int)EntityStatus.StoreIn;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
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
        #endregion //Method
    }
}
