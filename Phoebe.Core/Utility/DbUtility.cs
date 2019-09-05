using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace Phoebe.Core.Utility
{
    using SqlSugar;

    /// <summary>
    /// 数据库工具类
    /// </summary>
    public static class DbUtility
    {
        #region Function
        private static SqlSugarClient GetInstance()
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

        #region Method
        /// <summary>
        /// 获取数据表列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetTables()
        {
            var db = GetInstance();
            return db.DbMaintenance.GetTableInfoList().Select(r => r.Name).OrderBy(s => s).ToList();
        }

        /// <summary>
        /// 获取字段列表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetColumns(string tableName)
        {
            var db = GetInstance();
            return db.DbMaintenance.GetColumnInfosByTableName(tableName).Select(r => r.DbColumnName).ToList();
        }
        #endregion //Method
    }
}
