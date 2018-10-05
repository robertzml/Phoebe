using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Phoebe.Core.IDAL;
    using Phoebe.Core.DL;

    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness : AbstractBusiness<Category, int>, IBaseBL<Category, int>
    {
        #region Constructor
        /// <summary>
        /// 类别业务类
        /// </summary>
        public CategoryBusiness()
        {
            this.baseDal = RepositoryFactory<ICategoryRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Category> GetFirstCategory()
        {
            return this.baseDal.FindListByField("Hierarchy", 1);
        }

        /// <summary>
        /// 获取子分类
        /// </summary>
        /// <param name="parentId">所属父分类ID</param>
        /// <returns></returns>
        public IEnumerable<Category> GetChildCategory(int parentId)
        {
            return this.baseDal.FindListByField("ParentId", parentId);
        }
        #endregion //Method

        #region CRUD
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override Category Create(Category entity)
        {
            var count = this.baseDal.Count("Number", entity.Number);
            if (count != 0)
                throw new PoseidonException(ErrorCode.DuplicateNumber);

            entity.Status = 0;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override bool Update(Category entity)
        {
            var data = this.baseDal.FindOneByField("Number", entity.Number);
            if (data.Id != entity.Id)
            {
                throw new PoseidonException(ErrorCode.DuplicateNumber);
            }

            return base.Update(entity);
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="entity">分类对象</param>
        /// <returns></returns>
        public override bool Delete(Category entity)
        {
            if (this.baseDal.Count("ParentId", entity.Id) > 0)  //分类有子级
                return false;

            //if (RepositoryFactory<CargoRepository>.Instance.Find(r => r.CategoryId == entity.Id).Count() > 0)
            //    return ErrorCode.CategoryHasCargo;       

            return base.Delete(entity);
        }
        #endregion //CRUD
    }
}
