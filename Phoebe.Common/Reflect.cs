using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Common
{
    /// <summary>
    /// 反射工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Reflect<T> where T : class
    {
        #region Field
        /// <summary>
        /// 缓存
        /// </summary>
        private static Hashtable objCache = new Hashtable();

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new Object();
        #endregion //Field

        #region Function
        /// <summary>
        /// 根据全名和路径构造对象
        /// </summary>
        /// <param name="name">对象全名</param>
        /// <param name="filePath">程序集路径</param>
        /// <returns></returns>
        private static T CreateInstance(string name, string filePath)
        {
            Assembly assemblyObj = Assembly.Load(filePath);
            if (assemblyObj == null)
            {
                throw new ArgumentNullException("sFilePath", string.Format("无法加载sFilePath={0} 的程序集", filePath));
            }

            T obj = (T)assemblyObj.CreateInstance(name); //反射创建 
            return obj;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static T Create(string name, string filePath)
        {
            return Create(name, filePath, true);
        }

        /// <summary>
        /// 根据参数创建对象实例
        /// </summary>
        /// <param name="name">对象全局名称</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="bCache">缓存集合</param>
        /// <returns></returns>
        public static T Create(string name, string filePath, bool bCache)
        {
            string cacheKey = name;
            T objType = null;
            if (bCache)
            {
                if (!objCache.ContainsKey(cacheKey))
                {
                    lock (syncRoot)
                    {
                        objType = CreateInstance(cacheKey, filePath);
                        objCache.Add(cacheKey, objType);//缓存数据访问对象
                    }
                }
                else
                {
                    objType = (T)objCache[cacheKey];    //从缓存读取 
                }
            }
            else
            {
                objType = CreateInstance(cacheKey, filePath);
            }

            return objType;
        }
        #endregion //Method
    }
}
