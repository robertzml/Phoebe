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
        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="settlement">结算信息</param>
        /// <param name="details">详细记录</param>
        /// <returns></returns>
        public ErrorCode Create(Settlement settlement, List<SettlementDetail> details)
        {
            TransactionRepository trans = new TransactionRepository();
            return trans.SettlementAddTrans(settlement, details);
        }
        #endregion //Method
    }
}
