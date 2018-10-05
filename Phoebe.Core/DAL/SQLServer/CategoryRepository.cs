using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Core.DAL.SQLServer
{
    using Poseidon.Base.Framework;
    using Poseidon.Data;
    using Phoebe.Core.DL;
    using Phoebe.Core.IDAL;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// 类别对象数据访问类
    /// </summary>
    internal class CategoryRepository : AbstractDALSql<Category, int>, ICategoryRepository
    {
        #region Constructor
        /// <summary>
        /// 类别对象数据访问类
        /// </summary>
        public CategoryRepository() : base("Category", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Category DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Category DataRowToEntity(DataRow row)
        {
            Category entity = new Category();
            entity.Id = Convert.ToInt32(row["Id"]);
            entity.Name = row["Name"].ToString();
            entity.Number = row["Number"].ToString();
            if (row["ParentId"] == DBNull.Value)
                entity.ParentId = null;
            else
                entity.ParentId = Convert.ToInt32(row["ParentId"]);

            entity.Hierarchy = Convert.ToInt32(row["Hierarchy"]);
            entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Category entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("Name", entity.Name);
            table.Add("Number", entity.Number);
            table.Add("ParentId", entity.ParentId);
            table.Add("Hierarchy", entity.Hierarchy);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
