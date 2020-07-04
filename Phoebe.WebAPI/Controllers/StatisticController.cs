using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Model;
    using Phoebe.Core.Service;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 统计报表控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 获取合同一段时间内所有费用记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> GetExpenseRecord(DailyColdFeeModel model)
        {
            ExpenseService expenseService = new ExpenseService();
            var task = Task.Run(() =>
            {
                var result = expenseService.GetExpenseRecord(model.CustomerId, model.ContractId, model.StartTime, model.EndTime);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage,
                    Entity = result.data
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 获取客户出入库流水
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockFlow>> GetCustomerStockFlow(int customerId, DateTime startTime, DateTime endTime)
        {
            StatisticService statisticService = new StatisticService();

            return statisticService.GetCustomerStockFlow(customerId, startTime, endTime);
        }

        /// <summary>
        /// 获取客户实时欠费
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Debt> GetDebt(int customerId)
        {
            ExpenseService expenseService = new ExpenseService();
            return expenseService.GetDebt(customerId);
        }

        /// <summary>
        /// 获取客户费用报表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CustomerFee>> GetCustomerFee(int customerId, DateTime startTime, DateTime endTime)
        {
            ExpenseService expenseService = new ExpenseService();

            if (customerId == 0)
            {
                CustomerBusiness customerBusiness = new CustomerBusiness();
                var customers = customerBusiness.FindAll();

                List<CustomerFee> data = new List<CustomerFee>();

                foreach (var customer in customers)
                {
                    var fee = expenseService.GetCustomerFee(customer.Id, startTime, endTime);
                    if (fee.TotalFee != 0 || fee.StartDebt != 0 || fee.EndDebt != 0)
                        data.Add(fee);
                }

                return data;
            }
            else
            {
                var fee = expenseService.GetCustomerFee(customerId, startTime, endTime);

                List<CustomerFee> data = new List<CustomerFee>();
                data.Add(fee);

                return data;
            }
        }

        /// <summary>
        /// 获取客户货品库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CustomerCargoStore>> GetCustomerCargoStore(int contractId, DateTime date)
        {
            StatisticService statisticService = new StatisticService();
            return statisticService.GetCustomerCargoStore(contractId, date);
        }
        #endregion //Action
    }
}