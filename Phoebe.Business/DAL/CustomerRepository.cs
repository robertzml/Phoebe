using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Base;
using Phoebe.Model;

namespace Phoebe.Business.DAL
{
    /// <summary>
    /// 客户Repository
    /// </summary>
    public class CustomerRepository : IBaseDataAccess<Customer>
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public CustomerRepository()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        public Customer FindById(int id)
        {
            return this.context.Customers.Find(id);
        }
        #endregion //Method

    }
}
