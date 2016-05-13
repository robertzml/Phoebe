using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 用户Repository
    /// </summary>
    public class UserRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<User>
    {
        #region Method
        /// <summary>
        /// 根据ID查找用户
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public User FindById(object id)
        {
            return this.context.Users.Find(id);
        }

        /// <summary>
        /// 根据条件查找用户
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public User FindOne(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> FindAll()
        {
            return this.context.Users;
        }

        /// <summary>
        /// 按条件查找用户
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return this.context.Users.Where(predicate);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户对象</param>
        /// <returns></returns>
        public ErrorCode Create(User entity)
        {
            try
            {
                entity.Status = 0;

                if (this.context.Users.Any(r => r.UserName == entity.UserName))
                    return ErrorCode.DuplicateName;

                this.context.Users.Add(entity);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        public ErrorCode CreateRange(List<User> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="entity">用户对象</param>
        /// <returns></returns>
        public ErrorCode Update(User entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        public ErrorCode Delete(User entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
