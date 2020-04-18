using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 费用项目业务类
    /// </summary>
    public class ExpenseItemBusiness : AbstractBusiness<ExpenseItem, int>, IBaseBL<ExpenseItem, int>
    {
        #region Method
        /// <summary>
        /// 创建费用项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, ExpenseItem t) Create(ExpenseItem entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<ExpenseItem>().Count(r => r.Code == entity.Code);
            if (count > 0)
            {
                return (false, "代码重复", null);
            }

            return base.Create(entity, db);
        }

        /// <summary>
        /// 编辑费用项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(ExpenseItem entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<ExpenseItem>().Count(r => r.Id != entity.Id && r.Code == entity.Code);
            if (count > 0)
            {
                return (false, "代码重复");
            }

            var item = db.Queryable<ExpenseItem>().InSingle(entity.Id);
            item.Name = entity.Name;
            item.Type = entity.Type;
            item.Remark = entity.Remark;

            return base.Update(item, db);
        }
        #endregion //Method
    }
}
