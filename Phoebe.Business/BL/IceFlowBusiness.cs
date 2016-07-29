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

        #endregion //Function

        #region Method
        /// <summary>
        /// 获取月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetMonthGroup()
        {
            var data = this.dal.FindAll().Where(r => r.FlowType == (int)IceFlowType.CompleteStockIn || r.FlowType == (int)IceFlowType.FragmentStockIn || r.FlowType == (int)IceFlowType.CompleteMakeOut)
                .GroupBy(r => r.MonthTime).Select(g => g.Key).OrderByDescending(s => s);
            return data.ToArray();
        }

        /// <summary>
        /// 获取冰块销售月份分组
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 用于树形导航分组
        /// </remarks>
        public string[] GetSaleMonthGroup()
        {
            var data = this.dal.FindAll().Where(r => r.FlowType == (int)IceFlowType.IceSale)
                .GroupBy(s => s.MonthTime).Select(g => g.Key).OrderByDescending(t => t);
            return data.ToArray();
        }

        /// <summary>
        /// 按月度获取记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<IceFlow> GetByMonth(string monthTime)
        {
            Expression<Func<IceFlow, bool>> predicate = r => r.MonthTime == monthTime &&
                (r.FlowType == (int)IceFlowType.CompleteStockIn || r.FlowType == (int)IceFlowType.FragmentStockIn || r.FlowType == (int)IceFlowType.CompleteMakeOut);
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 按月度获取冰块销售记录
        /// </summary>
        /// <param name="monthTime">月份</param>
        /// <returns></returns>
        public List<IceFlow> GetSaleByMonth(string monthTime)
        {
            Expression<Func<IceFlow, bool>> predicate = r => r.MonthTime == monthTime && r.FlowType == (int)IceFlowType.IceSale;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.FlowNumber);
            return data.ToList();
        }

        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="flowTime">流水时间</param>
        /// <returns></returns>
        public string GetLastFlowNumber(DateTime flowTime)
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
        /// 按时间段获取出入库流水
        /// </summary>
        /// <param name="from">开始日期</param>
        /// <param name="to">结束日期</param>
        /// <returns></returns>
        public List<IceFlow> GetStock(DateTime from, DateTime to)
        {
            var data = this.dal.Find(r => r.FlowTime >= from && r.FlowTime <= to &&
                (r.FlowType == (int)IceFlowType.CompleteStockIn) || r.FlowType == (int)IceFlowType.FragmentStockIn || r.FlowType == (int)IceFlowType.CompleteMakeOut)
                .OrderByDescending(r => r.FlowTime);
            return data.ToList();
        }

        /// <summary>
        /// 删除冰块流水
        /// </summary>
        /// <param name="entity">冰块流水</param>
        /// <returns></returns>
        public override ErrorCode Delete(IceFlow entity)
        {
            IceFlowType flowType = (IceFlowType)entity.FlowType;

            if (flowType == IceFlowType.CompleteStockIn || flowType == IceFlowType.FragmentStockIn)
            {
                var iceStock = BusinessFactory<IceStockBusiness>.Instance.GetByFlow(entity.Id);
                var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)iceStock.IceType);

                if (store.Count < iceStock.FlowCount)
                    return ErrorCode.IceOutCountOverflow;
            }

            var trans = new TransactionRepository();
            var result = trans.IceFlowDeleteTrans(entity);

            return result;
        }
        #endregion //Method
    }
}
