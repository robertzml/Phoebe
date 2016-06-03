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
            this.dal = RepositoryFactory<CategoryRepository>.Instance;
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
        /// 获取所有二三级分类
        /// </summary>
        /// <returns></returns>
        public List<Category> GetLeafCategory()
        {
            Expression<Func<Category, bool>> predicate = r => r.Hierarchy == 2 || r.Hierarchy == 3;
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

        /// <summary>
        /// 根据编码获取分类
        /// </summary>
        /// <param name="number">分类编码</param>
        /// <returns></returns>
        public Category GetByNumber(string number)
        {
            Expression<Func<Category, bool>> predicate = r => r.Number == number;
            var data = this.dal.Find(predicate);
            if (data.Count() == 0)
                return null;
            else
                return data.First();
        }

        /// <summary>
        /// 根据编码获取分类
        /// </summary>
        /// <param name="number">分类编码</param>
        /// <param name="leafOnly">是否只获取节点编码</param>
        /// <returns></returns>
        public Category GetByNumber(string number, bool leafOnly)
        {
            if (leafOnly)
            {
                Expression<Func<Category, bool>> predicate = r => r.Number == number && (r.Hierarchy == 2 || r.Hierarchy == 3);
                var data = this.dal.Find(predicate);
                if (data.Count() == 0)
                    return null;
                else
                    return data.First();
            }
            else
            {
                return GetByNumber(number);
            }
        }

        /// <summary>
        /// 获取分类及子分类
        /// </summary>
        /// <param name="number">分类编码</param>
        /// <returns></returns>
        public List<Category> GetByParent(string number)
        {
            var parent = this.dal.FindOne(r => r.Number == number);
            if (parent == null)
            {
                return null;
            }
            else
            {
                List<Category> data = new List<Category>();

                data.Add(parent);

                var children = this.dal.Find(r => r.ParentId == parent.Id);
                data.AddRange(children);

                foreach (var item in children)
                {
                    var nc = this.dal.Find(r => r.ParentId == item.Id);
                    data.AddRange(nc);
                }

                return data;
            }
        }

        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override ErrorCode Create(Category entity)
        {
            try
            {
                if (this.dal.Find(r => r.Number == entity.Number).Count() > 0)
                {
                    return ErrorCode.DuplicateNumber;
                }

                entity.Status = 0;

                var result = this.dal.Create(entity);
                return result;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override ErrorCode Update(Category entity)
        {
            try
            {
                if (this.dal.Find(r => r.Id != entity.Id && r.Number == entity.Number).Count() > 0)
                {
                    return ErrorCode.DuplicateNumber;
                }

                var result = this.dal.Update(entity);
                return result;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override ErrorCode Delete(Category entity)
        {
            try
            {
                if (this.dal.Find(r => r.ParentId == entity.Id).Count() > 0)
                    return ErrorCode.CategoryHasChild;

                if (RepositoryFactory<CargoRepository>.Instance.Find(r => r.CategoryId == entity.Id).Count() > 0)
                    return ErrorCode.CategoryHasCargo;

                this.dal.Delete(entity);

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
