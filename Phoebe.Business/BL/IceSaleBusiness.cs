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
    /// 冰块销售业务类
    /// </summary>
    public class IceSaleBusiness : BaseBusiness<IceSale>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<IceSale> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块销售业务类
        /// </summary>
        public IceSaleBusiness() : base()
        {
            this.dal = RepositoryFactory<IceSaleRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
