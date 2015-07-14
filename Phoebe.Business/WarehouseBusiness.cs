using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 仓库业务类
    /// </summary>
    public class WarehouseBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public WarehouseBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有仓库
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> Get()
        {
            return this.context.Warehouses.ToList();
        }
        #endregion //Method

    }
}
