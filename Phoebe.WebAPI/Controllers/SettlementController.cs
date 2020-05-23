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
    using Phoebe.Core.Service;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 结算控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 添加结算
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Settlement settlement)
        {
            SettlementBusiness settlementBusiness = new SettlementBusiness();

            var task = Task.Run(() =>
            {
                var result = settlementBusiness.Create(settlement);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage,
                    Entity = result.t
                };

                return data;
            });

            return await task;
        }
        #endregion //Action

        #region Query
        /// <summary>
        /// 结算列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SettlementView>> List(int? customerId)
        {
            SettlementViewBusiness settlementViewBusiness = new SettlementViewBusiness();
            if (customerId.HasValue)
            {
                if (customerId.Value == 0)
                    return settlementViewBusiness.FindAll();
                else
                    return settlementViewBusiness.Query(r => r.CustomerId == customerId.Value);
            }
            else
                return settlementViewBusiness.FindAll();
        }


        /// <summary>
        /// 结算信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<SettlementView> Get(string id)
        {
            SettlementViewBusiness settlementViewBusiness = new SettlementViewBusiness();
            return settlementViewBusiness.FindById(id);
        }

        /// <summary>
        /// 获取入库费用
        /// </summary>
        /// <param name="customerId">客户ID</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<InBillingView>> GetPeriodInBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            SettlementService settlementService = new SettlementService();
            return settlementService.GetPeriodInBilling(customerId, startTime, endTime);
        }

        /// <summary>
        /// 获取出库费用
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<OutBillingView>> GetPeriodOutBilling(int customerId, DateTime startTime, DateTime endTime)
        {
            SettlementService settlementService = new SettlementService();
            return settlementService.GetPeriodOutBilling(customerId, startTime, endTime);
        }
        #endregion //Query
    }
}