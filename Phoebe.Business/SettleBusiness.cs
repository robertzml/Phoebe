using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettleBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public SettleBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取结算列表
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Settlement> Get(EntityStatus status)
        {
            return this.context.Settlements.Where(r => r.Status == (int)status).ToList();
        }
        #endregion //Method
    }
}
