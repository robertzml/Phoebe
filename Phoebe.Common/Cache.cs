using System;
using System.Collections;
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
        /// 存储字典
        /// </summary>
        private Hashtable hashtable = new Hashtable();

        /// <summary>
        /// 单件实例
        /// </summary>
        private static volatile Cache instance = null;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object lockHelper = new object();

        /// <summary>
        /// 实例锁变量
        /// </summary>
        private static object lockInstance = new object();
        #endregion //Field

        #region Constructor
        private Cache()
        {
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Add(string key, object value)
        {
            lock (lockHelper)
            {
                if (hashtable.ContainsKey(key))
                {
                    hashtable[key] = value;
                }
                else
                {
                    hashtable.Add(key, value);
                }
            }
        }

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (hashtable.ContainsKey(key))
            {
                return hashtable[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 移除指定项
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            lock (lockHelper)
            {
                if (hashtable.ContainsKey(key))
                {
                    hashtable.Remove(key);
                }
            }
        }

        /// <summary>
        /// 判断是否存在指定的键
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool ContainKey(string key)
        {
            return hashtable.ContainsKey(key);
        }

        /// <summary>
        /// 判断是否存在指定的值
        /// </summary>
        /// <param name="value">值</param>
        /// <returns></returns>
        public bool ContainValue(string value)
        {
            return hashtable.ContainsValue(value);
        }

        /// <summary>
        /// 获取字典中所有键
        /// </summary>
        /// <returns></returns>
        public List<string> GetKeys()
        {
            List<string> keys = new List<string>();
            foreach (string item in hashtable.Keys)
            {
                keys.Add(item);
            }

            return keys;
        }

        /// <summary>
        /// 获取字典项数量
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return hashtable.Count;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 单件实例
        /// </summary>
        public static Cache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockInstance)
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
        /// 获取索引项值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }
        #endregion //Property
    }
}
