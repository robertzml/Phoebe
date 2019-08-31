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
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 仓位控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 仓位列表
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Position>> List(int shelfId)
        {
            PositionBusiness positionBusiness = new PositionBusiness();
            return positionBusiness.FindByShelf(shelfId);
        }

        /// <summary>
        /// 生成仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Generate(int shelfId)
        {
            PositionBusiness positionBusiness = new PositionBusiness();

            var task = Task.Run(() =>
            {
                var result = positionBusiness.Generate(shelfId);

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
        #endregion //Action
    }
}