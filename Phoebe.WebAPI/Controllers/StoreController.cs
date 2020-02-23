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
        /// 获取所有库存
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> List()
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindAll();
        }

        /// <summary>
        /// 查找在库库存
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindStoreIn(int positionId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByPosition(positionId);
        }

        /// <summary>
        /// 按合同查找库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<StoreView> FindByContract(int contractId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByContract(contractId);
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<StoreView> FindByCargo(int contractId, string cargoId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByCargo(contractId, cargoId, true);
        }

        /// <summary>
        /// 按出库单和货品查找
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<StoreView> FindByStockOut(string stockOutId, string cargoId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByStockOut(stockOutId, cargoId);
        }

        /// <summary>
        /// 按托盘码查找库存
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <returns></returns>
        [HttpGet]
        public List<StoreView> FindByTray(string trayCode)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByTray(trayCode);
        }

        /// <summary>
        /// 库存信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StoreView> Get(string id)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindById(id);
        }
        #endregion //Action
    }
}