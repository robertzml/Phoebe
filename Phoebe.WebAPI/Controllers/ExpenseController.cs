using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.Model;
    using Phoebe.Core.Service;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 费用管理控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 获取日冷藏费记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> DailyColdFee(DailyColdFeeModel model)
        {
            ExpenseService expenseService = new ExpenseService();
            var task = Task.Run(() =>
            {
                var result = expenseService.GetDailyColdFee(model.CustomerId, model.ContractId, model.StartTime, model.EndTime);

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
        #endregion //Action
    }
}