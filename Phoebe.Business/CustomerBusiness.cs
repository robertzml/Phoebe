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
    /// 客户类
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
        #region GroupCustomer
        /// <summary>
        /// 获取所有团体客户
        /// </summary>
        /// <returns></returns>
        public List<GroupCustomer> GetGroupCustomer()
        {
            return this.context.GroupCustomers.ToList();
        }

        /// <summary>
        /// 获取团体客户
        /// </summary>
        /// <param name="id">客户ID</param>
        /// <returns></returns>
        public GroupCustomer GetGroupCustomer(int id)
        {
            return this.context.GroupCustomers.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// 添加团体客户
        /// </summary>
        /// <param name="data">团体客户数据</param>
        /// <returns></returns>
        public ErrorCode CreateGroupCustomer(GroupCustomer data)
        {
            try
            {
                this.context.GroupCustomers.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑团体客户
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ErrorCode EditGroupCustomer(GroupCustomer data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //GroupCustomer


        #region ScatterCustomer
        /// <summary>
        /// 获取所有零散客户
        /// </summary>
        /// <returns></returns>
        public List<ScatterCustomer> GetScatterCustomer()
        {
            return this.context.ScatterCustomers.ToList();
        }

        /// <summary>
        /// 获取零散客户
        /// </summary>
        /// <param name="id">客户ID</param>
        /// <returns></returns>
        public ScatterCustomer GetScatterCustomer(int id)
        {
            return this.context.ScatterCustomers.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// 添加零散客户
        /// </summary>
        /// <param name="data">零散客户数据</param>
        /// <returns></returns>
        public ErrorCode CreateScatterCustomer(ScatterCustomer data)
        {
            try
            {
                this.context.ScatterCustomers.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑零散客户
        /// </summary>
        /// <param name="data">零散客户数据</param>
        /// <returns></returns>
        public ErrorCode EditScatterCustomer(ScatterCustomer data)
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
        #endregion //ScatterCustomer

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
