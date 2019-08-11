using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Phoebe.Core.Entity;

namespace Phoebe.Core.BL
{
    public class CustomerBusiness : BaseBusiness
    {
        #region Method
        public List<Customer> FindAll()
        {
            var db = GetInstance();
            return db.Queryable<Customer>().ToList();
        }
        #endregion //Method
    }
}
