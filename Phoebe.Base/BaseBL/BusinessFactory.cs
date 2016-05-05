using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Phoebe.Base
{
    /// <summary>
    /// 业务工厂类
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
                string CacheKey = typeof(T).FullName;
                T bll = (T)objCache[CacheKey];　 //从缓存读取  
                if (bll == null)
                {
                    lock (syncRoot)
                    {
                        if (bll == null)
                        {
                            string filePath = typeof(T).Assembly.GetName().Name;
                            Assembly assemblyObj = Assembly.Load(filePath);
                            if (assemblyObj == null)
                            {
                                throw new ArgumentNullException("sFilePath", string.Format("无法加载sFilePath 的程序集"));
                            }

                            bll = (T)assemblyObj.CreateInstance(typeof(T).FullName); //反射创建  

                            objCache.Add(typeof(T).FullName, bll);
                        }
                    }
                }
                return bll;
            }
        }
        #endregion //Property
    }
}
