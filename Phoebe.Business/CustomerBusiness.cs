using System;
using System.Collections.Generic;
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
        #endregion //Method
    }
}
