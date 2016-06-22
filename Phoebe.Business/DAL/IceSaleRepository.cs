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

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<IceSale> Find(Expression<Func<IceSale, bool>> predicate)
        {
            return this.context.IceSales.Where(predicate);
        }

        /// <summary>
        /// 查找所有记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IceSale> FindAll()
        {
            return this.context.IceSales;
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
