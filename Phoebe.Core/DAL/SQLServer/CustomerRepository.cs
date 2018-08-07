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
    /// 客户对象数据访问类
    /// </summary>
    internal class CustomerRepository : AbstractDALSql<Customer, int>, ICustomerRepository
    {
        #region Constructor
        /// <summary>
        /// 客户对象数据访问类
        /// </summary>
        public CustomerRepository() : base("Customer", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Customer DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Customer DataRowToEntity(DataRow row)
        {
            Customer entity = new Customer();
            entity.Id = Convert.ToInt32(row["Id"]);
            entity.Name = row["Name"].ToString();
            entity.Number = row["Number"].ToString();
            entity.Address = row["Address"].ToString();
            entity.Telephone = row["Telephone"].ToString();
            entity.Contact = row["Contact"].ToString();
            entity.ContactTelephone = row["ContactTelephone"].ToString();
            entity.Type = Convert.ToInt32(row["Type"]);
            entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Customer entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("Name", entity.Name);
            table.Add("Number", entity.Number);
            table.Add("Address", entity.Address);
            table.Add("Telephone", entity.Telephone);
            table.Add("Contact", entity.Contact);
            table.Add("ContactTelephone", entity.ContactTelephone);
            table.Add("Type", entity.Type);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
