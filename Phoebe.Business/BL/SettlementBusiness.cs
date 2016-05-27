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

        #region Function
        /// <summary>
        /// 获取最新流水单号
        /// </summary>
        /// <param name="settleTime">结算时间</param>
        /// <returns></returns>
        private string GetLastFlowNumber(DateTime settleTime)
        {
            Expression<Func<Settlement, bool>> predicate = r => r.SettleTime == settleTime;
            var data = this.dal.Find(predicate).OrderByDescending(r => r.Number);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}0001",
                    settleTime.Year, settleTime.Month.ToString().PadLeft(2, '0'), settleTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().Number.Substring(8)) + 1;
                return string.Format("{0}{1}{2}{3}", settleTime.Year, settleTime.Month.ToString().PadLeft(2, '0'),
                    settleTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取客户上次结算
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public Settlement GetLast(int customerId)
        {
            var settles = this.dal.FindAll().Where(r => r.CustomerId == customerId).OrderByDescending(r => r.EndTime);            
            if (settles.Count() == 0)
                return null;
            else
                return settles.First();
        }

        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="settlement">结算信息</param>
        /// <param name="details">详细记录</param>
        /// <returns></returns>
        public ErrorCode Create(Settlement settlement, List<SettlementDetail> details)
        {
            settlement.Number = GetLastFlowNumber(settlement.SettleTime);

            TransactionRepository trans = new TransactionRepository();
            return trans.SettlementAddTrans(settlement, details);
        }
        #endregion //Method
    }
}
