using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Phoebe.Business.DAL
{
    using Phoebe.Common;

    /// <summary>
    /// SQL数据库访问基类
    /// </summary>
    /// <typeparam name="T">EF实例类</typeparam>
    public class SqlDataAccess<T> where T : DbContext
    {
        #region Field
        protected T context;
        #endregion //Field

        #region Constructor
        public SqlDataAccess()
        {
            this.context = Reflect<T>.Create(typeof(T).FullName, typeof(T).Assembly.GetName().Name);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
