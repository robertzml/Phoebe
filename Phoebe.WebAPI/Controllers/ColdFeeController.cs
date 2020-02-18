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
    using Phoebe.Core.Entity;
    using Phoebe.Core.Service;
    using Phoebe.Core.View;

    /// <summary>
    /// 冷藏费控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ColdFeeController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 获取冷藏费记录
        /// </summary>
        /// <param name="storeId">库存ID</param>
        /// <param name="current">当前日期</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ColdFee> GetByStore(string storeId, DateTime current)
        {
            ColdFeeService coldFeeService = new ColdFeeService();
            return coldFeeService.FindByStore(storeId, current);
        }
        #endregion //Query
    }
}