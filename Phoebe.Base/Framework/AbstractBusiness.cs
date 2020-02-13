using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SqlSugar;

namespace Phoebe.Base.Framework
{
    using Phoebe.Common;

    /// <summary>
    /// 抽象业务类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public abstract class AbstractBusiness<T, Tkey> : IBaseBL<T, Tkey>
        where T : class, IBaseEntity<Tkey>, new()
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

        #region Method
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual T FindById(Tkey id, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            return db.Queryable<T>().InSingle(id);
        }

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual T FindOneByField<Tvalue>(string field, Tvalue value, SqlSugarClient db = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        public virtual List<T> FindAll(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            return db.Queryable<T>().ToList();
        }

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public virtual List<T> FindListByField<Tvalue>(string field, Tvalue value, SqlSugarClient db = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        public virtual long Count(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();
            return db.Queryable<T>().Count();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual (bool success, string errorMessage, T t) Create(T entity, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var t = db.Insertable(entity).ExecuteReturnEntity();
                return (true, "", t);
            }
            catch (Exception e)
            {
                return (false, e.Message, null);
            }
        }

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public virtual (bool success, string errorMessage) Update(T entity, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var result = db.Updateable(entity).ExecuteCommand();
                if (result == 1)
                    return (true, "");
                else
                    return (false, "未更新对象");
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public virtual (bool success, string errorMessage) Delete(Tkey id, SqlSugarClient db = null)
        {
            try
            {
                if (db == null)
                    db = GetInstance();

                var result = db.Deleteable<T>().In(id).ExecuteCommand();
                if (result == 1)
                {
                    return (true, "");
                }
                else
                {
                    return (false, "未删除对象");
                }
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }
        #endregion //Method
    }
}
