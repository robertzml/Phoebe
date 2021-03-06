﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    /// 合同控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ContractView>> List(int? customerId)
        {
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            if (customerId.HasValue)
            {
                if (customerId.Value == 0)
                    return contractViewBusiness.FindAll();
                else
                    return contractViewBusiness.Query(r => r.CustomerId == customerId.Value);
            }
            else
                return contractViewBusiness.FindAll();
        }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ContractView>> ListByType(int customerId, int type)
        {
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            return contractViewBusiness.Query(r => r.CustomerId == customerId && r.Type == type);
        }

        /// <summary>
        /// 合同信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ContractView> Get(int id)
        {
            ContractViewBusiness contractViewBusiness = new ContractViewBusiness();
            return contractViewBusiness.FindById(id);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Contract contract)
        {
            ContractBusiness contractBusiness = new ContractBusiness();

            var task = Task.Run(() =>
            {
                var result = contractBusiness.Create(contract);

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
        /// 编辑合同
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Contract contract)
        {
            ContractBusiness contractBusiness = new ContractBusiness();

            var task = Task.Run(() =>
            {
                var result = contractBusiness.Update(contract);

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
        /// 强制删除合同
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> ForceDelete(int id)
        {
            ContractService contractService = new ContractService();

            var task = Task.Run(() =>
            {
                var result = contractService.ForceDelete(id);

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