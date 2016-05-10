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
        public ErrorCode StockInTrans(StockIn stockIn, List<StockInDetail> details, List<Store> stores)
        {
            try
            {
                // add stock in
                this.context.StockIns.Add(stockIn);

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
        #endregion //Method
    }
}
