﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Base.Framework
{
    using SqlSugar;

    /// <summary>
    /// 基础业务接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="Tkey">主键类型</typeparam>
    public interface IBaseBL<T, Tkey> where T : IBaseEntity<Tkey>
    {
        /// <summary>
        /// 根据ID查找对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T FindById(Tkey id, SqlSugarClient db = null);

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        T FindOneByField<Tvalue>(string field, Tvalue value, SqlSugarClient db = null);

        /// <summary>
        /// 查找所有对象
        /// </summary>
        /// <returns></returns>
        List<T> FindAll(SqlSugarClient db = null);

        /// <summary>
        /// 根据某一字段查找对象
        /// </summary>
        /// <typeparam name="Tvalue">值类型</typeparam>
        /// <param name="field">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        List<T> FindListByField<Tvalue>(string field, Tvalue value, SqlSugarClient db = null);

        /// <summary>
        /// 查找所有记录数量
        /// </summary>
        /// <returns></returns>
        long Count(SqlSugarClient db = null);

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        (bool success, string errorMessage, T t) Create(T entity, SqlSugarClient db = null);

        /// <summary>
        /// 编辑对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        (bool success, string errorMessage) Update(T entity, SqlSugarClient db = null);

        /// <summary>
        /// 根据ID删除对象
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        (bool success, string errorMessage) Delete(Tkey id, SqlSugarClient db = null);
    }
}
