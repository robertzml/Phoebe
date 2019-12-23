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
        public ActionResult<List<StoreView>> FindStoreIn(int positionId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindStoreIn(positionId);
        }

        /// <summary>
        /// 按合同查找库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="isStoreIn"></param>
        /// <returns></returns>
        [HttpGet]
        public List<StoreView> FindByContract(int contractId, bool isStoreIn)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByContract(contractId, isStoreIn);
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        public List<StoreView> FindByCargo(int contractId, string cargoId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByCargo(contractId, cargoId, true);
        }
        #endregion //Action
    }
}