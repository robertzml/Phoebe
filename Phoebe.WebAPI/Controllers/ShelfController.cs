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
    /// 货架控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 货架列表
        /// </summary>
        /// <param name="warehouseId">所属仓库</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Shelf>> List(int? warehouseId)
        {
            ShelfBusiness shelfBusiness = new ShelfBusiness();
            if (warehouseId.HasValue)
            {
                if (warehouseId.Value == 0)
                    return shelfBusiness.FindAll();
                else
                    return shelfBusiness.Query(r => r.WarehouseId == warehouseId.Value);
            }
            else
            {
                return shelfBusiness.FindAll();
            }
        }

        /// <summary>
        /// 货架信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Shelf> Get(int id)
        {
            ShelfBusiness shelfBusiness = new ShelfBusiness();
            return shelfBusiness.FindById(id);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 添加货架
        /// </summary>
        /// <param name="shelf"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Shelf shelf)
        {
            ShelfBusiness shelfBusiness = new ShelfBusiness();

            var task = Task.Run(() =>
            {
                var result = shelfBusiness.Create(shelf);

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
        /// 编辑货架
        /// </summary>
        /// <param name="shelf"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Shelf shelf)
        {
            ShelfBusiness shelfBusiness = new ShelfBusiness();

            var task = Task.Run(() =>
            {
                var result = shelfBusiness.Update(shelf);

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