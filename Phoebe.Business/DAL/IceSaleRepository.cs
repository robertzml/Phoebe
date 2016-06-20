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
    /// 冰块销售Repository
    /// </summary>
    public class IceSaleRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<IceSale>
    {
        #region Method
        public IceSale FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IceSale FindOne(Expression<Func<IceSale, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceSale> Find(Expression<Func<IceSale, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IceSale> FindAll()
        {
            throw new NotImplementedException();
        }

        public ErrorCode Create(IceSale entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<IceSale> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(IceSale entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(IceSale entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
