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
        #region Query
        /// <summary>
        /// 货品列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CargoView>> List(int? customerId)
        {
            CargoViewBusiness cargoViewBusiness = new CargoViewBusiness();
            if (customerId.HasValue)
            {
                if (customerId.Value == 0)
                    return cargoViewBusiness.FindAll();
                else
                    return cargoViewBusiness.Query(r => r.CustomerId == customerId.Value);
            }
            else
                return cargoViewBusiness.FindAll();
        }

        /// <summary>
        /// 货品列表
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CargoView>> ListByNumber(string customerNumber)
        {
            CargoViewBusiness cargoViewBusiness = new CargoViewBusiness();
            if (string.IsNullOrEmpty(customerNumber))
                return cargoViewBusiness.FindAll();
            else
                return cargoViewBusiness.Query(r => r.CustomerNumber == customerNumber);
        }

        /// <summary>
        /// 货品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CargoView> Get(string id)
        {
            CargoViewBusiness cargoViewBusiness = new CargoViewBusiness();
            return cargoViewBusiness.FindById(id);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 添加货物
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Cargo cargo)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();

            var task = Task.Run(() =>
            {
                var result = cargoBusiness.Create(cargo);

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
        /// 编辑货品
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Cargo cargo)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();

            var task = Task.Run(() =>
            {
                var result = cargoBusiness.Update(cargo);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 删除货品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();

            var task = Task.Run(() =>
            {
                var result = cargoBusiness.Delete(id);
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
    }
}