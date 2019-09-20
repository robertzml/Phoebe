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
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 库存控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 查找在库库存
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StoreView> FindStoreIn(int positionId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindStoreIn(positionId);
        }
        #endregion //Action
    }
}