﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 货品控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 货品列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CargoView>> List(int? customerId, int? contractId)
        {
            CargoViewBusiness cargoViewBusiness = new CargoViewBusiness();
            if (customerId.HasValue)
            {
                if (customerId.Value == 0)
                    return cargoViewBusiness.FindAll();
                else
                {
                    var cid = 0;
                    if (contractId.HasValue)
                        cid = contractId.Value;
                    return cargoViewBusiness.FindByCustomer(customerId.Value, cid);
                }
            }
            else
                return cargoViewBusiness.FindAll();
        }
        #endregion //Action
    }
}