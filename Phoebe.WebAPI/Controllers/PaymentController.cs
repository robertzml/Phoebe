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

        #endregion //Action

        #region Query
        /// <summary>
        /// 合同列表
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
        #endregion //Query
    }
}