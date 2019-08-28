using System;
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
    /// 仓库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 仓库列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Warehouse>> List()
        {
            WarehouseBusiness warehouseBusiness = new WarehouseBusiness();
            return warehouseBusiness.FindAll();
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Warehouse warehouse)
        {
            WarehouseBusiness warehouseBusiness = new WarehouseBusiness();

            var task = Task.Run(() =>
            {
                var result = warehouseBusiness.Create(warehouse);

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
    }
}