using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 客户业务类
    /// </summary>
    public class CustomerBusiness : AbstractBusiness<Customer, int>, IBaseBL<Customer, int>
    {
        #region Method
        /// <summary>
        /// 创建客户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Customer t) Create(Customer entity)
        {
            try
            {
                var db = GetInstance();
                var count = db.Queryable<Customer>().Count(r => r.Number == entity.Number);
                if (count > 0)
                {
                    return (false, "代码重复", null);
                }

                var t = db.Insertable(entity).ExecuteReturnEntity();
                return (true, "", t);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }
        #endregion //Method
    }
}
