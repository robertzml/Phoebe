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
    /// 冰块流水Repository
    /// </summary>
    public class IceFlowRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<IceFlow>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public IceFlow FindById(object id)
        {
            return this.context.IceFlows.Find(id);
        }

        public IceFlow FindOne(Expression<Func<IceFlow, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<IceFlow> Find(Expression<Func<IceFlow, bool>> predicate)
        {
            return this.context.IceFlows.Where(predicate);
        }

        /// <summary>
        /// 获取所有流水
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IceFlow> FindAll()
        {
            return this.context.IceFlows;
        }
       
        public ErrorCode Create(IceFlow entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<IceFlow> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(IceFlow entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(IceFlow entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
