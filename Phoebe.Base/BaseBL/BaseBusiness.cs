using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoebe.Base
{
    /// <summary>
    /// 业务逻辑基类
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public class BaseBusiness<T> where T : class, new()
    {
        #region Field
        /// <summary>
        /// 数据访问对象
        /// </summary>
        protected IBaseDataAccess<T> baseDal = null;
        #endregion //Field

        #region Function
        /// <summary>
        /// 初始化数据访问对象
        /// </summary>
        /// <param name="baseDal">数据访问对象</param>
        protected void Init(IBaseDataAccess<T> baseDal)
        {
            this.baseDal = baseDal;
        }
        #endregion //Function

        #region Method
        #region Read
        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <returns></returns>
        public virtual List<T> FindAll()
        {
            return this.baseDal.FindAll();
        }

        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(object id)
        {
            return this.baseDal.FindById(id);
        }
        #endregion //Read

        #region Write
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual ErrorCode Create(T entity)
        {
            return this.baseDal.Create(entity);
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual ErrorCode Update(T entity)
        {
            return this.baseDal.Update(entity);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual ErrorCode Delete(T entity)
        {
            return this.baseDal.Delete(entity);
        }
        #endregion //Write
        #endregion //Method
    }
}
