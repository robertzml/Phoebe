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
    /// 用户组对象数据访问类
    /// </summary>
    internal class UserGroupRepository : AbstractDALSql<UserGroup, int>, IUserGroupRepository
    {
        #region Constructor
        /// <summary>
        /// 用户组对象数据访问类
        /// </summary>
        public UserGroupRepository() : base("UserGroup", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override UserGroup DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override UserGroup DataRowToEntity(DataRow row)
        {
            UserGroup entity = new UserGroup();
            entity.Id = Convert.ToInt32(row["Id"]);
            entity.Name = row["Name"].ToString();
            entity.Titile = row["Title"].ToString();
            entity.Rank = Convert.ToInt32(row["Rank"]);
            entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(UserGroup entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("Name", entity.Name);
            table.Add("Title", entity.Titile);
            table.Add("Rank", entity.Rank);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
