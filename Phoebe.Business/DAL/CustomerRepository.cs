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
    /// 客户Repository
    /// </summary>
    public class CustomerRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Customer>
    {
        #region Method
        /// <summary>
        /// 根据ID查找客户
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Customer FindById(object id)
        {
            return this.context.Customers.Find(id);
        }

        public Customer FindOne(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有客户
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> FindAll()
        {
            return this.context.Customers;
        }

        /// <summary>
        /// 根据条件查找客户
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            return this.context.Customers.Where(predicate);
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="data">客户对象</param>
        /// <returns></returns>
        public ErrorCode Create(Customer entity)
        {
            try
            {
                this.context.Customers.Add(entity);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        public ErrorCode CreateRange(List<Customer> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="data">客户对象</param>
        /// <returns></returns>
        public ErrorCode Update(Customer entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="entity">客户对象</param>
        /// <returns></returns>
        public ErrorCode Delete(Customer entity)
        {
            try
            {
                this.context.Customers.Remove(entity);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
