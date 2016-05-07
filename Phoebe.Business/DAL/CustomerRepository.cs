using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 客户Repository
    /// </summary>
    public class CustomerRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Customer>
    {
        #region Field

        #endregion //Field

        #region Constructor
        public CustomerRepository()
        {
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有客户
        /// </summary>
        /// <returns></returns>
        public List<Customer> FindAll()
        {
            return this.context.Customers.ToList();
        }

        /// <summary>
        /// 根据ID查找客户
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Customer FindById(object id)
        {
            return this.context.Customers.Find(id);
        }
        #endregion //Method

    }
}
