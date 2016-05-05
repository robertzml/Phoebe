using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Base
{
    /// <summary>
    /// 业务逻辑基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(int id)
        {
            return baseDal.FindById(id);
        }
        #endregion //Method
    }
}
