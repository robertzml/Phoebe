using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Common
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class Cache
    {
        #region Field
        /// <summary>
        /// 字典
        /// </summary>
        private Dictionary<string, object> dict = new Dictionary<string, object>();

        /// <summary>
        /// 单件实例
        /// </summary>
        private static volatile Cache instance = null;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object lockHelper = new object();
        #endregion //Field

        #region Constructor
        private Cache()
        {
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 单件实例
        /// </summary>
        public static Cache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockHelper)
                    {
                        if (instance == null)
                        {
                            instance = new Cache();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Add(string key, object value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        /// <summary>
        /// 移除指定项
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }

        /// <summary>
        /// 判断是否存在指定的键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool ContainKey(string key)
        {
            return dict.ContainsKey(key);
        }

        /// <summary>
        /// 判断是否存在指定的值
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool ContainValue(string value)
        {
            return dict.ContainsValue(value);
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 获取索引项值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (dict.ContainsKey(key))
                    return dict[key];
                else
                    return null;
            }
            set
            {
                dict[key] = value;
            }
        }
        #endregion //Property
    }
}
