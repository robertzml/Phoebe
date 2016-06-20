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
    /// 冰块流水业务类
    /// </summary>
    public class IceFlowBusiness : BaseBusiness<IceFlow>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<IceFlow> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块流水业务类
        /// </summary>
        public IceFlowBusiness() : base()
        {
            this.dal = RepositoryFactory<IceFlowRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
