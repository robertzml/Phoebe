using System;
using System.Collections;

namespace Phoebe.Base
{
    using Phoebe.Common;

    /// <summary>
    /// 业务工厂类
    /// </summary>
    /// <typeparam name="T">业务类</typeparam>
    public class BusinessFactory<T> where T : class
    {
        #region Field
        /// <summary>
        /// 业务类缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new Object();
        #endregion //Field

        #region Property
        /// <summary>
        /// 创建或者从缓存中获取对应业务类的实例
        /// </summary>
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
