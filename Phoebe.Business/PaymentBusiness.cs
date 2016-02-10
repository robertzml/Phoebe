using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 缴费业务类
    /// </summary>
    public class PaymentBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public PaymentBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有缴费记录
        /// </summary>
        /// <returns></returns>
        public List<Payment> Get()
        {
            return this.context.Payments.ToList();
        }

        /// <summary>
        /// 获取客户所有缴费记录
        /// </summary>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public List<Payment> Get(int customerID)
        {
            return this.context.Payments.Where(r => r.CustomerID == customerID).ToList();
        }

        /// <summary>
        /// 添加缴费
        /// </summary>
        /// <param name="data">缴费记录</param>
        /// <returns></returns>
        public ErrorCode Create(Payment data)
        {
            try
            {
                this.context.Payments.Add(data);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
