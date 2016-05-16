using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.DAL
{
    using System.Linq.Expressions;
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 用户组Repository
    /// </summary>
    public class UserGroupRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<UserGroup>
    {
        #region Method
        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public UserGroup FindById(object id)
        {
            return this.context.UserGroups.Find(id);
        }
        
        /// <summary>
        /// 查找用户组
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public UserGroup FindOne(Expression<Func<UserGroup, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有用户组
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserGroup> FindAll()
        {
            return this.context.UserGroups;
        }

        /// <summary>
        /// 按条件获取用户组
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<UserGroup> Find(Expression<Func<UserGroup, bool>> predicate)
        {
            return this.context.UserGroups.Where(predicate);
        }

        public ErrorCode Create(UserGroup entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<UserGroup> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(UserGroup entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(UserGroup entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
