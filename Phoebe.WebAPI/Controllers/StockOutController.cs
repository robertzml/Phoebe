using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 出库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockOutController : ControllerBase
    {
        #region Common
        /// <summary>
        /// 获取月度分组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] GetMonthGroup()
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.GetMonthGroup();
        }
        #endregion //Common

        #region Stock Out
        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> List(string monthTime)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            if (string.IsNullOrEmpty(monthTime))
            {
                return stockOutViewBusiness.FindAll();
            }
            else
            {
                return stockOutViewBusiness.FindByMonth(monthTime);
            }
        }

        /// <summary>
        /// 添加出库
        /// </summary>
        /// <param name="stockOut"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(StockOut stockOut)
        {
            StockOutBusiness stockOutBusiness = new StockOutBusiness();

            var task = Task.Run(() =>
            {
                var result = stockOutBusiness.Create(stockOut);

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
        /// 获取出库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StockOutView> Get(string id)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindById(id);
        }
        #endregion //Stock Out

        #region Stock Out Task
        /// <summary>
        /// 添加出库任务
        /// </summary>
        /// <param name="stockOut"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> AddTask(StockOutTask outTask)
        {
            StockOutTaskBusiness stockOutTaskBusiness = new StockOutTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = stockOutTaskBusiness.Create(outTask);

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
        #endregion //Stock Out Task
    }
}