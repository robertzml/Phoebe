using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.Service;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 系统功能控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 修复普通库初始入库单ID
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FixNormalStoreStockInId()
        {
            SystemService systemService = new SystemService();
            var task = Task.Run(() =>
            {
                var result = systemService.FixNormalStoreStockInId();

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
        /// 修复普通库初始入库时间
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FixNormalStoreInitialTime()
        {
            SystemService systemService = new SystemService();
            var task = Task.Run(() =>
            {
                var result = systemService.FixNormalStoreInitialTime();

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