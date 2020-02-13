using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Phoebe.Base.Framework
{
    using Phoebe.Common;

    /// <summary>
    /// 抽象业务类
    /// </summary>
    public class AbstractService
    {
        #region Function
        protected SqlSugarClient GetInstance()
        {
            var cs = Cache.Instance.Get("ConnectionString").ToString();

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = cs,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            return db;
        }
        #endregion //Function
    }
}
