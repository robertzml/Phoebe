using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 冰块销售控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IceSaleController : ControllerBase
    {
        #region Method
        /// <summary>
        /// 冰块销售列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<IceSaleView>> List(int year)
        {
            IceSaleViewBusiness iceSaleViewBusiness = new IceSaleViewBusiness();
            return iceSaleViewBusiness.FindByYear(year);
        }

        /// <summary>
        /// 整冰销售数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetCompleteSale()
        {
            IceSaleViewBusiness iceSaleViewBusiness = new IceSaleViewBusiness();
            return iceSaleViewBusiness.GetCompleteSaleCount();
        }

        /// <summary>
        /// 碎冰销售数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetFragmentSale()
        {
            IceSaleViewBusiness iceSaleViewBusiness = new IceSaleViewBusiness();
            return iceSaleViewBusiness.GetFragmentSaleCount();
        }

        /// <summary>
        /// 整冰在库数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetCompleteStore()
        {
            IceSaleViewBusiness iceSaleViewBusiness = new IceSaleViewBusiness();
            return iceSaleViewBusiness.GetCompleteStoreCount();
        }

        /// <summary>
        /// 碎冰销售数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetFragmentStore()
        {
            IceSaleViewBusiness iceSaleViewBusiness = new IceSaleViewBusiness();
            return iceSaleViewBusiness.GetFragmentStoreCount();
        }
        #endregion //Method

        #region Action
        /// <summary>
        /// 添加冰块销售
        /// </summary>
        /// <param name="iceSale"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(IceSale iceSale)
        {
            IceSaleBusiness iceSaleBusiness = new IceSaleBusiness();

            var task = Task.Run(() =>
            {
                var result = iceSaleBusiness.Create(iceSale);

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
        /// 删除销售记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            IceSaleBusiness iceSaleBusiness = new IceSaleBusiness();
            var task = Task.Run(() =>
            {
                var result = iceSaleBusiness.Delete(id);

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
