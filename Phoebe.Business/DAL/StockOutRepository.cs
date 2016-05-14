using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 出库Repository
    /// </summary>
    public class StockOutRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockOut>
    {
        #region Method
        public StockOut FindById(object id)
        {
            throw new NotImplementedException();
        }

        public StockOut FindOne(Expression<Func<StockOut, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockOut> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockOut> Find(Expression<Func<StockOut, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(StockOut entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<StockOut> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(StockOut entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockOut entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
