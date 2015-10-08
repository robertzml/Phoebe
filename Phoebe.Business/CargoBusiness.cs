using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 货品业务类
    /// </summary>
    public class CargoBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public CargoBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有货品
        /// </summary>
        /// <returns></returns>
        public List<Cargo> Get()
        {
            return this.context.Cargoes.ToList();
        }

        /// <summary>
        /// 获取相关货品
        /// </summary>
        /// <param name="status">货品状态</param>
        /// <returns></returns>
        public List<Cargo> Get(EntityStatus status)
        {
            return this.context.Cargoes.Where(r => r.Status == (int)status).OrderBy(r => r.RegisterTime).ToList();
        }

        /// <summary>
        /// 获取相关货品
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <param name="customerType">客户类型</param>
        /// <returns></returns>
        public List<Cargo> GetByCustomer(int customerID, int customerType)
        {
            var data = from r in this.context.Cargoes
                       where (from s in this.context.Contracts
                              where s.CustomerID == customerID && s.CustomerType == customerType
                              select s.ID).Contains(r.ContractID)
                       orderby r.RegisterTime
                       select r;

            return data.ToList();
        }

        /// <summary>
        /// 获取相关货品
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Cargo> Get(EntityStatus[] status)
        {
            int[] s = status.Cast<int>().ToArray();
            return this.context.Cargoes.Where(r => s.Contains(r.Status)).ToList();
        }

        /// <summary>
        /// 获取货品
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Cargo Get(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.Cargoes.Find(gid);
        }

        /// <summary>
        /// 添加货品
        /// </summary>
        /// <param name="data">货品数据</param>
        /// <returns></returns>
        public ErrorCode Create(Cargo data)
        {
            try
            {
                data.ID = Guid.NewGuid();
                data.Status = (int)EntityStatus.CargoNotIn;

                this.context.Cargoes.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
