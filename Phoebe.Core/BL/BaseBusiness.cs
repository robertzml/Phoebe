using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Phoebe.Core.BL
{
    public class BaseBusiness
    {
        #region Function
        protected SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=localhost;Database=phoebe4;User=uphoebe;Password=uphoebe123456;",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            return db;
        }
        #endregion //Function
    }
}
