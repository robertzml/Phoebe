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
    /// 结算详细Repository
    /// </summary>
    public class SettlementDetailsRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<SettlementDetail>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public SettlementDetail FindById(object id)
        {
            return this.context.SettlementDetails.Find(id);
        }

        public SettlementDetail FindOne(Expression<Func<SettlementDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SettlementDetail> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据条件查找
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<SettlementDetail> Find(Expression<Func<SettlementDetail, bool>> predicate)
        {
            return this.context.SettlementDetails.Where(predicate);
        }

        public ErrorCode Create(SettlementDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<SettlementDetail> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(SettlementDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(SettlementDetail entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
