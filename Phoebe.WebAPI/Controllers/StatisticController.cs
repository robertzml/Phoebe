﻿using System;
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
        public async Task<ActionResult<ResponseData>> GetPeriodExpense(DailyColdFeeModel model)
        {
            StatisticService statisticService = new StatisticService();
            var task = Task.Run(() =>
            {
                var result = statisticService.GetPeriodExpense(model.CustomerId, model.ContractId, model.StartTime, model.EndTime);

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
        /// 获取客户费用报表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CustomerFee>> GetCustomerFee(int customerId, DateTime startTime, DateTime endTime)
        {
            SettlementService settlementService = new SettlementService();

            if (customerId == 0)
            {
                CustomerBusiness customerBusiness = new CustomerBusiness();
                var customers = customerBusiness.FindAll();

                List<CustomerFee> data = new List<CustomerFee>();

                foreach (var customer in customers)
                {
                    var fee = settlementService.GetCustomerFee(customer.Id, startTime, endTime);
                    if (fee.StartDebt != 0 || fee.EndDebt != 0)
                        data.Add(fee);
                }

                return data;
            }
            else
            {
                var fee = settlementService.GetCustomerFee(customerId, startTime, endTime);

                List<CustomerFee> data = new List<CustomerFee>();
                data.Add(fee);

                return data;
            }
        }
        #endregion //Action
    }
}