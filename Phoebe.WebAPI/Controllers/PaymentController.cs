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
    /// 缴费控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 添加缴费
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Payment payment)
        {
            PaymentBusiness paymentBusiness = new PaymentBusiness();

            var task = Task.Run(() =>
            {
                var result = paymentBusiness.Create(payment);

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

        /// <summary>
        /// 编辑缴费
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Payment payment)
        {
            PaymentBusiness paymentBusiness = new PaymentBusiness();

            var task = Task.Run(() =>
            {
                var result = paymentBusiness.Update(payment);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage,
                    Entity = null
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 删除缴费
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            PaymentBusiness paymentBusiness = new PaymentBusiness();

            var task = Task.Run(() =>
            {
                var result = paymentBusiness.Delete(id);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Action

        #region Query
        /// <summary>
        /// 缴费列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PaymentView>> List(int? customerId)
        {
            PaymentViewBusiness paymentViewBusiness = new PaymentViewBusiness();
            if (customerId.HasValue)
            {
                if (customerId.Value == 0)
                    return paymentViewBusiness.FindAll();
                else
                    return paymentViewBusiness.Query(r => r.CustomerId == customerId.Value);
            }
            else
                return paymentViewBusiness.FindAll();
        }

        /// <summary>
        /// 缴费信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaymentView> Get(string id)
        {
            PaymentViewBusiness paymentViewBusiness = new PaymentViewBusiness();
            return paymentViewBusiness.FindById(id);
        }
        #endregion //Query
    }
}