using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.Entity;

    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness : AbstractBusiness<Category, int>, IBaseBL<Category, int>
    {
        #region Method
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public override List<Category> FindAll(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            return db.Queryable<Category>().OrderBy(r => r.Number).ToList();
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetFirstCategory()
        {
            var db = GetInstance();
            return db.Queryable<Category>().Where(r => r.Hierarchy == 1).OrderBy(s => s.Number).ToList();
        }

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="parentId">所属父分类ID</param>
        /// <returns></returns>
        public List<Category> GetChildCategory(int parentId)
        {
            var db = GetInstance();
            return db.Queryable<Category>().Where(r => r.ParentId == parentId).OrderBy(s => s.Number).ToList();
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage, Category t) Create(Category entity, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<Category>().Count(r => r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复", null);
            }
            return base.Create(entity, db);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Category category, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var count = db.Queryable<Category>().Count(r => r.Id != category.Id && r.Number == category.Number);
            if (count > 0)
            {
                return (false, "编码重复");
            }

            var entity = db.Queryable<Category>().InSingle(category.Id);
            entity.Name = category.Name;
            entity.Number = category.Number;
            entity.Remark = category.Remark;

            return base.Update(entity, db);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(int id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var lower = db.Queryable<Category>().Count(r => r.ParentId == id);
            if (lower > 0)
            {
                return (false, "仅能删除无子类别的分类");
            }

            var cargos = db.Queryable<Cargo>().Count(r => r.CategoryId == id);
            if (cargos > 0)
            {
                return (false, "有货品使用该类别");
            }

            return base.Delete(id, db);
        }
        #endregion //Method
    }
}
