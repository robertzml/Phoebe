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
    /// 货品对象数据访问类
    /// </summary>
    internal class CargoRepository : AbstractDALSql<Cargo, string>, ICargoRepository
    {
        #region Constructor
        /// <summary>
        /// 货品对象数据访问类
        /// </summary>
        public CargoRepository() : base("Cargo", "Id")
        {
            base.Init(ConnectionSource.Cache, Utility.PhoebeConstant.ConnectionStringCacheKey);
        }
        #endregion //Constructor

        #region Function
        protected override Cargo DataReaderToEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DataRow转实体对象
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <returns></returns>
        protected override Cargo DataRowToEntity(DataRow row)
        {
            Cargo entity = new Cargo();
            entity.Id = row["Id"].ToString();
            entity.CategoryId = Convert.ToInt32(row["CategoryId"]);
            entity.GroupType = Convert.ToInt32(row["GroupType"]);
            entity.UnitWeight = Convert.ToDecimal(row["UnitWeight"]);
            entity.UnitVolume = Convert.ToDecimal(row["UnitVolume"]);
            entity.ContractId = Convert.ToInt32(row["ContractId"]);
            entity.RegisterTime = Convert.ToDateTime(row["RegisterTime"]);

            if (row["Remark"] == DBNull.Value)
                entity.Remark = "";
            else
                entity.Remark = row["Remark"].ToString();
            entity.Status = Convert.ToInt32(row["Status"]);

            return entity;
        }

        /// <summary>
        /// 实体对象转Hashtable
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override Hashtable EntityToHash(Cargo entity)
        {
            Hashtable table = new Hashtable();
            table.Add("Id", entity.Id);
            table.Add("CategoryId", entity.CategoryId);
            table.Add("GroupType", entity.GroupType);
            table.Add("UnitWeight", entity.UnitWeight);
            table.Add("UnitVolume", entity.UnitVolume);
            table.Add("ContractId", entity.ContractId);
            table.Add("RegisterTime", entity.RegisterTime);
            table.Add("Remark", entity.Remark);
            table.Add("Status", entity.Status);

            return table;
        }
        #endregion //Function
    }
}
