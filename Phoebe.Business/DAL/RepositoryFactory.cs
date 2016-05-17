using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Common;

    /// <summary>
    /// Repository工厂类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryFactory<T> where T : SqlDataAccess<Phoebe.Model.PhoebeContext>
    {
        #region Field
        /// <summary>
        /// 数据访问类缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Property
        public static T Instance
        {
            get
            {
                string cacheKey = typeof(T).FullName;
                T bll = (T)objCache[cacheKey];　 //从缓存读取  
                if (bll == null)
                {
                    lock (syncRoot)
                    {
                        if (bll == null)
                        {
                            bll = Reflect<T>.Create(typeof(T).FullName, typeof(T).Assembly.GetName().Name); //反射创建，并缓存
                            objCache.Add(cacheKey, bll);
                        }
                    }
                }
                return bll;
            }
        }
        #endregion //Property
    }
}
