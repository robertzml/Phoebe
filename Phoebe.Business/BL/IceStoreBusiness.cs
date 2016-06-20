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
    /// 冰块库存业务类
    /// </summary>
    public class IceStoreBusiness : BaseBusiness<IceStore>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<IceStore> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块库存业务类
        /// </summary>
        public IceStoreBusiness() : base()
        {
            this.dal = RepositoryFactory<IceStoreRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
