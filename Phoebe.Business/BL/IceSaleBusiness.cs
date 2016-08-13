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
        /// <summary>
        /// 根据流水获取销售记录
        /// </summary>
        /// <param name="flowId">流水ID</param>
        /// <returns></returns>
        public List<IceSale> GetByFlow(Guid flowId)
        {
            var data = this.dal.Find(r => r.FlowId == flowId);
            return data.ToList();
        }

        /// <summary>
        /// 根据合同获取销售记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<IceSale> GetByContract(int contractId, DateTime start, DateTime end)
        {
            var data = this.dal.Find(r => r.IceFlow.ContractId == contractId && r.IceFlow.FlowTime >= start && r.IceFlow.FlowTime <= end);
            return data.ToList();
        }

        /// <summary>
        /// 添加销售
        /// </summary>
        /// <param name="iceSales">冰块销售对象</param>
        /// <param name="iceFlow">冰块流水</param>
        /// <returns></returns>
        public ErrorCode Create(List<IceSale> iceSales, IceFlow iceFlow)
        {
            iceFlow.Id = Guid.NewGuid();
            iceFlow.FlowNumber = BusinessFactory<IceFlowBusiness>.Instance.GetLastFlowNumber(iceFlow.FlowTime);
            iceFlow.MonthTime = iceFlow.FlowTime.Year.ToString() + iceFlow.FlowTime.Month.ToString().PadLeft(2, '0');
            iceFlow.Status = 0;

            foreach (var item in iceSales)
            {
                item.Id = Guid.NewGuid();
                item.FlowId = iceFlow.Id;
                item.Status = 0;

                //check store count
                var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)item.IceType);
                if (item.SaleCount > store.Count)
                    return ErrorCode.IceOutCountOverflow;
            }

            TransactionRepository trans = new TransactionRepository();
            var result = trans.IceSaleAddTrans(iceSales, iceFlow);

            return result;
        }
        #endregion //Method
    }
}
