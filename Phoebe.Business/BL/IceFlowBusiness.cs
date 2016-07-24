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

        #region Function
        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="flowTime">流水时间</param>
        /// <returns></returns>
        private string GetLastFlowNumber(DateTime flowTime)
        {
            Expression<Func<IceFlow, bool>> predicate = r => r.FlowTime == flowTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    flowTime.Year, flowTime.Month.ToString().PadLeft(2, '0'), flowTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().FlowNumber.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", flowTime.Year, flowTime.Month.ToString().PadLeft(2, '0'),
                    flowTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 按时间段获取流水
        /// </summary>
        /// <param name="from">开始日期</param>
        /// <param name="to">结束日期</param>
        /// <returns></returns>
        public List<IceFlow> Get(DateTime from, DateTime to)
        {
            var data = this.dal.Find(r => r.FlowTime >= from && r.FlowTime <= to).OrderByDescending(r => r.FlowTime);
            return data.ToList();
        }

        /// <summary>
        /// 按时间段获取流水
        /// </summary>
        /// <param name="from">开始日期</param>
        /// <param name="to">结束日期</param>
        /// <param name="flowType">流水类型</param>
        /// <returns></returns>
        public List<IceFlow> Get(DateTime from, DateTime to, IceFlowType flowType)
        {
            var data = this.dal.Find(r => r.FlowTime >= from && r.FlowTime <= to && r.FlowType == (int)flowType).OrderByDescending(r => r.FlowTime);
            return data.ToList();
        }

        /// <summary>
        /// 新增流水
        /// </summary>
        /// <param name="entity">流水对象</param>
        /// <returns></returns>
        public override ErrorCode Create(IceFlow entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Status = 0;

            //check store count
            if (entity.FlowType == (int)IceFlowType.CompleteMakeOut)
            {
                var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)entity.IceType);
                if (entity.FlowCount > store.Count)
                    return ErrorCode.IceOutCountOverflow;
                if (entity.FlowWeight > store.Weight)
                    return ErrorCode.IceOutWeightOverflow;
            }

            var trans = new TransactionRepository();
            var result = trans.IceFlowAddTrans(entity);
            return result;
        }

        /// <summary>
        /// 删除冰块流水
        /// </summary>
        /// <param name="entity">冰块流水</param>
        /// <returns></returns>
        public override ErrorCode Delete(IceFlow entity)
        {
            if (entity.FlowType == (int)IceFlowType.CompleteStockIn || entity.FlowType == (int)IceFlowType.FragmentStockIn)
            {
                var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)entity.IceType);
                if (entity.FlowCount > store.Count)
                    return ErrorCode.IceDeleteCountOverflow;
                if (entity.FlowWeight > store.Weight)
                    return ErrorCode.IceDeleteWeightOverflow;
            }

            var trans = new TransactionRepository();
            var result = trans.IceFlowDeleteTrans(entity);

            return result;
        }
        #endregion //Method
    }
}
