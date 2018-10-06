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
    /// 合同对象数据访问类
    /// </summary>
    internal class ContractRepository : AbstractDALSql<Contract, int>, IContractRepository
    {
        #region Constructor
        /// <summary>
        /// 合同对象数据访问类
        /// </summary>
        public ContractRepository() : base("Contract", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Contract DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Contract DataRowToEntity(DataRow row)
        {
            Contract entity = new Contract();
            entity.Id = Convert.ToInt32(row["Id"]);
            entity.Name = row["Name"].ToString();
            entity.Number = row["Number"].ToString();
            entity.CustomerId = Convert.ToInt32(row["CustomerId"]);
            entity.Type = Convert.ToInt32(row["Type"]);
            entity.SignDate = Convert.ToDateTime(row["SignDate"]);

            if (row["CloseDate"] == DBNull.Value)
                entity.CloseDate = null;
            else
                entity.CloseDate = Convert.ToDateTime(row["CloseDate"]);

            entity.BillingType = Convert.ToInt32(row["BillingType"]);

            if (row["Parameter1"] == DBNull.Value)
                entity.Parameter1 = null;
            else
                entity.Parameter1 = row["Parameter1"].ToString();

            if (row["Parameter2"] == DBNull.Value)
                entity.Parameter2 = null;
            else
                entity.Parameter2 = row["Parameter2"].ToString();

            if (row["Parameter3"] == DBNull.Value)
                entity.Parameter3 = null;
            else
                entity.Parameter3 = row["Parameter3"].ToString();

            entity.UserId = Convert.ToInt32(row["UserId"]);
            entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Contract entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("Name", entity.Name);
            table.Add("Number", entity.Number);
            table.Add("CustomerId", entity.CustomerId);
            table.Add("Type", entity.Type);
            table.Add("SignDate", entity.SignDate);
            table.Add("CloseDate", entity.CloseDate);
            table.Add("BillingType", entity.BillingType);
            table.Add("Parameter1", entity.Parameter1);
            table.Add("Parameter2", entity.Parameter2);
            table.Add("Parameter3", entity.Parameter3);
            table.Add("UserId", entity.UserId);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
