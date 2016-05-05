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
    /// <typeparam name="T"></typeparam>
    public interface IBaseDataAccess<T> where T : class
    {
        T FindById(int id);
    }
}
