using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 分类业务类
    /// </summary>
    public class CategoryBusiness : BaseBusiness<Category>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Category> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 分类业务类
        /// </summary>
        public CategoryBusiness() : base()
        {
            this.dal = new CategoryRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetFirstCategory()
        {
            Expression<Func<Category, bool>> predicate = r => r.Hierarchy == 1;
            return this.dal.Find(predicate).ToList();
        }

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="parentId">所属父分类ID</param>
        /// <returns></returns>
        public List<Category> GetChildCategory(int parentId)
        {
            Expression<Func<Category, bool>> predicate = r => r.ParentId == parentId;
            return this.dal.Find(predicate).ToList();
        }
        #endregion //Method
    }
}
