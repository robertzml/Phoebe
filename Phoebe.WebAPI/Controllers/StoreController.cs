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
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Service;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 库存控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        #region Query
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
        /// <remarks>
        /// 库存状态为：在库，准备移入
        /// </remarks>
        [HttpGet]
        public ActionResult<List<StoreView>> FindStoreIn(int positionId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness
                .Query(r => r.PositionId == positionId && (r.Status == (int)EntityStatus.StoreIn || r.Status == (int)EntityStatus.StoreInReady));
        }

        /// <summary>
        /// 按合同查找库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindByContract(int contractId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.Query(r => r.ContractId == contractId);
        }

        /// <summary>
        /// 按货品查找库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindByCargo(int contractId, string cargoId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.Query(r => r.ContractId == contractId && r.CargoId == cargoId && r.Status == (int)EntityStatus.StoreIn);
        }

        /// <summary>
        /// 按托盘码查找库存
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindByTray(string trayCode)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindByTray(trayCode);
        }

        /// <summary>
        /// 根据货架码获取最外侧库存
        /// </summary>
        /// <param name="shelfCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindOutside(string shelfCode)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindOutside(shelfCode);
        }

        /// <summary>
        /// 出库时查找库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="cargoId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> FindForStockOut(int contractId, string cargoId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.FindForStockOut(contractId, cargoId);
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

        /// <summary>
        /// 获取指定仓位托盘码
        /// </summary>
        /// <param name="positionId">仓位ID</param>
        /// <returns></returns>
        [HttpGet]
        public string GetPositionTray(int positionId)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.GetPositionTray(positionId);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 添加搬运入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> MoveTray(MoveTrayModel model)
        {
            StoreService storeService = new StoreService();

            var task = Task.Run(() =>
            {
                var result = storeService.MoveTray(model.PositionId, model.TargetPosition, model.UserId);

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

        /// <summary>
        /// 删除库存记录
        /// </summary>
        /// <param name="id">库存ID</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> ForceDelete(string id)
        {
            StoreService storeService = new StoreService();

            var task = Task.Run(() =>
            {
                var result = storeService.DeleteStore(id);

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

        #region Storage
        /// <summary>
        /// 获取库存记录链表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> GetInOrder(string id)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.GetInOrder(id);
        }

        /// <summary>
        /// 获取指定日库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StoreView>> GetInDay(int contractId, DateTime date)
        {
            StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
            return storeViewBusiness.GetInDay(contractId, date);
        }
        #endregion //Storage
    }
}