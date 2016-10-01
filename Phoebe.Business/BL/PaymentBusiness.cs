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
    /// 缴费业务类
    /// </summary>
    public class PaymentBusiness : BaseBusiness<Payment>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Payment> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 缴费业务类
        /// </summary>
        public PaymentBusiness() : base()
        {
            this.dal = RepositoryFactory<PaymentRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 创建新票号
        /// </summary>
        /// <param name="paidTime">缴费时间</param>
        /// <returns></returns>
        private string CreateTicketNumber(DateTime paidTime)
        {
            var data = this.dal.Find(r => r.PaidTime == paidTime).OrderByDescending(r => r.TicketNumber);

            if (data.Count() == 0)
                return string.Format("{0}{1}{2}-0001",
                    paidTime.Year, paidTime.Month.ToString().PadLeft(2, '0'), paidTime.Day.ToString().PadLeft(2, '0'));
            else
            {
                int newNumber = Convert.ToInt32(data.First().TicketNumber.Substring(9)) + 1;
                return string.Format("{0}{1}{2}-{3}", paidTime.Year, paidTime.Month.ToString().PadLeft(2, '0'),
                    paidTime.Day.ToString().PadLeft(2, '0'), newNumber.ToString().PadLeft(4, '0'));
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取客户缴费记录
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        public List<Payment> GetByCustomer(int customerId)
        {
            var payments = this.dal.Find(r => r.CustomerId == customerId);
            return payments.ToList();
        }

        /// <summary>
        /// 查询时间段内缴费
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <returns></returns>
        public List<Payment> Get(DateTime start, DateTime end)
        {
            var payments = this.dal.Find(r => r.PaidTime >= start && r.PaidTime <= end);
            return payments.ToList();
        }

        /// <summary>
        /// 添加缴费
        /// </summary>
        /// <param name="entity">缴费对象</param>
        /// <returns></returns>
        public override ErrorCode Create(Payment entity)
        {
            entity.Id = Guid.NewGuid();
            entity.TicketNumber = CreateTicketNumber(entity.PaidTime);
            entity.Status = 0;

            var result = this.dal.Create(entity);
            return result;
        }
        #endregion //Method
    }
}
