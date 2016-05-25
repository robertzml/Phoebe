using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.BL
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 结算业务类
    /// </summary>
    public class SettlementBusiness : BaseBusiness<Settlement>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Settlement> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 结算业务类
        /// </summary>
        public SettlementBusiness() : base()
        {
            this.dal = RepositoryFactory<SettlementRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
