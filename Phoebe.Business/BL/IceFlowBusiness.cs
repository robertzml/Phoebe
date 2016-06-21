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
        /// <summary>
        /// 新增流水
        /// </summary>
        /// <param name="entity">流水对象</param>
        /// <returns></returns>
        public override ErrorCode Create(IceFlow entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Status = 0;

            var trans = new TransactionRepository();
            var result = trans.IceFlowAddTrans(entity);
            return result;
        }
        #endregion //Method
    }
}
