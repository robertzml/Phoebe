using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Base
{
    /// <summary>
    /// 通用数据访问接口
    /// </summary>
    /// <typeparam name="T">实体类</typeparam>
    public interface IBaseDataAccess<T> where T : class
    {
        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <returns></returns>
        List<T> FindAll();

        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(object id);
    }
}
