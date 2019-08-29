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
        #region Action
        /// <summary>
        /// 货架列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Shelf>> List()
        {
            ShelfBusiness shelfBusiness = new ShelfBusiness();
            return shelfBusiness.FindAll();
        }


        /// <summary>
        /// 添加货架
        /// </summary>
        /// <param name="customer"></param>
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
        #endregion //Action
    }
}