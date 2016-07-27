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
    /// 冰块出入库业务类
    /// </summary>
    public class IceStockBusiness : BaseBusiness<IceStock>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<IceStock> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块出入库业务类
        /// </summary>
        public IceStockBusiness() : base()
        {
            this.dal = RepositoryFactory<IceStockRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据流水获取记录
        /// </summary>
        /// <param name="flowId">流水ID</param>
        /// <returns></returns>
        public IceStock GetByFlow(Guid flowId)
        {
            var data = this.dal.FindOne(r => r.FlowId == flowId);
            return data;
        }

        /// <summary>
        /// 新增冰块出入库
        /// </summary>
        /// <param name="iceStock">出入库记录</param>
        /// <param name="iceFlow">流水记录</param>
        /// <returns></returns>
        public ErrorCode Create(IceStock iceStock, IceFlow iceFlow)
        {
            iceFlow.Id = Guid.NewGuid();
            iceFlow.FlowNumber = BusinessFactory<IceFlowBusiness>.Instance.GetLastFlowNumber(iceFlow.FlowTime);
            iceFlow.MonthTime = iceFlow.FlowTime.Year.ToString() + iceFlow.FlowTime.Month.ToString().PadLeft(2, '0');
            iceFlow.Status = 0;

            iceStock.Id = Guid.NewGuid();
            iceStock.FlowId = iceFlow.Id;
            iceStock.Status = 0;

            if (iceFlow.FlowType == (int)IceFlowType.CompleteMakeOut)
            {
                var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)iceStock.IceType);
                if (iceStock.FlowCount > store.Count)
                    return ErrorCode.IceOutCountOverflow;
            }

            TransactionRepository trans = new TransactionRepository();
            var result = trans.IceStockAddTrans(iceStock, iceFlow);

            return result;
        }
        #endregion //Method
    }
}
