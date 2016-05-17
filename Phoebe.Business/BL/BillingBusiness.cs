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
    /// 计费业务类
    /// </summary>
    public class BillingBusiness : BaseBusiness<Billing>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Billing> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 计费业务类
        /// </summary>
        public BillingBusiness() : base()
        {
            this.dal = new BillingRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
