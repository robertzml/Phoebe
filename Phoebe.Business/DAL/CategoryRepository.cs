using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 分类Repository
    /// </summary>
    public class CategoryRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Category>
    {
        #region Method
        /// <summary>
        /// 根据ID查找分类
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Category FindById(object id)
        {
            return this.context.Categories.Find(id);
        }

        /// <summary>
        /// 按条件查找分类
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public Category FindOne(Expression<Func<Category, bool>> predicate)
        {
            return this.context.Categories.SingleOrDefault(predicate);
        }

        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> FindAll()
        {
            return this.context.Categories;
        }

        /// <summary>
        /// 按条件查找分类
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return this.context.Categories.Where(predicate);
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity">分类实体</param>
        /// <returns></returns>
        public ErrorCode Create(Category entity)
        {
            try
            {
                if (this.context.Categories.Any(r => r.Number == entity.Number))
                {
                    return ErrorCode.DuplicateNumber;
                }

                entity.Status = 0;

                this.context.Categories.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        public ErrorCode CreateRange(List<Category> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public ErrorCode Update(Category entity)
        {
            try
            {
                if (this.context.Categories.Any(r => r.Id != entity.Id && r.Number == entity.Number))
                {
                    return ErrorCode.DuplicateNumber;
                }

                this.context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }


        public ErrorCode Delete(Category entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
