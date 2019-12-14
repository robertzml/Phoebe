using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 搬运入库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarryInTaskController : ControllerBase
    {
        #region Action
        public async Task<ActionResult<ResponseData>> Create(CarryInTask carryInTask)
        {
            CarryInTaskBusiness carryInTaskBusiness = new CarryInTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = carryInTaskBusiness.Create(carryInTask);

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