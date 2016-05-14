using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 出库业务类
    /// </summary>
    public class StockOutBusiness : BaseBusiness<StockOut>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<StockOut> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 出库业务类
        /// </summary>
        public StockOutBusiness() : base()
        {
            this.dal = new StockOutRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor
    }
}
