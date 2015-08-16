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
        /// 获取货品
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Cargo Get(string id)
        {
            Guid gid;
            if (!Guid.TryParse(id, out gid))
                return null;

            return this.context.Cargoes.SingleOrDefault(r => r.ID == gid);
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
                data.RegisterTime = DateTime.Now;
                data.Status = (int)EntityStatus.CargoNotEntry;

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
