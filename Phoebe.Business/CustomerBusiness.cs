using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 客户业务类
    /// </summary>
    public class CustomerBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public CustomerBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有客户
        /// </summary>
        /// <returns></returns>
        public List<Customer> Get()
        {
            return this.context.Customers.ToList();
        }

        /// <summary>
        /// 获取客户
        /// </summary>
        /// <param name="id">客户ID</param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            return this.context.Customers.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// 按类型获取客户
        /// </summary>
        /// <param name="type">客户类型</param>
        /// <returns></returns>
        public List<Customer> GetByType(CustomerType type)
        {
            return this.context.Customers.Where(r => r.Type == (int)type).ToList();
        }

        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="data">客户数据</param>
        /// <returns></returns>
        public ErrorCode Create(Customer data)
        {
            try
            {
                data.Status = 0;

                this.context.Customers.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="data">客户数据</param>
        /// <returns></returns>
        public ErrorCode Edit(Customer data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ErrorCode Delete(Customer data)
        {
            try
            {
                if (this.context.Contracts.Count(r => r.CustomerID == data.ID) > 0)
                    return ErrorCode.CustomerHasContract;

                this.context.Customers.Remove(data);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
