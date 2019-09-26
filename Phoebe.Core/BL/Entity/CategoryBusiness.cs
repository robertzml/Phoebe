﻿using System;
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
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public override List<Category> FindAll()
        {
            var db = GetInstance();
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
        public override (bool success, string errorMessage, Category t) Create(Category entity)
        {
            var db = GetInstance();
            var count = db.Queryable<Category>().Count(r => r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复", null);
            }
            return base.Create(entity);
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Category entity)
        {
            var db = GetInstance();

            var count = db.Queryable<Category>().Count(r => r.Id != entity.Id && r.Number == entity.Number);
            if (count > 0)
            {
                return (false, "编码重复");
            }

            return base.Update(entity);
        }
        #endregion //Method
    }
}