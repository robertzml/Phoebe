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
        /// 获取团体客户
        /// </summary>
        /// <param name="id">客户ID</param>
        /// <returns></returns>
        public Customer Get(int id)
        {
            return this.context.Customers.SingleOrDefault(r => r.ID == id);
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
        /// 保存更新
        /// </summary>
        /// <returns></returns>
        public ErrorCode Save()
        {
            try
            {
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
