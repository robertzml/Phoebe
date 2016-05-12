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
    /// 库存业务类
    /// </summary>
    public class StoreBusiness : BaseBusiness<Store>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Store> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 库存业务类
        /// </summary>
        public StoreBusiness() : base()
        {
            this.dal = new StoreRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor
    }
}
