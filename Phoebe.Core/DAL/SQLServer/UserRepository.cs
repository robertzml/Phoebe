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
    /// 用户对象数据访问类
    /// </summary>
    internal class UserRepository : AbstractDALSql<User, int>, IUserRepository
    {
        #region Constructor
        /// <summary>
        /// 用户对象数据访问类
        /// </summary>
        public UserRepository() : base("User", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override User DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override User DataRowToEntity(DataRow row)
        {
            User entity = new User();
            entity.Id = Convert.ToInt32(row["Id"]);
            entity.UserName = row["UserName"].ToString();
            entity.Name = row["Name"].ToString();
            entity.Password = row["Password"].ToString();
            entity.UserGroupId = Convert.ToInt32(row["UserGroupId"]);
            entity.LastLoginTime = Convert.ToDateTime(row["LastLoginTime"]);
            entity.CurrentLoginTime = Convert.ToDateTime(row["CurrentLoginTime"]);
            entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(User entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("UserName", entity.UserName);
            table.Add("Name", entity.Name);
            table.Add("Password", entity.Password);
            table.Add("UserGroupId", entity.UserGroupId);
            table.Add("LastLoginTime", entity.LastLoginTime);
            table.Add("CurrentLoginTime", entity.CurrentLoginTime);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
