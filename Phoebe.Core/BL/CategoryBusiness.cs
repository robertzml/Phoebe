using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness : AbstractBusiness<Category, int>, IBaseBL<Category, int>
    {
        #region Method
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetFirstCategory()
        {
            var db = GetInstance();
            return db.Queryable<Category>().Where(r => r.Hierarchy == 1).ToList();
        }

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="parentId">所属父分类ID</param>
        /// <returns></returns>
        public List<Category> GetChildCategory(int parentId)
        {
            var db = GetInstance();
            return db.Queryable<Category>().Where(r => r.ParentId == parentId).ToList();
        }
        #endregion //Method
    }
}
