using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 货品业务类
    /// </summary>
    public class CargoBusiness : AbstractBusiness<Cargo, string>, IBaseBL<Cargo, string>
    {
        #region Method
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Cargo t) Create(Cargo entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<Cargo>().Count(r => r.CustomerId == entity.CustomerId && r.Name == entity.Name);
            if (count > 0)
            {
                return (false, "名称重复", null);
            }

            entity.Id = Guid.NewGuid().ToString();
            entity.RegisterTime = DateTime.Now;
            entity.Status = 0;
            return base.Create(entity, db);
        }

        /// <summary>
        /// 编辑货品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Cargo entity, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var count = db.Queryable<Cargo>().Count(r => r.Id != entity.Id && r.CustomerId == entity.CustomerId && r.Name == entity.Name);
                if (count > 0)
                {
                    return (false, "名称重复");
                }

                var cargo = db.Queryable<Cargo>().InSingle(entity.Id);
                cargo.Name = entity.Name;
                cargo.Specification = entity.Specification;
                cargo.Remark = entity.Remark;

                db.Updateable(cargo).ExecuteCommand();

                return (true, "");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
