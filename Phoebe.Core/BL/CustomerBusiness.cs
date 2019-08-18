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
            var db = GetInstance();
            var count = db.Queryable<Customer>().Count(r => r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复", null);
            }

            return base.Create(entity);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Customer entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Customer>().Count(r => r.Id != entity.Id && r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复");
            }

            return base.Update(entity);
        }
        #endregion //Method
    }
}
